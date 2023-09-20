namespace GalaxySMS.Business.Entities
{
    public partial class UploadedFile
    {
        public UploadedFile()
        {
            Initialize();
        }

        public UploadedFile(UploadedFile e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(UploadedFile e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
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
