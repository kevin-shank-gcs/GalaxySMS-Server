using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Constants;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

    public partial class InputDevice_GetAlertEventAcknowledgeData
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceAlertEventTypeUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveAudio { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveInstructions { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanHaveSchedule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AcknowledgeTimeScheduleUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AcknowledgePriority { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ResponseInstructions { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ResponseInstructionsUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AudioBinaryResourceUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class InputDeviceListItem : DeviceListItemBase
    {
        public InputDeviceListItem()
        {
            AlertEventAcknowledgeData = new List<InputDevice_GetAlertEventAcknowledgeData>();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<InputDevice_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData {get;set;}
        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.InputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsBoundToHardware { get; set; }

    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class InputDeviceListItemCommands : ListItemBase
    {
        public InputDeviceListItemCommands()
        {
            Commands = new List<InputCommandBasic>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public List<InputCommandBasic> Commands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsBoundToHardware { get; set; }
    }


}
