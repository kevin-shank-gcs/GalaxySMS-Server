using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceActivityAlarmEventRepository : IDataRepository<InputDeviceActivityAlarmEvent>
    {
        IEnumerable<InputDeviceActivityAlarmEvent> GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        InputDeviceActivityAlarmEvent GetByInputDeviceActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        PanelActivityLogMessage[] GetUnacknowledgedAlarms(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

