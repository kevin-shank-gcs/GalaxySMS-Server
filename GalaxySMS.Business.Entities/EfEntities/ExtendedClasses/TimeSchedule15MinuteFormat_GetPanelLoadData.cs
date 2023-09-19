using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class TimeSchedule15MinuteFormat_GetPanelLoadData
    {
        public TimeSchedule15MinuteFormat_GetPanelLoadData()
        {
            Initialize();
        }

        public TimeSchedule15MinuteFormat_GetPanelLoadData(TimeSchedule15MinuteFormat_GetPanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(TimeSchedule15MinuteFormat_GetPanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.TimeScheduleUid = e.TimeScheduleUid;
            this.ScheduleName = e.ScheduleName;
            this.DayTypeName = e.DayTypeName;
            this.DayTypeCode = e.DayTypeCode;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
            this.FifteenMinuteFormatUsesHolidays = e.FifteenMinuteFormatUsesHolidays;
            this.StartTime = e.StartTime;
            this.EndTime = e.EndTime;
            this.EntityName = e.EntityName;
            this.EntityId = e.EntityId;
            this.ClusterUid = e.ClusterUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.ScheduleTypeCode = e.ScheduleTypeCode;
            this.ScheduleTypeDisplay = e.ScheduleTypeDisplay;
            this.RETURNVALUE = e.RETURNVALUE;
        }

        public TimeSchedule15MinuteFormat_GetPanelLoadData Clone(TimeSchedule15MinuteFormat_GetPanelLoadData e)
        {
            return new TimeSchedule15MinuteFormat_GetPanelLoadData(e);
        }

        public bool Equals(TimeSchedule15MinuteFormat_GetPanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeSchedule15MinuteFormat_GetPanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleUid != this.TimeScheduleUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
