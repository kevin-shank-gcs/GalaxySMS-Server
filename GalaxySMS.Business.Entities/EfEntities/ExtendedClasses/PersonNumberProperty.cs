using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonNumberProperty
    {
        public PersonNumberProperty()
        {
            Initialize();
        }

        public PersonNumberProperty(PersonNumberProperty e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonNumberProperty e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonNumberPropertyUid = e.PersonNumberPropertyUid;
            this.PersonUid = e.PersonUid;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.Value = e.Value;
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

        public PersonNumberProperty Clone(PersonNumberProperty e)
        {
            return new PersonNumberProperty(e);
        }

        public bool Equals(PersonNumberProperty other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonNumberProperty other)
        {
            if (other == null)
                return false;

            if (other.PersonNumberPropertyUid != this.PersonNumberPropertyUid)
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
