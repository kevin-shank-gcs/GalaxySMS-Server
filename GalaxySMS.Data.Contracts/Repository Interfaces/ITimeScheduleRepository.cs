using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimeScheduleRepository : IPagedDataRepository<TimeSchedule>, IHasGetEntityId
    {
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForGalaxyCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForAssaAbloyDsr(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<TimeSchedule> GetAllTimeSchedulesForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        TimeSchedule_PanelLoadData GetTimeSchedulePanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<TimeSchedule_PanelLoadData> parameters);
        IEnumerable<TimeScheduleSelectionItemBasic> GetAllTimeScheduleSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        bool IsTimeScheduleActive(Guid timeScheduleUid, GalaxySMS.Common.Enums.TimeScheduleType scheduleTypeCode, Guid clusterId, DateTimeOffset dateTime);

        IArrayResponse<TimeScheduleClusterItem> GetTimeScheduleClusterItems(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        bool GetAutoMapTimeSchedulesForEntity(Guid entityId);
        bool IsTimeScheduleMappedToCluster(Guid timeScheduleUid, Guid clusterUid);
        IEnumerable<Guid> GetUidsForCluster(Guid clusterUid);
        TimeScheduleUsageCounts GetTimeScheduleUsageCounts(Guid timeScheduleUid, Guid clusterUid);
        bool CanTimeScheduleBeDeleted(Guid timeScheduledUid);
        TimeScheduleUsageData GetTimeScheduleUsageData(Guid timeScheduledUid);
    };
}

