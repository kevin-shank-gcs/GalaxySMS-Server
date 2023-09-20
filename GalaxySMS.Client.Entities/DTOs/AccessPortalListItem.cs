////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessPortalListItem.cs
//
// summary:	Implements the access portal list item class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using System.Collections.ObjectModel;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public partial class AccessPortal_GetAlertEventAcknowledgeData
    {
        [DataMember]
        public Guid AccessPortalUid { get; set; }
        [DataMember]
        public Guid AccessPortalAlertEventTypeUid { get; set; }
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public bool CanHaveAudio { get; set; }
        [DataMember]
        public bool CanHaveInstructions { get; set; }
        [DataMember]
        public bool CanHaveSchedule { get; set; }
        [DataMember]
        public Guid AcknowledgeTimeScheduleUid { get; set; }
        [DataMember]
        public int AcknowledgePriority { get; set; }
        [DataMember] 
        public bool IsActive { get; set; }

        [DataMember]
        public string ResponseInstructions { get; set; }
        [DataMember]
        public Guid ResponseInstructionsUid { get; set; }
        [DataMember]
        public Guid AudioBinaryResourceUid { get; set; }
        [DataMember]
        public Guid GalaxyPanelUid { get; set; }
        [DataMember]
        public Guid ClusterUid {get;set; }

        [DataMember]
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode {get;set; }
        [DataMember]
        public bool ResponseRequired { get; set; }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal list item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPortalListItem : DeviceListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalListItem()
        {
            AlertEventAcknowledgeData = new List<AccessPortal_GetAlertEventAcknowledgeData>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the alert event acknowledge. </summary>
        ///
        /// <value> Information describing the alert event acknowledge. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public List<AccessPortal_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique hardware. </summary>
        ///
        /// <value> The identifier of the unique hardware. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }

        
        public AccessPortal_GetAlertEventAcknowledgeData GetAlertEventAcknowledgeData(PanelActivityEventCode eventType)
        {
            switch (eventType)
            {
                case PanelActivityEventCode.DoorForcedOpen:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen);

                case PanelActivityEventCode.DoorLeftOpen:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.OpenTooLong);

                case PanelActivityEventCode.AccessDenied:
                case PanelActivityEventCode.AccessDeniedAttemptPivCardExpired:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.InvalidAccessAttempt);

                case PanelActivityEventCode.PassbackViolation:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.PassbackViolation);

                case PanelActivityEventCode.DuressAuxiliaryFunction:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DuressAuxiliaryFunction);

                case PanelActivityEventCode.DoorHeartbeartAlarm:
                case PanelActivityEventCode.ReaderHeartbeatStopped:
                case PanelActivityEventCode.ReaderTamperAlarm:
                case PanelActivityEventCode.DoorModuleAdapterTamperAlarm:
                    return AlertEventAcknowledgeData?.FirstOrDefault(o=>o.AccessPortalAlertEventTypeUid == GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ReaderHeartbeat);
            }
            
            return null;
        }


    }

    [DataContract]
    public class AccessPortalListItemCommands : ListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalListItemCommands()
        {
            Commands = new List<AccessPortalCommand>();
        }


        [DataMember]
        public List<AccessPortalCommand> Commands { get; set; }


        /// <summary>   The command menu. </summary>
        private ObservableCollection<MenuItem> _commandMenu;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command menu. </summary>
        ///
        /// <value> The command menu. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<MenuItem> CommandMenu
        {
            get { return _commandMenu; }
            set
            {
                if (_commandMenu != value)
                {
                    _commandMenu = value;
                }
            }
        }

        [DataMember]
        public bool IsBoundToHardware { get; set; }
    }


}
