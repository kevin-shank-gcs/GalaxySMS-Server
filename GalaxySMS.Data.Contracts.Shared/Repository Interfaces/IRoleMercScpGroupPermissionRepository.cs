using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleMercScpGroupPermissionRepository : IDataRepository<RoleMercScpGroupPermission>
    {
        IEnumerable<RoleMercScpGroupPermission> GetAllForRoleMercScpGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleMercScpGroupPermission> GetAllForPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

