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
	public partial class StateProvince
    {
        public StateProvince()
        {
            Initialize();
        }

        public StateProvince(StateProvince e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.Country = new Country();
            //this.Addresses = new HashSet<Address>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(StateProvince e)
        {
            Initialize();
            if( e == null )
                return;
            this.StateProvinceUid = e.StateProvinceUid;
            this.CountryUid = e.CountryUid;
            this.StateProvinceCode = e.StateProvinceCode;
            this.StateProvinceName = e.StateProvinceName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.Country = e.Country;
            //this.Addresses = e.Addresses.ToCollection();

        }

        public StateProvince Clone(StateProvince e)
        {
            return new StateProvince(e);
        }

        public bool Equals(StateProvince other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(StateProvince other)
        {
            if( other == null ) 
                return false;

            if(other.StateProvinceUid != this.StateProvinceUid )
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

