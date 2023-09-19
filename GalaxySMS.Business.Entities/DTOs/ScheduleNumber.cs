using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	public enum SystemSchedule { Never = 0, Always = 255}

	[DataContract]
    public class ScheduleNumber : EntityBase
	{
		private Int32 scheduleNumber;

		public enum ScheduleNumberLimits { MinimumScheduleNumber = 0, MaximumScheduleNumber = 255 }
		
		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", Number); } }

		[DataMember]
		public Int32 Number
		{
			get { return scheduleNumber; }
			set
			{
				if (value >= (Int32)ScheduleNumberLimits.MinimumScheduleNumber && value <= (Int32)ScheduleNumberLimits.MaximumScheduleNumber)
					scheduleNumber = value;
				else
					throw new ArgumentOutOfRangeException("ScheduleNumber.Number", value, string.Format("The ScheduleNumber.Number value must be between {0} and {1}",
						ScheduleNumberLimits.MinimumScheduleNumber, ScheduleNumberLimits.MaximumScheduleNumber));
			}
		}
		
		public override string ToString()
		{
			return UniqueId;
		}
	}
}
