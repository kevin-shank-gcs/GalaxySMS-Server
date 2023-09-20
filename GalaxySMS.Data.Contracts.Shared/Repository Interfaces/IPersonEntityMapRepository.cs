using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonEntityMapRepository : IDataRepository<PersonEntityMap>
    {
        IEnumerable<PersonEntityMap> GetAllPersonEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonEntityMap> GetAllPersonEntityMapsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

