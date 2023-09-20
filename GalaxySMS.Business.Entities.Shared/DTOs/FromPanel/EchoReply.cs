using System;
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

    public class EchoReply : PanelMessageBase
    {
        public EchoReply() : base() { }
        public EchoReply(PanelMessageBase b)
            : base(b)
        {
        }

        public EchoReply(EchoReply o)
            : base(o)
        {
            if (o != null)
                Response = o.Response;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String Response { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class EchoReplySignalR : PanelMessageBaseSimple
    {
        public EchoReplySignalR() : base() { }
        public EchoReplySignalR(PanelMessageBaseSimple b)
            : base(b)
        {
        }

        public EchoReplySignalR(EchoReplySignalR o)
            : base(o)
        {
        }
    }

}
