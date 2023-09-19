using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleInputOutputGroupRepository : IDataRepository<RoleInputOutputGroup>
    {
        IEnumerable<RoleInputOutputGroup> GetAllForInputOutputGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputOutputGroup> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputOutputGroup> GetAllForRoleIdAndClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

