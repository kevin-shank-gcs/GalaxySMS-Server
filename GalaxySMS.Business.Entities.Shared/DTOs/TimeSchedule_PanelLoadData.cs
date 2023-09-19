using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
    [DataContract]
#endif
	public class TimeSchedule_PanelLoadData
    {
        public TimeSchedule_PanelLoadData()
        {
            TimeSchedule15MinuteFormatGetPanelLoadData = new List<TimeSchedule15MinuteFormat_GetPanelLoadData>();
            TimeScheduleOneMinuteFormatGetPanelLoadData = new List<TimeScheduleOneMinuteFormat_GetPanelLoadData>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<TimeSchedule15MinuteFormat_GetPanelLoadData> TimeSchedule15MinuteFormatGetPanelLoadData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<TimeScheduleOneMinuteFormat_GetPanelLoadData> TimeScheduleOneMinuteFormatGetPanelLoadData { get; set; }

    }
}
