using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessProfileAccessGroupRepository : IDataRepository<AccessProfileAccessGroup>
    {
        IEnumerable<AccessProfileAccessGroup> GetAllForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileAccessGroup> GetAllForAccessProfileCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileAccessGroup> GetAllForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileAccessGroup> GetAllForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

