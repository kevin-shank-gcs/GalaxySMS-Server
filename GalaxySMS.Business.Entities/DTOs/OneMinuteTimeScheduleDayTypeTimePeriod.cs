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
    public class OneMinuteTimeScheduleDayTypeTimePeriod : EntityBase
    {
        public OneMinuteTimeScheduleDayTypeTimePeriod()
        {
            DayTypeTimePeriods = new Dictionary<short, short>();
        }

        [DataMember]
        public ushort ScheduleNumber { get; set; }

        [DataMember]
        public Dictionary<short,short> DayTypeTimePeriods { get; set; }

    }
}
