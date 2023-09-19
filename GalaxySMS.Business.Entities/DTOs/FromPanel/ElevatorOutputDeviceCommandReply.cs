using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class ElevatorOutputDeviceCommandReply : PanelMessageBase
    {
        public enum CommandCode { None, Pulse, EarlyOn, EarlyOff, CancelEarlyOn, CancelEarlyOff }
        public ElevatorOutputDeviceCommandReply()
        {
            Command = CommandCode.None;
        }

        public ElevatorOutputDeviceCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = CommandCode.None;
        }

        public ElevatorOutputDeviceCommandReply(ElevatorOutputDeviceCommandReply o)
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
