using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonAddress
    {
        public PersonAddress()
        {
            Initialize();
        }

        public PersonAddress(PersonAddress e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonAddress e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonAddressUid = e.PersonAddressUid;
            this.PersonUid = e.PersonUid;
            this.AddressUid = e.AddressUid;
            this.Label = e.Label;
            this.IsCurrent = e.IsCurrent;
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

        public PersonAddress Clone(PersonAddress e)
        {
            return new PersonAddress(e);
        }

        public bool Equals(PersonAddress other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonAddress other)
        {
            if (other == null)
                return false;

            if (other.PersonAddressUid != this.PersonAddressUid)
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
