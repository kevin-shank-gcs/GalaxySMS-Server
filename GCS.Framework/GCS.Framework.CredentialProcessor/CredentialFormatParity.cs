using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;

namespace GCS.Framework.CredentialProcessor
{
    public class CredentialFormatParity: ICredentialFormatParityInstance
    {
        #region Implementation of ICredentialFormatParity

        public CredentialParityTypes ParityType { get; set; }
        public byte[] HexMask { get; set; }
        public UInt64 HexMaskUlong {get;set;}
        public short BitPosition { get; set; }
        public short ComputeSequence { get; set; }
        public Guid CredentialFormatParityUid { get; set ; }
        public Guid CredentialFormatUid { get ; set ; }
        public bool IsDirty { get ; set ; }
        public short? ConcurrencyValue { get ; set ; }
        public DateTimeOffset InsertDate { get ; set ; }
        public string InsertName { get ; set ; }
        public DateTimeOffset? UpdateDate { get ; set ; }
        public string UpdateName { get ; set ; }

        public ulong GetParityValue(ulong data, short finalLength)
        {
            UInt64 retVal = 0;

            switch (ParityType)
            {
                case CredentialParityTypes.Even:
                    if (EvenParity(data, HexMaskUlong) == false)
                        return GetParityData(finalLength);
                    break;

                case CredentialParityTypes.Odd:
                    if (OddParity(data, HexMaskUlong) == false)
                        return GetParityData(finalLength);
                    break;

                default:
                    return retVal;

            }

            return retVal;
        }

        #endregion

        private bool EvenParity(UInt64 data, UInt64 mask)
        {
            int bits_on = 0;
            bool bRet = false;

            data &= mask;
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

        private bool OddParity(UInt64 data, UInt64 mask)
        {
            bool bRet = false;
            int bits_on = 0;

            data &= mask;
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

        private UInt64 GetParityData(short finalLength)
        {
            UInt64 ret = 1;

            var numberOfBitsToShift = finalLength - BitPosition + 1;
            if (numberOfBitsToShift > finalLength)
                return 0;

            for (int x = 1; x < numberOfBitsToShift; x++)
                ret *= 2;
            return ret;
        }
    }
}
