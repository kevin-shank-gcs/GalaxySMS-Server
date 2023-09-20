﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.PanelProtocols.Enums
{
    public enum PacketDataCodeTo6xx : UInt16
    {
        CpuHeartbeat = 0,
        RecalibrateIoCommand1 = 1,
        RecalibrateIoCommand2 = 2,
        NotificationCardAreaChange = 5,
        CommandResetCpu = 6,
        RecalibrateIoCommand7 = 7,
        RecalibrateIoCommand8 = 8,
        CommandClearAutoTimer = 9,
        CommandLoadBoardSectionNodeData = 0x0c,
        CommandLoadAccessGroupSchedulesForDoor = 0x0d,
        CommandLoadTimeSchedule15MinuteFormat = 0x0e,
        CommandLoadExtendedCards = 0x0f,
        CommandLoadStandardCards = 0x10,
        CommandDeleteCard = 0x11,
        CommandLoadAccessGroupSchedule = 0x12,
        CommandClearTimeSchedules = 0x13,
        CommandClearAllUsers = 0x14,
        CommandClearAccessGroupRange = 0x15,
        CommandLoadAccessGroupsCrisisGroups = 0x16,
        CommandSetDateTime = 0x17,
        CommandPing = 0x18,
        CommandLoad15MinuteScheduleHolidayTable = 0x19,
        CommandPanelInquire = 0x1a,
        CommandRequestTotalCardCount = 0x1c,
        //NotificationInternalPanelRecalibrate = 0x1e,
        //PanelRecalibrateComplete = 0x1f,
        CommandRequestSerialChannelRS485DeviceInfo = 0x1e,
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
        CommandReadInputVoltages = 0x3b,
        CommandOutputOn = 0x40,
        CommandOutputOff = 0x41,
        CommandOutputEnable = 0x42,
        CommandOutputDisable = 0x43,
        CommandRequestOutputStatus = 0x48,
        CommandElevatorPulse = 0x50,
        CommandElevatorEarlyOn = 0x51,
        CommandElevatorEarlyOff = 0x52,
        CommandElevatorCancelEarlyOn = 0x53,
        CommandElevatorCancelEarlyOff = 0x54,
        CommandLoadPersonalDoors = 0x57,
        CommandLoggingSetOnOff = 0x61,
        CommandLoggingResetPointers = 0x62,
        CommandLoggingAcknowledgeToMessageIndex = 0x63,
        CommandSignOnChallenge = 0x65,  // server back to panel
        CommandSignOnChallengeResponse = 0x66,  //server back to panel back
        CommandRequestConnectedBoardInformation = 0x67,
        CommandLoadTimeAdjustment = 0x6a,
        CommandSetCardLoadAcknowledgePanel = 0x6d,
        CommandRequestLoggingInformation = 0x6e,
        CommandLoadTamperAcFailureLowBattery = 0x70,
        CommandLoadABAOptions = 0x71,
        CommandLoadLockoutOptions = 0x72,
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
        CommandGetSetPanelConfigBlockData = 0x80,
        CommandLoad15MinuteScheduleHolidays = 0x8e, // holidays 2 - 9
        CommandLoadCardaxStartStopSettings = 0x8f,
        CommandGetIOGroupCounters = 0x94,
        NotificationCounterBelowZero = 0x96,
        NotificationEventPreviousStateInvalid = 0x9b,
        NotificationEventNewStateInvalid = 0x9c,
        NotificationEventIOLevel = 0xa0,
        CommandLoadIOGroupArmSchedule = 0xa1,
        NotificationInputOutputGroupBitsRepaired = 0xa2,
        CommandInitializeBoardSection = 0xa3,
        NotificationEventIOPulse = 0xa4,
        NotificationEventRecalibrate = 0xa5,
        // 508i & 600 Codes
        CommandBeginFlashLoad600 = 0xa6,
        CommandLoadFlashPacket600 = 0xa7,
        CommandValidateFlash600 = 0xa8,
        CommandValidateThenBurnFlash600 = 0xa9,
        //CommandLoadEZ80PrimaryLoopDelays = 0xaa,
        LoadAccessGroupCrisisGroup = 0xab,
        NotificationCardNotInPanelMemory = 0xad,
        CommandSetServerConsultationOptions = 0xae,
        NotificationCardHasBeenRead = 0xaf,
        NotificationCardRemoteAccessRuleOverride = 0xb0,
        CommandLoadMinuteScheduleDayTypes = 0xb1,
        CommandLoadMinuteScheduleTimePeriod = 0xb2,
        CommandLoadMinuteScheduleTimePeriodsForDayType = 0xb3,
        CommandCardRemoteAccessRuleOverrideReply = 0xb4,
        CommandBeginFlashLoad635 = 0xb6,
        CommandLoadFlashPacket635 = 0xb7,
        CommandValidateFlash635 = 0xb8,
        CommandValidateThenBurnFlash635 = 0xb9,
        EchoNack = 0xff
    }

    public enum PacketDataCodeFrom6xx : UInt16
    {
        CpuHeartbeat = 0,
        RecalibrateIoCommand1 = 1,
        RecalibrateIoCommand2 = 2,
        ResponseAck = 3,
        ResponseNack = 4,
        NotificationCardAreaChange = 5,
        ResponseResetCpu = 7,
        RecalibrateIoCommand7 = 7,
        RecalibrateIoCommand8 = 8,
        ResponseReaderPortStatus = 0x0a,
        ResponseInputDeviceStatus = 0x0b,
        ResponseCardCommand = 0x0f,
        ResponsePanelInquire = 0x1b,
        ResponseTotalCardCount = 0x1d,
        //NotificationInternalPanelRecalibrate = 0x1e,    // 500 only
        //PanelRecalibrateComplete = 0x1f,                // 500 only
        ResponseSerialChannelRS485DeviceInfo = 0x1f,
        ResponseInputVoltages = 0x3c,
        ResponseReaderPortOutputStatus = 0x49,
        ResponseOutputRelayModuleOutputStatus = 0x4a,
        ResponseAlarmMonitoringModuleGeneralPurposeIOOutputStatus = 0x4b,
        ResponseElevatorModuleOutputStatus = 0x4c,
        ResponseElevatorCommand = 0x55,
        ActivityLogMessage = 0x60,
        ResponseSignOnChallenge = 0x66, //panel back to server
        //ResponseSignOnSuccessful = 0x67,
        //ResponseSignOnDenied = 0x68,
        ResponseConnectedBoardInformation = 0x68,
        ResponseRequestLoggingInformation = 0x6f,
        ResponseIOGroupCounters = 0x95,
        NotificationCounterBelowZero = 0x96,
        NotificationEventPreviousStateInvalid = 0x9b,
        NotificationEventNewStateInvalid = 0x9c,
        NotificationEventIOLevel = 0xa0,
        NotificationInputOutputGroupBitsRepaired = 0xa2,
        NotificationEventIOPulse = 0xa4,
        NotificationEventRecalibrate = 0xa5,
        NotificationCardNotInPanelMemory = 0xad,
        NotificationCardHasBeenRead = 0xaf,
        NotificationCardRemoteAccessRuleOverride = 0xb0,
        ResponseSignOnOemCodeFailure = 0xd0,
    }

}
