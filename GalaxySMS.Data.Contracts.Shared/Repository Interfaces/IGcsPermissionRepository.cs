using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsPermissionRepository : IDataRepository<gcsPermission>
    {
        IEnumerable<gcsPermission> GetAllPermissionsForApplication(Guid applicationId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsPermission> GetAllPermissionsForPermissionCategory(Guid permissionCategoryId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsPermission> GetAllPermissionsForRole(Guid roleId, IGetParametersWithPhoto getParameters);
    }
}

