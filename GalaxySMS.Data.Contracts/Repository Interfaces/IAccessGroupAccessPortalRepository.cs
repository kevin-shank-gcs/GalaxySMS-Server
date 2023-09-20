using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessGroupAccessPortalRepository : IDataRepository<AccessGroupAccessPortal>
    {
        IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        ValidationProblemDetails Validate(AccessGroupAccessPortal data, string propertyName, int index);
        ValidationProblemDetails Validate(IEnumerable<AccessGroupAccessPortal> data, string propertyName);
        ValidationProblemDetails ValidateAccessPortalsAndScheduleMatchCluster(IEnumerable<AccessGroupAccessPortal> data, Guid clusterUid, string propertyName);

        ValidationProblemDetails ValidateAccessGroupsAndScheduleMatchCluster(IEnumerable<AccessGroupAccessPortal> data,
            Guid clusterUid, string propertyName);
    }
}

