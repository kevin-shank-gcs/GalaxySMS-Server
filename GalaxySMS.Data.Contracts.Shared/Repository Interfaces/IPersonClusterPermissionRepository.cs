using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonClusterPermissionRepository : IDataRepository<PersonClusterPermission>
    {
        IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

