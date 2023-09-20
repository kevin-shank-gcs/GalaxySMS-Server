using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class PanelActivityLogMessageBase //: PanelMessageBase
    {
        //ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }

        //private Int32 nodeNumberValue;
        //private Int32 sectionNumberValue;
        //private Int32 boardNumberValue;

        //public enum ActivityLogBoardNumberLimits { MinimumBoardNumber = 0, MaximumBoardNumber = 32 }
        //public enum ActivityLogSectionNumberLimits { MinimumSectionNumber = 0, MaximumSectionNumber = 16 }
        //public enum ActivityLogNodeNumberLimits { MinimumNodeNumber = 0, MaximumNodeNumber = 16 }

        public PanelActivityLogMessageBase()
        {
            ActivityEventUid = GuidUtilities.GenerateComb();
        }

        public PanelActivityLogMessageBase(PanelActivityLogMessageBase msg)
        {
            ActivityEventUid = msg.ActivityEventUid;
            ClusterGroupId = msg.ClusterGroupId;
            ClusterNumber = msg.ClusterNumber;
            PanelNumber = msg.PanelNumber;
            CpuId = msg.CpuId;
            BoardNumber = msg.BoardNumber;
            SectionNumber = msg.SectionNumber;
            NodeNumber = msg.NodeNumber;
            CpuModel = msg.CpuModel;
            DateTimeOffset = msg.DateTimeOffset;
            BufferIndex = msg.BufferIndex;
            PanelActivityType = msg.PanelActivityType;
            InputOutputGroupNumber = msg.InputOutputGroupNumber;
            MultiFactorMode = msg.MultiFactorMode;
            DeviceDescription = msg.DeviceDescription;
            EventDescription = msg.EventDescription;
            DeviceEntityId = msg.DeviceEntityId;
            DeviceUid = msg.DeviceUid;
            CpuUid = msg.CpuUid;
            ClusterName = msg.ClusterName;
            IsAlarmEvent = msg.IsAlarmEvent;
            AlarmPriority = msg.AlarmPriority;
            Instructions = msg.Instructions;
            InstructionsNoteUid = msg.InstructionsNoteUid;
            AudioBinaryResourceUid = msg.AudioBinaryResourceUid;
            RawData = msg.RawData;
            Color = msg.Color;
        }

        [DataMember]
        public Guid ActivityEventUid { get; set; }

        [DataMember]
        public int ClusterGroupId { get; set; }

        [DataMember]
        public int ClusterNumber { get; set; }

        [DataMember]
        public int PanelNumber { get; set; }

        [DataMember]
        public short CpuId { get; set; }

        [DataMember]
        public int BoardNumber { get; set; }

        [DataMember]
        public int SectionNumber { get; set; }

        [DataMember]
        public int NodeNumber { get; set; }

        [DataMember]
        public CpuModel CpuModel { get; set; }

        [DataMember]
        public DateTimeOffset DateTimeOffset { get; set; }

        [DataMember]
        public UInt32 BufferIndex { get; set; }

        [DataMember]
        public PanelActivityEventCode PanelActivityType { get; set; }

        [DataMember]
        public Int16 InputOutputGroupNumber { get; set; }

        [DataMember]
        public AccessPortalMultiFactorModeCode MultiFactorMode { get; set; }

        [DataMember]
        public string DeviceDescription { get; set; }

        [DataMember]
        public string EventDescription { get; set; }

        [DataMember]
        public Guid DeviceEntityId { get; set; }

        [DataMember]
        public Guid DeviceUid { get; set; }

        [DataMember]
        public Guid CpuUid { get; set; }

        [DataMember]
        public string ClusterName { get; set; }

        [DataMember]
        public bool IsAlarmEvent { get; set; }

        [DataMember]
        public int AlarmPriority { get; set; }

        [DataMember]
        public string Instructions { get; set; }

        [DataMember]
        public Guid InstructionsNoteUid { get; set; }

        [DataMember]
        public Guid AudioBinaryResourceUid { get; set; }

        [DataMember]
        public Byte[] RawData { get; set; }

        [DataMember]
        public int Color { get; set; }

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
                    case PanelActivityEventCode.AccessGrantedWithPinData:
                    case PanelActivityEventCode.Duress:
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
                        return PanelActivityEventCategory.DsiChannel;

                    case PanelActivityEventCode.PointInTroubleOpenCircuit:
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

        public String UniqueCpuId { get { return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }
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

                    case PanelActivityEventCategory.GalaxyElevator:
                    case PanelActivityEventCategory.OtisElevator:
                    case PanelActivityEventCategory.Panel:
                    case PanelActivityEventCategory.PanelBoard:
                    case PanelActivityEventCategory.InputOutputGroup:
                    case PanelActivityEventCategory.CardTour:
                    case PanelActivityEventCategory.Person:
                    case PanelActivityEventCategory.PersonInputOutputGroup:
                    case PanelActivityEventCategory.DoorGroup:
                    case PanelActivityEventCategory.DsiChannel:
                    case PanelActivityEventCategory.Unknown:
                    default:
                        return string.Empty;
                }
            }
        }

        [DataMember]
        public ICollection<AcknowledgedAlarmBasicData> Acknowledgements {get;set;}
    }
}



