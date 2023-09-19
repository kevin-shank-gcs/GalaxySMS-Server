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

    public class CredentialCommandReply : PanelMessageBase
    {
        public CredentialCommandReply()
        {
        }

        public CredentialCommandReply(PanelMessageBase o): base(o)
        {
        }


        public CredentialCommandReply(CredentialCommandReply o)
        {
            if (o != null)
            {
                CardData = o.CardData;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardData { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class CredentialCommandReplySignalR : PanelMessageBaseSimple
    {
        public CredentialCommandReplySignalR()
        {
        }


        public CredentialCommandReplySignalR(CredentialCommandReply o) : base(o)
        {
            if (o != null)
            {
                CardData = o.CardData;
            }
        }

        public CredentialCommandReplySignalR(PanelMessageBaseSimple o) : base(o)
        {

        }

        public CredentialCommandReplySignalR(CredentialCommandReplySignalR o) : base(o)
        {
            if (o != null)
            {
                CardData = o.CardData;
            }
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardData { get; set; }
    }

}
