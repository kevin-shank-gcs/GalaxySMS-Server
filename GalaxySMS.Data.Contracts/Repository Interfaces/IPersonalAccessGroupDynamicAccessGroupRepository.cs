using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonalAccessGroupDynamicAccessGroupRepository : IDataRepository<PersonalAccessGroupDynamicAccessGroup>
    {
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

