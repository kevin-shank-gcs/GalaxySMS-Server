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
        [DataMember]
        public DefaultBehaviorCodes DefaultBehavior { get; set; }
        [DataMember]
	    public DayTypeCode SundayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode MondayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode TuesdayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode WednesdayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode ThursdayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode FridayDefaultType { get; set; }
	    [DataMember]
	    public DayTypeCode SaturdayDefaultType { get; set; }

    }
}
