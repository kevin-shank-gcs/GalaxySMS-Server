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

    public class CredentialHIDH1030437BitFormat : CredentialFormatBase
    {
        private ushort _facilityCode;
        private uint _idCode;

        public const UInt64 EvenParityMask = 0xFFFFC0000;
        public const UInt64 OddParityMask = 0x7FFFE;

        public const short EvenParityBitPosition = 1;
        public const short OddParityBitPosition = 37;

        public const short EvenParityComputeSequence = 1;
        public const short OddParityComputeSequence = 2;

        public const int TotalBitLength = 37;
        public const int FacilityCodeBitLength = 16;
        public const short FacilityCodeStartBitPosition = 2;
        public const int FacilityCodeMinimumValue = 0;
        public const uint FacilityCodeMaximumValue = 0xFFFF;

        public const int IdCodeBitLength = 19;
        public const short IdCodeStartBitPosition = 18;
        public const int IdCodeMinimumValue = 0;
        public const uint IdCodeMaximumValue = 0x7ffff;   // 0x7ffffff

        public CredentialHIDH1030437BitFormat()
        {
            BitCount = TotalBitLength;//37;
            FacilityCode = 0;
            IDCode = 0;
        }

        public CredentialHIDH1030437BitFormat(ushort facilityCode, ushort idCode)
        {
            BitCount = TotalBitLength;
            FacilityCode = facilityCode;
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
                CredentialFormatCode = CredentialFormatCodes.H1030437Bit, 
                BiometricEnrollmentSupported = false,
                BiometricIdField = 2,
                IsEnabled = true,
                Display = "HID H10304 37 Bit"
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
                    return CredentialFormatCodes.H1030437Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        public static string Compute(ushort FacilityCode, uint IDCode)
        {
            var formatInstance = CredentialHIDH1030437BitFormat.GetCredentialFormatInstance();
            formatInstance.SetFieldValue(1, FacilityCode);
            formatInstance.SetFieldValue(2, IDCode);
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

        private static ushort ExtractFacilityCode(UInt64 code)
        {
            ushort Fac;
            UInt64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            temp = temp >> IdCodeBitLength;  // SHIFT DOWN TO LSB
            Fac = (ushort)(temp & FacilityCodeMaximumValue);
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

        public static CredentialHIDH1030437BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialHIDH1030437BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > TotalBitLength)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            UInt64 binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(uint));
            binaryData = ByteFlipper.ReverseBytes(binaryData);
            uint idCode = ExtractIDCode(binaryData);
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
