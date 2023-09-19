using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IDeviceAlertEventSettingsRepository: IRepository<EntityDeviceAlertEventSettings>
    {
        EntityDeviceAlertEventSettings GetForEntityId(Guid entityId, bool isActive);
        EntityDeviceAlertEventSettings SaveForEntityId(SaveParameters<EntityDeviceAlertEventSettings> parameters, bool isActive, IApplicationUserSessionDataHeader sessionData);
        ValidationProblemDetails Validate(EntityDeviceAlertEventSettings data, ISaveParameters saveParams, IApplicationUserSessionDataHeader sessionData);
    }
}
