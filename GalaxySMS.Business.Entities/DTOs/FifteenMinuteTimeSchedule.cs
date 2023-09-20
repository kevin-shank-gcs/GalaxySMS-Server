using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
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

        [DataMember]
        public ushort ScheduleNumber { get; set; }

        [DataMember]
        public Dictionary<Days,FifteenMinuteTimeScheduleDay> DailySchedules { get; set; }

    }
}
