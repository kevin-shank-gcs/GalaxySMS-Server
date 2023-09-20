using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalElevatorControlTypeRepository : IDataRepository<AccessPortalElevatorControlType>
    {
        IEnumerable<AccessPortalElevatorControlType> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessPortalElevatorControlType> GetByGalaxyPanelModelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

