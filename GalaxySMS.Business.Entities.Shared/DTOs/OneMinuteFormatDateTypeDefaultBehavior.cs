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

    public class OneMinuteFormatDateTypeDefaultBehavior : EntityBase
	{
        public enum DefaultBehaviorCodes { Unspecified, UseDayOfWeek, UseWeekdayWeekend}

        public OneMinuteFormatDateTypeDefaultBehavior()
		{
		    DefaultBehavior = DefaultBehaviorCodes.Unspecified;
            SundayDefaultType = DayTypeCode.Sunday;
		    MondayDefaultType = DayTypeCode.Monday;
		    TuesdayDefaultType = DayTypeCode.Tuesday;
		    WednesdayDefaultType = DayTypeCode.Wednesday;
		    ThursdayDefaultType = DayTypeCode.Thursday;
		    FridayDefaultType = DayTypeCode.Friday;
		    SaturdayDefaultType = DayTypeCode.Saturday;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DefaultBehaviorCodes DefaultBehavior { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode SundayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode MondayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode TuesdayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode WednesdayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode ThursdayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode FridayDefaultType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DayTypeCode SaturdayDefaultType { get; set; }

    }
}
