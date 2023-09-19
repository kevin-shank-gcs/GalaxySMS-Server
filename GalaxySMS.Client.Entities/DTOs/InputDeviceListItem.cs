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

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public partial class InputDevice_GetAlertEventAcknowledgeData
    {
        [DataMember]
        public Guid InputDeviceUid { get; set; }
        [DataMember]
        public Guid InputDeviceAlertEventTypeUid { get; set; }
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

        [DataMember] public bool ResponseRequired { get; set; }

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
        public Guid ClusterUid { get; set; }

        [DataMember]
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal list item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InputDeviceListItem : DeviceListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceListItem()
        {
            AlertEventAcknowledgeData = new List<InputDevice_GetAlertEventAcknowledgeData>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the alert event acknowledge. </summary>
        ///
        /// <value> Information describing the alert event acknowledge. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public List<InputDevice_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique hardware. </summary>
        ///
        /// <value> The identifier of the unique hardware. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.InputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, ModuleNumber, NodeNumber); } }

        
        public InputDevice_GetAlertEventAcknowledgeData GetAlertEventAcknowledgeData(PanelActivityEventCode eventType)
        {
            if( eventType == PanelActivityEventCode.PointAlarmArmed)
                return AlertEventAcknowledgeData.FirstOrDefault();
            return null;
        }

        [DataMember]
        public bool IsBoundToHardware { get; set; }

    }

    [DataContract]
    public class InputDeviceListItemCommands : ListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceListItemCommands()
        {
            Commands = new List<InputCommand>();
        }


        [DataMember]
        public List<InputCommand> Commands { get; set; }


        [DataMember]
        public bool IsBoundToHardware { get; set; }

    }


}
