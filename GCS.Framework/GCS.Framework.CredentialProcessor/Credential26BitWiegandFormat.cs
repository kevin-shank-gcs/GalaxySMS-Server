using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{

    public class Credential26BitWiegandFormat : CredentialFormatBase
    {
        private ushort _facilityCode;
        private int _idCode;

        public const UInt32 EvenParityMask = 0x1FFE000;
        public const UInt32 OddParityMask = 0x1FFE;

        public const short EvenParityBitPosition = 1;
        public const short OddParityBitPosition = 26;

        public const short EvenParityComputeSequence = 1;
        public const short OddParityComputeSequence = 2;

        public const int TotalBitLength = 26;
        public const int FacilityCodeBitLength = 8;
        public const short FacilityCodeStartBitPosition = 2;
        public const int FacilityCodeMinimumValue = 0;
        public const uint FacilityCodeMaximumValue = 0xff;

        public const int IdCodeBitLength = 16;
        public const short IdCodeStartBitPosition = 10;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0xffff;

        public Credential26BitWiegandFormat()
        {
            FacilityCode = 0;
            IDCode = 0;
            BitCount = TotalBitLength;//26;
        }

        public Credential26BitWiegandFormat(ushort facilityCode, int idCode)
        {
            FacilityCode = facilityCode;
            IDCode = idCode;
            BitCount = TotalBitLength;//26;
        }


        public ushort FacilityCode
        {
            get { return _facilityCode; }
            set
            {
                if (value >= FacilityCodeMinimumValue && value <= FacilityCodeMaximumValue)
                    _facilityCode = value;
                else _facilityCode = 0;
            }
        }


        public int IDCode
        {
            get { return _idCode; }
            set
            {
                if (value >= IdCodeMinimumValue && value <= IdCodeMaximumValue)
                    _idCode = value;
                else _idCode = 0;
            }
        }


        public override bool ContainsData
        {
            get
            {
                if (FacilityCode != 0 || IDCode != 0)
                    return true;
                return false;
            }
        }

        public override string FCC
        {
            get
            {
                return Compute(FacilityCode, IDCode);
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

        public override CredentialFormatCodes DataFormat
        {
            get
            {
                if (ContainsData == true)
                    return CredentialFormatCodes.Standard26Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        public static string Compute(ushort FacilityCode, int IDCode)
        {
            if (FacilityCode == 0 && IDCode == 0)
                return 0.ToString();//string.Empty;

            bool odd;
            bool even;
            Int32 data;

            data = Convert.ToInt32(FacilityCode);
            data <<= 16;        // shift up 16 bits
            data |= Convert.ToInt32(IDCode);    // or in the IDCode

            odd = OddParity(data);
            even = EvenParity(data);

            data <<= 1;         // make room for the parity bit
            if (odd == false)
                data |= 0x01;
            if (even == false)
                data |= 0x02000000;     // set the proper bit
            return data.ToString();
        }

        private static bool EvenParity(Int32 code)   // test parity on bits 12 - 23
        {
            byte ones = 0;
            byte x;

            for (x = 0; x < 12; x++)
            {
                if ((code & 0x00001000) != 0)
                    ones++;
                code >>= 1;     // shift down the next bit
            }

            if ((ones % 2) != 0)        // if non-zero, then there are an odd number of ones
                return false;       // FALSE = EVEN
            else
                return true;        // TRUE = NOT EVEN
        }

        private static bool OddParity(Int32 code)  // test parity on bits 0 - 11
        {
            byte ones = 0;
            byte x;

            for (x = 0; x < 12; x++)
            {
                if ((code & 0x00000001) != 0)
                    ones++;
                code >>= 1;     // shift down the next bit
            }

            if ((ones % 2) != 0)        // if non-zero, then there are an odd number of ones
                return true;        // TRUE = ODD
            else
                return false;       // FALSE = NOT ODD
        }

        private static ushort ExtractFacilityCode(uint code)
        {
            ushort Fac;
            long temp;

            temp = code >> 17;  // SHIFT DOWN TO LSB
            Fac = (ushort)(temp & 0x00ff);
            return Fac;

        }

        private static ushort ExtractIDCode(uint code)
        {
            ushort ID;
            long temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            ID = (ushort)(temp & 0x0000ffff);
            return ID;
        }

        public static Credential26BitWiegandFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new Credential26BitWiegandFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > 26)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            uint binaryData = BitConverter.ToUInt32(array, array.Length - sizeof(uint));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            ushort idCode = ExtractIDCode(binaryData);
            ushort facCode = ExtractFacilityCode(binaryData);
            string computedCode = Compute(facCode, idCode);
            if (computedCode != binaryData.ToString())
                return ret;
            ret.FacilityCode = facCode;
            ret.IDCode = idCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}", FacilityCode, IDCode);
            else return string.Empty;
        }
    }

}
