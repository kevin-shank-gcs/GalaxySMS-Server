using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Address
    {
        public Address()
        {
            Initialize();
        }

        public Address(Address e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            StateProvince = new StateProvince();
        }

        public void Initialize(Address e)
        {
            Initialize();
            if (e == null)
                return;
            this.AddressUid = e.AddressUid;
            this.StreetAddress = e.StreetAddress;
            this.PostalCode = e.PostalCode;
            this.City = e.City;
            this.StateProvinceUid = e.StateProvinceUid;
            this.Longitude = e.Longitude;
            this.Latitude = e.Latitude;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.StateProvince = e.StateProvince;
        }

        public Address Clone(Address e)
        {
            return new Address(e);
        }

        public bool Equals(Address other)
        {
            return base.Equals(other);
        }


        public bool IsPrimaryKeyEqual(Address other)
        {
            if (other == null)
                return false;

            if (other.AddressUid != this.AddressUid)
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