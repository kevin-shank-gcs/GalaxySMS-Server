using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

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

    public class LoggingStatusReply : PanelMessageBase
    {
        public LoggingStatusReply() { }

        public LoggingStatusReply(PanelMessageBase b) : base(b)
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState EnabledState { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 BufferedActivityLogCount { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif

    public class LoggingStatusReplyBasic
    {
        public LoggingStatusReplyBasic() { }

        public LoggingStatusReplyBasic(LoggingStatusReply o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }

        public LoggingStatusReplyBasic(LoggingStatusReplyBasic o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState EnabledState { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 BufferedActivityLogCount { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class LoggingStatusReplySignalR : PanelMessageBaseSimple
    {
        public LoggingStatusReplySignalR() { }

        public LoggingStatusReplySignalR(PanelMessageBase b) : base(b)
        { }
        public LoggingStatusReplySignalR(LoggingStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                EnabledState = o.EnabledState;
                UnacknowledgedActivityLogCount = o.UnacknowledgedActivityLogCount;
                BufferedActivityLogCount = o.BufferedActivityLogCount;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState EnabledState { get; set; }

        public string EnabledStateCode => EnabledState.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 BufferedActivityLogCount { get; set; }
    }


}
