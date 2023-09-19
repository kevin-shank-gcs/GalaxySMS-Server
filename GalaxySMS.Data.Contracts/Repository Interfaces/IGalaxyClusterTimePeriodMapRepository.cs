using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyClusterTimePeriodMapRepository : IDataRepository<GalaxyClusterTimePeriodMap>
    {
        IEnumerable<GalaxyClusterTimePeriodMap> GetAllGalaxyClusterTimePeriodMapForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyClusterTimePeriodMap> GetAllGalaxyClusterTimePeriodMapForPeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

