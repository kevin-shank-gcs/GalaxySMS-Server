using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleClusterPermissionRepository : IDataRepository<RoleClusterPermission>
    {
        IEnumerable<RoleClusterPermission> GetAllForRoleClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleClusterPermission> GetAllForPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

