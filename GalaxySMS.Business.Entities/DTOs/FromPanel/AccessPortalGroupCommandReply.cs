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

        [DataMember]
        public AccessPortalGroupCommandActionCode Command { get; set; }
    }
}
