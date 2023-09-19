using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalActivityAlarmEventRepository : IDataRepository<AccessPortalActivityAlarmEvent>
    {
        IEnumerable<AccessPortalActivityAlarmEvent> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AccessPortalActivityAlarmEvent GetByAccessPortalActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        PanelActivityLogMessage[] GetUnacknowledgedAlarms(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

