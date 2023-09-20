using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class OutputDeviceCommandReply : PanelMessageBase
    {
        public enum CommandCode { None, On, Off, Enable, Disable, RequestStatus }
        public OutputDeviceCommandReply()
        {
            Command = CommandCode.None;
        }

        public OutputDeviceCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = CommandCode.None;
        }

        public OutputDeviceCommandReply(OutputDeviceCommandReply o)
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
