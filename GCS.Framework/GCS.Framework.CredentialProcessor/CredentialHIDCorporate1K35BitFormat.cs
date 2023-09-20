using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialHIDCorporate1K35BitFormat : CredentialFormatBase
    {
        private uint _companyCode;
        private uint _idCode;

        public const UInt64 OddParityMSBMask = 0x3FFFFFFFF;
        public const UInt64 OddParityLSBMask = 0x36DB6DB6C;
        public const UInt64 EvenParityMask = 0x1B6DB6DB6;

        public const short OddParityMSBBitPosition = 35;
        public const short OddParityLSBBitPosition = 1;
        public const short EvenParityBitPosition = 34;

        public const short OddParityMSBComputeSequence = 3;
        public const short OddParityLSBComputeSequence = 2;
        public const short EvenParityComputeSequence = 1;


        public const int TotalBitLength = 35;
        public const int CompanyCodeBitLength = 12;
        public const short CompanyCodeStartBitPosition = 3;
        public const int CompanyCodeMinimumValue = 0;
        public const uint CompanyCodeMaximumValue = 4095;

        public const int IdCodeBitLength = 20;
        public const short IdCodeStartBitPosition = 25;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0xFFFFF;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialHIDCorporate1K35BitFormat()
        {
            CompanyCode = 0;
            IDCode = 0;
            BitCount = TotalBitLength;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2017. </remarks>
        ///
        /// <param name="companyCode">  The company code. </param>
        /// <param name="idCode">       The identifier code. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialHIDCorporate1K35BitFormat(uint companyCode, uint idCode)
        {
            CompanyCode = companyCode;
            IDCode = idCode;
            BitCount = TotalBitLength;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the company code. </summary>
        ///
        /// <value> The company code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint CompanyCode
        {
            get { return _companyCode; }
            set
            {
                if (value > CompanyCodeMinimumValue && value <= CompanyCodeMaximumValue)
                    _companyCode = value;
                else
                    _companyCode = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier code. </summary>
        ///
        /// <value> The identifier code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint IDCode
        {
            get { return _idCode; }
            set
            {
                if (value > IdCodeMinimumValue && value <= IdCodeMaximumValue)
                    _idCode = value;
                else
                    _idCode = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this object contains data. </summary>
        ///
        /// <value> true if contains data, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public override bool ContainsData
        {
            get
            {
                if (CompanyCode != 0 || IDCode != 0)
                    return true;
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the fcc. </summary>
        ///
        /// <value> The fcc. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string FCC
        {
            get
            {
                return Compute(CompanyCode, IDCode);
            }
        }


        #region Overrides of CredentialFormatBase

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the standard length binary data. </summary>
        ///
        /// <value> Information describing the binary. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override byte[] BinaryDataStandard
        {
            get
            {
                int discardedCount = 0;
                return HexEncoding.GetBytesFromDecimalString(FCC, StandardBinaryDataLength, out discardedCount);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the extended length binary data . </summary>
        ///
        /// <value> The binary data extended. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override byte[] BinaryDataExtended
        {
            get
            {
                int discardedCount = 0;
                return HexEncoding.GetBytesFromDecimalString(FCC, ExtendedBinaryDataLength, out discardedCount);
            }
        }
        #endregion



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the data format. </summary>
        ///
        /// <value> The data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override CredentialFormatCodes DataFormat
        {
            get
            {
                if (ContainsData == true)
                    return CredentialFormatCodes.Corporate1K35Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Computes. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="CompanyCode">  The company code. </param>
        /// <param name="IDCode">       The identifier code. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Compute(uint CompanyCode, uint IDCode)
        {
            if (CompanyCode == 0 && IDCode == 0)
                return string.Empty;

            UInt64 hex_code = 0;

            hex_code = Convert.ToUInt64(CompanyCode);
            hex_code <<= 21;
            hex_code |= Convert.ToUInt64(IDCode) << 1;
            if (EvenParity(hex_code) == false)
                hex_code |= 0x200000000;
            if (OddParityLSB(hex_code) == false)
                hex_code |= 1;
            if (OddParityMSB(hex_code) == false)
                hex_code |= 0x400000000;

            return hex_code.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Odd parity MSB. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool OddParityMSB(UInt64 data)
        {
//            UInt64 mask = OddParityMSBMask;
            bool bRet = false;
            int bits_on = 0;

            data &= OddParityMSBMask;
            while (data != 0)
            {
                if ((data & 1) != 0)
                    bits_on++;
                data >>= 1;
            }
            if ((bits_on % 2) != 0)
                bRet = true;
            return bRet;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Odd parity LSB. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool OddParityLSB(UInt64 data)
        {
//            UInt64 mask = 0x36DB6DB6C;
            bool bRet = false;
            int bits_on = 0;

            data &= OddParityLSBMask;
            while (data != 0)
            {
                if ((data & 1) != 0)
                    bits_on++;
                data >>= 1;
            }
            if ((bits_on % 2) != 0)
                bRet = true;
            return bRet;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Even parity. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool EvenParity(UInt64 data)
        {
//            UInt64 mask = 0x1B6DB6DB6;
            int bits_on = 0;
            bool bRet = false;

            data &= EvenParityMask;
            while (data != 0)
            {
                if ((data & 1) != 0)
                    bits_on++;
                data >>= 1;
            }
            if ((bits_on % 2) == 0)
                bRet = true;
            return bRet;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the company code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted company code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractCompanyCode(ulong data)
        {
            ulong mask = (ulong)0x1FFE00000;
            ulong company = data & mask;
            company >>= 21;
            return (uint)company;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the identifier code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted identifier code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractIDCode(ulong data)
        {
            ulong mask = (ulong)0x1FFFFE;
            ulong id = data & mask;
            id >>= 1;
            return (uint)id;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is binary data valid. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="array">    The array. </param>
        ///
        /// <returns>   A CredentialHIDCorporate1K35BitFormat. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CredentialHIDCorporate1K35BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialHIDCorporate1K35BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > 35)
                return ret;
            if (array.Length < 5)   // at least 5 bytes are required for 35 bits
                return ret;

            array = HexEncoding.PadByteArray(array, sizeof(ulong), false);

            ulong binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(ulong));
            binaryData = ByteFlipper.ReverseBytes(binaryData);

            uint idCode = ExtractIDCode(binaryData);
            uint companyCode = ExtractCompanyCode(binaryData);
            string computedCode = Compute(companyCode, idCode);
            if (computedCode != binaryData.ToString())
                return ret;
            ret.CompanyCode = companyCode;
            ret.IDCode = idCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}", CompanyCode, IDCode);
            else return string.Empty;
        }
    }

}
