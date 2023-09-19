using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelActivityAlarmEventRepository : IDataRepository<GalaxyPanelActivityAlarmEvent>
    {
        IEnumerable<GalaxyPanelActivityAlarmEvent> GetByGalaxyPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyPanelActivityAlarmEvent GetByGalaxyPanelActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        PanelActivityLogMessage[] GetUnacknowledgedAlarms(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

