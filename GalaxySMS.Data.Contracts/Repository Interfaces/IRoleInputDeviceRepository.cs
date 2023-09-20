using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IRoleInputDeviceRepository : IDataRepository<RoleInputDevice>
    {
        IEnumerable<RoleInputDevice> GetAllForInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputDevice> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<RoleInputDevice> GetAllForRoleIdAndClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);

    }
}

