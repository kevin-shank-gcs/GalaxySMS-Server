using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class InputOutputGroupCommandReply : PanelMessageBase
    {
        public enum CommandCode { None, Arm, Disarm, Shunt, Unshunt }
        public InputOutputGroupCommandReply()
        {
            Command = CommandCode.None;
        }

        public InputOutputGroupCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = CommandCode.None;
        }

        public InputOutputGroupCommandReply(InputOutputGroupCommandReply o)
            : base(o)
        {
            if (o != null)
            {
                this.Command = o.Command;
            }
        }

        [DataMember]
        public CommandCode Command { get; set; }
    }
}
