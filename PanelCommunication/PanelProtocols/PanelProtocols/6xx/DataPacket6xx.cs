using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Utils;
using GCS.PanelProtocols.Enums;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using static GalaxySMS.Business.Entities.DataPacketBase;

namespace GCS.PanelProtocols.Series6xx
{
    static class Utilities
    {
        const UInt16 SectionMask = 0x3;

        public static Byte EncodeSection(UInt16 section, UInt16 node)
        {
            return (Byte)(((section & SectionMask) | node << 3) & 0xFF);
        }

        public static UInt16 ExtractSection(UInt16 value)
        {
            return (UInt16)(value & SectionMask);
        }

        public static UInt16 ExtractSubSection(UInt16 value)
        {
            return (UInt16)((value & ~SectionMask) >> SectionMask);
        }
    }

    //public class PacketDistribution
    //{
    //	public const Byte FromServerToAllPanelsOnAllClusters = 0x00;
    //	public const Byte FromServerToAllPanelsOnCluster = 0x08;
    //	public const Byte FromServerToSpecificPanel = 0x04;
    //	public const Byte FromServerToSpecificPanelBoard = 0x02;
    //	public const Byte FromServerToSpecificPanelBoardSection = 0x01;
    //	public const Byte FromPanelToServer = 0x80;
    //	public const Byte FromPanelToAllPanels = 0x88;
    //	public const Byte FromPanelToSpecificPanel = 0x8C;
    //}

    //public class CpuDistribution
    //{
    //	public const Byte EitherCpu = 0x00;
    //	public const Byte Cpu1Only = 0x01;
    //	public const Byte Cpu2Only = 0x02;
    //	public const Byte Both = 0x03;
    //}
    public enum CpuDistribution : byte
    {
        EitherCpu = 0x00,
        Cpu1Only = 0x01,
        Cpu2Only = 0x02,
        Both = 0x03,
    }

    public enum SohCode : uint { UInt8ClusterAndPanelIds = 0xFE7F0180, UInt16ClusterAndPanelIds = 0xFE7F0181 }
    public enum HeaderSize : byte { UInt8ClusterAndPanelIds = 6, UInt16ClusterAndPanelIds = 9 }
    public enum PacketDistribution : byte
    {
        FromServerToAllPanelsOnAllClusters = 0x00,
        FromServerToSpecificPanelBoardSection = 0x01,
        FromServerToSpecificPanelBoard = 0x02,
        FromServerToSpecificPanel = 0x04,
        FromServerToAllPanelsOnCluster = 0x08,
        FromPanelToServer = 0x80,
        FromPanelToAllPanels = 0x88,
        FromPanelToSpecificPanel = 0x8C
    }

    public class PacketConstants
    {
        public const UInt16 MinimumDataSize = 16;
        //public const UInt32 Soh = 0xFE7F0180;
        //public const Byte HeaderSize = 6;	//(sizeof( packet_600.soh) + sizeof( packet_600.length))
        public const UInt16 LengthWithoutData = 16;
        public const UInt16 DataSize = 1028;        // room for 1024 data bytes + 4 byte CRC
    };

    public class PanelBoardSectionLimits
    {
        public const Byte AllPanels = 255;
        public const Byte MinimumBoardNumber = 1;
        public const Byte MaximumBoardNumber = 32;
        public const Byte MinimumBoardSectionNumber = 1;
        public const Byte MaximumBoardSectionNumber = 16;
    };

    public enum EncryptionType { None = 0, Aes };

    public interface IDataPacket6xx
    {
        SohCode Soh { get; set; }
        UInt16 Length { get; set; }
        DataDirection Direction { get; }
        PacketDistribution Distribute { get; set; }
        Int32 ClusterId { get; set; }
        Int32 PanelId { get; set; }
        CpuDistribution Cpu { get; set; }
        Int32 BoardNumber { get; set; }
        UInt16 SectionEncoded { get; set; }
        UInt16 Section { get; set; }
        UInt16 Node { get; set; }
        byte[] When { get; set; }
        byte[] Sequence { get; set; }
        byte[] Data { get; set; }
        object Packet { get; }
        sDataPacket6xx StandardPacket { get; }
        sDataPacket6xxExtended ExtendedPacket { get; }
        bool IsHeaderValid { get; }
        string FromHardwareAddress { get; }
        void Decrypt(byte[] key);
        void Encrypt(byte[] key);
        void ResizeData(int len);
        byte[] GetRawData();
        bool IsValid();
        void EncodeSection(UInt16 section, UInt16 node);
        void FillData(object o);
        void FillData(object o, int objectSize);
        void FillData(byte[] data);
        void PrepareForTransmission(bool passthru, bool fillWhen, string timeZoneId);
        byte[] GetBytes();
        string BoardSectionAddressString { get; }
        string BoardSectionNodeAddressString { get; }
        uint SequenceNumber { get; }
        void FillWhen(string timeZoneId);
    }

    public class DataPacket6xx : PanelMessageBase, IDataPacket6xx
    {
        public DataPacket6xx()
        {

        }

        public DataPacket6xx(SohCode sohCode)
        {
            Init(sohCode);
        }

        public DataPacket6xx(ref IDataPacket6xx o)
        {
            if (o != null)
            {
                Soh = o.Soh;
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard = o.StandardPacket;
                        break;
                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended = o.ExtendedPacket;
                        break;
                }
            }
        }
        public DataPacket6xx(SohCode sohCode, byte[] data)
        {
            Soh = sohCode;
            switch (sohCode)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard = new sDataPacket6xx(data);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended = new sDataPacket6xxExtended(data);
                    break;
            }
        }

        public DataPacket6xx(SohCode sohCode, UInt32 sequence)
        {
            Soh = sohCode;
            switch (sohCode)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard = new sDataPacket6xx(sequence);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended = new sDataPacket6xxExtended(sequence);
                    break;
            }
        }
        public DataPacket6xx(SohCode sohCode, sDataPacket6xx data)
        {
            Soh = sohCode;
            switch (sohCode)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard = data;
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended = new sDataPacket6xxExtended(0);
                    break;
            }
        }

        public DataPacket6xx(SohCode sohCode, sDataPacket6xxExtended data)
        {
            Soh = sohCode;
            switch (sohCode)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard = new sDataPacket6xx(0);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended = data;
                    break;
            }
        }

        private void Init(SohCode sohCode)
        {
            Soh = sohCode;
            switch (sohCode)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard = new sDataPacket6xx(0);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended = new sDataPacket6xxExtended(0);
                    break;
            }
        }

        public DataDirection Direction
        {
            get
            {
                switch (Distribute)
                {
                    case PacketDistribution.FromServerToAllPanelsOnAllClusters:
                    case PacketDistribution.FromServerToSpecificPanelBoardSection:
                    case PacketDistribution.FromServerToSpecificPanelBoard:
                    case PacketDistribution.FromServerToSpecificPanel:
                    case PacketDistribution.FromServerToAllPanelsOnCluster:
                        return DataDirection.TransmittedToPanel;

                    case PacketDistribution.FromPanelToServer:
                    case PacketDistribution.FromPanelToAllPanels:
                    case PacketDistribution.FromPanelToSpecificPanel:
                        return DataDirection.ReceivedFromPanel;

                    default:
                        return DataDirection.TransmittedToPanel;

                }
            }
        }

        public SohCode Soh
        {
            get => _soh;
            set => _soh = value;
        }

        public UInt16 Length
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Length;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Length;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Length = value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Length = value;
                        break;
                }
            }
        }
        public PacketDistribution Distribute
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return (PacketDistribution)_packetStandard.Distribute;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return (PacketDistribution)_packetExtended.Distribute;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Distribute = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Distribute = (byte)value;
                        break;
                }
            }
        }

        public Int32 ClusterId
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.ClusterId;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.ClusterId;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.ClusterId = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.ClusterId = (ushort)value;
                        break;
                }
            }
        }

        public Int32 PanelId
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.PanelId;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.PanelId;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.PanelId = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.PanelId = (ushort)value;
                        break;
                }
            }
        }

        public CpuDistribution Cpu
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return (CpuDistribution)_packetStandard.Cpu;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return (CpuDistribution)_packetExtended.Cpu;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Cpu = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Cpu = (byte)value;
                        break;
                }
            }
        }
        public Int32 BoardNumber
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Board;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Board;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Board = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Board = (ushort)value;
                        break;
                }
            }
        }

        public UInt16 SectionEncoded
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.SectionEncoded;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.SectionEncoded;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.SectionEncoded = (byte)value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.SectionEncoded = (byte)value;
                        break;
                }
            }
        }

        public UInt16 Section
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Section;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Section;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.EncodeSection(Section, Node);
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.EncodeSection(Section, Node);
                        break;
                }
            }
        }

        public UInt16 Node
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Node;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Node;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.EncodeSection(Section, Node);
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.EncodeSection(Section, Node);
                        break;
                }
            }
        }

        public byte[] When
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.When;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.When;
                    default:
                        return null;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.When = value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.When = value;
                        break;
                }
            }
        }

        public byte[] Sequence
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Sequence;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Sequence;
                    default:
                        return null;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Sequence = value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Sequence = value;
                        break;
                }
            }
        }

        public byte[] Data
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.Data;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.Data;
                    default:
                        return null;
                }
            }
            set
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        _packetStandard.Data = value;
                        break;

                    case SohCode.UInt16ClusterAndPanelIds:
                        _packetExtended.Data = value;
                        break;
                }
            }
        }

        public bool IsHeaderValid
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.IsHeaderValid;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.IsHeaderValid;
                    default:
                        return false;
                }

            }
        }
        public string FromHardwareAddress
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard.FromHardwareAddress;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended.FromHardwareAddress;
                }
                return string.Empty;
            }
        }

        public string BoardSectionAddressString
        {
            get { return $"{this.BoardNumber}:{this.Section}"; }
        }

        public string BoardSectionNodeAddressString
        {
            get { return $"{this.BoardNumber}:{this.Section}:{this.Node}"; }
        }

        public uint SequenceNumber
        {
            get
            {
                if (Sequence == null)
                    return 0;
                var seq = new byte[4];
                for(int x = 0; x < Sequence.Length; x++)
                {
                    seq[x] = Sequence[x];
                }
                return BitConverter.ToUInt32(seq, 0);
            }
        }

        public void FillWhen(string timeZoneId)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.FillWhen(timeZoneId);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.FillWhen(timeZoneId);
                    break;
            }
        }


        public void Decrypt(byte[] key)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.Decrypt(key);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.Decrypt(key);
                    break;
            }
        }

        public void Encrypt(byte[] key)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.Encrypt(key);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.Encrypt(key);
                    break;
            }
        }

        public void ResizeData(int len)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    Array.Resize<Byte>(ref _packetStandard.Data, len);
                    break;
                case SohCode.UInt16ClusterAndPanelIds:
                    Array.Resize<Byte>(ref _packetExtended.Data, len);
                    break;
            }
        }

        public byte[] GetRawData()
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    return ByteArrayUtilities.GetBytesFromArray(ref _packetStandard.Data, _packetStandard.Length - 16, 0);

                case SohCode.UInt16ClusterAndPanelIds:
                    return ByteArrayUtilities.GetBytesFromArray(ref _packetExtended.Data, _packetExtended.Length - 16, 0);
            }
            return null;
        }
        public bool IsValid()
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    return _packetStandard.IsValid();

                case SohCode.UInt16ClusterAndPanelIds:
                    return _packetExtended.IsValid();
            }
            return false;
        }

        public void EncodeSection(ushort section, ushort node)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.EncodeSection(section, node);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.EncodeSection(section, node);
                    break;
            }
        }

        public void FillData(object o)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.FillData(o);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.FillData(o);
                    break;
            }
        }

        public void FillData(object o, int objectSize)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.FillData(o, objectSize);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.FillData(o, objectSize);
                    break;
            }
        }

        public void FillData(byte[] data)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.FillData(data);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.FillData(data);
                    break;
            }
        }

        public void PrepareForTransmission(bool passthru, bool fillWhen, string timeZoneId)
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    _packetStandard.PrepareForTransmission(passthru, fillWhen, timeZoneId);
                    break;

                case SohCode.UInt16ClusterAndPanelIds:
                    _packetExtended.PrepareForTransmission(passthru, fillWhen, timeZoneId);
                    break;
            }
        }

        public byte[] GetBytes()
        {
            switch (Soh)
            {
                case SohCode.UInt8ClusterAndPanelIds:
                    return _packetStandard.GetBytes();

                case SohCode.UInt16ClusterAndPanelIds:
                    return _packetExtended.GetBytes();
            }
            return null;
        }

        public object Packet
        {
            get
            {
                switch (Soh)
                {
                    case SohCode.UInt8ClusterAndPanelIds:
                        return _packetStandard;

                    case SohCode.UInt16ClusterAndPanelIds:
                        return _packetExtended;
                    default:
                        return null;
                }
            }
        }

        public sDataPacket6xx StandardPacket
        {
            get { return _packetStandard; }
        }

        public sDataPacket6xxExtended ExtendedPacket
        {
            get { return _packetExtended; }
        }


        private sDataPacket6xx _packetStandard;
        private sDataPacket6xxExtended _packetExtended;
        private SohCode _soh;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct sDataPacket6xx
    {
        public UInt32 Soh;      // start of header = 0x7FFE8001 (xFE7F0180)
        public UInt16 Length;       // number of bytes in packet (not counting 4 byte header) ( 32 - 1040)

        //********************encryption starts here***************************
        public Byte Distribute;         // 0000 0000 = from PC: send to all units in all loops
        public Byte ClusterId;
        public Byte PanelId;
        public Byte Cpu;            //  0000 0000    send to either CPU 1 or CPU 2, but not both
        public Byte Board;
        public Byte SectionEncoded;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Byte[] When;         // INT24: seconds since the start of this week, check before processing msg
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Byte[] Sequence;     // INT24: incrementing number, check only if panel to panel traffic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = PacketConstants.DataSize)]
        public Byte[] Data; // first byte is command code: must be multiple of 16 bytes int

        //********************encryption ends here********************************
        //		public UInt32 Crc;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="sequence">	The sequence number. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public sDataPacket6xx(UInt32 sequence)
        {
            Soh = (uint)SohCode.UInt8ClusterAndPanelIds;//PacketConstants.Soh;
            Length = PacketConstants.LengthWithoutData;
            //		    Distribute = PacketDistribution.FromServerToAllPanelsOnCluster;
            Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            ClusterId = 0;
            PanelId = 0;
            Cpu = (byte)CpuDistribution.Both;
            Board = 0;
            SectionEncoded = 0;
            When = new Byte[3];
            Sequence = new Byte[3];

            byte[] tempSeq = BitConverter.GetBytes(sequence);
            Sequence[0] = tempSeq[0];
            Sequence[1] = tempSeq[1];
            Sequence[2] = tempSeq[2];

            Data = new Byte[PacketConstants.DataSize];
            //			Crc = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="bytes">	The bytes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public sDataPacket6xx(Byte[] bytes)
        {
            Soh = (uint)SohCode.UInt8ClusterAndPanelIds;//PacketConstants.Soh;
            Length = PacketConstants.LengthWithoutData;
            Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            ClusterId = 0;
            PanelId = 0;
            Cpu = (byte)CpuDistribution.Both;
            Board = 0;
            SectionEncoded = 0;
            When = new Byte[3];
            Sequence = new Byte[3];
            Data = new Byte[PacketConstants.DataSize];

            Int32 len = bytes.GetLength(0);
            Int32 index = 0;
            var soh = BitConverter.ToUInt32(bytes, index);

            if (soh == (uint)SohCode.UInt8ClusterAndPanelIds)
            {
                Soh = soh;
                index += sizeof(UInt32);

                Length = BitConverter.ToUInt16(bytes, index);
                index += sizeof(UInt16);

                Distribute = bytes[index++];
                ClusterId = bytes[index++];
                PanelId = bytes[index++];
                Cpu = bytes[index++];
                Board = bytes[index++];
                SectionEncoded = bytes[index++];
                int y;
                for (y = 0; y < When.Length; y++)
                    When[y] = bytes[index++];

                for (y = 0; y < Sequence.Length; y++)
                    Sequence[y] = bytes[index++];

                for (y = 0; y < Data.Length; y++)
                {
                    Data[y] = bytes[index++];
                    if (index >= len)
                        break;
                }

                //Crc = BitConverter.ToUInt32(bytes, index);
                //index += sizeof(UInt32);            
            }
        }

        #region Public Properties
        public string FromHardwareAddress => $"{this.ClusterId}:{this.PanelId}:{this.Cpu}:{this.Board}:{this.SectionEncoded}";

        public UInt16 Section => Utilities.ExtractSection(this.SectionEncoded);

        public UInt16 Node => Utilities.ExtractSubSection(SectionEncoded);

        #endregion

        public String GetDataHexString()
        {
            String sDebug = string.Empty;
            for (int x = 0; x < this.Length - PacketConstants.LengthWithoutData; x++)
                sDebug += $"{Data[x]:x2}";

            return sDebug;
        }

        public void EncodeSection(UInt16 section, UInt16 node)
        {
            SectionEncoded = Utilities.EncodeSection(section, node);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Converts the entire packet to a byte array </summary>
        ///
        /// <returns>	The bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] GetBytes()
        {
            Int32 buf_len = Length + (byte)HeaderSize.UInt8ClusterAndPanelIds;// PacketConstants.HeaderSize;// sizeof(uint) + sizeof(UInt16);
                                                                              //           buf_len -= (Pkt600Struct.DATA_SIZE - length);	// only allocate and send as much data as the packet length

            Byte[] ba = new Byte[buf_len];
            Int32 x = 0;

            Byte[] temp = BitConverter.GetBytes(Soh);
            for (int y = 0; y < temp.Length; y++)
                ba[x++] = temp[y];

            temp = BitConverter.GetBytes(Length);
            for (int y = 0; y < temp.Length; y++)
                ba[x++] = temp[y];

            ba[x++] = Distribute;
            ba[x++] = ClusterId;
            ba[x++] = PanelId;
            ba[x++] = Cpu;
            ba[x++] = Board;
            ba[x++] = SectionEncoded;

            for (int y = 0; y < When.Length; y++)
                ba[x++] = When[y];

            for (int y = 0; y < Sequence.Length; y++)
                ba[x++] = Sequence[y];

            for (int y = 0; y < Data.Length; y++)
            {
                ba[x++] = Data[y];
                if (x >= buf_len)
                    break;
            }
            return ba;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Gets the bytes that can be encrypted. This excludes the soh and length (header) members. </summary>
        ///
        /// <returns>	The encryptable bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Byte[] GetEncryptableBytes()
        {
            Int32 buf_len = Length;

            Byte[] ba = new Byte[buf_len];
            Int32 x = 0;

            ba[x++] = Distribute;
            ba[x++] = ClusterId;
            ba[x++] = PanelId;
            ba[x++] = Cpu;
            ba[x++] = Board;
            ba[x++] = SectionEncoded;

            foreach (var t in When)
                ba[x++] = t;

            foreach (var t in Sequence)
                ba[x++] = t;

            foreach (var t in Data)
            {
                ba[x++] = t;
                if (x >= buf_len)
                    break;
            }
            return ba;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the packet header is valid. The soh and length members are considered./ </summary>
        ///
        /// <value>	true if this object is header valid, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsHeaderValid
        {
            get
            {
                if (Soh != (uint)SohCode.UInt8ClusterAndPanelIds)//PacketConstants.Soh)
                    return false;

                if (Length < 32 || Length > 1040)
                    return false;

                if ((Length % 16) != 0)
                    return false;

                return true;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the object is a valid packet based on the header and CRC being correct. </summary>
        ///
        /// <returns>	true if valid, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsValid()
        {
            if (IsHeaderValid == false)
                return false;

            if (this.Length < 32 || this.Length > 1040)
                return false;

            if (ValidateCrc() == false)
                return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Decrypts the packet data using AES and the specified key </summary>
        ///
        /// <param name="key">	The key. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Decrypt(byte[] key)
        {
            UInt16 origLen = this.Length;
            UInt32 origSoh = this.Soh;

            byte[] bytesToDecrypt = GetEncryptableBytes();
            byte[] decrypted = GCS.Security.AesCrypto.DecryptBytesFromBytes_AES(bytesToDecrypt, key);
            FromBytes(decrypted);
            Soh = origSoh;
            Length = origLen;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Encrypts the packet data using AES and the specified key </summary>
        ///
        /// <param name="key">	The key. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Encrypt(byte[] key)
        {
            UInt16 origLen = this.Length;
            UInt32 origSoh = this.Soh;

            byte[] bytesToEncrypt = GetEncryptableBytes();
            byte[] encrypted = GCS.Security.AesCrypto.EncryptBytesToBytes_AES(bytesToEncrypt, key);
            FromBytes(encrypted);
            Soh = origSoh;
            Length = origLen;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <param name="o">	The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(object o)//, int size)
        {
            int size = Marshal.SizeOf(o);
            //if (sz != size)
            //	System.Diagnostics.Trace.WriteLine("FillData size mismatch");
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(o, ptr, true);
                Marshal.Copy(ptr, this.Data, 0, size);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
            Marshal.FreeHGlobal(ptr);

            SetPacketLength((UInt16)size);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <remarks>   Kevin, 1/24/2019. </remarks>
        ///
        /// <param name="o">            The object to process. </param>
        /// <param name="objectSize">   Size of the object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(object o, int objectSize)
        {
            int size = objectSize;
            //if (sz != size)
            //	System.Diagnostics.Trace.WriteLine("FillData size mismatch");
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(o, ptr, false);//true);
                Marshal.Copy(ptr, this.Data, 0, size);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
            Marshal.FreeHGlobal(ptr);

            SetPacketLength((UInt16)size);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <param name="o">	The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(Byte[] data)
        {
            if (data.Length <= Data.Length)
            {
                Buffer.BlockCopy(data, 0, Data, 0, data.Length);
                SetPacketLength((UInt16)data.Length);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Sets the packet length value based on the length of the data byte array. </summary>
        ///
        /// <param name="dataSize">	Size of the data portion of the packet. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetPacketLength(UInt16 dataSize)
        {   // the dataSize is the size of the structure that has been copied into the data array			
            UInt16 dataLength = CalculateDataLength(dataSize); // calculate the size that the data array must be to accomodate the structure. 
                                                               // This is forced to be on a 16 byte boundry
                                                               // 
                                                               //		    Length = (ushort)(Marshal.SizeOf(this) - PacketConstants.DataSize - PacketConstants.HeaderSize + dataLength);
            Length = (ushort)(Marshal.SizeOf(this) - PacketConstants.DataSize - (byte)HeaderSize.UInt8ClusterAndPanelIds + dataLength);

            Length += sizeof(UInt32);   // add room for the crc (4 bytes)
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>	Prepares the packet for transmission. It plugs the when value, calculates and fills the CRC bytes for non-passthru packets </summary>
        ///
        /// <remarks>   Kevin, 5/31/2018. </remarks>
        ///
        /// <param name="passthru"> True to passthru. </param>
        /// <param name="fillWhen"> True to fill when. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrepareForTransmission(bool passthru, bool fillWhen, string timeZoneId)
        {
            if (passthru == false)
            {
                if (fillWhen == true)
                    FillWhen(timeZoneId);
                CalculateAndFillCrc();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Initializes this object from an array of bytes. The array of bytes does not include the soh or length values. It is used to create a packet in conjunction with the encryption and decryption methods. </summary>
        ///
        /// <param name="bytes">	The bytes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FromBytes(byte[] bytes)
        { // the bytes does not include soh & length 
            Soh = (uint)SohCode.UInt8ClusterAndPanelIds;//PacketConstants.Soh;
            Length = (ushort)bytes.Length;
            Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            ClusterId = 0;
            PanelId = 0;
            Cpu = 0;
            Board = 0;
            SectionEncoded = 0;
            When = new Byte[3];
            Sequence = new Byte[3];
            Data = new Byte[PacketConstants.DataSize];

            Int32 len = bytes.GetLength(0);
            Int32 index = 0;

            Distribute = bytes[index++];
            ClusterId = bytes[index++];
            PanelId = bytes[index++];
            Cpu = bytes[index++];
            Board = bytes[index++];
            SectionEncoded = bytes[index++];
            int y;
            for (y = 0; y < When.Length; y++)
                When[y] = bytes[index++];

            for (y = 0; y < Sequence.Length; y++)
                Sequence[y] = bytes[index++];

            for (y = 0; y < Data.Length; y++)
            {
                Data[y] = bytes[index++];
                if (index >= len)
                    break;
            }
        }

        #region Private Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the data length. The length of the packet must be on a 16 byte boundry. </summary>
        ///
        /// <param name="dataSize">	Size of the data portion of the packet. </param>
        ///
        /// <returns>	The calculated data length. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt16 CalculateDataLength(UInt16 dataSize)
        {
            if (dataSize == 0)
                dataSize = PacketConstants.MinimumDataSize;

            if ((dataSize % PacketConstants.MinimumDataSize) != 0)
            {   // if not an even 16 bytes
                dataSize = (UInt16)(((dataSize / PacketConstants.MinimumDataSize) * PacketConstants.MinimumDataSize) + PacketConstants.MinimumDataSize);
            }
            return dataSize;
        }

        /// <summary>	Calculates the CRC and plugs it at the end of the data. The packet length must be already set properly.</summary>
        void CalculateAndFillCrc()
        {
            UInt32 crc = CalculateCrc();
            UInt16 crcOffset = CalculateCrcOffset();    // figure out where the CRC must go
            byte[] crcBytes = BitConverter.GetBytes(crc);
            for (int x = 0; x < crcBytes.Length; x++)
                Data[crcOffset + x] = crcBytes[x];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the CRC offset within the data buffer. </summary>
        ///
        /// <returns>	The calculated CRC offset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt16 CalculateCrcOffset()
        {
            //			UInt16 crc_offset = (UInt16)(length - PacketConstants.LengthWithoutData - PacketConstants.HeaderSize);
            UInt16 crc_offset = Length;
            crc_offset -= PacketConstants.LengthWithoutData;
            return crc_offset;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Gets elapsed seconds in week. </summary>
        ///
        /// <returns>	The elapsed seconds in week. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 GetElapsedSecondsInWeek(string timeZoneId)
        {
            //DateTime now = DateTime.Now;
            var now = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(timeZoneId);

            //Trace.WriteLine($"{timeZoneId}: {now.ToString()}");

            //if(!string.IsNullOrEmpty(timeZoneId) )
            //{
            //    var tzNow = DateTime.Now.GetCurrentTimeForTimeZoneId(timeZoneId);
            //}

            TimeSpan span = new TimeSpan((int)now.DayOfWeek, now.Hour, now.Minute, now.Second);
            return (UInt32)span.TotalSeconds;
        }

        /// <summary>	Fills the when value </summary>
        public void FillWhen(string timeZoneId)
        {
            UInt32 elapsedSecondsInWeek = GetElapsedSecondsInWeek(timeZoneId);
            byte[] secondsIntoWeek = BitConverter.GetBytes(elapsedSecondsInWeek);
            When[0] = secondsIntoWeek[0];
            When[1] = secondsIntoWeek[1];
            When[2] = secondsIntoWeek[2];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the CRC is valid. This method is typically used to validate a packet that was received</summary>
        ///
        /// <returns>	true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool ValidateCrc()
        {
            UInt32 extractedCRC = ExtractCrc();
            UInt32 calculatedCRC = CalculateCrc();

            if (extractedCRC == calculatedCRC)
                return true;
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Extracts the CRC from the end of the buffer </summary>
        ///
        /// <returns>	The extracted CRC. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 ExtractCrc()
        {
            UInt32 crc = 0;
            UInt16 crc_offset = Length;
            crc_offset -= PacketConstants.LengthWithoutData;

            crc = BitConverter.ToUInt32(Data, crc_offset);
            //// Added this to erase the CRC because the crc data was being transmitted to GCSComm service
            //// and was ending up in the card_data section of log messages for non-card related messages
            if (Distribute == (byte)PacketDistribution.FromPanelToServer)
            {
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
            }

            return crc;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the CRC. This should only be called after all the other packet members have been set. </summary>
        ///
        /// <returns>	The calculated CRC. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 CalculateCrc()
        {
            uint crc = 0;
            byte[] array = GetBytes();
            //for (int x = 0; x < Length - sizeof(UInt32) + PacketConstants.HeaderSize; x++)
            for (int x = 0; x < Length - sizeof(UInt32) + (byte)HeaderSize.UInt8ClusterAndPanelIds; x++)
            {
                crc = GCS.Security.Crc32.UPDC32(array[x], crc);
            }
            return crc;
        }

        #endregion
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct sDataPacket6xxExtended
    {
        public UInt32 Soh;      // start of header = 0x7FFE8101 (xFE7F0181)
        public UInt16 Length;       // number of bytes in packet (not counting 4 byte header) ( 32 - 1040)

        public Byte Distribute;         // 0000 0000 = from PC: send to all units in all loops
        public ushort ClusterId;
        //********************encryption starts here***************************
        public ushort PanelId;
        public Byte Cpu;            //  0000 0000    send to either CPU 1 or CPU 2, but not both
        public ushort Board;
        public Byte SectionEncoded;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Byte[] When;         // INT24: seconds since the start of this week, check before processing msg
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Byte[] Sequence;     // INT24: incrementing number, check only if panel to panel traffic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = PacketConstants.DataSize)]
        public Byte[] Data; // first byte is command code: must be multiple of 16 bytes int
                            //********************encryption ends here********************************
                            //		public UInt32 Crc;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="sequence">	The sequence number. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public sDataPacket6xxExtended(UInt32 sequence)
        {
            Soh = (uint)SohCode.UInt16ClusterAndPanelIds;
            Length = PacketConstants.LengthWithoutData;
            Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            ClusterId = 0;
            PanelId = 0;
            Cpu = (byte)CpuDistribution.Both;
            Board = 0;
            SectionEncoded = 0;
            When = new Byte[3];
            Sequence = new Byte[3];

            byte[] tempSeq = BitConverter.GetBytes(sequence);
            Sequence[0] = tempSeq[0];
            Sequence[1] = tempSeq[1];
            Sequence[2] = tempSeq[2];

            Data = new Byte[PacketConstants.DataSize];
            //			Crc = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="bytes">	The bytes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public sDataPacket6xxExtended(Byte[] bytes)
        {
            Soh = (uint)SohCode.UInt16ClusterAndPanelIds;//PacketConstants.Soh;
            Length = PacketConstants.LengthWithoutData;
            Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            ClusterId = 0;
            PanelId = 0;
            Cpu = (byte)CpuDistribution.Both;
            Board = 0;
            SectionEncoded = 0;
            When = new Byte[3];
            Sequence = new Byte[3];
            Data = new Byte[PacketConstants.DataSize];

            Int32 len = bytes.GetLength(0);
            Int32 index = 0;

            var soh = BitConverter.ToUInt32(bytes, index);
            if (soh == (uint)SohCode.UInt16ClusterAndPanelIds)
            {
                Soh = soh;
                index += sizeof(UInt32);

                Length = BitConverter.ToUInt16(bytes, index);
                index += sizeof(UInt16);

                Distribute = bytes[index++];

                ClusterId = BitConverter.ToUInt16(bytes, index);
                index += sizeof(UInt16);

                PanelId = BitConverter.ToUInt16(bytes, index);
                index += sizeof(UInt16);

                Cpu = bytes[index++];

                Board = BitConverter.ToUInt16(bytes, index);
                index += sizeof(UInt16);

                SectionEncoded = bytes[index++];
                int y;
                for (y = 0; y < When.Length; y++)
                    When[y] = bytes[index++];

                for (y = 0; y < Sequence.Length; y++)
                    Sequence[y] = bytes[index++];

                for (y = 0; y < Data.Length; y++)
                {
                    Data[y] = bytes[index++];
                    if (index >= len)
                        break;
                }

                //Crc = BitConverter.ToUInt32(bytes, index);
                //index += sizeof(UInt32);
            }
        }


        //		////////////////////////////////////////////////////////////////////////////////////////////////////
        //		/// <summary>	Constructor. </summary>
        //		///
        //		/// <param name="clusterId">	Identifier for the cluster. </param>
        //		/// <param name="controller">	The controller. </param>
        //		////////////////////////////////////////////////////////////////////////////////////////////////////

        //		public DataPacket6xx(UInt32 clusterId, UInt16 controller)
        //		{
        //			Soh = PacketConstants.Soh;
        //			Length = PacketConstants.LengthWithoutData;
        //			Distribute = PacketDistribution.FromServerToSpecificPanel;
        //			if (controller == PanelBoardSectionLimits.AllPanels)
        //				Distribute = PacketDistribution.FromServerToAllPanelsOnCluster;
        //			ClusterId = Convert.ToByte(clusterId);
        //			PanelId = Convert.ToByte(controller);
        //			Cpu = CpuDistribution.Both;
        //			Board = 0;
        //			SectionEncoded = 0;
        //			When = new Byte[3];
        //			Sequence = new Byte[3];
        //			Data = new Byte[PacketConstants.DataSize];
        ////			Crc = 0;
        //		}

        //		////////////////////////////////////////////////////////////////////////////////////////////////////
        //		/// <summary>	Constructor. </summary>
        //		///
        //		/// <param name="clusterId">	Identifier for the cluster. </param>
        //		/// <param name="controller">	The controller. </param>
        //		/// <param name="cpu">		  	The CPU. </param>
        //		////////////////////////////////////////////////////////////////////////////////////////////////////

        //		public DataPacket6xx(uint clusterId, UInt16 controller, UInt16 cpu)
        //		{
        //			Soh = PacketConstants.Soh;
        //			Length = PacketConstants.LengthWithoutData;
        //			Distribute = PacketDistribution.FromServerToSpecificPanel;
        //			if (controller == PanelBoardSectionLimits.AllPanels)
        //				Distribute = PacketDistribution.FromServerToAllPanelsOnCluster;
        //			ClusterId = Convert.ToByte(clusterId);
        //			PanelId = Convert.ToByte(controller);
        //			this.Cpu = Convert.ToByte(cpu);
        //			switch (cpu)
        //			{
        //				case CpuDistribution.EitherCpu:
        //				case CpuDistribution.Cpu1Only:
        //				case CpuDistribution.Cpu2Only:
        //					break;

        //				default:
        //					this.Cpu = CpuDistribution.Both;
        //					break;
        //			}
        //			Board = 0;
        //			SectionEncoded = 0;
        //			When = new Byte[3];
        //			Sequence = new Byte[3];
        //			Data = new Byte[PacketConstants.DataSize];
        ////			Crc = 0;
        //		}

        //		////////////////////////////////////////////////////////////////////////////////////////////////////
        //		/// <summary>	Constructor. </summary>
        //		///
        //		/// <param name="clusterId">	Identifier for the cluster. </param>
        //		/// <param name="controller">	The controller. </param>
        //		/// <param name="cpu">		  	The CPU. </param>
        //		/// <param name="board">	  	The board. </param>
        //		////////////////////////////////////////////////////////////////////////////////////////////////////

        //		public DataPacket6xx(UInt32 clusterId, UInt16 controller, UInt16 cpu, UInt16 board)
        //		{
        //			Soh = PacketConstants.Soh;
        //			Length = PacketConstants.LengthWithoutData;
        //			Distribute = PacketDistribution.FromServerToSpecificPanelBoard;
        //			ClusterId = Convert.ToByte(clusterId);
        //			PanelId = Convert.ToByte(controller);
        //			this.Cpu = Convert.ToByte(cpu);
        //			switch (cpu)
        //			{
        //				case CpuDistribution.EitherCpu:
        //				case CpuDistribution.Cpu1Only:
        //				case CpuDistribution.Cpu2Only:
        //					break;

        //				default:
        //					this.Cpu = CpuDistribution.Both;
        //					break;
        //			}
        //			this.Board = Convert.ToByte(board);
        //			SectionEncoded = 0;
        //			When = new Byte[3];
        //			Sequence = new Byte[3];
        //			Data = new Byte[PacketConstants.DataSize];
        ////			Crc = 0;
        //		}

        //		////////////////////////////////////////////////////////////////////////////////////////////////////
        //		/// <summary>	Constructor. </summary>
        //		///
        //		/// <param name="clusterId">	Identifier for the cluster. </param>
        //		/// <param name="controller">	The controller. </param>
        //		/// <param name="cpu">		  	The CPU. </param>
        //		/// <param name="board">	  	The board. </param>
        //		/// <param name="section">	  	The section. </param>
        //		////////////////////////////////////////////////////////////////////////////////////////////////////

        //		public DataPacket6xx(UInt32 clusterId, UInt16 controller, UInt16 cpu, UInt16 board, UInt16 section)
        //		{
        //			Soh = PacketConstants.Soh;
        //			Length = PacketConstants.LengthWithoutData;
        //			Distribute = PacketDistribution.FromServerToSpecificPanelBoardSection;
        //			ClusterId = Convert.ToByte(clusterId);
        //			PanelId = Convert.ToByte(controller);
        //			this.Cpu = Convert.ToByte(cpu);
        //			switch (cpu)
        //			{
        //				case CpuDistribution.EitherCpu:
        //				case CpuDistribution.Cpu1Only:
        //				case CpuDistribution.Cpu2Only:
        //					break;

        //				default:
        //					this.Cpu = CpuDistribution.Both;
        //					break;
        //			}
        //			this.Board = Convert.ToByte(board);
        //			this.SectionEncoded = Convert.ToByte(section);
        //			When = new Byte[3];
        //			Sequence = new Byte[3];
        //			Data = new Byte[PacketConstants.DataSize];
        ////			Crc = 0;
        //		}

        //		////////////////////////////////////////////////////////////////////////////////////////////////////
        //		/// <summary>	Constructor. </summary>
        //		///
        //		/// <param name="clusterId"> 	Identifier for the cluster. </param>
        //		/// <param name="controller"> 	The controller. </param>
        //		/// <param name="cpu">				The CPU. </param>
        //		/// <param name="board">			The board. </param>
        //		/// <param name="section">			The section. </param>
        //		/// <param name="subSection">	The sub section. </param>
        //		////////////////////////////////////////////////////////////////////////////////////////////////////

        //		public DataPacket6xx(UInt32 clusterId, UInt16 controller, UInt16 cpu, UInt16 board, UInt16 section, UInt16 subSection)
        //		{
        //			Soh = PacketConstants.Soh;
        //			Length = PacketConstants.LengthWithoutData;
        //			Distribute = PacketDistribution.FromServerToSpecificPanelBoardSection;
        //			ClusterId = Convert.ToByte(clusterId);
        //			PanelId = Convert.ToByte(controller);
        //			this.Cpu = Convert.ToByte(cpu);
        //			switch (cpu)
        //			{
        //				case CpuDistribution.EitherCpu:
        //				case CpuDistribution.Cpu1Only:
        //				case CpuDistribution.Cpu2Only:
        //					break;

        //				default:
        //					this.Cpu = CpuDistribution.Both;
        //					break;
        //			}
        //			this.Board = Convert.ToByte(board);
        //			this.SectionEncoded = Convert.ToByte(section | (subSection << 3));
        //			When = new Byte[3];
        //			Sequence = new Byte[3];
        //			Data = new Byte[PacketConstants.DataSize];
        ////			Crc = 0;
        //		}

        #region Public Properties
        public string FromHardwareAddress => $"{this.ClusterId}:{this.PanelId}:{this.Cpu}:{this.Board}:{this.SectionEncoded}";

        public UInt16 Section => Utilities.ExtractSection(this.SectionEncoded);

        public UInt16 Node => Utilities.ExtractSubSection(SectionEncoded);

        #endregion

        public String GetDataHexString()
        {
            String sDebug = string.Empty;
            for (int x = 0; x < this.Length - PacketConstants.LengthWithoutData; x++)
                sDebug += $"{Data[x]:x2}";

            return sDebug;
        }

        public void EncodeSection(UInt16 section, UInt16 node)
        {
            SectionEncoded = Utilities.EncodeSection(section, node);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Converts the entire packet to a byte array </summary>
        ///
        /// <returns>	The bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] GetBytes()
        {
            Int32 buf_len = Length + (byte)HeaderSize.UInt16ClusterAndPanelIds;// PacketConstants.HeaderSize;// sizeof(uint) + sizeof(UInt16);
                                                                               //           buf_len -= (Pkt600Struct.DATA_SIZE - length);	// only allocate and send as much data as the packet length

            Byte[] ba = new Byte[buf_len];
            Int32 x = 0;

            Byte[] temp = BitConverter.GetBytes(Soh);
            foreach (var t in temp)
                ba[x++] = t;

            temp = BitConverter.GetBytes(Length);
            foreach (var t in temp)
                ba[x++] = t;

            ba[x++] = Distribute;

            temp = BitConverter.GetBytes(ClusterId);
            foreach (var t in temp)
                ba[x++] = t;

            temp = BitConverter.GetBytes(PanelId);
            foreach (var t in temp)
                ba[x++] = t;

            ba[x++] = Cpu;

            temp = BitConverter.GetBytes(Board);
            foreach (var t in temp)
                ba[x++] = t;

            ba[x++] = SectionEncoded;

            foreach (var t in When)
                ba[x++] = t;

            foreach (var t in Sequence)
                ba[x++] = t;

            foreach (var t in Data)
            {
                ba[x++] = t;
                if (x >= buf_len)
                    break;
            }
            return ba;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Gets the bytes that can be encrypted. This excludes the soh and length (header) members. </summary>
        ///
        /// <returns>	The encryptable bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] GetEncryptableBytes()
        {
            Int32 buf_len = Length;

            Byte[] ba = new Byte[buf_len];
            Int32 x = 0;

            var temp = BitConverter.GetBytes(PanelId);
            foreach (var t in temp)
                ba[x++] = t;

            ba[x++] = Cpu;

            temp = BitConverter.GetBytes(Board);
            foreach (var t in temp)
                ba[x++] = t;

            ba[x++] = SectionEncoded;

            foreach (var t in When)
                ba[x++] = t;

            foreach (var t in Sequence)
                ba[x++] = t;

            foreach (var t in Data)
            {
                ba[x++] = t;
                if (x >= buf_len)
                    break;
            }
            return ba;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the packet header is valid. The soh and length members are considered./ </summary>
        ///
        /// <value>	true if this object is header valid, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsHeaderValid
        {
            get
            {
                if (Soh != (uint)SohCode.UInt16ClusterAndPanelIds)
                    return false;

                if (Length < 32 || Length > 1040)
                    return false;

                if ((Length % 16) != 0)
                    return false;

                return true;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the object is a valid packet based on the header and CRC being correct. </summary>
        ///
        /// <returns>	true if valid, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsValid()
        {
            if (IsHeaderValid == false)
                return false;

            if (this.Length < 32 || this.Length > 1040)
                return false;

            if (ValidateCrc() == false)
                return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Decrypts the packet data using AES and the specified key </summary>
        ///
        /// <param name="key">	The key. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Decrypt(byte[] key)
        {
            UInt16 origLen = this.Length;
            UInt32 origSoh = this.Soh;

            byte[] bytesToDecrypt = GetEncryptableBytes();
            byte[] decrypted = GCS.Security.AesCrypto.DecryptBytesFromBytes_AES(bytesToDecrypt, key);
            FromBytes(decrypted);
            Soh = origSoh;
            Length = origLen;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Encrypts the packet data using AES and the specified key </summary>
        ///
        /// <param name="key">	The key. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Encrypt(byte[] key)
        {
            UInt16 origLen = this.Length;
            UInt32 origSoh = this.Soh;

            byte[] bytesToEncrypt = GetEncryptableBytes();
            byte[] encrypted = GCS.Security.AesCrypto.EncryptBytesToBytes_AES(bytesToEncrypt, key);
            FromBytes(encrypted);
            Soh = origSoh;
            Length = origLen;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <param name="o">	The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(object o)//, int size)
        {
            int size = Marshal.SizeOf(o);
            //if (sz != size)
            //	System.Diagnostics.Trace.WriteLine("FillData size mismatch");
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(o, ptr, true);
                Marshal.Copy(ptr, this.Data, 0, size);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
            Marshal.FreeHGlobal(ptr);

            SetPacketLength((UInt16)size);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <remarks>   Kevin, 1/24/2019. </remarks>
        ///
        /// <param name="o">            The object to process. </param>
        /// <param name="objectSize">   Size of the object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(object o, int objectSize)//, int size)
        {
            int size = objectSize;
            //if (sz != size)
            //	System.Diagnostics.Trace.WriteLine("FillData size mismatch");
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(o, ptr, true);
                Marshal.Copy(ptr, this.Data, 0, size);
            }
            catch (AccessViolationException e)
            {
                Trace.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
            Marshal.FreeHGlobal(ptr);

            SetPacketLength((UInt16)size);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Fill data byte array with the object. This object must be a structure. </summary>
        ///
        /// <param name="o">	The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FillData(Byte[] data)
        {
            if (data.Length <= Data.Length)
            {
                Buffer.BlockCopy(data, 0, Data, 0, data.Length);
                SetPacketLength((UInt16)data.Length);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Sets the packet length value based on the length of the data byte array. </summary>
        ///
        /// <param name="dataSize">	Size of the data portion of the packet. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetPacketLength(UInt16 dataSize)
        {   // the dataSize is the size of the structure that has been copied into the data array			
            UInt16 dataLength = CalculateDataLength(dataSize); // calculate the size that the data array must be to accomodate the structure. 
                                                               // This is forced to be on a 16 byte boundry
                                                               // 
            Length = (ushort)(Marshal.SizeOf(this) - PacketConstants.DataSize - (byte)HeaderSize.UInt16ClusterAndPanelIds + dataLength);

            Length += sizeof(UInt32);   // add room for the crc (4 bytes)
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///  <summary>	Prepares the packet for transmission. It plugs the when value, calculates and fills the CRC bytes for non-passthru packets </summary>
        ///
        /// <remarks>   Kevin, 5/31/2018. </remarks>
        ///
        /// <param name="passthru"> True to passthru. </param>
        /// <param name="fillWhen"> True to fill when. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrepareForTransmission(bool passthru, bool fillWhen, string timeZoneId)
        {
            if (passthru == false)
            {
                if (fillWhen == true)
                    FillWhen(timeZoneId);
                CalculateAndFillCrc();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Initializes this object from an array of bytes. The array of bytes does not include the soh or length values. It is used to create a packet in conjunction with the encryption and decryption methods. </summary>
        ///
        /// <param name="bytes">	The bytes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FromBytes(byte[] bytes)
        { // the bytes does not include soh & length 
            //Soh = (uint)SohCode.UInt16ClusterAndPanelIds;//PacketConstants.Soh;
            //Length = (ushort)bytes.Length;
            //Distribute = (byte)PacketDistribution.FromServerToAllPanelsOnCluster;
            //ClusterId = 0;
            //PanelId = 0;
            //Cpu = 0;
            //Board = 0;
            //SectionEncoded = 0;
            //When = new Byte[3];
            //Sequence = new Byte[3];
            //Data = new Byte[PacketConstants.DataSize];

            Int32 len = bytes.GetLength(0);
            Int32 index = 0;

            //Distribute = bytes[index++];
            //ClusterId = bytes[index++];


            PanelId = BitConverter.ToUInt16(bytes, index);
            index += sizeof(ushort);

            Cpu = bytes[index++];
            Board = BitConverter.ToUInt16(bytes, index);
            index += sizeof(ushort);

            SectionEncoded = bytes[index++];
            int y;
            for (y = 0; y < When.Length; y++)
                When[y] = bytes[index++];

            for (y = 0; y < Sequence.Length; y++)
                Sequence[y] = bytes[index++];

            for (y = 0; y < Data.Length; y++)
            {
                Data[y] = bytes[index++];
                if (index >= len)
                    break;
            }
        }

        #region Private Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the data length. The length of the packet must be on a 16 byte boundry. </summary>
        ///
        /// <param name="dataSize">	Size of the data portion of the packet. </param>
        ///
        /// <returns>	The calculated data length. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt16 CalculateDataLength(UInt16 dataSize)
        {
            if (dataSize == 0)
                dataSize = PacketConstants.MinimumDataSize;

            if ((dataSize % PacketConstants.MinimumDataSize) != 0)
            {   // if not an even 16 bytes
                dataSize = (UInt16)(((dataSize / PacketConstants.MinimumDataSize) * PacketConstants.MinimumDataSize) + PacketConstants.MinimumDataSize);
            }
            return dataSize;
        }

        /// <summary>	Calculates the CRC and plugs it at the end of the data. The packet length must be already set properly.</summary>
        void CalculateAndFillCrc()
        {
            UInt32 crc = CalculateCrc();
            UInt16 crcOffset = CalculateCrcOffset();    // figure out where the CRC must go
            byte[] crcBytes = BitConverter.GetBytes(crc);
            for (int x = 0; x < crcBytes.Length; x++)
                Data[crcOffset + x] = crcBytes[x];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the CRC offset within the data buffer. </summary>
        ///
        /// <returns>	The calculated CRC offset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt16 CalculateCrcOffset()
        {
            //			UInt16 crc_offset = (UInt16)(length - PacketConstants.LengthWithoutData - PacketConstants.HeaderSize);
            UInt16 crc_offset = Length;
            crc_offset -= PacketConstants.LengthWithoutData;
            return crc_offset;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Gets elapsed seconds in week. </summary>
        ///
        /// <returns>	The elapsed seconds in week. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 GetElapsedSecondsInWeek(string timeZoneId)
        {
            //DateTime now = DateTime.Now;
            var now = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(timeZoneId);

            //Trace.WriteLine($"{timeZoneId}: {now.ToString()}");

            TimeSpan span = new TimeSpan((int)now.DayOfWeek, now.Hour, now.Minute, now.Second);
            return (UInt32)span.TotalSeconds;
        }

        /// <summary>	Fills the when value </summary>
        public void FillWhen(string timeZoneId)
        {
            UInt32 elapsedSecondsInWeek = GetElapsedSecondsInWeek(timeZoneId);
            byte[] secondsIntoWeek = BitConverter.GetBytes(elapsedSecondsInWeek);
            When[0] = secondsIntoWeek[0];
            When[1] = secondsIntoWeek[1];
            When[2] = secondsIntoWeek[2];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Determines if the CRC is valid. This method is typically used to validate a packet that was received</summary>
        ///
        /// <returns>	true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool ValidateCrc()
        {
            UInt32 extractedCRC = ExtractCrc();
            UInt32 calculatedCRC = CalculateCrc();

            if (extractedCRC == calculatedCRC)
                return true;
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Extracts the CRC from the end of the buffer </summary>
        ///
        /// <returns>	The extracted CRC. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 ExtractCrc()
        {
            UInt32 crc = 0;
            UInt16 crc_offset = Length;
            crc_offset -= PacketConstants.LengthWithoutData;

            crc = BitConverter.ToUInt32(Data, crc_offset);
            //// Added this to erase the CRC because the crc data was being transmitted to GCSComm service
            //// and was ending up in the card_data section of log messages for non-card related messages
            if (Distribute == (byte)PacketDistribution.FromPanelToServer)
            {
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
                Data[crc_offset++] = 0;
            }

            return crc;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Calculates the CRC. This should only be called after all the other packet members have been set. </summary>
        ///
        /// <returns>	The calculated CRC. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        UInt32 CalculateCrc()
        {
            uint crc = 0;
            byte[] array = GetBytes();
            //for (int x = 0; x < Length - sizeof(UInt32) + PacketConstants.HeaderSize; x++)
            for (int x = 0; x < Length - sizeof(UInt32) + (byte)HeaderSize.UInt16ClusterAndPanelIds; x++)
            {
                crc = GCS.Security.Crc32.UPDC32(array[x], crc);
            }
            return crc;
        }

        #endregion
    }







}
