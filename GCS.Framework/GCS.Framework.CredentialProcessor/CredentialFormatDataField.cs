using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Utils;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialFormatDataField:ICredentialFormatDataFieldInstance
    {
        #region Implementation of ICredentialFormatDataField

        public string FieldName { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public short StartsAt { get; set; }
        public short BitLength { get; set; }
        public ulong MinimumValue { get; set; }
        public ulong MaximumValue { get; set; }
        public short FieldNumber { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsVisible { get; set; }
        public ulong DefaultValue { get; set; }

        #endregion

        #region Implementation of ICredentialFormatDataFieldInstance

        public void Initialize(ICredentialFormatDataField field)
        {
            this.DefaultValue = field.DefaultValue;
            this.BitLength = field.BitLength;
            this.Description = field.Description;
            this.Display = field.Display;
            this.FieldName = field.FieldName;
            this.FieldNumber = field.FieldNumber;
            this.IsReadOnly = field.IsReadOnly;
            this.IsVisible = field.IsVisible;
            this.MaximumValue = field.MaximumValue;
            this.MinimumValue = field.MinimumValue;
            this.StartsAt = field.StartsAt;
        }

        public void InitializeValue()
        {
            Value = DefaultValue;
        }

        public int MaxDigits
        {
            get
            {
                uint compareTo = 10;
                int maxDigits = 1;
                while (compareTo < uint.MaxValue)
                {
                    if (MaximumValue < compareTo)
                        return maxDigits;
                    maxDigits++;
                    compareTo *= 10;
                }
                return 0;
            }
        }

        public ulong Value { get; set; }
        public uint GetAdjustedValue32(uint finalLength)
        {
            ulong value = 0;
            value = Value;

            if (value == 0)
                return (uint)value;

            if (finalLength > 32)
                finalLength = 32;

            var numberOfBitsToShift = finalLength - BitLength - StartsAt + 1;
            if (numberOfBitsToShift > finalLength)
                return 0;

            for (int x = 0; x < numberOfBitsToShift; x++)
            {
                value = value * 2;
            }
            return (uint)value;
        }

        public ulong GetAdjustedValue64(uint finalLength)
        {
            ulong value = 0;
            value = Value;
            if (value == 0)
                return value;

            if (finalLength > 64)
                finalLength = 64;
            if (finalLength == 0)
                return 0;

            var numberOfBitsToShift = finalLength - BitLength - StartsAt + 1;
            if (numberOfBitsToShift > finalLength)
                return 0;

            for (int x = 0; x < numberOfBitsToShift; x++)
            {
                value = value * 2;
            }
            return value;
        }

        public bool ValueValid
        {
            get
            {
                if (Value < MinimumValue)
                    return false;
                if (Value > MaximumValue)
                    return false;

                return true;
            }
            
        }

        public Guid CredentialFormatDataFieldUid { get; set; }
        public Guid CredentialFormatUid { get; set; }
        public bool IsDirty { get; set; }
        public short? ConcurrencyValue { get; set; }
        public DateTimeOffset InsertDate { get; set; }
        public string InsertName { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string UpdateName { get; set; }

        public bool IsValueValid(uint value)
        {
            if (value < MinimumValue)
                return false;
            if (value > MaximumValue)
                return false;

            return true;
        }

        public uint ExtractValueFromData(ulong data, uint finalLength)
        {
            ulong mask = 0;
            uint x = 0;

            for (x = 0; x < BitLength; x++)
            {
                mask *= 2;
                mask |= 1;
            }

            var numberOfBitsToShift = finalLength - BitLength - StartsAt + 1;

            ulong test = ByteFlipper.ReverseBytes(data);

            for (x = 0; x < numberOfBitsToShift; x++)
            {
                test /= 2;
            }

            ulong value = test & mask;
            return (uint)value;
        }

        #endregion
    }
}
