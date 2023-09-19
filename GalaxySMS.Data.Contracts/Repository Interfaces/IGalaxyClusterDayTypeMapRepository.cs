using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyClusterDayTypeMapRepository : IDataRepository<GalaxyClusterDayTypeMap>
    {
        IEnumerable<GalaxyClusterDayTypeMap> GetAllGalaxyClusterDayTypeMapForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyClusterDayTypeMap> GetAllGalaxyClusterDayTypeMapForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

