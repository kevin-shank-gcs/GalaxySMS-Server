using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

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

    public class FifteenMinuteTimeSchedule : EntityBase
    {
        public enum Days
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            HolidayType1,
            HolidayType2,
            HolidayType3,
            HolidayType4,
            HolidayType5,
            HolidayType6,
            HolidayType7,
            HolidayType8,
            HolidayType9,
        }
        public FifteenMinuteTimeSchedule()
        {
            DailySchedules = new Dictionary<Days, FifteenMinuteTimeScheduleDay>();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort ScheduleNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Dictionary<Days,FifteenMinuteTimeScheduleDay> DailySchedules { get; set; }

    }
}
