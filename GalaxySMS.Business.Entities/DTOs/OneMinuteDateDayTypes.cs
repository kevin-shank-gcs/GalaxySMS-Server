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
    public class OneMinuteDateDayTypes : EntityBase
	{
		public OneMinuteDateDayTypes()
		{
		    DateDayTypes = new Dictionary<DateTimeOffset, short>();
        }

	    [DataMember]
	    public Dictionary<DateTimeOffset, short> DateDayTypes { get; set; }
	}
}
