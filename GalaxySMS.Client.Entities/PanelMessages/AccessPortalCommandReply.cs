
using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
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

        [DataMember]
        public Guid AccessPortalUid { get; set; }

    }
}