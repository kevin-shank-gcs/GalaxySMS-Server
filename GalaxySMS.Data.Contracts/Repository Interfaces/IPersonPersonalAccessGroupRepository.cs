using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonPersonalAccessGroupRepository : IDataRepository<PersonPersonalAccessGroup>
    {
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        int GetAvailablePersonalAccessGroupNumber(Guid clusterUid);
    }
}

