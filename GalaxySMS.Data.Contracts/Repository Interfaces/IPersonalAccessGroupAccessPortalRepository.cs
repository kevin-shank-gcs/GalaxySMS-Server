using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonalAccessGroupAccessPortalRepository : IDataRepository<PersonalAccessGroupAccessPortal>
    {
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonalAccessGroupAccessPortal> GetAllPersonalAccessGroupAccessPortalsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

