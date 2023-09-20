using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{

    public interface IPersonInputOutputGroupRepository : IDataRepository<PersonInputOutputGroup>
    {
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonInputOutputGroup> GetAllPersonInputOutputGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

