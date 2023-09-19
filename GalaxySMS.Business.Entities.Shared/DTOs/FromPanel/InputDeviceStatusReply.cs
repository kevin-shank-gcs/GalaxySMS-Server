using GalaxySMS.Common.Enums;
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

    public class InputDeviceStatusReply : PanelMessageBase
    {
        public InputDeviceStatusReply()
        {
        }

        public InputDeviceStatusReply(PanelMessageBase b)
            : base(b)
        {
        }

        public InputDeviceStatusReply(InputDeviceStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                InputDeviceUid = o.InputDeviceUid;
                //AccessPortalStatus = o.AccessPortalStatus;
                ContactStatus = o.ContactStatus;
                ArmedStatus = o.ArmedStatus;
                MonitoringStatus = o.MonitoringStatus;
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
        public InputDeviceContactStatus ContactStatus { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputDeviceIoGroupArmedStatus ArmedStatus { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public InputDeviceIoGroupArmedManuallyStatus ArmedManuallyStatus { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputDeviceMonitoringStatus MonitoringStatus { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CircuitBoardStatus BoardStatus { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IoGroupIsLocal { get; set; }
    }
}
