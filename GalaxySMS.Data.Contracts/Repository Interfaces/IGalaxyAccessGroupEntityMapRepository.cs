using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyAccessGroupEntityMapRepository : IDataRepository<AccessGroupEntityMap>
    {
        IEnumerable<AccessGroupEntityMap> GetAllAccessGroupEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessGroupEntityMap> GetAllAccessGroupEntityMapsForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

