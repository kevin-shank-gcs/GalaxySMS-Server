using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface IAddressRepository : IDataRepository<Address>
    {
        IHasAddress SaveAddress(IHasAddress entity, IApplicationUserSessionDataHeader sessionData,
            PDSATransaction transaction, ISaveParameters saveParams);
        Address SaveAddress(Address address, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);

        IEnumerable<Address> GetAllForStateProvince(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Address> GetAllForCountry(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

