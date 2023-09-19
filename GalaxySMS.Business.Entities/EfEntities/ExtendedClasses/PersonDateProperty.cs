using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonDateProperty
    {
        public PersonDateProperty()
        {
            Initialize();
        }

        public PersonDateProperty(PersonDateProperty e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonDateProperty e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonDatePropertyUid = e.PersonDatePropertyUid;
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

        public PersonDateProperty Clone(PersonDateProperty e)
        {
            return new PersonDateProperty(e);
        }

        public bool Equals(PersonDateProperty other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonDateProperty other)
        {
            if (other == null)
                return false;

            if (other.PersonDatePropertyUid != this.PersonDatePropertyUid)
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
