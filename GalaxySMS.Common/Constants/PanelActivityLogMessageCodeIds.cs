////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PanelActivityLogMessageCodeIds.cs
//
// summary:	Implements the panel activity log message code identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel activity log message code identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PanelActivityLogMessageCodeIds
    {
        /// <summary>   The door forced open. </summary>
        public static readonly Guid DoorForcedOpen = new Guid("00000000-0000-0000-0001-000000000000");
        /// <summary>   The door left open. </summary>
        public static readonly Guid DoorLeftOpen = new Guid("00000000-0000-0000-0001-000000000001");
        /// <summary>   The door closed. </summary>
        public static readonly Guid DoorClosed = new Guid("00000000-0000-0000-0001-000000000002");
        /// <summary>   The read error. </summary>
        public static readonly Guid ReadError = new Guid("00000000-0000-0000-0001-000000000003");
        /// <summary>   The door contact shunted. </summary>
        public static readonly Guid DoorContactShunted = new Guid("00000000-0000-0000-0001-000000000004");
        /// <summary>   The door request to exit. </summary>
        public static readonly Guid DoorRequestToExit = new Guid("00000000-0000-0000-0001-000000000005");
        /// <summary>   The door unlock by schedule. </summary>
        public static readonly Guid DoorUnlockBySchedule = new Guid("00000000-0000-0000-0001-000000000006");
        /// <summary>   The door lock by schedule. </summary>
        public static readonly Guid DoorLockBySchedule = new Guid("00000000-0000-0000-0001-000000000007");
        /// <summary>   The CPU warm reset. </summary>
        public static readonly Guid CpuWarmReset = new Guid("00000000-0000-0000-0001-00000000000B");
        /// <summary>   The CPU cold reset. </summary>
        public static readonly Guid CpuColdReset = new Guid("00000000-0000-0000-0001-00000000000C");
        /// <summary>   The door delayed unlock. </summary>
        public static readonly Guid DoorDelayedUnlock = new Guid("00000000-0000-0000-0001-00000000000D");

        /// <summary>   The point in trouble open circuit. </summary>
        public static readonly Guid PointInTroubleOpenCircuit = new Guid("00000000-0000-0000-0001-000000000010");
        /// <summary>   The point trouble short circuit. </summary>
        public static readonly Guid PointTroubleShortCircuit = new Guid("00000000-0000-0000-0001-000000000011");
        /// <summary>   The point secure unarmed. </summary>
        public static readonly Guid PointSecureUnarmed = new Guid("00000000-0000-0000-0001-000000000012");
        /// <summary>   The point alarm unarmed. </summary>
        public static readonly Guid PointAlarmUnarmed = new Guid("00000000-0000-0000-0001-000000000013");
        /// <summary>   The point secure armed. </summary>
        public static readonly Guid PointSecureArmed = new Guid("00000000-0000-0000-0001-000000000014");
        /// <summary>   The point alarm armed. </summary>
        public static readonly Guid PointAlarmArmed = new Guid("00000000-0000-0000-0001-000000000015");
        /// <summary>   The point shunted by command. </summary>
        public static readonly Guid PointShuntedByCommand = new Guid("00000000-0000-0000-0001-000000009336");
        /// <summary>   The point unshunted by command. </summary>
        public static readonly Guid PointUnshuntedByCommand = new Guid("00000000-0000-0000-0001-000000009337");
        /// <summary>   The point taken out of service by command. </summary>
        public static readonly Guid PointTakenOutOfServiceByCommand = new Guid("00000000-0000-0000-0001-000000009332");
        /// <summary>   The point returned to service by command. </summary>
        public static readonly Guid PointReturnedToServiceByCommand = new Guid("00000000-0000-0000-0001-000000009333");

        /// <summary>   The output off by schedule. </summary>
        public static readonly Guid OutputOffBySchedule = new Guid("00000000-0000-0000-0001-000000000018");
        /// <summary>   The output on by schedule. </summary>
        public static readonly Guid OutputOnBySchedule = new Guid("00000000-0000-0000-0001-000000000019");
        /// <summary>   The output on by command. </summary>
        public static readonly Guid OutputOnByCommand = new Guid("00000000-0000-0000-0001-000000009440");
        /// <summary>   The output off by command. </summary>
        public static readonly Guid OutputOffByCommand = new Guid("00000000-0000-0000-0001-000000009441");
        /// <summary>   The output taken out of service by command. </summary>
        public static readonly Guid OutputTakenOutOfServiceByCommand = new Guid("00000000-0000-0000-0001-000000009443");
        /// <summary>   The output returned to service by command. </summary>
        public static readonly Guid OutputReturnedToServiceByCommand = new Guid("00000000-0000-0000-0001-000000009442");

        /// <summary>   The i/o group disarmed by schedule. </summary>
        public static readonly Guid IoGroupDisarmedBySchedule = new Guid("00000000-0000-0000-0001-000000000016");
        /// <summary>   The i/o group armed by schedule. </summary>
        public static readonly Guid IoGroupArmedBySchedule = new Guid("00000000-0000-0000-0001-000000000017");
        /// <summary>   The i/o group armed by command. </summary>
        public static readonly Guid IoGroupArmedByCommand = new Guid("00000000-0000-0000-0001-00000000001a");
        /// <summary>   The i/o group disarmed by command. </summary>
        public static readonly Guid IoGroupDisarmedByCommand = new Guid("00000000-0000-0000-0001-00000000001b");
        /// <summary>   The i/o group shunted by command. </summary>
        public static readonly Guid IoGroupShuntedByCommand = new Guid("00000000-0000-0000-0001-000000009230");
        /// <summary>   The i/o group unshunted by command. </summary>
        public static readonly Guid IoGroupUnshuntedByCommand = new Guid("00000000-0000-0000-0001-000000009231");
        /// <summary>   The i/o group arm by card. </summary>
        public static readonly Guid IoGroupArmByCard = new Guid("00000000-0000-0000-0001-000000000045");
        /// <summary>   The i/o group disarm by card. </summary>
        public static readonly Guid IoGroupDisarmByCard = new Guid("00000000-0000-0000-0001-000000000046");

        /// <summary>   The device offline. </summary>
        public static readonly Guid DeviceOffline = new Guid("00000000-0000-0000-0001-00000000001C");
        /// <summary>   The device online. </summary>
        public static readonly Guid DeviceOnline = new Guid("00000000-0000-0000-0001-00000000001C");
        /// <summary>   The relay 2 off by schedule. </summary>
        public static readonly Guid Relay2OffBySchedule = new Guid("00000000-0000-0000-0001-000000000020");
        /// <summary>   The relay 2 on by schedule. </summary>
        public static readonly Guid Relay2OnBySchedule = new Guid("00000000-0000-0000-0001-000000000021");
        /// <summary>   The door contact trouble open circuit. </summary>
        public static readonly Guid DoorContactTroubleOpenCircuit = new Guid("00000000-0000-0000-0001-000000000023");
        /// <summary>   The door contact trouble short circuit. </summary>
        public static readonly Guid DoorContactTroubleShortCircuit = new Guid("00000000-0000-0000-0001-000000000024");
        /// <summary>   The door heartbeart alarm. </summary>
        public static readonly Guid DoorHeartbeartAlarm = new Guid("00000000-0000-0000-0001-000000000025");
        /// <summary>   The door heartbeat restored. </summary>
        public static readonly Guid DoorHeartbeatRestored = new Guid("00000000-0000-0000-0001-000000000026");
        /// <summary>   The door contact trouble cleared. </summary>
        public static readonly Guid DoorContactTroubleCleared = new Guid("00000000-0000-0000-0001-000000000027");
        /// <summary>   The board communication stopped. </summary>
        public static readonly Guid BoardCommunicationStopped = new Guid("00000000-0000-0000-0001-000000000028");
        /// <summary>   The board communication started. </summary>
        public static readonly Guid BoardCommunicationStarted = new Guid("00000000-0000-0000-0001-000000000029");
        /// <summary>   The reader heartbeat stopped. </summary>
        public static readonly Guid ReaderHeartbeatStopped = new Guid("00000000-0000-0000-0001-00000000002A");
        /// <summary>   The reader heartbeat started. </summary>
        public static readonly Guid ReaderHeartbeatStarted = new Guid("00000000-0000-0000-0001-00000000002B");
        /// <summary>   The reader low battery. </summary>
        public static readonly Guid ReaderLowBattery = new Guid("00000000-0000-0000-0001-00000000002C");
        /// <summary>   The reader battery flat. </summary>
        public static readonly Guid ReaderBatteryFlat = new Guid("00000000-0000-0000-0001-00000000002D");
        /// <summary>   The reader battery ok. </summary>
        public static readonly Guid ReaderBatteryOk = new Guid("00000000-0000-0000-0001-00000000002E");

        /// <summary>   The credential not in panel memory. </summary>
        public static readonly Guid CredentialNotInPanelMemory = new Guid("00000000-0000-0000-0001-000000000030");
        /// <summary>   The credential not in panel memory reverse. </summary>
        public static readonly Guid CredentialNotInPanelMemoryReverse = new Guid("00000000-0000-0000-0001-000000000031");
        /// <summary>   The access granted no card code lookup. </summary>
        public static readonly Guid AccessGrantedNoCardCodeLookup = new Guid("00000000-0000-0000-0001-000000000032");
        /// <summary>   The access denied attempt piv card expired. </summary>
        public static readonly Guid AccessDeniedAttemptPivCardExpired = new Guid("00000000-0000-0000-0001-000000000033");
        /// <summary>   The access denied. </summary>
        public static readonly Guid AccessDenied = new Guid("00000000-0000-0000-0001-000000000040");
        /// <summary>   The access granted. </summary>
        public static readonly Guid AccessGranted = new Guid("00000000-0000-0000-0001-000000000041");
        /// <summary>   Information describing the access granted with pin. </summary>
        public static readonly Guid AccessGrantedWithPinData = new Guid("00000000-0000-0000-0001-000000000048");
        /// <summary>   The duress. </summary>
        public static readonly Guid Duress = new Guid("00000000-0000-0000-0001-000000000042");
        /// <summary>   The passback violation. </summary>
        public static readonly Guid PassbackViolation = new Guid("00000000-0000-0000-0001-000000000043");
        /// <summary>   The incorrect pin entered. </summary>
        public static readonly Guid IncorrectPinEntered = new Guid("00000000-0000-0000-0001-000000000044");
        /// <summary>   The passback forgiven for user. </summary>
        public static readonly Guid PassbackForgivenForUser = new Guid("00000000-0000-0000-0001-000000009674");
        /// <summary>   The passback forgiven for all users. </summary>
        public static readonly Guid PassbackForgivenForAllUsers = new Guid("00000000-0000-0000-0001-000000009775");
        /// <summary>   The credential activated. </summary>
        public static readonly Guid CredentialActivated = new Guid("00000000-0000-0000-0001-000000009677");
        /// <summary>   The credential deactivated. </summary>
        public static readonly Guid CredentialDeactivated = new Guid("00000000-0000-0000-0001-000000009678");

        /// <summary>   The otis elevator audit. </summary>
        public static readonly Guid OtisElevatorAudit = new Guid("00000000-0000-0000-0001-000000000049");
        /// <summary>   The reader radio interference detected. </summary>
        public static readonly Guid ReaderRadioInterferenceDetected = new Guid("00000000-0000-0000-0001-000000000050");
        /// <summary>   The reader radio interference cleared. </summary>
        public static readonly Guid ReaderRadioInterferenceCleared = new Guid("00000000-0000-0000-0001-000000000051");

        /// <summary>   The CPU tamper restored. </summary>
        public static readonly Guid CpuTamperRestored = new Guid("00000000-0000-0000-0001-000000000060");
        /// <summary>   The CPU tamper alarm. </summary>
        public static readonly Guid CpuTamperAlarm = new Guid("00000000-0000-0000-0001-000000000061");
        /// <summary>   The CPU low battery restored. </summary>
        public static readonly Guid CpuLowBatteryRestored = new Guid("00000000-0000-0000-0001-000000000062");
        /// <summary>   The CPU low battery alarm. </summary>
        public static readonly Guid CpuLowBatteryAlarm = new Guid("00000000-0000-0000-0001-000000000063");
        /// <summary>   The CPU AC failure restored. </summary>
        public static readonly Guid CpuAcFailureRestored = new Guid("00000000-0000-0000-0001-000000000064");
        /// <summary>   The CPU AC failure alarm. </summary>
        public static readonly Guid CpuAcFailureAlarm = new Guid("00000000-0000-0000-0001-000000000065");

        /// <summary>   The emergency unlock inactive. </summary>
        public static readonly Guid EmergencyUnlockInactive = new Guid("00000000-0000-0000-0001-000000000066");
        /// <summary>   The emergency unlock active. </summary>
        public static readonly Guid EmergencyUnlockActive = new Guid("00000000-0000-0000-0001-000000000067");
        /// <summary>   The reader tamper alarm. </summary>
        public static readonly Guid ReaderTamperAlarm = new Guid("00000000-0000-0000-0001-000000000068");
        /// <summary>   The reader tamper restored. </summary>
        public static readonly Guid ReaderTamperRestored = new Guid("00000000-0000-0000-0001-000000000069");
        /// <summary>   The crisis mode activated. </summary>
        public static readonly Guid CrisisModeActivated = new Guid("00000000-0000-0000-0001-000000000022");
        /// <summary>   The crisis mode activated. </summary>
        public static readonly Guid CrisisModeDeActivated = new Guid("00000000-0000-0000-0001-000000000056");
        /// <summary>   The crisis mode activated by command. </summary>
        public static readonly Guid CrisisModeDeActivatedByCommand = new Guid("00000000-0000-0000-0001-00000000977D");
        /// <summary>   The crisis mode activated by command. </summary>
        public static readonly Guid CrisisModeActivatedByCommand = new Guid("00000000-0000-0000-0001-00000000977E");
        /// <summary>   The CPU turn logging on. </summary>
        public static readonly Guid CpuTurnLoggingOn = new Guid("00000000-0000-0000-0001-000000009761");
        /// <summary>   The CPU turn logging off. </summary>
        public static readonly Guid CpuTurnLoggingOff = new Guid("00000000-0000-0000-0001-000000009760");

        /// <summary>   The dual serial interface relay board offline. </summary>
        public static readonly Guid DualSerialInterfaceRelayBoardOffline = new Guid("00000000-0000-0000-0001-000000000088");
        /// <summary>   The dual serial interface relay board online. </summary>
        public static readonly Guid DualSerialInterfaceRelayBoardOnline = new Guid("00000000-0000-0000-0001-000000000089");
        /// <summary>   The dual serial interface door module offline. </summary>
        public static readonly Guid DualSerialInterfaceDoorModuleOffline = new Guid("00000000-0000-0000-0001-00000000008A");
        /// <summary>   The dual serial interface door module online. </summary>
        public static readonly Guid DualSerialInterfaceDoorModuleOnline = new Guid("00000000-0000-0000-0001-00000000008B");

        /// <summary>   The card tour starting. </summary>
        public static readonly Guid CardTourStarting = new Guid("00000000-0000-0000-0001-0000000000E0");
        /// <summary>   The card tour continuing. </summary>
        public static readonly Guid CardTourContinuing = new Guid("00000000-0000-0000-0001-0000000000E1");
        /// <summary>   The card tour completed. </summary>
        public static readonly Guid CardTourCompleted = new Guid("00000000-0000-0000-0001-0000000000E2");
        /// <summary>   The card tour overdue. </summary>
        public static readonly Guid CardTourOverdue = new Guid("00000000-0000-0000-0001-0000000000E3");
        /// <summary>   The card tour incorrect start reader. </summary>
        public static readonly Guid CardTourIncorrectStartReader = new Guid("00000000-0000-0000-0001-0000000000E4");
        /// <summary>   The card tour non existant tour. </summary>
        public static readonly Guid CardTourNonExistantTour = new Guid("00000000-0000-0000-0001-0000000000E5");

        /// <summary>   The command unlock door. </summary>
        public static readonly Guid CommandUnlockDoor = new Guid("00000000-0000-0000-0001-000000009021");
        /// <summary>   The command lock door. </summary>
        public static readonly Guid CommandLockDoor = new Guid("00000000-0000-0000-0001-000000009022");
        /// <summary>   The command disable door. </summary>
        public static readonly Guid CommandDisableDoor = new Guid("00000000-0000-0000-0001-000000009023");
        /// <summary>   The command enable door. </summary>
        public static readonly Guid CommandEnableDoor = new Guid("00000000-0000-0000-0001-000000009024");
        /// <summary>   The command pulse door. </summary>
        public static readonly Guid CommandPulseDoor = new Guid("00000000-0000-0000-0001-000000009025");
        /// <summary>   The command relay 2 off. </summary>
        public static readonly Guid CommandRelay2Off = new Guid("00000000-0000-0000-0001-00000000902A");
        /// <summary>   The command relay 2 on. </summary>
        public static readonly Guid CommandRelay2On = new Guid("00000000-0000-0000-0001-00000000902D");

        /// <summary>   Group the command unlock door belongs to. </summary>
        public static readonly Guid CommandUnlockDoorGroup = new Guid("00000000-0000-0000-0001-000000009126");
        /// <summary>   Group the command lock door belongs to. </summary>
        public static readonly Guid CommandLockDoorGroup = new Guid("00000000-0000-0000-0001-000000009127");
        /// <summary>   Group the command disable door belongs to. </summary>
        public static readonly Guid CommandDisableDoorGroup = new Guid("00000000-0000-0000-0001-000000009128");
        /// <summary>   Group the command enable door belongs to. </summary>
        public static readonly Guid CommandEnableDoorGroup = new Guid("00000000-0000-0000-0001-000000009129");

        /// <summary>   Group the command shunt i/o belongs to. </summary>
        public static readonly Guid CommandShuntIOGroup = new Guid("00000000-0000-0000-0001-000000009230");
        /// <summary>   Group the command unshunt i/o belongs to. </summary>
        public static readonly Guid CommandUnshuntIOGroup = new Guid("00000000-0000-0000-0001-000000009231");
        /// <summary>   The command disable input. </summary>
        public static readonly Guid CommandDisableInput = new Guid("00000000-0000-0000-0001-000000009332");
        /// <summary>   The command enable input. </summary>
        public static readonly Guid CommandEnableInput = new Guid("00000000-0000-0000-0001-000000009333");
        /// <summary>   Group the command arm i/o belongs to. </summary>
        public static readonly Guid CommandArmIOGroup = new Guid("00000000-0000-0000-0001-000000009234");
        /// <summary>   Group the command disarm i/o belongs to. </summary>
        public static readonly Guid CommandDisarmIOGroup = new Guid("00000000-0000-0000-0001-000000009235");
        /// <summary>   The command shunt input. </summary>
        public static readonly Guid CommandShuntInput = new Guid("00000000-0000-0000-0001-000000009336");
        /// <summary>   The command unshunt input. </summary>
        public static readonly Guid CommandUnshuntInput = new Guid("00000000-0000-0000-0001-000000009337");

        /// <summary>   The command output on. </summary>
        public static readonly Guid CommandOutputOn = new Guid("00000000-0000-0000-0001-000000009440");
        /// <summary>   The command output off. </summary>
        public static readonly Guid CommandOutputOff = new Guid("00000000-0000-0000-0001-000000009441");
        /// <summary>   The command output enable. </summary>
        public static readonly Guid CommandOutputEnable = new Guid("00000000-0000-0000-0001-000000009442");
        /// <summary>   The command output disable. </summary>
        public static readonly Guid CommandOutputDisable = new Guid("00000000-0000-0000-0001-000000009443");

        /// <summary>   The command elevator pulse. </summary>
        public static readonly Guid CommandElevatorPulse = new Guid("00000000-0000-0000-0001-000000009550");
        /// <summary>   The command elevator early on. </summary>
        public static readonly Guid CommandElevatorEarlyOn = new Guid("00000000-0000-0000-0001-000000009551");
        /// <summary>   The command elevator early off. </summary>
        public static readonly Guid CommandElevatorEarlyOff = new Guid("00000000-0000-0000-0001-000000009552");
        /// <summary>   The command elevator cancel early on. </summary>
        public static readonly Guid CommandElevatorCancelEarlyOn = new Guid("00000000-0000-0000-0001-000000009553");
        /// <summary>   The command elevator cancel early off. </summary>
        public static readonly Guid CommandElevatorCancelEarlyOff = new Guid("00000000-0000-0000-0001-000000009554");

        /// <summary>   The reader privacy mode entered. </summary>
        public static readonly Guid ReaderPrivacyModeEntered = new Guid("00000000-0000-0000-0001-000000000052");
        /// <summary>   The reader privacy mode exited. </summary>
        public static readonly Guid ReaderPrivacyModeExited = new Guid("00000000-0000-0000-0001-000000000053");
        /// <summary>   The reader office mode entered. </summary>
        public static readonly Guid ReaderOfficeModeEntered = new Guid("00000000-0000-0000-0001-000000000054");
        /// <summary>   The reader office mode exited. </summary>
        public static readonly Guid ReaderOfficeModeExited = new Guid("00000000-0000-0000-0001-000000000055");
        /// <summary>   The reader nde magnet alert needs calibrated. </summary>
        public static readonly Guid ReaderNdeMagnetAlertNeedsCalibrated = new Guid("00000000-0000-0000-0001-000000000057");
        /// <summary>   The reader nde magnet safe calibrated. </summary>
        public static readonly Guid ReaderNdeMagnetSafeCalibrated = new Guid("00000000-0000-0000-0001-000000000058");
        /// <summary>   The door contact change. </summary>
        public static readonly Guid DoorContactChange = new Guid("00000000-0000-0000-0001-000000000059");
        /// <summary>   The veridt reader tamper alarm. </summary>
        public static readonly Guid VeridtReaderTamperAlarm = new Guid("00000000-0000-0000-0001-00000000005A");
        /// <summary>   The veridt reader tamper safe. </summary>
        public static readonly Guid VeridtReaderTamperSafe = new Guid("00000000-0000-0000-0001-00000000005B");
        /// <summary>   The veridt card certificate problem. </summary>
        public static readonly Guid VeridtCardCertificateProblem = new Guid("00000000-0000-0000-0001-00000000005C");
        /// <summary>   Set the veridt reader factor mode belongs to. </summary>
        public static readonly Guid VeridtReaderFactorModeSet = new Guid("00000000-0000-0000-0001-00000000005D");


    }

}
