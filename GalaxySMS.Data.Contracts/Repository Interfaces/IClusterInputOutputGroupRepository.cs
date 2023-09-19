using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IClusterInputOutputGroupRepository : IDataRepository<ClusterInputOutputGroup>
    {
        IEnumerable<ClusterInputOutputGroup> GetClusterInputOutputGroupsByClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<ClusterInputOutputGroup> GetClusterInputOutputGroupsByTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

