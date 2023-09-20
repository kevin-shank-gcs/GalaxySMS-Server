namespace GalaxySMS.Client.Entities
{
    public partial class UploadedFile
    {
        public UploadedFile() : base()
        {
            Initialize();
        }

        public UploadedFile(UploadedFile e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(UploadedFile e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.UploadedFileUid = e.UploadedFileUid;
            this.Tag = e.Tag;
            this.UniqueFilename = e.UniqueFilename;
            this.OriginalFilename = e.OriginalFilename;
            this.ContentType = e.ContentType;
            this.PhotoImage = e.PhotoImage;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public UploadedFile Clone(UploadedFile e)
        {
            return new UploadedFile(e);
        }

        public bool Equals(UploadedFile other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UploadedFile other)
        {
            if (other == null)
                return false;

            if (other.UploadedFileUid != this.UploadedFileUid)
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
