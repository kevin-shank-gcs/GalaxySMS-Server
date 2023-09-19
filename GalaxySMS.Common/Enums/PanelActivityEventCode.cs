////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PanelActivityEventCode.cs
//
// summary:	Implements the panel activity event code class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent panel activity event categories. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PanelActivityEventCategory
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the door option. </summary>
        Door,
        /// <summary>   An enum constant representing the input option. </summary>
        Input,
        /// <summary>   An enum constant representing the output option. </summary>
        Output,
        /// <summary>   An enum constant representing the galaxy elevator option. </summary>
        GalaxyElevator,
        /// <summary>   An enum constant representing the otis elevator option. </summary>
        OtisElevator,
        /// <summary>   An enum constant representing the panel option. </summary>
        Panel,
        /// <summary>   An enum constant representing the panel board option. </summary>
        PanelBoard,
        /// <summary>   An enum constant representing the input output group option. </summary>
        InputOutputGroup,
        /// <summary>   An enum constant representing the card tour option. </summary>
        CardTour,
        /// <summary>   An enum constant representing the person option. </summary>
        Person,
        /// <summary>   An enum constant representing the person door option. </summary>
        PersonDoor,
        /// <summary>   An enum constant representing the person input output group option. </summary>
        PersonInputOutputGroup,
        /// <summary>   An enum constant representing the door group option. </summary>
        DoorGroup,
        /// <summary>   An enum constant representing the dsi channel option. </summary>
        DsiChannel
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent panel activity event codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PanelActivityEventCode
    {
        /// <summary>   An enum constant representing the door forced open option. </summary>
		DoorForcedOpen,
        /// <summary>   An enum constant representing the door left open option. </summary>
		DoorLeftOpen,
        /// <summary>   An enum constant representing the door closed option. </summary>
		DoorClosed,
        /// <summary>   An enum constant representing the read error option. </summary>
		ReadError,
        /// <summary>   An enum constant representing the door contact shunted option. </summary>
		DoorContactShunted,
        /// <summary>   An enum constant representing the door request to exit option. </summary>
		DoorRequestToExit,
        /// <summary>   An enum constant representing the door unlock by schedule option. </summary>
		DoorUnlockBySchedule,
        /// <summary>   An enum constant representing the door lock by schedule option. </summary>
		DoorLockBySchedule,
        /// <summary>   An enum constant representing the door delayed unlock option. </summary>
		DoorDelayedUnlock,

        /// <summary>   An enum constant representing the CPU warm reset option. </summary>
		CpuWarmReset,
        /// <summary>   An enum constant representing the CPU cold reset option. </summary>
		CpuColdReset,

        /// <summary>   An enum constant representing the point in trouble open circuit option. </summary>
        PointInTroubleOpenCircuit,
        /// <summary>   An enum constant representing the point trouble short circuit option. </summary>
		PointTroubleShortCircuit,
        /// <summary>   An enum constant representing the point secure unarmed option. </summary>
		PointSecureUnarmed,
        /// <summary>   An enum constant representing the point alarm unarmed option. </summary>
		PointAlarmUnarmed,
        /// <summary>   An enum constant representing the point secure armed option. </summary>
		PointSecureArmed,
        /// <summary>   An enum constant representing the point alarm armed option. </summary>
		PointAlarmArmed,
        /// <summary>   An enum constant representing the point shunted by command option. </summary>
		PointShuntedByCommand,
        /// <summary>   An enum constant representing the point unshunted by command option. </summary>
		PointUnshuntedByCommand,
        /// <summary>
        /// An enum constant representing the point taken out of service by command option.
        /// </summary>
		PointTakenOutOfServiceByCommand,
        /// <summary>
        /// An enum constant representing the point returned to service by command option.
        /// </summary>
		PointReturnedToServiceByCommand,

        /// <summary>   An enum constant representing the output off by schedule option. </summary>
		OutputOffBySchedule,
        /// <summary>   An enum constant representing the output on by schedule option. </summary>
		OutputOnBySchedule,
        /// <summary>   An enum constant representing the output on by command option. </summary>
		OutputOnByCommand,
        /// <summary>   An enum constant representing the output off by command option. </summary>
		OutputOffByCommand,
        /// <summary>
        /// An enum constant representing the output taken out of service by command option.
        /// </summary>
		OutputTakenOutOfServiceByCommand,
        /// <summary>
        /// An enum constant representing the output returned to service by command option.
        /// </summary>
		OutputReturnedToServiceByCommand,

        /// <summary>   An enum constant representing the I/O group disarmed by schedule option. </summary>
		IoGroupDisarmedBySchedule,
        /// <summary>   An enum constant representing the I/O group armed by schedule option. </summary>
		IoGroupArmedBySchedule,
        /// <summary>   An enum constant representing the I/O group armed by command option. </summary>
		IoGroupArmedByCommand,
        /// <summary>   An enum constant representing the I/O group disarmed by command option. </summary>
		IoGroupDisarmedByCommand,
        /// <summary>   An enum constant representing the I/O group shunted by command option. </summary>
		IoGroupShuntedByCommand,
        /// <summary>   An enum constant representing the I/O group unshunted by command option. </summary>
		IoGroupUnshuntedByCommand,
        /// <summary>   An enum constant representing the I/O group arm by card option. </summary>
		IoGroupArmByCard,
        /// <summary>   An enum constant representing the I/O group disarm by card option. </summary>
		IoGroupDisarmByCard,

        /// <summary>   An enum constant representing the device offline option. </summary>
		DeviceOffline,
        /// <summary>   An enum constant representing the device online option. </summary>
		DeviceOnline,
        /// <summary>   An enum constant representing the relay 2 off by schedule option. </summary>
		Relay2OffBySchedule,
        /// <summary>   An enum constant representing the relay 2 on by schedule option. </summary>
		Relay2OnBySchedule,
        /// <summary>
        /// An enum constant representing the door contact trouble open circuit option.
        /// </summary>
		DoorContactTroubleOpenCircuit,
        /// <summary>
        /// An enum constant representing the door contact trouble short circuit option.
        /// </summary>
		DoorContactTroubleShortCircuit,
        /// <summary>   An enum constant representing the door heartbeart alarm option. </summary>
		DoorHeartbeartAlarm,
        /// <summary>   An enum constant representing the door heartbeat restored option. </summary>
		DoorHeartbeatRestored,
        /// <summary>   An enum constant representing the door contact trouble cleared option. </summary>
		DoorContactTroubleCleared,
        /// <summary>   An enum constant representing the board communication stopped option. </summary>
		BoardCommunicationStopped,
        /// <summary>   An enum constant representing the board communication started option. </summary>
		BoardCommunicationStarted,
        /// <summary>   An enum constant representing the reader heartbeat stopped option. </summary>
		ReaderHeartbeatStopped,
        /// <summary>   An enum constant representing the reader heartbeat started option. </summary>
		ReaderHeartbeatStarted,
        /// <summary>   An enum constant representing the reader low battery option. </summary>
		ReaderLowBattery,
        /// <summary>   An enum constant representing the reader battery flat option. </summary>
		ReaderBatteryFlat,
        /// <summary>   An enum constant representing the reader battery ok option. </summary>
		ReaderBatteryOk,

        /// <summary>   An enum constant representing the credential not in panel memory option. </summary>
		CredentialNotInPanelMemory,
        /// <summary>
        /// An enum constant representing the credential not in panel memory reverse option.
        /// </summary>
		CredentialNotInPanelMemoryReverse,
        /// <summary>
        /// An enum constant representing the access granted no card code lookup option.
        /// </summary>
		AccessGrantedNoCardCodeLookup,
        /// <summary>
        /// An enum constant representing the access denied attempt piv card expired option.
        /// </summary>
		AccessDeniedAttemptPivCardExpired,
        /// <summary>   An enum constant representing the access denied option. </summary>
		AccessDenied,
        /// <summary>   An enum constant representing the access granted option. </summary>
		AccessGranted,
        /// <summary>   An enum constant representing the access granted with pin data option. </summary>
		AccessGrantedWithPinData,
        /// <summary>   An enum constant representing the duress option. </summary>
		Duress,
        /// <summary>   An enum constant representing the passback violation option. </summary>
		PassbackViolation,
        /// <summary>   An enum constant representing the incorrect pin entered option. </summary>
		IncorrectPinEntered,
        /// <summary>   An enum constant representing the passback forgiven for user option. </summary>
		PassbackForgivenForUser,
        /// <summary>   An enum constant representing the passback forgiven for all users option. </summary>
		PassbackForgivenForAllUsers,
        /// <summary>   An enum constant representing the credential activated option. </summary>
		CredentialActivated,
        /// <summary>   An enum constant representing the credential deactivated option. </summary>
		CredentialDeactivated,

        /// <summary>   An enum constant representing the otis elevator audit option. </summary>
		OtisElevatorAudit,
        /// <summary>
        /// An enum constant representing the reader radio interference detected option.
        /// </summary>
		ReaderRadioInterferenceDetected,
        /// <summary>
        /// An enum constant representing the reader radio interference cleared option.
        /// </summary>
		ReaderRadioInterferenceCleared,

        /// <summary>   An enum constant representing the reader privacy mode entered option. </summary>
        ReaderPrivacyModeEntered,
        /// <summary>   An enum constant representing the reader privacy mode exited option. </summary>
        ReaderPrivacyModeExited,
        /// <summary>   An enum constant representing the reader office mode entered option. </summary>
		ReaderOfficeModeEntered,
        /// <summary>   An enum constant representing the reader office mode exited option. </summary>
		ReaderOfficeModeExited,
        /// <summary>
        /// An enum constant representing the reader nde magnet alert needs calibrated option.
        /// </summary>
        ReaderNdeMagnetAlertNeedsCalibrated,
        /// <summary>
        /// An enum constant representing the reader nde magnet safe calibrated option.
        /// </summary>
	    ReaderNdeMagnetSafeCalibrated,
        /// <summary>   An enum constant representing the door contact change option. </summary>
	    DoorContactChange,
        /// <summary>   An enum constant representing the veridt reader tamper alarm option. </summary>
        VeridtReaderTamperAlarm,
        /// <summary>   An enum constant representing the veridt reader tamper safe option. </summary>
        VeridtReaderTamperSafe,
        /// <summary>   An enum constant representing the veridt card certificate problem option. </summary>
        VeridtCardCertificateProblem,
        /// <summary>   An enum constant representing the veridt reader factor mode set option. </summary>
        VeridtReaderFactorModeSet,



        /// <summary>   An enum constant representing the CPU tamper restored option. </summary>
		CpuTamperRestored,
        /// <summary>   An enum constant representing the CPU tamper alarm option. </summary>
		CpuTamperAlarm,
        /// <summary>   An enum constant representing the CPU low battery restored option. </summary>
		CpuLowBatteryRestored,
        /// <summary>   An enum constant representing the CPU low battery alarm option. </summary>
		CpuLowBatteryAlarm,
        /// <summary>   An enum constant representing the CPU AC failure restored option. </summary>
		CpuAcFailureRestored,
        /// <summary>   An enum constant representing the CPU AC failure alarm option. </summary>
		CpuAcFailureAlarm,

        /// <summary>   An enum constant representing the emergency unlock inactive option. </summary>
		EmergencyUnlockInactive,
        /// <summary>   An enum constant representing the emergency unlock active option. </summary>
		EmergencyUnlockActive,
        /// <summary>   An enum constant representing the reader tamper alarm option. </summary>
		ReaderTamperAlarm,
        /// <summary>   An enum constant representing the reader tamper restored option. </summary>
		ReaderTamperRestored,
        /// <summary>   An enum constant representing the crisis mode activated option. </summary>
		CrisisModeActivated,
        /// <summary>   An enum constant representing the crisis mode activated option. </summary>
		CrisisModeDeActivated,
        /// <summary>   An enum constant representing the crisis mode activated by command option. </summary>
		CrisisModeActivatedByCommand,
        /// <summary>   An enum constant representing the crisis mode activated by command option. </summary>
        CrisisModeDeActivatedByCommand,
        /// <summary>   An enum constant representing the CPU turn logging on option. </summary>
        CpuTurnLoggingOn,
        /// <summary>   An enum constant representing the CPU turn logging off option. </summary>
        CpuTurnLoggingOff,

        /// <summary>
        /// An enum constant representing the dual serial interface relay board offline option.
        /// </summary>
		DualSerialInterfaceRelayBoardOffline,
        /// <summary>
        /// An enum constant representing the dual serial interface relay board online option.
        /// </summary>
		DualSerialInterfaceRelayBoardOnline,
        /// <summary>
        /// An enum constant representing the dual serial interface door module offline option.
        /// </summary>
		DualSerialInterfaceDoorModuleOffline,
        /// <summary>
        /// An enum constant representing the dual serial interface door module online option.
        /// </summary>
		DualSerialInterfaceDoorModuleOnline,

        /// <summary>   An enum constant representing the card tour starting option. </summary>
		CardTourStarting,
        /// <summary>   An enum constant representing the card tour continuing option. </summary>
		CardTourContinuing,
        /// <summary>   An enum constant representing the card tour completed option. </summary>
		CardTourCompleted,
        /// <summary>   An enum constant representing the card tour overdue option. </summary>
		CardTourOverdue,
        /// <summary>   An enum constant representing the card tour incorrect start reader option. </summary>
		CardTourIncorrectStartReader,
        /// <summary>   An enum constant representing the card tour non existant tour option. </summary>
		CardTourNonExistantTour,


        /// <summary>   An enum constant representing the command unlock door option. </summary>
		CommandUnlockDoor,
        /// <summary>   An enum constant representing the command lock door option. </summary>
		CommandLockDoor,
        /// <summary>   An enum constant representing the command disable door option. </summary>
		CommandDisableDoor,
        /// <summary>   An enum constant representing the command enable door option. </summary>
		CommandEnableDoor,
        /// <summary>   An enum constant representing the command pulse door option. </summary>
		CommandPulseDoor,
        /// <summary>   An enum constant representing the command relay 2 off option. </summary>
		CommandRelay2Off,
        /// <summary>   An enum constant representing the command relay 2 on option. </summary>
		CommandRelay2On,

        /// <summary>   An enum constant representing the command unlock door group option. </summary>
		CommandUnlockDoorGroup,
        /// <summary>   An enum constant representing the command lock door group option. </summary>
		CommandLockDoorGroup,
        /// <summary>   An enum constant representing the command disable door group option. </summary>
		CommandDisableDoorGroup,
        /// <summary>   An enum constant representing the command enable door group option. </summary>
		CommandEnableDoorGroup,


        /// <summary>   An enum constant representing the command shunt I/O group option. </summary>
		CommandShuntIOGroup,
        /// <summary>   An enum constant representing the command unshunt I/O group option. </summary>
		CommandUnshuntIOGroup,
        /// <summary>   An enum constant representing the command disable input option. </summary>
		CommandDisableInput,
        /// <summary>   An enum constant representing the command enable input option. </summary>
		CommandEnableInput,
        /// <summary>   An enum constant representing the command arm I/O group option. </summary>
		CommandArmIOGroup,
        /// <summary>   An enum constant representing the command disarm I/O group option. </summary>
		CommandDisarmIOGroup,
        /// <summary>   An enum constant representing the command shunt input option. </summary>
		CommandShuntInput,
        /// <summary>   An enum constant representing the command unshunt input option. </summary>
		CommandUnshuntInput,

        /// <summary>   An enum constant representing the command output on option. </summary>
		CommandOutputOn,
        /// <summary>   An enum constant representing the command output off option. </summary>
		CommandOutputOff,
        /// <summary>   An enum constant representing the command output enable option. </summary>
		CommandOutputEnable,
        /// <summary>   An enum constant representing the command output disable option. </summary>
		CommandOutputDisable,

        /// <summary>   An enum constant representing the command elevator pulse option. </summary>
		CommandElevatorPulse,
        /// <summary>   An enum constant representing the command elevator early on option. </summary>
		CommandElevatorEarlyOn,
        /// <summary>   An enum constant representing the command elevator early off option. </summary>
		CommandElevatorEarlyOff,
        /// <summary>   An enum constant representing the command elevator cancel early on option. </summary>
		CommandElevatorCancelEarlyOn,
        /// <summary>
        /// An enum constant representing the command elevator cancel early off option.
        /// </summary>
		CommandElevatorCancelEarlyOff,
    }
}
