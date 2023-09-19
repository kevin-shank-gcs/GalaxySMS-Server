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
    public enum AutomaticForgivePassbackTimes { Never = 0, Midnight, MidnightAndNoon, EveryFourHours, EveryTwoHours, EveryHour, EveryHalfHour }
    public enum DoorGroupBehavior { Nothing, NotifyGroupButDoNotReactToGroup, ReactToGroupButDoNotNotifyGroup, NotifyAndReact }
    public enum AutomaticUnlockBehavior { UnlockImmediately, RequireValidAccess }
    public enum PinRequiredBehavior { None, RequiredForAccessDecision, InformationalOnly, PINSpecifiesRecloseTime }
    public enum DoorContactSupervisionType { None, SeriesOnly, ParallelOnly, BothSeriesAndParallel }

    [DataContract]
    public class ReaderConfigurationData : BoardSectionNodeHardwareAddress
    {

        public ReaderConfigurationData()
        {
            DoorIllegalOpenInputOutputGroupAssignment = new InputOutputGroupAssignment();
            InvalidAccessAttemptInputOutputGroupAssignment = new InputOutputGroupAssignment();
            PassbackViolationInputOutputGroupAssignment = new InputOutputGroupAssignment();
            DoorOpenTooLongInputOutputGroupAssignment = new InputOutputGroupAssignment();
            DuressInputOutputGroupAssignment = new InputOutputGroupAssignment();
            DoorGroupInputOutputGroupAssignment = new InputOutputGroupAssignment();
            AccessGrantedInputOutputGroupAssignment = new InputOutputGroupAssignment();
            HeartbeatStoppedInputOutputGroupAssignment = new InputOutputGroupAssignment();

            LockOnInputOutputGroupEvent = new InputOutputGroupNumber();
            UnlockOnInputOutputGroupEvent = new InputOutputGroupNumber();

            PassbackIntoArea = new PassbackAreaNumber();
            PassbackFromArea = new PassbackAreaNumber();

            FreeAccessUnlockSchedule = new ScheduleNumber();
            PinRequiredSchedule = new ScheduleNumber();
            DisableDoorIllegalOpenSchedule = new ScheduleNumber();
            DisableDoorOpenTooLongSchedule = new ScheduleNumber();

            RelayTwoSettings = new ReaderRelayTwoSettings();

            DisarmInputOutputGroup1 = new InputOutputGroupNumber();
            DisarmInputOutputGroup2 = new InputOutputGroupNumber();
            DisarmInputOutputGroup3 = new InputOutputGroupNumber();
            DisarmInputOutputGroup4 = new InputOutputGroupNumber();

            ElevatorControlBoardSectionAddress = new BoardSectionHardwareAddress();
            LcdSettings = new ReaderLcdSettings();
            PanelDoorNumber = new PanelDoorNumber();
            OtisDecGroupFlags = new OtisDecGroupFlag();
            PimNumber = new SchlagePimNumber();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment DoorIllegalOpenInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment InvalidAccessAttemptInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment PassbackViolationInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment DoorOpenTooLongInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment DuressInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment DoorGroupInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment AccessGrantedInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupAssignment HeartbeatStoppedInputOutputGroupAssignment { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber LockOnInputOutputGroupEvent { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber UnlockOnInputOutputGroupEvent { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PassbackAreaNumber PassbackIntoArea { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PassbackAreaNumber PassbackFromArea { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AutomaticForgivePassbackTimes AutomaticForgivePassbackTimes { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ScheduleNumber FreeAccessUnlockSchedule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ScheduleNumber PinRequiredSchedule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ScheduleNumber DisableDoorIllegalOpenSchedule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ScheduleNumber DisableDoorOpenTooLongSchedule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 UnlockDuration { get; set; }  // hundredths of seconds
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 RecloseDuration { get; set; } // hundredths of seconds
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 UnlockDelayDuration { get; set; } // hundredths of seconds
#if NetCoreApi
#else
        [DataMember]
#endif
        public ReaderRelayTwoSettings RelayTwoSettings { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo AllowAccessOnPassbackViolation { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo TwoValidCredentialsRequired { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo UnlockOnRequestToExit { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo SuppressRequestToExitMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo DuressEnabled { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DoorGroupBehavior DoorGroupBehavior { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo EnergizeRelayOneDuringArmingDelay { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AutomaticUnlockBehavior AutomaticUnlockBehavior { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PinRequiredBehavior PINRequiredBehavior { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo RequestToExitInputIndicatesWhichParallelAdapterReaderWasUsed { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DoorContactSupervisionType DoorContactSupervisionType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo MonitorReaderHeartbeat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo SuppressDoorIllegalOpenMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo SuppressDoorOpenTooLongMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo SuppressDoorCloseMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo DeenergizeRelayOneWhenDoorCloses { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber DisarmInputOutputGroup1 { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber DisarmInputOutputGroup2 { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber DisarmInputOutputGroup3 { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber DisarmInputOutputGroup4 { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo IgnoreNotInSystemReads { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public YesNo ReaderIsCardTourMember { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public BoardSectionHardwareAddress ElevatorControlBoardSectionAddress { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ReaderLcdSettings LcdSettings { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessDecisionServerConsultationRule AccessRuleOverrideConsultRule { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessDecisionServerFailsToRespondTimeoutBehavior AccessRuleOverrideServerFailsToRespondBehavior { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelDoorNumber PanelDoorNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public OtisDecGroupFlag OtisDecGroupFlags { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public SchlagePimNumber PimNumber { get; set; }
    }
}
