namespace GalaxySMS.Client.Entities
{
    public partial class AccessPortalCommandChoice
    {
        public AccessPortalCommandChoice() : base()
        {
            Initialize();
        }

        public AccessPortalCommandChoice(AccessPortalCommandChoice e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessPortalCommandChoice e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalCommandChoiceUid = e.AccessPortalCommandChoiceUid;
            this.AccessPortalCommandUid = e.AccessPortalCommandUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ChoiceTypeCode = e.ChoiceTypeCode;
            this.ApproxWaitTime = e.ApproxWaitTime;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessPortalCommandChoice Clone(AccessPortalCommandChoice e)
        {
            return new AccessPortalCommandChoice(e);
        }

        public bool Equals(AccessPortalCommandChoice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalCommandChoice other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalCommandChoiceUid != this.AccessPortalCommandChoiceUid)
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
