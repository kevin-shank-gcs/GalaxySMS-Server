namespace GalaxySMS.Client.Entities
{
    public partial class CredentialH1030237Bit
    {
        public CredentialH1030237Bit() : base()
        {
            Initialize();
        }

        public CredentialH1030237Bit(CredentialH1030237Bit e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(CredentialH1030237Bit e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.CredentialUid = e.CredentialUid;
            this.IdCode = e.IdCode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public CredentialH1030237Bit Clone(CredentialH1030237Bit e)
        {
            return new CredentialH1030237Bit(e);
        }

        public bool Equals(CredentialH1030237Bit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialH1030237Bit other)
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
