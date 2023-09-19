using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Flash
{
    public class GalaxyFlashImageHelper
    {
        #region Public Properties
        public Byte Package { get; internal set; }
        public String PackageString { get { return Package.ToString("X2"); } }
        public UInt16 MajorVersion { get; internal set; }
        public UInt16 MinorVersion { get; internal set; }
        public String Description { get; internal set; }
        public UInt32 SumCheck { get; internal set; }
        public String SumCheckString { get { return $"0x{SumCheck.ToString("X8")}"; } }
        public List<S28ErrorInformation> Errors { get; internal set; }
        public List<S28Record> SRecords { get; internal set; }
        public List<EZ80LoadPacket> LoadPackets { get; internal set; }
        public bool SumCheckVerified { get; internal set; }

        public UInt32 CRC_118 { get; internal set; }
        public UInt32 CRC_119 { get; internal set; }
        public UInt32 CRC_Ex { get; internal set; }
        public UInt32 CRC { get; internal set; }
        public int SystemType { get; internal set; }
        public byte[] Data { get; internal set; }
        public string Filename { get; internal set; }
        public DateTimeOffset FileCreatedDate { get; internal set; }
        public DateTimeOffset FileLastModifiedDate { get; internal set; }
        public string Version { get { return $"{MajorVersion}.{MinorVersion}.x"; } }
        #endregion

        #region Constructor 
        public GalaxyFlashImageHelper()
        {
            Errors = new List<S28ErrorInformation>();
            SRecords = new List<S28Record>();
            LoadPackets = new List<EZ80LoadPacket>();
        }

        public GalaxyFlashImageHelper(GalaxyFlashImageHelper o)
        {
            if (o == null)
            {
                Errors = new List<S28ErrorInformation>();
                SRecords = new List<S28Record>();
                LoadPackets = new List<EZ80LoadPacket>();
            }
            else
            {
                Errors = o.Errors.ToList();
                SRecords = o.SRecords.ToList();
                LoadPackets = o.LoadPackets.ToList();
                Package = o.Package;
                MajorVersion = o.MajorVersion;
                MinorVersion = o.MinorVersion;
                Description = o.Description;
                SumCheck = o.SumCheck;
                SumCheckVerified = o.SumCheckVerified;
                CRC_118 = o.CRC_118;
                CRC_119 = o.CRC_119;
                CRC_Ex = o.CRC_Ex;
                CRC = o.CRC;
                SystemType = o.SystemType;
                Data = o.Data.ToArray();
                Filename = o.Filename;
                FileCreatedDate = o.FileCreatedDate;
                FileLastModifiedDate = o.FileLastModifiedDate;
            }

        }
        #endregion

        #region Public Methods
        public bool ReadFlashS28File(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                    return false;
                Filename = filename;
                var fileInfo = new FileInfo(filename);
                FileCreatedDate = File.GetCreationTime(filename);
                FileLastModifiedDate = File.GetLastWriteTime(filename);

                var bytes = File.ReadAllBytes(filename);
                return ReadFlashS28Buffer(bytes);

                uint counter = 0;
                string line;
                bool ret = false;

                // Read the file and display it line by line.  
                var file = new System.IO.StreamReader(filename);
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    //Trace.WriteLine(line);
                    if (line.Length < 2)
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = $"Invalid line length. ({line.Length} characters)",
                            Data = line,
                            LineNumber = counter
                        });
                        continue;
                    }

                    if (!line.StartsWith("S2"))
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = $"S - Record type ignored",
                            Data = line,
                            LineNumber = counter
                        });
                        continue;
                    }

                    var sRecord = new S28Record(line);
                    if (!sRecord.IsValid())
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = sRecord.GetError(),
                            Data = line,
                            LineNumber = counter
                        });
                        break;
                    }

                    SRecords.Add(sRecord);

                    var address = sRecord.GetAddress();
                    if (address == Constants.FIXED_MEMORY_BLOCK)
                    {
                        byte package = 0;
                        ushort majorVersion = 0;
                        ushort minorVersion = 0;
                        ret = sRecord.ReadByteValue(ref package, Constants.EZ80_PACKAGE);
                        if (ret)
                            Package = package;

                        ret = sRecord.ReadWORDValue(ref majorVersion, Constants.EZ80_MAJOR_VERSION);
                        if (ret)
                            MajorVersion = majorVersion;

                        ret = sRecord.ReadWORDValue(ref minorVersion, Constants.EZ80_MINOR_VERSION);
                        if (ret)
                            MinorVersion = minorVersion;
                    }
                    else if (address == Constants.EZ80_DESCRIPTION1 ||
                        address == Constants.EZ80_DESCRIPTION2 ||
                        address == Constants.EZ80_DESCRIPTION3 ||
                        address == Constants.EZ80_DESCRIPTION4 ||
                        address == Constants.EZ80_DESCRIPTION5 ||
                        address == Constants.EZ80_DESCRIPTION6 ||
                        address == Constants.EZ80_DESCRIPTION7)
                    {
                        var desc = new Byte[120];
                        ret = sRecord.ReadDataValue(ref desc, address, (Byte)sRecord.GetDataLength());
                        if (ret)
                            Description = System.Text.Encoding.ASCII.GetString(desc);

                        var index = sRecord.GetOffsetOfAddress(Constants.EZ80_FILE_SUMCHECK);
                        if (index != -1)
                        {
                            UInt32 sumCheck = 0;
                            ret = sRecord.ReadDWORDValueByOffset(ref sumCheck, (UInt32)index);
                            if (ret)
                                SumCheck = sumCheck;
                        }

                    }
                    else if (address == (Constants.EZ80_FILE_SUMCHECK & 0xFFFFF0))
                    {
                        UInt32 sumCheck = 0;
                        ret = sRecord.ReadDWORDValue(ref sumCheck, Constants.EZ80_FILE_SUMCHECK);
                        if (ret)
                            SumCheck = sumCheck;
                    }
                }

                file.Close();

                SumCheckVerified = VerifySumcheck();
                if (SumCheckVerified)
                    CreateLoadablePackets();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return SumCheckVerified;
        }

        public bool ReadFlashS28Buffer(Byte[] buffer)
        {
            try
            {
                Data = buffer;
                uint counter = 0;
                bool ret = false;
                // Read the file and display it line by line.  
                var entireString = System.Text.Encoding.ASCII.GetString(buffer);
                var strings = entireString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var line in strings)
                {
                    counter++;
                    //Trace.WriteLine(line);
                    if (line.Length < 2)
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = $"Invalid line length. ({line.Length} characters)",
                            Data = line,
                            LineNumber = counter
                        });
                        continue;
                    }

                    if (!line.StartsWith("S2"))
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = $"S - Record type ignored",
                            Data = line,
                            LineNumber = counter
                        });
                        continue;
                    }

                    var sRecord = new S28Record(line);
                    if (!sRecord.IsValid())
                    {
                        Errors.Add(new S28ErrorInformation()
                        {
                            ErrorMessage = sRecord.GetError(),
                            Data = line,
                            LineNumber = counter
                        });
                        break;
                    }

                    SRecords.Add(sRecord);

                    var address = sRecord.GetAddress();
                    if (address == Constants.FIXED_MEMORY_BLOCK)
                    {
                        byte package = 0;
                        ushort majorVersion = 0;
                        ushort minorVersion = 0;
                        ret = sRecord.ReadByteValue(ref package, Constants.EZ80_PACKAGE);
                        if (ret)
                        {
                            Package = package;
                            switch ((FlashPackageType)Package)
                            {
                                case FlashPackageType.Package600Cpu://    600
                                case FlashPackageType.Package635Cpu:    // 635
                                    SystemType = 600;
                                    break;

                                case FlashPackageType.Package508i:    // 635
                                    SystemType = 500;
                                    break;
                                default:
                                    break;

                            }
                        }
                        ret = sRecord.ReadWORDValue(ref majorVersion, Constants.EZ80_MAJOR_VERSION);
                        if (ret)
                            MajorVersion = majorVersion;

                        ret = sRecord.ReadWORDValue(ref minorVersion, Constants.EZ80_MINOR_VERSION);
                        if (ret)
                            MinorVersion = minorVersion;
                    }
                    else if (address == Constants.EZ80_DESCRIPTION1 ||
                        address == Constants.EZ80_DESCRIPTION2 ||
                        address == Constants.EZ80_DESCRIPTION3 ||
                        address == Constants.EZ80_DESCRIPTION4 ||
                        address == Constants.EZ80_DESCRIPTION5 ||
                        address == Constants.EZ80_DESCRIPTION6 ||
                        address == Constants.EZ80_DESCRIPTION7)
                    {
                        var desc = new Byte[120];
                        ret = sRecord.ReadDataValue(ref desc, address, (Byte)sRecord.GetDataLength());
                        if (ret && string.IsNullOrEmpty(Description))
                            Description += System.Text.Encoding.ASCII.GetString(desc).Trim('\0');

                        var index = sRecord.GetOffsetOfAddress(Constants.EZ80_FILE_SUMCHECK);
                        if (index != -1)
                        {
                            UInt32 sumCheck = 0;
                            ret = sRecord.ReadDWORDValueByOffset(ref sumCheck, (UInt32)index);
                            if (ret)
                                SumCheck = sumCheck;
                        }

                    }
                    else if (address == (Constants.EZ80_FILE_SUMCHECK & 0xFFFFF0))
                    {
                        UInt32 sumCheck = 0;
                        ret = sRecord.ReadDWORDValue(ref sumCheck, Constants.EZ80_FILE_SUMCHECK);
                        if (ret)
                            SumCheck = sumCheck;
                    }
                }

                SumCheckVerified = VerifySumcheck();
                if (SumCheckVerified)
                    CreateLoadablePackets();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return SumCheckVerified;
        }

        #endregion

        #region Private Methods
        private Boolean VerifySumcheck()
        {
            UInt32 sc = 0;
            foreach (var sr in SRecords)
            {
                sc += sr.CalculateDataSumcheck();
            }

            var bytes = BitConverter.GetBytes(SumCheck);
            foreach (var b in bytes)
                sc -= b;

            sc = ByteFlipper.ReverseBytes(sc);
            if (sc != SumCheck)
                return false;
            return true;
        }

        private Boolean CreateLoadablePackets()
        {
            Boolean bRet = false;

            try
            {
                EZ80LoadPacket loadPkt = null;
                foreach (var sr in SRecords)
                {
                    if (loadPkt == null)   // create a new packet
                    {
                        loadPkt = new EZ80LoadPacket(sr.GetAddress());
                        LoadPackets.Add(loadPkt);
                    }

                    if (sr.GetAddress() > loadPkt.MaxAddress)
                    {
                        // Test for empty, no data. If all 0's, then delete the packet & remove from the array
                        if (loadPkt.IsZero)
                        {
                            if (loadPkt == LoadPackets[LoadPackets.Count - 1])
                            {
                                LoadPackets.RemoveAt(LoadPackets.Count - 1);
                            }
                        }
                        loadPkt = new EZ80LoadPacket(sr.GetAddress());
                        LoadPackets.Add(loadPkt);
                    }

                    var ret = loadPkt.AddData(sr);
                }
                bRet = true;
                // Test for empty, no data. If all 0's, then delete the packet & remove from the array
                if (loadPkt != null)
                {
                    if (loadPkt.IsZero)
                    {
                        if (loadPkt == LoadPackets[LoadPackets.Count - 1])
                        {
                            LoadPackets.RemoveAt(LoadPackets.Count - 1);
                        }
                    }
                }
                //		m_CRC = GetTotalCRC();
                var size = GetTotalSize();
                CRC_118 = GetTotalCRC(Constants.EZ80_600_CRC_SIZE_1_18);
                CRC_119 = GetTotalCRC(Constants.EZ80_600_CRC_SIZE_1_19);
                CRC_Ex = GetTotalCRC(Constants.EZ80_600_CRC_SIZE_5_01);

                switch (SystemType)
                {
                    case 500:
                        CRC = CRC_119;
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return bRet;
        }

        private UInt32 GetPacketCount() { return (UInt32)LoadPackets.Count; }

        private UInt32 GetTotalSize()
        {
            return GetPacketCount() * Constants.EZ80_FLASH_PACKET_SIZE;
        }

        private UInt32 GetTotalCRC(UInt32 crc_size)
        {
            UInt32 crc = 0;

            try
            {
                UInt32 buffer_size = Constants.EZ80_600_BUFFER_SIZE;
                switch (SystemType)
                {
                    case 500:
                        buffer_size = Constants.EZ80_508I_CRC_BUFFER_SIZE;
                        crc_size = Constants.EZ80_508I_CRC_BUFFER_SIZE;
                        break;

                    case 600:
                        buffer_size = Constants.EZ80_600_BUFFER_SIZE;
                        break;
                }

                var buf = new byte[buffer_size];
                UInt32 addr = 0;
                UInt32 size = 0;
                foreach (var pkt in LoadPackets)
                {
                    var temp = pkt.GetData();
                    var last_addr = addr;
                    addr = pkt.Address;
                    if (addr >= buffer_size - 1024)
                    {
                        Trace.WriteLine($"Invalid S28 Error. Address to large");
                        return 0;
                    }
                    else
                    {
                        Buffer.BlockCopy(temp, 0, buf, (int)addr, temp.Length);
                        size = (UInt32)(addr + temp.Length);
                    }
                }

                crc = GetCrcCheck(crc_size, buf);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
            return crc;
        }

        private UInt32 GetCrcCheck(uint crc_size, byte[] buf)
        {
            var crc = GCS.Security.Crc32.CRC32Bytes(buf, (int)crc_size);
            return crc;
        }

        #endregion
    }
}
