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

    public class AccessPortalCommandReply : PanelMessageBase
    {
        public AccessPortalCommandReply()
        {
            Command = AccessPortalCommandActionCode.None;
        }

        public AccessPortalCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = AccessPortalCommandActionCode.None;
        }

        public AccessPortalCommandReply(AccessPortalCommandReply o)
            : base(o)
        {
            if (o != null)
            {
                this.Command = o.Command;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalCommandActionCode Command { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }
    }
}
