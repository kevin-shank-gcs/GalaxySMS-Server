#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.ConcurrencyValue = 0;
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
            this.Standard26Bit = e.Standard26Bit;

            this.Bqt36Bit = e.Bqt36Bit;
            this.Corporate1K35Bit = e.Corporate1K35Bit;
            this.Corporate1K48Bit = e.Corporate1K48Bit;
            this.CredentialFormat = e.CredentialFormat;
            this.Cypress37Bit = e.Cypress37Bit;
            this.CredentialData = e.CredentialData;
            this.H1030437Bit = e.H1030437Bit;
            this.PIV75Bit = e.PIV75Bit;
            this.XceedId40Bit = e.XceedId40Bit;

        }

        public bool IsAnythingDirty
        {
            get
            {
                if (IsDirty)
                    return IsDirty;

                if (Standard26Bit != null)
                    if (Standard26Bit.IsDirty)
                        return true;

                if (Corporate1K35Bit != null)
                    if (Corporate1K35Bit.IsDirty)
                        return true;

                if (Corporate1K48Bit != null)
                    if (Corporate1K48Bit.IsDirty)
                        return true;

                if (CredentialFormat != null)
                    if (CredentialFormat.IsDirty)
                        return true;

                if (CredentialData != null)
                    if (CredentialData.IsDirty)
                        return true;

                if (H1030437Bit != null)
                    if (H1030437Bit.IsDirty)
                        return true;

                if (PIV75Bit != null)
                    if (PIV75Bit.IsDirty)
                        return true;

                if (Bqt36Bit != null)
                    if (Bqt36Bit.IsDirty)
                        return true;

                if (XceedId40Bit != null)
                    if (XceedId40Bit.IsDirty)
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
                if (Standard26Bit != null)
                    return Standard26Bit.HasValidData;

                if (Corporate1K35Bit != null)
                    return Corporate1K35Bit.HasValidData;

                if (Corporate1K48Bit != null)
                    return Corporate1K48Bit.HasValidData;

                if (Cypress37Bit != null)
                    return Cypress37Bit.HasValidData;

                if (CredentialData != null)
                    return CredentialData.HasValidData;

                if (H1030437Bit != null)
                    return H1030437Bit.HasValidData;

                if (XceedId40Bit != null)
                    return XceedId40Bit.HasValidData;

                if (Bqt36Bit != null)
                    return Bqt36Bit.HasValidData;

                if (PIV75Bit != null)
                    return PIV75Bit.HasValidData;

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
