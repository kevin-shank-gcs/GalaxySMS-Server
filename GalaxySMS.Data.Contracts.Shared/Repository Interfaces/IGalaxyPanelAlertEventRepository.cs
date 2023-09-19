using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyPanelAlertEventRepository : IDataRepository<GalaxyPanelAlertEvent>
    {
        IEnumerable<GalaxyPanelAlertEvent> GetByGalaxyPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyPanelAlertEvent> GetByEntityId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

