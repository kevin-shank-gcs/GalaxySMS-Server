using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalElevatorControlTypePanelModelRepository : IDataRepository<AccessPortalElevatorControlTypePanelModel>
    {
        IEnumerable<AccessPortalElevatorControlTypePanelModel> GetAllAccessPortalElevatorControlTypePanelModelsForElevatorControlType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AccessPortalElevatorControlTypePanelModel> GetAllAccessPortalElevatorControlTypePanelModelsForPanelModel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

