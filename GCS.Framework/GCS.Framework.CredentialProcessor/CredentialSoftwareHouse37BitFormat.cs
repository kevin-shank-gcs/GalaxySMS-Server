using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialSoftwareHouse37BitFormat : CredentialFormatBase
    {
        private short _facilityCode;
        private short _siteCode;
        private int _idCode;

        public const UInt64 EvenParityMask = 0x1FFFE0000;
        public const UInt64 OddParityMask = 0x1FFFE;

        public const short EvenParityBitPosition = 1;
        public const short OddParityBitPosition = 37;

        public const short EvenParityComputeSequence = 1;
        public const short OddParityComputeSequence = 2;

        public const int TotalBitLength = 37;
        public const int FacilityCodeBitLength = 10;
        public const short FacilityCodeStartBitPosition = 5;
        public const int FacilityCodeMinimumValue = 0;
        public const uint FacilityCodeMaximumValue = 0x3FF;

        public const int SiteCodeBitLength = 6;
        public const short SiteCodeStartBitPosition = 15;
        public const int SiteCodeMinimumValue = 0;
        public const uint SiteCodeMaximumValue = 0x3F;

        public const int IdCodeBitLength = 16;
        public const short IdCodeStartBitPosition = 21;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0xffff;

        public CredentialSoftwareHouse37BitFormat()
        {
            BitCount = TotalBitLength;//37;
            FacilityCode = 0;
            SiteCode = 0;
            IdCode = 0;
        }

        public CredentialSoftwareHouse37BitFormat(short facilityCode, short siteCode, int idCode)
        {
            BitCount = TotalBitLength;
            FacilityCode = facilityCode;
            SiteCode = siteCode;
            IdCode = idCode;
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
                BatchLoadIncrementField = 3,
                CredentialFormatCode = CredentialFormatCodes.SoftwareHouse37Bit,
                BiometricEnrollmentSupported = false,
                BiometricIdField = 3,
                IsEnabled = true,
                Display = "Software House 37 Bit"
            };

            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "FacilityCode",
                BitLength = FacilityCodeBitLength,
                MinimumValue = FacilityCodeMinimumValue,
                MaximumValue = FacilityCodeMaximumValue,
                StartsAt = FacilityCodeStartBitPosition,
                FieldNumber = 1
            });


            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "SiteCode",
                BitLength = SiteCodeBitLength,
                MinimumValue = SiteCodeMinimumValue,
                MaximumValue = SiteCodeMaximumValue,
                StartsAt = SiteCodeStartBitPosition,
                FieldNumber = 2
            });

            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "IdCode",
                BitLength = IdCodeBitLength,
                MinimumValue = IdCodeMinimumValue,
                MaximumValue = IdCodeMaximumValue,
                StartsAt = IdCodeStartBitPosition,
                FieldNumber = 3
            });

            parities.Add(new CredentialFormatParity()
            {
                ParityType = CredentialParityTypes.Even,
                BitPosition = EvenParityBitPosition,
                ComputeSequence = EvenParityComputeSequence,
                HexMaskUlong = EvenParityMask,
                HexMask = BitConverter.GetBytes(EvenParityMask),
            });

            parities.Add(new CredentialFormatParity()
            {
                ParityType = CredentialParityTypes.Odd,
                BitPosition = OddParityBitPosition,
                ComputeSequence = OddParityComputeSequence,
                HexMaskUlong = OddParityMask,
                HexMask = BitConverter.GetBytes(OddParityMask),
            });

            formatInstance.Initialize(formatDefinition, fields, parities);
            return formatInstance;
        }

        public short FacilityCode
        {
            get { return _facilityCode; }
            set
            {
                if (value >= FacilityCodeMinimumValue && value <= FacilityCodeMaximumValue)
                    _facilityCode = value;
                else _facilityCode = 0;
            }
        }

        public short SiteCode
        {
            get { return _siteCode; }
            set
            {
                if (value >= SiteCodeMinimumValue && value <= SiteCodeMaximumValue)
                    _siteCode = value;
                else _siteCode = 0;
            }
        }


        public int IdCode
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
                if (FacilityCode != 0 || SiteCode != 0 || IdCode != 0)
                    return true;
                return false;
            }
        }

        public override string FCC
        {
            get
            {
                return Compute(FacilityCode, SiteCode, IdCode);
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
                    return CredentialFormatCodes.SoftwareHouse37Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        public static string Compute(short FacilityCode, short SiteCode, int IDCode)
        {
            var formatInstance = CredentialSoftwareHouse37BitFormat.GetCredentialFormatInstance();
            formatInstance.SetFieldValue(1, FacilityCode);
            formatInstance.SetFieldValue(2, SiteCode);
            formatInstance.SetFieldValue(3, IDCode);
            return formatInstance.CalculateCode().ToString();

            //if (FacilityCode == 0 && IDCode == 0)
            //    return string.Empty;

            //bool odd;
            //bool even;
            //Int32 data;

            //data = Convert.ToInt32(FacilityCode);
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

        private static short ExtractFacilityCode(UInt64 code)
        {
            short Fac;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            temp = temp >> IdCodeBitLength;  // SHIFT DOWN TO LSB
            Fac = (short)(temp & FacilityCodeMaximumValue);
            return Fac;
        }

        private static short ExtractSiteCode(UInt64 code)
        {
            short sc;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            temp = temp >> SiteCodeBitLength;  // SHIFT DOWN TO LSB
            sc = (short)(temp & SiteCodeMaximumValue);
            return sc;
        }

        private static short ExtractIDCode(UInt64 code)
        {
            short ID;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            ID = (short)(temp & IdCodeMaximumValue);
            return ID;
        }

        public static CredentialSoftwareHouse37BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialSoftwareHouse37BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > TotalBitLength)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            UInt64 binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(uint));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            var idCode = ExtractIDCode(binaryData);
            var facCode = ExtractFacilityCode(binaryData);
            var siteCode = ExtractSiteCode(binaryData);
            string computedCode = Compute(facCode, siteCode, idCode);
            if (computedCode != binaryData.ToString())
                return ret;

            ret.FacilityCode = facCode;
            ret.SiteCode = siteCode;
            ret.IdCode = idCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}:{1}:{2}", FacilityCode, SiteCode, IdCode);
            else return string.Empty;
        }
    }

}
