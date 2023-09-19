using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleSiteRepository : IDataRepository<RoleSite>
    {
        IEnumerable<RoleSite> GetAllForSiteUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleSite> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleSite> GetAllForRoleIdAndRegionUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

