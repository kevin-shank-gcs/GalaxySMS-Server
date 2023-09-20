using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class LoggingStatusReply : PanelMessageBase
	{
		public LoggingStatusReply(){}

        public LoggingStatusReply(PanelMessageBase b):base(b)
        { }
		public LoggingStatusReply(LoggingStatusReply o)
			: base(o)
		{
			if (o != null)
			{
				EnabledState = o.EnabledState;
				UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
				BufferedActivityLogCount = o.BufferedActivityLogCount;
			}
		}

		[DataMember]
		public ActivityLoggingEnabledState EnabledState { get; set; }

		[DataMember]
		public UInt32 UnacknowledgedActivityLogCount { get; set; }

		[DataMember]
		public UInt32 BufferedActivityLogCount { get; set; }
	}
}
