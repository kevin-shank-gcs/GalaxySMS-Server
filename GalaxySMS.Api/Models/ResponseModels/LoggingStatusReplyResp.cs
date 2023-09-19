using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
	public class LoggingStatusReplyResp : PanelMessageBaseResp
	{
		public LoggingStatusReplyResp(){}

        public LoggingStatusReplyResp(PanelMessageBaseResp b):base(b)
        { }
		public LoggingStatusReplyResp(LoggingStatusReplyResp o)
			: base(o)
		{
			if (o != null)
			{
				EnabledState = o.EnabledState;
				UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
				BufferedActivityLogCount = o.BufferedActivityLogCount;
			}
		}
        public ActivityLoggingEnabledState EnabledState { get; set; }
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
        public UInt32 BufferedActivityLogCount { get; set; }
	}

    public class LoggingStatusReplyBasicResp
    {
        public LoggingStatusReplyBasicResp(){}

        public LoggingStatusReplyBasicResp(LoggingStatusReplyResp o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }

        public LoggingStatusReplyBasicResp(LoggingStatusReplyBasicResp o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }

        public ActivityLoggingEnabledState EnabledState { get; set; }
        public string EnabledStateFriendly => EnabledState.ToString();
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
        public UInt32 BufferedActivityLogCount { get; set; }
    }
}
