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
	public class ActivityLoggingInformation : EntityBase
	{
		[DataMember]
		public UInt32 ActivityLogNotAcknowledgedCount { get; set; }

		[DataMember]
		public UInt32 ActivityLogBufferCount { get; set; }

		[DataMember]
		public ActivityLoggingEnabledState ActivityLoggingEnabledState { get; set; }

	}
}
