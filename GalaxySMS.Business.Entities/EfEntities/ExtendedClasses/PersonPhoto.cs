using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
