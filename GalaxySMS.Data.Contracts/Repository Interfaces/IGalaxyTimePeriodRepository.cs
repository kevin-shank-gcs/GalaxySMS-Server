using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyTimePeriodRepository : IPagedDataRepository<GalaxyTimePeriod>, IHasGetEntityId
    {
        IArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriodsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyTimePeriod_PanelLoadData GetGalaxyTimePeriodPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<GalaxyTimePeriod_PanelLoadData> parameters);

        int GetAvailablePanelTimePeriodNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

