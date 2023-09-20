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
    public class HolidayDates : EntityBase
	{
		public HolidayDates()
		{
            Dates = new List<DateTimeOffset>();
        }

        [DataMember]
        public List<DateTimeOffset> Dates { get; set; }
	}
}
