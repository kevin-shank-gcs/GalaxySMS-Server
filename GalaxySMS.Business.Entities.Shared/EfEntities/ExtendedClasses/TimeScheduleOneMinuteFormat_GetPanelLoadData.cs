using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class TimeScheduleOneMinuteFormat_GetPanelLoadData
    {
        public TimeScheduleOneMinuteFormat_GetPanelLoadData()
        {
            Initialize();
        }

        public TimeScheduleOneMinuteFormat_GetPanelLoadData(TimeScheduleOneMinuteFormat_GetPanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(TimeScheduleOneMinuteFormat_GetPanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.TimeScheduleUid = e.TimeScheduleUid;
            this.ScheduleName = e.ScheduleName;
            this.DayTypeName = e.DayTypeName;
            this.DayTypeCode = e.DayTypeCode;
            this.PanelScheduleNumber = e.PanelScheduleNumber;
            this.PanelTimePeriodNumber = e.PanelTimePeriodNumber;
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

        public TimeScheduleOneMinuteFormat_GetPanelLoadData Clone(TimeScheduleOneMinuteFormat_GetPanelLoadData e)
        {
            return new TimeScheduleOneMinuteFormat_GetPanelLoadData(e);
        }

        public bool Equals(TimeScheduleOneMinuteFormat_GetPanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(TimeScheduleOneMinuteFormat_GetPanelLoadData other)
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
