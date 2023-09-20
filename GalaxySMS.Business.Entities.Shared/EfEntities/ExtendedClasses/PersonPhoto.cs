using GCS.Core.Common.Extensions;
using System.Collections.Generic;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class PersonPhoto
    {
        public PersonPhoto()
        {
            Initialize();
        }

        public PersonPhoto(PersonPhoto e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            ScaledPhotos = new HashSet<PersonPhotoScaled>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonPhoto e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonPhotoUid = e.PersonPhotoUid;
            this.PersonUid = e.PersonUid;
            this.Tag = e.Tag;
            this.OriginalFilename = e.OriginalFilename;
            this.UniqueFilename = e.UniqueFilename;
            this.ContentType = e.ContentType;
            this.IsDefault = e.IsDefault;
            this.PublicUrl = e.PublicUrl;
            this.PhotoImage = e.PhotoImage;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.ScaledPhotos != null)
                this.ScaledPhotos = e.ScaledPhotos.ToCollection();

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

        public PersonPhoto Clone(PersonPhoto e)
        {
            return new PersonPhoto(e);
        }

        public bool Equals(PersonPhoto other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonPhoto other)
        {
            if (other == null)
                return false;

            if (other.PersonPhotoUid != this.PersonPhotoUid)
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
