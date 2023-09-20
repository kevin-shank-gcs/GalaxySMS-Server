using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class Country
    {
        public Country()
        {
            Initialize();
        }

        public Country(Country e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.StateProvinces = new HashSet<StateProvince>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(Country e)
        {
            Initialize();
            if (e == null)
                return;
            this.CountryUid = e.CountryUid;
            this.CountryIso = e.CountryIso;
            this.CountryName = e.CountryName;
            this.LongCountryName = e.LongCountryName;
            this.Iso3 = e.Iso3;
            this.NumberCode = e.NumberCode;
            this.UnitedNationsMemberState = e.UnitedNationsMemberState;
            this.CallingCode = e.CallingCode;
            this.CCTLD = e.CCTLD;
            this.FlagImage = e.FlagImage;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.StateProvinces = e.StateProvinces.ToCollection();
        }

        public Country Clone(Country e)
        {
            return new Country(e);
        }

        public bool Equals(Country other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Country other)
        {
            if (other == null)
                return false;

            if (other.CountryUid != this.CountryUid)
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