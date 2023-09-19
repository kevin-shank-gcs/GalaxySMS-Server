using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IClusterEntityMapRepository : IDataRepository<ClusterEntityMap>
    {
        IEnumerable<ClusterEntityMap> GetAllClusterEntityMapsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<ClusterEntityMap> GetAllClusterEntityMapsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

