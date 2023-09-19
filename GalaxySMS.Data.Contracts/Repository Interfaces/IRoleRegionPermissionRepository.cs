using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleRegionPermissionRepository : IDataRepository<RoleRegionPermission>
    {
        IEnumerable<RoleRegionPermission> GetAllForRoleRegionUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleRegionPermission> GetAllForPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

