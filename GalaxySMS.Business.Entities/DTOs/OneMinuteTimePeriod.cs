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
    public class OneMinuteTimePeriod : EntityBase
	{
		public OneMinuteTimePeriod()
		{
            TimePeriodNumber = 0;
		    TimeIntervals = new List<OneMinuteTimePeriodInterval>();
         }

	    [DataMember]
	    public ushort TimePeriodNumber { get; set; }

	    [DataMember]
	    public List<OneMinuteTimePeriodInterval> TimeIntervals { get; set; }
	}
}
