using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalAlarmEventAcknowledgmentRepository : IDataRepository<AccessPortalAlarmEventAcknowledgment>
    {
        IEnumerable<AccessPortalAlarmEventAcknowledgment> GetByAccessPortalActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AcknowledgedAlarmBasicData GetAcknowledgedAlarmBasicData_ByAccessPortalAlarmEventAcknowledgmentUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

