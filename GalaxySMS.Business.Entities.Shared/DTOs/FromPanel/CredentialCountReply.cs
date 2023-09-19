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

    public class CredentialCountReply : PanelMessageBase
    {
        public CredentialCountReply()
        {
        }

        public CredentialCountReply(PanelMessageBase b)
            : base(b)
        {
        }

        public CredentialCountReply(CredentialCountReply o)
            : base(o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 Value { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class CredentialCountReplyBasic
    {
        public CredentialCountReplyBasic()
        {
        }

        public CredentialCountReplyBasic(CredentialCountReply o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }

        public CredentialCountReplyBasic(CredentialCountReplyBasic o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 Value { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class CredentialCountReplySignalR : PanelMessageBaseSimple
    {
        public CredentialCountReplySignalR()
        {
        }

        public CredentialCountReplySignalR(CredentialCountReply o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }

        public CredentialCountReplySignalR(CredentialCountReplySignalR o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 Value { get; set; }
    }

}
