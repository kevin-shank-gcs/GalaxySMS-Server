using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleMercScpGroupRepository : IDataRepository<RoleMercScpGroup>
    {
        IEnumerable<RoleMercScpGroup> GetAllForMercScpGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<RoleMercScpGroup> GetAllForMercScpGroupAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleMercScpGroup> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleMercScpGroup> GetAllForRoleIdAndSiteUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

