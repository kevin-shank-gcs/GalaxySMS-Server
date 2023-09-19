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
    public class FifteenMinuteTimeScheduleDay : EntityBase
	{
		public FifteenMinuteTimeScheduleDay()
		{
		    Intervals = new List<FifteenMinuteTimePeriodInterval>();
        }

        [DataMember]
        public List<FifteenMinuteTimePeriodInterval> Intervals { get; set; }
	}
}
