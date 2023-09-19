using GalaxySMS.Common.Enums;
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

    public class PingReply : PanelMessageBase
    {
        public PingReply() : base() { }
        public PingReply(PanelMessageBase b)
            : base(b)
        {
        }

        public PingReply(PingReply o)
            : base(o)
        {
            if (o != null)
                Response = o.Response;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo Response { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class PingReplySignalR : PanelMessageBaseSimple
    {
        public PingReplySignalR() : base() { }
        public PingReplySignalR(PanelMessageBaseSimple b)
            : base(b)
        {
        }

        public PingReplySignalR(PingReplySignalR o)
            : base(o)
        {
        }
    }

}
