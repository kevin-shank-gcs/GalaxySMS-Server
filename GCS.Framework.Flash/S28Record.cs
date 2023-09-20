using GCS.Core.Common.Extensions;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Flash
{
    public class S28ErrorInformation
    {
        public String Data { get; set; }
        public String ErrorMessage { get; set; }
        public UInt32 LineNumber { get; set; }
    }

    // This structure represents one line in a s28 file
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct S2_Record
    {
        public Byte DataLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Byte[] Address;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Byte[] Data;
        public Byte Sumcheck;
    }

    public class S28Record
    {
        #region Private fields
        String _sError;
        Byte _recordType;
        UInt32 _address;
        Boolean _isValid;
        UInt32 _length;
        Byte _sumCheck;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.EZ80_FLASH_PACKET_SIZE)]
        Byte[] _data;

        String _sRawData;

        S2_Record _rawRecord;

        #endregion
        public S28Record(string s2Record)
        {
            _address = 0;
            _sError = string.Empty;
            _recordType = 0;
            _length = 0;
            _sumCheck = 0;
            _data = new Byte[Constants.EZ80_FLASH_PACKET_SIZE];
            _rawRecord = new S2_Record();
            _sRawData = s2Record;

            _isValid = ValidateVariableLengthRecord(_sRawData);

        }

        #region Public Methods

        public Boolean ValidateVariableLengthRecord(String sDataIn)
        {
            String sData = sDataIn;
            String sTemp;
            int x = 0;
            int offset = 0;
            int templen = 0;

            Byte bData = 0;
            Byte sum = 0xFF;

            _isValid = true;  // assume valid

            if (sData[0] != 'S')
            {
                _isValid = false;
                _sError = $"Not an S-Record. First character should be 'S' and it is '{sData[0]}'.";
                return _isValid;
            }

            if (sData[1] != '2')
            {
                _isValid = false;
                _sError = $"Invalid record type. The second character should be '2' and it is '{sData[1]}'.";
                return _isValid;
            }

            _recordType = Convert.ToByte(sData[1]);

            sData = sData.Substring(2); // chop of the RecordType characters
            var lineLengthText = sData.Substring(0, 2);
            var lineLength = Convert.ToByte(lineLengthText, 16);

            x = 0;
            templen = sData.GetLength();
            if (!sData.IsHexadecimal(false))
            {
                _sError = $"Invalid data. ({sData}) is not entirely HEX";
                _isValid = false;
                return _isValid;
            }

            bData = 0;
            sum = 0xFF;
            // convert it to hex now
            for (x = 0; x < templen; x += 2, offset++)
            {
                try
                {
                    sTemp = sData.Substring(x, 2);    // grab 2 digits at a time
                    var byteValue = Convert.ToByte(sTemp, 16);
                    sum -= byteValue;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(e.ToString());
                }
            }

            // if sum is anything other than 0, then the sumcheck did not match
            if (sum != 0)
            {
                _sError = $"Sumcheck error. Sum = {sum}";
                _isValid = false;
                return _isValid;
            }



            sTemp = sData.Substring(0, 2);
            _length = Convert.ToUInt32(sTemp, 16);

            sData = sData.Substring(2); // chop of the Length characters
            sTemp = sData.Substring(0, 6);
            _address = Convert.ToUInt32(sTemp, 16);

            sData = sData.Substring(6); // chop of the Address characters

            sTemp = sData.Substring(sData.Length - 2);
            _sumCheck = Convert.ToByte(sTemp, 16);

            sData = sData.Substring(0, sData.Length - 2);  // chop of the SumCheck characters at the end


            if (sData.Length % 2 != 0)
            {
                _isValid = false;
                _sError = $"Invalid length. Length = {sData.Length}. Not divisible by 2";
                return _isValid;
            }


            if (_isValid == false)
                return _isValid;

            int Length = sData.GetLength() / 2;

            if (Length != _length - 4) // 4 comes from 3 for address & 1 for sumcheck //sizeof( m_RawRecord ) )
            {
                _sError = $"Invalid length ({Length}).";
                _isValid = false;
                return _isValid;
            }

            offset = 0;

            bData = 0;
            // convert it to hex now

            for (x = 0; x < sData.Length; x += 2, offset++)
            {
                if (offset >= _data.Length)
                {
                    _isValid = false;
                    return _isValid;
                }

                try
                {
                    sTemp = sData.Substring(x, 2);    // grab 2 digits at a time
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(e.ToString());
                }

                bData = Convert.ToByte(sTemp, 16);
                _data[offset] = bData;
            }


            return _isValid;
        }

        public Boolean IsValid()
        {
            return _isValid;
        }

        public String GetError()
        {
            return _sError;
        }

        public uint GetAddress()
        {
            return _address;
        }

        public UInt32 GetDataLength()
        {
            return _length - 4;
        }


        public Int32 GetOffsetOfAddress(UInt32 address)
        {
            Int32 ret = -1;
            if (address < _address)
                return ret;
            if (address > (_address + GetDataLength()))
                return ret;
            return (Int32)((Int32)address - _address);
        }

        public Boolean ReadByteValue(ref Byte data, uint address)
        {
            Boolean bRet = false;
            if (IsMyAddress(address) == false)
                return bRet;

            uint offset = address & 0x0F;

            data = _data[offset];
            bRet = true;
            return bRet;
        }

        public Boolean ReadWORDValue(ref ushort data, uint address)
        {   // ONLY SUPPORTS READING DATA THAT IS CONTAINED COMPLETELY IN THIS RECORD. No wrapping supported
            Boolean bRet = false;
            if (IsMyAddress(address) == false)
                return bRet;

            var offset = address & 0x0F;
            if (offset > GetDataLength() - sizeof(ushort))    //  maximum of 16 Bytes of real data per line	
                return bRet;
            data = BitConverter.ToUInt16(_data, (int)offset);
            data = ByteConverters.ReverseBytes(data);
            bRet = true;
            return bRet;
        }


        public Boolean ReadDWORDValue(ref UInt32 data, uint address)
        {   // ONLY SUPPORTS READING DATA THAT IS CONTAINED COMPLETELY IN THIS RECORD. No wrapping supported
            Boolean bRet = false;
            if (IsMyAddress(address) == false)
                return bRet;

            var offset = address & 0x0F;
            if (offset > GetDataLength() - sizeof(UInt32))   //  maximum of 16 Bytes of real data per line	
                return bRet;

            data = BitConverter.ToUInt32(_data, (int)offset);
            data = ByteConverters.ReverseBytes(data);
            bRet = true;
            return bRet;
        }

        public Boolean ReadDWORDValueByOffset(ref UInt32 data, uint offset)
        {   // ONLY SUPPORTS READING DATA THAT IS CONTAINED COMPLETELY IN THIS RECORD. No wrapping supported
            Boolean bRet = false;

            if (offset > GetDataLength() - sizeof(UInt32))   //  maximum of 16 Bytes of real data per line	
                return bRet;

            data = BitConverter.ToUInt32(_data, (int)offset);
            data = ByteConverters.ReverseBytes(data);
            bRet = true;
            return bRet;
        }



        public Boolean ReadDataValue(ref Byte[] data, uint address, Byte length)
        {   // ONLY SUPPORTS READING DATA THAT IS CONTAINED COMPLETELY IN THIS RECORD. No wrapping supported
            Boolean bRet = false;
            if (IsMyAddress(address) == false)
                return bRet;

            var offset = address & 0x0F;
            if (length < 1)
                return bRet;
            if (offset + length > GetDataLength())
                return bRet;

            Buffer.BlockCopy(_data, (int)offset, data, 0, length);

            bRet = true;
            return bRet;
        }

        public UInt32 CalculateDataSumcheck()
        {
            UInt32 val = 0;
            //for( UINT x = 0; x < m_RawRecord.data_length - sizeof(m_RawRecord.address) - sizeof( m_RawRecord.sumcheck); x++ )
            //	val += m_RawRecord.data[x];
            for (uint x = 0; x < _length - 3 - 1; x++) // 3 for the address Bytes and 1 for the checksum Byte
                val += _data[x];
            return val;
        }

        public Byte[] GetData(UInt32 length)
        {
            if (length > _data.Length)
                return _data;
            var returnData = new byte[length];
            Buffer.BlockCopy(_data, 0, returnData, 0, (int)length);
            return returnData;
        }

        #endregion
        #region Private methods
        Boolean IsMyAddress(UInt32 address)
        {
            if ((address & 0xFFFFF0) == _address)
                return true;
            return false;
        }
        #endregion

    }
}
