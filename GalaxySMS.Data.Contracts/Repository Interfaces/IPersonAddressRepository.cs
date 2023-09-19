using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonAddressRepository : IDataRepository<PersonAddress>
    {
        IEnumerable<PersonAddress> GetAllPersonAddresssForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAddress> GetAllPersonAddresssForAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

