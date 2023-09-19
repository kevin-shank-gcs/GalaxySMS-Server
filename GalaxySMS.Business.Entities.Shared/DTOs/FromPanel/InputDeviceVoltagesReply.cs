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

    public class InputDeviceVoltagesReply : PanelMessageBase
    {
        public InputDeviceVoltagesReply()
        {
        }

        public InputDeviceVoltagesReply(PanelMessageBase b)
            : base(b)
        {
        }

        public InputDeviceVoltagesReply(InputDeviceVoltagesReply o)
            : base(o)
        {
            if (o != null)
            {
                InputDeviceUid = o.InputDeviceUid;
                NormalVoltage = o.NormalVoltage;
                AlternateVoltage = o.AlternateVoltage;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort NormalVoltage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort AlternateVoltage { get; set; }
    }
}
