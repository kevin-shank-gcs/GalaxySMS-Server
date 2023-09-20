using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialBQT36BitFormat : CredentialFormatBase
    {
        private uint _facilityCode;
        private uint _idCode;
        private uint _issueNumber;


        public const UInt64 OddParityMask = 0x3ffff;
        public const UInt64 EvenParityMask = 0xffffC0000;

        public const short OddParityBitPosition = 36;
        public const short EvenParityBitPosition = 1;

        public const short OddParityComputeSequence = 2;
        public const short EvenParityComputeSequence = 1;

        public const int TotalBitLength = 36;
        public const int FacilityCodeBitLength = 10;
        public const short FacilityCodeStartBitPosition = 6;
        public const int FacilityCodeMinimumValue = 0;
        public const uint FacilityCodeMaximumValue = 0x3FF;

        public const int IdCodeBitLength = 20;
        public const short IdCodeStartBitPosition = 16;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0xFFFFF;

        public const int IssueCodeBitLength = 4;
        public const short IssueCodeStartBitPosition = 2;
        public const int IssueCodeMinimumValue = 1;
        public const uint IssueCodeMaximumValue = 0xF;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialBQT36BitFormat()
        {
            FacilityCode = 0;
            IDCode = 0;
            IssueNumber = 0;
            BitCount = TotalBitLength;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 6/6/2017. </remarks>
        ///
        /// <param name="facilityCode"> The facility code. </param>
        /// <param name="idCode">       The identifier code. </param>
        /// <param name="issueNumber">  The issue number. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialBQT36BitFormat(uint facilityCode, uint idCode, uint issueNumber)
        {
            FacilityCode = facilityCode;
            IDCode = idCode;
            IssueNumber = issueNumber;
            BitCount = TotalBitLength;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the facility code. </summary>
        ///
        /// <value> The facility code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint FacilityCode
        {
            get { return _facilityCode; }
            set
            {
                if (value >= FacilityCodeMinimumValue && value <= FacilityCodeMaximumValue)
                    _facilityCode = value;
                else _facilityCode = 0;
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
                if (value >= IdCodeMinimumValue && value <= IdCodeMaximumValue)
                    _idCode = value;
                else _idCode = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the issue number. </summary>
        ///
        /// <value> The issue number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public uint IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value <= IssueCodeMaximumValue)
                    _issueNumber = value;
                else _issueNumber = 0;
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
                if (FacilityCode != 0 || IDCode != 0 || IssueNumber != 0)
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
                return Compute(FacilityCode, IDCode, IssueNumber);
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
                    return CredentialFormatCodes.Bqt36Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Computes. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="FacilityCode"> The facility code. </param>
        /// <param name="AccessCode">   The access code. </param>
        /// <param name="IssueNumber">  The issue number. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string Compute(uint FacilityCode, uint AccessCode, uint IssueNumber)
        {
            if (FacilityCode == 0 && AccessCode == 0 && IssueNumber == 0)
                return string.Empty;
            UInt64 hex_code = 0;

            hex_code = Convert.ToUInt64(IssueNumber) & IssueCodeMaximumValue;//0xf;
            hex_code <<= 10;
            hex_code |= Convert.ToUInt64(FacilityCode) & FacilityCodeMaximumValue;// 0x3FFF;
            hex_code <<= 20;
            hex_code |= Convert.ToUInt64(AccessCode) & IdCodeMaximumValue;// 0xFFFFF;
            hex_code <<= 1;
            if (EvenParity(hex_code) == false)      // msb = EVEN PARITY 1ST 18 BITS
                hex_code |= 0x800000000;
            if (OddParity(hex_code) == false)       // lsb = ODD PARITY BITS 19 - 36
                hex_code |= 1;

            return hex_code.ToString();
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

        private static bool EvenParity(UInt64 data)   // test parity on bits 1 - 18
        {
            UInt16 ones = 0;
            UInt16 x;

            for (x = 0; x < 18; x++)
            {
                if ((data & (UInt64)0x40000) != 0)
                    ones++;
                data >>= 1;     // shift down the next bit
            }

            if ((ones % 2) != 0)    // if non-zero, then there are an odd number of ones
                return false;       // TRUE = ODD
            else
                return true;        // FALSE = NOT ODD
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Odd parity. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool OddParity(UInt64 data)  // test parity on bits 19 - 36
        {
            UInt16 ones = 0;
            UInt16 x;

            for (x = 0; x < 18; x++)
            {
                if ((data & 0x00000001) == 1)
                    ones++;
                data >>= 1;     // shift down the next bit
            }

            if ((ones % 2) != 0)        // if non-zero, then there are an odd number of ones
                return true;        // TRUE = ODD
            else
                return false;       // FALSE = NOT ODD
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the issue number described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted issue number. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractIssueNumber(ulong data)
        {
            ulong mask = (ulong)0x780000000;
            ulong issue_number = data & mask;
            issue_number >>= 31;
            return (uint)issue_number;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the facility code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted facility code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractFacilityCode(ulong data)
        {
            ulong mask = (ulong)0x7FE00000;
            ulong facility = data & mask;
            facility >>= 21;
            return (uint)facility;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the access code described by data. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The extracted access code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static uint ExtractAccessCode(ulong data)
        {
            ulong mask = (ulong)0x1FFFFF;
            ulong access_code = data & mask;
            access_code >>= 1;
            return (uint)access_code;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is binary data valid. </summary>
        ///
        /// <remarks>   Kevin, 6/11/2014. </remarks>
        ///
        /// <param name="array">    The array. </param>
        ///
        /// <returns>   A CredentialBQT36BitFormat. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CredentialBQT36BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialBQT36BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > 36)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            ulong binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(ulong));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            uint issueNumber = ExtractIssueNumber(binaryData);
            uint facilityCode = ExtractFacilityCode(binaryData);
            uint accessCode = ExtractAccessCode(binaryData);
            string computedCode = Compute(facilityCode, accessCode, issueNumber);
            if (computedCode != binaryData.ToString())
                return ret;

            ret.FacilityCode = facilityCode;
            ret.IDCode = accessCode;
            ret.IssueNumber = issueNumber;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}:{2}", FacilityCode, IDCode, IssueNumber);
            else return string.Empty;
        }
    }

}
