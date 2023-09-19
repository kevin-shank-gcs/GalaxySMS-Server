using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonAccessGroupRepository : IDataRepository<PersonAccessGroup>
    {
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonAccessGroup> GetAllPersonAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

