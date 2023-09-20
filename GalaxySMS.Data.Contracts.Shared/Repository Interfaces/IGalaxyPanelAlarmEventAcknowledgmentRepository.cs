using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelAlarmEventAcknowledgmentRepository : IDataRepository<GalaxyPanelAlarmEventAcknowledgment>
    {
        IEnumerable<GalaxyPanelAlarmEventAcknowledgment> GetByGalaxyPanelActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        AcknowledgedAlarmBasicData GetAcknowledgedAlarmBasicData_ByGalaxyPanelAlarmEventAcknowledgmentUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

