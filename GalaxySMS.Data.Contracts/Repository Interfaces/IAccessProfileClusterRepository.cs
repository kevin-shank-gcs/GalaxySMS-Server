using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessProfileClusterRepository : IDataRepository<AccessProfileCluster>
    {
        IEnumerable<AccessProfileCluster> GetAllForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileCluster> GetAllForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

