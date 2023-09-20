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

    public class AccessPortalGroupCommandReply : PanelMessageBase
    {
        public AccessPortalGroupCommandReply()
        {
            Command = AccessPortalGroupCommandActionCode.None;
        }

        public AccessPortalGroupCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = AccessPortalGroupCommandActionCode.None;
        }

        public AccessPortalGroupCommandReply(AccessPortalGroupCommandReply o)
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
        public AccessPortalGroupCommandActionCode Command { get; set; }
    }
}
