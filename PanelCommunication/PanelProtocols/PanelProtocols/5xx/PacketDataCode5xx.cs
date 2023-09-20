using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.PanelProtocols.Enums
{
	public enum PacketDataCode5xx
	{
		CpuHeartbeat = 0,
		CommandLoadFlashBank = 1,
		CommandCheckFlashBank = 2,
		ResponseAck = 3,
		ResponseNack = 4,
		EventCardAreaChange = 5,
		CommandResetCpu = 6,
		ResponseResetCpu = 7,
		CommandBeginFlashLoad = 8,
		EventAlarmIOGroupChange = 9,
		ResponseReaderPortStatus = 0x0a,
		ResponseInputDeviceStatus = 0x0b,
		CommandLoadBoardSectionNodeData = 0x0c,
		//		CommandLoadAccessGroups5xx = 0x0d,
		CommandLoadAccessGroupSchedulesForDoor = 0x0d,
		CommandLoadTimeSchedule = 0x0e,
		ResponseCardCommand = 0x0f,
		CommandLoadExtendedCards = 0x0f,
		CommandLoadStandardCards = 0x10,
		CommandDeleteCard = 0x11,
		CommandLoadAccessGroupSchedule = 0x12,
		//		CommandLoadAccessGroup5xx = 0x12,
		CommandClearTimeSchedules = 0x13,
		CommandClearAllUsers = 0x14,
		//		CommandClearAccessGroups5xx = 0x15,
		CommandClearAccessGroupRange = 0x15,
		CommandClearPort = 0x16,
		CommandSetDateTime = 0x17,
		CommandPing = 0x18,
		CommandLoadHolidayTable = 0x19,
		CommandPanelInquire = 0x1a,
		ResponsePanelInquire = 0x1b,
		CommandRequestTotalCardCount = 0x1c,
		ResponseTotalCardCount = 0x1d,
		InternalPanelRecalibrateEvent = 0x1e,
		PanelRecalibrateComplete = 0x1f,
		//		Ascii5xx = 0x20,

		CommandUnlockDoor = 0x21,
		CommandLockDoor = 0x22,
		CommandDisableDoor = 0x23,
		CommandEnableDoor = 0x24,
		CommandPulseDoor = 0x25,

		CommandUnlockDoorGroup = 0x26,
		CommandLockDoorGroup = 0x27,
		CommandDisableDoorGroup = 0x28,
		CommandEnableDoorGroup = 0x29,

		CommandRelay2Off = 0x2a,
		CommandRequestReaderPortStatus = 0x2b,
		//		DialBackIDMessage5xx = 0x2c,
		CommandRelay2On = 0x2d,
		CommandSetLedTemporaryState = 0x2e,

		CommandShuntIOGroup = 0x30,
		CommandUnshuntIOGroup = 0x31,
		CommandDisableInput = 0x32,
		CommandEnableInput = 0x33,
		CommandArmIOGroup = 0x34,
		CommandDisarmIOGroup = 0x35,
		CommandShuntInput = 0x36,
		CommandUnshuntInput = 0x37,
		CommandRequestInputStatus = 0x38,
		ResponseInputVoltages = 0x3c,

		CommandOutputOn = 0x40,
		CommandOutputOff = 0x41,
		CommandOutputEnable = 0x42,
		CommandOutputDisable = 0x43,
		CommandRequestOutputStatus = 0x48,
		ResponseReaderPortOutputStatus = 0x49,
		ResponseOutputRelayModuleOutputStatus = 0x4a,
		ResponseAlarmMonitoringModuleGeneralPurposeIOOutputStatus = 0x4b,
		ResponseElevatorModuleOutputStatus = 0x4c,

		CommandElevatorPulse = 0x50,
		CommandElevatorEarlyOn = 0x51,
		CommandElevatorEarlyOff = 0x52,
		CommandElevatorCancelEarlyOn = 0x53,
		CommandElevatorCancelEarlyOff = 0x54,
		ResponseElevatorCommand = 0x55,

		CommandLoadPersonalDoors = 0x57,
		//		CommandLoadPrimaryLoopTransmitDelay5xx = 0x5f,
		ActivityLogMessage = 0x60,
		CommandLoggingSetOnOff = 0x61,
		CommandLoggingResetPointers = 0x62,
		CommandLoggingAcknowledgeToMessageIndex = 0x63,

		CommandSignOnRequest = 0x64,						// Server to panel
		ResponseSignOnRequestWithChallenge = 0x65,	// panel back to server
		CommandSignOnChallengeResponse = 0x66,
		ResponseSignOnSuccessful = 0x67,
		ResponseSignOnDenied = 0x68,

		CommandLoadLogFullDialBackParameters = 0x69,
		CommandLoadTimeAdjustment = 0x6a,
		//		NetworkBridgeCommunicationStatus = 0x6c,	// 500 network bridge
		CommandSetCardLoadAcknowledgePanel = 0x6d,
		CommandRequestLoggingInformation = 0x6e,
		ResponseRequestLoggingInformation = 0x6f,

		CommandLoadTamperAcFailureLowBattery = 0x70,
		CommandLoadABAOptions = 0x71,
		CommandLoadLockoutOptions = 0x72,
		//		CommandLoadDialBackSettings = 0x73,	
		CommandForgivePassbackCard = 0x74,
		CommandForgivePassbackEverybody = 0x75,
		CommandRecalibrate = 0x76,
		CommandCardEnable = 0x77,
		CommandCardDisable = 0x78,
		CommandSetUserAuthority = 0x79,
		CommandLoadLedOptions = 0x7b,
		CommandLoadCrisisModeIOGroup = 0x7c,
		CommandResetCrisisMode = 0x7d,
		CommandSetCrisisMode = 0x7e,
		CommandLoadWiegandStartStopSettings = 0x7f,

		//CommandLoadKeyControlTable = 0x80,
		//CommandAssignKeyToCard = 0x81,
		//CommandRequestKeysOwnedByCard = 0x82,
		//ResponseKeysOwnedByCard = 0x83,
		//CommandRequestKeysAvailable = 0x84,
		//ResponseKeysAvailable = 0x85,
		//CommandWhoHasKey = 0x86,
		//ResponseWhoHasKey = 0x87,
		//CommandReleaseKeysForCard = 0x88,

		CommandLoadTimeScheduleHolidays = 0x8e,	// holidays 2 - 9
		//CommandSend232Message = 0x90,
		//CommandSend232MessageAll = 0x91,
		//CommandSet232MessageOptions = 0x92,
		//CommandSetLoopTestMode = 0x93,

		CommandGetIOGroupCounters = 0x94,
		ResponseIOGroupCounters = 0x95,
		NotificationCounterBelowZero = 0x96,

		// 5xx network error codes
		NotificationSdlcLoopErrorPrimaryTransmitError = 0x97,
		NotificationSdlcLoopErrorSecondaryReceivedDuplicateSerialNumber = 0x98,
		NotificationSdlcLoopErrorSecondaryDetectedMissingSerialNumber = 0x99,
		NotificationSdlcLoopErrorPriryReceivedDuplicateSerialNumber = 0x9a,

		NotificationEventPreviousStateInvalid = 0x9b,
		NotificationEventNewStateInvalid = 0x9c,

		NotificationEventIOLevel = 0xa0,
		CommandLoadIOGroupArmSchedule = 0xa1,
		NotificationInputOuputGroupBitsRepaired = 0xa2,
		CommandInitializeBoardSection = 0xa3,
		NotificationEventIOPulse = 0xa4,
		NotificationEventRecalibrate = 0xa5,

		CommandBeginFlashLoadEz80 = 0xa6,
		CommandLoadFlashPacketEz80 = 0xa7,
		CommandValidateFlashEz80 = 0xa8,
		CommandValidateThenBurnFlashEz80 = 0xa9,

		CommandLoadEZ80PrimaryLoopDelays = 0xaa,

		NotificationCardNotInPanelMemory = 0xad,
		CommandSetUnlimitedCardOption = 0xae,
		NotificationCardHasBeenRead = 0xaf,
		NotificationCardRemoteAccessRuleOverride = 0xb0,
		CommandCardRemoteAccessRuleOverrideReply = 0xb4,

		CommandBeginFlashLoad635 = 0xb6,
		CommandLoadFlashPacket635 = 0xb7,
		CommandValidateFlash635 = 0xb8,
		CommandValidateThenBurnFlash635 = 0xb9,



	}
}
