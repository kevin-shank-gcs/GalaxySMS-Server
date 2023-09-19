using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public partial class AccessPortal_GetAlertEventAcknowledgeData
    {
        [DataMember]
        public Guid AccessPortalUid {get;set; }
        [DataMember]
        public Guid AccessPortalAlertEventTypeUid {get;set; }
        [DataMember]
        public string Tag {get;set; }
        [DataMember]
        public bool CanHaveAudio {get;set; }
        [DataMember]
        public bool CanHaveInstructions {get;set; }
        [DataMember]
        public bool CanHaveSchedule {get;set; }
        [DataMember]
        public Guid AcknowledgeTimeScheduleUid {get;set; }
        [DataMember]
        public int AcknowledgePriority {get;set; }
        [DataMember]
        public string ResponseInstructions {get;set; }
        [DataMember]
        public Guid ResponseInstructionsUid {get;set; }
        [DataMember]
        public Guid AudioBinaryResourceUid {get;set; }
        [DataMember]
        public Guid GalaxyPanelUid {get;set; }
        [DataMember]
        public Guid ClusterUid {get;set; }
        [DataMember]
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode {get;set;}
    }

    [DataContract]
    public class AccessPortalListItem : DeviceListItemBase
    {
        public AccessPortalListItem()
        {
            AlertEventAcknowledgeData = new List<AccessPortal_GetAlertEventAcknowledgeData>();
        }
        [DataMember]
        public List<AccessPortal_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData {get;set;}
        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }
    }
}
