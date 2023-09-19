using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;
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
            ClusterUid = msg.ClusterUid;
            PanelNumber = msg.PanelNumber;
            CpuId = msg.CpuId;
            BoardNumber = msg.BoardNumber;
            SectionNumber = msg.SectionNumber;
            ModuleNumber = msg.ModuleNumber;
            NodeNumber = msg.NodeNumber;
            CpuModel = msg.CpuModel;
            DateTime = msg.DateTime;
            BufferIndex = msg.BufferIndex;
            PanelActivityType = msg.PanelActivityType;
            EventTypeUid = msg.EventTypeUid;
            DeviceTypeCode = msg.DeviceTypeCode;
            InputOutputGroupNumber = msg.InputOutputGroupNumber;
            MultiFactorMode = msg.MultiFactorMode;
            DeviceDescription = msg.DeviceDescription;
            EventDescription = msg.EventDescription;
            InputOutputGroupName = msg.InputOutputGroupName;
            InputOutputGroupUid = msg.InputOutputGroupUid;
            GalaxyInterfaceBoardUid = msg.GalaxyInterfaceBoardUid;
            GalaxyInterfaceBoardSectionUid = msg.GalaxyInterfaceBoardSectionUid;
            GalaxyHardwareModuleUid = msg.GalaxyHardwareModuleUid;
            GalaxyInterfaceBoardSectionNodeUid = msg.GalaxyInterfaceBoardSectionNodeUid;
            DeviceEntityId = msg.DeviceEntityId;
            DeviceUid = msg.DeviceUid;
            CpuUid = msg.CpuUid;
            ClusterName = msg.ClusterName;
            IsAlarmEvent = msg.IsAlarmEvent;
            AlarmPriority = msg.AlarmPriority;
            ResponseRequired = msg.ResponseRequired;
            Instructions = msg.Instructions;
            InstructionsNoteUid = msg.InstructionsNoteUid;
            AudioBinaryResourceUid = msg.AudioBinaryResourceUid;
            RawData = msg.RawData;
            Color = msg.Color;
            ForeColorHex = msg.ForeColorHex;
            AccessPortalContactStatus = msg.AccessPortalContactStatus;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ActivityEventUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EventTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public short CpuId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int BoardNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int SectionNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ModuleNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int NodeNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel CpuModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //public DateTimeOffset DateTimeOffset { get; set; }
        public DateTimeOffset DateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 BufferIndex { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelActivityEventCode PanelActivityType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DeviceType DeviceTypeCode { get; set; }

        public string DeviceType => DeviceTypeCode.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int16 InputOutputGroupNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalMultiFactorModeCode MultiFactorMode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceDescription { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string EventDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputOutputGroupName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputOutputGroupUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DeviceUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAlarmEvent { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AlarmPriority { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResponseRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Instructions { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InstructionsNoteUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AudioBinaryResourceUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte[] RawData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Color { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ForeColorHex { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string ColorArgb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalContactStatus AccessPortalContactStatus { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string DeviceEntityName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityType { get; set; }

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
                    //                    case PanelActivityEventCode.PointInTroubleOpenCircuit:
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
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.InputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, ModuleNumber, NodeNumber);

                    case PanelActivityEventCategory.Output:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.OutputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber);

                    case PanelActivityEventCategory.DsiChannel:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.DsiChannelModule, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, ModuleNumber);

                    case PanelActivityEventCategory.PanelBoard:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.InterfaceBoard, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber);

                    case PanelActivityEventCategory.Panel:
                    case PanelActivityEventCategory.Person:
                        return string.Format(GalaxySMS.Common.Constants.UniqueHardwareAddressFormat.GalaxyCpu, ClusterGroupId, ClusterNumber, PanelNumber, CpuId);

                    case PanelActivityEventCategory.GalaxyElevator:
                    case PanelActivityEventCategory.OtisElevator:
                    case PanelActivityEventCategory.InputOutputGroup:
                    case PanelActivityEventCategory.CardTour:
                    case PanelActivityEventCategory.PersonInputOutputGroup:
                    case PanelActivityEventCategory.DoorGroup:

                    case PanelActivityEventCategory.Unknown:
                    default:
                        return string.Empty;
                }
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AcknowledgedAlarmBasicData> Acknowledgements { get; set; }
    }
}



