using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
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

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public InputOutputGroupAssignment DoorIllegalOpenInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment InvalidAccessAttemptInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment PassbackViolationInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment DoorOpenTooLongInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment DuressInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment DoorGroupInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment AccessGrantedInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupAssignment HeartbeatStoppedInputOutputGroupAssignment { get; set; }

		[DataMember]
		public InputOutputGroupNumber LockOnInputOutputGroupEvent { get; set; }

		[DataMember]
		public InputOutputGroupNumber UnlockOnInputOutputGroupEvent { get; set; }

		[DataMember]
		public PassbackAreaNumber PassbackIntoArea { get; set; }

		[DataMember]
		public PassbackAreaNumber PassbackFromArea { get; set; }

		[DataMember]
		public AutomaticForgivePassbackTimes AutomaticForgivePassbackTimes {get;set;}

		[DataMember]
		public ScheduleNumber FreeAccessUnlockSchedule { get; set; }

		[DataMember]
		public ScheduleNumber PinRequiredSchedule { get; set; }

		[DataMember]
		public ScheduleNumber DisableDoorIllegalOpenSchedule { get; set; }

		[DataMember]
		public ScheduleNumber DisableDoorOpenTooLongSchedule { get; set; }

		[DataMember]
		public UInt16 UnlockDuration { get; set; }	// hundredths of seconds

		[DataMember]
		public UInt16 RecloseDuration { get; set; }	// hundredths of seconds

		[DataMember]
		public UInt16 UnlockDelayDuration { get; set; }	// hundredths of seconds

		[DataMember]
		public ReaderRelayTwoSettings RelayTwoSettings { get; set; }

		[DataMember]
		public YesNo AllowAccessOnPassbackViolation { get; set; }

		[DataMember]
		public YesNo TwoValidCredentialsRequired { get; set; }

		[DataMember]
		public YesNo UnlockOnRequestToExit { get; set; }

		[DataMember]
		public YesNo SuppressRequestToExitMessage { get; set; }

		[DataMember]
		public YesNo DuressEnabled { get; set; }

		[DataMember]
		public DoorGroupBehavior DoorGroupBehavior { get; set; }

		[DataMember]
		public YesNo EnergizeRelayOneDuringArmingDelay { get; set; }

		[DataMember]
		public AutomaticUnlockBehavior AutomaticUnlockBehavior { get; set; }

		[DataMember]
		public PinRequiredBehavior PINRequiredBehavior { get; set; }

		[DataMember]
		public YesNo RequestToExitInputIndicatesWhichParallelAdapterReaderWasUsed { get; set; }

		[DataMember]
		public DoorContactSupervisionType DoorContactSupervisionType { get; set; }

		[DataMember]
		public YesNo MonitorReaderHeartbeat { get; set; }

		[DataMember]
		public YesNo SuppressDoorIllegalOpenMessage { get; set; }

		[DataMember]
		public YesNo SuppressDoorOpenTooLongMessage { get; set; }

		[DataMember]
		public YesNo SuppressDoorCloseMessage { get; set; }

		[DataMember]
		public YesNo DeenergizeRelayOneWhenDoorCloses { get; set; }

		[DataMember]
		public InputOutputGroupNumber DisarmInputOutputGroup1 { get; set; }

		[DataMember]
		public InputOutputGroupNumber DisarmInputOutputGroup2 { get; set; }

		[DataMember]
		public InputOutputGroupNumber DisarmInputOutputGroup3 { get; set; }

		[DataMember]
		public InputOutputGroupNumber DisarmInputOutputGroup4 { get; set; }

		[DataMember]
		public YesNo IgnoreNotInSystemReads { get; set; }

		[DataMember]
		public YesNo ReaderIsCardTourMember { get; set; }

		[DataMember]
		public BoardSectionHardwareAddress ElevatorControlBoardSectionAddress { get; set; }

		[DataMember]
		public ReaderLcdSettings LcdSettings { get; set; }

		[DataMember]
		public AccessDecisionServerConsultationRule AccessRuleOverrideConsultRule {get;set;}

		[DataMember]
		public AccessDecisionServerFailsToRespondTimeoutBehavior AccessRuleOverrideServerFailsToRespondBehavior { get; set; }

		[DataMember]
		public PanelDoorNumber PanelDoorNumber { get; set; }

		[DataMember]
		public OtisDecGroupFlag OtisDecGroupFlags { get; set; }

		[DataMember]
		public SchlagePimNumber PimNumber { get; set; }
	}
}
