using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

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

    public class ReaderRelayTwoSettings : EntityBase
	{
		public enum BehaviorMode {None = 0, Follow, Timeout, Schedule, Latching }
	
		public ReaderRelayTwoSettings()
		{
			ScheduleNumber = new ScheduleNumber();
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public BehaviorMode Mode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 ActivationDelay { get; set; }	// In hundredths of seconds
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 EnergizeDuration { get; set; }	// In hundredths of seconds
#if NetCoreApi
#else
        [DataMember]
#endif
        public ScheduleNumber ScheduleNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnIllegalOpen { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnOpenTooLong { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnInvalidAccessAttempt { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnPassbackViolation { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnValidAccess { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TriggerOnDuress { get; set; }
	}
}
