using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonAccessProfile
    {
        public PersonAccessProfile()
        {
            Initialize();
        }

        public PersonAccessProfile(PersonAccessProfile e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonAccessProfile e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonAccessProfileUid = e.PersonAccessProfileUid;
            this.PersonUid = e.PersonUid;
            this.AccessProfileUid = e.AccessProfileUid;
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

        public PersonAccessProfile Clone(PersonAccessProfile e)
        {
            return new PersonAccessProfile(e);
        }

        public bool Equals(PersonAccessProfile other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonAccessProfile other)
        {
            if (other == null)
                return false;

            if (other.PersonAccessProfileUid != this.PersonAccessProfileUid)
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
