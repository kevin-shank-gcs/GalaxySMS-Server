using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsRolePermissionRepository : IDataRepository<gcsRolePermission>
    {
        IEnumerable<gcsRolePermission> GetAllForRole(Guid roleId);
        IEnumerable<gcsRolePermission> GetAllForRoleAndApplication(Guid roleId, Guid applicationId);
    }
}

