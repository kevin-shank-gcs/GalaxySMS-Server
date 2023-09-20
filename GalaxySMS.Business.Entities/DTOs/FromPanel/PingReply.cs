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

        [DataMember]
        public YesNo Response { get; set; }
    }
}
