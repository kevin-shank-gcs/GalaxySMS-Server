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

    public class GalaxyCpuCommandReply : PanelMessageBase
    {
        public GalaxyCpuCommandReply()
        {
            Command = GalaxyCpuCommandActionCode.None;
        }

        public GalaxyCpuCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = GalaxyCpuCommandActionCode.None;
        }

        public GalaxyCpuCommandReply(GalaxyCpuCommandReply o)
            : base(o)
        {
            if (o != null)
            {
                this.Command = o.Command;
                this.CredentialUid = o.CredentialUid;
                this.CredentialBytes = o.CredentialBytes;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyCpuCommandActionCode Command { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CredentialBytes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }
    }
}
