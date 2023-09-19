using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPropertySensitivityLevelPermissionRepository : IDataRepository<PropertySensitivityLevelPermission>
    {
        IEnumerable<PropertySensitivityLevelPermission> GetAllPropertySensitivityLevelPermissionForSensitivityLevel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<PropertySensitivityLevelPermission> GetAllPropertySensitivityLevelPermissionForPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        PropertySensitivityLevelPermission GetPropertySensitivityLevelPermissionBySensitivityLevelUidAndPermissionId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

