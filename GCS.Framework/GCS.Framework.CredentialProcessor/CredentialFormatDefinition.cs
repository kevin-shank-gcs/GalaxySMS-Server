using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialFormatDefinition : ICredentialFormatInstance
    {

        public const int CARD_DATA_LENGTH = 32;

        public static int GetWiegandBitCount(byte[] dataBytes)
        {
            if (dataBytes.Length > CARD_DATA_LENGTH)
                return 0;

            int bit_count = 8 * dataBytes.Length;
            foreach (byte b in dataBytes)
            {	// byte 0 = Bits 47 - 40
                // byte 1 = Bits 39 - 32
                // byte 2 = Bits 31 - 25
                // byte 3 = Bits 24 - 17
                // byte 4 = Bits 16 - 9
                // byte 5 = Bits 8 - 1
                byte mask = 0x80;
                for (int bit = 0; bit < 8; bit++, bit_count--)
                {
                    if ((b & mask) != 0)
                        return bit_count;
                    mask >>= 1;
                }
            }

            return bit_count;
        }

        #region Implementation of ICredentialFormat

        public string Display { get; set; }
        public string Description { get; set; }
        public CredentialFormatCodes CredentialFormatCode { get; set; }
        public short BitLength { get; set; }
        public bool IsEnabled { get; set; }
        public bool BiometricEnrollmentSupported { get; set; }
        public short BiometricIdField { get; set; }
        public bool UseCardNumber { get; set; }
        public bool BatchLoadSupported { get; set; }
        public short BatchLoadIncrementField { get; set; }
        public ICollection<ICredentialFormatDataFieldInstance> CredentialFormatDataFields { get; set; }
        public ICollection<ICredentialFormatParityInstance> CredentialFormatParities { get; set; }
        public bool Initialized { get; private set; }
        ICollection<ICredentialFormatDataField> ICredentialFormatDefinition.CredentialFormatDataFields { get; set; }
        ICollection<ICredentialFormatParity> ICredentialFormatDefinition.CredentialFormatParities { get; set; }
        public short? ConcurrencyValue { get; set; }
        public DateTimeOffset InsertDate { get; set; }
        public string InsertName { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string UpdateName { get; set; }

        #endregion

        public CredentialFormatDefinition()
        {
            CredentialFormatDataFields = new List<ICredentialFormatDataFieldInstance>();
            CredentialFormatParities = new List<ICredentialFormatParityInstance>();
            Description = string.Empty;
            CredentialFormatCode = CredentialFormatCodes.None;
            BitLength = 0;
            IsEnabled = false;
            BiometricEnrollmentSupported = false;
            BiometricIdField = 0;
        }

        #region Implementation of ICredentialFormatInstance

        public void Initialize(ICredentialFormatDefinition format, IEnumerable<ICredentialFormatDataFieldInstance> fields, IEnumerable<ICredentialFormatParityInstance> parities)
        {
            this.BiometricEnrollmentSupported = format.BiometricEnrollmentSupported;
            this.BiometricIdField = format.BiometricIdField;
            this.BitLength = format.BitLength;
            this.CredentialFormatCode = format.CredentialFormatCode;
            this.Description = format.Description;
            this.Display = format.Display;
            this.BatchLoadSupported = format.BatchLoadSupported;
            this.BatchLoadIncrementField = format.BatchLoadIncrementField;
            this.IsEnabled = format.IsEnabled;
            this.UseCardNumber = format.UseCardNumber;
            this.CredentialFormatDataFields = fields.ToList();
            this.CredentialFormatParities = parities.ToList();
        }

        public bool SetFieldValue(int fieldNumber, ulong value)
        {
            foreach (var field in CredentialFormatDataFields)
            {
                if (field.FieldNumber == fieldNumber)
                {
                    field.Value = value;
                    return true;
                }
            }
            return false;
        }

        public bool SetFieldValue(int fieldNumber, long value)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return false;
            field.Value = (ulong)value;
            return true;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        field.Value = (ulong)value;
            //        return true;
            //    }
            //}
            //return false;
        }

        public ulong GetFieldValue(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return 0;
            return field.Value;
            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.Value;
            //    }
            //}
            //return 0;
        }

        public string GetFieldTitle(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return string.Empty;
            return field.Display;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.Display;
            //    }
            //}
            //return string.Empty;
        }

        public short GetMaxDigits(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return 0;
            return field.BitLength;
            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.BitLength;
            //    }
            //}

            //return 0;
        }

        public bool IsFieldVisible(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return true;
            return field.IsVisible;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.IsVisible;
            //    }
            //}

            //return true;
        }

        public bool IsFieldReadOnly(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return true;
            return field.IsReadOnly;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.IsReadOnly;
            //    }
            //}

            //return true;
        }

        public ulong GetMinimumValue(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return 0;
            return field.MinimumValue;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.MinimumValue;
            //    }
            //}

            //return 0;
        }

        public ulong GetMaximumValue(int fieldNumber)
        {
            var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            if (field == null)
                return 0;
            return field.MaximumValue;

            //foreach (var field in CredentialFormatDataFields)
            //{
            //    if (field.FieldNumber == fieldNumber)
            //    {
            //        return field.var field = CredentialFormatDataFields.FirstOrDefault(o => o.FieldNumber == fieldNumber);
            //        if (field == null)
            //            return 0;
            //        return field.MinimumValue;
            //        ;
            //    }
            //}

            //return 0;
        }

        public bool AreAllValuesValid()
        {
            foreach (var field in CredentialFormatDataFields)
            {
                if (field.ValueValid == false)
                    return false;
            }

            return true;
        }

        public ulong CalculateCode()
        {
            ulong finalvalue64 = 0;
            ulong finalParity64 = 0;

            foreach (var field in CredentialFormatDataFields)
            {
                finalvalue64 |= field.GetAdjustedValue64((uint)this.BitLength);
            }

            foreach (var parity in CredentialFormatParities)
            {
                finalParity64 |= parity.GetParityValue(finalvalue64, this.BitLength);
                finalvalue64 |= finalParity64; //added 6/6/2017
            }

            //finalvalue64 |= finalParity64; -- Commented out 6/6/2017

            ulong finalFlipped = ByteFlipper.ReverseBytes(finalvalue64);

            //string sHex = BinaryToHexString((BYTE*)&finalFlipped, sizeof(finalFlipped), FALSE, FALSE, TRUE );

            return finalvalue64;
        }

        public bool IsValidCardCode(string s, List<string> DataParts, ref uint BitCount)
        {
            DataParts.Clear();
            BitCount = 0;

            if (s.Trim() == string.Empty)
                return false;

            if (this.BitLength > 64)
                return false;

            //if( s[0] != 'x') 
            //{
            //    s = AsciiStringToHexString(s, _T("x") );
            //}

            int discarded;
            byte[] hexData;
            if (s[0] == 'x')
            {	// hex format
                hexData = HexEncoding.GetBytesFromHexString(s, CARD_DATA_LENGTH, out discarded);
            }
            else
            {
                hexData = HexEncoding.GetBytesFromDecimalString(s, CARD_DATA_LENGTH, out discarded);
            }

            ulong hexValue = BitConverter.ToUInt64(hexData, 0);

            int bc = GetWiegandBitCount(hexData);
            if (bc > this.BitLength)
                return false;

            // extract the fields
            foreach (var field in CredentialFormatDataFields)
            {
                uint value = field.ExtractValueFromData(hexValue, (uint)this.BitLength);
                string sValue = string.Format("{0}", value);
                DataParts.Add(sValue);

            }

            ResetValues();

            for (int x = 0; x < DataParts.Count; x++)
            {
                string sPart = DataParts[x];
                SetFieldValue(x + 1, Convert.ToUInt32(sPart));
            }

            ulong testValue = CalculateCode();
            ulong finalFlipped = ByteFlipper.ReverseBytes(testValue);

            if (finalFlipped == hexValue)
                return true;
            return false;

        }

        public bool IsValueValid(int fieldNumber)
        {
            foreach (var field in CredentialFormatDataFields)
            {
                if (field.FieldNumber == fieldNumber)
                {
                    return field.ValueValid;
                }
            }

            return false;
        }

        public int GetFirstInvalidFieldNumber()
        {
            foreach (var field in CredentialFormatDataFields)
            {
                if (field.ValueValid == false)
                    return field.FieldNumber;
            }

            return 0;
        }

        public void ResetValues()
        {
            foreach (var field in CredentialFormatDataFields)
            {
                field.InitializeValue();
            }
        }


        #endregion
    }


}
