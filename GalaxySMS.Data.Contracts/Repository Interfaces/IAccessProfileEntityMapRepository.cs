using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessProfileEntityMapRepository : IDataRepository<AccessProfileEntityMap>
    {
        IEnumerable<AccessProfileEntityMap> GetAllAccessProfileEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessProfileEntityMap> GetAllAccessProfileEntityMapsForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

