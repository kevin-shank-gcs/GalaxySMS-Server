////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\PanelActivityLogMessageBase.cs
//
// summary:	Implements the panel activity log message base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel activity log message base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PanelActivityLogMessageBase : ObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelActivityLogMessageBase()
        {
            //UniqueUid = GuidUtilities.GenerateComb();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="msg">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelActivityLogMessageBase(PanelActivityLogMessageBase msg)
        {
            ActivityEventUid = msg.ActivityEventUid;
            ClusterGroupId = msg.ClusterGroupId;
            ClusterNumber = msg.ClusterNumber;
            ClusterUid = msg.ClusterUid;
            PanelNumber = msg.PanelNumber;
            CpuId = msg.CpuId;
            BoardNumber = msg.BoardNumber;
            SectionNumber = msg.SectionNumber;
            NodeNumber = msg.NodeNumber;
            CpuModel = msg.CpuModel;
            DateTime = msg.DateTime;
            BufferIndex = msg.BufferIndex;
            PanelActivityType = msg.PanelActivityType;
            DeviceTypeCode = msg.DeviceTypeCode;
            InputOutputGroupNumber = msg.InputOutputGroupNumber;
            InputOutputGroupUid = msg.InputOutputGroupUid;
            InputOutputGroupName = msg.InputOutputGroupName;
            MultiFactorMode = msg.MultiFactorMode;
            DeviceDescription = msg.DeviceDescription;
            EventDescription = msg.EventDescription;
            DeviceEntityId = msg.DeviceEntityId;
            DeviceUid = msg.DeviceUid;
            CpuUid = msg.CpuUid;
            ClusterName = msg.ClusterName;
            RawData = msg.RawData;
            Color = msg.Color;
            ForeColorHex = msg.ForeColorHex;
            AccessPortalContactStatus = msg.AccessPortalContactStatus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID if the object. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ActivityEventUid { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterGroupId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster number. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel number. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PanelNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the CPU. </summary>
        ///
        /// <value> The identifier of the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short CpuId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board number. </summary>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int BoardNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section number. </summary>
        ///
        /// <value> The section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int SectionNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the node number. </summary>
        ///
        /// <value> The node number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int NodeNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU model. </summary>
        ///
        /// <value> The CPU model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public CpuModel CpuModel { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date time. </summary>
        ///
        /// <value> The date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
   //     public DateTimeOffset DateTimeOffset { get; set; }
        public DateTimeOffset DateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the zero-based index of the buffer. </summary>
        ///
        /// <value> The buffer index. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 BufferIndex { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the panel activity. </summary>
        ///
        /// <value> The type of the panel activity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelActivityEventCode PanelActivityType { get; set; }


        [DataMember]
        public DeviceType DeviceTypeCode { get; set; }

        public string DeviceType => DeviceTypeCode.ToString();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int16 InputOutputGroupNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the multi factor mode. </summary>
        ///
        /// <value> The multi factor mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPortalMultiFactorModeCode MultiFactorMode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the device. </summary>
        ///
        /// <value> Information describing the device. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string DeviceDescription { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the event. </summary>
        ///
        /// <value> Information describing the event. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EventDescription { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the input output group. </summary>
        ///
        /// <value> The name of the input output group. </value>
        ///=================================================================================================

        [DataMember]
        public string InputOutputGroupName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group UID. </summary>
        ///
        /// <value> The input output group UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid InputOutputGroupUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the device entity. </summary>
        ///
        /// <value> The identifier of the device entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid DeviceEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the device UID. </summary>
        ///
        /// <value> The device UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid DeviceUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CpuUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the cluster. </summary>
        ///
        /// <value> The name of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClusterName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this PanelActivityLogMessageBase is alarm event.
        /// </summary>
        ///
        /// <value> True if this PanelActivityLogMessageBase is alarm event, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsAlarmEvent { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the alarm priority. </summary>
        ///
        /// <value> The alarm priority. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int AlarmPriority { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the instructions. </summary>
        ///
        /// <value> The instructions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Instructions { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the raw. </summary>
        ///
        /// <value> Information describing the raw. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Byte[] RawData { get; set; }


        [DataMember]
        public int Color { get; set; }
        
        [DataMember]
        public string ForeColorHex { get; set; }

        [DataMember]
        public AccessPortalContactStatus AccessPortalContactStatus { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the category. </summary>
        ///
        /// <value> The category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelActivityEventCategory Category
        {
            get
            {
                switch (PanelActivityType)
                {
                    case PanelActivityEventCode.DoorForcedOpen:
                    case PanelActivityEventCode.DoorLeftOpen:
                    case PanelActivityEventCode.DoorClosed:
                    case PanelActivityEventCode.ReadError:
                    case PanelActivityEventCode.DoorContactShunted:
                    case PanelActivityEventCode.DoorRequestToExit:
                    case PanelActivityEventCode.DoorUnlockBySchedule:
                    case PanelActivityEventCode.DoorLockBySchedule:
                    case PanelActivityEventCode.DoorDelayedUnlock:
                    case PanelActivityEventCode.Relay2OffBySchedule:
                    case PanelActivityEventCode.Relay2OnBySchedule:
                    case PanelActivityEventCode.DoorContactTroubleOpenCircuit:
                    case PanelActivityEventCode.DoorContactTroubleShortCircuit:
                    case PanelActivityEventCode.DoorHeartbeartAlarm:
                    case PanelActivityEventCode.DoorHeartbeatRestored:
                    case PanelActivityEventCode.DoorContactTroubleCleared:
                    case PanelActivityEventCode.ReaderHeartbeatStopped:
                    case PanelActivityEventCode.ReaderHeartbeatStarted:
                    case PanelActivityEventCode.ReaderLowBattery:
                    case PanelActivityEventCode.ReaderBatteryFlat:
                    case PanelActivityEventCode.ReaderBatteryOk:
                    case PanelActivityEventCode.CredentialNotInPanelMemory:
                    case PanelActivityEventCode.CredentialNotInPanelMemoryReverse:
                    case PanelActivityEventCode.ReaderRadioInterferenceDetected:
                    case PanelActivityEventCode.ReaderRadioInterferenceCleared:
                    case PanelActivityEventCode.ReaderPrivacyModeEntered:
                    case PanelActivityEventCode.ReaderPrivacyModeExited:
                    case PanelActivityEventCode.ReaderOfficeModeEntered:
                    case PanelActivityEventCode.ReaderOfficeModeExited:
                    case PanelActivityEventCode.ReaderNdeMagnetAlertNeedsCalibrated:
                    case PanelActivityEventCode.ReaderNdeMagnetSafeCalibrated:
                    case PanelActivityEventCode.DoorContactChange:
                    case PanelActivityEventCode.VeridtReaderTamperAlarm:
                    case PanelActivityEventCode.VeridtReaderTamperSafe:
                    case PanelActivityEventCode.VeridtCardCertificateProblem:
                    case PanelActivityEventCode.VeridtReaderFactorModeSet:
                    case PanelActivityEventCode.ReaderTamperAlarm:
                    case PanelActivityEventCode.ReaderTamperRestored:
                    case PanelActivityEventCode.DoorModuleAdapterTamperAlarm:
                    case PanelActivityEventCode.DoorModuleAdapterTamperSafe:
                    case PanelActivityEventCode.CommandUnlockDoor:
                    case PanelActivityEventCode.CommandLockDoor:
                    case PanelActivityEventCode.CommandDisableDoor:
                    case PanelActivityEventCode.CommandEnableDoor:
                    case PanelActivityEventCode.CommandPulseDoor:
                    case PanelActivityEventCode.CommandRelay2Off:
                    case PanelActivityEventCode.CommandRelay2On:
                        return PanelActivityEventCategory.Door;

                    case PanelActivityEventCode.AccessGrantedNoCardCodeLookup:
                    case PanelActivityEventCode.AccessDeniedAttemptPivCardExpired:
                    case PanelActivityEventCode.AccessDenied:
                    case PanelActivityEventCode.AccessGranted:
                    case PanelActivityEventCode.AccessGrantedDoorNotOpened:
                    case PanelActivityEventCode.AutoUnlockActivatedByAccessGranted:
                    case PanelActivityEventCode.CredentialDoublePresentDoorUnlocked:
                    case PanelActivityEventCode.CredentialDoublePresentDoorLocked:
                    case PanelActivityEventCode.AccessGrantedWithPinData:
                    case PanelActivityEventCode.DuressAuxiliaryFunction:
                    case PanelActivityEventCode.PassbackViolation:
                    case PanelActivityEventCode.IncorrectPinEntered:
                        return PanelActivityEventCategory.PersonDoor;

                    case PanelActivityEventCode.CpuWarmReset:
                    case PanelActivityEventCode.CpuColdReset:
                    case PanelActivityEventCode.PassbackForgivenForAllUsers:
                    case PanelActivityEventCode.CpuTamperRestored:
                    case PanelActivityEventCode.CpuTamperAlarm:
                    case PanelActivityEventCode.CpuLowBatteryRestored:
                    case PanelActivityEventCode.CpuLowBatteryAlarm:
                    case PanelActivityEventCode.CpuAcFailureRestored:
                    case PanelActivityEventCode.CpuAcFailureAlarm:
                    case PanelActivityEventCode.EmergencyUnlockInactive:
                    case PanelActivityEventCode.EmergencyUnlockActive:
                    case PanelActivityEventCode.CrisisModeActivated:
                    case PanelActivityEventCode.CrisisModeDeActivated:
                    case PanelActivityEventCode.CrisisModeActivatedByCommand:
                    case PanelActivityEventCode.CrisisModeDeActivatedByCommand:
                    case PanelActivityEventCode.CpuTurnLoggingOn:
                    case PanelActivityEventCode.CpuTurnLoggingOff:
                        return PanelActivityEventCategory.Panel;

                    case PanelActivityEventCode.BoardCommunicationStopped:
                    case PanelActivityEventCode.BoardCommunicationStarted:
                        return PanelActivityEventCategory.PanelBoard;

                    case PanelActivityEventCode.DeviceOffline:
                    case PanelActivityEventCode.DeviceOnline:
                    case PanelActivityEventCode.DualSerialInterfaceRelayBoardOffline:
                    case PanelActivityEventCode.DualSerialInterfaceRelayBoardOnline:
                    case PanelActivityEventCode.DualSerialInterfaceDoorModuleOffline:
                    case PanelActivityEventCode.DualSerialInterfaceDoorModuleOnline:
                    case PanelActivityEventCode.DualSerialInterfaceInputModuleOffline:
                    case PanelActivityEventCode.DualSerialInterfaceInputModuleOnline:
                        return PanelActivityEventCategory.DsiChannel;

                    case PanelActivityEventCode.PointInTrouble:
                    //case PanelActivityEventCode.PointInTroubleOpenCircuit:
                    case PanelActivityEventCode.PointTroubleShortCircuit:
                    case PanelActivityEventCode.PointSecureUnarmed:
                    case PanelActivityEventCode.PointAlarmUnarmed:
                    case PanelActivityEventCode.PointSecureArmed:
                    case PanelActivityEventCode.PointAlarmArmed:
                    case PanelActivityEventCode.PointShuntedByCommand:
                    case PanelActivityEventCode.PointUnshuntedByCommand:
                    case PanelActivityEventCode.PointTakenOutOfServiceByCommand:
                    case PanelActivityEventCode.PointReturnedToServiceByCommand:
                    case PanelActivityEventCode.CommandDisableInput:
                    case PanelActivityEventCode.CommandEnableInput:
                    case PanelActivityEventCode.CommandShuntInput:
                    case PanelActivityEventCode.CommandUnshuntInput:
                        return PanelActivityEventCategory.Input;

                    case PanelActivityEventCode.OutputOffBySchedule:
                    case PanelActivityEventCode.OutputOnBySchedule:
                    case PanelActivityEventCode.OutputOnByCommand:
                    case PanelActivityEventCode.OutputOffByCommand:
                    case PanelActivityEventCode.OutputTakenOutOfServiceByCommand:
                    case PanelActivityEventCode.OutputReturnedToServiceByCommand:
                    case PanelActivityEventCode.CommandOutputOn:
                    case PanelActivityEventCode.CommandOutputOff:
                    case PanelActivityEventCode.CommandOutputEnable:
                    case PanelActivityEventCode.CommandOutputDisable:
                        return PanelActivityEventCategory.Output;

                    case PanelActivityEventCode.IoGroupDisarmedBySchedule:
                    case PanelActivityEventCode.IoGroupArmedBySchedule:
                    case PanelActivityEventCode.IoGroupArmedByCommand:
                    case PanelActivityEventCode.IoGroupDisarmedByCommand:
                    case PanelActivityEventCode.IoGroupShuntedByCommand:
                    case PanelActivityEventCode.IoGroupUnshuntedByCommand:
                    case PanelActivityEventCode.CommandShuntIOGroup:
                    case PanelActivityEventCode.CommandUnshuntIOGroup:
                    case PanelActivityEventCode.CommandArmIOGroup:
                    case PanelActivityEventCode.CommandDisarmIOGroup:
                        return PanelActivityEventCategory.InputOutputGroup;

                    case PanelActivityEventCode.IoGroupArmByCard:
                    case PanelActivityEventCode.IoGroupDisarmByCard:
                        return PanelActivityEventCategory.PersonInputOutputGroup;

                    case PanelActivityEventCode.CommandUnlockDoorGroup:
                    case PanelActivityEventCode.CommandLockDoorGroup:
                    case PanelActivityEventCode.CommandDisableDoorGroup:
                    case PanelActivityEventCode.CommandEnableDoorGroup:
                        return PanelActivityEventCategory.DoorGroup;

                    case PanelActivityEventCode.PassbackForgivenForUser:
                    case PanelActivityEventCode.CredentialActivated:
                    case PanelActivityEventCode.CredentialDeactivated:
                        return PanelActivityEventCategory.Person;

                    case PanelActivityEventCode.OtisElevatorAudit:
                        return PanelActivityEventCategory.OtisElevator;

                    case PanelActivityEventCode.CardTourStarting:
                    case PanelActivityEventCode.CardTourContinuing:
                    case PanelActivityEventCode.CardTourCompleted:
                    case PanelActivityEventCode.CardTourOverdue:
                    case PanelActivityEventCode.CardTourIncorrectStartReader:
                    case PanelActivityEventCode.CardTourNonExistantTour:
                        return PanelActivityEventCategory.CardTour;

                    case PanelActivityEventCode.CommandElevatorPulse:
                    case PanelActivityEventCode.CommandElevatorEarlyOn:
                    case PanelActivityEventCode.CommandElevatorEarlyOff:
                    case PanelActivityEventCode.CommandElevatorCancelEarlyOn:
                    case PanelActivityEventCode.CommandElevatorCancelEarlyOff:
                        return PanelActivityEventCategory.GalaxyElevator;

                    default:
                        return PanelActivityEventCategory.Unknown;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique CPU. </summary>
        ///
        /// <value> The identifier of the unique CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueCpuId { get { return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique hardware. </summary>
        ///
        /// <value> The identifier of the unique hardware. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueHardwareId
        {
            get
            {
                switch (Category)
                {
                    case PanelActivityEventCategory.Door:
                    case PanelActivityEventCategory.PersonDoor:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.AccessPortal, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);

                    case PanelActivityEventCategory.Input:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.InputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);

                    case PanelActivityEventCategory.Output:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.OutputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);

                    case PanelActivityEventCategory.Panel:
                    case PanelActivityEventCategory.Person:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId);

                    case PanelActivityEventCategory.GalaxyElevator:
                    case PanelActivityEventCategory.OtisElevator:
                    case PanelActivityEventCategory.PanelBoard:
                    case PanelActivityEventCategory.InputOutputGroup:
                    case PanelActivityEventCategory.CardTour:
                    case PanelActivityEventCategory.PersonInputOutputGroup:
                    case PanelActivityEventCategory.DoorGroup:
                    case PanelActivityEventCategory.DsiChannel:
                    case PanelActivityEventCategory.Unknown:
                    default:
                        return string.Empty;
                }
            }
        }

        private ObservableCollection<AcknowledgedAlarmBasicData> _acknowledgments;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the acknowledgements. </summary>
        ///
        /// <value> The acknowledgements. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<AcknowledgedAlarmBasicData> Acknowledgements
        {
            get { return _acknowledgments; }
            set
            {
                if (_acknowledgments != value)
                {
                    _acknowledgments = value;
                    OnPropertyChanged(() => Acknowledgements, true);
                }
            }
        }
    }
}



