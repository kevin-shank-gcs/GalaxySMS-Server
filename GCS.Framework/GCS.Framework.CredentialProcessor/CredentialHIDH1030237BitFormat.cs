using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;

namespace GCS.Framework.CredentialProcessor
{

    public class CredentialHIDH1030237BitFormat : CredentialFormatBase
    {
        private long _idCode;

        public const UInt64 EvenParityMask = 0xFFFFC0000;
        public const UInt64 OddParityMask = 0x7FFFE;

        public const short EvenParityBitPosition = 1;
        public const short OddParityBitPosition = 37;

        public const short EvenParityComputeSequence = 1;
        public const short OddParityComputeSequence = 2;

        public const int TotalBitLength = 37;

        public const int IdCodeBitLength = 35;
        public const short IdCodeStartBitPosition = 2;
        public const int IdCodeMinimumValue = 0;
        public const long IdCodeMaximumValue = 34359738367;   // 0x7ffffffff

        public CredentialHIDH1030237BitFormat()
        {
            BitCount = TotalBitLength;//37;
            IdCode = 0;
        }

        public CredentialHIDH1030237BitFormat(long idCode)
        {
            BitCount = TotalBitLength;
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
                BatchLoadIncrementField = 1,
                CredentialFormatCode = CredentialFormatCodes.H1030237Bit,
                BiometricEnrollmentSupported = false,
                BiometricIdField = 1,
                IsEnabled = true,
                Display = "HID H10302 37 Bit (ID code only)"
            };

            fields.Add(new CredentialFormatDataField()
            {
                FieldName = "IdCode",
                BitLength = IdCodeBitLength,
                MinimumValue = IdCodeMinimumValue,
                MaximumValue = IdCodeMaximumValue,
                StartsAt = IdCodeStartBitPosition,
                FieldNumber = 1
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

        public long IdCode
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
                if (IdCode != 0)
                    return true;
                return false;
            }
        }

        public override string FCC
        {
            get
            {
                return Compute((ulong)IdCode);
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
                    return CredentialFormatCodes.H1030237Bit;
                else
                    return CredentialFormatCodes.None;
            }
        }

        public static string Compute(ulong IDCode)
        {
            var formatInstance = CredentialHIDH1030237BitFormat.GetCredentialFormatInstance();
            formatInstance.SetFieldValue(1, IDCode);
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

        private static long ExtractIDCode(Int64 code)
        {
            long ID;
            Int64 temp;

            temp = code >> 1;   // SHIFT OUT THE PARITY BIT
            ID = (temp & IdCodeMaximumValue);
            return ID;
        }

        public static CredentialHIDH1030237BitFormat IsBinaryDataValid(byte[] array)
        {
            var ret = new CredentialHIDH1030237BitFormat();
            short hightest1Bit = HexEncoding.GetHighestNonZeroBit(array);
            if (hightest1Bit > TotalBitLength)
                return ret;
            if (array.Length < sizeof(int))
                return ret;

            var binaryData = BitConverter.ToUInt64(array, array.Length - sizeof(uint));
            binaryData = ByteFlipper.ReverseBytes((ulong)binaryData);
            long idCode = ExtractIDCode((long)binaryData);
            string computedCode = Compute((ulong)idCode);
            if (computedCode != binaryData.ToString())
                return ret;
            ret.IdCode = idCode;

            return ret;
        }

        public override string ToString()
        {
            if (this.ContainsData == true)
                return string.Format("{0}", IdCode);
            else return string.Empty;
        }
    }

}
