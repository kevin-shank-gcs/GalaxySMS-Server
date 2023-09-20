using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class InputDeviceCommandReply : PanelMessageBase
    {
        public enum CommandCode { None, Enable, Disable, Shunt, Unshunt, RequestStatus }
        public InputDeviceCommandReply()
        {
            Command = CommandCode.None;
        }

        public InputDeviceCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = CommandCode.None;
        }

        public InputDeviceCommandReply(InputDeviceCommandReply o)
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
