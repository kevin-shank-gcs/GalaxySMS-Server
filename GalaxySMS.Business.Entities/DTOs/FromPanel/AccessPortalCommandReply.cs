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

        [DataMember]
        public AccessPortalCommandActionCode Command { get; set; }
    }
}
