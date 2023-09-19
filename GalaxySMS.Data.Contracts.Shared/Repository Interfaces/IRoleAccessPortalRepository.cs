using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleAccessPortalRepository : IDataRepository<RoleAccessPortal>
    {
        IEnumerable<RoleAccessPortal> GetAllForAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleAccessPortal> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleAccessPortal> GetAllForRoleIdAndClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

