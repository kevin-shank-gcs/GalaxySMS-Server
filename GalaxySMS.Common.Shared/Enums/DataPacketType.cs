////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\DataPacketType.cs
//
// summary:	Implements the data packet type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent packet data types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PacketDataType
    {
        /// <summary>   . </summary>
        CpuHeartbeat = 0,
        /// <summary>   . </summary>
        RecalibrateIoCommand1 = 1,
        /// <summary>   . </summary>
        RecalibrateIoCommand2 = 2,
        /// <summary>   . </summary>
        ResponseAck = 3,
        /// <summary>   . </summary>
        ResponseNack = 4,
        /// <summary>   . </summary>
        EventCardAreaChange = 5,
        /// <summary>   . </summary>
        CommandResetCpu = 6,
        /// <summary>   . </summary>
        ResponseResetCpu = 7,
        /// <summary>   . </summary>
        CommandBeginFlashLoad = 8,
        /// <summary>   . </summary>
        EventAlarmIOGroupChange = 9,
        /// <summary>   . </summary>
        ResponseReaderPortStatus = 0x0a,
        /// <summary>   . </summary>
        ResponseInputDeviceStatus = 0x0b,
        /// <summary>   . </summary>
        CommandLoadBoardSectionNodeData = 0x0c,
        /// <summary>   . </summary>
        //		CommandLoadAccessGroups5xx = 0x0d,
        CommandLoadAccessGroupSchedulesForDoor = 0x0d,
        /// <summary>   . </summary>
        CommandLoadTimeSchedule = 0x0e,
        /// <summary>   . </summary>
        ResponseCardCommand = 0x0f,
        /// <summary>   . </summary>
        CommandLoadExtendedCards = 0x0f,
        /// <summary>   . </summary>
        CommandLoadStandardCards = 0x10,
        /// <summary>   . </summary>
        CommandDeleteCard = 0x11,
        /// <summary>   . </summary>
        CommandLoadAccessGroupSchedule = 0x12,
        /// <summary>   . </summary>
        //		CommandLoadAccessGroup5xx = 0x12,
        CommandClearTimeSchedules = 0x13,
        /// <summary>   . </summary>
        CommandClearAllUsers = 0x14,
        /// <summary>   . </summary>
        //		CommandClearAccessGroups5xx = 0x15,
        CommandClearAccessGroupRange = 0x15,
        /// <summary>   . </summary>
        CommandClearPort = 0x16,
        /// <summary>   . </summary>
        CommandSetDateTime = 0x17,
        /// <summary>   . </summary>
        CommandPing = 0x18,
        /// <summary>   . </summary>
        CommandLoadHolidayTable = 0x19,
        /// <summary>   . </summary>
        CommandPanelInquire = 0x1a,
        /// <summary>   . </summary>
        ResponsePanelInquire = 0x1b,
        /// <summary>   . </summary>
        CommandRequestTotalCardCount = 0x1c,
        /// <summary>   . </summary>
        ResponseTotalCardCount = 0x1d,
        /// <summary>   . </summary>
        CommandRequestSerialChannelRS485DeviceInfo = 0x1e,
        /// <summary>   . </summary>
        ResponseSerialChannelRS485DeviceInfo = 0x1f,
        /// <summary>   . </summary>
        //		Ascii5xx = 0x20,

        CommandUnlockDoor = 0x21,
        /// <summary>   . </summary>
        CommandLockDoor = 0x22,
        /// <summary>   . </summary>
        CommandDisableDoor = 0x23,
        /// <summary>   . </summary>
        CommandEnableDoor = 0x24,
        /// <summary>   . </summary>
        CommandPulseDoor = 0x25,

        /// <summary>   . </summary>
        CommandUnlockDoorGroup = 0x26,
        /// <summary>   . </summary>
        CommandLockDoorGroup = 0x27,
        /// <summary>   . </summary>
        CommandDisableDoorGroup = 0x28,
        /// <summary>   . </summary>
        CommandEnableDoorGroup = 0x29,

        /// <summary>   . </summary>
        CommandRelay2Off = 0x2a,
        /// <summary>   . </summary>
        CommandRequestReaderPortStatus = 0x2b,
        /// <summary>   . </summary>
        //		DialBackIDMessage5xx = 0x2c,
        CommandRelay2On = 0x2d,
        /// <summary>   . </summary>
        CommandSetLedTemporaryState = 0x2e,

        /// <summary>   . </summary>
        CommandShuntIOGroup = 0x30,
        /// <summary>   . </summary>
        CommandUnshuntIOGroup = 0x31,
        /// <summary>   . </summary>
        CommandDisableInput = 0x32,
        /// <summary>   . </summary>
        CommandEnableInput = 0x33,
        /// <summary>   . </summary>
        CommandArmIOGroup = 0x34,
        /// <summary>   . </summary>
        CommandDisarmIOGroup = 0x35,
        /// <summary>   . </summary>
        CommandShuntInput = 0x36,
        /// <summary>   . </summary>
        CommandUnshuntInput = 0x37,
        /// <summary>   . </summary>
        CommandRequestInputStatus = 0x38,
        /// <summary>   . </summary>
        ResponseInputVoltages = 0x3c,

        /// <summary>   . </summary>
        CommandOutputOn = 0x40,
        /// <summary>   . </summary>
        CommandOutputOff = 0x41,
        /// <summary>   . </summary>
        CommandOutputEnable = 0x42,
        /// <summary>   . </summary>
        CommandOutputDisable = 0x43,
        /// <summary>   . </summary>
        CommandRequestOutputStatus = 0x48,
        /// <summary>   . </summary>
        ResponseReaderPortOutputStatus = 0x49,
        /// <summary>   . </summary>
        ResponseOutputRelayModuleOutputStatus = 0x4a,
        /// <summary>   . </summary>
        ResponseAlarmMonitoringModuleGeneralPurposeIOOutputStatus = 0x4b,
        /// <summary>   . </summary>
        ResponseElevatorModuleOutputStatus = 0x4c,

        /// <summary>   . </summary>
        CommandElevatorPulse = 0x50,
        /// <summary>   . </summary>
        CommandElevatorEarlyOn = 0x51,
        /// <summary>   . </summary>
        CommandElevatorEarlyOff = 0x52,
        /// <summary>   . </summary>
        CommandElevatorCancelEarlyOn = 0x53,
        /// <summary>   . </summary>
        CommandElevatorCancelEarlyOff = 0x54,
        /// <summary>   . </summary>
        ResponseElevatorCommand = 0x55,

        /// <summary>   . </summary>
        CommandLoadPersonalDoors = 0x57,
        /// <summary>   . </summary>
        //		CommandLoadPrimaryLoopTransmitDelay5xx = 0x5f,
        ActivityLogMessage = 0x60,
        /// <summary>   . </summary>
        CommandLoggingSetOnOff = 0x61,
        /// <summary>   . </summary>
        CommandLoggingResetPointers = 0x62,
        /// <summary>   . </summary>
        CommandLoggingAcknowledgeToMessageIndex = 0x63,

        /// <summary>   server back to panel. </summary>
        //CommandSignOnRequest = 0x64,	// Server to panel
        //ResponseSignOnRequestWithChallenge = 0x65,	// panel back to server
        CommandSignOnChallenge = 0x65,
        /// <summary>   panel back to server. </summary>
        ResponseSignOnChallenge = 0x66,
        /// <summary>   server back to panel back. </summary>
        CommandSignOnChallengeResponse = 0x66,
        /// <summary>   . </summary>
        CommandRequestConnectedBoardInformation = 0x67,
        /// <summary>   . </summary>
        ResponseConnectedBoardInformation = 0x68,
        /// <summary>   . </summary>
        //ResponseSignOnSuccessful = 0x67,
        //ResponseSignOnDenied = 0x68,

        CommandLoadTimeAdjustment = 0x6a,
        /// <summary>   . </summary>
        //		NetworkBridgeCommunicationStatus = 0x6c,	// 500 network bridge
        CommandSetCardLoadAcknowledgePanel = 0x6d,
        /// <summary>   . </summary>
        CommandRequestLoggingInformation = 0x6e,
        /// <summary>   . </summary>
        ResponseRequestLoggingInformation = 0x6f,

        /// <summary>   . </summary>
        CommandLoadTamperAcFailureLowBattery = 0x70,
        /// <summary>   . </summary>
        CommandLoadABAOptions = 0x71,
        /// <summary>   . </summary>
        CommandLoadLockoutOptions = 0x72,
        /// <summary>   . </summary>
        //		CommandLoadDialBackSettings = 0x73,	
        CommandForgivePassbackCard = 0x74,
        /// <summary>   . </summary>
        CommandForgivePassbackEverybody = 0x75,
        /// <summary>   . </summary>
        CommandRecalibrate = 0x76,
        /// <summary>   . </summary>
        CommandCardEnable = 0x77,
        /// <summary>   . </summary>
        CommandCardDisable = 0x78,
        /// <summary>   . </summary>
        CommandSetUserAuthority = 0x79,
        /// <summary>   . </summary>
        CommandLoadLedOptions = 0x7b,
        /// <summary>   . </summary>
        CommandLoadCrisisModeIOGroup = 0x7c,
        /// <summary>   . </summary>
        CommandResetCrisisMode = 0x7d,
        /// <summary>   . </summary>
        CommandSetCrisisMode = 0x7e,
        /// <summary>   . </summary>
        CommandLoadWiegandStartStopSettings = 0x7f,

        /// <summary>   holidays 2 - 9. </summary>
        //CommandLoadKeyControlTable = 0x80,
        //CommandAssignKeyToCard = 0x81,
        //CommandRequestKeysOwnedByCard = 0x82,
        //ResponseKeysOwnedByCard = 0x83,
        //CommandRequestKeysAvailable = 0x84,
        //ResponseKeysAvailable = 0x85,
        //CommandWhoHasKey = 0x86,
        //ResponseWhoHasKey = 0x87,
        //CommandReleaseKeysForCard = 0x88,

        CommandLoadTimeScheduleHolidays = 0x8e,
        /// <summary>   . </summary>
        CommandLoadCardaxStartStopSettings = 0x8f,

        /// <summary>   . </summary>
        //CommandSend232Message = 0x90,
        //CommandSend232MessageAll = 0x91,
        //CommandSet232MessageOptions = 0x92,
        //CommandSetLoopTestMode = 0x93,

        CommandGetIOGroupCounters = 0x94,
        /// <summary>   . </summary>
        ResponseIOGroupCounters = 0x95,
        /// <summary>   . </summary>
        NotificationCounterBelowZero = 0x96,

        /// <summary>   . </summary>
        // 5xx network error codes
        NotificationSdlcLoopErrorPrimaryTransmitError = 0x97,
        /// <summary>   . </summary>
        NotificationSdlcLoopErrorSecondaryReceivedDuplicateSerialNumber = 0x98,
        /// <summary>   . </summary>
        NotificationSdlcLoopErrorSecondaryDetectedMissingSerialNumber = 0x99,
        /// <summary>   . </summary>
        NotificationSdlcLoopErrorPriryReceivedDuplicateSerialNumber = 0x9a,

        /// <summary>   . </summary>
        NotificationEventPreviousStateInvalid = 0x9b,
        /// <summary>   . </summary>
        NotificationEventNewStateInvalid = 0x9c,

        /// <summary>   . </summary>
        NotificationEventIOLevel = 0xa0,
        /// <summary>   . </summary>
        CommandLoadIOGroupArmSchedule = 0xa1,
        /// <summary>   . </summary>
        NotificationInputOuputGroupBitsRepaired = 0xa2,
        /// <summary>   . </summary>
        CommandInitializeBoardSection = 0xa3,
        /// <summary>   . </summary>
        NotificationEventIOPulse = 0xa4,
        /// <summary>   . </summary>
        NotificationEventRecalibrate = 0xa5,

        /// <summary>   . </summary>
        CommandBeginFlashLoadEz80 = 0xa6,
        /// <summary>   . </summary>
        CommandLoadFlashPacketEz80 = 0xa7,
        /// <summary>   . </summary>
        CommandValidateFlashEz80 = 0xa8,
        /// <summary>   . </summary>
        CommandValidateThenBurnFlashEz80 = 0xa9,

        /// <summary>   . </summary>
        CommandLoadEZ80PrimaryLoopDelays = 0xaa,

        /// <summary>   . </summary>
        LoadAccessGroupCrisisGroup = 0xab,

        /// <summary>   . </summary>
        NotificationCardNotInPanelMemory = 0xad,
        /// <summary>   . </summary>
        CommandSetServerConsultationOptions = 0xae,
        /// <summary>   . </summary>
        NotificationCardHasBeenRead = 0xaf,
        /// <summary>   . </summary>
        NotificationCardRemoteAccessRuleOverride = 0xb0,
        /// <summary>   . </summary>
        CommandLoadMinuteScheduleDayTypes = 0xb1,
        /// <summary>   . </summary>
        CommandLoadMinuteScheduleTimePeriod = 0xb2,
        /// <summary>
        /// An enum constant representing the command load minute schedule time periods for day type
        /// option.
        /// </summary>
        CommandLoadMinuteScheduleTimePeriodsForDayType = 0xb3,
        /// <summary>
        /// An enum constant representing the command card remote access rule override reply option.
        /// </summary>
        CommandCardRemoteAccessRuleOverrideReply = 0xb4,

        /// <summary>   An enum constant representing the command begin flash load 635 option. </summary>
		CommandBeginFlashLoad635 = 0xb6,
        /// <summary>   An enum constant representing the command load flash packet 635 option. </summary>
		CommandLoadFlashPacket635 = 0xb7,
        /// <summary>   An enum constant representing the command validate flash 635 option. </summary>
		CommandValidateFlash635 = 0xb8,
        /// <summary>
        /// An enum constant representing the command validate then burn flash 635 option.
        /// </summary>
		CommandValidateThenBurnFlash635 = 0xb9,



    }

}
