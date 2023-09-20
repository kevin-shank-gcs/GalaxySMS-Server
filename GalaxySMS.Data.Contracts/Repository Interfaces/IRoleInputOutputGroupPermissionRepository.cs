using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleInputOutputGroupPermissionRepository : IDataRepository<RoleInputOutputGroupPermission>
    {
        IEnumerable<RoleInputOutputGroupPermission> GetAllForRoleInputOutputGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputOutputGroupPermission> GetAllForPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

