using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IInputDeviceAlarmEventAcknowledgmentRepository : IDataRepository<InputDeviceAlarmEventAcknowledgment>
    {
        IEnumerable<InputDeviceAlarmEventAcknowledgment> GetByInputDeviceActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AcknowledgedAlarmBasicData GetAcknowledgedAlarmBasicData_ByInputDeviceAlarmEventAcknowledgmentUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

