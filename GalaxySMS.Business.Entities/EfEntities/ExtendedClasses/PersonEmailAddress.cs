using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonEmailAddress
    {
        public PersonEmailAddress()
        {
            Initialize();
        }

        public PersonEmailAddress(PersonEmailAddress e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonEmailAddress e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonEmailAddressUid = e.PersonEmailAddressUid;
            this.PersonUid = e.PersonUid;
            this.Label = e.Label;
            this.EmailAddress = e.EmailAddress;
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

        public PersonEmailAddress Clone(PersonEmailAddress e)
        {
            return new PersonEmailAddress(e);
        }

        public bool Equals(PersonEmailAddress other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonEmailAddress other)
        {
            if (other == null)
                return false;

            if (other.PersonEmailAddressUid != this.PersonEmailAddressUid)
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
