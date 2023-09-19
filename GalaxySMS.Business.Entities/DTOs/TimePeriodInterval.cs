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
    public class TimePeriodInterval : EntityBase
	{
		public TimePeriodInterval()
		{
            StartTime = DateTimeOffset.MinValue;
            EndTime = DateTimeOffset.MinValue;
        }

	    public TimePeriodInterval(TimeSpan start, TimeSpan end)
	    {
	        var now = DateTimeOffset.Now;
	        StartTime = new DateTimeOffset(now.Year, now.Month, now.Day, start.Hours, start.Minutes, 0);
	        EndTime = new DateTimeOffset(now.Year, now.Month, now.Day, end.Hours, end.Minutes, 0);
        }

        [DataMember]
        public DateTimeOffset StartTime { get; set; }

        [DataMember]
        public DateTimeOffset EndTime { get; set; }
	}
}
