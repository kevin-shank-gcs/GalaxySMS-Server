using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class TimeSchedule_PanelLoadData
    {
        public TimeSchedule_PanelLoadData()
        {
            TimeSchedule15MinuteFormatGetPanelLoadData = new List<TimeSchedule15MinuteFormat_GetPanelLoadData>();
            TimeScheduleOneMinuteFormatGetPanelLoadData = new List<TimeScheduleOneMinuteFormat_GetPanelLoadData>();
        }

        public Guid TimeScheduleUid { get; set; }
        public Guid ClusterUid { get; set; }
        public IEnumerable<TimeSchedule15MinuteFormat_GetPanelLoadData> TimeSchedule15MinuteFormatGetPanelLoadData { get; set; }
        public IEnumerable<TimeScheduleOneMinuteFormat_GetPanelLoadData> TimeScheduleOneMinuteFormatGetPanelLoadData { get; set; }

    }
}
