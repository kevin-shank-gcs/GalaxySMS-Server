using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IClusterCommandRepository : IDataRepository<ClusterCommand>
    {
        IEnumerable<ClusterCommand> GetAllClusterCommandsForClusterType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<ClusterCommand> GetAllClusterFlashingCommandsForClusterType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

