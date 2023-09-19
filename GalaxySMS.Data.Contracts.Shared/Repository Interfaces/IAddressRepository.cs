using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAddressRepository : IDataRepository<Address>
    {
        IHasAddress SaveAddress(IHasAddress entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        Address SaveAddress(Address address, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
        IEnumerable<Address> GetAllForStateProvince(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<Address> GetAllForCountry(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

