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
    public class FifteenMinuteTimePeriodInterval : EntityBase
	{
		public FifteenMinuteTimePeriodInterval()
		{
            StartTime = DateTimeOffset.Now;
            Duration = new TimeSpan(0);
        }

        [DataMember]
        public DateTimeOffset StartTime { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }
	}
}
