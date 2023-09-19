using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleInputDevicePermissionRepository : IDataRepository<RoleInputDevicePermission>
    {
        IEnumerable<RoleInputDevicePermission> GetAllForRoleInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputDevicePermission> GetAllForPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

