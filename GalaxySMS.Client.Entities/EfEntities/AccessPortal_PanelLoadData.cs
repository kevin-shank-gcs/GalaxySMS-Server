////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\AccessPortal_PanelLoadData.cs
//
// summary:	Implements the access portal panel load data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal panel load data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [DataContract]
    public partial class AccessPortal_PanelLoadData : ObjectBase
    {
        #region Private Variables
        /// <summary>   The access portal UID. </summary>
        private Guid _AccessPortalUid = Guid.NewGuid();
        /// <summary>   The cluster UID. </summary>
        private Guid _ClusterUid = Guid.NewGuid();
        /// <summary>   The galaxy panel UID. </summary>
        private Guid _GalaxyPanelUid = Guid.NewGuid();
        /// <summary>   The galaxy interface board UID. </summary>
        private Guid _GalaxyInterfaceBoardUid = Guid.NewGuid();
        /// <summary>   The galaxy interface board section UID. </summary>
        private Guid _GalaxyInterfaceBoardSectionUid = Guid.NewGuid();
        /// <summary>   The galaxy hardware module UID. </summary>
        private Guid _GalaxyHardwareModuleUid = Guid.NewGuid();
        /// <summary>   The galaxy interface board section node UID. </summary>
        private Guid _GalaxyInterfaceBoardSectionNodeUid = Guid.NewGuid();
        /// <summary>   Name of the portal. </summary>
        private string _PortalName = string.Empty;
        /// <summary>   The account code. </summary>
        private int _clusterGroupId = 0;
        /// <summary>   The cluster number. </summary>
        private int _ClusterNumber = 0;
        /// <summary>   The panel number. </summary>
        private int _PanelNumber = 0;
        /// <summary>   The board number. </summary>
        private short _BoardNumber = 0;
        /// <summary>   The section number. </summary>
        private short _SectionNumber = 0;
        /// <summary>   The module number. </summary>
        private short _ModuleNumber = 0;
        /// <summary>   The node number. </summary>
        private short _NodeNumber = 0;
        /// <summary>   The door number. </summary>
        private short _DoorNumber = 0;
        /// <summary>   Information describing the access portal type. </summary>
        private string _AccessPortalTypeDescription = string.Empty;
        /// <summary>   Name of the reader type. </summary>
        private string _ReaderTypeName = string.Empty;
        /// <summary>   The panel data format code. </summary>
        private int _PanelDataFormatCode = 0;
        /// <summary>   Name of the data format. </summary>
        private string _DataFormatName = string.Empty;
        /// <summary>   The access portal board section mode. </summary>
        private short _AccessPortalBoardSectionMode = 0;
        /// <summary>   The access portal board section mode display. </summary>
        private string _AccessPortalBoardSectionModeDisplay = string.Empty;
        /// <summary>   The access portal panel model type code. </summary>
        private string _AccessPortalPanelModelTypeCode = string.Empty;
        /// <summary>   The access portal CPU type code. </summary>
        private string _AccessPortalCpuTypeCode = string.Empty;
        /// <summary>   The access portal board type model. </summary>
        private string _AccessPortalBoardTypeModel = string.Empty;
        /// <summary>   The access portal board type code. </summary>
        private short _AccessPortalBoardTypeTypeCode = 0;
        /// <summary>   The access portal board type display. </summary>
        private string _AccessPortalBoardTypeDisplay = string.Empty;
        /// <summary>   The unlock delay. </summary>
        private int _UnlockDelay = 0;
        /// <summary>   Duration of the unlock. </summary>
        private int _UnlockDuration = 0;
        /// <summary>   Duration of the reclose. </summary>
        private int _RecloseDuration = 0;
        /// <summary>   The allow passback access. </summary>
        private bool? _AllowPassbackAccess = false;
        /// <summary>   The require two valid credentials. </summary>
        private bool? _RequireTwoValidCredentials = false;
        /// <summary>   The unlock on rex. </summary>
        private bool? _UnlockOnREX = false;
        /// <summary>   The suppress illegal open log. </summary>
        private bool? _SuppressIllegalOpenLog = false;
        /// <summary>   The suppress open too long log. </summary>
        private bool? _SuppressOpenTooLongLog = false;
        /// <summary>   The suppress closed log. </summary>
        private bool? _SuppressClosedLog = false;
        /// <summary>   The suppress rex log. </summary>
        private bool? _SuppressREXLog = false;
        /// <summary>   The generate door contact change logs. </summary>
        private bool? _GenerateDoorContactChangeLogs = false;
        /// <summary>   The lock when door closes. </summary>
        private bool? _LockWhenDoorCloses = false;
        /// <summary>   The enable duress. </summary>
        private bool? _EnableDuress = false;
        /// <summary>   The door group notify. </summary>
        private bool? _DoorGroupNotify = false;
        /// <summary>   The door group can disable. </summary>
        private bool? _DoorGroupCanDisable = false;
        /// <summary>   The relay one on during arm delay. </summary>
        private bool? _RelayOneOnDuringArmDelay = false;
        /// <summary>   The require valid access for automatic unlock. </summary>
        private bool? _RequireValidAccessForAutoUnlock = false;
        /// <summary>   Duration of the pin specifies reclose. </summary>
        private bool? _PINSpecifiesRecloseDuration = false;
        /// <summary>   The valid access requires door open. </summary>
        private bool? _ValidAccessRequiresDoorOpen = false;
        /// <summary>   Number of dont decrement limited swipe expires. </summary>
        private bool? _DontDecrementLimitedSwipeExpireCount = false;
        /// <summary>   The ignore not in system. </summary>
        private bool? _IgnoreNotInSystem = false;
        /// <summary>   The reader sends heartbeat. </summary>
        private bool? _ReaderSendsHeartbeat = false;
        /// <summary>   The properties last updated Date/Time. </summary>
        private DateTimeOffset? _PropertiesLastUpdated;
        /// <summary>   The automatic forgive passback code. </summary>
        private short _AutoForgivePassbackCode = 0;
        /// <summary>   The automatic forgive passback display. </summary>
        private string _AutoForgivePassbackDisplay = string.Empty;
        /// <summary>   The pin required mode code. </summary>
        private short _PinRequiredModeCode = 0;
        /// <summary>   The pin required mode display. </summary>
        private string _PinRequiredModeDisplay = string.Empty;
        /// <summary>   The contact supervision code. </summary>
        private short _ContactSupervisionCode = 0;
        /// <summary>   The contact supervision display. </summary>
        private string _ContactSupervisionDisplay = string.Empty;
        /// <summary>   The defer to server code. </summary>
        private short _DeferToServerCode = 0;
        /// <summary>   The defer to server display. </summary>
        private string _DeferToServerDisplay = string.Empty;
        /// <summary>   The no server reply code. </summary>
        private short _NoServerReplyCode = 0;
        /// <summary>   The no server reply display. </summary>
        private string _NoServerReplyDisplay = string.Empty;
        /// <summary>   The lock push button code. </summary>
        private short _LockPushButtonCode = 0;
        /// <summary>   The lock push button display. </summary>
        private string _LockPushButtonDisplay = string.Empty;
        /// <summary>   The LCD board number. </summary>
        private short _LCDBoardNumber = 0;
        /// <summary>   The LCD section number. </summary>
        private short _LCDSectionNumber = 0;
        /// <summary>   The LCD node number. </summary>
        private short _LCDNodeNumber = 0;
        /// <summary>   The elevator control type code. </summary>
        private short _ElevatorControlTypeCode = 0;
        /// <summary>   The elevator control type display. </summary>
        private string _ElevatorControlTypeDisplay = string.Empty;
        /// <summary>   The elevator relay board number. </summary>
        private short _ElevatorRelayBoardNumber = 0;
        /// <summary>   The elevator relay section number. </summary>
        private short _ElevatorRelaySectionNumber = 0;
        /// <summary>   The passback into area number. </summary>
        private int _PassbackIntoAreaNumber = 0;
        /// <summary>   The passback from area number. </summary>
        private int _PassbackFromAreaNumber = 0;
        /// <summary>   The free access schedule number. </summary>
        private int _FreeAccessScheduleNumber = 0;
        /// <summary>   The free access schedule display. </summary>
        private string _FreeAccessScheduleDisplay = string.Empty;
        /// <summary>   The crisis free access schedule number. </summary>
        private int _CrisisFreeAccessScheduleNumber = 0;
        /// <summary>   The crisis free access schedule display. </summary>
        private string _CrisisFreeAccessScheduleDisplay = string.Empty;
        /// <summary>   The pin required schedule number. </summary>
        private int _PinRequiredScheduleNumber = 0;
        /// <summary>   The pin required schedule display. </summary>
        private string _PinRequiredScheduleDisplay = string.Empty;
        /// <summary>   The disable forced open schedule number. </summary>
        private int _DisableForcedOpenScheduleNumber = 0;
        /// <summary>   The disable forced open schedule display. </summary>
        private string _DisableForcedOpenScheduleDisplay = string.Empty;
        /// <summary>   The disable open too long schedule number. </summary>
        private int _DisableOpenTooLongScheduleNumber = 0;
        /// <summary>   The disable open too long schedule display. </summary>
        private string _DisableOpenTooLongScheduleDisplay = string.Empty;
        /// <summary>   The auxiliary output schedule number. </summary>
        private int _AuxiliaryOutputScheduleNumber = 0;
        /// <summary>   The auxiliary output schedule display. </summary>
        private string _AuxiliaryOutputScheduleDisplay = string.Empty;
        /// <summary>   The relay 2 activation delay. </summary>
        private int _Relay2ActivationDelay = 0;
        /// <summary>   Duration of the relay 2 activation. </summary>
        private int _Relay2ActivationDuration = 0;
        /// <summary>   The relay 2 trigger access granted. </summary>
        private bool? _Relay2TriggerAccessGranted = false;
        /// <summary>   The relay 2 trigger duress. </summary>
        private bool? _Relay2TriggerDuress = false;
        /// <summary>   The relay 2 trigger forced open. </summary>
        private bool? _Relay2TriggerForcedOpen = false;
        /// <summary>   The relay 2 trigger invalid attempt. </summary>
        private bool? _Relay2TriggerInvalidAttempt = false;
        /// <summary>   The relay 2 trigger open too long. </summary>
        private bool? _Relay2TriggerOpenTooLong = false;
        /// <summary>   The relay 2 trigger passback violation. </summary>
        private bool? _Relay2TriggerPassbackViolation = false;
        /// <summary>   The relay 2 mode code. </summary>
        private short _Relay2ModeCode = 0;
        /// <summary>   The relay 2 mode display. </summary>
        private string _Relay2ModeDisplay = string.Empty;
        /// <summary>   The relay 2 schedule number. </summary>
        private int _Relay2ScheduleNumber = 0;
        /// <summary>   The relay 2 schedule display. </summary>
        private string _Relay2ScheduleDisplay = string.Empty;
        /// <summary>   The forced open i/o group number. </summary>
        private int _ForcedOpenIOGroupNumber = 0;
        /// <summary>   The forced open i/o group offset. </summary>
        private short _ForcedOpenIOGroupOffset = 0;
        /// <summary>   The open too long i/o group number. </summary>
        private int _OpenTooLongIOGroupNumber = 0;
        /// <summary>   The open too long i/o group offset. </summary>
        private short _OpenTooLongIOGroupOffset = 0;
        /// <summary>   The invalid access attempt i/o group number. </summary>
        private int _InvalidAccessAttemptIOGroupNumber = 0;
        /// <summary>   The invalid access attempt i/o group offset. </summary>
        private short _InvalidAccessAttemptIOGroupOffset = 0;
        /// <summary>   The passback violation i/o group number. </summary>
        private int _PassbackViolationIOGroupNumber = 0;
        /// <summary>   The passback violation i/o group offset. </summary>
        private short _PassbackViolationIOGroupOffset = 0;
        /// <summary>   The duress i/o group number. </summary>
        private int _DuressIOGroupNumber = 0;
        /// <summary>   The duress i/o group offset. </summary>
        private short _DuressIOGroupOffset = 0;
        /// <summary>   The missed heartbeat i/o group number. </summary>
        private int _MissedHeartbeatIOGroupNumber = 0;
        /// <summary>   The missed heartbeat i/o group offset. </summary>
        private short _MissedHeartbeatIOGroupOffset = 0;
        /// <summary>   The access granted i/o group number. </summary>
        private int _AccessGrantedIOGroupNumber = 0;
        /// <summary>   The access granted i/o group offset. </summary>
        private short _AccessGrantedIOGroupOffset = 0;
        /// <summary>   The door group i/o group number. </summary>
        private int _DoorGroupIOGroupNumber = 0;
        /// <summary>   The door group i/o group offset. </summary>
        private short _DoorGroupIOGroupOffset = 0;
        /// <summary>   The locked by i/o group number. </summary>
        private int _LockedByIOGroupNumber = 0;
        /// <summary>   The unlocked by i/o group number. </summary>
        private int _UnlockedByIOGroupNumber = 0;
        /// <summary>   The first disarm i/o group number. </summary>
        private int _DisarmIOGroupNumber1 = 0;
        /// <summary>   The second disarm i/o group number. </summary>
        private int _DisarmIOGroupNumber2 = 0;
        /// <summary>   The third disarm i/o group number. </summary>
        private int _DisarmIOGroupNumber3 = 0;
        /// <summary>   The fourth disarm i/o group number. </summary>
        private int _DisarmIOGroupNumber4 = 0;

        /// <summary>   The access portal last updated Date/Time. </summary>
        private DateTimeOffset? _AccessPortalLastUpdated;
        private DateTimeOffset? _HardwareAddressLastUpdated;
        private DateTimeOffset? _PassbackIntoAreaLastUpdated;
        private DateTimeOffset? _PassbackFromAreaLastUpdated;
        private DateTimeOffset? _FreeAccessSchLastUpdated;
        private DateTimeOffset? _CrisisFreeAccessSchLastUpdated;
        private DateTimeOffset? _PinRequiredSchLastUpdated;
        private DateTimeOffset? _DisableForcedOpenSchLastUpdated;
        private DateTimeOffset? _DisableOpenTooLongSchLastUpdated;
        private DateTimeOffset? _AuxOutputSchLastUpdated;
        private DateTimeOffset? _AuxOutputLastUpdated;
        private DateTimeOffset? _Relay2SchLastUpdated;
        private DateTimeOffset? _ForcedOpenAlertLastUpdated;
        private DateTimeOffset? _OpenTooLongAlertLastUpdated;
        private DateTimeOffset? _InvalidAccessAttemptAlertLastUpdated;
        private DateTimeOffset? _PassbackViolationAlertLastUpdated;
        private DateTimeOffset? _DuressAlertLastUpdated;
        private DateTimeOffset? _MissedHeartbeatAlertLastUpdated;
        private DateTimeOffset? _AccessGrantedAlertLastUpdated;
        private DateTimeOffset? _DoorGroupAlertLastUpdated;
        private DateTimeOffset? _UnlockedByIogLastUpdated;
        private DateTimeOffset? _LockedByIogLastUpdated;
        private DateTimeOffset? _DisarmIog1LastUpdated;
        private DateTimeOffset? _DisarmIog2LastUpdated;
        private DateTimeOffset? _DisarmIog3LastUpdated;
        private DateTimeOffset? _DisarmIog4LastUpdated;
        private int _CpuNumber = 0;
        private Guid _CpuUid = Guid.Empty;
        private string _serverAddress;
        private bool _isConnected;
        private bool _ForcedOpenAlertEventIsActive = false;
        private bool _OpenTooLongAlertEventIsActive = false;
        private bool _InvalidAccessAttemptAlertEventIsActive = false;
        private bool _PassbackViolationAlertEventIsActive = false;
        private bool _DuressAlertEventIsActive = false;
        private bool _MissedHeartbeatAlertEventIsActive = false;
        private bool _AccessGrantedAlertEventIsActive = false;
        private bool _DoorGroupAlertEventIsActive = false;
        private bool _UnlockedByAlertEventIsActive = false;
        private bool _LockedByAlertEventIsActive = false;
        private bool _Disarm1AlertEventIsActive = false;
        private bool _Disarm2AlertEventIsActive = false;
        private bool _Disarm3AlertEventIsActive = false;
        private bool _Disarm4AlertEventIsActive = false;

        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Uid value. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid AccessPortalUid
        {
            get { return _AccessPortalUid; }
            set
            {
                if (_AccessPortalUid != value)
                {
                    _AccessPortalUid = value;
                    OnPropertyChanged(() => AccessPortalUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Uid value. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid ClusterUid
        {
            get { return _ClusterUid; }
            set
            {
                if (_ClusterUid != value)
                {
                    _ClusterUid = value;
                    OnPropertyChanged(() => ClusterUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Panel Uid value. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyPanelUid
        {
            get { return _GalaxyPanelUid; }
            set
            {
                if (_GalaxyPanelUid != value)
                {
                    _GalaxyPanelUid = value;
                    OnPropertyChanged(() => GalaxyPanelUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Interface Board Uid value. </summary>
        ///
        /// <value> The galaxy interface board UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyInterfaceBoardUid
        {
            get { return _GalaxyInterfaceBoardUid; }
            set
            {
                if (_GalaxyInterfaceBoardUid != value)
                {
                    _GalaxyInterfaceBoardUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Interface Board Section Uid value. </summary>
        ///
        /// <value> The galaxy interface board section UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyInterfaceBoardSectionUid
        {
            get { return _GalaxyInterfaceBoardSectionUid; }
            set
            {
                if (_GalaxyInterfaceBoardSectionUid != value)
                {
                    _GalaxyInterfaceBoardSectionUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardSectionUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Hardware Module Uid value. </summary>
        ///
        /// <value> The galaxy hardware module UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyHardwareModuleUid
        {
            get { return _GalaxyHardwareModuleUid; }
            set
            {
                if (_GalaxyHardwareModuleUid != value)
                {
                    _GalaxyHardwareModuleUid = value;
                    OnPropertyChanged(() => GalaxyHardwareModuleUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Interface Board Section Node Uid value. </summary>
        ///
        /// <value> The galaxy interface board section node UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyInterfaceBoardSectionNodeUid
        {
            get { return _GalaxyInterfaceBoardSectionNodeUid; }
            set
            {
                if (_GalaxyInterfaceBoardSectionNodeUid != value)
                {
                    _GalaxyInterfaceBoardSectionNodeUid = value;
                    OnPropertyChanged(() => GalaxyInterfaceBoardSectionNodeUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Portal Name value. </summary>
        ///
        /// <value> The name of the portal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PortalName
        {
            get { return _PortalName; }
            set
            {
                if (_PortalName != value)
                {
                    _PortalName = value;
                    OnPropertyChanged(() => PortalName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Account Code value. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Number value. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ClusterNumber
        {
            get { return _ClusterNumber; }
            set
            {
                if (_ClusterNumber != value)
                {
                    _ClusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Number value. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PanelNumber
        {
            get { return _PanelNumber; }
            set
            {
                if (_PanelNumber != value)
                {
                    _PanelNumber = value;
                    OnPropertyChanged(() => PanelNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Board Number value. </summary>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short BoardNumber
        {
            get { return _BoardNumber; }
            set
            {
                if (_BoardNumber != value)
                {
                    _BoardNumber = value;
                    OnPropertyChanged(() => BoardNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Section Number value. </summary>
        ///
        /// <value> The section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short SectionNumber
        {
            get { return _SectionNumber; }
            set
            {
                if (_SectionNumber != value)
                {
                    _SectionNumber = value;
                    OnPropertyChanged(() => SectionNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Module Number value. </summary>
        ///
        /// <value> The module number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ModuleNumber
        {
            get { return _ModuleNumber; }
            set
            {
                if (_ModuleNumber != value)
                {
                    _ModuleNumber = value;
                    OnPropertyChanged(() => ModuleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Node Number value. </summary>
        ///
        /// <value> The node number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short NodeNumber
        {
            get { return _NodeNumber; }
            set
            {
                if (_NodeNumber != value)
                {
                    _NodeNumber = value;
                    OnPropertyChanged(() => NodeNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Door Number value. </summary>
        ///
        /// <value> The door number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short DoorNumber
        {
            get { return _DoorNumber; }
            set
            {
                if (_DoorNumber != value)
                {
                    _DoorNumber = value;
                    OnPropertyChanged(() => DoorNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Type Description value. </summary>
        ///
        /// <value> Information describing the access portal type. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalTypeDescription
        {
            get { return _AccessPortalTypeDescription; }
            set
            {
                if (_AccessPortalTypeDescription != value)
                {
                    _AccessPortalTypeDescription = value;
                    OnPropertyChanged(() => AccessPortalTypeDescription);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Reader Type Name value. </summary>
        ///
        /// <value> The name of the reader type. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ReaderTypeName
        {
            get { return _ReaderTypeName; }
            set
            {
                if (_ReaderTypeName != value)
                {
                    _ReaderTypeName = value;
                    OnPropertyChanged(() => ReaderTypeName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Data Format Code value. </summary>
        ///
        /// <value> The panel data format code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PanelDataFormatCode
        {
            get { return _PanelDataFormatCode; }
            set
            {
                if (_PanelDataFormatCode != value)
                {
                    _PanelDataFormatCode = value;
                    OnPropertyChanged(() => PanelDataFormatCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Data Format Name value. </summary>
        ///
        /// <value> The name of the data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DataFormatName
        {
            get { return _DataFormatName; }
            set
            {
                if (_DataFormatName != value)
                {
                    _DataFormatName = value;
                    OnPropertyChanged(() => DataFormatName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Board Section Mode value. </summary>
        ///
        /// <value> The access portal board section mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AccessPortalBoardSectionMode
        {
            get { return _AccessPortalBoardSectionMode; }
            set
            {
                if (_AccessPortalBoardSectionMode != value)
                {
                    _AccessPortalBoardSectionMode = value;
                    OnPropertyChanged(() => AccessPortalBoardSectionMode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Board Section Mode Display value. </summary>
        ///
        /// <value> The access portal board section mode display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalBoardSectionModeDisplay
        {
            get { return _AccessPortalBoardSectionModeDisplay; }
            set
            {
                if (_AccessPortalBoardSectionModeDisplay != value)
                {
                    _AccessPortalBoardSectionModeDisplay = value;
                    OnPropertyChanged(() => AccessPortalBoardSectionModeDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Panel Model Type Code value. </summary>
        ///
        /// <value> The access portal panel model type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalPanelModelTypeCode
        {
            get { return _AccessPortalPanelModelTypeCode; }
            set
            {
                if (_AccessPortalPanelModelTypeCode != value)
                {
                    _AccessPortalPanelModelTypeCode = value;
                    OnPropertyChanged(() => AccessPortalPanelModelTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Cpu Type Code value. </summary>
        ///
        /// <value> The access portal CPU type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalCpuTypeCode
        {
            get { return _AccessPortalCpuTypeCode; }
            set
            {
                if (_AccessPortalCpuTypeCode != value)
                {
                    _AccessPortalCpuTypeCode = value;
                    OnPropertyChanged(() => AccessPortalCpuTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Board Type Model value. </summary>
        ///
        /// <value> The access portal board type model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalBoardTypeModel
        {
            get { return _AccessPortalBoardTypeModel; }
            set
            {
                if (_AccessPortalBoardTypeModel != value)
                {
                    _AccessPortalBoardTypeModel = value;
                    OnPropertyChanged(() => AccessPortalBoardTypeModel);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Board Type Type Code value. </summary>
        ///
        /// <value> The access portal board type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AccessPortalBoardTypeTypeCode
        {
            get { return _AccessPortalBoardTypeTypeCode; }
            set
            {
                if (_AccessPortalBoardTypeTypeCode != value)
                {
                    _AccessPortalBoardTypeTypeCode = value;
                    OnPropertyChanged(() => AccessPortalBoardTypeTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Portal Board Type Display value. </summary>
        ///
        /// <value> The access portal board type display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AccessPortalBoardTypeDisplay
        {
            get { return _AccessPortalBoardTypeDisplay; }
            set
            {
                if (_AccessPortalBoardTypeDisplay != value)
                {
                    _AccessPortalBoardTypeDisplay = value;
                    OnPropertyChanged(() => AccessPortalBoardTypeDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlock Delay value. </summary>
        ///
        /// <value> The unlock delay. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int UnlockDelay
        {
            get { return _UnlockDelay; }
            set
            {
                if (_UnlockDelay != value)
                {
                    _UnlockDelay = value;
                    OnPropertyChanged(() => UnlockDelay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlock Duration value. </summary>
        ///
        /// <value> The unlock duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int UnlockDuration
        {
            get { return _UnlockDuration; }
            set
            {
                if (_UnlockDuration != value)
                {
                    _UnlockDuration = value;
                    OnPropertyChanged(() => UnlockDuration);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Reclose Duration value. </summary>
        ///
        /// <value> The reclose duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int RecloseDuration
        {
            get { return _RecloseDuration; }
            set
            {
                if (_RecloseDuration != value)
                {
                    _RecloseDuration = value;
                    OnPropertyChanged(() => RecloseDuration);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Allow Passback Access value. </summary>
        ///
        /// <value> The allow passback access. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? AllowPassbackAccess
        {
            get { return _AllowPassbackAccess; }
            set
            {
                if (_AllowPassbackAccess != value)
                {
                    _AllowPassbackAccess = value;
                    OnPropertyChanged(() => AllowPassbackAccess);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Require Two Valid Credentials value. </summary>
        ///
        /// <value> The require two valid credentials. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? RequireTwoValidCredentials
        {
            get { return _RequireTwoValidCredentials; }
            set
            {
                if (_RequireTwoValidCredentials != value)
                {
                    _RequireTwoValidCredentials = value;
                    OnPropertyChanged(() => RequireTwoValidCredentials);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlock On REX value. </summary>
        ///
        /// <value> The unlock on rex. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? UnlockOnREX
        {
            get { return _UnlockOnREX; }
            set
            {
                if (_UnlockOnREX != value)
                {
                    _UnlockOnREX = value;
                    OnPropertyChanged(() => UnlockOnREX);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Suppress Illegal Open Log value. </summary>
        ///
        /// <value> The suppress illegal open log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? SuppressIllegalOpenLog
        {
            get { return _SuppressIllegalOpenLog; }
            set
            {
                if (_SuppressIllegalOpenLog != value)
                {
                    _SuppressIllegalOpenLog = value;
                    OnPropertyChanged(() => SuppressIllegalOpenLog);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Suppress Open Too Long Log value. </summary>
        ///
        /// <value> The suppress open too long log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? SuppressOpenTooLongLog
        {
            get { return _SuppressOpenTooLongLog; }
            set
            {
                if (_SuppressOpenTooLongLog != value)
                {
                    _SuppressOpenTooLongLog = value;
                    OnPropertyChanged(() => SuppressOpenTooLongLog);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Suppress Closed Log value. </summary>
        ///
        /// <value> The suppress closed log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? SuppressClosedLog
        {
            get { return _SuppressClosedLog; }
            set
            {
                if (_SuppressClosedLog != value)
                {
                    _SuppressClosedLog = value;
                    OnPropertyChanged(() => SuppressClosedLog);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Suppress REX Log value. </summary>
        ///
        /// <value> The suppress rex log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? SuppressREXLog
        {
            get { return _SuppressREXLog; }
            set
            {
                if (_SuppressREXLog != value)
                {
                    _SuppressREXLog = value;
                    OnPropertyChanged(() => SuppressREXLog);
                }
            }
        }


        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the generate door contact change logs. </summary>
        ///
        /// <value> The generate door contact change logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the generate door contact change logs. </summary>
        ///
        /// <value> The generate door contact change logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the generate door contact change logs. </summary>
        ///
        /// <value> The generate door contact change logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the generate door contact change logs. </summary>
        ///
        /// <value> The generate door contact change logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? GenerateDoorContactChangeLogs
        {
            get { return _GenerateDoorContactChangeLogs; }
            set
            {
                if (_GenerateDoorContactChangeLogs != value)
                {
                    _GenerateDoorContactChangeLogs = value;
                    OnPropertyChanged(() => GenerateDoorContactChangeLogs);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Lock When Door Closes value. </summary>
        ///
        /// <value> The lock when door closes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? LockWhenDoorCloses
        {
            get { return _LockWhenDoorCloses; }
            set
            {
                if (_LockWhenDoorCloses != value)
                {
                    _LockWhenDoorCloses = value;
                    OnPropertyChanged(() => LockWhenDoorCloses);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Enable DuressAuxiliaryFunction value. </summary>
        ///
        /// <value> The enable duress. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? EnableDuress
        {
            get { return _EnableDuress; }
            set
            {
                if (_EnableDuress != value)
                {
                    _EnableDuress = value;
                    OnPropertyChanged(() => EnableDuress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Door Group Notify value. </summary>
        ///
        /// <value> The door group notify. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? DoorGroupNotify
        {
            get { return _DoorGroupNotify; }
            set
            {
                if (_DoorGroupNotify != value)
                {
                    _DoorGroupNotify = value;
                    OnPropertyChanged(() => DoorGroupNotify);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Door Group Can Disable value. </summary>
        ///
        /// <value> The door group can disable. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? DoorGroupCanDisable
        {
            get { return _DoorGroupCanDisable; }
            set
            {
                if (_DoorGroupCanDisable != value)
                {
                    _DoorGroupCanDisable = value;
                    OnPropertyChanged(() => DoorGroupCanDisable);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay One On During Arm Delay value. </summary>
        ///
        /// <value> The relay one on during arm delay. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? RelayOneOnDuringArmDelay
        {
            get { return _RelayOneOnDuringArmDelay; }
            set
            {
                if (_RelayOneOnDuringArmDelay != value)
                {
                    _RelayOneOnDuringArmDelay = value;
                    OnPropertyChanged(() => RelayOneOnDuringArmDelay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Require Valid Access For Auto Unlock value. </summary>
        ///
        /// <value> The require valid access for automatic unlock. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? RequireValidAccessForAutoUnlock
        {
            get { return _RequireValidAccessForAutoUnlock; }
            set
            {
                if (_RequireValidAccessForAutoUnlock != value)
                {
                    _RequireValidAccessForAutoUnlock = value;
                    OnPropertyChanged(() => RequireValidAccessForAutoUnlock);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the PIN Specifies Reclose Duration value. </summary>
        ///
        /// <value> The pin specifies reclose duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? PINSpecifiesRecloseDuration
        {
            get { return _PINSpecifiesRecloseDuration; }
            set
            {
                if (_PINSpecifiesRecloseDuration != value)
                {
                    _PINSpecifiesRecloseDuration = value;
                    OnPropertyChanged(() => PINSpecifiesRecloseDuration);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Valid Access Requires Door Open value. </summary>
        ///
        /// <value> The valid access requires door open. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? ValidAccessRequiresDoorOpen
        {
            get { return _ValidAccessRequiresDoorOpen; }
            set
            {
                if (_ValidAccessRequiresDoorOpen != value)
                {
                    _ValidAccessRequiresDoorOpen = value;
                    OnPropertyChanged(() => ValidAccessRequiresDoorOpen);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Dont Decrement Limited Swipe Expire Count value. </summary>
        ///
        /// <value> The number of dont decrement limited swipe expires. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? DontDecrementLimitedSwipeExpireCount
        {
            get { return _DontDecrementLimitedSwipeExpireCount; }
            set
            {
                if (_DontDecrementLimitedSwipeExpireCount != value)
                {
                    _DontDecrementLimitedSwipeExpireCount = value;
                    OnPropertyChanged(() => DontDecrementLimitedSwipeExpireCount);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Ignore Not In System value. </summary>
        ///
        /// <value> The ignore not in system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? IgnoreNotInSystem
        {
            get { return _IgnoreNotInSystem; }
            set
            {
                if (_IgnoreNotInSystem != value)
                {
                    _IgnoreNotInSystem = value;
                    OnPropertyChanged(() => IgnoreNotInSystem);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Reader Sends Heartbeat value. </summary>
        ///
        /// <value> The reader sends heartbeat. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? ReaderSendsHeartbeat
        {
            get { return _ReaderSendsHeartbeat; }
            set
            {
                if (_ReaderSendsHeartbeat != value)
                {
                    _ReaderSendsHeartbeat = value;
                    OnPropertyChanged(() => ReaderSendsHeartbeat);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Properties Last Updated value. </summary>
        ///
        /// <value> The properties last updated. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public DateTimeOffset? PropertiesLastUpdated
        {
            get { return _PropertiesLastUpdated; }
            set
            {
                if (_PropertiesLastUpdated != value)
                {
                    _PropertiesLastUpdated = value;
                    OnPropertyChanged(() => PropertiesLastUpdated);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Auto Forgive Passback Code value. </summary>
        ///
        /// <value> The automatic forgive passback code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AutoForgivePassbackCode
        {
            get { return _AutoForgivePassbackCode; }
            set
            {
                if (_AutoForgivePassbackCode != value)
                {
                    _AutoForgivePassbackCode = value;
                    OnPropertyChanged(() => AutoForgivePassbackCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Auto Forgive Passback Display value. </summary>
        ///
        /// <value> The automatic forgive passback display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AutoForgivePassbackDisplay
        {
            get { return _AutoForgivePassbackDisplay; }
            set
            {
                if (_AutoForgivePassbackDisplay != value)
                {
                    _AutoForgivePassbackDisplay = value;
                    OnPropertyChanged(() => AutoForgivePassbackDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Pin Required Mode Code value. </summary>
        ///
        /// <value> The pin required mode code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short PinRequiredModeCode
        {
            get { return _PinRequiredModeCode; }
            set
            {
                if (_PinRequiredModeCode != value)
                {
                    _PinRequiredModeCode = value;
                    OnPropertyChanged(() => PinRequiredModeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Pin Required Mode Display value. </summary>
        ///
        /// <value> The pin required mode display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PinRequiredModeDisplay
        {
            get { return _PinRequiredModeDisplay; }
            set
            {
                if (_PinRequiredModeDisplay != value)
                {
                    _PinRequiredModeDisplay = value;
                    OnPropertyChanged(() => PinRequiredModeDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Contact Supervision Code value. </summary>
        ///
        /// <value> The contact supervision code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ContactSupervisionCode
        {
            get { return _ContactSupervisionCode; }
            set
            {
                if (_ContactSupervisionCode != value)
                {
                    _ContactSupervisionCode = value;
                    OnPropertyChanged(() => ContactSupervisionCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Contact Supervision Display value. </summary>
        ///
        /// <value> The contact supervision display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ContactSupervisionDisplay
        {
            get { return _ContactSupervisionDisplay; }
            set
            {
                if (_ContactSupervisionDisplay != value)
                {
                    _ContactSupervisionDisplay = value;
                    OnPropertyChanged(() => ContactSupervisionDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Defer To Server Code value. </summary>
        ///
        /// <value> The defer to server code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short DeferToServerCode
        {
            get { return _DeferToServerCode; }
            set
            {
                if (_DeferToServerCode != value)
                {
                    _DeferToServerCode = value;
                    OnPropertyChanged(() => DeferToServerCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Defer To Server Display value. </summary>
        ///
        /// <value> The defer to server display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DeferToServerDisplay
        {
            get { return _DeferToServerDisplay; }
            set
            {
                if (_DeferToServerDisplay != value)
                {
                    _DeferToServerDisplay = value;
                    OnPropertyChanged(() => DeferToServerDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the No Server Reply Code value. </summary>
        ///
        /// <value> The no server reply code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short NoServerReplyCode
        {
            get { return _NoServerReplyCode; }
            set
            {
                if (_NoServerReplyCode != value)
                {
                    _NoServerReplyCode = value;
                    OnPropertyChanged(() => NoServerReplyCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the No Server Reply Display value. </summary>
        ///
        /// <value> The no server reply display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string NoServerReplyDisplay
        {
            get { return _NoServerReplyDisplay; }
            set
            {
                if (_NoServerReplyDisplay != value)
                {
                    _NoServerReplyDisplay = value;
                    OnPropertyChanged(() => NoServerReplyDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Lock Push Button Code value. </summary>
        ///
        /// <value> The lock push button code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LockPushButtonCode
        {
            get { return _LockPushButtonCode; }
            set
            {
                if (_LockPushButtonCode != value)
                {
                    _LockPushButtonCode = value;
                    OnPropertyChanged(() => LockPushButtonCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Lock Push Button Display value. </summary>
        ///
        /// <value> The lock push button display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string LockPushButtonDisplay
        {
            get { return _LockPushButtonDisplay; }
            set
            {
                if (_LockPushButtonDisplay != value)
                {
                    _LockPushButtonDisplay = value;
                    OnPropertyChanged(() => LockPushButtonDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the LCD Board Number value. </summary>
        ///
        /// <value> The LCD board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LCDBoardNumber
        {
            get { return _LCDBoardNumber; }
            set
            {
                if (_LCDBoardNumber != value)
                {
                    _LCDBoardNumber = value;
                    OnPropertyChanged(() => LCDBoardNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the LCD Section Number value. </summary>
        ///
        /// <value> The LCD section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LCDSectionNumber
        {
            get { return _LCDSectionNumber; }
            set
            {
                if (_LCDSectionNumber != value)
                {
                    _LCDSectionNumber = value;
                    OnPropertyChanged(() => LCDSectionNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the LCD Node Number value. </summary>
        ///
        /// <value> The LCD node number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LCDNodeNumber
        {
            get { return _LCDNodeNumber; }
            set
            {
                if (_LCDNodeNumber != value)
                {
                    _LCDNodeNumber = value;
                    OnPropertyChanged(() => LCDNodeNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Elevator Control Type Code value. </summary>
        ///
        /// <value> The elevator control type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ElevatorControlTypeCode
        {
            get { return _ElevatorControlTypeCode; }
            set
            {
                if (_ElevatorControlTypeCode != value)
                {
                    _ElevatorControlTypeCode = value;
                    OnPropertyChanged(() => ElevatorControlTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Elevator Control Type Display value. </summary>
        ///
        /// <value> The elevator control type display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ElevatorControlTypeDisplay
        {
            get { return _ElevatorControlTypeDisplay; }
            set
            {
                if (_ElevatorControlTypeDisplay != value)
                {
                    _ElevatorControlTypeDisplay = value;
                    OnPropertyChanged(() => ElevatorControlTypeDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Elevator Relay Board Number value. </summary>
        ///
        /// <value> The elevator relay board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ElevatorRelayBoardNumber
        {
            get { return _ElevatorRelayBoardNumber; }
            set
            {
                if (_ElevatorRelayBoardNumber != value)
                {
                    _ElevatorRelayBoardNumber = value;
                    OnPropertyChanged(() => ElevatorRelayBoardNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Elevator Relay Section Number value. </summary>
        ///
        /// <value> The elevator relay section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ElevatorRelaySectionNumber
        {
            get { return _ElevatorRelaySectionNumber; }
            set
            {
                if (_ElevatorRelaySectionNumber != value)
                {
                    _ElevatorRelaySectionNumber = value;
                    OnPropertyChanged(() => ElevatorRelaySectionNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Passback Into Area Number value. </summary>
        ///
        /// <value> The passback into area number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PassbackIntoAreaNumber
        {
            get { return _PassbackIntoAreaNumber; }
            set
            {
                if (_PassbackIntoAreaNumber != value)
                {
                    _PassbackIntoAreaNumber = value;
                    OnPropertyChanged(() => PassbackIntoAreaNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Passback From Area Number value. </summary>
        ///
        /// <value> The passback from area number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PassbackFromAreaNumber
        {
            get { return _PassbackFromAreaNumber; }
            set
            {
                if (_PassbackFromAreaNumber != value)
                {
                    _PassbackFromAreaNumber = value;
                    OnPropertyChanged(() => PassbackFromAreaNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Free Access Schedule Number value. </summary>
        ///
        /// <value> The free access schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int FreeAccessScheduleNumber
        {
            get { return _FreeAccessScheduleNumber; }
            set
            {
                if (_FreeAccessScheduleNumber != value)
                {
                    _FreeAccessScheduleNumber = value;
                    OnPropertyChanged(() => FreeAccessScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Free Access Schedule Display value. </summary>
        ///
        /// <value> The free access schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string FreeAccessScheduleDisplay
        {
            get { return _FreeAccessScheduleDisplay; }
            set
            {
                if (_FreeAccessScheduleDisplay != value)
                {
                    _FreeAccessScheduleDisplay = value;
                    OnPropertyChanged(() => FreeAccessScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Crisis Free Access Schedule Number value. </summary>
        ///
        /// <value> The crisis free access schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int CrisisFreeAccessScheduleNumber
        {
            get { return _CrisisFreeAccessScheduleNumber; }
            set
            {
                if (_CrisisFreeAccessScheduleNumber != value)
                {
                    _CrisisFreeAccessScheduleNumber = value;
                    OnPropertyChanged(() => CrisisFreeAccessScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Crisis Free Access Schedule Display value. </summary>
        ///
        /// <value> The crisis free access schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string CrisisFreeAccessScheduleDisplay
        {
            get { return _CrisisFreeAccessScheduleDisplay; }
            set
            {
                if (_CrisisFreeAccessScheduleDisplay != value)
                {
                    _CrisisFreeAccessScheduleDisplay = value;
                    OnPropertyChanged(() => CrisisFreeAccessScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Pin Required Schedule Number value. </summary>
        ///
        /// <value> The pin required schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PinRequiredScheduleNumber
        {
            get { return _PinRequiredScheduleNumber; }
            set
            {
                if (_PinRequiredScheduleNumber != value)
                {
                    _PinRequiredScheduleNumber = value;
                    OnPropertyChanged(() => PinRequiredScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Pin Required Schedule Display value. </summary>
        ///
        /// <value> The pin required schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PinRequiredScheduleDisplay
        {
            get { return _PinRequiredScheduleDisplay; }
            set
            {
                if (_PinRequiredScheduleDisplay != value)
                {
                    _PinRequiredScheduleDisplay = value;
                    OnPropertyChanged(() => PinRequiredScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disable Forced Open Schedule Number value. </summary>
        ///
        /// <value> The disable forced open schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisableForcedOpenScheduleNumber
        {
            get { return _DisableForcedOpenScheduleNumber; }
            set
            {
                if (_DisableForcedOpenScheduleNumber != value)
                {
                    _DisableForcedOpenScheduleNumber = value;
                    OnPropertyChanged(() => DisableForcedOpenScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disable Forced Open Schedule Display value. </summary>
        ///
        /// <value> The disable forced open schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DisableForcedOpenScheduleDisplay
        {
            get { return _DisableForcedOpenScheduleDisplay; }
            set
            {
                if (_DisableForcedOpenScheduleDisplay != value)
                {
                    _DisableForcedOpenScheduleDisplay = value;
                    OnPropertyChanged(() => DisableForcedOpenScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disable Open Too Long Schedule Number value. </summary>
        ///
        /// <value> The disable open too long schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisableOpenTooLongScheduleNumber
        {
            get { return _DisableOpenTooLongScheduleNumber; }
            set
            {
                if (_DisableOpenTooLongScheduleNumber != value)
                {
                    _DisableOpenTooLongScheduleNumber = value;
                    OnPropertyChanged(() => DisableOpenTooLongScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disable Open Too Long Schedule Display value. </summary>
        ///
        /// <value> The disable open too long schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DisableOpenTooLongScheduleDisplay
        {
            get { return _DisableOpenTooLongScheduleDisplay; }
            set
            {
                if (_DisableOpenTooLongScheduleDisplay != value)
                {
                    _DisableOpenTooLongScheduleDisplay = value;
                    OnPropertyChanged(() => DisableOpenTooLongScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Auxiliary Output Schedule Number value. </summary>
        ///
        /// <value> The auxiliary output schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int AuxiliaryOutputScheduleNumber
        {
            get { return _AuxiliaryOutputScheduleNumber; }
            set
            { 
                if (_AuxiliaryOutputScheduleNumber != value)
                {
                    _AuxiliaryOutputScheduleNumber = value;
                    OnPropertyChanged(() => AuxiliaryOutputScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Auxiliary Output Schedule Display value. </summary>
        ///
        /// <value> The auxiliary output schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string AuxiliaryOutputScheduleDisplay
        {
            get { return _AuxiliaryOutputScheduleDisplay; }
            set
            {
                if (_AuxiliaryOutputScheduleDisplay != value)
                {
                    _AuxiliaryOutputScheduleDisplay = value;
                    OnPropertyChanged(() => AuxiliaryOutputScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Activation Delay value. </summary>
        ///
        /// <value> The relay 2 activation delay. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int Relay2ActivationDelay
        {
            get { return _Relay2ActivationDelay; }
            set
            {
                if (_Relay2ActivationDelay != value)
                {
                    _Relay2ActivationDelay = value;
                    OnPropertyChanged(() => Relay2ActivationDelay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Activation Duration value. </summary>
        ///
        /// <value> The relay 2 activation duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int Relay2ActivationDuration
        {
            get { return _Relay2ActivationDuration; }
            set
            {
                if (_Relay2ActivationDuration != value)
                {
                    _Relay2ActivationDuration = value;
                    OnPropertyChanged(() => Relay2ActivationDuration);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger Access Granted value. </summary>
        ///
        /// <value> The relay 2 trigger access granted. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerAccessGranted
        {
            get { return _Relay2TriggerAccessGranted; }
            set
            {
                if (_Relay2TriggerAccessGranted != value)
                {
                    _Relay2TriggerAccessGranted = value;
                    OnPropertyChanged(() => Relay2TriggerAccessGranted);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger DuressAuxiliaryFunction value. </summary>
        ///
        /// <value> The relay 2 trigger duress. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerDuress
        {
            get { return _Relay2TriggerDuress; }
            set
            {
                if (_Relay2TriggerDuress != value)
                {
                    _Relay2TriggerDuress = value;
                    OnPropertyChanged(() => Relay2TriggerDuress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger Forced Open value. </summary>
        ///
        /// <value> The relay 2 trigger forced open. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerForcedOpen
        {
            get { return _Relay2TriggerForcedOpen; }
            set
            {
                if (_Relay2TriggerForcedOpen != value)
                {
                    _Relay2TriggerForcedOpen = value;
                    OnPropertyChanged(() => Relay2TriggerForcedOpen);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger Invalid Attempt value. </summary>
        ///
        /// <value> The relay 2 trigger invalid attempt. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerInvalidAttempt
        {
            get { return _Relay2TriggerInvalidAttempt; }
            set
            {
                if (_Relay2TriggerInvalidAttempt != value)
                {
                    _Relay2TriggerInvalidAttempt = value;
                    OnPropertyChanged(() => Relay2TriggerInvalidAttempt);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger Open Too Long value. </summary>
        ///
        /// <value> The relay 2 trigger open too long. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerOpenTooLong
        {
            get { return _Relay2TriggerOpenTooLong; }
            set
            {
                if (_Relay2TriggerOpenTooLong != value)
                {
                    _Relay2TriggerOpenTooLong = value;
                    OnPropertyChanged(() => Relay2TriggerOpenTooLong);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Trigger Passback Violation value. </summary>
        ///
        /// <value> The relay 2 trigger passback violation. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? Relay2TriggerPassbackViolation
        {
            get { return _Relay2TriggerPassbackViolation; }
            set
            {
                if (_Relay2TriggerPassbackViolation != value)
                {
                    _Relay2TriggerPassbackViolation = value;
                    OnPropertyChanged(() => Relay2TriggerPassbackViolation);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Mode Code value. </summary>
        ///
        /// <value> The relay 2 mode code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short Relay2ModeCode
        {
            get { return _Relay2ModeCode; }
            set
            {
                if (_Relay2ModeCode != value)
                {
                    _Relay2ModeCode = value;
                    OnPropertyChanged(() => Relay2ModeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Mode Display value. </summary>
        ///
        /// <value> The relay 2 mode display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string Relay2ModeDisplay
        {
            get { return _Relay2ModeDisplay; }
            set
            { 
                if (_Relay2ModeDisplay != value)
                {
                    _Relay2ModeDisplay = value;
                    OnPropertyChanged(() => Relay2ModeDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Schedule Number value. </summary>
        ///
        /// <value> The relay 2 schedule number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int Relay2ScheduleNumber
        {
            get { return _Relay2ScheduleNumber; }
            set
            {
                if (_Relay2ScheduleNumber != value)
                {
                    _Relay2ScheduleNumber = value;
                    OnPropertyChanged(() => Relay2ScheduleNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Relay 2 Schedule Display value. </summary>
        ///
        /// <value> The relay 2 schedule display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string Relay2ScheduleDisplay
        {
            get { return _Relay2ScheduleDisplay; }
            set
            {
                if (_Relay2ScheduleDisplay != value)
                {
                    _Relay2ScheduleDisplay = value;
                    OnPropertyChanged(() => Relay2ScheduleDisplay);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Forced Open IO Group Number value. </summary>
        ///
        /// <value> The forced open i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ForcedOpenIOGroupNumber
        {
            get { return _ForcedOpenIOGroupNumber; }
            set
            {
                if (_ForcedOpenIOGroupNumber != value)
                {
                    _ForcedOpenIOGroupNumber = value;
                    OnPropertyChanged(() => ForcedOpenIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Forced Open IO Group Offset value. </summary>
        ///
        /// <value> The forced open i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short ForcedOpenIOGroupOffset
        {
            get { return _ForcedOpenIOGroupOffset; }
            set
            {
                if (_ForcedOpenIOGroupOffset != value)
                {
                    _ForcedOpenIOGroupOffset = value;
                    OnPropertyChanged(() => ForcedOpenIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Open Too Long IO Group Number value. </summary>
        ///
        /// <value> The open too long i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int OpenTooLongIOGroupNumber
        {
            get { return _OpenTooLongIOGroupNumber; }
            set
            {
                if (_OpenTooLongIOGroupNumber != value)
                {
                    _OpenTooLongIOGroupNumber = value;
                    OnPropertyChanged(() => OpenTooLongIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Open Too Long IO Group Offset value. </summary>
        ///
        /// <value> The open too long i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short OpenTooLongIOGroupOffset
        {
            get { return _OpenTooLongIOGroupOffset; }
            set
            {
                if (_OpenTooLongIOGroupOffset != value)
                {
                    _OpenTooLongIOGroupOffset = value;
                    OnPropertyChanged(() => OpenTooLongIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Invalid Access Attempt IO Group Number value. </summary>
        ///
        /// <value> The invalid access attempt i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int InvalidAccessAttemptIOGroupNumber
        {
            get { return _InvalidAccessAttemptIOGroupNumber; }
            set
            {
                if (_InvalidAccessAttemptIOGroupNumber != value)
                {
                    _InvalidAccessAttemptIOGroupNumber = value;
                    OnPropertyChanged(() => InvalidAccessAttemptIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Invalid Access Attempt IO Group Offset value. </summary>
        ///
        /// <value> The invalid access attempt i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short InvalidAccessAttemptIOGroupOffset
        {
            get { return _InvalidAccessAttemptIOGroupOffset; }
            set
            {
                if (_InvalidAccessAttemptIOGroupOffset != value)
                {
                    _InvalidAccessAttemptIOGroupOffset = value;
                    OnPropertyChanged(() => InvalidAccessAttemptIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Passback Violation IO Group Number value. </summary>
        ///
        /// <value> The passback violation i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int PassbackViolationIOGroupNumber
        {
            get { return _PassbackViolationIOGroupNumber; }
            set
            {
                if (_PassbackViolationIOGroupNumber != value)
                {
                    _PassbackViolationIOGroupNumber = value;
                    OnPropertyChanged(() => PassbackViolationIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Passback Violation IO Group Offset value. </summary>
        ///
        /// <value> The passback violation i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short PassbackViolationIOGroupOffset
        {
            get { return _PassbackViolationIOGroupOffset; }
            set
            {
                if (_PassbackViolationIOGroupOffset != value)
                {
                    _PassbackViolationIOGroupOffset = value;
                    OnPropertyChanged(() => PassbackViolationIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the DuressAuxiliaryFunction IO Group Number value. </summary>
        ///
        /// <value> The duress i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DuressIOGroupNumber
        {
            get { return _DuressIOGroupNumber; }
            set
            {
                if (_DuressIOGroupNumber != value)
                {
                    _DuressIOGroupNumber = value;
                    OnPropertyChanged(() => DuressIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the DuressAuxiliaryFunction IO Group Offset value. </summary>
        ///
        /// <value> The duress i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short DuressIOGroupOffset
        {
            get { return _DuressIOGroupOffset; }
            set
            {
                if (_DuressIOGroupOffset != value)
                {
                    _DuressIOGroupOffset = value;
                    OnPropertyChanged(() => DuressIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Missed Heartbeat IO Group Number value. </summary>
        ///
        /// <value> The missed heartbeat i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int MissedHeartbeatIOGroupNumber
        {
            get { return _MissedHeartbeatIOGroupNumber; }
            set
            {
                if (_MissedHeartbeatIOGroupNumber != value)
                {
                    _MissedHeartbeatIOGroupNumber = value;
                    OnPropertyChanged(() => MissedHeartbeatIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Missed Heartbeat IO Group Offset value. </summary>
        ///
        /// <value> The missed heartbeat i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short MissedHeartbeatIOGroupOffset
        {
            get { return _MissedHeartbeatIOGroupOffset; }
            set
            {
                if (_MissedHeartbeatIOGroupOffset != value)
                {
                    _MissedHeartbeatIOGroupOffset = value;
                    OnPropertyChanged(() => MissedHeartbeatIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Granted IO Group Number value. </summary>
        ///
        /// <value> The access granted i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int AccessGrantedIOGroupNumber
        {
            get { return _AccessGrantedIOGroupNumber; }
            set
            {
                if (_AccessGrantedIOGroupNumber != value)
                {
                    _AccessGrantedIOGroupNumber = value;
                    OnPropertyChanged(() => AccessGrantedIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Granted IO Group Offset value. </summary>
        ///
        /// <value> The access granted i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AccessGrantedIOGroupOffset
        {
            get { return _AccessGrantedIOGroupOffset; }
            set
            {
                if (_AccessGrantedIOGroupOffset != value)
                {
                    _AccessGrantedIOGroupOffset = value;
                    OnPropertyChanged(() => AccessGrantedIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Door Group IO Group Number value. </summary>
        ///
        /// <value> The door group i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DoorGroupIOGroupNumber
        {
            get { return _DoorGroupIOGroupNumber; }
            set
            {
                if (_DoorGroupIOGroupNumber != value)
                {
                    _DoorGroupIOGroupNumber = value;
                    OnPropertyChanged(() => DoorGroupIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Door Group IO Group Offset value. </summary>
        ///
        /// <value> The door group i/o group offset. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short DoorGroupIOGroupOffset
        {
            get { return _DoorGroupIOGroupOffset; }
            set
            {
                if (_DoorGroupIOGroupOffset != value)
                {
                    _DoorGroupIOGroupOffset = value;
                    OnPropertyChanged(() => DoorGroupIOGroupOffset);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Locked By IO Group Number value. </summary>
        ///
        /// <value> The locked by i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int LockedByIOGroupNumber
        {
            get { return _LockedByIOGroupNumber; }
            set
            {
                if (_LockedByIOGroupNumber != value)
                {
                    _LockedByIOGroupNumber = value;
                    OnPropertyChanged(() => LockedByIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlocked By IO Group Number value. </summary>
        ///
        /// <value> The unlocked by i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int UnlockedByIOGroupNumber
        {
            get { return _UnlockedByIOGroupNumber; }
            set
            {
                if (_UnlockedByIOGroupNumber != value)
                {
                    _UnlockedByIOGroupNumber = value;
                    OnPropertyChanged(() => UnlockedByIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disarm IO Group Number 1 value. </summary>
        ///
        /// <value> The disarm i/o group number 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisarmIOGroupNumber1
        {
            get { return _DisarmIOGroupNumber1; }
            set
            {
                if (_DisarmIOGroupNumber1 != value)
                {
                    _DisarmIOGroupNumber1 = value;
                    OnPropertyChanged(() => DisarmIOGroupNumber1);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disarm IO Group Number 2 value. </summary>
        ///
        /// <value> The disarm i/o group number 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisarmIOGroupNumber2
        {
            get { return _DisarmIOGroupNumber2; }
            set
            {
                if (_DisarmIOGroupNumber2 != value)
                {
                    _DisarmIOGroupNumber2 = value;
                    OnPropertyChanged(() => DisarmIOGroupNumber2);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disarm IO Group Number 3 value. </summary>
        ///
        /// <value> The disarm i/o group number 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisarmIOGroupNumber3
        {
            get { return _DisarmIOGroupNumber3; }
            set
            {
                if (_DisarmIOGroupNumber3 != value)
                {
                    _DisarmIOGroupNumber3 = value;
                    OnPropertyChanged(() => DisarmIOGroupNumber3);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Disarm IO Group Number 4 value. </summary>
        ///
        /// <value> The disarm i/o group number 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int DisarmIOGroupNumber4
        {
            get { return _DisarmIOGroupNumber4; }
            set
            {
                if (_DisarmIOGroupNumber4 != value)
                {
                    _DisarmIOGroupNumber4 = value;
                    OnPropertyChanged(() => DisarmIOGroupNumber4);
                }
            }
        }

        /// <summary>   Information describing the access group. </summary>
        private ICollection<AccessGroupAccessPortal_PanelLoadData> _accessGroupData = new HashSet<AccessGroupAccessPortal_PanelLoadData>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the access group. </summary>
        ///
        /// <value> Information describing the access group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<AccessGroupAccessPortal_PanelLoadData> AccessGroupData
        {
            get { return _accessGroupData; }
            set
            {
                if (_accessGroupData != value)
                {
                    _accessGroupData = value;
                    OnPropertyChanged(() => AccessGroupData, false);
                }
            }
        }

        [DataMember]

        public DateTimeOffset? AccessPortalLastUpdated
        {
            get { return _AccessPortalLastUpdated; }
            set
            {
                if (_AccessPortalLastUpdated != value)
                {
                    _AccessPortalLastUpdated = value;
                    OnPropertyChanged(() => AccessPortalLastUpdated, false);
                }
            }
        }

        public DateTimeOffset? HardwareAddressLastUpdated
        {
            get { return _HardwareAddressLastUpdated; }
            set
            {
                if (_HardwareAddressLastUpdated != value)
                {
                    _HardwareAddressLastUpdated = value;
                    OnPropertyChanged(() => HardwareAddressLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? PassbackIntoAreaLastUpdated
        {
            get { return _PassbackIntoAreaLastUpdated; }
            set
            {
                if (_PassbackIntoAreaLastUpdated != value)
                {
                    _PassbackIntoAreaLastUpdated = value;
                    OnPropertyChanged(() => PassbackIntoAreaLastUpdated, false);
                }
            }
        }

        public DateTimeOffset? PassbackFromAreaLastUpdated
        {
            get { return _PassbackFromAreaLastUpdated; }
            set
            {
                if (_PassbackFromAreaLastUpdated != value)
                {
                    _PassbackFromAreaLastUpdated = value;
                    OnPropertyChanged(() => PassbackFromAreaLastUpdated, false);
                }
            }
        }

        public DateTimeOffset? FreeAccessSchLastUpdated
        {
            get { return _FreeAccessSchLastUpdated; }
            set
            {
                if (_FreeAccessSchLastUpdated != value)
                {
                    _FreeAccessSchLastUpdated = value;
                    OnPropertyChanged(() => FreeAccessSchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? CrisisFreeAccessSchLastUpdated
        {
            get { return _CrisisFreeAccessSchLastUpdated; }
            set
            {
                if (_CrisisFreeAccessSchLastUpdated != value)
                {
                    _CrisisFreeAccessSchLastUpdated = value;
                    OnPropertyChanged(() => CrisisFreeAccessSchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? PinRequiredSchLastUpdated
        {
            get { return _PinRequiredSchLastUpdated; }
            set
            {
                if (_PinRequiredSchLastUpdated != value)
                {
                    _PinRequiredSchLastUpdated = value;
                    OnPropertyChanged(() => PinRequiredSchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? DisableForcedOpenSchLastUpdated
        {
            get { return _DisableForcedOpenSchLastUpdated; }
            set
            {
                if (_DisableForcedOpenSchLastUpdated != value)
                {
                    _DisableForcedOpenSchLastUpdated = value;
                    OnPropertyChanged(() => DisableForcedOpenSchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? DisableOpenTooLongSchLastUpdated
        {
            get { return _DisableOpenTooLongSchLastUpdated; }
            set
            {
                if (_DisableOpenTooLongSchLastUpdated != value)
                {
                    _DisableOpenTooLongSchLastUpdated = value;
                    OnPropertyChanged(() => DisableOpenTooLongSchLastUpdated, false);
                }
            }
        }



        public DateTimeOffset? AuxOutputSchLastUpdated
        {
            get { return _AuxOutputSchLastUpdated; }
            set
            {
                if (_AuxOutputSchLastUpdated != value)
                {
                    _AuxOutputSchLastUpdated = value;
                    OnPropertyChanged(() => AuxOutputSchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? AuxOutputLastUpdated
        {
            get { return _AuxOutputLastUpdated; }
            set
            {
                if (_AuxOutputLastUpdated != value)
                {
                    _AuxOutputLastUpdated = value;
                    OnPropertyChanged(() => AuxOutputLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? Relay2SchLastUpdated
        {
            get { return _Relay2SchLastUpdated; }
            set
            {
                if (_Relay2SchLastUpdated != value)
                {
                    _Relay2SchLastUpdated = value;
                    OnPropertyChanged(() => Relay2SchLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? ForcedOpenAlertLastUpdated
        {
            get { return _ForcedOpenAlertLastUpdated; }
            set
            {
                if (_ForcedOpenAlertLastUpdated != value)
                {
                    _ForcedOpenAlertLastUpdated = value;
                    OnPropertyChanged(() => ForcedOpenAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? OpenTooLongAlertLastUpdated
        {
            get { return _OpenTooLongAlertLastUpdated; }
            set
            {
                if (_OpenTooLongAlertLastUpdated != value)
                {
                    _OpenTooLongAlertLastUpdated = value;
                    OnPropertyChanged(() => OpenTooLongAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? InvalidAccessAttemptAlertLastUpdated
        {
            get { return _InvalidAccessAttemptAlertLastUpdated; }
            set
            {
                if (_InvalidAccessAttemptAlertLastUpdated != value)
                {
                    _InvalidAccessAttemptAlertLastUpdated = value;
                    OnPropertyChanged(() => InvalidAccessAttemptAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? PassbackViolationAlertLastUpdated
        {
            get { return _PassbackViolationAlertLastUpdated; }
            set
            {
                if (_PassbackViolationAlertLastUpdated != value)
                {
                    _PassbackViolationAlertLastUpdated = value;
                    OnPropertyChanged(() => PassbackViolationAlertLastUpdated, false);
                }
            }
        }

        public DateTimeOffset? DuressAlertLastUpdated
        {
            get { return _DuressAlertLastUpdated; }
            set
            {
                if (_DuressAlertLastUpdated != value)
                {
                    _DuressAlertLastUpdated = value;
                    OnPropertyChanged(() => DuressAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? MissedHeartbeatAlertLastUpdated
        {
            get { return _MissedHeartbeatAlertLastUpdated; }
            set
            {
                if (_MissedHeartbeatAlertLastUpdated != value)
                {
                    _MissedHeartbeatAlertLastUpdated = value;
                    OnPropertyChanged(() => MissedHeartbeatAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? AccessGrantedAlertLastUpdated
        {
            get { return _AccessGrantedAlertLastUpdated; }
            set
            {
                if (_AccessGrantedAlertLastUpdated != value)
                {
                    _AccessGrantedAlertLastUpdated = value;
                    OnPropertyChanged(() => AccessGrantedAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? DoorGroupAlertLastUpdated
        {
            get { return _DoorGroupAlertLastUpdated; }
            set
            {
                if (_DoorGroupAlertLastUpdated != value)
                {
                    _DoorGroupAlertLastUpdated = value;
                    OnPropertyChanged(() => DoorGroupAlertLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? UnlockedByIogLastUpdated
        {
            get { return _UnlockedByIogLastUpdated; }
            set
            {
                if (_UnlockedByIogLastUpdated != value)
                {
                    _UnlockedByIogLastUpdated = value;
                    OnPropertyChanged(() => UnlockedByIogLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? LockedByIogLastUpdated
        {
            get { return _LockedByIogLastUpdated; }
            set
            {
                if (_LockedByIogLastUpdated != value)
                {
                    _LockedByIogLastUpdated = value;
                    OnPropertyChanged(() => LockedByIogLastUpdated, false);
                }
            }
        }


        public DateTimeOffset? DisarmIog1LastUpdated
        {
            get { return _DisarmIog1LastUpdated; }
            set
            {
                if (_DisarmIog1LastUpdated != value)
                {
                    _DisarmIog1LastUpdated = value;
                    OnPropertyChanged(() => DisarmIog1LastUpdated, false);
                }
            }
        }

        public DateTimeOffset? DisarmIog2LastUpdated
        {
            get { return _DisarmIog2LastUpdated; }
            set
            {
                if (_DisarmIog2LastUpdated != value)
                {
                    _DisarmIog2LastUpdated = value;
                    OnPropertyChanged(() => DisarmIog2LastUpdated, false);
                }
            }
        }

        
        public DateTimeOffset? DisarmIog3LastUpdated
        {
            get { return _DisarmIog3LastUpdated; }
            set
            {
                if (_DisarmIog3LastUpdated != value)
                {
                    _DisarmIog3LastUpdated = value;
                    OnPropertyChanged(() => DisarmIog3LastUpdated, false);
                }
            }
        }


        public DateTimeOffset? DisarmIog4LastUpdated
        {
            get { return _DisarmIog4LastUpdated; }
            set
            {
                if (_DisarmIog4LastUpdated != value)
                {
                    _DisarmIog4LastUpdated = value;
                    OnPropertyChanged(() => DisarmIog4LastUpdated, false);
                }
            }
        }


        public int CpuNumber
        {
            get { return _CpuNumber; }
            set
            {
                if (_CpuNumber != value)
                {
                    _CpuNumber = value;
                    OnPropertyChanged(() => CpuNumber, false);
                }
            }
        }

        public Guid CpuUid
        {
            get { return _CpuUid; }
            set
            {
                if (_CpuUid != value)
                {
                    _CpuUid = value;
                    OnPropertyChanged(() => CpuUid, false);
                }
            }
        }


        public string ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                if (_serverAddress != value)
                {
                    _serverAddress = value;
                    OnPropertyChanged(() => ServerAddress, true);
                }
            }
        }


        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged(() => IsConnected, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Forced Open Alert Event Is Active value
        /// </summary>

        [DataMember]
        public bool ForcedOpenAlertEventIsActive
        {
            get { return _ForcedOpenAlertEventIsActive; }
            set
            {
                if (_ForcedOpenAlertEventIsActive != value)
                {
                    _ForcedOpenAlertEventIsActive = value;
                    OnPropertyChanged(() => ForcedOpenAlertEventIsActive, true);
                }
            }
        }


        /// <summary>
        /// Get/Set the Open Too Long Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool OpenTooLongAlertEventIsActive
        {
            get { return _OpenTooLongAlertEventIsActive; }
            set
            {
                if (_OpenTooLongAlertEventIsActive != value)
                {
                    _OpenTooLongAlertEventIsActive = value;
                    OnPropertyChanged(() => OpenTooLongAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Invalid Access Attempt Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool InvalidAccessAttemptAlertEventIsActive
        {
            get { return _InvalidAccessAttemptAlertEventIsActive; }
            set
            {
                if (_InvalidAccessAttemptAlertEventIsActive != value)
                {
                    _InvalidAccessAttemptAlertEventIsActive = value;
                    OnPropertyChanged(() => InvalidAccessAttemptAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Passback Violation Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool PassbackViolationAlertEventIsActive
        {
            get { return _PassbackViolationAlertEventIsActive; }
            set
            {
                if (_PassbackViolationAlertEventIsActive != value)
                {
                    _PassbackViolationAlertEventIsActive = value;
                    OnPropertyChanged(() => PassbackViolationAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the DuressAuxiliaryFunction Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool DuressAlertEventIsActive
        {
            get { return _DuressAlertEventIsActive; }
            set
            {
                if (_DuressAlertEventIsActive != value)
                {
                    _DuressAlertEventIsActive = value;
                    OnPropertyChanged(() => DuressAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Missed Heartbeat Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool MissedHeartbeatAlertEventIsActive
        {
            get { return _MissedHeartbeatAlertEventIsActive; }
            set
            {
                if (_MissedHeartbeatAlertEventIsActive != value)
                {
                    _MissedHeartbeatAlertEventIsActive = value;
                    OnPropertyChanged(() => MissedHeartbeatAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Access Granted Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool AccessGrantedAlertEventIsActive
        {
            get { return _AccessGrantedAlertEventIsActive; }
            set
            {
                if (_AccessGrantedAlertEventIsActive != value)
                {
                    _AccessGrantedAlertEventIsActive = value;
                    OnPropertyChanged(() => AccessGrantedAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Door Group Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool DoorGroupAlertEventIsActive
        {
            get { return _DoorGroupAlertEventIsActive; }
            set
            {
                if (_DoorGroupAlertEventIsActive != value)
                {
                    _DoorGroupAlertEventIsActive = value;
                    OnPropertyChanged(() => DoorGroupAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Unlocked By Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool UnlockedByAlertEventIsActive
        {
            get { return _UnlockedByAlertEventIsActive; }
            set
            {
                if (_UnlockedByAlertEventIsActive != value)
                {
                    _UnlockedByAlertEventIsActive = value;
                    OnPropertyChanged(() => UnlockedByAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Locked By Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool LockedByAlertEventIsActive
        {
            get { return _LockedByAlertEventIsActive; }
            set
            {
                if (_LockedByAlertEventIsActive != value)
                {
                    _LockedByAlertEventIsActive = value;
                    OnPropertyChanged(() => LockedByAlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Disarm 1 Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool Disarm1AlertEventIsActive
        {
            get { return _Disarm1AlertEventIsActive; }
            set
            {
                if (_Disarm1AlertEventIsActive != value)
                {
                    _Disarm1AlertEventIsActive = value;
                    OnPropertyChanged(() => Disarm1AlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Disarm 2 Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool Disarm2AlertEventIsActive
        {
            get { return _Disarm2AlertEventIsActive; }
            set
            {
                if (_Disarm2AlertEventIsActive != value)
                {
                    _Disarm2AlertEventIsActive = value;
                    OnPropertyChanged(() => Disarm2AlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Disarm 3 Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool Disarm3AlertEventIsActive
        {
            get { return _Disarm3AlertEventIsActive; }
            set
            {
                if (_Disarm3AlertEventIsActive != value)
                {
                    _Disarm3AlertEventIsActive = value;
                    OnPropertyChanged(() => Disarm3AlertEventIsActive, true);
                }
            }
        }

        /// <summary>
        /// Get/Set the Disarm 4 Alert Event Is Active value
        /// </summary>

        [DataMember]

        public bool Disarm4AlertEventIsActive
        {
            get { return _Disarm4AlertEventIsActive; }
            set
            {
                if (_Disarm4AlertEventIsActive != value)
                {
                    _Disarm4AlertEventIsActive = value;
                    OnPropertyChanged(() => Disarm4AlertEventIsActive, true);
                }
            }
        }
        #endregion
    }

}
