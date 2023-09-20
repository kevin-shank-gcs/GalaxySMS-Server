using System;
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

    public class InputOutputGroupCommandReply : PanelMessageBase
    {
        public enum CommandCode { None, Arm, Disarm, Shunt, Unshunt }
        public InputOutputGroupCommandReply()
        {
            Command = CommandCode.None;
            InputOutputGroupNumber = 0;
        }

        public InputOutputGroupCommandReply(PanelMessageBase b)
            : base(b)
        {
            Command = CommandCode.None;
            InputOutputGroupNumber = b.RawData[2];
        }

        public InputOutputGroupCommandReply(InputOutputGroupCommandReply o)
            : base(o)
        {
            if (o != null)
            {
                this.Command = o.Command;
                InputOutputGroupNumber = o.InputOutputGroupNumber;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CommandCode Command { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 InputOutputGroupNumber { get; set; }
    }
}
