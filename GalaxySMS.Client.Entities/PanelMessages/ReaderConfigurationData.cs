////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ReaderConfigurationData.cs
//
// summary:	Implements the reader configuration data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent automatic forgive passback times. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AutomaticForgivePassbackTimes { Never = 0, Midnight, MidnightAndNoon, EveryFourHours, EveryTwoHours, EveryHour, EveryHalfHour }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent door group behaviors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum DoorGroupBehavior { Nothing, NotifyGroupButDoNotReactToGroup, ReactToGroupButDoNotNotifyGroup, NotifyAndReact }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent automatic unlock behaviors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AutomaticUnlockBehavior { UnlockImmediately, RequireValidAccess }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent pin required behaviors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum PinRequiredBehavior { None, RequiredForAccessDecision, InformationalOnly, PinSpecifiesRecloseTime }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent door contact supervision types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum DoorContactSupervisionType { None, SeriesOnly, ParallelOnly, BothSeriesAndParallel }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A reader configuration data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class ReaderConfigurationData : BoardSectionNodeHardwareAddress
	{
	    #region Private fields

        /// <summary>   The description. </summary>
	    private string _description;
        /// <summary>   The door illegal open input output group assignment. </summary>
	    private InputOutputGroupAssignment _doorIllegalOpenInputOutputGroupAssignment;
        /// <summary>   The invalid access attempt input output group assignment. </summary>
	    private InputOutputGroupAssignment _invalidAccessAttemptInputOutputGroupAssignment;
        /// <summary>   The passback violation input output group assignment. </summary>
	    private InputOutputGroupAssignment _passbackViolationInputOutputGroupAssignment;
        /// <summary>   The door open too long input output group assignment. </summary>
	    private InputOutputGroupAssignment _doorOpenTooLongInputOutputGroupAssignment;
        /// <summary>   The duress input output group assignment. </summary>
	    private InputOutputGroupAssignment _duressInputOutputGroupAssignment;
        /// <summary>   The door group input output group assignment. </summary>
	    private InputOutputGroupAssignment _doorGroupInputOutputGroupAssignment;
        /// <summary>   The access granted input output group assignment. </summary>
	    private InputOutputGroupAssignment _accessGrantedInputOutputGroupAssignment;
        /// <summary>   The heartbeat stopped input output group assignment. </summary>
	    private InputOutputGroupAssignment _heartbeatStoppedInputOutputGroupAssignment;
        /// <summary>   The lock on input output group event. </summary>
	    private InputOutputGroupNumber _lockOnInputOutputGroupEvent;
        /// <summary>   The unlock on input output group event. </summary>
	    private InputOutputGroupNumber _unlockOnInputOutputGroupEvent;
        /// <summary>   The passback into area. </summary>
	    private PassbackAreaNumber _passbackIntoArea;
        /// <summary>   The passback from area. </summary>
	    private PassbackAreaNumber _passbackFromArea;
        /// <summary>   List of times of the automatic forgive passbacks. </summary>
	    private AutomaticForgivePassbackTimes _automaticForgivePassbackTimes;
        /// <summary>   The free access unlock schedule. </summary>
	    private ScheduleNumber _freeAccessUnlockSchedule;
        /// <summary>   The pin required schedule. </summary>
	    private ScheduleNumber _pinRequiredSchedule;
        /// <summary>   The disable door illegal open schedule. </summary>
	    private ScheduleNumber _disableDoorIllegalOpenSchedule;
        /// <summary>   The disable door open too long schedule. </summary>
	    private ScheduleNumber _disableDoorOpenTooLongSchedule;
        /// <summary>   Duration of the unlock. </summary>
	    private ushort _unlockDuration;
        /// <summary>   Duration of the reclose. </summary>
	    private ushort _recloseDuration;
        /// <summary>   Duration of the unlock delay. </summary>
	    private ushort _unlockDelayDuration;
        /// <summary>   The relay two settings. </summary>
	    private ReaderRelayTwoSettings _relayTwoSettings;
        /// <summary>   The allow access on passback violation. </summary>
	    private YesNo _allowAccessOnPassbackViolation;
        /// <summary>   The two valid credentials required. </summary>
	    private YesNo _twoValidCredentialsRequired;
        /// <summary>   The unlock on request to exit. </summary>
	    private YesNo _unlockOnRequestToExit;
        /// <summary>   Message describing the suppress request to exit. </summary>
	    private YesNo _suppressRequestToExitMessage;
        /// <summary>   The duress enabled. </summary>
	    private YesNo _duressEnabled;
        /// <summary>   The door group behavior. </summary>
	    private DoorGroupBehavior _doorGroupBehavior;
        /// <summary>   The energize relay one during arming delay. </summary>
	    private YesNo _energizeRelayOneDuringArmingDelay;
        /// <summary>   The automatic unlock behavior. </summary>
	    private AutomaticUnlockBehavior _automaticUnlockBehavior;
        /// <summary>   The pin required behavior. </summary>
	    private PinRequiredBehavior _pinRequiredBehavior;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The request to exit input indicates which parallel adapter reader was used.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    private YesNo _requestToExitInputIndicatesWhichParallelAdapterReaderWasUsed;
        /// <summary>   Type of the door contact supervision. </summary>
	    private DoorContactSupervisionType _doorContactSupervisionType;
        /// <summary>   The monitor reader heartbeat. </summary>
	    private YesNo _monitorReaderHeartbeat;
        /// <summary>   Message describing the suppress door illegal open. </summary>
	    private YesNo _suppressDoorIllegalOpenMessage;
        /// <summary>   Message describing the suppress door open too long. </summary>
	    private YesNo _suppressDoorOpenTooLongMessage;
        /// <summary>   Message describing the suppress door close. </summary>
	    private YesNo _suppressDoorCloseMessage;
        /// <summary>   The deenergize relay one when door closes. </summary>
	    private YesNo _deenergizeRelayOneWhenDoorCloses;
        /// <summary>   The first disarm input output group. </summary>
	    private InputOutputGroupNumber _disarmInputOutputGroup1;
        /// <summary>   The second disarm input output group. </summary>
	    private InputOutputGroupNumber _disarmInputOutputGroup2;
        /// <summary>   The third disarm input output group. </summary>
	    private InputOutputGroupNumber _disarmInputOutputGroup3;
        /// <summary>   The fourth disarm input output group. </summary>
	    private InputOutputGroupNumber _disarmInputOutputGroup4;
        /// <summary>   The ignore not in system reads. </summary>
	    private YesNo _ignoreNotInSystemReads;
        /// <summary>   The reader is card tour member. </summary>
	    private YesNo _readerIsCardTourMember;
        /// <summary>   The elevator control board section address. </summary>
	    private BoardSectionHardwareAddress _elevatorControlBoardSectionAddress;
        /// <summary>   The LCD settings. </summary>
	    private ReaderLcdSettings _lcdSettings;
        /// <summary>   The access rule override consult rule. </summary>
	    private AccessDecisionServerConsultationRule _accessRuleOverrideConsultRule;
        /// <summary>   The access rule override server fails to respond behavior. </summary>
	    private AccessDecisionServerFailsToRespondTimeoutBehavior _accessRuleOverrideServerFailsToRespondBehavior;
        /// <summary>   The panel door number. </summary>
	    private PanelDoorNumber _panelDoorNumber;
        /// <summary>   The otis decrement group flags. </summary>
	    private OtisDecGroupFlag _otisDecGroupFlags;
        /// <summary>   The pim number. </summary>
	    private SchlagePimNumber _pimNumber;

	    #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public string Description
	    {
	        get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the door illegal open input output group assignment. </summary>
        ///
        /// <value> The door illegal open input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment DoorIllegalOpenInputOutputGroupAssignment
	    {
	        get { return _doorIllegalOpenInputOutputGroupAssignment; }
            set
            {
                if (_doorIllegalOpenInputOutputGroupAssignment != value)
                {
                    _doorIllegalOpenInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => DoorIllegalOpenInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the invalid access attempt input output group assignment. </summary>
        ///
        /// <value> The invalid access attempt input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment InvalidAccessAttemptInputOutputGroupAssignment
	    {
	        get { return _invalidAccessAttemptInputOutputGroupAssignment; }
            set
            {
                if (_invalidAccessAttemptInputOutputGroupAssignment != value)
                {
                    _invalidAccessAttemptInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => InvalidAccessAttemptInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the passback violation input output group assignment. </summary>
        ///
        /// <value> The passback violation input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment PassbackViolationInputOutputGroupAssignment
	    {
	        get { return _passbackViolationInputOutputGroupAssignment; }
            set
            {
                if (_passbackViolationInputOutputGroupAssignment != value)
                {
                    _passbackViolationInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => PassbackViolationInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the door open too long input output group assignment. </summary>
        ///
        /// <value> The door open too long input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment DoorOpenTooLongInputOutputGroupAssignment
	    {
	        get { return _doorOpenTooLongInputOutputGroupAssignment; }
            set
            {
                if (_doorOpenTooLongInputOutputGroupAssignment != value)
                {
                    _doorOpenTooLongInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => DoorOpenTooLongInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duress input output group assignment. </summary>
        ///
        /// <value> The duress input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment DuressInputOutputGroupAssignment
	    {
	        get { return _duressInputOutputGroupAssignment; }
            set
            {
                if (_duressInputOutputGroupAssignment != value)
                {
                    _duressInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => DuressInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the door group input output group assignment. </summary>
        ///
        /// <value> The door group input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment DoorGroupInputOutputGroupAssignment
	    {
	        get { return _doorGroupInputOutputGroupAssignment; }
            set
            {
                if (_doorGroupInputOutputGroupAssignment != value)
                {
                    _doorGroupInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => DoorGroupInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access granted input output group assignment. </summary>
        ///
        /// <value> The access granted input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment AccessGrantedInputOutputGroupAssignment
	    {
	        get { return _accessGrantedInputOutputGroupAssignment; }
            set
            {
                if (_accessGrantedInputOutputGroupAssignment != value)
                {
                    _accessGrantedInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => AccessGrantedInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the heartbeat stopped input output group assignment. </summary>
        ///
        /// <value> The heartbeat stopped input output group assignment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupAssignment HeartbeatStoppedInputOutputGroupAssignment
	    {
	        get { return _heartbeatStoppedInputOutputGroupAssignment; }
            set
            {
                if (_heartbeatStoppedInputOutputGroupAssignment != value)
                {
                    _heartbeatStoppedInputOutputGroupAssignment = value;
                    OnPropertyChanged(() => HeartbeatStoppedInputOutputGroupAssignment);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lock on input output group event. </summary>
        ///
        /// <value> The lock on input output group event. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber LockOnInputOutputGroupEvent
	    {
	        get { return _lockOnInputOutputGroupEvent; }
            set
            {
                if (_lockOnInputOutputGroupEvent != value)
                {
                    _lockOnInputOutputGroupEvent = value;
                    OnPropertyChanged(() => LockOnInputOutputGroupEvent);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unlock on input output group event. </summary>
        ///
        /// <value> The unlock on input output group event. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber UnlockOnInputOutputGroupEvent
	    {
	        get { return _unlockOnInputOutputGroupEvent; }
            set
            {
                if (_unlockOnInputOutputGroupEvent != value)
                {
                    _unlockOnInputOutputGroupEvent = value;
                    OnPropertyChanged(() => UnlockOnInputOutputGroupEvent);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the passback into area. </summary>
        ///
        /// <value> The passback into area. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public PassbackAreaNumber PassbackIntoArea
	    {
	        get { return _passbackIntoArea; }
            set
            {
                if (_passbackIntoArea != value)
                {
                    _passbackIntoArea = value;
                    OnPropertyChanged(() => PassbackIntoArea);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the passback from area. </summary>
        ///
        /// <value> The passback from area. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public PassbackAreaNumber PassbackFromArea
	    {
	        get { return _passbackFromArea; }
            set
            {
                if (_passbackFromArea != value)
                {
                    _passbackFromArea = value;
                    OnPropertyChanged(() => PassbackFromArea);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of times of the automatic forgive passbacks. </summary>
        ///
        /// <value> A list of times of the automatic forgive passbacks. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AutomaticForgivePassbackTimes AutomaticForgivePassbackTimes
	    {
	        get { return _automaticForgivePassbackTimes; }
            set
            {
                if (_automaticForgivePassbackTimes != value)
                {
                    _automaticForgivePassbackTimes = value;
                    OnPropertyChanged(() => AutomaticForgivePassbackTimes);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the free access unlock schedule. </summary>
        ///
        /// <value> The free access unlock schedule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ScheduleNumber FreeAccessUnlockSchedule
	    {
	        get { return _freeAccessUnlockSchedule; }
            set
            {
                if (_freeAccessUnlockSchedule != value)
                {
                    _freeAccessUnlockSchedule = value;
                    OnPropertyChanged(() => FreeAccessUnlockSchedule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pin required schedule. </summary>
        ///
        /// <value> The pin required schedule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ScheduleNumber PinRequiredSchedule
	    {
	        get { return _pinRequiredSchedule; }
            set
            {
                if (_pinRequiredSchedule != value)
                {
                    _pinRequiredSchedule = value;
                    OnPropertyChanged(() => PinRequiredSchedule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disable door illegal open schedule. </summary>
        ///
        /// <value> The disable door illegal open schedule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ScheduleNumber DisableDoorIllegalOpenSchedule
	    {
	        get { return _disableDoorIllegalOpenSchedule; }
            set
            {
                if (_disableDoorIllegalOpenSchedule != value)
                {
                    _disableDoorIllegalOpenSchedule = value;
                    OnPropertyChanged(() => DisableDoorIllegalOpenSchedule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disable door open too long schedule. </summary>
        ///
        /// <value> The disable door open too long schedule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ScheduleNumber DisableDoorOpenTooLongSchedule
	    {
	        get { return _disableDoorOpenTooLongSchedule; }
            set
            {
                if (_disableDoorOpenTooLongSchedule != value)
                {
                    _disableDoorOpenTooLongSchedule = value;
                    OnPropertyChanged(() => DisableDoorOpenTooLongSchedule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duration of the unlock. </summary>
        ///
        /// <value> The unlock duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 UnlockDuration
	    {
	        get { return _unlockDuration; }
            set
            {
                if (_unlockDuration != value)
                {
                    _unlockDuration = value;
                    OnPropertyChanged(() => UnlockDuration);
                }
            }
        } // hundredths of seconds

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duration of the reclose. </summary>
        ///
        /// <value> The reclose duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 RecloseDuration
	    {
	        get { return _recloseDuration; }
            set
            {
                if (_recloseDuration != value)
                {
                    _recloseDuration = value;
                    OnPropertyChanged(() => RecloseDuration);
                }
            }
        } // hundredths of seconds

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duration of the unlock delay. </summary>
        ///
        /// <value> The unlock delay duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 UnlockDelayDuration
	    {
	        get { return _unlockDelayDuration; }
            set
            {
                if (_unlockDelayDuration != value)
                {
                    _unlockDelayDuration = value;
                    OnPropertyChanged(() => UnlockDelayDuration);
                }
            }
        } // hundredths of seconds

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the relay two settings. </summary>
        ///
        /// <value> The relay two settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ReaderRelayTwoSettings RelayTwoSettings
	    {
	        get { return _relayTwoSettings; }
            set
            {
                if (_relayTwoSettings != value)
                {
                    _relayTwoSettings = value;
                    OnPropertyChanged(() => RelayTwoSettings);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the allow access on passback violation. </summary>
        ///
        /// <value> The allow access on passback violation. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo AllowAccessOnPassbackViolation
	    {
	        get { return _allowAccessOnPassbackViolation; }
            set
            {
                if (_allowAccessOnPassbackViolation != value)
                {
                    _allowAccessOnPassbackViolation = value;
                    OnPropertyChanged(() => AllowAccessOnPassbackViolation);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the two valid credentials required. </summary>
        ///
        /// <value> The two valid credentials required. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo TwoValidCredentialsRequired
	    {
	        get { return _twoValidCredentialsRequired; }
            set
            {
                if (_twoValidCredentialsRequired != value)
                {
                    _twoValidCredentialsRequired = value;
                    OnPropertyChanged(() => TwoValidCredentialsRequired);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unlock on request to exit. </summary>
        ///
        /// <value> The unlock on request to exit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo UnlockOnRequestToExit
	    {
	        get { return _unlockOnRequestToExit; }
            set
            {
                if (_unlockOnRequestToExit != value)
                {
                    _unlockOnRequestToExit = value;
                    OnPropertyChanged(() => UnlockOnRequestToExit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the suppress request to exit. </summary>
        ///
        /// <value> A message describing the suppress request to exit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo SuppressRequestToExitMessage
	    {
	        get { return _suppressRequestToExitMessage; }
            set
            {
                if (_suppressRequestToExitMessage != value)
                {
                    _suppressRequestToExitMessage = value;
                    OnPropertyChanged(() => SuppressRequestToExitMessage);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duress enabled. </summary>
        ///
        /// <value> The duress enabled. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo DuressEnabled
	    {
	        get { return _duressEnabled; }
            set
            {
                if (_duressEnabled != value)
                {
                    _duressEnabled = value;
                    OnPropertyChanged(() => DuressEnabled);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the door group behavior. </summary>
        ///
        /// <value> The door group behavior. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public DoorGroupBehavior DoorGroupBehavior
	    {
	        get { return _doorGroupBehavior; }
            set
            {
                if (_doorGroupBehavior != value)
                {
                    _doorGroupBehavior = value;
                    OnPropertyChanged(() => DoorGroupBehavior);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the energize relay one during arming delay. </summary>
        ///
        /// <value> The energize relay one during arming delay. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo EnergizeRelayOneDuringArmingDelay
	    {
	        get { return _energizeRelayOneDuringArmingDelay; }
            set
            {
                if (_energizeRelayOneDuringArmingDelay != value)
                {
                    _energizeRelayOneDuringArmingDelay = value;
                    OnPropertyChanged(() => EnergizeRelayOneDuringArmingDelay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the automatic unlock behavior. </summary>
        ///
        /// <value> The automatic unlock behavior. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AutomaticUnlockBehavior AutomaticUnlockBehavior
	    {
	        get { return _automaticUnlockBehavior; }
            set
            {
                if (_automaticUnlockBehavior != value)
                {
                    _automaticUnlockBehavior = value;
                    OnPropertyChanged(() => AutomaticUnlockBehavior);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pin required behavior. </summary>
        ///
        /// <value> The pin required behavior. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public PinRequiredBehavior PinRequiredBehavior
	    {
	        get { return _pinRequiredBehavior; }
            set
            {
                if (_pinRequiredBehavior != value)
                {
                    _pinRequiredBehavior = value;
                    OnPropertyChanged(() => PinRequiredBehavior);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the request to exit input indicates which parallel adapter reader was used.
        /// </summary>
        ///
        /// <value> The request to exit input indicates which parallel adapter reader was used. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo RequestToExitInputIndicatesWhichParallelAdapterReaderWasUsed
	    {
	        get { return _requestToExitInputIndicatesWhichParallelAdapterReaderWasUsed; }
            set
            {
                if (_requestToExitInputIndicatesWhichParallelAdapterReaderWasUsed != value)
                {
                    _requestToExitInputIndicatesWhichParallelAdapterReaderWasUsed = value;
                    OnPropertyChanged(() => RequestToExitInputIndicatesWhichParallelAdapterReaderWasUsed);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the door contact supervision. </summary>
        ///
        /// <value> The type of the door contact supervision. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public DoorContactSupervisionType DoorContactSupervisionType
	    {
	        get { return _doorContactSupervisionType; }
            set
            {
                if (_doorContactSupervisionType != value)
                {
                    _doorContactSupervisionType = value;
                    OnPropertyChanged(() => DoorContactSupervisionType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the monitor reader heartbeat. </summary>
        ///
        /// <value> The monitor reader heartbeat. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo MonitorReaderHeartbeat
	    {
	        get { return _monitorReaderHeartbeat; }
            set
            {
                if (_monitorReaderHeartbeat != value)
                {
                    _monitorReaderHeartbeat = value;
                    OnPropertyChanged(() => MonitorReaderHeartbeat);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the suppress door illegal open. </summary>
        ///
        /// <value> A message describing the suppress door illegal open. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo SuppressDoorIllegalOpenMessage
	    {
	        get { return _suppressDoorIllegalOpenMessage; }
            set
            {
                if (_suppressDoorIllegalOpenMessage != value)
                {
                    _suppressDoorIllegalOpenMessage = value;
                    OnPropertyChanged(() => SuppressDoorIllegalOpenMessage);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the suppress door open too long. </summary>
        ///
        /// <value> A message describing the suppress door open too long. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo SuppressDoorOpenTooLongMessage
	    {
	        get { return _suppressDoorOpenTooLongMessage; }
            set
            {
                if (_suppressDoorOpenTooLongMessage != value)
                {
                    _suppressDoorOpenTooLongMessage = value;
                    OnPropertyChanged(() => SuppressDoorOpenTooLongMessage);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the suppress door close. </summary>
        ///
        /// <value> A message describing the suppress door close. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo SuppressDoorCloseMessage
	    {
	        get { return _suppressDoorCloseMessage; }
            set
            {
                if (_suppressDoorCloseMessage != value)
                {
                    _suppressDoorCloseMessage = value;
                    OnPropertyChanged(() => SuppressDoorCloseMessage);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the deenergize relay one when door closes. </summary>
        ///
        /// <value> The deenergize relay one when door closes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo DeenergizeRelayOneWhenDoorCloses
	    {
	        get { return _deenergizeRelayOneWhenDoorCloses; }
            set
            {
                if (_deenergizeRelayOneWhenDoorCloses != value)
                {
                    _deenergizeRelayOneWhenDoorCloses = value;
                    OnPropertyChanged(() => DeenergizeRelayOneWhenDoorCloses);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disarm input output group 1. </summary>
        ///
        /// <value> The disarm input output group 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber DisarmInputOutputGroup1
	    {
	        get { return _disarmInputOutputGroup1; }
            set
            {
                if (_disarmInputOutputGroup1 != value)
                {
                    _disarmInputOutputGroup1 = value;
                    OnPropertyChanged(() => DisarmInputOutputGroup1);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disarm input output group 2. </summary>
        ///
        /// <value> The disarm input output group 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber DisarmInputOutputGroup2
	    {
	        get { return _disarmInputOutputGroup2; }
            set
            {
                if (_disarmInputOutputGroup2 != value)
                {
                    _disarmInputOutputGroup2 = value;
                    OnPropertyChanged(() => DisarmInputOutputGroup2);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disarm input output group 3. </summary>
        ///
        /// <value> The disarm input output group 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber DisarmInputOutputGroup3
	    {
	        get { return _disarmInputOutputGroup3; }
            set
            {
                if (_disarmInputOutputGroup3 != value)
                {
                    _disarmInputOutputGroup3 = value;
                    OnPropertyChanged(() => DisarmInputOutputGroup3);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the disarm input output group 4. </summary>
        ///
        /// <value> The disarm input output group 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public InputOutputGroupNumber DisarmInputOutputGroup4
	    {
	        get { return _disarmInputOutputGroup4; }
            set
            {
                if (_disarmInputOutputGroup4 != value)
                {
                    _disarmInputOutputGroup4 = value;
                    OnPropertyChanged(() => DisarmInputOutputGroup4);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the ignore not in system reads. </summary>
        ///
        /// <value> The ignore not in system reads. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo IgnoreNotInSystemReads
	    {
	        get { return _ignoreNotInSystemReads; }
            set
            {
                if (_ignoreNotInSystemReads != value)
                {
                    _ignoreNotInSystemReads = value;
                    OnPropertyChanged(() => IgnoreNotInSystemReads);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the reader is card tour member. </summary>
        ///
        /// <value> The reader is card tour member. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public YesNo ReaderIsCardTourMember
	    {
	        get { return _readerIsCardTourMember; }
            set
            {
                if (_readerIsCardTourMember != value)
                {
                    _readerIsCardTourMember = value;
                    OnPropertyChanged(() => ReaderIsCardTourMember);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the elevator control board section address. </summary>
        ///
        /// <value> The elevator control board section address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public BoardSectionHardwareAddress ElevatorControlBoardSectionAddress
	    {
	        get { return _elevatorControlBoardSectionAddress; }
            set
            {
                if (_elevatorControlBoardSectionAddress != value)
                {
                    _elevatorControlBoardSectionAddress = value;
                    OnPropertyChanged(() => ElevatorControlBoardSectionAddress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the LCD settings. </summary>
        ///
        /// <value> The LCD settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ReaderLcdSettings LcdSettings
	    {
	        get { return _lcdSettings; }
            set
            {
                if (_lcdSettings != value)
                {
                    _lcdSettings = value;
                    OnPropertyChanged(() => LcdSettings);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access rule override consult rule. </summary>
        ///
        /// <value> The access rule override consult rule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AccessDecisionServerConsultationRule AccessRuleOverrideConsultRule
	    {
	        get { return _accessRuleOverrideConsultRule; }
            set
            {
                if (_accessRuleOverrideConsultRule != value)
                {
                    _accessRuleOverrideConsultRule = value;
                    OnPropertyChanged(() => AccessRuleOverrideConsultRule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the access rule override server fails to respond behavior.
        /// </summary>
        ///
        /// <value> The access rule override server fails to respond behavior. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AccessDecisionServerFailsToRespondTimeoutBehavior AccessRuleOverrideServerFailsToRespondBehavior
	    {
	        get { return _accessRuleOverrideServerFailsToRespondBehavior; }
            set
            {
                if (_accessRuleOverrideServerFailsToRespondBehavior != value)
                {
                    _accessRuleOverrideServerFailsToRespondBehavior = value;
                    OnPropertyChanged(() => AccessRuleOverrideServerFailsToRespondBehavior);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel door number. </summary>
        ///
        /// <value> The panel door number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public PanelDoorNumber PanelDoorNumber
	    {
	        get { return _panelDoorNumber; }
            set
            {
                if (_panelDoorNumber != value)
                {
                    _panelDoorNumber = value;
                    OnPropertyChanged(() => PanelDoorNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the otis decrement group flags. </summary>
        ///
        /// <value> The otis decrement group flags. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public OtisDecGroupFlag OtisDecGroupFlags
	    {
	        get { return _otisDecGroupFlags; }
            set
            {
                if (_otisDecGroupFlags != value)
                {
                    _otisDecGroupFlags = value;
                    OnPropertyChanged(() => OtisDecGroupFlags);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pim number. </summary>
        ///
        /// <value> The pim number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public SchlagePimNumber PimNumber
	    {
	        get { return _pimNumber; }
            set
            {
                if (_pimNumber != value)
                {
                    _pimNumber = value;
                    OnPropertyChanged(() => PimNumber);
                }
            }
        }
	}
}
