using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialXceedId40BitFormat : CredentialFormatBase
    {
        private ushort _facilityCode;
        private uint _idCode;

        public const UInt64 EvenParityMask = 0xFFFFF00000;
        public const UInt64 OddParityMask = 0x7FFFFFFFFF;

        public const short EvenParityBitPosition = 1;
        public const short OddParityBitPosition = 40;

        public const short EvenParityComputeSequence = 1;
        public const short OddParityComputeSequence = 2;

        public const int TotalBitLength = 40;
        public const int SiteCodeBitLength = 10;
        public const short SiteCodeStartBitPosition = 2;
        public const int SiteCodeMinimumValue = 0;
        public const uint SiteCodeMaximumValue = 0x3ff;

        public const int IdCodeBitLength = 28;
        public const short IdCodeStartBitPosition = 12;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0xFFFFFFF;   

        public CredentialXceedId40BitFormat()
        {
            BitCount = TotalBitLength;
            SiteCode = 0;
            IDCode = 0;
        }

        public CredentialXceedId40BitFormat(ushort facilityCode, ushort idCode)
        {
            BitCount = TotalBitLength;
            SiteCode = facilityCode;
            IDCode = idCode;
        }

        public static ICredentialFormatInstance GetCredentialFormatInstance()
        {
            ICredentialFormatDefinition formatDefinition = new CredentialFormatDefinition();
            ICredentialFormatInstance formatInstance = new CredentialFormatDefinition();
            IList<ICredentialFormatDataFieldInstance> fields = new List<ICredentialFormatDataFieldInstance>();
            IList<ICredentialFormatParityInstance> parities = new List<ICredentialFormatParityInstance>();

            formatDefinition = new CredentialFormatDefinition
            {
                BitLength = TotalBitLength,
                BatchLoadSupported = true,
                BatchLoadIncrementField = 2,
                CredentialFormatCode = CredentialFormatCodes.XceedId40Bit, 
                BiometricEnrollmentSupported = false,
                BiometricIdField = 2,
                IsEnabled = true,
                Display = "XceedId 40 Bit"
            };

            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "SiteCode",
                BitLength = SiteCodeBitLength,
                MinimumValue = SiteCodeMinimumValue,
                MaximumValue = SiteCodeMaximumValue,
                StartsAt = SiteCodeStartBitPosition,
                FieldNumber = 1
            });

            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "IdCode",
                BitLength = IdCodeBitLength,
                MinimumValue = IdCodeMinimumValue,
                MaximumValue = IdCodeMaximumValue,
                StartsAt = IdCodeStartBitPosition,
                FieldNumber = 2
            });

            parities.Add(new CredentialFormatParity()
            {
                ParityType = CredentialParityTypes.Even,
                BitPosition = EvenParityBitPosition,
                ComputeSequence = EvenParityComputeSequence,
                HexMaskUlong = EvenParityMask,
                HexMask = BitConverter.GetBytes(EvenParityMask),// HexEncoding.GetBytesFromHexString(EvenParityMask.ToString("X"))
            });

            parities.Add(new CredentialFormatParity()
            {
                ParityType = CredentialParityTypes.Odd,
                BitPosition = OddParityBitPosition,
                ComputeSequence = OddParityComputeSequence,
                HexMaskUlong = OddParityMask,
                HexMask = BitConverter.GetBytes(OddParityMask),//  HexMask = HexEncoding.GetBytesFromHexString(OddParityMask.ToString("X"))
            });

            formatInstance.Initialize(formatDefinition, fields, parities);
            return formatInstance;
        }

        public ushort SiteCode
        {
            get { return _facilityCode; }
            set
            {
                if (value >= SiteCodeMinimumValue && value <= SiteCodeMaximumValue)
                    _facilityCode = value;
                else _facilityCode = 0;
            }
        }


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

        public override bool ContainsData
        {
            get
            {
                if (SiteCode != 0 || IDCode != 0)
                    return true;
                return false;
            }
        }

        public override string FCC
        {
            get
            {
                return Compute(SiteCode, IDCode);
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
                    return CredentialFormatCodes.XceedId40Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        public static string Compute(ushort siteCode, uint IDCode)
        {
            var formatInstance = CredentialXceedId40BitFormat.GetCredentialFormatInstance();
            formatInstance.SetFieldValue(1, siteCode);
            formatInstance.SetFieldValue(2, IDCode);
            return formatInstance.CalculateCode().ToString();

            //if (SiteCode == 0 && IDCode == 0)
            //    return string.Empty;

            //bool odd;
            //bool even;
            //Int32 data;

            //data = Convert.ToInt32(SiteCode);
            //data <<= IdCodeBitLength;        // shift up 16 bits
            //data |= Convert.ToInt32(IDCode);    // or in the IDCode

            //odd = OddParity(data);
            //even = EvenParity(data);

            //data <<= 1;         // make room for the parity bit
            //if (odd == false)
            //    data |= 0x01;
            //if (even == false)
            //    data |= 0x02000000;     // set the proper bit
            //return data.ToString();
        }

        //private static bool EvenParity(Int32 code)   // test parity on bits 12 - 23
        //{
        //    byte ones = 0;
        //    byte x;

        //    for (x = 0; x < 12; x++)
        //    {
        //        if ((code & 0x00001000) != 0)
        //            ones++;
        //        code >>= 1;     // shift down the next bit
        //    }

        //    if ((ones % 2) != 0)        // if non-zero, then there are an odd number of ones
        //        return false;       // FALSE = EVEN
        //    else
        //        return true;        // TRUE = NOT EVEN
        //}

        //private static bool OddParity(Int32 code)  // test parity on bits 0 - 11
        //{
        //    byte ones = 0;
        //    byte x;

        //    for (x = 0; x < 12; x++)
        //    {
        //        if ((code & 0x00000001) != 0)
        //            ones++;
        //        code >>= 1;     // shift down the next bit
        //    }

        //    if ((ones % 2) != 0)        // if non-zero, then there are an odd number of ones
        //        return true;        // TRUE = ODD
        //    else
        //        return false;       // FALSE = NOT ODD
        //}

        private static ushort ExtractSiteCode(UInt64 code)
        {
            ushort Fac;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            temp = temp >> IdCodeBitLength;  // SHIFT DOWN TO LSB
            Fac = (ushort)(temp & SiteCodeMaximumValue);
            return Fac;

        }

        private static ushort ExtractIDCode(UInt64 code)
        {
            ushort ID;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            ID = (ushort)(temp & IdCodeMaximumValue);
            return ID;
        }

        public static CredentialXceedId40BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialXceedId40BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > TotalBitLength)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            UInt64 binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(uint));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            uint idCode = ExtractIDCode(binaryData);
            ushort facCode = ExtractSiteCode(binaryData);
            string computedCode = Compute(facCode, idCode);
            if (computedCode != binaryData.ToString())
                return ret;
            ret.SiteCode = facCode;
            ret.IDCode = idCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}", SiteCode, IDCode);
            else return string.Empty;
        }
    }

}
