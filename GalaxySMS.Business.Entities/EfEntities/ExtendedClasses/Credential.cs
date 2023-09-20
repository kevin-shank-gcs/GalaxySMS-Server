using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Credential
    {
        public Credential()
        {
            Initialize();
        }

        public Credential(Credential e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Credential e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialUid = e.CredentialUid;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.CardNumber = e.CardNumber;
            this.CardNumberIsHex = e.CardNumberIsHex;
            this.CardBinaryData = e.CardBinaryData;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.BitCount = e.BitCount;
            this.Credential26BitStandard = e.Credential26BitStandard;

            this.CredentialBqt36Bit = e.CredentialBqt36Bit;
            this.CredentialCorporate1K35Bit = e.CredentialCorporate1K35Bit;
            this.CredentialCorporate1K48Bit = e.CredentialCorporate1K48Bit;
            this.CredentialFormat = e.CredentialFormat;
            this.CredentialCypress37Bit = e.CredentialCypress37Bit;
            this.CredentialData = e.CredentialData;
            this.CredentialH1030437Bit = e.CredentialH1030437Bit;
            this.CredentialPIV75Bit = e.CredentialPIV75Bit;
            this.CredentialXceedId40Bit = e.CredentialXceedId40Bit;

        }

        public bool IsAnythingDirty
        {
            get
            {
                if (IsDirty)
                    return IsDirty;

                if (Credential26BitStandard != null)
                    if (Credential26BitStandard.IsDirty)
                        return true;

                if (CredentialCorporate1K35Bit != null)
                    if (CredentialCorporate1K35Bit.IsDirty)
                        return true;

                if (CredentialCorporate1K48Bit != null)
                    if (CredentialCorporate1K48Bit.IsDirty)
                        return true;

                if (CredentialFormat != null)
                    if (CredentialFormat.IsDirty)
                        return true;

                if (CredentialData != null)
                    if (CredentialData.IsDirty)
                        return true;

                if (CredentialH1030437Bit != null)
                    if (CredentialH1030437Bit.IsDirty)
                        return true;

                if (CredentialPIV75Bit != null)
                    if (CredentialPIV75Bit.IsDirty)
                        return true;

                if (CredentialBqt36Bit != null)
                    if (CredentialBqt36Bit.IsDirty)
                        return true;

                if (CredentialXceedId40Bit != null)
                    if (CredentialXceedId40Bit.IsDirty)
                        return true;
                return IsDirty;
            }
        }

        public Credential Clone(Credential e)
        {
            return new Credential(e);
        }

        public bool Equals(Credential other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Credential other)
        {
            if (other == null)
                return false;

            if (other.CredentialUid != this.CredentialUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool HasValidData
        {
            get
            {
                if (Credential26BitStandard != null)
                    return Credential26BitStandard.HasValidData;

                if (CredentialCorporate1K35Bit != null)
                    return CredentialCorporate1K35Bit.HasValidData;

                if (CredentialCorporate1K48Bit != null)
                    return CredentialCorporate1K48Bit.HasValidData;

                if (CredentialCypress37Bit != null)
                    return CredentialCypress37Bit.HasValidData;

                if (CredentialData != null)
                    return CredentialData.HasValidData;

                if (CredentialH1030437Bit != null)
                    return CredentialH1030437Bit.HasValidData;

                if (CredentialXceedId40Bit != null)
                    return CredentialXceedId40Bit.HasValidData;

                if (CredentialBqt36Bit != null)
                    return CredentialBqt36Bit.HasValidData;

                if (CredentialPIV75Bit != null)
                    return CredentialPIV75Bit.HasValidData;

                return
                    string.IsNullOrEmpty(this.CardNumber) ||
                    string.IsNullOrWhiteSpace(this.CardNumber);

                //return
                //    Credential26BitStandard.HasValidData ||
                //    CredentialCorporate1K35Bit.HasValidData ||
                //    CredentialCorporate1K48Bit.HasValidData ||
                //    CredentialCypress37Bit.HasValidData ||
                //    CredentialData.HasValidData ||
                //    CredentialH1030437Bit.HasValidData ||
                //    CredentialXceedId40Bit.HasValidData ||
                //    CredentialBqt36Bit.HasValidData ||
                //    CredentialPIV75Bit.HasValidData ||
                //    string.IsNullOrEmpty(this.CardNumber) ||
                //    string.IsNullOrWhiteSpace(this.CardNumber);
            }
        }
    }
}
