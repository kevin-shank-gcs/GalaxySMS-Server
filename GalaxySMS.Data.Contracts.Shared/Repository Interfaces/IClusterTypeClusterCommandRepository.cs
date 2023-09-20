using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IClusterTypeClusterCommandRepository : IDataRepository<ClusterTypeClusterCommand>
    {
        IEnumerable<ClusterTypeClusterCommand> GetAllClusterTypeClusterCommandForClusterType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<ClusterTypeClusterCommand> GetAllClusterTypeClusterCommandForCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

