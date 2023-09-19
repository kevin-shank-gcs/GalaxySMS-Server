using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalEntityMapRepository : IDataRepository<AccessPortalEntityMap>
    {
        IEnumerable<AccessPortalEntityMap> GetAllAccessPortalEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessPortalEntityMap> GetAllAccessPortalEntityMapsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

