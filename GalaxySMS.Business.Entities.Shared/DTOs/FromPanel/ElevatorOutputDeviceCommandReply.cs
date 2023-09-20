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
#if NetCoreApi
#else
        [DataMember]
#endif
        public CommandCode Command { get; set; }
    }
}
