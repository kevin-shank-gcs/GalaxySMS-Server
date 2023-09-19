using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyClusterTimeScheduleMapRepository : IDataRepository<GalaxyClusterTimeScheduleMap>
    {
        IEnumerable<GalaxyClusterTimeScheduleMap> GetAllGalaxyClusterTimeScheduleMapForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<GalaxyClusterTimeScheduleMap> GetAllGalaxyClusterTimeScheduleMapForSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        GalaxyClusterTimeScheduleMap GetByClusterUidAndTimeScheduleUid(IApplicationUserSessionDataHeader sessionData, Guid clusterUid, Guid timeScheduleUid);
        int GetLowestAvailablePanelTimeScheduleNumber(Guid clusterUid);
        bool CanTimeScheduleBeUnmappedFromCluster(Guid timeScheduledUid, Guid clusterUid);
        TimeScheduleUsageData GetTimeScheduleUsageData(Guid timeScheduledUid, Guid clusterUid);
    }
}

