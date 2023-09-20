namespace GalaxySMS.Client.Entities
{
    public partial class CredentialSoftwareHouse37Bit
    {
        public CredentialSoftwareHouse37Bit() : base()
        {
            Initialize();
        }

        public CredentialSoftwareHouse37Bit(CredentialSoftwareHouse37Bit e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(CredentialSoftwareHouse37Bit e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.CredentialUid = e.CredentialUid;
            this.FacilityCode = e.FacilityCode;
            this.SiteCode = e.SiteCode;
            this.IdCode = e.IdCode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public CredentialSoftwareHouse37Bit Clone(CredentialSoftwareHouse37Bit e)
        {
            return new CredentialSoftwareHouse37Bit(e);
        }

        public bool Equals(CredentialSoftwareHouse37Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialSoftwareHouse37Bit other)
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
    }
}
