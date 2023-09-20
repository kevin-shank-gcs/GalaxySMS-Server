using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class ReaderRelayTwoSettings : EntityBase
	{
		public enum BehaviorMode {None = 0, Follow, Timeout, Schedule, Latching }
	
		public ReaderRelayTwoSettings()
		{
			ScheduleNumber = new ScheduleNumber();
		}

		[DataMember]
		public BehaviorMode Mode { get; set; }

		[DataMember]
		public UInt16 ActivationDelay { get; set; }	// In hundredths of seconds
		
		[DataMember]
		public UInt16 EnergizeDuration { get; set; }	// In hundredths of seconds

		[DataMember]
		public ScheduleNumber ScheduleNumber { get; set; }

		[DataMember]
		public YesNo TriggerOnIllegalOpen { get; set; }

		[DataMember]
		public YesNo TriggerOnOpenTooLong { get; set; }

		[DataMember]
		public YesNo TriggerOnInvalidAccessAttempt { get; set; }

		[DataMember]
		public YesNo TriggerOnPassbackViolation { get; set; }

		[DataMember]
		public YesNo TriggerOnValidAccess { get; set; }

		[DataMember]
		public YesNo TriggerOnDuress { get; set; }
	}
}
