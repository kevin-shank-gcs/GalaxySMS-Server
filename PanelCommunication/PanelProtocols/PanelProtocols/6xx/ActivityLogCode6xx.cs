﻿namespace GCS.PanelProtocols.Series6xx
{

    public enum PanelActivityLogMessageCode
    {
        DoorForcedOpen = 0x00,
        DoorLeftOpen = 0x01,
        DoorClosed = 0x02,
        ReadError = 0x03,
        DoorContactShunted = 0x04,
        DoorRequestToExit = 0x05,
        DoorUnlockBySchedule = 0x06,
        DoorLockBySchedule = 0x07,
        CpuWarmReset = 0x0B,
        CpuColdReset = 0x0C,
        DoorDelayedUnlock = 0x0D,
        LogBufferFilling = 0x0E,
        PointInTrouble = 0x10,
        PointTroubleShortCircuit = 0x11,
        PointSecureUnarmed = 0x12,
        PointAlarmUnarmed = 0x13,
        PointSecureArmed = 0x14,
        PointAlarmArmed = 0x15,
        IoGroupDisarmedBySchedule = 0x16,
        IoGroupArmedBySchedule = 0x17,
        OutputOffBySchedule = 0x18,
        OutputOnBySchedule = 0x19,
        IoGroupArmedByCommand = 0x1A,
        IoGroupDisarmedByCommand = 0x1B,
        DeviceOffline = 0x1C,
        DeviceOnline = 0x1D,
        Relay2OffBySchedule = 0x20,
        Relay2OnBySchedule = 0x21,

        CrisisModeActivated = 0x22,

        DoorContactTroubleOpenCircuit = 0x23,
        DoorContactTroubleShortCircuit = 0x24,
        DoorHeartbeartAlarm = 0x25,
        DoorHeartbeatRestored = 0x26,
        DoorContactTroubleCleared = 0x27,
        BoardCommunicationStopped = 0x28,
        BoardCommunicationStarted = 0x29,
        ReaderHeartbeatStopped = 0x2A,
        ReaderHeartbeatStarted = 0x2B,
        ReaderLowBattery = 0x2C,
        ReaderBatteryFlat = 0x2D,
        ReaderBatteryOk = 0x2E,
        NotInPanelMemory = 0x30,
        NotInPanelMemoryReverse = 0x31,
        AccessGrantedNoCardCodeLookup = 0x32,
        AccessDeniedAttemptPivCardExpired = 0x33,
        ExtendedCardCodeHighestBytes = 0x34,
        ExtendedCardCodeMiddleBytes = 0x35,
        AccessDenied = 0x40,
        AccessGranted = 0x41,
        Duress = 0x42,
        PassbackViolation = 0x43,
        IncorrectPinEntered = 0x44,
        IoGroupArmByCard = 0x45,
        IoGroupDisarmByCard = 0x46,
        AccessGrantedWithPinData = 0x48,
        OtisElevatorAudit = 0x49,
        AccessGrantedDoorNotOpened = 0x4a,
        AutoUnlockActivatedByAccessGranted = 0x4b,
        CredentialDoublePresentDoorUnlocked = 0x4c,
        CredentialDoublePresentDoorLocked = 0x4d,

        ReaderRadioInterferenceDetected = 0x50,
        ReaderRadioInterferenceCleared = 0x51,
        ReaderPrivacyModeEntered = 0x52,
        ReaderPrivacyModeExited = 0x53,
        ReaderOfficeModeEntered = 0x54,
        ReaderOfficeModeExited = 0x55,
        ClusterCrisisModeReset = 0x56,
        ReaderNdeMagnetAlertNeedsCalibrated = 0x57,
        ReaderNdeMagnetSafeCalibrated = 0x58,
        DoorContactChange = 0x59,
        VeridtReaderTamperAlarm = 0x5A,
        VeridtReaderTamperSafe = 0x5B,
        VeridtCardCertificateProblem = 0x5C,
        VeridtReaderFactorModeSet = 0x5D,
        PanelTamperRestored = 0x60,
        PanelTamperAlarm = 0x61,
        PanelLowBatteryRestored = 0x62,
        PanelLowBatteryAlarm = 0x63,
        PanelAcFailureRestored = 0x64,
        PanelAcFailureAlarm = 0x65,
        EmergencyUnlockInactive = 0x66,
        EmergencyUnlockActive = 0x67,
        ReaderTamperAlarm = 0x68,
        ReaderTamperRestored = 0x69,
        DoorModuleAdapterTamperAlarm = 0x6a,
        DoorModuleAdapterTamperSafe = 0x6b,

        CrisisModeDeActivated = 0x7d,
        CrisisModeActivatedByCommand = 0x7e,
        //PassbackForgivenForUser = 128,
        //PassbackForgivenForAllUsers = 129,
        //CardActivated = 130,
        //CardDeactivated = 131,

        DualSerialInterfaceRelayBoardOffline = 0x88,
        DualSerialInterfaceRelayBoardOnline = 0x89,
        DualSerialInterfaceDoorModuleOffline = 0x8A,
        DualSerialInterfaceDoorModuleOnline = 0x8B,
        DualSerialInterfaceInputModuleOffline = 0x8C,
        DualSerialInterfaceInputModuleOnline = 0x8D,

        DoorCommand = 0x90,
        DoorGroupCommand = 0x91,
        IoGroupCommand = 0x92,
        InputCommand = 0x93,
        OutputCommand = 0x94,
        ElevatorCommand = 0x95,
        CardCommand = 0x96,
        PanelCommand = 0x97,

        CardTourStarting = 0xE0,
        CardTourContinuing = 0xE1,
        CardTourCompleted = 0xE2,
        CardTourOverdue = 0xE3,
        CardTourIncorrectStartReader = 0xE4,
        CardTourNonExistentTour = 0xE5,

    }
}
