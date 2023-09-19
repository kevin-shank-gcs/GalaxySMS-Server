

using System;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class TimeSchedule15MinuteFormat_GetPanelLoadData : ObjectBase
    {
        #region Public Variables
        public Guid TimeScheduleUid { get; set; }
        public string ScheduleName { get; set; }
        public string DayTypeName { get; set; }
 //       public short DayTypeCode { get; set; }
        public DayTypeCode DayTypeCode { get; set; }
        public int PanelScheduleNumber { get; set; }
        public bool? FifteenMinuteFormatUsesHolidays { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public Guid ClusterUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterName { get; set; }
//        public short ScheduleTypeCode { get; set; }
        public Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }

        public string ScheduleTypeDisplay { get; set; }
        public int RETURNVALUE { get; set; }
        #endregion

    }
}
