namespace GalaxySMS.Client.Entities
{
    public partial class PersonPhotoScaled
    {
        public PersonPhotoScaled() : base()
        {
            Initialize();
        }

        public PersonPhotoScaled(PersonPhotoScaled e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(PersonPhotoScaled e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonPhotoScaledUid = e.PersonPhotoScaledUid;
            this.PersonPhotoUid = e.PersonPhotoUid;
            this.UniqueFilename = e.UniqueFilename;
            this.PublicUrl = e.PublicUrl;
            this.PhotoImage = e.PhotoImage;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public PersonPhotoScaled Clone(PersonPhotoScaled e)
        {
            return new PersonPhotoScaled(e);
        }

        public bool Equals(PersonPhotoScaled other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonPhotoScaled other)
        {
            if (other == null)
                return false;

            if (other.PersonPhotoScaledUid != this.PersonPhotoScaledUid)
                return false;
            if (other.PersonPhotoUid != this.PersonPhotoUid)
                return false;
            if (other.UniqueFilename != this.UniqueFilename)
                return false;
            if (other.PhotoImage != this.PhotoImage)
                return false;
            if (other.InsertName != this.InsertName)
                return false;
            if (other.InsertDate != this.InsertDate)
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
