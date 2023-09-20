using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
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
    public partial class AccessPortal_GetAlertEventAcknowledgeData
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalAlertEventTypeUid { get; set; }
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
        public bool IsActive { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessPortalListItem : DeviceListItemBase
    {
        public AccessPortalListItem()
        {
            AlertEventAcknowledgeData = new List<AccessPortal_GetAlertEventAcknowledgeData>();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<AccessPortal_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData { get; set; }
        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessPortalListItemCommands : ListItemBase
    {
        public AccessPortalListItemCommands()
        {
            //Commands = new List<AccessPortalCommandBasic>();
            DisabledCommandIds = new List<Guid>();
        }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public List<AccessPortalCommandBasic> Commands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> DisabledCommandIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalLastUsageData LastUsageData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsBoundToHardware { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }
    }

}
