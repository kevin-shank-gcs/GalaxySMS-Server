////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Connection6xx.cs
//
// summary:	Implements the connection 6xx class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Business.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Framework.Flash;
using GCS.Framework.Utilities;
using GCS.PanelCommunicationServerAsync.Entities;
using GCS.PanelCommunicationServerAsync.Interfaces;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.PanelPacketConverters;
using GCS.PanelProtocols.Series5xx;
using GCS.PanelProtocols.Series6xx;
using GCS.PanelProtocols.Series6xx.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GCS.PanelCommunicationServerAsync.Support;
using GCS.PanelProtocols;
using AbaSettings = GalaxySMS.Business.Entities.AbaSettings;
using AccessPortal_PanelLoadData = GalaxySMS.Business.Entities.AccessPortal_PanelLoadData;
using AccessPortalAuxiliaryOutputMode = GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode;
using AccessPortalCommandAction = GalaxySMS.Business.Entities.AccessPortalCommandAction;
using AccessPortalDeferToServerBehavior = GalaxySMS.Common.Enums.AccessPortalDeferToServerBehavior;
using AccessPortalListItem = GalaxySMS.Client.Entities.AccessPortalListItem;
using AccessPortalNoServerReplyBehavior = GalaxySMS.Common.Enums.AccessPortalNoServerReplyBehavior;
using AccessPortalStatusReply = GalaxySMS.Business.Entities.AccessPortalStatusReply;
using ActivityLoggingState = GalaxySMS.Business.Entities.ActivityLoggingState;
using BoardSectionHardwareAddress = GalaxySMS.Business.Entities.BoardSectionHardwareAddress;
using BoardSectionNodeHardwareAddress = GalaxySMS.Business.Entities.BoardSectionNodeHardwareAddress;
using CardaxSettings = GalaxySMS.Business.Entities.CardaxSettings;
using CpuConnectionInfo = GalaxySMS.Business.Entities.CpuConnectionInfo;
using Credential_PanelLoadData = GalaxySMS.Business.Entities.Credential_PanelLoadData;
using CredentialCountReply = GalaxySMS.Business.Entities.CredentialCountReply;
using CredentialToDeleteFromCpu = GalaxySMS.Business.Entities.CredentialToDeleteFromCpu;
using CrisisModeSettings = GalaxySMS.Business.Entities.CrisisModeSettings;
using DataReceivedEventHandler = GCS.PanelCommunicationServerAsync.Interfaces.DataReceivedEventHandler;
using FirmwareVersion = GalaxySMS.Business.Entities.FirmwareVersion;
using FlashProgressMessage = GalaxySMS.Business.Entities.FlashProgressMessage;
using GalaxyCpuConnection = GalaxySMS.Client.Entities.GalaxyCpuConnection;
using GalaxyCpuDatabaseInformation = GalaxySMS.Business.Entities.GalaxyCpuDatabaseInformation;
using GalaxyInputDelayType = GalaxySMS.Common.Enums.GalaxyInputDelayType;
using GalaxyInputMode = GalaxySMS.Common.Enums.GalaxyInputMode;
using GalaxyInterfaceBoardSection = GalaxySMS.Client.Entities.GalaxyInterfaceBoardSection;
using GalaxyInterfaceBoardSection_PanelLoadData = GalaxySMS.Business.Entities.GalaxyInterfaceBoardSection_PanelLoadData;
using GalaxyInterfaceBoardSectionCommandAction = GalaxySMS.Business.Entities.GalaxyInterfaceBoardSectionCommandAction;
using GalaxyLoadFlashCommandAction = GalaxySMS.Business.Entities.GalaxyLoadFlashCommandAction;
using GalaxyOutputInputSourceMode = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode;
using GalaxyOutputMode = GalaxySMS.Common.Enums.GalaxyOutputMode;
using GalaxyPanelResetCommand = GalaxySMS.Business.Entities.GalaxyPanelResetCommand;
using InitializeBoardSectionSettings = GalaxySMS.Business.Entities.InitializeBoardSectionSettings;
using InputDeviceCommandAction = GalaxySMS.Business.Entities.InputDeviceCommandAction;
using InputDeviceStatusReply = GalaxySMS.Business.Entities.InputDeviceStatusReply;
using InputDeviceVoltagesReply = GalaxySMS.Business.Entities.InputDeviceVoltagesReply;
using InputOutputGroupCommandAction = GalaxySMS.Business.Entities.InputOutputGroupCommandAction;
using LoggingStatusReply = GalaxySMS.Business.Entities.LoggingStatusReply;
using OutputDeviceCommandAction = GalaxySMS.Business.Entities.OutputDeviceCommandAction;
using PanelActivityLogMessage = GalaxySMS.Business.Entities.PanelActivityLogMessage;
using PanelActivityLogMessageBase = GalaxySMS.Business.Entities.PanelActivityLogMessageBase;
using PanelBoardInformationCollection = GalaxySMS.Business.Entities.PanelBoardInformationCollection;
using PanelCredentialActivityLogMessage = GalaxySMS.Business.Entities.PanelCredentialActivityLogMessage;
using PanelInqueryReply = GalaxySMS.Business.Entities.PanelInqueryReply;
using PanelLoadDataReply = GalaxySMS.Business.Entities.PanelLoadDataReply;
using PanelMessageBase = GalaxySMS.Business.Entities.PanelMessageBase;
using PinRequiredMode = GalaxySMS.Common.Enums.PinRequiredMode;
using RawDataToSend = GalaxySMS.Business.Entities.RawDataToSend;
using ReaderLockoutSettings = GalaxySMS.Business.Entities.ReaderLockoutSettings;
using SerialChannelGalaxyDoorModuleDataCollection = GalaxySMS.Business.Entities.SerialChannelGalaxyDoorModuleDataCollection;
using SerialChannelGalaxyInputModuleDataCollection = GalaxySMS.Business.Entities.SerialChannelGalaxyInputModuleDataCollection;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;
using WiegandSettings = GalaxySMS.Business.Entities.WiegandSettings;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Connection6xxParameters
    {
        public Connection6xxParameters(ConnectionManagerAsync parent, SocketAsyncEventArgs socketAsyncEventArgs, CryptoType cryptoType, string phrase, BlockingCollection<object> processingQueue, BlockingCollection<object> recordingQueue, string serverAddress, int ackLogMessageIndexMinimumInterval, int operationTimeoutSecondsDefaultValue)
        {
            Parent = parent;
            SocketAsyncEventArgs = socketAsyncEventArgs;
            CryptoType = cryptoType;
            Phrase = phrase;
            ProcessingQueue = processingQueue;
            RecordingQueue = recordingQueue;
            ServerAddress = serverAddress;
            AckLogMessageIndexMinimumInterval = ackLogMessageIndexMinimumInterval;
            OperationTimeoutSecondsDefaultValue = operationTimeoutSecondsDefaultValue;
        }

        public ConnectionManagerAsync Parent { get; private set; }
        public SocketAsyncEventArgs SocketAsyncEventArgs { get; private set; }
        public CryptoType CryptoType { get; private set; }
        public string Phrase { get; private set; }
        public BlockingCollection<object> ProcessingQueue { get; private set; }
        public BlockingCollection<object> RecordingQueue { get; private set; }
        public string ServerAddress { get; private set; }
        public int AckLogMessageIndexMinimumInterval { get; private set; }
        public int OperationTimeoutSecondsDefaultValue { get; private set; }
    }

    /// <summary>   Connection 6xx. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [System.Runtime.InteropServices.GuidAttribute("8D8EC705-F98A-4A82-A9C4-4EA377403872")]
    public class Connection6xx : IPanelConnection
    {
        #region Private enum and constants

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent SignOnState. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private enum SignOnState
        {
            /// <summary>	An enum constant representing the not authenticated option. </summary>
            NotAuthenticated,
            /// <summary>	An enum constant representing the sent sign on challange option. </summary>
            SentSignOnChallange,
            /// <summary>	An enum constant representing the sent date time synchronise option. </summary>
            SentDateTimeSync,
            /// <summary>	An enum constant representing the authenticated option. </summary>
            Authenticated
        }

        /// <summary>   The minimum send interval minimum value. </summary>
        private const int minimumSendIntervalMinimumValue = 0;
        /// <summary>   The minimum send interval maximum value. </summary>
        private const int minimumSendIntervalMaximumValue = 100;

        private const uint SpecialOpIdOr = 0x80000000;
        #endregion

        #region Private fields
        /// <summary>   true if disposed. </summary>
        private bool _disposed = false;
        /// <summary>   The client. </summary>
        private SocketAsyncEventArgs _socketEventArgs;
        /// <summary>   The owner. </summary>
        private ConnectionManagerAsync _owner;
        /// <summary>   The receiver. </summary>
        private readonly GCS.PanelProtocols.SenderReceiver6xx _receiver;
        /// <summary>   Number of last heartbeat received ticks. </summary>
        private int _lastHeartbeatReceivedTickCount;
        /// <summary>   Number of last send ticks. </summary>
        private int _lastSendTickCount = System.Environment.TickCount;
        /// <summary>   The minimum send interval for 600 panels. </summary>
        private int _minimumSendInterval600 = 0;
        /// <summary>   The minimum send interval for 635 panels. </summary>
        private int _minimumSendInterval635 = 0;

        /// <summary>   The minimum send interval for 7xx panels. </summary>
        private int _minimumSendInterval7xx = 0;

        //        private int _inputOutputGroupLoadTimerInterval = 500;
        private int _loadDataTimerInterval = 500;
        //private int _requestDataThatNeedsTimerInterval = 0;

        /// <summary>   The transmit sequence. </summary>
        private UInt32 _transmitSequence = 1;
        /// <summary>   Type of the crypto. </summary>
        private GCS.PanelProtocols.CryptoType _cryptoType;
        /// <summary>   The phrase. </summary>
        private String _phrase;
        /// <summary>   State of the sign on. </summary>
        private SignOnState _signOnState;
        /// <summary>   The timer. 1 second timer for controlling heartbeats</summary>
        private Timer _timer;

        /// <summary>   The flash load timer. </summary>
        private Timer _flashLoadtimer;

        /// <summary>   The load data timer. </summary>
        private Timer _loadDataTimer;

        /// <summary>   true if connection close event raised. </summary>
        private bool _connectionCloseEventRaised = false;

        /// <summary>   Queue of processings. </summary>
        //       private System.Collections.Concurrent.ConcurrentQueue<object> processingQueue;
        /// <summary>   Queue of processings. </summary>
        private readonly System.Collections.Concurrent.BlockingCollection<object> _processingQueue;
        /// <summary>   Queue of recordings. </summary>
        private readonly System.Collections.Concurrent.BlockingCollection<object> _recordingQueue;

        private readonly string _serverAddress;

        /// <summary>   The session identifiers for response codes. </summary>
        private Dictionary<UInt16, List<Guid>> _sessionIdsForResponseCodes = new Dictionary<UInt16, List<Guid>>();
        private Dictionary<UInt16, List<Guid>> _sessionIdsForAckNackResponseCodes = new Dictionary<UInt16, List<Guid>>();
        //private Dictionary<UInt32, MessageTrackingData> _messageTrackingDictionary = new Dictionary<UInt32, MessageTrackingData>();
        private Dictionary<UInt32, List<MessageTrackingData>> _messageTrackingDictionary = new Dictionary<UInt32, List<MessageTrackingData>>();
        //private ConcurrentDictionary<Guid, DateTimeOffset> _operationTrackingExpirationDictionary = new ConcurrentDictionary<Guid, DateTimeOffset>();

        /// <summary>   Default to the standard (8 bit cluster & unit) format. </summary>
        private SohCode _sohValue = SohCode.UInt8ClusterAndPanelIds;
        /// <summary>   / &lt;summary&gt;   Date/Time of the date time created. </summary>

        private DateTimeOffset _dateTimeLastReceive = DateTimeOffset.MinValue;
        /// <summary>   Date/Time of the datetime last send. </summary>
        private DateTimeOffset _datetimeLastSend = DateTimeOffset.MinValue;

        /// <summary>   Information describing the CPU connection. </summary>
        private CpuConnectionInfo _cpuConnectionInfo = new CpuConnectionInfo();

        /// <summary>   The CPU information reply. </summary>
        private CpuInformationReply _cpuInformationReply;
        /// <summary>   The CPU total card count reply. </summary>
        private CpuTotalCardCountReply _cpuTotalCardCountReply;
        /// <summary>   The CPU activity logging information reply. </summary>
        private CpuActivityLoggingInformationReply _cpuActivityLoggingInformationReply;


        /// <summary>   The panel inquery reply. </summary>
        private PanelInqueryReply _panelInqueryReply;
        /// <summary>   The card count reply. </summary>
        private CredentialCountReply _cardCountReply;
        /// <summary>   The logging status reply. </summary>
        private LoggingStatusReply _loggingStatusReply;
        //private GalaxySiteServerConnection _siteServerConnection;
        /// <summary>   The board information with boot response. </summary>
        private BoardInformationWithBootResponse _boardInformationWithBootResponse;
        /// <summary>   The board information reply. </summary>
        private PanelBoardInformationCollection _boardInformationReply;

        /// <summary>   Unique identifier for the instance. </summary>
        private Guid _instanceGuid;
        //private ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket> recentReceivedPackets;
        //private ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket> recentTransmittedPackets;

        //		private ActivityLogMessageCardHelper cardHelper;
        /// <summary>   The card helpers. </summary>
        private ConcurrentDictionary<string, ActivityLogMessageCardHelper> _cardHelpers = new ConcurrentDictionary<string, ActivityLogMessageCardHelper>();
        /// <summary>   The minimum event date time. </summary>
        private DateTimeOffset _minEventDateTime = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
        /// <summary>   List of access portals. </summary>
        private Dictionary<string, GalaxySMS.Client.Entities.AccessPortalListItem> _accessPortalList = new Dictionary<string, GalaxySMS.Client.Entities.AccessPortalListItem>();
        private Dictionary<string, GalaxySMS.Client.Entities.InputDeviceListItem> _inputDeviceList = new Dictionary<string, GalaxySMS.Client.Entities.InputDeviceListItem>();
        private Dictionary<string, GalaxySMS.Client.Entities.OutputDeviceListItem> _outputDeviceList = new Dictionary<string, GalaxySMS.Client.Entities.OutputDeviceListItem>();
        private Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoard> _interfaceBoards = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoard>();
        private Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSection> _interfaceBoardSections = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSection>();
        private Dictionary<string, GalaxySMS.Client.Entities.GalaxyHardwareModule> _hardwareModules = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyHardwareModule>();
        private Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSectionNode> _interfaceBoardSectionNodes = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSectionNode>();

        private Dictionary<string, GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType> _boardSectionTypes = new Dictionary<string, GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType>();

        private FlashLoadingData _flashLoadingData = null;
        private DateTimeOffset _lastSentFlashStatus = DateTimeOffset.Now;
        private GalaxySMS.Business.Entities.SendDataParameters<InputOutputGroup_PanelLoadData> _ioGroupDataToLoad;
        //private Timer _ioGroupLoadTimer;
        //private IList<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>> _personalAccessGroupDataToLoad = new List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>();
        private SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>> _personalAccessGroupDataToLoadParams = new SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>>();
        private List<SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>>> _personalAccessGroupDataToLoadQueue = new List<SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>>>();
        //private IList<Credential_PanelLoadData> _credentialDataToSend = new List<Credential_PanelLoadData>();
        private IList<SendDataParameters<List<Credential_PanelLoadData>>> _credentialDataToSendQueue = new List<SendDataParameters<List<Credential_PanelLoadData>>>();
        private SendDataParameters<List<Credential_PanelLoadData>> _credentialDataToSendParams = new SendDataParameters<List<Credential_PanelLoadData>>();
        private IList<GalaxySMS.Business.Entities.SendDataParameters<AccessPortal_PanelLoadData>> _accessPortalDataToLoad = new List<GalaxySMS.Business.Entities.SendDataParameters<AccessPortal_PanelLoadData>>();
        private IList<GalaxySMS.Business.Entities.SendDataParameters<InputDevice_PanelLoadData>> _inputDeviceDataToLoad = new List<GalaxySMS.Business.Entities.SendDataParameters<InputDevice_PanelLoadData>>();
        private IList<GalaxySMS.Business.Entities.SendDataParameters<OutputDevice_PanelLoadData>> _outputDeviceDataToLoad = new List<GalaxySMS.Business.Entities.SendDataParameters<OutputDevice_PanelLoadData>>();
        private IList<CredentialToDeleteFromCpu> _credentialDataToDelete = new List<CredentialToDeleteFromCpu>();
        private IList<GalaxySMS.Business.Entities.SendDataParameters<AccessGroup_PanelLoadData>> _accessGroupDataToLoad = new List<GalaxySMS.Business.Entities.SendDataParameters<AccessGroup_PanelLoadData>>();

        private GalaxySMS.Client.Entities.GalaxyCpuDatabaseInformation _cpuDbInfo;
        private ActionScheduler _scheduler = new ActionScheduler();
        private string _oemCode = string.Empty;
        private int _retrySignonCount = 0;
        private bool _bHardwareTreeBuiltSuccessfully;
        private DateTimeOffset _lastSentAckToLogMessageIndex;
        private int _ackLogMessageIndexMinimumInterval;
        private readonly int _operationTimeoutSecondsDefaultValue;
        private uint _lastLogMessageBufferIndex;
        private uint _lastLogMessageBufferIndexAcked;

        //private Timer _requestDataThatNeedsLoadedTimer;
        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an unique identifier of the instance. </summary>
        ///
        /// <value> Unique identifier of the instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string InstanceGuid
        {
            get { return _instanceGuid.ToString(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the information describing the connection. </summary>
        ///
        /// <value> Information describing the connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ConnectionDescription
        {
            get { return string.Format("ClusterGroupId:{0}, Cluster:{1}, Panel:{2}, CPU:{3}", ClusterGroupId, ClusterId, PanelId, CpuId); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the connected client. </summary>
        ///
        /// <value> The connected client. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Socket Socket
        {
            get
            {
                if (this._socketEventArgs.UserToken == null)
                    return this._socketEventArgs.AcceptSocket;
                return ((AsyncUserToken)this._socketEventArgs.UserToken).Socket;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this object is authenticated. </summary>
        ///
        /// <value> true if this object is authenticated, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsAuthenticated
        {
            get
            {
                if (_signOnState == SignOnState.Authenticated)
                    return true;
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the debugging mode. </summary>
        ///
        /// <value> true if debugging mode, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DebuggingMode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the minimum send interval for 600 panesl. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The minimum send interval. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MinimumSendInterval600
        {
            get
            {
                return _minimumSendInterval600;
            }
            set
            {
                if (value < minimumSendIntervalMinimumValue || value > minimumSendIntervalMaximumValue)
                {
                    throw new ArgumentOutOfRangeException("MinimumSendInterval600", value, string.Format("The value must be between {0} and {1}", minimumSendIntervalMinimumValue, minimumSendIntervalMaximumValue));
                }
                else
                {
                    _minimumSendInterval600 = value;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the minimum send interval for 635 panesl. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The minimum send interval. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MinimumSendInterval635
        {
            get
            {
                return _minimumSendInterval635;
            }
            set
            {
                if (value < minimumSendIntervalMinimumValue || value > minimumSendIntervalMaximumValue)
                {
                    throw new ArgumentOutOfRangeException("MinimumSendInterval635", value, string.Format("The value must be between {0} and {1}", minimumSendIntervalMinimumValue, minimumSendIntervalMaximumValue));
                }
                else
                {
                    _minimumSendInterval635 = value;
                }
            }
        }

        public int MinimumSendInterval7xx
        {
            get
            {
                return _minimumSendInterval7xx;
            }
            set
            {
                if (value < minimumSendIntervalMinimumValue || value > minimumSendIntervalMaximumValue)
                {
                    throw new ArgumentOutOfRangeException("MinimumSendInterval7xx", value, string.Format("The value must be between {0} and {1}", minimumSendIntervalMinimumValue, minimumSendIntervalMaximumValue));
                }
                else
                {
                    _minimumSendInterval7xx = value;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the information describing the CPU connection. </summary>
        ///
        /// <value> Information describing the CPU connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuConnectionInfo CpuConnectionInfo
        {
            get { return _cpuConnectionInfo; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the cluster. </summary>
        ///
        /// <value> The identifier of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClusterId
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.ClusterNumber; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClusterGroupId
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.ClusterGroupId; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the panel. </summary>
        ///
        /// <value> The identifier of the panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int PanelId
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.PanelNumber; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the CPU. </summary>
        ///
        /// <value> The identifier of the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public short CpuId
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.CpuId; }
        }

        public Guid? ClusterUid => CpuConnectionInfo?.CpuDatabaseInformation?.ClusterUid;
        public Guid? GalaxyPanelUid => CpuConnectionInfo?.CpuDatabaseInformation?.GalaxyPanelUid;
        public Guid? CpuUid => CpuConnectionInfo?.CpuDatabaseInformation?.CpuUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the CPU model. </summary>
        ///
        /// <value> The CPU model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuModel CpuModel
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.CpuModel; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the serial number. </summary>
        ///
        /// <value> The serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String SerialNumber
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.SerialNumber; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Date/Time of the date time created. </summary>
        ///
        /// <value> The date time created. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeCreated { get { return CpuConnectionInfo.CreatedDateTime; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Date/Time of the date time last receive. </summary>
        ///
        /// <value> The date time last receive. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeLastReceive { get { return _dateTimeLastReceive; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Date/Time of the date time last send. </summary>
        ///
        /// <value> The date time last send. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeLastSend { get { return _datetimeLastSend; } }


        public FirmwareVersion FlashVersion
        {
            get { return CpuConnectionInfo?.GalaxyCpuInformation?.InqueryReply?.Version; }
        }

        public Guid EntityId
        {
            get
            {
                if (CpuConnectionInfo?.CpuDatabaseInformation?.EntityId == null)
                    return Guid.Empty;
                return CpuConnectionInfo.CpuDatabaseInformation.EntityId;
            }
        }

        public string EntityName
        {
            get
            {
                if (CpuConnectionInfo?.CpuDatabaseInformation?.EntityName == null)
                    return string.Empty;
                return CpuConnectionInfo.CpuDatabaseInformation.EntityName;
            }
        }

        public string EntityType
        {
            get
            {
                if (CpuConnectionInfo?.CpuDatabaseInformation?.EntityType == null)
                    return string.Empty;
                return CpuConnectionInfo.CpuDatabaseInformation.EntityType;
            }
        }


        public string TimeZoneId
        {
            get
            {
                return CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// public Int32 RecentPacketsReceivedBufferSize { get; set; }
        /// public Int32 RecentPacketsTransmittedBufferSize { get; set; }
        /// public ReadOnlyObservableCollection&lt;GCS.PanelProtocols.Series6xx.DataPacket&gt;
        /// RecentPacketsReceived {get { return new ReadOnlyObservableCollection&lt;
        /// GCS.PanelProtocols.Series6xx.DataPacket&gt;(this.recentReceivedPackets);
        /// }}
        /// public ReadOnlyObservableCollection&lt;GCS.PanelProtocols.Series6xx.DataPacket&gt;
        /// RecentPacketsTransmitted { get { return new ReadOnlyObservableCollection&lt;
        /// GCS.PanelProtocols.Series6xx.DataPacket&gt;(this.recentTransmittedPackets);
        /// } }
        /// </summary>
        ///
        /// <value> The socket event arguments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SocketAsyncEventArgs SocketEventArgs
        {
            get { return _socketEventArgs; }
        }
        #endregion

        #region Public Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Delegate for handling DataReceived events. </summary>
        ///
        /// <param name="sender">	Source of the event. </param>
        /// <param name="e">		 	Data received event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>   Event queue for all listeners interested in dataReceived events. </summary>
        public event DataReceivedEventHandler DataReceivedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DataPacketReceived events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel data packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DataPacketReceivedEventHandler(object sender, PanelDataPacketEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in panelToPanelPacketReceived events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event DataPacketReceivedEventHandler PanelToPanelPacketReceivedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Delegate for handling DebugPacket events. </summary>
        ///
        /// <param name="sender">	Source of the event. </param>
        /// <param name="e">		 	Connection debug packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>   Event queue for all listeners interested in debugPacket events. </summary>
        public event DebugPacketEventHandler DebugPacketEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Delegate for handling ConnectionStateChanged events. </summary>
        ///
        /// <param name="sender">	Source of the event. </param>
        /// <param name="e">		 	Connection state change event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>   Event queue for all listeners interested in connectionStateChanged events. </summary>
        public event ConnectionStateChangedEventHandler ConnectionStateChangedEvent;
        /// <summary>   Event queue for all listeners interested in connectionClosed events. </summary>
        public event ConnectionClosedEventHandler ConnectionClosedEvent;
        /// <summary>   Event queue for all listeners interested in panelInformation events. </summary>
        public event PanelInformationEventHandler PanelInformationEvent;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Constructor. </summary>
        ///
        /// <param name="parent">						The parent. </param>
        /// <param name="socketAsyncEventArgs">	The TCP client. </param>
        /// <param name="cryptoType">					Type of the crypto. </param>
        /// <param name="phrase">						The phrase. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// public Connection6xx(ConnectionManagerAsync parent, SocketAsyncEventArgs socketAsyncEventArgs,
        /// GCS.PanelProtocols.CryptoType cryptoType, String phrase,
        /// System.Collections.Concurrent.BlockingCollection<object> processingQueue,
        /// System.Collections.Concurrent.BlockingCollection<object> recordingQueue,
        /// GalaxySiteServerConnection siteServerConnection)
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parent">               The parent. </param>
        /// <param name="socketAsyncEventArgs"> Socket asynchronous event information. </param>
        /// <param name="cryptoType">           Type of the crypto. </param>
        /// <param name="phrase">               The phrase. </param>
        /// <param name="processingQueue">      Queue of processings. </param>
        /// <param name="recordingQueue">       Queue of recordings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Connection6xx(Connection6xxParameters connectionParameters)
        {
            //DebuggingMode = true;
            this._owner = connectionParameters.Parent;
            _instanceGuid = Guid.NewGuid();
            _cpuConnectionInfo.GalaxyCpuInformation.InstanceGuid = InstanceGuid;

            // Get Stream Object
            this._socketEventArgs = connectionParameters.SocketAsyncEventArgs;
            this._processingQueue = connectionParameters.ProcessingQueue;
            this._recordingQueue = connectionParameters.RecordingQueue;
            this._ackLogMessageIndexMinimumInterval = connectionParameters.AckLogMessageIndexMinimumInterval;
            _operationTimeoutSecondsDefaultValue = connectionParameters.OperationTimeoutSecondsDefaultValue;

            _serverAddress = connectionParameters.ServerAddress;
            //this._siteServerConnection = siteServerConnection;
            //GCS.Framework.Logging.LogWriter.LogInformation("Connection6xx constructor. Setting signOnState = SignOnState.NotAuthenticated");
            this.Log().InfoFormat("Connection6xx constructor. Setting signOnState = SignOnState.NotAuthenticated");
            _signOnState = SignOnState.NotAuthenticated;
            _cpuConnectionInfo.CreatedDateTime = DateTimeOffset.Now;

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = Socket;

            this._cryptoType = connectionParameters.CryptoType;
            this._phrase = connectionParameters.Phrase;

            _receiver = new PanelProtocols.SenderReceiver6xx(connectionParameters.CryptoType, connectionParameters.Phrase);

            //recentReceivedPackets = new ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket>();
            //recentTransmittedPackets = new ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket>();

            _transmitSequence = 1;

            SendSignOnChallenge();
            _timer = new Timer(TimerCallback, null, 5000, 1000);
        }
        #endregion

        #region Send/Receive Data From Sockets

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Send this message. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Send(byte[] data)
        {
            try
            {
                //				System.Diagnostics.Trace.WriteLine(string.Format("Send on thread:{0}, {1}", Thread.CurrentThread.ManagedThreadId, this.ConnectionDescription));
                if (Socket.Connected == false)
                {
                    this.Log().DebugFormat("{0}, {1} {2} - Skipping send because object has been disposed", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    return;
                }

                if (CpuConnectionInfo != null)
                {
                    int ticksSinceLastSend = System.Environment.TickCount - _lastSendTickCount;
                    int sleepTicks = 0;

                    switch (CpuConnectionInfo.GalaxyCpuInformation.CpuModel)
                    {
                        case CpuModel.Cpu600:
                            if (ticksSinceLastSend < MinimumSendInterval600)
                            {
                                sleepTicks = MinimumSendInterval600 - ticksSinceLastSend;
                                this.Log().DebugFormat("sleeping for {0} ms", sleepTicks);
                            }
                            break;

                        case CpuModel.Cpu635:
                            if (ticksSinceLastSend < MinimumSendInterval635)
                            {
                                sleepTicks = MinimumSendInterval635 - ticksSinceLastSend;
                                this.Log().DebugFormat("sleeping for {0} ms", sleepTicks);
                            }
                            break;

                        case CpuModel.Cpu708:
                            if (ticksSinceLastSend < MinimumSendInterval7xx)
                            {
                                sleepTicks = MinimumSendInterval7xx - ticksSinceLastSend;
                                this.Log().DebugFormat("sleeping for {0} ms", sleepTicks);
                            }
                            break;

                    }

                    if (sleepTicks > 0)
                        System.Threading.Thread.Sleep(sleepTicks);
                }

                if (DebuggingMode == true)
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0}, {1} - Sending {2} bytes: ", DateTimeOffset.Now.ToString(), ConnectionDescription, data.Length));
                    this.Log().DebugFormat("{0}, {1} - Sending {2} bytes: ", DateTimeOffset.Now.ToString(), ConnectionDescription, data.Length);
                    string dbg = string.Empty;
                    for (int x = 0; x < data.Length; x++)
                        dbg += string.Format("{0:x2}", data[x]);
                    //GCS.Framework.Logging.LogWriter.Trace(dbg);
                    this.Log().Debug(dbg);
                }

                _lastSendTickCount = System.Environment.TickCount;

                Socket.Send(data);
                _datetimeLastSend = DateTimeOffset.Now;

            }
            catch (SocketException socketException)
            {
                //if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                {
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("Send() SocketException.ErrorCode: {0}", socketException.ErrorCode));
                    this.Log().Info("Send() SocketException", socketException);
                    if (Socket.Connected == true)
                    {
                    }
                }
            }
            catch (ObjectDisposedException objectDisposedException)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("Send() objectDisposedException: {0}", objectDisposedException.Message));
                this.Log().Info("Send() ObjectDisposedException", objectDisposedException);
                if (Socket.Connected == true)
                {
                }
            }
            // Eat up exception....Hmmmm I'm loving eat!!!
            catch (Exception exception)
            {
                //GCS.Framework.Logging.LogWriter.Trace(exception.Message + "\n" + exception.StackTrace);
                this.Log().Info("Send() Exception", exception);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the receive action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    [in,out] The archive. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void HandleReceiveData(ref SocketAsyncEventArgs e)
        {
            // Read data from the client socket. 
            //			System.Diagnostics.Trace.WriteLine(string.Format("HandleReceiveData on thread:{0}, {1}", Thread.CurrentThread.ManagedThreadId, this.ConnectionDescription));
            try
            {
                _socketEventArgs = e;
                // There  might be more data, so store the data received so far.
                byte[] theData = new byte[_socketEventArgs.BytesTransferred];
                Array.Copy(_socketEventArgs.Buffer, _socketEventArgs.Offset, theData, 0, _socketEventArgs.BytesTransferred);
                Int32 index = 0;
                int len = _socketEventArgs.BytesTransferred;

                if (DebuggingMode == true)
                {
                    string dbg = string.Empty;
                    for (int x = 0; x < theData.Length; x++)
                        dbg += string.Format("{0:x2}", theData[x]);
                    this.Log().DebugFormat("Raw data: {0}", dbg);
                    //this.Log().Debug(dbg);
                }


                while ((len--) > 0)
                {
                    if (_receiver.ReceiveByte(theData[index++]) == true)
                    {	// A COMPLETE MESSAGE HAS BEEN RECEIVED
                        this._dateTimeLastReceive = DateTimeOffset.Now;

                        var packet = _receiver.Packet;
                        _receiver.Init();
                        bool bValid = packet.IsValid();
                        if (bValid == true)
                        {
                            _sohValue = (SohCode)_receiver.SohValue;
                            _lastHeartbeatReceivedTickCount = System.Environment.TickCount;
                            ProcessPacket(ref packet);
                        }
                        else
                        {
                            this.Log().DebugFormat("packet.IsValid() returned false");
                            if (IsAuthenticated == false)
                            {	// if the connection is not authenticated, drop the connection
                                //GCS.Framework.Logging.LogWriter.LogInformation("Dropping connection. Not Authenticated!!!\n");
                                this.Log().InfoFormat("HandleReceiveData Dropping connection. Not Authenticated!!!\n");
                                PrepareToClose(false);
                            }
                        }
                    }
                }
            }
            catch (SocketException socketException)
            {
                //WSAECONNRESET, the other side closed impolitely
                //				if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                {
                    // Complete the disconnect request.
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("OnReceive() SocketException.ErrorCode: {0}", socketException.ErrorCode));
                    this.Log().Error("HandleReceiveData() SocketException", socketException);
                    PrepareToClose(false);
                }
            }

            // Eat up exception....Hmmmm I'm loving eat!!!
            catch (Exception exception)
            {
                //GCS.Framework.Logging.LogWriter.LogException(exception);
                //System.Diagnostics.Trace.Write(exception.Message + "\n" + exception.StackTrace);
                this.Log().Error($"HandleReceiveData() Exception: {exception}", exception);

            }
            //			GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0} OnReceive exited", DateTimeOffset.Now.ToString()));
        }
        #endregion

        #region Private methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the packet described by pkt. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ApplicationException"> Thrown when an Application error condition occurs. </exception>
        ///
        /// <param name="pkt">  [in,out] The packet. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ProcessPacket(ref IDataPacket6xx pkt)
        {
            var forceColdReset = false;
            if (IsAuthenticated == true)
            {
                if (pkt.ClusterId != ClusterId ||
                    pkt.PanelId != PanelId ||
                    (short)pkt.Cpu != CpuId)
                {
                    PrepareToClose(false);
                    var exceptionMessage = $"{DateTimeOffset.Now} Connection6xx {ConnectionDescription} {InstanceGuid} CPU address changed, mis-match; received packet from Cluster:{pkt.ClusterId}, Panel:{pkt.PanelId}, CPU:{pkt.Cpu} Data:{GCS.Core.Common.Utils.HexEncoding.ToString(pkt.Data, false, "0x", false, 0)}";
                    throw new ApplicationException(exceptionMessage);
                }
            }

            var nowInTz = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(TimeZoneId);

            if (DebuggingMode == true)
            {
                var debugHandler = DebugPacketEvent;
                if (debugHandler != null)
                {
                    debugHandler(this, new ConnectionDebugPacketEventArgs(ref pkt, DataDirection.ReceivedFromPanel, this.CpuConnectionInfo));
                }
            }

            if ((PacketDataCodeFrom6xx)pkt.Data[0] != PacketDataCodeFrom6xx.CpuHeartbeat)
                SendToRecordingQueue(pkt);

            if (_signOnState == SignOnState.Authenticated && _bHardwareTreeBuiltSuccessfully == false)
            {
                Task.Run(async () =>
                {
                    await BuildHardwareDeviceDataList();
                }).Wait();
            }

            uint opId = 0;
            switch ((PacketDataCodeFrom6xx)pkt.Data[0])
            {
                case PacketDataCodeFrom6xx.CpuHeartbeat:
                    //this.Log().DebugFormat("{0}, {1} {2} - heartbeat received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    break;

                case PacketDataCodeFrom6xx.ResponseSignOnOemCodeFailure:
                    if (_retrySignonCount == 0)
                    {
                        if (string.IsNullOrEmpty(_oemCode))
                        {
                            _oemCode = "7094-4A80-D53D-7E36-9E93-D5F4-B3CC-0E3F-53C0-C475";
                            SendSignOnChallengeWithOemCode();
                        }
                        else
                        {
                            _oemCode = string.Empty;
                            SendSignOnChallenge();
                        }
                        _retrySignonCount++;
                        break;
                    }
                    PrepareToClose(false);
                    return false;

                case PacketDataCodeFrom6xx.ResponseSignOnChallenge:
                    //this.Log().DebugFormat("{0}, {1} {2} - ResponseSignOnChallenge received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    if (this._signOnState == SignOnState.SentSignOnChallange)
                    {
                        var clusterId = pkt.ClusterId;
                        var panelId = pkt.PanelId;
                        var cpuId = pkt.Cpu;
                        var length = pkt.Length;
                        var data = pkt.Data;
                        Task.Run(async () =>
                        {
                            await AcceptSignOnChallengeResponse(clusterId, panelId, (short)cpuId, data, length);
                        }).Wait();
                    }
                    else
                    {
                        PrepareToClose(false);
                        return false;
                    }
                    break;

                case PacketDataCodeFrom6xx.ResponseAck:
                case PacketDataCodeFrom6xx.ResponseNack:
                    //this.Log().DebugFormat("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCodeTo6xx)pkt.Data[1]).ToString());
                    if (pkt.Data[1] == (byte)PacketDataCodeTo6xx.CommandSetDateTime &&
                        _signOnState == SignOnState.SentDateTimeSync)
                    {
                        if ((PacketDataCodeFrom6xx)pkt.Data[0] == PacketDataCodeFrom6xx.ResponseNack)
                        {
                            HandleSetDateTimeChallenge(ref pkt);
                            break;
                        }
                        //GCS.Framework.Logging.LogWriter.LogInformation("ProcessPacket PacketDataCode6xx.ResponseAck. Setting signOnState = SignOnState.Authenticated");
                        //this.Log().DebugFormat("ProcessPacket PacketDataCode6xx.ResponseAck. Setting signOnState = SignOnState.Authenticated");
                        _signOnState = SignOnState.Authenticated;
                        _cpuConnectionInfo.RemoteIpEndpoint = this.Socket.RemoteEndPoint.ToString();
                        _cpuConnectionInfo.LocalIpEndpoint = this.Socket.LocalEndPoint.ToString();
                        _cpuConnectionInfo.IsAuthenticated = IsAuthenticated;
                        _cpuConnectionInfo.IsConnected = true;
                        _cpuConnectionInfo.Description = ConnectionDescription;
                        _cpuConnectionInfo.SocketHandle = this.Socket.Handle.ToString();


                        SendToProcessingQueue(CpuConnectionInfo, null);

                        HandleSetDateTimeChallenge(ref pkt);
                        SetLoggingState(ActivityLoggingState.Off, null);
                        var sendToAddress = new SendDataParameters<GalaxyCpuCommandAction>()
                        {
                            SendToAddress = new BoardSectionNodeHardwareAddress()
                            {
                                PanelNumber = (int)PanelNumber.AllPanels
                            }
                        };

                        SendGetLoggingInfo(sendToAddress);
                        SendGetControllerInfo(sendToAddress);
                        SendGetCardCount(sendToAddress);
                        SendRequestBoardInformation(sendToAddress);

                        if (CpuUid.HasValueAndNotEmpty())
                        {
                            Task.Run(async () =>
                            {
                                await BuildHardwareDeviceDataList();
                                await SendSetLoggingPointersAsync(true);

                            }).Wait();
                        }

                        RaiseConnectionStateChangedEvent();
                    }

                    switch (pkt.Data[1])
                    {
                        case (byte)PacketDataCodeTo6xx.CommandBeginFlashLoad635:
                        case (byte)PacketDataCodeTo6xx.CommandBeginFlashLoad600:
                        case (byte)PacketDataCodeTo6xx.CommandLoadFlashPacket600:
                        case (byte)PacketDataCodeTo6xx.CommandLoadFlashPacket635:
                            SendFlashProgressMessageToProcessingQueue((PacketDataCodeTo6xx)pkt.Data[1], AckNack.Ack);
                            if (_flashLoadingData != null && _flashLoadingData.Paused == false) // it is possible for the loading to be paused or cancelled before the last ack is received. For this reason, the _flashLoadingData must be checked for non-null and the Paused flag must also be checked to ensure that the timer does not get started if paused
                                StartFlashLoadTimer();
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandValidateFlash635:
                        case (byte)PacketDataCodeTo6xx.CommandValidateFlash600:
                        case (byte)PacketDataCodeTo6xx.CommandValidateThenBurnFlash635:
                        case (byte)PacketDataCodeTo6xx.CommandValidateThenBurnFlash600:
                            if ((PacketDataCodeFrom6xx)pkt.Data[0] == PacketDataCodeFrom6xx.ResponseNack)
                                SendFlashProgressMessageToProcessingQueue((PacketDataCodeTo6xx)pkt.Data[1], AckNack.Nack);
                            else
                                SendFlashProgressMessageToProcessingQueue((PacketDataCodeTo6xx)pkt.Data[1], AckNack.Ack);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData:
                            var bst = GetBoardSectionType(pkt.BoardSectionAddressString);
                            var loadBoardSectionDataReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, bst, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as PanelLoadDataReply;
                            SendDataParameters originalLoadBoardSectionNodeDataCommand = null;
                            if (loadBoardSectionDataReply != null)
                            {
                                var expectedLoadBoardSectionNodeResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                                if (expectedLoadBoardSectionNodeResponseData != null)
                                {
                                    originalLoadBoardSectionNodeDataCommand = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters;
                                    switch (bst)
                                    {
                                        case PanelInterfaceBoardSectionType.Unused:
                                            break;
                                        case PanelInterfaceBoardSectionType.VeridtReader:
                                            break;
                                        case PanelInterfaceBoardSectionType.DrmSection:
                                        case PanelInterfaceBoardSectionType.RS485DoorModule:
                                            GalaxySMS.Client.Entities.AccessPortalListItem ap = null;
                                            if (_accessPortalList.TryGetValue(loadBoardSectionDataReply.UniqueIdAsAccessPortal, out ap))
                                            {
                                                if (ap != null)
                                                {
                                                    loadBoardSectionDataReply.ItemGuid = ap.UniqueUid;
                                                    loadBoardSectionDataReply.Description = ap.Name;
                                                }
                                            }

                                            if (expectedLoadBoardSectionNodeResponseData != null &&
                                                originalLoadBoardSectionNodeDataCommand != null)
                                            {
                                                var originalReaderData = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters<AccessPortal_PanelLoadData>;
                                                if (originalReaderData != null)
                                                {
                                                    loadBoardSectionDataReply.OperationUid = originalReaderData.OperationUid;
                                                    loadBoardSectionDataReply.Description = originalReaderData.Data.PortalName;
                                                }
                                            }
                                            break;
                                        case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                            loadBoardSectionDataReply.ModuleNumber = 1;
                                            loadBoardSectionDataReply.NodeNumber = pkt.Data[3];
                                            loadBoardSectionDataReply.ItemNumber = loadBoardSectionDataReply.NodeNumber;
                                            GalaxySMS.Client.Entities.OutputDeviceListItem odA = null;
                                            if (_outputDeviceList.TryGetValue(
                                                    loadBoardSectionDataReply.UniqueIdAsOutputDevice, out odA))
                                            {
                                                if (odA != null)
                                                    loadBoardSectionDataReply.ItemGuid = odA.UniqueUid;
                                            }
                                            if (expectedLoadBoardSectionNodeResponseData != null && originalLoadBoardSectionNodeDataCommand != null)
                                            {
                                                var originalDioData = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters<OutputDevice_PanelLoadData>;
                                                if (originalDioData != null)
                                                {
                                                    loadBoardSectionDataReply.OperationUid = originalDioData.OperationUid;
                                                    loadBoardSectionDataReply.Description = originalDioData.Data.OutputName;
                                                }
                                            }
                                            break;
                                        case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                            loadBoardSectionDataReply.ModuleNumber = 1;
                                            loadBoardSectionDataReply.NodeNumber = pkt.Data[3];
                                            loadBoardSectionDataReply.ItemNumber = loadBoardSectionDataReply.NodeNumber;
                                            GalaxySMS.Client.Entities.InputDeviceListItem idA = null;
                                            if (_inputDeviceList.TryGetValue(
                                                    loadBoardSectionDataReply.UniqueIdAsInputDevice, out idA))
                                            {
                                                if (idA != null)
                                                    loadBoardSectionDataReply.ItemGuid = idA.UniqueUid;
                                            }
                                            if (expectedLoadBoardSectionNodeResponseData != null &&
                                                originalLoadBoardSectionNodeDataCommand != null)
                                            {
                                                var originalDioData = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters<InputDevice_PanelLoadData>;
                                                if (originalDioData != null)
                                                {
                                                    loadBoardSectionDataReply.OperationUid = originalDioData.OperationUid;
                                                    loadBoardSectionDataReply.Description = originalDioData.Data.InputName;
                                                }
                                            }
                                            break;

                                        case PanelInterfaceBoardSectionType.RS485InputModule:
                                            loadBoardSectionDataReply.ModuleNumber = pkt.Data[3];
                                            loadBoardSectionDataReply.NodeNumber = pkt.Data[2];
                                            loadBoardSectionDataReply.ItemNumber = loadBoardSectionDataReply.NodeNumber;
                                            if (loadBoardSectionDataReply.NodeNumber != 0)
                                            {
                                                // This means that only 1 input out of the possible 18 on the module was loaded
                                                GalaxySMS.Client.Entities.InputDeviceListItem idB = null;
                                                if (_inputDeviceList.TryGetValue(loadBoardSectionDataReply.UniqueIdAsInputDevice, out idB))
                                                {
                                                    if (idB != null)
                                                        loadBoardSectionDataReply.ItemGuid = idB.UniqueUid;
                                                }
                                            }
                                            else
                                            {
                                                // 0 means that all of the inputs were loaded. Generate separate messages for each input on the module
                                                for (int x = 1; x <= 18; x++)
                                                {
                                                    var lbsdr = new PanelLoadDataReply(loadBoardSectionDataReply);
                                                    lbsdr.NodeNumber = x;
                                                    lbsdr.ItemNumber = lbsdr.NodeNumber;
                                                    GalaxySMS.Client.Entities.InputDeviceListItem idC = null;
                                                    if (_inputDeviceList.TryGetValue(lbsdr.UniqueIdAsInputDevice, out idC))
                                                    {
                                                        if (idC != null)
                                                            lbsdr.ItemGuid = idC.UniqueUid;

                                                        if (expectedLoadBoardSectionNodeResponseData != null && originalLoadBoardSectionNodeDataCommand != null)
                                                        {
                                                            var originalInputData = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters<InputDevice_PanelLoadData>;
                                                            if (originalInputData != null)
                                                            {
                                                                loadBoardSectionDataReply.OperationUid = originalInputData.OperationUid;
                                                                loadBoardSectionDataReply.Description = originalInputData.Data.InputName;
                                                            }
                                                            SendToProcessingQueue(loadBoardSectionDataReply, originalLoadBoardSectionNodeDataCommand.GetGuidsToSendTo());
                                                        }
                                                        else
                                                            SendToProcessingQueue(lbsdr, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                                                    }
                                                }

                                                loadBoardSectionDataReply = null;
                                            }

                                            break;

                                        case PanelInterfaceBoardSectionType.OutputRelays:
                                            loadBoardSectionDataReply.ModuleNumber = 1;
                                            loadBoardSectionDataReply.NodeNumber = loadBoardSectionDataReply.NodeNumber;
                                            loadBoardSectionDataReply.ItemNumber = loadBoardSectionDataReply.NodeNumber;
                                            if (loadBoardSectionDataReply.NodeNumber != 0)
                                            {
                                                GalaxySMS.Client.Entities.OutputDeviceListItem odB = null;
                                                if (_outputDeviceList.TryGetValue(
                                                        loadBoardSectionDataReply.UniqueIdAsOutputDevice, out odB))
                                                {
                                                    if (odB != null)
                                                        loadBoardSectionDataReply.ItemGuid = odB.UniqueUid;
                                                }
                                            }
                                            if (expectedLoadBoardSectionNodeResponseData != null && originalLoadBoardSectionNodeDataCommand != null)
                                            {
                                                var originalDioData = expectedLoadBoardSectionNodeResponseData.OriginalData as SendDataParameters<OutputDevice_PanelLoadData>;
                                                if (originalDioData != null)
                                                {
                                                    loadBoardSectionDataReply.OperationUid = originalDioData.OperationUid;
                                                    loadBoardSectionDataReply.Description = originalDioData.Data.OutputName;
                                                }
                                            }
                                            break;

                                        case PanelInterfaceBoardSectionType.ElevatorRelays:
                                            break;
                                        case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                            break;
                                        case PanelInterfaceBoardSectionType.AllegionPimAba:
                                            break;
                                        case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                            break;
                                        case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                            break;
                                        case PanelInterfaceBoardSectionType.SaltoSallis:
                                            break;
                                        case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                            break;
                                        case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                            break;
                                        case PanelInterfaceBoardSectionType.VeridtCpu:
                                            break;
                                    }
                                }
                            }

                            if (loadBoardSectionDataReply != null)
                            {
                                if (originalLoadBoardSectionNodeDataCommand != null)
                                {
                                    SendToProcessingQueue(loadBoardSectionDataReply, originalLoadBoardSectionNodeDataCommand.GetGuidsToSendTo());
                                }
                                else
                                {

                                    SendToProcessingQueue(loadBoardSectionDataReply, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                                }
                            }

                            LoadDataTimerCallback(null);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoadIOGroupArmSchedule:
                            var ioGroupData = (PanelLoadDataReply)Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId,
                                PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid,
                                GalaxyPanelUid, CpuUid, TimeZoneId);
                            ioGroupData.CreatedDateTime = nowInTz;
                            var expectedLoadIOGroupDataResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedLoadIOGroupDataResponseData != null)
                            {
                                var originalCommand = expectedLoadIOGroupDataResponseData.OriginalData as SendDataParameters<InputOutputGroup_PanelLoadData>;
                                if (originalCommand != null)
                                {
                                    ioGroupData.OperationUid = originalCommand.OperationUid;
                                }
                                SendToProcessingQueue(ioGroupData, originalCommand.GetGuidsToSendTo());
                            }
                            else
                            {
                                SendToProcessingQueue(ioGroupData, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }

                            LoadDataTimerCallback(null);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandInitializeBoardSection:
                            var convertedInitBoardSectionResponse = Packet6xxConverters.ConvertFrom(pkt,
                                this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty,
                                Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as PanelLoadDataReply;
                            var expectedInitBoardSectionResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedInitBoardSectionResponseData != null)
                            {
                                var originalCommand = expectedInitBoardSectionResponseData.OriginalData as SendDataParameters<InitializeBoardSectionSettings>;
                                if (originalCommand != null)
                                {
                                    convertedInitBoardSectionResponse.OperationUid = originalCommand.OperationUid;

                                    SendToProcessingQueue(convertedInitBoardSectionResponse, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                            {
                                SendToProcessingQueue(convertedInitBoardSectionResponse, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoadPersonalDoors:
                            var personDoorLoadData = (PanelLoadDataReply)Packet6xxConverters.ConvertFrom(pkt,
                                this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty,
                                Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                            personDoorLoadData.CreatedDateTime = nowInTz;
                            var expectedLoadCardPersonalDoorDataResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedLoadCardPersonalDoorDataResponseData != null)
                            {
                                var originalCommand = expectedLoadCardPersonalDoorDataResponseData.OriginalData as SendDataParameters<List<PersonalAccessGroup_PanelLoadData>>;
                                if (originalCommand != null)
                                {
                                    personDoorLoadData.OperationUid = originalCommand.OperationUid;
                                    SendToProcessingQueue(personDoorLoadData, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                            {
                                SendToProcessingQueue(personDoorLoadData, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }

                            LoadDataTimerCallback(null);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoadStandardCards:
                        case (byte)PacketDataCodeTo6xx.CommandLoadExtendedCards:
                            var loadCardData = (PanelLoadDataReply)Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                            loadCardData.CreatedDateTime = nowInTz;

                            var expectedLoadCardDataResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedLoadCardDataResponseData != null)
                            {
                                var originalCommand = expectedLoadCardDataResponseData.OriginalData as SendDataParameters<List<Credential_PanelLoadData>>;
                                if (originalCommand != null)
                                {
                                    foreach (var c in loadCardData.CredentialsLoaded)
                                    {
                                        var newReply = new PanelLoadDataReply(loadCardData, false)
                                        {
                                            OperationUid = originalCommand.OperationUid
                                        };

                                        newReply.CredentialsLoaded.Add(c);
                                        Task.Run(async () =>
                                        {
                                            var cred = await Globals.Instance.GetCredentialActivityEventData(c.CardData);
                                            if (cred != null)
                                            {
                                                newReply.ItemGuid = cred.CredentialUid;
                                                newReply.ItemString =
                                                    $"{cred.CardBinaryDataAsHexString} ({cred.ActivityEventText} - {cred.CredentialDescription})";
                                            }
                                        }).Wait();
                                        SendToProcessingQueue(newReply, originalCommand.GetGuidsToSendTo());
                                    }
                                }
                            }
                            else
                            {
                                foreach (var c in loadCardData.CredentialsLoaded)
                                {
                                    var newReply = new PanelLoadDataReply(loadCardData, false);
                                    newReply.CredentialsLoaded.Add(c);
                                    Task.Run(async () =>
                                    {
                                        var cred = await Globals.Instance.GetCredentialActivityEventData(c.CardData);
                                        if (cred != null)
                                        {
                                            newReply.ItemGuid = cred.CredentialUid;
                                            newReply.ItemString = $"{cred.CardBinaryDataAsHexString} ({cred.ActivityEventText} - {cred.CredentialDescription})";
                                        }
                                    }).Wait();
                                    SendToProcessingQueue(newReply, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                                }
                            }

                            LoadDataTimerCallback(null);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandDeleteCard:
                            SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            LoadDataTimerCallback(null);
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandPulseDoor:
                        case (byte)PacketDataCodeTo6xx.CommandDisableDoor:
                        case (byte)PacketDataCodeTo6xx.CommandEnableDoor:
                        case (byte)PacketDataCodeTo6xx.CommandLockDoor:
                        case (byte)PacketDataCodeTo6xx.CommandUnlockDoor:
                        case (byte)PacketDataCodeTo6xx.CommandRelay2Off:
                        case (byte)PacketDataCodeTo6xx.CommandRelay2On:
                        case (byte)PacketDataCodeTo6xx.CommandSetLedTemporaryState:
                            opId = BitConverter.ToUInt32(pkt.Data, 2);
                            var expectedAccessPortalCommandResponseData = GetExpectedResponseInfo(opId);
                            if (expectedAccessPortalCommandResponseData != null)
                            {
                                var originalCommand =
                                    expectedAccessPortalCommandResponseData.OriginalData as SendDataParameters<AccessPortalCommandAction>;
                                if (originalCommand != null)
                                {
                                    var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                                        this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, originalCommand.Data.AccessPortalUid, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                                    SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());

                                    //SendToProcessingQueue(new SignalREnvelope<OperationStatusInfo>()
                                    //{
                                    //    Payload = new OperationStatusInfo()
                                    //    {
                                    //        OperationUid = originalCommand.OperationUid,
                                    //        Successful = true
                                    //    }, SignalRGroupUids = sessionUids
                                    //}, sessionUids);
                                }
                            }
                            else
                                SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandSetCrisisMode:
                        case (byte)PacketDataCodeTo6xx.CommandResetCrisisMode:
                        case (byte)PacketDataCodeTo6xx.CommandPing:
                        case (byte)PacketDataCodeTo6xx.CommandForgivePassbackEverybody:
                        case (byte)PacketDataCodeTo6xx.CommandClearAllUsers:
                        case (byte)PacketDataCodeTo6xx.CommandClearAutoTimer:
                        case (byte)PacketDataCodeTo6xx.CommandRecalibrate:
                            opId = BitConverter.ToUInt32(pkt.Data, 2);
                            var expectedPanelCommandResponseData = GetExpectedResponseInfo(opId);
                            if (expectedPanelCommandResponseData != null)
                            {
                                var originalCommand = expectedPanelCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                                if (originalCommand != null)
                                {
                                    var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                                        this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                                    var convertedItemType = convertedItem.GetType();
                                    SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                                SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoggingResetPointers:
                            opId = BitConverter.ToUInt32(pkt.Data, 3);
                            var expectedResetLoggingCommandResponseData = GetExpectedResponseInfo(opId);
                            if (expectedResetLoggingCommandResponseData != null)
                            {
                                var originalCommand = expectedResetLoggingCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                                if (originalCommand != null)
                                {
                                    var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                                        this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                                    var convertedItemType = convertedItem.GetType();
                                    SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                                SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandCardEnable:
                        case (byte)PacketDataCodeTo6xx.CommandCardDisable:
                        case (byte)PacketDataCodeTo6xx.CommandForgivePassbackCard:
                            var convertedCardCommandResponse = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty,
                                ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as GalaxyCpuCommandReply;
                            var expectedCardCommandResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedCardCommandResponseData != null)
                            {
                                var originalCommand = expectedCardCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                                if (originalCommand != null)
                                {
                                    convertedCardCommandResponse.OperationUid = originalCommand.OperationUid;

                                    if (originalCommand.Data.CredentialBytesList.Any())
                                    {
                                        var idx = 0;
                                        foreach (var cardData in originalCommand.Data.CredentialBytesList)
                                        {
                                            if (cardData.IsCardDataEqual(convertedCardCommandResponse.CredentialBytes))
                                            {
                                                convertedCardCommandResponse.CredentialUid = originalCommand.Data.CredentialUids[idx];
                                                originalCommand.Data.CredentialUids.RemoveAt(idx);
                                                originalCommand.Data.CredentialBytesList.RemoveAt(idx);
                                                break;
                                            }
                                        }
                                    }

                                    SendToProcessingQueue(convertedCardCommandResponse, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                            {
                                SendToProcessingQueue(convertedCardCommandResponse, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }

                            //SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            break;

                        case (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleDayTypes:
                        case (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriod:
                        case (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriodsForDayType:
                        case (byte)PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidayTable:
                        case (byte)PacketDataCodeTo6xx.CommandLoadTimeSchedule15MinuteFormat:
                        case (byte)PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidays:
                        case (byte)PacketDataCodeTo6xx.CommandLoadABAOptions:
                        case (byte)PacketDataCodeTo6xx.CommandLoadWiegandStartStopSettings:
                        case (byte)PacketDataCodeTo6xx.CommandLoadCardaxStartStopSettings:
                        case (byte)PacketDataCodeTo6xx.CommandLoadLockoutOptions:
                        case (byte)PacketDataCodeTo6xx.CommandLoadLedOptions:
                        case (byte)PacketDataCodeTo6xx.CommandLoadCrisisModeIOGroup:
                        case (byte)PacketDataCodeTo6xx.CommandSetServerConsultationOptions:
                        case (byte)PacketDataCodeTo6xx.CommandLoadTamperAcFailureLowBattery:
                        case (byte)PacketDataCodeTo6xx.CommandClearAccessGroupRange:
                        case (byte)PacketDataCodeTo6xx.CommandLoadAccessGroupSchedulesForDoor:
                        case (byte)PacketDataCodeTo6xx.LoadAccessGroupCrisisGroup:
                        case (byte)PacketDataCodeTo6xx.CommandLoadAccessGroupSchedule:
                            var convertedLoadDataResponse = Packet6xxConverters.ConvertFrom(pkt,
                                this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty,
                                Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as PanelLoadDataReply;
                            var expectedLoadDataResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedLoadDataResponseData != null)
                            {
                                var originalCommand = expectedLoadDataResponseData.OriginalData as SendDataParameters;
                                if (originalCommand != null)
                                {
                                    convertedLoadDataResponse.OperationUid = originalCommand.OperationUid;

                                    SendToProcessingQueue(convertedLoadDataResponse, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                            {
                                SendToProcessingQueue(convertedLoadDataResponse, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }

                            break;

                        case (byte)PacketDataCodeTo6xx.EchoNack:
                            var convertedEchoNackResponse = Packet6xxConverters.ConvertFrom(pkt,
                                this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty,
                                Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as EchoReply;
                            var expectedEchoReplyResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                            if (expectedEchoReplyResponseData != null)
                            {
                                var originalCommand = expectedEchoReplyResponseData.OriginalData as SendDataParameters;
                                if (originalCommand != null)
                                {
                                    convertedEchoNackResponse.OperationUid = originalCommand.OperationUid;

                                    SendToProcessingQueue(convertedEchoNackResponse, originalCommand.GetGuidsToSendTo());
                                }
                            }
                            else
                            {
                                SendToProcessingQueue(convertedEchoNackResponse, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            }
                            break;

                        default:
                            SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                            break;
                    }
                    break;




                //case PacketDataCodeFrom6xx.ResponseNack:
                //    this.Log().DebugFormat("{0}, {1} - Nack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCodeTo6xx)pkt.Data[1]).ToString());
                //    var bstNack = PanelInterfaceBoardSectionType.Unused;
                //    if (pkt.Data[1] == (byte)PacketDataCodeTo6xx.CommandSetDateTime &&
                //        _signOnState == SignOnState.SentDateTimeSync)
                //    {
                //        HandleSetDateTimeChallenge(ref pkt);
                //    }
                //    else
                //    {
                //        switch (pkt.Data[1])
                //        {
                //            case (byte)PacketDataCodeTo6xx.CommandValidateFlash635:
                //            case (byte)PacketDataCodeTo6xx.CommandValidateFlash600:
                //            case (byte)PacketDataCodeTo6xx.CommandValidateThenBurnFlash635:
                //            case (byte)PacketDataCodeTo6xx.CommandValidateThenBurnFlash600:
                //                SendFlashProgressMessageToProcessingQueue((PacketDataCodeTo6xx)pkt.Data[1], AckNack.Nack);
                //                break;

                //            case (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData:
                //                bstNack = GetBoardSectionType(pkt.BoardSectionAddressString);
                //                SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, bstNack, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //                break;

                //            case (byte)PacketDataCodeTo6xx.CommandPulseDoor:
                //            case (byte)PacketDataCodeTo6xx.CommandDisableDoor:
                //            case (byte)PacketDataCodeTo6xx.CommandEnableDoor:
                //            case (byte)PacketDataCodeTo6xx.CommandLockDoor:
                //            case (byte)PacketDataCodeTo6xx.CommandUnlockDoor:
                //            case (byte)PacketDataCodeTo6xx.CommandRelay2Off:
                //            case (byte)PacketDataCodeTo6xx.CommandRelay2On:
                //            case (byte)PacketDataCodeTo6xx.CommandSetLedTemporaryState:
                //                opId = BitConverter.ToUInt32(pkt.Data, 2);
                //                var expectedApCmdResponseData = GetExpectedResponseInfo(opId);
                //                if (expectedApCmdResponseData != null)
                //                {
                //                    var originalCommand =
                //                        expectedApCmdResponseData.OriginalData as SendDataParameters<AccessPortalCommandAction>;
                //                    if (originalCommand != null)
                //                    {
                //                        var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                //                            this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, originalCommand.Data.AccessPortalUid, ClusterUid, GalaxyPanelUid, CpuUid);
                //                        SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());
                //                    }
                //                }
                //                break;

                //            case (byte)PacketDataCodeTo6xx.CommandSetCrisisMode:
                //            case (byte)PacketDataCodeTo6xx.CommandResetCrisisMode:
                //            case (byte)PacketDataCodeTo6xx.CommandPing:
                //            case (byte)PacketDataCodeTo6xx.CommandForgivePassbackEverybody:
                //            case (byte)PacketDataCodeTo6xx.CommandClearAllUsers:
                //            case (byte)PacketDataCodeTo6xx.CommandClearAutoTimer:
                //            case (byte)PacketDataCodeTo6xx.CommandRecalibrate:
                //                opId = BitConverter.ToUInt32(pkt.Data, 2);
                //                var expectedPanelCommandResponseData = GetExpectedResponseInfo(opId);
                //                if (expectedPanelCommandResponseData != null)
                //                {
                //                    var originalCommand = expectedPanelCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                //                    if (originalCommand != null)
                //                    {
                //                        var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                //                            this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid);
                //                        var convertedItemType = convertedItem.GetType();
                //                        SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());
                //                    }
                //                }
                //                else
                //                    SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //                break;

                //            //case (byte)PacketDataCodeTo6xx.CommandCardEnable:
                //            //case (byte)PacketDataCodeTo6xx.CommandCardDisable:
                //            //case (byte)PacketDataCodeTo6xx.CommandForgivePassbackCard:
                //            //    SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //            //    break;

                //            case (byte)PacketDataCodeTo6xx.CommandLoggingResetPointers:
                //                opId = BitConverter.ToUInt32(pkt.Data, 3);
                //                var expectedRestLoggingCommandResponseData = GetExpectedResponseInfo(opId);
                //                if (expectedRestLoggingCommandResponseData != null)
                //                {
                //                    var originalCommand = expectedRestLoggingCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                //                    if (originalCommand != null)
                //                    {
                //                        var convertedItem = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel,
                //                            this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, originalCommand.OperationUid, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid);
                //                        var convertedItemType = convertedItem.GetType();
                //                        SendToProcessingQueue(convertedItem, originalCommand.GetGuidsToSendTo());
                //                    }
                //                }
                //                else
                //                    SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //                break;

                //            case (byte)PacketDataCodeTo6xx.CommandCardEnable:
                //            case (byte)PacketDataCodeTo6xx.CommandCardDisable:
                //            case (byte)PacketDataCodeTo6xx.CommandForgivePassbackCard:
                //                var convertedCardCommandResponse = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty,
                //                    ClusterUid, GalaxyPanelUid, CpuUid) as GalaxyCpuCommandReply;
                //                var expectedCardCommandResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[1]);
                //                if (expectedCardCommandResponseData != null)
                //                {
                //                    var originalCommand = expectedCardCommandResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                //                    if (originalCommand != null)
                //                    {
                //                        convertedCardCommandResponse.OperationUid = originalCommand.OperationUid;

                //                        if (originalCommand.Data.CredentialBytesList.Any())
                //                        {
                //                            var idx = 0;
                //                            foreach (var cardData in originalCommand.Data.CredentialBytesList)
                //                            {
                //                                if (cardData.IsCardDataEqual(convertedCardCommandResponse.CredentialBytes))
                //                                {
                //                                    convertedCardCommandResponse.CredentialUid = originalCommand.Data.CredentialUids[idx];
                //                                    originalCommand.Data.CredentialUids.RemoveAt(idx);
                //                                    originalCommand.Data.CredentialBytesList.RemoveAt(idx);
                //                                    break;
                //                                }
                //                            }
                //                        }

                //                        SendToProcessingQueue(convertedCardCommandResponse, originalCommand.GetGuidsToSendTo());
                //                    }
                //                }
                //                else
                //                {
                //                    SendToProcessingQueue(convertedCardCommandResponse, GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //                }

                //                break;


                //            default:
                //                SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, bstNack, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //                break;
                //        }
                //    }
                //    //SendToProcessingQueue(Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, bstNack), GetSessionIdsForAckNackResponseCode((UInt16)pkt.Data[1]));
                //    break;

                case PacketDataCodeFrom6xx.ResponsePanelInquire:
                    _cpuInformationReply = new CpuInformationReply(pkt.Data);
                    switch (_cpuInformationReply.ModelNumber)
                    {
                        case 500:
                            _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel = CpuModel.Cpu5xx;
                            break;

                        case 600:
                            _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel = CpuModel.Cpu600;
                            break;

                        case 635:
                            _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel = CpuModel.Cpu635;
                            break;

                        case 708:
                            _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel = CpuModel.Cpu708;
                            break;

                        default:
                            _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel = CpuModel.Unknown;
                            break;
                    }

                    CpuConnectionInfo.GalaxyCpuInformation.CpuModel = _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CpuModel;
                    _cpuConnectionInfo.RemoteIpEndpoint = this.Socket.RemoteEndPoint.ToString();
                    _cpuConnectionInfo.LocalIpEndpoint = this.Socket.LocalEndPoint.ToString();
                    _cpuConnectionInfo.IsAuthenticated = IsAuthenticated;
                    _cpuConnectionInfo.IsConnected = true;
                    _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.SerialNumber = System.Text.Encoding.ASCII.GetString(_cpuInformationReply.SerialNumber);
                    _cpuConnectionInfo.Description = ConnectionDescription;
                    _cpuConnectionInfo.SocketHandle = this.Socket.Handle.ToString();
                    _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.Version.Major = _cpuInformationReply.Version.Major;
                    _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.Version.Minor = _cpuInformationReply.Version.Minor;
                    _cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.Version.LetterCode = _cpuInformationReply.Version.LetterCode;

                    _panelInqueryReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as PanelInqueryReply;
                    var expectedPanelInfoResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[0]);
                    if (expectedPanelInfoResponseData != null)
                    {
                        var originalCommand = expectedPanelInfoResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                        if (originalCommand != null)
                        {
                            _panelInqueryReply.OperationUid = originalCommand.OperationUid;
                            SendToProcessingQueue(_panelInqueryReply, originalCommand.GetGuidsToSendTo());
                        }
                    }
                    else
                    {
                        SendToProcessingQueue(_panelInqueryReply, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }

                    RaisePanelInformationEvent();

                    //SetLoggingState(ActivityLoggingState.On);
                    break;

                case PacketDataCodeFrom6xx.ResponseRequestLoggingInformation:
                    _cpuActivityLoggingInformationReply = new CpuActivityLoggingInformationReply(pkt.Data);
                    _loggingStatusReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as LoggingStatusReply;

                    var expectedLoggingInfoResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[0]);
                    if (expectedLoggingInfoResponseData != null)
                    {
                        var originalCommand = expectedLoggingInfoResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                        if (originalCommand != null)
                        {
                            _loggingStatusReply.OperationUid = originalCommand.OperationUid;
                            SendToProcessingQueue(_loggingStatusReply, originalCommand.GetGuidsToSendTo());
                        }
                    }
                    else
                    {
                        SendToProcessingQueue(_loggingStatusReply, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }

                    RaisePanelInformationEvent();
                    break;

                case PacketDataCodeFrom6xx.ResponseTotalCardCount:
                    _cpuTotalCardCountReply = new CpuTotalCardCountReply(pkt.Data);
                    _cardCountReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as CredentialCountReply;

                    var expectedCardCountResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[0]);
                    if (expectedCardCountResponseData != null)
                    {
                        var originalCommand = expectedCardCountResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                        if (originalCommand != null)
                        {
                            _cardCountReply.OperationUid = originalCommand.OperationUid;
                            SendToProcessingQueue(_cardCountReply, originalCommand.GetGuidsToSendTo());
                        }
                    }
                    else
                    {
                        SendToProcessingQueue(_cardCountReply, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }

                    RaisePanelInformationEvent();
                    break;

                case PacketDataCodeFrom6xx.ResponseConnectedBoardInformation:
                    _boardInformationWithBootResponse = new BoardInformationWithBootResponse(pkt.Data, pkt.Length);
                    _boardInformationReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as PanelBoardInformationCollection;

                    var expectedResponseData = GetExpectedResponseInfo(SpecialOpIdOr | (uint)(PacketDataCodeFrom6xx)pkt.Data[0]);
                    if (expectedResponseData != null)
                    {
                        var originalCommand = expectedResponseData.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                        if (originalCommand != null)
                        {
                            _boardInformationReply.OperationUid = originalCommand.OperationUid;
                            SendToProcessingQueue(_boardInformationReply, originalCommand.GetGuidsToSendTo());
                            //var sessionUids = new List<Guid>();
                            //sessionUids.Add(originalCommand.OperationUid);
                            //sessionUids.Add(originalCommand.ApplicationUserSessionHeader.SessionGuid);
                            //SendToProcessingQueue(new SignalREnvelope<OperationStatusInfo>()
                            //{
                            //    Payload = new OperationStatusInfo()
                            //    {
                            //        OperationUid = originalCommand.OperationUid,
                            //        Successful = false
                            //    },
                            //    SignalRGroupUids = sessionUids
                            //}, sessionUids);
                        }
                    }
                    else
                    {
                        SendToProcessingQueue(_boardInformationReply, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }
                    RaisePanelInformationEvent();
                    break;

                case PacketDataCodeFrom6xx.ResponseSerialChannelRS485DeviceInfo:
                    switch ((DualSerialChannelMode)pkt.Data[1])
                    {
                        case DualSerialChannelMode.RS485DoorModule:
                            //var doorModuleData = new RS485ChannelGalaxyDoorModuleStatusResponse(pkt.Data, pkt.Length);
                            var serialChannelDoorModuleData = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.RS485DoorModule, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as SerialChannelGalaxyDoorModuleDataCollection;
                            SendToProcessingQueue(serialChannelDoorModuleData, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                            break;

                        case DualSerialChannelMode.RS485InputModule:
                            //                            var inputModuleData = new RS485ChannelGalaxyInputModuleStatusResponse(pkt.Data, pkt.Length);
                            var serialChannelInputModuleData = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.RS485InputModule, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as SerialChannelGalaxyInputModuleDataCollection;
                            SendToProcessingQueue(serialChannelInputModuleData, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                            break;

                    }

                    //_boardInformationReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.None) as PanelBoardInformationCollection;
                    //SendToProcessingQueue(_boardInformationReply, GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    //RaisePanelInformationEvent();
                    break;

                case PacketDataCodeFrom6xx.ActivityLogMessage:
                    if (_signOnState != SignOnState.Authenticated)
                        break;
                    object activityLogMessage = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                    object activityLog = null;
                    if (activityLogMessage is StandardCardDataActivityLogMessageFromCpu standardEvent)
                    {
                        if (standardEvent.DateTime <= _minEventDateTime)
                        {
                            forceColdReset = true;
                            this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                            break;
                        }
                        ActivityLogMessageCardHelper cardHelper;
                        if (_cardHelpers.TryGetValue(pkt.FromHardwareAddress, out cardHelper) == false)
                        {
                            cardHelper = new ActivityLogMessageCardHelper(pkt, standardEvent);
                            _cardHelpers.TryAdd(pkt.FromHardwareAddress, cardHelper);
                        }
                        else
                            cardHelper.Initialize(pkt, standardEvent);

                        if (_cpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CardCodeFormat == CredentialDataSize.Standard48Bits)
                        {
                            activityLog = Packet6xxConverters.ConvertFrom(ref cardHelper, this.CpuModel, this.ClusterGroupId, TimeZoneId);
                        }
                    }
                    else if (activityLogMessage is ExtendedCardDataActivityLogMessageFromCpu extendedEvent)
                    {
                        ActivityLogMessageCardHelper cardHelper;
                        if (_cardHelpers.TryGetValue(pkt.FromHardwareAddress, out cardHelper) == true)
                        {
                            cardHelper.Update(extendedEvent);//(ExtendedCardDataActivityLogMessageFromCpu)activityLogMessage);
                            if (extendedEvent.LogType == (Byte)PanelActivityLogMessageCode.ExtendedCardCodeMiddleBytes)
                            {
                                activityLog = Packet6xxConverters.ConvertFrom(ref cardHelper, this.CpuModel, this.ClusterGroupId, TimeZoneId);
                            }
                        }
                    }
                    //else if (activityLogMessage is ActivityLogMessageFromCpu l)
                    else if (activityLogMessage is PanelActivityLogMessage l)
                    {
                        if (l.DateTime <= _minEventDateTime)
                        {
                            forceColdReset = true;
                            this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                            break;
                        }
                        activityLog = activityLogMessage;

                        switch ((PanelActivityLogMessageCode)l.PanelActivityType)
                        {
                            case PanelActivityLogMessageCode.BoardCommunicationStarted:
                            case PanelActivityLogMessageCode.BoardCommunicationStopped:
                                SendRequestBoardInformation(null);
                                break;
                        }

                        switch (l.PanelActivityType)
                        {
                            case PanelActivityEventCode.CrisisModeActivated:
                            case PanelActivityEventCode.CrisisModeActivatedByCommand:
                            case PanelActivityEventCode.CrisisModeDeActivated:
                            case PanelActivityEventCode.CrisisModeDeActivatedByCommand:
                                SendGetControllerInfo(null);
                                break;

                        }
                    }
                    else if (activityLogMessage is CardTourActivityLogMessageFromCpu cardTourActivity)
                    {
                        if (cardTourActivity.DateTime <= _minEventDateTime)
                        {
                            forceColdReset = true;
                            this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                            break;
                        }
                    }
                    else if (activityLogMessage is OtisElevatorActivityLogMessageFromCpu otisElevatorActivity)
                    {
                        if (otisElevatorActivity.DateTime <= _minEventDateTime)
                        {
                            forceColdReset = true;
                            this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                            break;
                        }
                    }
                    else
                        activityLog = activityLogMessage;
                    if (activityLog == null)
                    {
                        // this is a legitamate condition for extended card messages
                        break;
                    }

                    var messageType = activityLogMessage.GetType();
                    try
                    {
                        if (((PanelActivityLogMessage)activityLog)?.DateTime < _minEventDateTime)
                        {
                            this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Log().Error($"{nameof(this.ClusterGroupId)}:{this.ClusterGroupId}, {nameof(this.ClusterId)}:{this.ClusterId}, {nameof(this.PanelId)}:{this.PanelId}, {nameof(this.CpuId)}:{this.CpuId} - Activity log event has an invalid time. Panel may need to be cold-reset");
                        Trace.WriteLine(ex.ToString());
                    }

                    if (activityLog is PanelCredentialActivityLogMessage credentialActivity)
                    {
                        credentialActivity.DeviceEntityId = this.EntityId;
                        credentialActivity.DeviceEntityName = this.EntityName;
                        credentialActivity.EntityType = this.EntityType;

                        switch (credentialActivity.Category)
                        {
                            case PanelActivityEventCategory.Door:
                            case PanelActivityEventCategory.PersonDoor:
                                try
                                {
                                    credentialActivity.DeviceTypeCode = DeviceType.AccessPortal;
                                    GalaxySMS.Client.Entities.AccessPortalListItem ap = null;
                                    if (_accessPortalList.TryGetValue(credentialActivity.UniqueHardwareId, out ap))
                                    {
                                        if (ap != null)
                                        {
                                            //credentialActivity.DeviceEntityId = ap.EntityId;
                                            //credentialActivity.DeviceEntityName = this.EntityName;
                                            credentialActivity.DeviceUid = ap.UniqueUid;
                                            credentialActivity.DeviceDescription = ap.Name;
                                        }
                                    }
                                    Task.Run(async () =>
                                    {
                                        var cred = await Globals.Instance.GetCredentialActivityEventData(credentialActivity.CredentialBytes);
                                        if (cred != null)
                                        {
                                            credentialActivity.PersonUid = cred.PersonUid;
                                            credentialActivity.CredentialUid = cred.CredentialUid;
                                            credentialActivity.PersonDescription = cred.ActivityEventText;
                                            credentialActivity.FirstName = cred.FirstName;
                                            credentialActivity.LastName = cred.LastName;
                                            credentialActivity.CredentialDescription = cred.CredentialDescription;
                                            credentialActivity.Trace = cred.CredentialTraceEnabled | cred.PersonTrace;
                                            credentialActivity.PersonCredentialUid = cred.PersonCredentialUid;
                                            credentialActivity.PersonExpirationModeUid = cred.PersonExpirationModeUid;
                                            credentialActivity.UsageCount = cred.UsageCount;
                                            credentialActivity.IsActive = cred.IsActive;
                                        }
                                    }).Wait();

                                    if (ap != null)
                                    {
                                        var apAlertAckData = ap.GetAlertEventAcknowledgeData(credentialActivity.PanelActivityType);

                                        if (apAlertAckData != null && apAlertAckData.AcknowledgeTimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                                        {
                                            if (apAlertAckData.AcknowledgeTimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                                            {
                                                credentialActivity.IsAlarmEvent = apAlertAckData.IsActive;
                                                credentialActivity.AlarmPriority = apAlertAckData.AcknowledgePriority;
                                                credentialActivity.ResponseRequired = apAlertAckData.ResponseRequired;
                                                credentialActivity.Instructions = apAlertAckData.ResponseInstructions;
                                                credentialActivity.InstructionsNoteUid = apAlertAckData.ResponseInstructionsUid;
                                                credentialActivity.AudioBinaryResourceUid = apAlertAckData.AudioBinaryResourceUid;
                                            }
                                            else
                                            {   // See if the schedule is active

                                                Task.Run(async () =>
                                                {
                                                    credentialActivity.IsAlarmEvent = await Globals.Instance.IsTimeScheduleActive(apAlertAckData.AcknowledgeTimeScheduleUid, apAlertAckData.ScheduleTypeCode, this.CpuConnectionInfo.CpuDatabaseInformation.ClusterUid, credentialActivity.DateTime);
                                                    if (credentialActivity.IsAlarmEvent)
                                                    {
                                                        credentialActivity.IsAlarmEvent = apAlertAckData.IsActive;
                                                        credentialActivity.AlarmPriority = apAlertAckData.AcknowledgePriority;
                                                        credentialActivity.ResponseRequired = apAlertAckData.ResponseRequired;
                                                        credentialActivity.Instructions = apAlertAckData.ResponseInstructions;
                                                        credentialActivity.InstructionsNoteUid = apAlertAckData.ResponseInstructionsUid;
                                                        credentialActivity.AudioBinaryResourceUid = apAlertAckData.AudioBinaryResourceUid;
                                                    }
                                                }).Wait();

                                            }
                                        }
                                    }
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    credentialActivity.DeviceEntityId = Guid.Empty;
                                    credentialActivity.DeviceEntityName = this.EntityName;
                                    credentialActivity.EntityType = this.EntityType;
                                    credentialActivity.DeviceUid = Guid.Empty;
                                    credentialActivity.DeviceDescription = credentialActivity.UniqueHardwareId;
                                }
                                break;

                            case PanelActivityEventCategory.Panel:
                                credentialActivity.DeviceTypeCode = DeviceType.GalaxyPanel;
                                //credentialActivity.DeviceEntityId = this.EntityId;
                                //credentialActivity.DeviceEntityName = this.EntityName;
                                credentialActivity.DeviceUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                credentialActivity.DeviceDescription = $"{CpuConnectionInfo.CpuDatabaseInformation.PanelName} (CPU:{CpuConnectionInfo.CpuDatabaseInformation.CpuNumber})";
                                var gpAlertAckData = CpuConnectionInfo.CpuDatabaseInformation.GetAlertEventAcknowledgeData(credentialActivity.PanelActivityType);
                                break;

                            case PanelActivityEventCategory.Person:
                                credentialActivity.DeviceTypeCode = DeviceType.GalaxyPanel;
                                //credentialActivity.DeviceEntityId = this.EntityId;
                                //credentialActivity.DeviceEntityName = this.EntityName;
                                credentialActivity.DeviceUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                credentialActivity.DeviceDescription = $"{CpuConnectionInfo.CpuDatabaseInformation.PanelName} (CPU:{CpuConnectionInfo.CpuDatabaseInformation.CpuNumber})";

                                Task.Run(async () =>
                                {
                                    var cred = await Globals.Instance.GetCredentialActivityEventData(credentialActivity.CredentialBytes);
                                    if (cred != null)
                                    {
                                        credentialActivity.PersonUid = cred.PersonUid;
                                        credentialActivity.CredentialUid = cred.CredentialUid;
                                        credentialActivity.PersonDescription = cred.ActivityEventText;
                                        credentialActivity.FirstName = cred.FirstName;
                                        credentialActivity.LastName = cred.LastName;
                                        credentialActivity.CredentialDescription = cred.CredentialDescription;
                                        credentialActivity.Trace = cred.CredentialTraceEnabled | cred.PersonTrace;
                                        credentialActivity.PersonCredentialUid = cred.PersonCredentialUid;
                                        credentialActivity.PersonExpirationModeUid = cred.PersonExpirationModeUid;
                                        credentialActivity.UsageCount = cred.UsageCount;
                                        credentialActivity.IsActive = cred.IsActive;
                                    }
                                }).Wait();
                                break;

                            case PanelActivityEventCategory.Unknown:
                            case PanelActivityEventCategory.Input:
                            case PanelActivityEventCategory.Output:
                            case PanelActivityEventCategory.GalaxyElevator:
                            case PanelActivityEventCategory.OtisElevator:
                            case PanelActivityEventCategory.InputOutputGroup:
                            case PanelActivityEventCategory.CardTour:
                            case PanelActivityEventCategory.PersonInputOutputGroup:
                            case PanelActivityEventCategory.DoorGroup:
                            case PanelActivityEventCategory.DsiChannel:
                            default:
                                break;
                        }
                    }
                    else if (activityLog is PanelActivityLogMessage activity)
                    {
                        activity.DeviceEntityName = this.EntityName;
                        activity.DeviceEntityId = this.EntityId;
                        activity.EntityType = this.EntityType;

                        switch (activity.Category)
                        {
                            case PanelActivityEventCategory.Door:
                            case PanelActivityEventCategory.PersonDoor:
                                try
                                {
                                    activity.DeviceTypeCode = DeviceType.AccessPortal;
                                    AccessPortalListItem ap = null;
                                    if (_accessPortalList.TryGetValue(activity.UniqueHardwareId, out ap))
                                    {
                                        if (ap != null)
                                        {
                                            //activity.DeviceEntityId = ap.EntityId;
                                            //activity.DeviceEntityName = this.EntityName;
                                            activity.DeviceUid = ap.UniqueUid;
                                            activity.DeviceDescription = ap.Name;

                                            var alertAckData = ap.GetAlertEventAcknowledgeData(activity.PanelActivityType);

                                            if (alertAckData != null && alertAckData.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                                            {
                                                if (alertAckData.AcknowledgeTimeScheduleUid == TimeScheduleIds.TimeSchedule_Always)
                                                {
                                                    activity.IsAlarmEvent = alertAckData.IsActive; //true;
                                                    activity.AlarmPriority = alertAckData.AcknowledgePriority;
                                                    activity.ResponseRequired = alertAckData.ResponseRequired;
                                                    activity.Instructions = alertAckData.ResponseInstructions;
                                                    activity.InstructionsNoteUid = alertAckData.ResponseInstructionsUid;
                                                    activity.AudioBinaryResourceUid = alertAckData.AudioBinaryResourceUid;
                                                }
                                                else
                                                {   // See if the schedule is active

                                                    Task.Run(async () =>
                                                    {
                                                        activity.IsAlarmEvent = await Globals.Instance.IsTimeScheduleActive(alertAckData.AcknowledgeTimeScheduleUid, alertAckData.ScheduleTypeCode, this.CpuConnectionInfo.CpuDatabaseInformation.ClusterUid, activity.DateTime);
                                                        if (activity.IsAlarmEvent)
                                                        {
                                                            activity.AlarmPriority = alertAckData.AcknowledgePriority;
                                                            activity.ResponseRequired = alertAckData.ResponseRequired;
                                                            activity.Instructions = alertAckData.ResponseInstructions;
                                                            activity.InstructionsNoteUid = alertAckData.ResponseInstructionsUid;
                                                            activity.AudioBinaryResourceUid = alertAckData.AudioBinaryResourceUid;
                                                        }
                                                    }).Wait();

                                                }
                                            }
                                        }

                                    }
                                    if (ap == null)
                                    {
                                        this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name}: Access Portal '{activity.UniqueHardwareId}' not found in _accessPortalList for Connection: {this.ConnectionDescription}. ");
                                    }
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                break;

                            case PanelActivityEventCategory.Panel:
                            case PanelActivityEventCategory.PanelBoard:
                                activity.DeviceTypeCode = DeviceType.GalaxyPanel;
                                //activity.DeviceEntityId = this.EntityId;
                                //activity.DeviceEntityName = this.EntityName;

                                activity.DeviceUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                activity.DeviceDescription = $"{CpuConnectionInfo.CpuDatabaseInformation.PanelName} (CPU:{CpuConnectionInfo.CpuDatabaseInformation.CpuNumber})";
                                var gpAlertAckData = CpuConnectionInfo.CpuDatabaseInformation.GetAlertEventAcknowledgeData(activity.PanelActivityType);
                                if (gpAlertAckData != null && gpAlertAckData.AcknowledgeTimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                                {
                                    if (gpAlertAckData.AcknowledgeTimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                                    {
                                        activity.IsAlarmEvent = gpAlertAckData.IsActive;//true;
                                        activity.AlarmPriority = gpAlertAckData.AcknowledgePriority;
                                        activity.ResponseRequired = gpAlertAckData.ResponseRequired;
                                        activity.Instructions = gpAlertAckData.ResponseInstructions;
                                        activity.InstructionsNoteUid = gpAlertAckData.UserInstructionsNoteUid;
                                        activity.AudioBinaryResourceUid = gpAlertAckData.AudioBinaryResourceUid;
                                    }
                                    else
                                    {   // See if the schedule is active

                                        Task.Run(async () =>
                                        {
                                            activity.IsAlarmEvent = await Globals.Instance.IsTimeScheduleActive(gpAlertAckData.AcknowledgeTimeScheduleUid, gpAlertAckData.ScheduleTypeCode, this.CpuConnectionInfo.CpuDatabaseInformation.ClusterUid, activity.DateTime);
                                            if (activity.IsAlarmEvent)
                                            {
                                                activity.IsAlarmEvent = gpAlertAckData.IsActive;
                                                activity.AlarmPriority = gpAlertAckData.AcknowledgePriority;
                                                activity.ResponseRequired = gpAlertAckData.ResponseRequired;
                                                activity.Instructions = gpAlertAckData.ResponseInstructions;
                                                activity.InstructionsNoteUid = gpAlertAckData.UserInstructionsNoteUid;
                                                activity.AudioBinaryResourceUid = gpAlertAckData.AudioBinaryResourceUid;
                                            }
                                        }).Wait();

                                    }
                                }
                                if (activity.Category == PanelActivityEventCategory.PanelBoard)
                                {   // determine the GalaxyInterfaceBoardUid
                                    switch (activity.PanelActivityType)
                                    {
                                        case PanelActivityEventCode.BoardCommunicationStarted:
                                        case PanelActivityEventCode.BoardCommunicationStopped:
                                            GalaxySMS.Client.Entities.GalaxyInterfaceBoard ib = null;
                                            if (_interfaceBoards.TryGetValue(activity.UniqueHardwareId, out ib))
                                            {
                                                if (ib != null)
                                                {
                                                    activity.GalaxyInterfaceBoardUid = ib.GalaxyInterfaceBoardUid;
                                                    activity.BoardNumber = ib.BoardNumber;
                                                    activity.DeviceDescription = string.Format(GalaxySMS.Resources.Resources.GalaxyInterfaceBoard_DefaultName, ib.ClusterNumber, ib.PanelNumber, ib.BoardNumber);
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;

                            case PanelActivityEventCategory.InputOutputGroup:
                                try
                                {
                                    activity.DeviceTypeCode = DeviceType.InputOutputGroup;
                                    activity.DeviceUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                    activity.DeviceDescription = $"{CpuConnectionInfo.CpuDatabaseInformation.PanelName} (CPU:{CpuConnectionInfo.CpuDatabaseInformation.CpuNumber})";
                                    Task.Run(async () =>
                                    {
                                        //this.Log().Info($"GetInputOutputGroupData:ClusterGroupId:{ClusterGroupId}, ClusterId:{ClusterId}, PanelId:{PanelId}, CpuId:{CpuId}");
                                        var iog = await Globals.Instance.GetInputOutputGroupData(this.ClusterGroupId, this.ClusterId, activity.InputOutputGroupNumber);
                                        if (iog != null)
                                        {
                                            activity.InputOutputGroupUid = iog.InputOutputGroupUid;
                                            activity.InputOutputGroupName = iog.Display;
                                        }
                                    }).Wait();
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                catch (Exception ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                break;

                            case PanelActivityEventCategory.Input:
                                try
                                {
                                    activity.DeviceTypeCode = DeviceType.InputDevice;
                                    GalaxySMS.Client.Entities.InputDeviceListItem id = null;
                                    if (_inputDeviceList.TryGetValue(activity.UniqueHardwareId, out id))
                                    {
                                        if (id != null)
                                        {
                                            //activity.DeviceEntityId = id.EntityId;
                                            //activity.DeviceEntityName = this.EntityName;
                                            activity.DeviceUid = id.UniqueUid;
                                            activity.DeviceDescription = id.Name;

                                            var alertAckData = id.GetAlertEventAcknowledgeData(activity.PanelActivityType);

                                            if (alertAckData != null && alertAckData.AcknowledgeTimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                                            {
                                                if (alertAckData.AcknowledgeTimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                                                {
                                                    activity.IsAlarmEvent = alertAckData.IsActive;//true;
                                                    activity.AlarmPriority = alertAckData.AcknowledgePriority;
                                                    activity.ResponseRequired = alertAckData.ResponseRequired;
                                                    activity.Instructions = alertAckData.ResponseInstructions;
                                                    activity.InstructionsNoteUid = alertAckData.ResponseInstructionsUid;
                                                    activity.AudioBinaryResourceUid = alertAckData.AudioBinaryResourceUid;
                                                }
                                                else
                                                {   // See if the schedule is active

                                                    Task.Run(async () =>
                                                    {
                                                        activity.IsAlarmEvent = await Globals.Instance.IsTimeScheduleActive(alertAckData.AcknowledgeTimeScheduleUid, alertAckData.ScheduleTypeCode, this.CpuConnectionInfo.CpuDatabaseInformation.ClusterUid, activity.DateTime);
                                                        if (activity.IsAlarmEvent)
                                                        {
                                                            activity.IsAlarmEvent = alertAckData.IsActive;
                                                            activity.AlarmPriority = alertAckData.AcknowledgePriority;
                                                            activity.ResponseRequired = alertAckData.ResponseRequired;
                                                            activity.Instructions = alertAckData.ResponseInstructions;
                                                            activity.InstructionsNoteUid = alertAckData.ResponseInstructionsUid;
                                                            activity.AudioBinaryResourceUid = alertAckData.AudioBinaryResourceUid;
                                                        }
                                                    }).Wait();

                                                }
                                            }
                                        }
                                    }
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                catch (Exception ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                break;

                            case PanelActivityEventCategory.Output:
                                try
                                {
                                    activity.DeviceTypeCode = DeviceType.OutputDevice;
                                    GalaxySMS.Client.Entities.OutputDeviceListItem od = null;
                                    if (_outputDeviceList.TryGetValue(activity.UniqueHardwareId, out od))
                                    {
                                        if (od != null)
                                        {
                                            //activity.DeviceEntityId = od.EntityId;
                                            //activity.DeviceEntityName = this.EntityName;
                                            activity.DeviceUid = od.UniqueUid;
                                            activity.DeviceDescription = od.Name;
                                        }
                                    }
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                catch (Exception ex)
                                {
                                    activity.DeviceEntityId = Guid.Empty;
                                    activity.DeviceEntityName = string.Empty;
                                    activity.EntityType = string.Empty;
                                    activity.DeviceUid = Guid.Empty;
                                    activity.DeviceDescription = activity.UniqueHardwareId;
                                }
                                break;


                            case PanelActivityEventCategory.DsiChannel:
                                activity.DeviceTypeCode = DeviceType.GalaxyPanel;
                                switch (activity.PanelActivityType)
                                {
                                    case PanelActivityEventCode.DeviceOffline:
                                    case PanelActivityEventCode.DeviceOnline:
                                    case PanelActivityEventCode.DualSerialInterfaceRelayBoardOffline:
                                    case PanelActivityEventCode.DualSerialInterfaceRelayBoardOnline:
                                    case PanelActivityEventCode.DualSerialInterfaceDoorModuleOffline:
                                    case PanelActivityEventCode.DualSerialInterfaceDoorModuleOnline:
                                    case PanelActivityEventCode.DualSerialInterfaceInputModuleOffline:
                                    case PanelActivityEventCode.DualSerialInterfaceInputModuleOnline:
                                        activity.DeviceUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                        GalaxySMS.Client.Entities.GalaxyHardwareModule mod = null;
                                        if (_hardwareModules.TryGetValue(activity.UniqueHardwareId, out mod))
                                        {
                                            if (mod != null)
                                            {
                                                activity.GalaxyHardwareModuleUid = mod.GalaxyHardwareModuleUid;
                                                activity.ModuleNumber = mod.ModuleNumber;
                                                activity.DeviceDescription = string.Format(GalaxySMS.Resources.Resources.GalaxyDualSerialInterface_RemoteInputModule_ModuleDefaultName, mod.ClusterNumber, mod.PanelNumber, mod.BoardNumber, mod.SectionNumber, mod.ModuleNumber);

                                            }
                                        }
                                        if (string.IsNullOrEmpty(activity.DeviceDescription))
                                            activity.DeviceDescription = activity.UniqueHardwareId;
                                        break;
                                }

                                break;

                            case PanelActivityEventCategory.Unknown:
                            case PanelActivityEventCategory.GalaxyElevator:
                            case PanelActivityEventCategory.OtisElevator:
                            case PanelActivityEventCategory.CardTour:
                            case PanelActivityEventCategory.Person:
                            case PanelActivityEventCategory.PersonInputOutputGroup:
                            case PanelActivityEventCategory.DoorGroup:
                            default:
                                break;
                        }
                    }
                    Task.Run(async () =>
                    {
                        var eventType = await Globals.Instance.GetGalaxyActivityEventType(((PanelActivityLogMessageBase)activityLog).PanelActivityType);
                        if (eventType != null)
                        {
                            ((PanelActivityLogMessageBase)activityLog).EventDescription = eventType.Display;
                            ((PanelActivityLogMessageBase)activityLog).Color = eventType.ForeColor;
                            ((PanelActivityLogMessageBase)activityLog).ForeColorHex = eventType.ForeColorHex;
                            //((PanelActivityLogMessageBase)activityLog).ColorArgb = $"#{eventType.ForeColor.ToString("X8")}";
                        }
                    }).Wait();

                    SendToProcessingQueue(activityLog, null);
                    var bufferIndex = ((PanelActivityLogMessageBase)activityLog).BufferIndex;
                    if (bufferIndex < _lastLogMessageBufferIndex)
                    {
                        Task.Run(async () =>
                        {
                            await SendAcknowledgeToLogMessageIndexAsync(_lastLogMessageBufferIndex);
                        }).Wait();
                    }
                    _lastLogMessageBufferIndex = bufferIndex;
                    break;

                case PacketDataCodeFrom6xx.NotificationCardAreaChange:
                    var areaChangeEvent = new CardChangeAreaEvent()
                    {
                        Area = (UInt16)pkt.Data[1],
                        ForgiveCode = pkt.Data[2],
                        CardData = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(pkt.Data, 32, 3)
                    };
                    SendToProcessingQueue(areaChangeEvent, null);
                    break;

                case PacketDataCodeFrom6xx.NotificationEventIOLevel:
                    var inputChangeEvent = new InputChangeEvent()
                    {
                        InputOutputGroupNumber = pkt.Data[2],
                        Offset = pkt.Data[1],
                        NewState = pkt.Data[3],
                    };
                    SendToProcessingQueue(inputChangeEvent, null);
                    break;

                case PacketDataCodeFrom6xx.ResponseResetCpu:
                    var resetReply = new CpuResetReply()
                    {
                    };
                    SendToProcessingQueue(resetReply, null);
                    break;

                case PacketDataCodeFrom6xx.ResponseReaderPortStatus:
                    var accessPortalStatusReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as AccessPortalStatusReply;
                    if (accessPortalStatusReply != null)
                    {
                        AccessPortalListItem ap = null;
                        if (_accessPortalList.TryGetValue(accessPortalStatusReply.UniqueIdAsAccessPortal, out ap))
                        {
                            if (ap != null)
                            {
                                accessPortalStatusReply.AccessPortalUid = ap.UniqueUid;
                            }
                        }

                        SendToProcessingQueue(accessPortalStatusReply, null);//GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }
                    break;

                case PacketDataCodeFrom6xx.ResponseInputDeviceStatus:
                    var inputDeviceStatusReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as InputDeviceStatusReply;
                    if (inputDeviceStatusReply != null)
                    {
                        GalaxySMS.Client.Entities.InputDeviceListItem id = null;
                        if (_inputDeviceList.TryGetValue(inputDeviceStatusReply.UniqueIdAsInputDevice, out id))
                        {
                            if (id != null)
                            {
                                inputDeviceStatusReply.InputDeviceUid = id.UniqueUid;
                            }
                        }
                        SendToProcessingQueue(inputDeviceStatusReply, null);//GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }
                    break;

                case PacketDataCodeFrom6xx.ResponseInputVoltages:
                    var inputDeviceVoltagesReply = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId) as InputDeviceVoltagesReply;
                    if (inputDeviceVoltagesReply != null)
                    {
                        GalaxySMS.Client.Entities.InputDeviceListItem id = null;
                        if (_inputDeviceList.TryGetValue(inputDeviceVoltagesReply.UniqueIdAsInputDevice, out id))
                        {
                            if (id != null)
                            {
                                inputDeviceVoltagesReply.InputDeviceUid = id.UniqueUid;
                            }
                        }
                        SendToProcessingQueue(inputDeviceVoltagesReply, null);//GetSessionIdsForResponseCode((UInt16)pkt.Data[0]));
                    }
                    break;

                default:
                    //this.Log().DebugFormat("{0}, {1} - Received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCodeTo6xx)pkt.Data[0]).ToString());
                    if (_signOnState != SignOnState.Authenticated)
                    {	// if the connection is not authenticated, drop the connection
                        if (pkt.Data[0] != (byte)PacketDataCodeFrom6xx.NotificationEventIOLevel)
                        {
                            PrepareToClose(false);
                        }
                        return false;
                    }
                    else
                    {
                        var o = Packet6xxConverters.ConvertFrom(pkt, this.CpuModel, this.ClusterGroupId, PanelInterfaceBoardSectionType.Unused, Guid.Empty, Guid.Empty, ClusterUid, GalaxyPanelUid, CpuUid, TimeZoneId);
                        // Temporarily Commented out
                        SendToProcessingQueue(o, null);
                    }
                    break;
            }

            //if (forceColdReset == true)
            //{
            //    SendResetCommand(ResetCpuCommand.ResetTypeValue.ForceColdReset);
            //    PrepareToClose();
            //    return false;
            //}

            //		COleDateTime dt;
            //		BOOL bNotifyCommServiceOfNewConnection = FALSE;
            switch (pkt.Distribute)
            {
                case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToAllPanels:
                case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToSpecificPanel:
                    // This packet must be distributed to other panels. 
                    var handler = PanelToPanelPacketReceivedEvent;
                    if (handler != null)
                    {
                        //this.Log().DebugFormat("PanelToPanelPacketReceivedEvent raised from Thread 0x{0:X}, {1} - packet for distribution to other panels",
                        //    System.Threading.Thread.CurrentThread.ManagedThreadId, ConnectionDescription);
                        handler(this, new PanelDataPacketEventArgs(ref pkt, this.ClusterGroupId));
                    }
                    break;

                case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToServer:
                    break;

            }
            return true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets session identifiers for response code. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="packetDataCodeFrom6xx">    The packet data code from 6xx. </param>
        ///
        /// <returns>   The session identifiers for response code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private List<Guid> GetSessionIdsForResponseCode(UInt16 packetDataCodeFrom6xx)
        {
            if (_sessionIdsForResponseCodes.ContainsKey(packetDataCodeFrom6xx))
            {
                var l = _sessionIdsForResponseCodes[packetDataCodeFrom6xx];
                _sessionIdsForResponseCodes.Remove(packetDataCodeFrom6xx);
                return l;
            }
            return null;
        }

        private List<Guid> GetSessionIdsForAckNackResponseCode(UInt16 packetDataCodeFrom6xx)
        {
            if (_sessionIdsForAckNackResponseCodes.ContainsKey(packetDataCodeFrom6xx))
            {
                var l = _sessionIdsForAckNackResponseCodes[packetDataCodeFrom6xx];
                _sessionIdsForAckNackResponseCodes.Remove(packetDataCodeFrom6xx);
                return l;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a set logging pointers asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="enableLogging">    True to enable, false to disable the logging. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task SendSetLoggingPointersAsync(bool enableLogging)
        {
            try
            {
                if (CpuUid.HasValueAndNotEmpty())
                {
                    if (CpuConnectionInfo.CpuDatabaseInformation.LastLogIndex >= 0)
                    {
                        IDataPacket6xx p = GetNewPacketToSend();
                        var c = new SetLoggingIndex
                        {
                            Cmd = (byte)PacketDataCodeTo6xx.CommandLoggingAcknowledgeToMessageIndex,
                            Index = (ushort)CpuConnectionInfo.CpuDatabaseInformation.LastLogIndex
                        };

                        p.FillData(c);//, Marshal.SizeOf(c));
                        p.PrepareForTransmission(false, true, TimeZoneId);
                        //                            this.Log().DebugFormat("SendSetLoggingPointers. Setting index = {0}", CpuConnectionInfo.CpuDatabaseInformation.LastLogIndex);
                        Send(ref p);
                        _lastSentAckToLogMessageIndex = DateTimeOffset.Now;

                        if (enableLogging)
                        {
                            SetLoggingState(ActivityLoggingState.On, null);
                            SendGetLoggingInfo(null);
                        }
                    }
                    //else
                    //    this.Log().DebugFormat("SendSetLoggingPointers. Setting index = {0}", CpuConnectionInfo.CpuDatabaseInformation.LastLogIndex);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        private async Task<bool> SendAcknowledgeToLogMessageIndexAsync(uint indexNumber)
        {
            try
            {
                IDataPacket6xx p = GetNewPacketToSend();
                var c = new SetLoggingIndex
                {
                    Cmd = (byte)PacketDataCodeTo6xx.CommandLoggingAcknowledgeToMessageIndex,
                    Index = (ushort)indexNumber
                };

                p.FillData(c);//, Marshal.SizeOf(c));
                p.PrepareForTransmission(false, true, TimeZoneId);
                Send(ref p);

                _lastLogMessageBufferIndexAcked = indexNumber;
                _lastSentAckToLogMessageIndex = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                return false;
            }
            return true;
        }


        private async Task GetGalaxyCpuDatabaseInformationAsync()
        {
            try
            {
                var mgr = Globals.Instance.GetManager<PanelDataProcessingManager>();//new PanelDataProcessingManager(Globals.Instance.ServerConnection);

                _cpuDbInfo = await mgr.GetGalaxyCpuDatabaseInformationAsync(new GalaxySMS.Client.Entities.CpuHardwareAddress
                {
                    ClusterGroupId = this.ClusterGroupId,
                    ClusterNumber = this.ClusterId,
                    PanelNumber = this.PanelId,
                    CpuId = (Int32)this.CpuId
                });
                if (_cpuDbInfo != null)
                {
                    //                    var temp = AutoMapper.Mapper.Map<GalaxyCpuDatabaseInformation>(_cpuDbInfo);
                    var temp = Globals.Instance.Mapper.Map<GalaxyCpuDatabaseInformation>(_cpuDbInfo);

                    this.CpuConnectionInfo.CpuDatabaseInformation = temp;
                    this.CpuConnectionInfo.GalaxyCpuInformation.ClusterUid = temp.ClusterUid;
                    this.CpuConnectionInfo.GalaxyCpuInformation.PanelUid = temp.GalaxyPanelUid;
                    this.CpuConnectionInfo.GalaxyCpuInformation.CpuUid = temp.CpuUid;
                    RaiseConnectionStateChangedEvent();
                    this.Log().InfoFormat($"GetGalaxyCpuDatabaseInformationAsync CPU found in database. ClusterGroupId:{this.ClusterGroupId}, Cluster:{this.ClusterId}, Panel:{this.PanelId}, CPU:{this.CpuId}");
                }
                else
                {   // The cpu is not in the database
                    var clusterPanelDbInfo = await mgr.GetGalaxyClusterPanelInformationAsync(new GalaxySMS.Client.Entities.CpuHardwareAddress
                    {
                        ClusterGroupId = this.ClusterGroupId,
                        ClusterNumber = this.ClusterId,
                        PanelNumber = this.PanelId,
                        CpuId = (Int32)this.CpuId
                    });
                    if (clusterPanelDbInfo != null)
                    {
                        //var temp = new GalaxyCpuDatabaseInformation();

                        //SimpleMapper.PropertyMap(clusterPanelDbInfo, temp);
                        //var temp = AutoMapper.Mapper.Map<GalaxyCpuDatabaseInformation>(clusterPanelDbInfo);
                        var temp = Globals.Instance.Mapper.Map<GalaxyCpuDatabaseInformation>(clusterPanelDbInfo);

                        if (temp.PanelNumber != this.PanelId)
                        {
                            temp.GalaxyPanelUid = Guid.Empty;
                            temp.PanelNumber = 0;
                            temp.PanelName = string.Empty;
                            temp.PanelLocation = string.Empty;
                            // Must do the cpu as well, since this is obviously a different panel
                            temp.CpuUid = Guid.Empty;
                            temp.CpuNumber = 0;
                            temp.CpuIsActive = false;
                        }

                        if (temp.ClusterNumber != this.ClusterId)
                        {
                            temp.ClusterUid = Guid.Empty;
                            temp.ClusterNumber = 0;
                            temp.ClusterName = string.Empty;
                            // Must do the panel as well, since this is obviously a different cluster
                            temp.GalaxyPanelUid = Guid.Empty;
                            temp.PanelNumber = 0;
                            temp.PanelName = string.Empty;
                            // Must do the cpu as well, since this is obviously a different panel
                            temp.CpuUid = Guid.Empty;
                            temp.CpuNumber = 0;
                            temp.CpuIsActive = false;
                        }

                        if (temp.CpuNumber != this.CpuId)
                        {
                            temp.CpuUid = Guid.Empty;
                            temp.CpuNumber = 0;
                            temp.CpuIsActive = false;
                        }

                        this.CpuConnectionInfo.CpuDatabaseInformation = temp;
                        this.CpuConnectionInfo.GalaxyCpuInformation.ClusterUid = temp.ClusterUid;
                        this.CpuConnectionInfo.GalaxyCpuInformation.PanelUid = temp.GalaxyPanelUid;
                        this.CpuConnectionInfo.GalaxyCpuInformation.CpuUid = temp.CpuUid;
                        RaiseConnectionStateChangedEvent();
                        if (this.CpuConnectionInfo.GalaxyCpuInformation.CpuUid != Guid.Empty)
                            this.Log().InfoFormat($"GetGalaxyCpuDatabaseInformationAsync CPU found in database. ClusterGroupId:{this.ClusterGroupId}, Cluster:{this.ClusterId}, Panel:{this.PanelId}, CPU:{this.CpuId}");
                        else
                            this.Log().InfoFormat($"GetGalaxyCpuDatabaseInformationAsync cluster for CPU not found in database. ClusterGroupId:{this.ClusterGroupId}, Cluster:{this.ClusterId}, Panel:{this.PanelId}, CPU:{this.CpuId}");
                    }
                    else
                    {
                        this.Log().InfoFormat($"GetGalaxyCpuDatabaseInformationAsync cluster for CPU not found in database. ClusterGroupId:{this.ClusterGroupId}, Cluster:{this.ClusterId}, Panel:{this.PanelId}, CPU:{this.CpuId}");
                    }
                    //this.Log().InfoFormat($"GetGalaxyCpuDatabaseInformationAsync CPU not found in database. ClusterGroupId:{this.ClusterGroupId}, Cluster:{this.ClusterId}, Panel:{this.PanelId}, CPU:{this.CpuId}");
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        //public async Task SetCpuDatabaseInformation(GalaxyCpuDatabaseInformation data)
        //{
        //    await GetGalaxyCpuDatabaseInformationAsync();
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Builds hardware device data list. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task BuildHardwareDeviceDataList()
        {
            try
            {
                _bHardwareTreeBuiltSuccessfully = false;
                var apMgr = Globals.Instance.GetManager<AccessPortalManager>();//(_siteServerConnection);
                var idMgr = Globals.Instance.GetManager<InputDeviceManager>();//(_siteServerConnection);
                var odMgr = Globals.Instance.GetManager<OutputDeviceManager>();//(_siteServerConnection);
                var iogMgr = Globals.Instance.GetManager<GalaxyInputOutputGroupManager>();//(_siteServerConnection);
                var galaxyInterfaceBoardMgr = Globals.Instance.GetManager<GalaxyInterfaceBoardManager>();
                var galaxyInterfaceBoardSectionMgr = Globals.Instance.GetManager<GalaxyInterfaceBoardSectionManager>();
                var galaxyHardwareModuleMgr = Globals.Instance.GetManager<GalaxyHardwareModuleManager>();
                var galaxyInterfaceBoardSectionNodeMgr = Globals.Instance.GetManager<GalaxyInterfaceBoardSectionNodeManager>();

                var parameters = new GalaxySMS.Client.Entities.GetParameters()
                {
                    UniqueId = CpuConnectionInfo.GalaxyCpuInformation.PanelUid,
                    ClusterGroupId = this.ClusterGroupId,
                    ClusterNumber = this.ClusterId,
                    PanelNumber = this.PanelId,
                    IncludeMemberCollections = true,
                    DoNotValidateAuthorization = true
                };
                parameters.AddOption(GetInputDeviceOption.IsNodeActiveValue.ToString(), true);

                var paramsWithPhoto = new GalaxySMS.Client.Entities.GetParametersWithPhoto()
                {
                    UniqueId = CpuConnectionInfo.GalaxyCpuInformation.PanelUid,
                    ClusterGroupId = this.ClusterGroupId,
                    ClusterNumber = this.ClusterId,
                    PanelNumber = this.PanelId,
                    IncludeMemberCollections = true,
                    DoNotValidateAuthorization = true
                };


                var apList = await apMgr.GetAccessPortalListForGalaxyPanelAsync(parameters);
                var idList = await idMgr.GetInputDeviceListForGalaxyPanelAsync(parameters);
                var odList = await odMgr.GetOutputDeviceListForGalaxyPanelAsync(parameters);
                var boardList = await galaxyInterfaceBoardMgr.GetGalaxyInterfaceBoardsForPanelAddressAsync(paramsWithPhoto);
                var sectionList = await galaxyInterfaceBoardSectionMgr.GetGalaxyInterfaceBoardSectionsForPanelAddressAsync(paramsWithPhoto);
                var modulesList = await galaxyHardwareModuleMgr.GetGalaxyHardwareModulesForPanelAddressAsync(paramsWithPhoto);
                var nodesList = await galaxyInterfaceBoardSectionNodeMgr.GetGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(paramsWithPhoto);

                // Don't need this because the Globals.Instance contains the list of io groups. This is so that there is a single copy of the IO Groups instead of multiple copies in each connection
                //var iogList = await iogMgr.GetInputOutputGroupsForClusterAddressAsync(new GalaxySMS.Client.Entities.GetParametersWithPhoto()
                //{
                //    ClusterGroupId = this.ClusterGroupId,
                //    ClusterNumber = this.ClusterId,
                //    IncludeMemberCollections = false
                //});
                if (apList != null && apList.Items.Any())
                    _accessPortalList = apList.Items.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _accessPortalList = new Dictionary<string, GalaxySMS.Client.Entities.AccessPortalListItem>();

                if (idList != null && idList.Items.Any())
                    _inputDeviceList = idList.Items.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _inputDeviceList = new Dictionary<string, GalaxySMS.Client.Entities.InputDeviceListItem>();

                if (odList != null && odList.Items.Any())
                    _outputDeviceList = odList.Items.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _outputDeviceList = new Dictionary<string, GalaxySMS.Client.Entities.OutputDeviceListItem>();

                if (boardList != null && boardList.Any())
                    _interfaceBoards = boardList.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _interfaceBoards = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoard>();

                if (sectionList != null && sectionList.Any())
                    _interfaceBoardSections = sectionList.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _interfaceBoardSections = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSection>();

                if (modulesList != null && modulesList.Any())
                    _hardwareModules = modulesList.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _hardwareModules = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyHardwareModule>();

                if (nodesList != null && nodesList.Any())
                    _interfaceBoardSectionNodes = nodesList.ToDictionary(v => v.UniqueHardwareId, v => v);
                else
                    _interfaceBoardSectionNodes = new Dictionary<string, GalaxySMS.Client.Entities.GalaxyInterfaceBoardSectionNode>();
                _bHardwareTreeBuiltSuccessfully = true;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }

        }

        private async Task UpdateCpuConnectionStatus(GalaxyCpuConnection cpuConnection)
        {
            try
            {
                var mgr = Globals.Instance.GetManager<PanelDataProcessingManager>();

                var bRet = await mgr.UpdateGalaxyCpuConnectionAsync(cpuConnection);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        private async Task RefreshAccessPortalHardwareDeviceData(Guid accessPortalUid)
        {
            try
            {
                var apMgr = Globals.Instance.GetManager<AccessPortalManager>();//(_siteServerConnection);

                var parameters = new GalaxySMS.Client.Entities.GetParameters()
                {
                    UniqueId = accessPortalUid,
                    IncludeMemberCollections = true,
                    DoNotValidateAuthorization = true
                };

                var ap = await apMgr.GetAccessPortalListItemAsync(parameters);
                if (ap != null)
                    _accessPortalList[ap.UniqueHardwareId] = ap;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        private async Task RefreshInputDeviceHardwareDeviceData(Guid inputDeviceUid)
        {
            try
            {
                var mgr = Globals.Instance.GetManager<InputDeviceManager>();//(_siteServerConnection);

                var parameters = new GalaxySMS.Client.Entities.GetParameters()
                {
                    UniqueId = inputDeviceUid,
                    IncludeMemberCollections = true,
                    DoNotValidateAuthorization = true
                };

                var o = await mgr.GetInputDeviceListItemAsync(parameters);
                if (o != null)
                    _inputDeviceList[o.UniqueHardwareId] = o;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }

        }

        private async Task RefreshOutputDeviceHardwareDeviceData(Guid outputDeviceUid)
        {
            try
            {
                var mgr = Globals.Instance.GetManager<OutputDeviceManager>();//(_siteServerConnection);

                var parameters = new GalaxySMS.Client.Entities.GetParameters()
                {
                    UniqueId = outputDeviceUid,
                    IncludeMemberCollections = true,
                    DoNotValidateAuthorization = true
                };

                var o = await mgr.GetOutputDeviceListItemAsync(parameters);
                if (o != null)
                    _outputDeviceList[o.UniqueHardwareId] = o;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }


        private void SendFlashProgressMessageToProcessingQueue(PacketDataCodeTo6xx cmdCode, AckNack ackNack)
        {
            var sendProgressMessage = true;
            switch (cmdCode)
            {
                case PacketDataCodeTo6xx.CommandLoadFlashPacket600:
                case PacketDataCodeTo6xx.CommandLoadFlashPacket635:
                    if (this._flashLoadingData != null)
                    {   // only send every xth message to reduce traffic 
                        //if (_flashLoadingData.PacketCounter > _flashLoadingData.PacketsPerLoadMessage &&
                        //    (_flashLoadingData.PacketCounter % (_flashLoadingData.PacketsPerLoadMessage * 4) != 0) &&
                        //    _flashLoadingData.PacketCounter < _flashLoadingData.TotalPacketCount)
                        var ts = DateTimeOffset.Now - _lastSentFlashStatus;
                        if (ts.TotalMilliseconds < 500 &&
                            _flashLoadingData.PacketCounter > _flashLoadingData.PacketsPerLoadMessage &&
                            _flashLoadingData.PacketCounter < _flashLoadingData.TotalPacketCount)
                            sendProgressMessage = false;
                    }
                    else
                        sendProgressMessage = false;
                    break;

                case PacketDataCodeTo6xx.CommandBeginFlashLoad635:
                case PacketDataCodeTo6xx.CommandBeginFlashLoad600:
                case PacketDataCodeTo6xx.CommandValidateFlash635:
                case PacketDataCodeTo6xx.CommandValidateFlash600:
                case PacketDataCodeTo6xx.CommandValidateThenBurnFlash635:
                case PacketDataCodeTo6xx.CommandValidateThenBurnFlash600:
                    break;

                default:
                    sendProgressMessage = false;
                    break;
            }

            if (sendProgressMessage == true)
            {
                var msg = new FlashProgressMessage()
                {
                    ClusterGroupId = this.ClusterGroupId,
                    ClusterNumber = this.ClusterId,
                    PanelNumber = this.PanelId,
                    CpuId = this.CpuId,
                    CpuModel = this.CpuModel,
                    DateTimeOffset = DateTimeOffset.Now,
                    ValidationResult = FlashValidationResult.Unknown
                };
                switch (cmdCode)
                {
                    case PacketDataCodeTo6xx.CommandBeginFlashLoad635:
                    case PacketDataCodeTo6xx.CommandBeginFlashLoad600:
                        msg.CurrentState = FlashingState.BeginFlashLoadSent;    // this is a very short lived state and can cause a visual blip on the client side, so instead of using this state, go directly to the LoadingPackets state
                        msg.CurrentState = FlashingState.LoadingPackets;
                        break;

                    case PacketDataCodeTo6xx.CommandLoadFlashPacket600:
                    case PacketDataCodeTo6xx.CommandLoadFlashPacket635:
                        msg.CurrentState = FlashingState.LoadingPackets;
                        if (_flashLoadingData != null)
                        {
                            if (_flashLoadingData.Paused)
                                msg.CurrentState = FlashingState.LoadingPaused;
                            else if (_flashLoadingData.PacketCounter == _flashLoadingData.TotalPacketCount)
                                msg.CurrentState = FlashingState.LoadingPacketsFinished;
                        }
                        break;

                    case PacketDataCodeTo6xx.CommandValidateFlash635:
                    case PacketDataCodeTo6xx.CommandValidateFlash600:
                    case PacketDataCodeTo6xx.CommandValidateThenBurnFlash635:
                    case PacketDataCodeTo6xx.CommandValidateThenBurnFlash600:
                        msg.CurrentState = FlashingState.ValidationFinished;
                        switch (ackNack)
                        {
                            case AckNack.Nack:
                                msg.ValidationResult = FlashValidationResult.Failed;
                                break;

                            case AckNack.Ack:
                                msg.ValidationResult = FlashValidationResult.Passed;
                                break;

                            default:
                                msg.ValidationResult = FlashValidationResult.Unknown;
                                break;
                        }
                        break;
                }


                if (this.CpuConnectionInfo.CpuDatabaseInformation != null)
                    msg.CpuUid = this.CpuConnectionInfo.CpuDatabaseInformation.CpuUid;

                if (this._flashLoadingData != null)
                {
                    msg.PacketNumber = _flashLoadingData.PacketCounter;
                    msg.TotalPacketCount = _flashLoadingData.TotalPacketCount;
                    msg.StartedDateTime = _flashLoadingData.StartedDateTime;
                }
                SendToProcessingQueue(msg, null);
                _lastSentFlashStatus = DateTimeOffset.Now;
            }
        }

        private void SendFlashProgressMessageToProcessingQueue(FlashingState currentState)
        {
            var msg = new FlashProgressMessage()
            {
                ClusterGroupId = this.ClusterGroupId,
                ClusterNumber = this.ClusterId,
                PanelNumber = this.PanelId,
                CpuId = this.CpuId,
                CpuModel = this.CpuModel,
                DateTimeOffset = DateTimeOffset.Now,
                CurrentState = currentState,
                ValidationResult = FlashValidationResult.Unknown,
            };

            if (this.CpuConnectionInfo.CpuDatabaseInformation != null)
                msg.CpuUid = this.CpuConnectionInfo.CpuDatabaseInformation.CpuUid;

            if (this._flashLoadingData != null)
            {
                msg.PacketNumber = _flashLoadingData.PacketCounter;
                msg.TotalPacketCount = _flashLoadingData.TotalPacketCount;
                msg.StartedDateTime = _flashLoadingData.StartedDateTime;
            }
            SendToProcessingQueue(msg, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends to processing queue. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">            The object to process. </param>
        /// <param name="sessionIds">   List of identifiers for the sessions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendToProcessingQueue(object o, List<Guid> sessionIds)
        {
            if (o != null)
            {
                Task task1 = new Task(delegate
                 {
                     try
                     {
                         if (o is PanelMessageBase @base)
                         {
                             @base.ClusterGroupId = this.ClusterGroupId;
                             @base.ClusterNumber = this.ClusterId;
                             @base.PanelNumber = this.PanelId;
                             @base.CpuId = this.CpuId;
                             if (CpuConnectionInfo?.CpuDatabaseInformation != null)
                             {
                                 @base.ClusterUid = CpuConnectionInfo.CpuDatabaseInformation.ClusterUid;
                                 @base.PanelUid = CpuConnectionInfo.CpuDatabaseInformation.GalaxyPanelUid;
                                 @base.CpuUid = CpuConnectionInfo.CpuDatabaseInformation.CpuUid;
                             }
                             if (sessionIds != null && sessionIds.Any())
                                 @base.SessionIdsToSendTo = sessionIds;
                             @base.IpAddress = this.CpuConnectionInfo.RemoteIpEndpoint;
                             //if (@base.OperationUid != Guid.Empty)
                             //{
                             //    SetOperationTimeout(@base.OperationUid, _operationTimeoutSecondsDefaultValue);
                             //}
                         }
                         else if (o is PanelActivityLogMessageBase @activity)
                         {
                             @activity.ClusterGroupId = this.ClusterGroupId;
                             @activity.ClusterNumber = this.ClusterId;
                             @activity.PanelNumber = this.PanelId;
                             @activity.CpuId = this.CpuId;
                             if (CpuConnectionInfo?.CpuDatabaseInformation != null)
                             {
                                 @activity.ClusterUid = CpuConnectionInfo.CpuDatabaseInformation.ClusterUid;
                                 @activity.CpuUid = CpuConnectionInfo.CpuDatabaseInformation.CpuUid;
                                 @activity.ClusterName = CpuConnectionInfo.CpuDatabaseInformation.ClusterName;
                             }
                         }
                         _processingQueue.TryAdd(o);
                         //this.Log().DebugFormat("SendToProcessingQueue. Queue Count: {0}", processingQueue.Count);
                     }
                     catch (Exception ex)
                     {
                         this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                     }
                 });
                task1.Start();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends to recording queue. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendToRecordingQueue(object o)
        {
            if (o != null)
            {
                Task task1 = new Task(delegate
                 {
                     try
                     {
                         _recordingQueue.TryAdd(o);
                         //this.Log().DebugFormat("SendToProcessingQueue. Queue Count: {0}", processingQueue.Count);
                     }
                     catch (Exception ex)
                     {
                         this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                     }
                 });
                task1.Start();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the timer. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TimerCallback(object state)
        {
            if (IsAuthenticated == false)
            {
                //               GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - TimerCallback called before Authenticated", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
                this.Log().DebugFormat("{0}, {1}, {2} - TimerCallback called before Authenticated", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                return;
            }

            //			GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - TimerCallback called", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));

            if (System.Environment.TickCount < this._lastSendTickCount ||
                (System.Environment.TickCount - this._lastSendTickCount) > 14000)
                SendHeartbeat();

            if (_lastLogMessageBufferIndexAcked < _lastLogMessageBufferIndex &&
               _lastSentAckToLogMessageIndex.AddSeconds(_ackLogMessageIndexMinimumInterval) < DateTimeOffset.Now)
            {
                SendAcknowledgeToLogMessageIndexAsync(_lastLogMessageBufferIndex);
            }

            //if (System.Environment.TickCount < this.lastHeartbeatReceivedTickCount)
            //	this.lastHeartbeatReceivedTickCount = System.Environment.TickCount;

            int ticksSinceLastHeartbeatReceived = (System.Environment.TickCount - this._lastHeartbeatReceivedTickCount);
            if (ticksSinceLastHeartbeatReceived > 17000)
            {
                //              GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2}, lastHeartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, ticksSinceLastHeartbeatReceived));
                this.Log().InfoFormat($"{ConnectionDescription}, {InstanceGuid}, lastHeartbeat received {(System.Environment.TickCount - this._lastHeartbeatReceivedTickCount)} ms ago");
                if (ticksSinceLastHeartbeatReceived > 20000)
                {
                    //                GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - closing connection, last heartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, ticksSinceLastHeartbeatReceived));
                    this.Log().InfoFormat("{0}, {1} - closing connection, last heartbeat received {2} ms ago", ConnectionDescription, InstanceGuid, (System.Environment.TickCount - this._lastHeartbeatReceivedTickCount));
                    PrepareToClose(false);
                }
            }
            ////check the message tracking dictionary for timed out messages
            //else
            //{
            //    if (_operationTrackingExpirationDictionary.Any())
            //    {
            //        var dt = DateTimeOffset.Now;
            //        foreach (var expiredSession in _operationTrackingExpirationDictionary.Where(o => o.Value < DateTimeOffset.UtcNow).ToList())
            //        {
            //            //this.Log().Info($"OperationUid: {expiredSession.Key} expired.");
            //            var removed = _operationTrackingExpirationDictionary.TryRemove(expiredSession.Key, out dt);

            //            var sessionUids = new HashSet<Guid>();
            //            sessionUids.Add(expiredSession.Key);
            //            SendToProcessingQueue(new SignalREnvelope<OperationStatusInfo>()
            //            {
            //                Payload = new OperationStatusInfo()
            //                {
            //                    OperationUid = expiredSession.Key,
            //                    Successful = true,
            //                    Timeout = true,
            //                    PanelUid = GalaxyPanelUid.Value,
            //                    CpuUid = CpuUid.Value
            //                },
            //                SignalRGroupUids = sessionUids
            //            }, null);
            //        }
            //    }
            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Kill timer. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void KillTimer()
        {
            if (_timer != null)
            {
                //ManualResetEvent disposed = new ManualResetEvent(false);
                _timer.Dispose();// (disposed);
                                 //disposed.WaitOne();
                _timer = null;
            }
        }

        private void FlashLoadTimerCallback(object state)
        {
            if (_flashLoadingData != null && _flashLoadtimer != null && _flashLoadingData.Paused == false)
                SendNextFlashPacket();
        }

        private void StartFlashLoadTimer()
        {
            KillFlashLoadTimer();
            if (_flashLoadingData != null && _flashLoadingData.SendPacketIntervalMilliseconds >= GalaxyFlashLoadLimits.MinimumFlashPacketInterval && _flashLoadingData.SendPacketIntervalMilliseconds <= GalaxyFlashLoadLimits.MaximumFlashPacketInterval)
                _flashLoadtimer = new Timer(FlashLoadTimerCallback, null, _flashLoadingData.SendPacketIntervalMilliseconds, Timeout.Infinite);
            else
                _flashLoadtimer = new Timer(FlashLoadTimerCallback, null, GalaxyFlashLoadLimits.DefaultFlashPacketInterval, Timeout.Infinite);

        }

        private void KillFlashLoadTimer()
        {
            if (_flashLoadtimer != null)
            {
                //ManualResetEvent disposed = new ManualResetEvent(false);
                _flashLoadtimer.Dispose();// (disposed);
                                          //disposed.WaitOne();
                _flashLoadtimer = null;
            }
        }

        private void LoadDataTimerCallback(object state)
        {
            if (IsAuthenticated == false)
                return;

            KillDataLoadTimer();

            // Check to see if any of the queued data must be moved into the working lists
            if (_credentialDataToSendParams?.Data == null ||
                !_credentialDataToSendParams.Data.Any() ||
                _credentialDataToSendParams.Data.FirstOrDefault() == null)
            {
                if (_credentialDataToSendQueue != null && _credentialDataToSendQueue.Any())
                {
                    _credentialDataToSendParams = _credentialDataToSendQueue[0];
                    this.Log().Debug($"Moving queued credentailData to working property. Panel.Cpu:{this.PanelId}.{this.CpuId}, Count:{_credentialDataToSendParams.Data.Count}");
                    _credentialDataToSendQueue.RemoveAt(0);
                }
            }

            if (_personalAccessGroupDataToLoadParams?.Data == null || !_personalAccessGroupDataToLoadParams.Data.Any())
            {
                if (_personalAccessGroupDataToLoadQueue != null && _personalAccessGroupDataToLoadQueue.Any())
                {
                    _personalAccessGroupDataToLoadParams = _personalAccessGroupDataToLoadQueue[0];
                    _personalAccessGroupDataToLoadQueue.RemoveAt(0);
                }
            }

            if (_ioGroupDataToLoad != null)
                SendNextInputOutputGroupPacket();
            else if (_accessPortalDataToLoad.Any())
                SendNextAccessPortalData();
            else if (_inputDeviceDataToLoad.Any())
                SendNextInputDeviceData();
            else if (_outputDeviceDataToLoad.Any())
                SendNextOutputDeviceData();
            else if (_credentialDataToDelete.Any())
                SendNextDeleteCredentialPacket();
            else if (_credentialDataToSendParams.Data.Any())
            {
                SendNextCredentialPacket();
            }
            else if (_personalAccessGroupDataToLoadParams.Data.Any())
                SendNextPersonalAccessGroupData();
            else if (_accessGroupDataToLoad.Any())
                SendNextAccessGroupData();

            if (_ioGroupDataToLoad != null ||
                _accessPortalDataToLoad.Any() ||
                _inputDeviceDataToLoad.Any() ||
                _outputDeviceDataToLoad.Any() ||
                _credentialDataToSendParams.Data.Any() ||
                _personalAccessGroupDataToLoadParams.Data.Any() ||
                _credentialDataToDelete.Any() ||
                _accessGroupDataToLoad.Any())
                StartDataLoadTimer();
        }

        private void StartDataLoadTimer()
        {
            KillDataLoadTimer();
            if (_loadDataTimer != null)
                _loadDataTimer = new Timer(LoadDataTimerCallback, null, _loadDataTimerInterval, Timeout.Infinite);
            else
                _loadDataTimer = new Timer(LoadDataTimerCallback, null, _loadDataTimerInterval, Timeout.Infinite);
        }

        private void KillDataLoadTimer()
        {
            if (_loadDataTimer != null)
            {
                _loadDataTimer.Dispose();
                _loadDataTimer = null;
            }
        }

        /// <summary>   Gets new packet to send. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new packet to send. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IDataPacket6xx GetNewPacketToSend()
        {
            IDataPacket6xx p = new DataPacket6xx(_sohValue, _transmitSequence++);
            p.ClusterId = ClusterId;
            p.PanelId = PanelId;
            p.Cpu = (CpuDistribution)CpuId;

            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets new packet to send. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="boardSectionHardwareAddress">  The board section hardware address. </param>
        ///
        /// <returns>   The new packet to send. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IDataPacket6xx GetNewPacketToSend(BoardSectionHardwareAddress boardSectionHardwareAddress)
        {
            IDataPacket6xx p = new DataPacket6xx(_sohValue, _transmitSequence++)
            {
                ClusterId = ClusterId,
                PanelId = PanelId,
                Cpu = (CpuDistribution)CpuId,
                BoardNumber = boardSectionHardwareAddress.BoardNumber,
                SectionEncoded = (ushort)boardSectionHardwareAddress.SectionNumber
            };

            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets new packet to send. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="boardSectionNodeHardwareAddress">  The board section node hardware address. </param>
        ///
        /// <returns>   The new packet to send. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IDataPacket6xx GetNewPacketToSend(BoardSectionNodeHardwareAddress boardSectionNodeHardwareAddress, bool useModuleNumberForSubsection = false)
        {
            IDataPacket6xx p = new DataPacket6xx(_sohValue, _transmitSequence++)
            {
                ClusterId = ClusterId,
                PanelId = PanelId,
                Cpu = (CpuDistribution)CpuId,
                BoardNumber = boardSectionNodeHardwareAddress.BoardNumber
            };

            if (useModuleNumberForSubsection)
                p.EncodeSection((ushort)boardSectionNodeHardwareAddress.SectionNumber, (ushort)boardSectionNodeHardwareAddress.ModuleNumber);
            else
                p.EncodeSection((ushort)boardSectionNodeHardwareAddress.SectionNumber, (ushort)boardSectionNodeHardwareAddress.NodeNumber);

            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the heartbeat. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendHeartbeat()
        {
            IDataPacket6xx p = GetNewPacketToSend();
            Heartbeat c = new Heartbeat();

            c.Cmd = (byte)PacketDataCodeTo6xx.CpuHeartbeat;

            p.FillData(c);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //			GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - Sending heartbeat", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the sign on challenge. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendSignOnChallenge()
        {
            IDataPacket6xx p = GetNewPacketToSend();
            SignOnChallenge c = new SignOnChallenge();
            System.Random rand = new System.Random();

            DateTimeOffset now = DateTimeOffset.Now;

            c.Cmd = (byte)PacketDataCodeTo6xx.CommandSignOnChallenge;
            c.Year = (ushort)now.Year;
            c.Month = (ushort)now.Month;
            c.Day = (ushort)now.Day;
            c.Hour = (ushort)now.Hour;
            c.Minute = (ushort)now.Minute;
            c.Second = (ushort)now.Second;
            c.Random = (ushort)rand.Next();
            c.Sum = (Byte)(c.Cmd +
                           c.Year +
                           c.Month +
                           c.Day +
                           c.Hour +
                           c.Minute +
                           c.Second +
                           c.Random);

            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            //           GCS.Framework.Logging.LogWriter.LogInformation("SendSignOnChallenge. Setting signOnState = SignOnState.SentSignOnChallange");
            this.Log().DebugFormat("SendSignOnChallenge. Setting signOnState = SignOnState.SentSignOnChallange");
            _signOnState = SignOnState.SentSignOnChallange;
            Send(ref p);
        }

        private void SendSignOnChallengeWithOemCode()
        {
            IDataPacket6xx p = GetNewPacketToSend();
            var c = new SignOnChallengeWithOemCode(0);
            System.Random rand = new System.Random();

            DateTimeOffset now = DateTimeOffset.Now;

            c.Cmd = (byte)PacketDataCodeTo6xx.CommandSignOnChallenge;
            c.Year = (ushort)now.Year;
            c.Month = (ushort)now.Month;
            c.Day = (ushort)now.Day;
            c.Hour = (ushort)now.Hour;
            c.Minute = (ushort)now.Minute;
            c.Second = (ushort)now.Second;
            c.Random = (ushort)rand.Next();
            c.Sum = (Byte)(c.Cmd +
                           c.Year +
                           c.Month +
                           c.Day +
                           c.Hour +
                           c.Minute +
                           c.Second +
                           c.Random);

            var oemCodeBytes = Encoding.UTF8.GetBytes(_oemCode);
            Buffer.BlockCopy(oemCodeBytes, 0, c.OemCode, 0, oemCodeBytes.Length);


            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            //           GCS.Framework.Logging.LogWriter.LogInformation("SendSignOnChallenge. Setting signOnState = SignOnState.SentSignOnChallange");
            this.Log().DebugFormat("SendSignOnChallengeWithOemCode. Setting signOnState = SignOnState.SentSignOnChallange");
            _signOnState = SignOnState.SentSignOnChallange;
            Send(ref p);
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Accept sign on challenge response. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="pkt">  [in,out] The packet. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task AcceptSignOnChallengeResponse(int clusterId, int panelNumber, short cpuId, byte[] data, ushort length)
        {
            _cpuConnectionInfo.GalaxyCpuInformation.ClusterNumber = clusterId;
            _cpuConnectionInfo.GalaxyCpuInformation.PanelNumber = panelNumber;
            _cpuConnectionInfo.GalaxyCpuInformation.CpuId = cpuId;
            SignOnResponse resp = new SignOnResponse(data);

            if (length == 48)
            {
                _cpuConnectionInfo.GalaxyCpuInformation.ClusterGroupId = resp.ClusterGroupId;// _cpuConnectionInfo.GalaxyCpuInformation.ClusterGroupId.TrimEnd(' ');
            }

            this.Log().InfoFormat("AcceptSignOnChallengeResponse. Setting signOnState = SignOnState.SentDateTimeSync");
            _signOnState = SignOnState.SentDateTimeSync;
            await GetGalaxyCpuDatabaseInformationAsync();
            if (this.CpuUid.HasValueAndNotEmpty())
            {
                Task.Run(async () =>
                {
                    await UpdateCpuConnectionStatus(new GalaxyCpuConnection()
                    {
                        CpuUid = this.CpuConnectionInfo.CpuDatabaseInformation.CpuUid,
                        IsConnected = true,
                        ServerAddress = this._serverAddress
                    });
                }).Wait();
            }

            LoadDateTime();
            //	NotifyCommServerOfNewConnection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Handles the set date time challenge described by pkt. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="pkt">  [in,out] The packet. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HandleSetDateTimeChallenge(ref IDataPacket6xx pkt)
        {
            IDataPacket6xx p = GetNewPacketToSend();
            p.When = pkt.When;
            SetPanelDateTime data = new SetPanelDateTime();
            //DateTimeOffset now = DateTimeOffset.Now;
            var now = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(TimeZoneId);

            //if( !string.IsNullOrEmpty(CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId))
            //{
            //    var tzTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId);
            //}

            UInt32 offset = 0;

            data.Cmd = (byte)PacketDataCodeTo6xx.CommandSetDateTime;
            data.hour = (byte)now.Hour;         // 0-23
            data.minute = (byte)now.Minute;     // 0-59
            data.second = (byte)now.Second;     // 0-59
            data.month = (byte)now.Month;           // 1-12
            data.day = (byte)now.Day;           // 1-31
            data.year = (byte)(now.Year % 100); // year - 1900 
            data.century = (byte)(now.Year / 100);  // century
            data.seconds_from_universal_time = offset;

            p.FillData(data);//, Marshal.SizeOf(c));

            p.PrepareForTransmission(false, false, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Loads date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void LoadDateTime()
        {
            IDataPacket6xx p = GetNewPacketToSend();
            SetPanelDateTime data = new SetPanelDateTime();
            //DateTimeOffset now = DateTimeOffset.Now;
            var now = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(TimeZoneId);
            //if( !string.IsNullOrEmpty(CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId))
            //{
            //    var tzTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId);
            //}

            UInt32 offset = 0;

            data.Cmd = (byte)PacketDataCodeTo6xx.CommandSetDateTime;
            data.hour = (byte)now.Hour;         // 0-23
            data.minute = (byte)now.Minute;     // 0-59
            data.second = (byte)now.Second;     // 0-59
            data.month = (byte)now.Month;           // 1-12
            data.day = (byte)now.Day;           // 1-31
            data.year = (byte)(now.Year % 100); // year - 1900 
            data.century = (byte)(now.Year / 100);  // century
            data.seconds_from_universal_time = offset;

            p.FillData(data);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }


        public void ChangeTimeZone(string timeZoneId)
        {
            IDataPacket6xx p = GetNewPacketToSend();
            p.FillWhen(this.TimeZoneId);
            
            this.CpuConnectionInfo.CpuDatabaseInformation.TimeZoneId = timeZoneId;

            SetPanelDateTime data = new SetPanelDateTime();
            //DateTimeOffset now = DateTimeOffset.Now;
            var now = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(TimeZoneId);
            //if( !string.IsNullOrEmpty(CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId))
            //{
            //    var tzTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, CpuConnectionInfo?.CpuDatabaseInformation?.TimeZoneId);
            //}

            UInt32 offset = 0;

            data.Cmd = (byte)PacketDataCodeTo6xx.CommandSetDateTime;
            data.hour = (byte)now.Hour;         // 0-23
            data.minute = (byte)now.Minute;     // 0-59
            data.second = (byte)now.Second;     // 0-59
            data.month = (byte)now.Month;           // 1-12
            data.day = (byte)now.Day;           // 1-31
            data.year = (byte)(now.Year % 100); // year - 1900 
            data.century = (byte)(now.Year / 100);  // century
            data.seconds_from_universal_time = offset;

            p.FillData(data);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, false, TimeZoneId);
            Send(ref p);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets logging state. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetLoggingState(ActivityLoggingState state, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            IDataPacket6xx p = GetNewPacketToSend();
            SetLoggingState c = new SetLoggingState();
            System.Random rand = new System.Random();

            DateTimeOffset now = DateTimeOffset.Now;

            c.Cmd = (byte)PacketDataCodeTo6xx.CommandLoggingSetOnOff;
            switch (state)
            {
                case ActivityLoggingState.Off:
                    c.State = 0;
                    break;

                case ActivityLoggingState.On:
                    c.State = 1;
                    break;
            }

            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets logging pointers. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetLoggingPointers()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a single byte command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cmd">  The command. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendSingleByteCommand(PacketDataCodeTo6xx cmd, MessageTrackingData trackingData)
        {
            IDataPacket6xx p = GetNewPacketToSend();
            SingleByteCommand c = new SingleByteCommand();
            c.Cmd = (Byte)cmd;
            c.OpId = p.SequenceNumber;
            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);

            if (trackingData != null)
            {
                switch (cmd)
                {
                    case PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation:
                        SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeFrom6xx.ResponseConnectedBoardInformation, trackingData, true);
                        break;

                    case PacketDataCodeTo6xx.CommandRequestTotalCardCount:
                        SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeFrom6xx.ResponseTotalCardCount, trackingData, true);
                        break;

                    case PacketDataCodeTo6xx.CommandPanelInquire:
                        SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeFrom6xx.ResponsePanelInquire, trackingData, true);
                        break;

                    case PacketDataCodeTo6xx.CommandRequestLoggingInformation:
                        SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeFrom6xx.ResponseRequestLoggingInformation, trackingData, true);
                        break;

                    //case PacketDataCodeTo6xx.CommandClearAutoTimer:
                    //    break;

                    //case PacketDataCodeTo6xx.CommandClearAllUsers:
                    //    break;

                    //case PacketDataCodeTo6xx.CommandRecalibrate:
                    //    break;

                    default:
                        SetExpectedResponseInfo(p.SequenceNumber, trackingData, true);
                        break;
                }

            }

            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a single byte command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    [in,out] The IDataPacket6xx to process. </param>
        /// <param name="cmd">  The command. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendSingleByteCommand(ref IDataPacket6xx p, PacketDataCodeTo6xx cmd, MessageTrackingData trackingData)
        {
            SingleByteCommand c = new SingleByteCommand();
            c.Cmd = (Byte)cmd;
            c.OpId = p.SequenceNumber;
            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);

            if (trackingData != null)
            {
                SetExpectedResponseInfo(p.SequenceNumber, trackingData, true);
            }

            Send(ref p);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a buffer. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendBuffer(byte[] data)
        {
            IDataPacket6xx p = GetNewPacketToSend();
            p.FillData(data);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the connection state changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaiseConnectionStateChangedEvent()
        {

            var handler = ConnectionStateChangedEvent;
            if (handler != null)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("Connection6xx::RaiseConnectionStateChangedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid));
                this.Log().DebugFormat("Connection6xx::RaiseConnectionStateChangedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                handler(this, new ConnectionStateChangeEventArgs(new CpuConnectionInfo(CpuConnectionInfo)));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the connection state changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaiseConnectionClosedEvent()
        {
            if (_connectionCloseEventRaised == false)
            {
                //SendToProcessingQueue(CpuConnectionInfo, null);
                var handler = ConnectionClosedEvent;
                if (handler != null)
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("Connection6xx::RaiseConnectionClosedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid));
                    this.Log().DebugFormat("Connection6xx::RaiseConnectionClosedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                    handler(this, this.SocketEventArgs);
                    _connectionCloseEventRaised = true;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the connection state changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaisePanelInformationEvent()
        {

            var handler = PanelInformationEvent;
            if (handler != null)
            {
                //                this.Log().DebugFormat("Connection6xx::RaisePanelInformationEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                if (this._panelInqueryReply != null)
                    CpuConnectionInfo.GalaxyCpuInformation.InqueryReply = this._panelInqueryReply;
                if (this._cardCountReply != null)
                    CpuConnectionInfo.GalaxyCpuInformation.CardCountReply = this._cardCountReply;
                if (this._loggingStatusReply != null)
                    CpuConnectionInfo.GalaxyCpuInformation.LoggingStatusReply = this._loggingStatusReply;
                if (this._boardInformationReply != null)
                    CpuConnectionInfo.GalaxyCpuInformation.Boards = this._boardInformationReply;
                PanelInformationEventArgs args = new PanelInformationEventArgs(CpuConnectionInfo.GalaxyCpuInformation);
                handler(this, args);
            }
        }
        #endregion

        #region IDisposable Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prepare to close. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrepareToClose(bool deletedPanel)
        {
            KillTimer();
            KillFlashLoadTimer();

            if (_cpuConnectionInfo.IsConnected)
            {
                _cpuConnectionInfo.IsConnected = false;
                if (this.CpuConnectionInfo?.CpuDatabaseInformation != null && !deletedPanel)
                {
                    Task.Run(async () =>
                    {
                        await UpdateCpuConnectionStatus(new GalaxyCpuConnection()
                        {
                            CpuUid = this.CpuConnectionInfo.CpuDatabaseInformation.CpuUid,
                            IsConnected = _cpuConnectionInfo.IsConnected,
                            ServerAddress = this._serverAddress
                        });
                    }).Wait();
                }
            }

            RaiseConnectionClosedEvent();
            //if (Socket != null)
            //{
            //	if (Socket.Connected == true)
            //	{
            //		Socket.Disconnect(true);
            //		Socket.Close();
            //	}
            //}
            //cpuConnectionInfo.IsConnected = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void IDisposable.Dispose()
        {
            if (_disposed)
                return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Releases the unmanaged resources used by the Connection6xx and optionally releases the
        /// managed resources.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="disposing">    true to release both managed and unmanaged resources; false to
        ///                                     release only unmanaged resources. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (_disposed)
                    return;

                if (disposing)
                {
                    PrepareToClose(false);
                }
                _disposed = true;
            }
            catch (Exception)
            { }
        }

        #endregion

        #region Public Methods

        public void TakeAction(ActionCode actionCode, int delayMs)
        {
            switch (actionCode)
            {
                case ActionCode.RefreshCpuDatabaseInformation:
                    if (this.CpuUid.HasValueAndNotEmpty())
                        _scheduler.Execute(async () => await GetGalaxyCpuDatabaseInformationAsync(), delayMs);
                    else
                        PrepareToClose(false);
                    break;

                case ActionCode.DisconnectCpu:
                    PrepareToClose(false);
                    break;

                case ActionCode.DisconnectDeletedCpu:
                    PrepareToClose(true);
                    break;

                case ActionCode.SendTimeToPanel:
                    LoadDateTime();
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a raw data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data">     The data. </param>
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRawData(RawDataToSend data, object param)
        {
            var p = GetNewPacketToSend(data.Address);
            Int32 discarded;
            Byte[] bytes = GCS.Framework.Utilities.HexEncoding.GetBytesFromHexString(data.StringData, 0, out discarded);
            p.FillData(bytes);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the get logging information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetLoggingInfo(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestLoggingInformation, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestLoggingInformation, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the get card count. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetCardCount(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestTotalCardCount, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestTotalCardCount, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the get controller information. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetControllerInfo(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandPanelInquire, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandPanelInquire, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the Ping controller. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendPing(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandPing, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandPing, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the board section. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitializeBoardSection(SendDataParameters<InitializeBoardSectionSettings> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter InitializeBoardSectionSettings data cannot be null"));
            if (data.Data.Address.ClusterNumber == 0)
                data.Data.Address.ClusterNumber = this.ClusterId;
            if (data.Data.Address.PanelNumber == 0)
                data.Data.Address.PanelNumber = this.PanelId;
            if (data.Data.Address.CpuId == 0)
                data.Data.Address.CpuId = this.CpuId;

            if (data.Data.Address.ClusterNumber != this.ClusterId)
            {
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("InitializeBoardSection data.Address.ClusterId != this.ClusterId."));
                this.Log().InfoFormat("InitializeBoardSection data.Address.ClusterId != this.ClusterId.");
                return;
            }

            if (data.Data.Address.PanelNumber != this.PanelId)
            {
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("InitializeBoardSection data.Address.PanelId != this.PanelId."));
                this.Log().InfoFormat("InitializeBoardSection data.Address.PanelId != this.PanelId.");
                return;
            }

            IDataPacket6xx p = GetNewPacketToSend(data.Data.Address);
            InitializeBoardSection d = new InitializeBoardSection();

            d.Cmd = (byte)PacketDataCodeTo6xx.CommandInitializeBoardSection;
            d.Type = data.Data.TypeCode;
            d.RelayCount = (byte)data.Data.RelayCount;

            // Save info in _boardSectionTypes dictionary
            SaveBoardSectionType(p.BoardSectionAddressString, data.Data.SectionType);

            p.FillData(d);//, Marshal.SizeOf(c));

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        private void SaveBoardSectionType(string sKey, PanelInterfaceBoardSectionType sectionType)
        {
            try
            {
                _boardSectionTypes[sKey] = sectionType;
            }
            catch (KeyNotFoundException ex)
            {
                this.Log().Info($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}", ex);
            }
            catch (Exception ex)
            {
                this.Log().Info($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}", ex);
            }
        }

        private PanelInterfaceBoardSectionType GetBoardSectionType(string sKey)
        {
            try
            {
                var pibst = PanelInterfaceBoardSectionType.Unused;
                if (_boardSectionTypes.TryGetValue(sKey, out pibst))
                    return pibst;
                GalaxyInterfaceBoardSection bs = null;
                if (_interfaceBoardSections.TryGetValue(sKey, out bs))
                {
                    var sectionType = GenericEnums.GetOne<PanelInterfaceBoardSectionType>(bs.ModeCode);
                    return sectionType;
                }
                return PanelInterfaceBoardSectionType.Unused;
                //var pibst = _boardSectionTypes[sKey];
                //return pibst;
            }
            catch (KeyNotFoundException ex)
            {
                this.Log().Info($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}", ex);
            }
            catch (Exception ex)
            {
                this.Log().Info($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}", ex);
            }
            return PanelInterfaceBoardSectionType.Unused;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Send this message. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    [in,out] The IDataPacket6xx to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Send(ref IDataPacket6xx p)
        {
            bool bThisIsAResetCommand = false;
            if (DebuggingMode == true || (PacketDataCodeTo6xx)p.Data[0] != PacketDataCodeTo6xx.CpuHeartbeat)
            {
                if ((PacketDataCodeTo6xx)p.Data[0] == PacketDataCodeTo6xx.CommandResetCpu ||
                    (PacketDataCodeTo6xx)p.Data[0] == PacketDataCodeTo6xx.CommandValidateThenBurnFlash635 ||
                    (PacketDataCodeTo6xx)p.Data[0] == PacketDataCodeTo6xx.CommandValidateThenBurnFlash600)
                    bThisIsAResetCommand = true;

                byte[] bytes = p.GetBytes();

                if ((PacketDataCodeTo6xx)p.Data[0] != PacketDataCodeTo6xx.CpuHeartbeat)
                {
                    IDataPacket6xx pkt = new DataPacket6xx(p.Soh, bytes);
                    //  SendToProcessingQueue(pkt); // only do this if the outbound message must be sent to other processes.
                    SendToRecordingQueue(pkt);
                }

                if (DebuggingMode == true)
                {
                    var debugHandler = DebugPacketEvent;
                    if (debugHandler != null)
                    {
                        IDataPacket6xx pktDbg = new DataPacket6xx(p.Soh, bytes);
                        debugHandler(this, new ConnectionDebugPacketEventArgs(ref pktDbg, DataDirection.TransmittedToPanel, this.CpuConnectionInfo));
                    }
                }
            }

            switch (_receiver.CryptoType)
            {
                case PanelProtocols.CryptoType.Aes:
                    p.Encrypt(_receiver.AesEncryptionKey);
                    break;

                case PanelProtocols.CryptoType.None:
                    break;
            }
            byte[] msgToSend = p.GetBytes();

            Send(msgToSend);
            if (bThisIsAResetCommand)
                this.Socket.Close();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a packet. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendPacket(object param)
        {
            if (param is IDataPacket6xx)
            {
                IDataPacket6xx pkt = (IDataPacket6xx)param;
                Send(ref pkt);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendResetCommand(GalaxySMS.Business.Entities.SendDataParameters<GalaxyPanelResetCommand> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendResetCommand data cannot be null"));

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new ResetCpuCommand
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandResetCpu,
            };

            //d.ResetType = (ResetCpuCommand.ResetTypeValue)data.Data.ResetType;
            switch (data.Data.ResetType)
            {
                case CpuResetType.ColdReset:
                    d.ResetType = ResetCpuCommand.ResetTypeValue.ForceColdReset;
                    break;
                case CpuResetType.WarmReset:
                    d.ResetType = ResetCpuCommand.ResetTypeValue.SimulateResetButtonPress;
                    break;
            }
            p.FillData(d);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        private void SendResetCommand(ResetCpuCommand.ResetTypeValue resetType)
        {
            var p = GetNewPacketToSend();
            var d = new ResetCpuCommand
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandResetCpu,
                ResetType = resetType
            };

            p.FillData(d);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an aba settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAbaSettings(GalaxySMS.Business.Entities.SendDataParameters<AbaSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAbaSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetAbaSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadABAOptions,
                Start = (byte)data.Data.Start,
                End = (byte)data.Data.End,
                Flags = (byte)data.Data.Clipping
            };

            d.Flags |= (byte)data.Data.Folding;

            p.FillData(d);

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);

            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadABAOptions);

            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a wiegand settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendWiegandSettings(GalaxySMS.Business.Entities.SendDataParameters<WiegandSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendWiegandSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetWiegandSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadWiegandStartStopSettings,
                Start = (byte)data.Data.Start,
                End = (byte)data.Data.End
            };


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadWiegandStartStopSettings);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cardax settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCardaxSettings(GalaxySMS.Business.Entities.SendDataParameters<CardaxSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCardaxSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetCardaxSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadCardaxStartStopSettings,
                Start = (byte)data.Data.Start,
                End = (byte)data.Data.End
            };


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadCardaxStartStopSettings);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reader lockout settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendReaderLockoutSettings(GalaxySMS.Business.Entities.SendDataParameters<ReaderLockoutSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendReaderLockoutSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetReaderLockoutSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadLockoutOptions,
                MaximumInvalidAttempts = (byte)data.Data.MaximumInvalidAttempts,
                LockoutTimeInHundredthsOfSeconds = (ushort)data.Data.LockoutTimeInHundredthsOfSeconds,
                CardTourManagerControllerNumber = 0
            };


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadLockoutOptions);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   508i only. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendLoopTransmitDelaySettings(GalaxySMS.Business.Entities.SendDataParameters<LoopTransmitDelaySettings> data)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time adjustment settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeAdjustmentSettings(GalaxySMS.Business.Entities.SendDataParameters<DaylightSavingsTimeAdjustmentSettings> data)
        {

            //if (data?.Data == null)
            //    throw new ArgumentNullException("data", string.Format("The parameter SendTimeAdjustmentSettings data cannot be null"));

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}

            //var p = GetNewPacketToSend(data.SendToAddress);
            //var d = new SetTimeAdjustment
            //{
            //    Cmd = (byte)PacketDataCode6xx.CommandLoadTimeAdjustment,
            //};


            //p.FillData(d);
            //p.PrepareForTransmission(false, true, TimeZoneId);
            //Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a LED behavior settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendLedBehaviorSettings(GalaxySMS.Business.Entities.SendDataParameters<LedBehaviorSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendLedBehaviorSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetLedModes
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadLedOptions,
                NoLeds = (byte)data.Data.BothOff,
                GreenSolid = (byte)data.Data.GreenSolid,
                RedSolid = (byte)data.Data.RedSolid,
                BothSolid = (byte)data.Data.BothSolid,
                GreenBlink6TimesPerSecond = (byte)data.Data.GreenBlink,
                GreenBlink12TimesPerSecond = (byte)data.Data.GreenBlinkFast,
                BothBlink12TimesPerSecond = (byte)data.Data.BothBlinkFast,
                RedBlink2TimesPerSecond = (byte)data.Data.RedBlinkSlow,
            };

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadLedOptions);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the crisis mode settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCrisisModeSettings(GalaxySMS.Business.Entities.SendDataParameters<CrisisModeSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCrisisModeSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetCrisisModeSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadCrisisModeIOGroup,
                ActivateIoGroupNumber = (byte)data.Data.ActivateInputOutputGroupNumber.GroupNumber,
                ResetIoGroupNumber = (byte)data.Data.ResetInputOutputGroupNumber.GroupNumber,
            };

            if (data.Data.AutoReset == true)
            {
                d.ResetIoGroupNumber = d.ActivateIoGroupNumber;
            }

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadCrisisModeIOGroup);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a server consultation settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendServerConsultationSettings(GalaxySMS.Business.Entities.SendDataParameters<ServerConsultationSettings> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendServerConsultationSettings data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetServerConsultationSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandSetServerConsultationOptions,
                UnlimitedCredentialTimeout = (ushort)data.Data.UnknownCredentialLookupTimeout,
                AccessDecisionOverrideTimeout = (ushort)data.Data.AccessDecisionTimeout
            };

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandSetServerConsultationOptions);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an interface board section data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendInterfaceBoardSectionData(GalaxySMS.Business.Entities.SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInterfaceBoardSectionData data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.BoardNumber = data.Data.BoardNumber;
            data.SendToAddress.SectionNumber = data.Data.SectionNumber;
            InitializeBoardSectionSettings initBoardSectionData = null;

            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.BoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    initBoardSectionData = new InitializeBoardSectionSettings();
                    initBoardSectionData.Address.BoardNumber = data.Data.BoardNumber;
                    initBoardSectionData.Address.SectionNumber = data.Data.SectionNumber;
                    initBoardSectionData.SectionType = (GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType)data.Data.BoardSectionMode;
                    initBoardSectionData.ReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)0;
                    initBoardSectionData.RelayCount = data.Data.RelayCount;
                    initBoardSectionData.OperationUid = data.OperationUid;
                    InitializeBoardSection(new SendDataParameters<InitializeBoardSectionSettings>(data)
                    {
                        Data = initBoardSectionData
                    });
                    break;
            }

        }

        public void SendPanelAlarmSettings(GalaxySMS.Business.Entities.SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter GalaxyPanelAlarmSettings_PanelLoadData data cannot be null"));

            foreach (var o in data.Collection)
            {
                o.Validate();
                if (!o.IsValid)
                {
                    throw new DataValidationException(o.ValidationErrors);
                }
            }

            var p = GetNewPacketToSend();
            var d = new SetControllerAlarmSettings
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadTamperAcFailureLowBattery,
            };

            // Only set for those that are active
            foreach (var o in data.Collection.Where(x => x.IsActive))
            {
                var enumValue = EnumExtensions.GetOne<GalaxySMS.Common.Enums.GalaxyPanelAlertEventType>(o.Tag);
                switch (enumValue)
                {
                    case GalaxySMS.Common.Enums.GalaxyPanelAlertEventType.LowBattery:
                        d.LowBattery.IoGroupNumber = (byte)o.IOGroupNumber;
                        if (o.OffsetIndex > 0 && o.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                            d.LowBattery.Offset = (byte)(o.OffsetIndex - 1);
                        break;
                    case GalaxySMS.Common.Enums.GalaxyPanelAlertEventType.ACFailure:
                        d.AcFailure.IoGroupNumber = (byte)o.IOGroupNumber;
                        if (o.OffsetIndex > 0 && o.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                            d.AcFailure.Offset = (byte)(o.OffsetIndex - 1);
                        break;
                    case GalaxySMS.Common.Enums.GalaxyPanelAlertEventType.Tamper:
                        d.Tamper.IoGroupNumber = (byte)o.IOGroupNumber;
                        if (o.OffsetIndex > 0 && o.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                            d.Tamper.Offset = (byte)(o.OffsetIndex - 1);
                        break;
                    case GalaxySMS.Common.Enums.GalaxyPanelAlertEventType.EmergencyUnlock:
                        d.EmergencyUnlock.IoGroupNumber = (byte)o.IOGroupNumber;
                        if (o.OffsetIndex > 0 && o.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                            d.EmergencyUnlock.Offset = (byte)(o.OffsetIndex - 1);
                        break;
                }
            }

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadTamperAcFailureLowBattery);
            Send(ref p);

        }

        public void SendLoadDataFinished(SendDataParameters data, string hint)
        {
            if (data?.OperationUid == null || data.OperationUid == Guid.Empty)
                throw new ArgumentNullException("data.OperationUid", $"The parameter {nameof(data.OperationUid)} cannot be null or {Guid.Empty}");

            var p = GetNewPacketToSend();
            if (string.IsNullOrEmpty(hint))
                hint = "**";
            var d = new EchoNackData(hint)
            {

            };

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            //SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadTamperAcFailureLowBattery);
            Send(ref p);
        }

        public void SetInputOutputGroupDataForLoading(GalaxySMS.Business.Entities.SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            _ioGroupDataToLoad = new GalaxySMS.Business.Entities.SendDataParameters<InputOutputGroup_PanelLoadData>(data);
            _ioGroupDataToLoad.Data = data.Collection.FirstOrDefault();
            _ioGroupDataToLoad.Collection.Remove(_ioGroupDataToLoad.Data);
            SendInputOutputGroupData(_ioGroupDataToLoad);
            if (!_ioGroupDataToLoad.Collection.Any())
                _ioGroupDataToLoad = null;
        }


        private void SendNextInputOutputGroupPacket()
        {
            KillDataLoadTimer();
            var iog = _ioGroupDataToLoad.Collection.FirstOrDefault();
            if (iog != null)
            {

                _ioGroupDataToLoad.Data = iog;
                _ioGroupDataToLoad.Collection.Remove(_ioGroupDataToLoad.Data);
                SendInputOutputGroupData(_ioGroupDataToLoad);
            }

            if (!_ioGroupDataToLoad.Collection.Any())
            {
                //SendLoadDataFinished(_ioGroupDataToLoad, nameof(LoadDataToPanelSettings.InputOutputGroups));
                _ioGroupDataToLoad = null;
            }
        }

        private void SendNextAccessPortalData()
        {
            KillDataLoadTimer();
            var ap = _accessPortalDataToLoad.FirstOrDefault();
            if (ap != null)
            {
                Task.Run(async () =>
                {
                    await RefreshAccessPortalHardwareDeviceData(ap.Data.AccessPortalUid);
                });

                SendAccessPortalDataImmediate(ap);
                _accessPortalDataToLoad.Remove(ap);
                //if(!_accessGroupDataToLoad.Any() && 
                //   !_inputDeviceDataToLoad.Any() && 
                //   !_outputDeviceDataToLoad.Any())
                //    SendLoadDataFinished(ap, nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));

                //if(!_accessGroupDataToLoad.Any() &&
                //   !_accessGroupDataToLoad.Any())
                //    SendLoadDataFinished(ap, nameof(LoadDataToPanelSettings.AccessRules));
            }
        }

        private void SendNextInputDeviceData()
        {
            KillDataLoadTimer();
            var id = _inputDeviceDataToLoad.FirstOrDefault();
            if (id != null)
            {
                Task.Run(async () =>
                {
                    await RefreshInputDeviceHardwareDeviceData(id.Data.InputDeviceUid);
                });

                switch ((GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType)id.Data.InputDeviceBoardSectionMode)
                {
                    case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                        SendDigitalInputOutputInputDeviceDataImmediate(id);
                        _inputDeviceDataToLoad.Remove(id);
                        break;

                    case PanelInterfaceBoardSectionType.RS485InputModule:
                        //if( !id.Collection.Any())
                        //    id.Collection = _inputDeviceDataToLoad.Where(o=>o.Data.GalaxyHardwareModuleUid == id.Data.GalaxyHardwareModuleUid).ToList();
                        SendInputModuleDataImmediate(id);
                        _inputDeviceDataToLoad.Remove(id);
                        break;

                    case PanelInterfaceBoardSectionType.Unused:
                    case PanelInterfaceBoardSectionType.VeridtReader:
                    case PanelInterfaceBoardSectionType.DrmSection:
                    case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    case PanelInterfaceBoardSectionType.ElevatorRelays:
                    case PanelInterfaceBoardSectionType.CypressClockDisplay:
                    case PanelInterfaceBoardSectionType.OutputRelays:
                    case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                    case PanelInterfaceBoardSectionType.AllegionPimAba:
                    case PanelInterfaceBoardSectionType.LCD_4x20Display:
                    case PanelInterfaceBoardSectionType.RS485DoorModule:
                    case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                    case PanelInterfaceBoardSectionType.SaltoSallis:
                    case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.VeridtCpu:
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //if (!_accessGroupDataToLoad.Any() && !_inputDeviceDataToLoad.Any() && !_outputDeviceDataToLoad.Any())
                //    SendLoadDataFinished(id, nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));
            }
        }

        private async void SendNextOutputDeviceData()
        {
            KillDataLoadTimer();
            var od = _outputDeviceDataToLoad.FirstOrDefault();
            if (od != null)
            {
                await RefreshOutputDeviceHardwareDeviceData(od.Data.OutputDeviceUid);

                // await Task.Run(async () =>
                //{
                //});

                switch ((GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType)od.Data.OutputDeviceBoardSectionMode)
                {
                    case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    case PanelInterfaceBoardSectionType.OutputRelays:
                        SendOutputDeviceDataImmediate(od);
                        _outputDeviceDataToLoad.Remove(od);
                        break;

                    case PanelInterfaceBoardSectionType.Unused:
                    case PanelInterfaceBoardSectionType.VeridtReader:
                    case PanelInterfaceBoardSectionType.DrmSection:
                    case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                    case PanelInterfaceBoardSectionType.ElevatorRelays:
                    case PanelInterfaceBoardSectionType.CypressClockDisplay:
                    case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                    case PanelInterfaceBoardSectionType.AllegionPimAba:
                    case PanelInterfaceBoardSectionType.LCD_4x20Display:
                    case PanelInterfaceBoardSectionType.RS485DoorModule:
                    case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                    case PanelInterfaceBoardSectionType.SaltoSallis:
                    case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.VeridtCpu:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                //if (!_accessGroupDataToLoad.Any() && !_inputDeviceDataToLoad.Any() && !_outputDeviceDataToLoad.Any())
                //    SendLoadDataFinished(od, nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));
            }
        }

        private void SendNextAccessGroupData()
        {
            KillDataLoadTimer();
            var ag = _accessGroupDataToLoad.FirstOrDefault();
            if (ag != null)
            {
                _accessGroupDataToLoad.Remove(ag);
                SendAccessGroupDataImmediate(ag);

                //if (!_accessGroupDataToLoad.Any() &&
                //    !_accessPortalDataToLoad.Any())
                //    SendLoadDataFinished(ag, nameof(LoadDataToPanelSettings.AccessRules));
            }
        }

        private void SendNextPersonalAccessGroupData()
        {
            KillDataLoadTimer();
            var pag = _personalAccessGroupDataToLoadParams.Data.FirstOrDefault();
            if (pag != null)
            {
                _personalAccessGroupDataToLoadParams.Data.Remove(pag);
                var sendParams =
                    new SendDataParameters<List<PersonalAccessGroup_PanelLoadData>>(
                        _personalAccessGroupDataToLoadParams)
                    { Data = pag.ToList() };
                SendPersonalAccessGroupDataImmediate(sendParams);

                //if (!_credentialDataToSendParams.Data.Any() &&
                //    !_credentialDataToDelete.Any() &&
                //    !_credentialDataToSendQueue.Any() &&
                //    !_personalAccessGroupDataToLoadParams.Data.Any() &&
                //    !_personalAccessGroupDataToLoadQueue.Any())
                //    SendLoadDataFinished(sendParams, nameof(LoadDataToPanelSettings.AllCardData));
            }
        }

        private void SendNextCredentialPacket()
        {
            KillDataLoadTimer();

            var first = _credentialDataToSendParams.Data.FirstOrDefault();
            if (first == null)
            {
                if (_credentialDataToSendParams.Data.Any())
                    _credentialDataToSendParams.Data.Remove(first);
                return;
            }

            IEnumerable<Credential_PanelLoadData> credentialsToSend = new List<Credential_PanelLoadData>();
            if (first.CredentialDataLength == GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Standard48Bit)
                credentialsToSend = _credentialDataToSendParams.Data.Take(CredentialData48Bit.NumberOfCredentials).ToList();
            else if (first.CredentialDataLength == GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits)
            {
                credentialsToSend = _credentialDataToSendParams.Data.Take(CredentialData256Bit.NumberOfCredentials).ToList();
            }

            if (credentialsToSend.Any())
            {
                foreach (var c in credentialsToSend)
                {
                    if (_credentialDataToSendParams.Data.Any() && _credentialDataToSendParams.Data.Contains(c))
                    {
                        this.Log().Debug($"SendNextCredentialPacket: Panel:{this.PanelId}, Removing Credential:{c.CardNumber}, count:{_credentialDataToSendParams.Data.Count}");
                        _credentialDataToSendParams.Data.Remove(c);
                    }
                    else
                    {
                        this.Log().Info($"SendNextCredentialPacket: Panel:{this.PanelId}, Credential not found:{c.CardNumber}, count:{_credentialDataToSendParams.Data.Count}");
                    }
                }

                var sendParams = new SendDataParameters<List<Credential_PanelLoadData>>(_credentialDataToSendParams)
                {
                    Data = credentialsToSend.ToList()
                };

                SendCredentialDataImmediate(sendParams);

                //if (!_credentialDataToSendParams.Data.Any() &&
                //    !_credentialDataToDelete.Any() &&
                //    !_credentialDataToSendQueue.Any() &&
                //    !_personalAccessGroupDataToLoadParams.Data.Any() &&
                //    !_personalAccessGroupDataToLoadQueue.Any())
                //    SendLoadDataFinished(sendParams, nameof(LoadDataToPanelSettings.AllCardData));

            }
            else
            {
                this.Log().Info($"SendNextCredentialPacket has no credentials to send\n");
            }


        }

        private void SendNextDeleteCredentialPacket()
        {
            KillDataLoadTimer();
            var first = _credentialDataToDelete.FirstOrDefault();
            if (first == null)
                return;

            SendDeleteCredential(first.CardBinaryData);

            //if (!_credentialDataToSendParams.Data.Any() &&
            //    !_credentialDataToDelete.Any() &&
            //    !_credentialDataToSendQueue.Any() &&
            //    !_personalAccessGroupDataToLoadParams.Data.Any() &&
            //    !_personalAccessGroupDataToLoadQueue.Any())
            //    SendLoadDataFinished(sendParams, nameof(LoadDataToPanelSettings.AllCardData));
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an input output group data. </summary>
        ///
        /// <remarks>   Kevin, 3/5/2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendInputOutputGroupData(GalaxySMS.Business.Entities.SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter InputOutputGroup_PanelLoadData data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new InputOutputGroupData
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadIOGroupArmSchedule,
                IoGroupNumber = (byte)data.Data.IOGroupNumber,
                ArmSchedule = (byte)data.Data.PanelScheduleNumber,
            };

            if (data.Data.LocalIOGroup != false)
                d.LocalOnly = 1;

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            SetSessionIdForAckNackResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeTo6xx.CommandLoadIOGroupArmSchedule);
            Send(ref p);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="DataValidationException">      Thrown when a Data Validation error condition
        ///                                                 occurs. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalData(GalaxySMS.Business.Entities.SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalData data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            _accessPortalDataToLoad.Add(data);
            StartDataLoadTimer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal data immediate. </summary>
        ///
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="DataValidationException">      Thrown when a Data Validation error condition
        ///                                                 occurs. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendAccessPortalDataImmediate(GalaxySMS.Business.Entities.SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalDataImmediate data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.BoardNumber = data.Data.BoardNumber;
            data.SendToAddress.SectionNumber = data.Data.SectionNumber;
            data.SendToAddress.NodeNumber = data.Data.NodeNumber;

            InitializeBoardSectionSettings initBoardSectionData = null;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.AccessPortalBoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    initBoardSectionData = new InitializeBoardSectionSettings();
                    initBoardSectionData.Address.BoardNumber = data.Data.BoardNumber;
                    initBoardSectionData.Address.SectionNumber = data.Data.SectionNumber;
                    initBoardSectionData.SectionType = GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType.DrmSection;
                    initBoardSectionData.ReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)data.Data.PanelDataFormatCode;
                    data.SendToAddress.NodeNumber = 0;
                    initBoardSectionData.OperationUid = data.OperationUid;
                    InitializeBoardSection(new SendDataParameters<InitializeBoardSectionSettings>(data) { Data = initBoardSectionData });
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    //initBoardSectionData = new InitializeBoardSectionSettings();
                    //initBoardSectionData.Address.BoardNumber = data.Data.BoardNumber;
                    //initBoardSectionData.Address.SectionNumber = data.Data.SectionNumber;
                    //initBoardSectionData.SectionType = (GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType)data.Data.AccessPortalBoardSectionMode;
                    //initBoardSectionData.ReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)data.Data.PanelDataFormatCode;
                    //InitializeBoardSection(initBoardSectionData);
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new ReaderPort6xx
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData,
                DoorNumber = (byte)data.Data.DoorNumber,
            };

            d.NodeType.Type = (byte)data.Data.PanelDataFormatCode;


            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.AccessPortalBoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    d.NodeType.Type |= (byte)ReaderPort6xx.ReaderNodeTypeFlags.DrmReader;
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    switch ((GalaxySMS.Common.Enums.DualSerialChannelMode)data.Data.AccessPortalBoardSectionMode)
                    {
                        case DualSerialChannelMode.Unused:
                            break;
                        case DualSerialChannelMode.Shell:
                            break;
                        case DualSerialChannelMode.ElevatorRelays:
                            break;
                        case DualSerialChannelMode.CypressClockDisplay:
                            break;
                        case DualSerialChannelMode.OutputRelays:
                            break;
                        case DualSerialChannelMode.AllegionPimWiegand:
                            break;
                        case DualSerialChannelMode.AllegionPimAba:
                            break;
                        case DualSerialChannelMode.LCD_4x20Display:
                            break;
                        case DualSerialChannelMode.RS485DoorModule:
                            d.NodeType.Type |= (byte)ReaderPort6xx.ReaderNodeTypeFlags.Dsi485DoorModuleReader;
                            break;
                        case DualSerialChannelMode.AssaAbloyAperio:
                            break;
                        case DualSerialChannelMode.SaltoSallis:
                            break;
                        case DualSerialChannelMode.RS485InputModule:
                            break;
                        case DualSerialChannelMode.VeridtCac:
                            break;
                    }
                    break;
            }

            d.UnlockDurationHundredths = (UInt16)data.Data.UnlockDuration;
            d.RecloseTimeHundredths = (UInt16)data.Data.RecloseDuration;
            d.UnlockDelayHundredths = (UInt16)data.Data.UnlockDelay;

            #region Input Output Group Settings

            if (data.Data.ForcedOpenAlertEventIsActive)
            {
                d.IllegalOpenAssignment.IoGroupNumber = (byte)data.Data.ForcedOpenIOGroupNumber;
                d.IllegalOpenAssignment.Offset = (byte)data.Data.ForcedOpenIOGroupOffset;
            }

            if (data.Data.InvalidAccessAttemptAlertEventIsActive)
            {
                d.InvalidAttemptAssignment.IoGroupNumber = (byte)data.Data.InvalidAccessAttemptIOGroupNumber;
                d.InvalidAttemptAssignment.Offset = (byte)data.Data.InvalidAccessAttemptIOGroupOffset;
            }

            if (data.Data.PassbackViolationAlertEventIsActive)
            {
                d.PassbackViolationAssignment.IoGroupNumber = (byte)data.Data.PassbackViolationIOGroupNumber;
                d.PassbackViolationAssignment.Offset = (byte)data.Data.PassbackViolationIOGroupOffset;
            }

            if (data.Data.OpenTooLongAlertEventIsActive)
            {
                d.OpenTooLongAssignment.IoGroupNumber = (byte)data.Data.OpenTooLongIOGroupNumber;
                d.OpenTooLongAssignment.Offset = (byte)data.Data.OpenTooLongIOGroupOffset;
            }

            if (data.Data.DuressAlertEventIsActive)
            {
                d.DuressAssignment.IoGroupNumber = (byte)data.Data.DuressIOGroupNumber;
                d.DuressAssignment.Offset = (byte)data.Data.DuressIOGroupOffset;
            }

            if (data.Data.DoorGroupAlertEventIsActive)
            {
                d.DoorGroupAssignment.IoGroupNumber = (byte)data.Data.DoorGroupIOGroupNumber;
                d.DoorGroupAssignment.Offset = (byte)data.Data.DoorGroupIOGroupOffset;
            }

            if (data.Data.MissedHeartbeatAlertEventIsActive)
            {
                d.HeartbeatAssignment.IoGroupNumber = (byte)data.Data.MissedHeartbeatIOGroupNumber;
                d.HeartbeatAssignment.Offset = (byte)data.Data.MissedHeartbeatIOGroupOffset;
            }

            if (data.Data.AccessGrantedAlertEventIsActive)
            {
                d.AccessGrantedAssignment.IoGroupNumber = (byte)data.Data.AccessGrantedIOGroupNumber;
                d.AccessGrantedAssignment.Offset = (byte)data.Data.AccessGrantedIOGroupOffset;
            }

            if (data.Data.LockedByAlertEventIsActive)
            {
                d.LockIoGroup = (byte)data.Data.LockedByIOGroupNumber;
            }

            if (data.Data.UnlockedByAlertEventIsActive)
            {
                d.UnlockIoGroup = (byte)data.Data.UnlockedByIOGroupNumber;
            }

            if (d.IoGroupsToDisarmOnValidAccess == null)
                d.IoGroupsToDisarmOnValidAccess = new byte[4];

            if (data.Data.Disarm1AlertEventIsActive)
            {
                d.IoGroupsToDisarmOnValidAccess[0] = (byte)data.Data.DisarmIOGroupNumber1;
            }

            if (data.Data.Disarm2AlertEventIsActive)
            {
                d.IoGroupsToDisarmOnValidAccess[1] = (byte)data.Data.DisarmIOGroupNumber2;
            }

            if (data.Data.Disarm3AlertEventIsActive)
            {
                d.IoGroupsToDisarmOnValidAccess[2] = (byte)data.Data.DisarmIOGroupNumber3;
            }

            if (data.Data.Disarm4AlertEventIsActive)
            {
                d.IoGroupsToDisarmOnValidAccess[3] = (byte)data.Data.DisarmIOGroupNumber4;
            }

            #endregion

            #region Passback Settings

            d.IntoPassbackArea = (byte)data.Data.PassbackIntoAreaNumber;
            d.FromPassbackArea = (byte)data.Data.PassbackFromAreaNumber;
            d.ForgivePassbackAfter = (byte)data.Data.AutoForgivePassbackCode;

            #endregion

            #region Schedule Settings

            d.FreeAccessSchedule = (byte)data.Data.FreeAccessScheduleNumber;
            d.CrisisModeUnlockSchedule = (byte)data.Data.CrisisFreeAccessScheduleNumber;
            d.DisableIllegalOpenSchedule = (byte)data.Data.DisableForcedOpenScheduleNumber;
            d.DisableStillOpenSchedule = (byte)data.Data.DisableOpenTooLongScheduleNumber;
            #endregion

            #region PIN Required Settings
            d.PinRequiredSchedule = (byte)data.Data.PinRequiredScheduleNumber;
            switch ((GalaxySMS.Common.Enums.PinRequiredMode)data.Data.PinRequiredModeCode)
            {
                case PinRequiredMode.RequiredForAccessDecision:
                    break;
                case PinRequiredMode.InformationalOnly:
                    d.Options3 |= (byte)ReaderPort6xx.Options3Flags.PinInformationOnly;
                    break;
                case PinRequiredMode.SpecifiesRecloseTime:
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.PinSpecifiesRecloseTime;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            #endregion

            #region Relay 2 Settings

            d.Relay2Delay = (UInt16)data.Data.Relay2ActivationDelay;
            d.Relay2Schedule = (byte)data.Data.Relay2ScheduleNumber;
            d.Relay2Duration = (UInt16)data.Data.Relay2ActivationDuration;

            if (data.Data.Relay2TriggerAccessGranted.HasValue && data.Data.Relay2TriggerAccessGranted.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.AccessGranted;

            if (data.Data.Relay2TriggerDuress.HasValue && data.Data.Relay2TriggerDuress.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.Duress;

            if (data.Data.Relay2TriggerForcedOpen.HasValue && data.Data.Relay2TriggerForcedOpen.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.IllegalOpen;

            if (data.Data.Relay2TriggerInvalidAttempt.HasValue && data.Data.Relay2TriggerInvalidAttempt.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.InvalidAccessAttempt;

            if (data.Data.Relay2TriggerOpenTooLong.HasValue && data.Data.Relay2TriggerOpenTooLong.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.OpenTooLong;

            if (data.Data.Relay2TriggerPassbackViolation.HasValue && data.Data.Relay2TriggerPassbackViolation.Value)
                d.Relay2Triggers |= (byte)ReaderPort6xx.Relay2TriggerFlags.PassbackViolation;

            switch ((AccessPortalAuxiliaryOutputMode)data.Data.Relay2ModeCode)
            {
                case AccessPortalAuxiliaryOutputMode.Follows:
                    d.Relay2Delay = 0;
                    d.Relay2Duration = 0;
                    d.Relay2Schedule = (byte)TimeScheduleNumbers.TimeScheduleNever;
                    d.Options2 &= (byte)~ReaderPort6xx.Options2Flags.Relay2LatchingMode;
                    d.Relay2Triggers &= (byte)(ReaderPort6xx.Relay2TriggerFlags.IllegalOpen | ReaderPort6xx.Relay2TriggerFlags.OpenTooLong);
                    break;

                case AccessPortalAuxiliaryOutputMode.Timeout:
                    d.Relay2Schedule = (byte)TimeScheduleNumbers.TimeScheduleNever;
                    d.Options2 &= (byte)~ReaderPort6xx.Options2Flags.Relay2LatchingMode;
                    break;

                case AccessPortalAuxiliaryOutputMode.Scheduled:
                    d.Relay2Delay = 0;
                    d.Relay2Duration = 0;
                    d.Relay2Triggers = 0;
                    d.Options2 &= (byte)~ReaderPort6xx.Options2Flags.Relay2LatchingMode;
                    break;

                case AccessPortalAuxiliaryOutputMode.Latching:
                    d.Relay2Delay = 0;
                    d.Relay2Duration = 0;
                    d.Relay2Schedule = (byte)TimeScheduleNumbers.TimeScheduleNever;
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.Relay2LatchingMode;
                    break;
            }

            #endregion

            if (data.Data.DontDecrementLimitedSwipeExpireCount.HasValue && data.Data.DontDecrementLimitedSwipeExpireCount.Value == true)
                d.ForgivePassbackAfter |= (byte)ReaderPort6xx.ForgivePassbackAfterFlags.DontDecrementLimitedSwipeExpireCount;

            #region Options 1 Settings
            if (data.Data.AllowPassbackAccess.HasValue && data.Data.AllowPassbackAccess.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.AllowPassbackAccess;

            if (data.Data.RequireTwoValidCredentials.HasValue && data.Data.RequireTwoValidCredentials.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.RequireTwoValidCredentials;

            if (data.Data.UnlockOnREX.HasValue && data.Data.UnlockOnREX.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.UnlockOnREX;

            if (data.Data.SuppressREXLog.HasValue && data.Data.SuppressREXLog.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.DisableREXMessage;

            if (data.Data.EnableDuress.HasValue && data.Data.EnableDuress.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.DuressEnabled;

            if (data.Data.RelayOneOnDuringArmDelay.HasValue && data.Data.RelayOneOnDuringArmDelay.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.EnergizeRelay1DuringArmDelay;

            if (data.Data.DoorGroupCanDisable.HasValue && data.Data.DoorGroupCanDisable.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.DisableWhenDoorGroupIsActive;

            if (data.Data.DoorGroupNotify.HasValue && data.Data.DoorGroupNotify.Value == true)
                d.Options1 |= (byte)ReaderPort6xx.Options1Flags.ActivateDoorGroupWhenUnsecure;

            #endregion

            #region Options 2 Settings
            if (data.Data.ReaderSendsHeartbeat.HasValue && data.Data.ReaderSendsHeartbeat.Value == true)
                d.Options2 |= (byte)ReaderPort6xx.Options2Flags.ReaderSendsHeartbeats;

            if (data.Data.RequireValidAccessForAutoUnlock.HasValue && data.Data.RequireValidAccessForAutoUnlock.Value == true)
                d.Options2 |= (byte)ReaderPort6xx.Options2Flags.RequireValidAccessForAutoUnlock;

            if (data.Data.ValidAccessRequiresDoorOpen.HasValue && data.Data.ValidAccessRequiresDoorOpen.Value == true)
                d.Options2 |= (byte)ReaderPort6xx.Options2Flags.RequireDoorToOpenForAccessGranted;

            #endregion

            #region Options 3 Settings
            if (data.Data.LockWhenDoorCloses.HasValue && data.Data.LockWhenDoorCloses.Value == true)
                d.Options3 |= (byte)ReaderPort6xx.Options3Flags.DeEnergizeRelay1WhenContactOpens;

            if (data.Data.SuppressClosedLog.HasValue && data.Data.SuppressClosedLog.Value == true)
                d.Options3 |= (byte)ReaderPort6xx.Options3Flags.SuppressDoorClosedLogMessage;

            if (data.Data.SuppressIllegalOpenLog.HasValue && data.Data.SuppressIllegalOpenLog.Value == true)
                d.Options3 |= (byte)ReaderPort6xx.Options3Flags.SuppressIllegalOpenLogMessage;

            if (data.Data.SuppressOpenTooLongLog.HasValue && data.Data.SuppressOpenTooLongLog.Value == true)
                d.Options3 |= (byte)ReaderPort6xx.Options3Flags.SuppressOpenTooLongLogMessage;

            if (data.Data.GenerateDoorContactChangeLogs.HasValue && data.Data.GenerateDoorContactChangeLogs.Value == true)
                d.Options3 |= (byte)ReaderPort6xx.Options3Flags.GenerateDoorContactChangeLogMessages;

            #endregion

            #region Options 4 Settings
            if (data.Data.IgnoreNotInSystem.HasValue && data.Data.IgnoreNotInSystem.Value == true)
                d.Options4 |= (byte)ReaderPort6xx.Options4Flags.IgnoreNotInSystemEvents;
            #endregion

            #region Door Contact Supervision Settings
            switch ((GalaxySMS.Common.Enums.AccessPortalContactSupervisionType)data.Data.ContactSupervisionCode)
            {
                case GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.None:
                    break;
                case GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesInLine:
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.DoorContactHasSeriesResistor;
                    break;
                case GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.ParallelEndOfLine:
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.DoorContactHasParallelResistor;
                    break;
                case GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesAndParallel:
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.DoorContactHasSeriesResistor;
                    d.Options2 |= (byte)ReaderPort6xx.Options2Flags.DoorContactHasParallelResistor;
                    break;
            }
            #endregion

            #region Defer To Server Settings
            switch ((GalaxySMS.Common.Enums.AccessDecisionServerConsultationRule)data.Data.DeferToServerCode)
            {
                case AccessDecisionServerConsultationRule.NeverConsultServer:
                    break;
                case AccessDecisionServerConsultationRule.OnlyWhenValidAccessWouldBeGrantedByPanel:
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.DeferToServerForAccessGranted;
                    break;
                case AccessDecisionServerConsultationRule.OnlyWhenAccessWouldBeDeniedByPanel:
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.DeferToServerForAccessDenied;
                    break;
                case AccessDecisionServerConsultationRule.AlwaysConsultServer:
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.DeferToServerForAccessGranted;
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.DeferToServerForAccessDenied;
                    break;
            }

            switch ((GalaxySMS.Common.Enums.AccessDecisionServerFailsToRespondTimeoutBehavior)data.Data.NoServerReplyCode)
            {
                case AccessDecisionServerFailsToRespondTimeoutBehavior.FollowPanelDecision:
                    break;
                case AccessDecisionServerFailsToRespondTimeoutBehavior.AlwaysDenyAccess:
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.NoServerResponseDenyAccess;
                    break;
                case AccessDecisionServerFailsToRespondTimeoutBehavior.AlwaysGrantAccess:
                    d.UserAuthority |= (byte)ReaderPort6xx.UserAuthorityFlags.NoServerResponseGrantAccess;
                    break;
            }
            #endregion

            d.PrivacyOfficeMultiFactorMode = (byte)data.Data.LockPushButtonCode;
            // if the reader is a Veridt reader, then do this instead of the above
            //d.PrivacyOfficeMultiFactorMode = (byte)data.Data.MultiFactorMode;

            d.LCDBoardNumber = (byte)data.Data.LCDBoardNumber;
            d.LCDSectionNumber = (byte)data.Data.LCDSectionNumber;
            d.LCDSectionNumber = (byte)data.Data.LCDNodeNumber;

            switch ((GalaxySMS.Common.Enums.AccessPortalElevatorControlType)data.Data.ElevatorControlTypeCode)
            {
                case GalaxySMS.Common.Enums.AccessPortalElevatorControlType.None:
                    break;
                case GalaxySMS.Common.Enums.AccessPortalElevatorControlType.GalaxyElevatorControlRelays:
                    d.ElevatorOutputsBoard = (byte)data.Data.ElevatorRelayBoardNumber;
                    d.ElevatorOutputsSection = (byte)data.Data.ElevatorRelaySectionNumber;
                    break;
                case GalaxySMS.Common.Enums.AccessPortalElevatorControlType.OtisCompass:
                    break;
                case GalaxySMS.Common.Enums.AccessPortalElevatorControlType.KoneEli:
                    break;
            }
            //switch()
            //d.LCDOptions = data.Data.

            p.FillData(d);

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);


            // Now send the access group data
            // Start by clearing all of the access groups
            var pClearAllAg = GetNewPacketToSend(data.SendToAddress);
            var dClearAllAg = new AccessGroupClearRange(GalaxySMS.Common.Constants.AccessGroupLimits.None, GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber);
            dClearAllAg.SectionNumber = (byte)data.SendToAddress.SectionNumber;
            pClearAllAg.FillData(dClearAllAg);

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)dClearAllAg.Cmd, new MessageTrackingData(data, data.GetType()), false);

            pClearAllAg.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref pClearAllAg);

            // now send the access groups
            var maxAgByNumber = GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber;
            if (data.Data.AccessGroupData.Any())
                maxAgByNumber = data.Data.AccessGroupData.Max(o => o.AccessGroupNumber);
            //           for (UInt16 x = GalaxySMS.Common.Constants.AccessGroupLimits.LowestDefinableNumber; x < GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber; x += AccessGroupSchedules.NumberOfSchedules)
            for (UInt16 x = GalaxySMS.Common.Constants.AccessGroupLimits.LowestDefinableNumber; x < maxAgByNumber; x += AccessGroupSchedules.NumberOfSchedules)
            {
                var chunk = x / AccessGroupSchedules.NumberOfSchedules;
                //             var groups = data.Data.AccessGroupData.Where(i => i.AccessGroupNumber >= x && i.AccessGroupNumber < x + AccessGroupSchedules.NumberOfSchedules).ToList();
                var groups = data.Data.AccessGroupData.Where(i => i.AccessGroupNumber >= x && i.AccessGroupNumber < x + AccessGroupSchedules.NumberOfSchedules && i.ScheduleNumber > TimeScheduleNumber.TimeSchedule_Never).ToList();
                if (groups != null && groups.Count != 0)
                {
                    var pAg = GetNewPacketToSend(data.SendToAddress);
                    var dAg = new AccessGroupSchedules(x);
                    foreach (var g in groups)
                    {
                        var offset = g.AccessGroupNumber - 1;
                        offset = offset % AccessGroupSchedules.NumberOfSchedules;
                        dAg.ScheduleNumbers[offset] = (byte)g.ScheduleNumber;
                        if (g.AccessGroupNumber != AccessGroupLimits.UnlimitedAccess && (g.IsEnabled.GetValueOrDefault() == false || ((g.ActivationDate > g.CurrentTimeForCluster || g.ExpirationDate < g.CurrentTimeForCluster) && g.ActivationDate != g.ExpirationDate)))
                            dAg.ScheduleNumbers[offset] = (byte)TimeScheduleNumber.TimeSchedule_Never;
                    }
                    dAg.SectionNumber = (byte)data.SendToAddress.SectionNumber;
                    pAg.FillData(dAg);

                    SetExpectedResponseInfo(SpecialOpIdOr | (uint)dAg.Cmd, new MessageTrackingData(data, data.GetType()), false);

                    pAg.PrepareForTransmission(false, true, TimeZoneId);
                    Send(ref pAg);
                }
                else
                {
                    this.Log().Debug($"No access groups between {x} and {x + AccessGroupSchedules.NumberOfSchedules}\n");
                }
            }

            //for (UInt16 x = GalaxySMS.Common.Constants.AccessGroupLimits.LowestDefinableNumber; x < GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber; x += AccessGroupSchedules.NumberOfSchedules)
            //{
            //    var chunk = x / AccessGroupSchedules.NumberOfSchedules;
            //    var groups = data.Data.AccessGroupData.Where(i => i.AccessGroupNumber >= x && i.AccessGroupNumber < x + AccessGroupSchedules.NumberOfSchedules).ToList();
            //    if (groups != null && groups.Count != 0)
            //    {
            //        var pAg = GetNewPacketToSend(data.SendToAddress);
            //        var dAg = new AccessGroupSchedules(x);
            //        foreach (var g in groups)
            //        {
            //            var offset = g.AccessGroupNumber - 1;
            //            offset = offset % AccessGroupSchedules.NumberOfSchedules;
            //            dAg.ScheduleNumbers[offset] = (byte)g.ScheduleNumber;
            //            if (g.AccessGroupNumber != AccessGroupLimits.UnlimitedAccess && g.IsEnabled.GetValueOrDefault() == false || ((g.ActivationDate > g.CurrentTimeForCluster || g.ExpirationDate < g.CurrentTimeForCluster) && g.ActivationDate != g.ExpirationDate))
            //                dAg.ScheduleNumbers[offset] = (byte)TimeScheduleNumber.TimeSchedule_Never;
            //        }
            //        dAg.SectionNumber = (byte)data.SendToAddress.SectionNumber;
            //        pAg.FillData(dAg);

            //        SetExpectedResponseInfo(SpecialOpIdOr | (uint)dAg.Cmd, new MessageTrackingData(data, data.GetType()), false);

            //        pAg.PrepareForTransmission(false, true, TimeZoneId);
            //        Send(ref pAg);
            //    }
            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalCommand(GalaxySMS.Business.Entities.SendDataParameters<AccessPortalCommandAction> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalCommand data cannot be null"));

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}

            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.AccessPortalHardwareInformation.InterfaceBoardTypeCode)
            {
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    data.SendToAddress.NodeNumber = 0;
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress);
            var cmdCode = PacketDataCodeTo6xx.CommandRequestReaderPortStatus;

            switch (data.Data.CommandAction)
            {
                case AccessPortalCommandActionCode.Pulse:
                    cmdCode = PacketDataCodeTo6xx.CommandPulseDoor;
                    break;

                case AccessPortalCommandActionCode.Unlock:
                    cmdCode = PacketDataCodeTo6xx.CommandUnlockDoor;
                    break;

                case AccessPortalCommandActionCode.Lock:
                    cmdCode = PacketDataCodeTo6xx.CommandLockDoor;
                    break;

                case AccessPortalCommandActionCode.Enable:
                    cmdCode = PacketDataCodeTo6xx.CommandEnableDoor;
                    break;

                case AccessPortalCommandActionCode.Disable:
                    cmdCode = PacketDataCodeTo6xx.CommandDisableDoor;
                    break;

                case AccessPortalCommandActionCode.AuxRelayOn:
                    cmdCode = PacketDataCodeTo6xx.CommandRelay2On;
                    break;

                case AccessPortalCommandActionCode.AuxRelayOff:
                    cmdCode = PacketDataCodeTo6xx.CommandRelay2Off;
                    break;

                case AccessPortalCommandActionCode.SetLedTemporaryState:
                    cmdCode = PacketDataCodeTo6xx.CommandSetLedTemporaryState;
                    break;

                case AccessPortalCommandActionCode.None:
                case AccessPortalCommandActionCode.RequestStatus:
                    cmdCode = PacketDataCodeTo6xx.CommandRequestReaderPortStatus;
                    break;
            }

            SendSingleByteCommand(ref p, cmdCode, new MessageTrackingData(data, data.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an input device data. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendInputDeviceData(GalaxySMS.Business.Entities.SendDataParameters<InputDevice_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", "The parameter SendInputDeviceData data cannot be null");

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            KillDataLoadTimer();
            _inputDeviceDataToLoad.Add(data);
            StartDataLoadTimer();
        }


        public void SendOutputDeviceData(GalaxySMS.Business.Entities.SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", "The parameter SendOutputDeviceData data cannot be null");

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            KillDataLoadTimer();
            _outputDeviceDataToLoad.Add(data);
            StartDataLoadTimer();
        }


        public void SendDigitalInputOutputInputDeviceDataImmediate(GalaxySMS.Business.Entities.SendDataParameters<InputDevice_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputDeviceDataImmediate data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.BoardNumber = data.Data.BoardNumber;
            data.SendToAddress.SectionNumber = data.Data.SectionNumber;
            data.SendToAddress.NodeNumber = 0;

            //InitializeBoardSectionSettings initBoardSectionData = null;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.InputDeviceBoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new InputDeviceDigitalIOBoard(null);
            d.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            d.BoardSectionMode = (byte)data.Data.InputDeviceBoardSectionMode;
            d.InputNumber = (byte)data.Data.NodeNumber;

            d.IOGroupAssignment = new IoGroupAssignment();
            if (data.Data.MainIOGroupIsActive)
            {
                d.IOGroupAssignment.IoGroupNumber = (byte)data.Data.MainIOGroupNumber;
                d.IOGroupAssignment.Offset = (byte)data.Data.MainIOGroupOffset;

                if (d.IOGroupAssignment.Offset > (int)GalaxySMS.Common.Constants.InputOutputGroupLimits.None &&
                    data.Data.MainIOGroupOffset > 0)
                    d.IOGroupAssignment.Offset--;
            }

            if (data.Data.DisableDisarmedOnOffLogEvents)
                d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.SuppressDisarmedLogMessages;

            d.DelaySeconds = (ushort)data.Data.DelayDuration;
            if (d.DelaySeconds > 0)
            {
                switch ((GalaxySMS.Common.Enums.GalaxyInputDelayType)data.Data.GalaxyInputDelayTypeCode)
                {
                    case GalaxyInputDelayType.Entry:
                        d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.DelayTypeEntry;
                        break;
                    case GalaxyInputDelayType.Dwell:
                        d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.DelayTypeDwell;
                        break;
                    default:
                        break;
                }
            }

            switch ((GalaxySMS.Common.Enums.GalaxyInputMode)data.Data.GalaxyInputModeCode)
            {
                case GalaxyInputMode.Arming:
                    d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.InputModeArming;
                    d.ArmingSchedule = (byte)data.Data.ArmControlScheduleNumber;
                    d.ArmingIoGroups[0] = (byte)data.Data.ArmingIOGroupNumber1;
                    d.ArmingIoGroups[1] = (byte)data.Data.ArmingIOGroupNumber2;
                    d.ArmingIoGroups[2] = (byte)data.Data.ArmingIOGroupNumber3;
                    d.ArmingIoGroups[3] = (byte)data.Data.ArmingIOGroupNumber4;
                    break;

                case GalaxyInputMode.Standard:
                default:
                    break;
            }

            if (data.Data.IsNormalOpen)
                d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.NormalOpenContact;

            if (data.Data.AlternateVoltagesEnabled == false)
                d.Options1 |= (byte)InputDeviceDigitalIOBoard.Options1Flags.IgnoreAlternatingVoltages;

            d.VoltageThresholdsNormal[0] = (byte)data.Data.TroubleOpenThreshold;
            d.VoltageThresholdsNormal[1] = (byte)data.Data.NormalChangeThreshold;
            d.VoltageThresholdsNormal[2] = (byte)data.Data.TroubleShortThreshold;

            d.VoltageThresholdsAlternate[0] = (byte)data.Data.AlternateTroubleOpenThreshold;
            d.VoltageThresholdsAlternate[1] = (byte)data.Data.AlternateNormalChangeThreshold;
            d.VoltageThresholdsAlternate[2] = (byte)data.Data.AlternateTroubleShortThreshold;


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }


        // Send a full modules worth of data
        public void SendInputModuleDataImmediate(GalaxySMS.Business.Entities.SendDataParameters<InputDevice_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputModuleDataImmediate data cannot be null"));

            // If there aren't any items in the collection, add the single item to the collection.
            // Subsequent code in this method will deal only with the collection.
            if (!data.Collection.Any())
                data.Collection.Add(data.Data);

            if (data.Collection.Any())
            {
                foreach (var input in data.Collection)
                {
                    input.Validate();
                    if (!input.IsValid)
                    {
                        throw new DataValidationException(input.ValidationErrors);
                    }
                }
            }


            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.BoardNumber = data.Data.BoardNumber;
            data.SendToAddress.SectionNumber = data.Data.SectionNumber;
            data.SendToAddress.NodeNumber = data.Data.NodeNumber;

            //InitializeBoardSectionSettings initBoardSectionData = null;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.InputDeviceBoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    break;
                default:
                    break;
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new RS485InputModule(0);
            d.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            if (data.Collection.Count() > 1)
                d.InputNumber = 0;
            else
                d.InputNumber = (byte)data.Data.NodeNumber;    // 0= All inputs, 1-18 = single input
            d.ModuleNumber = (byte)data.Data.ModuleNumber;
            foreach (var i in data.Collection)
            {
                var input = new InputDeviceRS485InputModule(null);
                //input.IOGroupAssignment = new IoGroupAssignment()
                //{
                //    IoGroupNumber = (byte)i.MainIOGroupNumber,
                //    Offset = (byte)i.MainIOGroupOffset
                //};

                //if (input.IOGroupAssignment.Offset > (int)GalaxySMS.Common.Constants.InputOutputGroupLimits.None && data.Data.MainIOGroupOffset > 0)
                //    input.IOGroupAssignment.Offset--;

                input.IOGroupAssignment = new IoGroupAssignment();
                if (data.Data.MainIOGroupIsActive)
                {
                    input.IOGroupAssignment.IoGroupNumber = (byte)data.Data.MainIOGroupNumber;
                    input.IOGroupAssignment.Offset = (byte)data.Data.MainIOGroupOffset;

                    if (input.IOGroupAssignment.Offset > (int)GalaxySMS.Common.Constants.InputOutputGroupLimits.None &&
                        data.Data.MainIOGroupOffset > 0)
                        input.IOGroupAssignment.Offset--;
                }

                if (i.DisableDisarmedOnOffLogEvents)
                    input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.SuppressDisarmedLogMessages;

                input.DelaySeconds = (ushort)i.DelayDuration;
                if (input.DelaySeconds > 0)
                {
                    switch ((GalaxySMS.Common.Enums.GalaxyInputDelayType)i.GalaxyInputDelayTypeCode)
                    {
                        case GalaxyInputDelayType.Entry:
                            input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.DelayTypeEntry;
                            break;
                        case GalaxyInputDelayType.Dwell:
                            input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.DelayTypeDwell;
                            break;
                        default:
                            break;
                    }
                }
                switch ((GalaxySMS.Common.Enums.GalaxyInputMode)i.GalaxyInputModeCode)
                {
                    case GalaxyInputMode.Arming:
                        input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.InputModeArming;
                        input.ArmingSchedule = (byte)i.ArmControlScheduleNumber;
                        input.ArmingIoGroups[0] = (byte)i.ArmingIOGroupNumber1;
                        input.ArmingIoGroups[1] = (byte)i.ArmingIOGroupNumber2;
                        input.ArmingIoGroups[2] = (byte)i.ArmingIOGroupNumber3;
                        input.ArmingIoGroups[3] = (byte)i.ArmingIOGroupNumber4;
                        break;

                    case GalaxyInputMode.Standard:
                    default:
                        break;
                }

                if (i.IsNormalOpen)
                    input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.NormalOpenContact;

                if (i.HasSeriesResistor)
                    input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.SeriesResistor;

                if (i.HasParallelResistor)
                    input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.ParallelResistor;

                if (i.IsNodeActive || i.IsInputActive)
                    input.Options1 |= (byte)InputDeviceRS485InputModule.Options1Flags.InputIsActive;

                d.Inputs[i.NodeNumber - 1] = input;
            }


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);


        }



        public void SendOutputDeviceDataImmediate(GalaxySMS.Business.Entities.SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendOutputDeviceDataImmediate data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.BoardNumber = data.Data.BoardNumber;
            data.SendToAddress.SectionNumber = data.Data.SectionNumber;
            data.SendToAddress.NodeNumber = 0;

            //InitializeBoardSectionSettings initBoardSectionData = null;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.OutputDeviceBoardTypeTypeCode)
            {
                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    break;

                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new OutputDeviceData(null);
            d.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            d.BoardSectionMode = (byte)data.Data.OutputDeviceBoardSectionMode;
            d.OutputNumber = (byte)data.Data.NodeNumber;
            d.Schedule = (byte)data.Data.ScheduleNumber;
            d.Mode = (byte)data.Data.GalaxyOutputModeCode;
            if (data.Data.InvertOutput)
                d.Mode |= (byte)OutputDeviceData.ModeFlags.InvertOutput;
            if (data.Data.InputSourceRelationshipCode == (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.AND)
                d.Mode |= (byte)OutputDeviceData.ModeFlags.ANDMode;

            switch ((GalaxySMS.Common.Enums.GalaxyOutputMode)data.Data.GalaxyOutputModeCode)
            {
                case GalaxyOutputMode.TimeoutRetriggerable:
                case GalaxyOutputMode.Timeout:
                    d.DurationLimitCount = (ushort)data.Data.TimeoutDuration;
                    break;

                case GalaxyOutputMode.Limit:
                case GalaxyOutputMode.Counter:
                    d.DurationLimitCount = (ushort)data.Data.Limit;
                    break;
                case GalaxyOutputMode.None:
                case GalaxyOutputMode.Follows:
                case GalaxyOutputMode.Latching:
                case GalaxyOutputMode.Scheduled:
                    break;
                default:
                    break;
            }

            if ((GalaxySMS.Common.Enums.GalaxyOutputMode)data.Data.GalaxyOutputModeCode != GalaxyOutputMode.Scheduled)
            {
                foreach (var s in data.Data.InputSources)
                {
                    d.IoGroups[s.SourceNumber - 1] = (byte)s.IOGroupNumber;
                    d.TriggerConditions[s.SourceNumber - 1] = (byte)s.TriggerConditionCode;
                    if (s.InputOutputGroupMode)
                        d.TriggerConditions[s.SourceNumber - 1] |= (byte)OutputDeviceData.TriggerFlags.IOGroupMode;
                    switch ((GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode)s.SourceModeCode)
                    {
                        case GalaxyOutputInputSourceMode.OR:
                            break;
                        case GalaxyOutputInputSourceMode.AND:
                            d.TriggerConditions[s.SourceNumber - 1] |= (byte)OutputDeviceData.TriggerFlags.ANDMode;
                            break;
                        case GalaxyOutputInputSourceMode.NOR:
                            d.TriggerConditions[s.SourceNumber - 1] |= (byte)OutputDeviceData.TriggerFlags.InvertInputs;
                            break;
                        case GalaxyOutputInputSourceMode.NAND:
                            d.TriggerConditions[s.SourceNumber - 1] |= (byte)OutputDeviceData.TriggerFlags.ANDMode;
                            d.TriggerConditions[s.SourceNumber - 1] |= (byte)OutputDeviceData.TriggerFlags.InvertInputs;
                            break;
                        default:
                            break;
                    }

                    if (s.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
                    {
                        if (s.InputOutputGroupMode)
                        {
                            foreach (var iog in s.InputOutputGroups)
                            {
                                if (iog.IOGroupNumber >= s.IOGroupNumber && (iog.IOGroupNumber - s.IOGroupNumber < GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.Maximum))
                                {
                                    UInt32 mask = 0x80000000;
                                    mask >>= (iog.IOGroupNumber - s.IOGroupNumber);
                                    d.Offsets[s.SourceNumber - 1] |= mask;
                                }
                            }
                        }
                        else
                        {
                            foreach (var ass in s.Assignments.Where(o => o.OffsetIndex >= GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.Minimum && o.OffsetIndex <= GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.Maximum))
                            {
                                UInt32 mask = 0x80000000;
                                mask >>= ass.OffsetIndex - 1;
                                d.Offsets[s.SourceNumber - 1] |= mask;//ByteFlipper.ReverseBytes(mask);
                                //d.Offsets[s.SourceNumber-1] |= 0xFFFFFFFF;
                            }
                        }
                    }
                }
            }


            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an input device command. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendInputDeviceCommand(GalaxySMS.Business.Entities.SendDataParameters<InputDeviceCommandAction> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputDeviceCommand data cannot be null"));

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}

            var d = new InputDeviceCommand
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandRequestInputStatus,
                InputNumber = (byte)data.SendToAddress.NodeNumber,
            };

            var useModuleNumberAsSubSection = false;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.InputDeviceHardwareInformation.InterfaceBoardTypeCode)
            {
                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    data.SendToAddress.ModuleNumber = 0;
                    data.SendToAddress.NodeNumber = 0;
                    break;
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    //                    data.SendToAddress.NodeNumber = data.SendToAddress.ModuleNumber;
                    useModuleNumberAsSubSection = true;
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress, useModuleNumberAsSubSection);

            switch (data.Data.CommandAction)
            {
                case InputDeviceCommandActionCode.Shunt:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandShuntInput;
                    break;

                case InputDeviceCommandActionCode.Unshunt:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandUnshuntInput;
                    break;

                case InputDeviceCommandActionCode.Enable:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandEnableInput;
                    break;

                case InputDeviceCommandActionCode.Disable:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandDisableInput;
                    break;

                case InputDeviceCommandActionCode.ReadVoltages:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandReadInputVoltages;
                    break;

                case InputDeviceCommandActionCode.None:
                case InputDeviceCommandActionCode.RequestStatus:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandRequestInputStatus;
                    break;
            }

            p.FillData(d);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an output device command. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendOutputDeviceCommand(GalaxySMS.Business.Entities.SendDataParameters<OutputDeviceCommandAction> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendOutputDeviceCommand data cannot be null"));

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}

            var d = new OutputDeviceCommand
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandRequestInputStatus,
                OutputNumber = (byte)data.SendToAddress.NodeNumber,
            };

            var useModuleNumberAsSubSection = false;
            switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)data.Data.OutputDeviceHardwareInformation.InterfaceBoardTypeCode)
            {
                case GalaxyInterfaceBoardType.DigitalInputOutputBoard600:
                    data.SendToAddress.ModuleNumber = 0;
                    data.SendToAddress.NodeNumber = 0;
                    break;
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                    //                    data.SendToAddress.NodeNumber = data.SendToAddress.ModuleNumber;
                    data.SendToAddress.ModuleNumber = 0;
                    data.SendToAddress.NodeNumber = 0;
                    ///                    useModuleNumberAsSubSection = false;
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress, useModuleNumberAsSubSection);

            switch (data.Data.CommandAction)
            {
                case OutputDeviceCommandActionCode.Off:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandOutputOff;
                    break;

                case OutputDeviceCommandActionCode.On:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandOutputOn;
                    break;

                case OutputDeviceCommandActionCode.Enable:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandOutputEnable;
                    break;

                case OutputDeviceCommandActionCode.Disable:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandOutputDisable;
                    break;

                case OutputDeviceCommandActionCode.None:
                case OutputDeviceCommandActionCode.RequestStatus:
                    d.Cmd = (byte)PacketDataCodeTo6xx.CommandRequestOutputStatus;
                    break;
            }

            p.FillData(d);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }


        public void SendInterfaceBoardSectionCommand(GalaxySMS.Business.Entities.SendDataParameters<GalaxyInterfaceBoardSectionCommandAction> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInterfaceBoardSectionCommand data cannot be null"));

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}

            switch ((GalaxySMS.Common.Enums.DualSerialChannelMode)data.Data.InterfaceBoardSectionHardwareInformation.BoardSectionMode)
            {
                case DualSerialChannelMode.RS485DoorModule:
                case DualSerialChannelMode.RS485InputModule:
                    data.SendToAddress.NodeNumber = 0;
                    break;

                default:
                    break;
            }
            var p = GetNewPacketToSend(data.SendToAddress);
            var cmdCode = PacketDataCodeTo6xx.CommandRequestSerialChannelRS485DeviceInfo;
            var expectedResponseCode = PacketDataCodeFrom6xx.ResponseSerialChannelRS485DeviceInfo;
            switch (data.Data.CommandAction)
            {
                case GalaxyInterfaceBoardSectionCommandActionCode.RequestSerialChannelRS485DeviceInfo:
                    cmdCode = PacketDataCodeTo6xx.CommandRequestSerialChannelRS485DeviceInfo;
                    expectedResponseCode = PacketDataCodeFrom6xx.ResponseSerialChannelRS485DeviceInfo;
                    SetSessionIdForResponseCode(data.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeFrom6xx.ResponseSerialChannelRS485DeviceInfo);
                    break;

                default:
                    break;

            }

            SendSingleByteCommand(ref p, cmdCode, null);//new MessageTrackingData(data, data.GetType()));
        }

        public void SendInputOutputGroupCommand(GalaxySMS.Business.Entities.SendDataParameters<InputOutputGroupCommandAction> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputOutputGroupCommand data cannot be null"));
            if (data.Data.InputOutputGroupNumber < GalaxySMS.Common.Constants.InputOutputGroupLimits.LowestDefinableNumber ||
                data.Data.InputOutputGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.HighestNumber)
                throw new ArgumentOutOfRangeException("InputOutputGroupNumber", data.Data.InputOutputGroupNumber, $"The valid range is {GalaxySMS.Common.Constants.InputOutputGroupLimits.LowestDefinableNumber} to {GalaxySMS.Common.Constants.InputOutputGroupLimits.HighestNumber}");

            IDataPacket6xx p = GetNewPacketToSend();
            var c = new GCS.PanelProtocols.Series6xx.Messages.InputOutputGroupCommand();
            c.GroupNumber = data.Data.InputOutputGroupNumber;

            switch (data.Data.CommandAction)
            {
                case InputOutputGroupCommandActionCode.Arm:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandArmIOGroup;
                    break;
                case InputOutputGroupCommandActionCode.Disarm:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandDisarmIOGroup;
                    break;
                case InputOutputGroupCommandActionCode.Shunt:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandShuntIOGroup;
                    break;
                case InputOutputGroupCommandActionCode.Unshunt:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandUnshuntIOGroup;
                    break;
                case InputOutputGroupCommandActionCode.UnlockAccessPortals:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandUnlockDoorGroup;
                    break;
                case InputOutputGroupCommandActionCode.LockAccessPortals:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandLockDoorGroup;
                    break;
                case InputOutputGroupCommandActionCode.EnableAccessPortals:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandEnableDoorGroup;
                    break;
                case InputOutputGroupCommandActionCode.DisableAccessPortals:
                    c.Cmd = (Byte)PacketDataCodeTo6xx.CommandDisableDoorGroup;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access group data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public void SendAccessGroupData(GalaxySMS.Business.Entities.SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessGroupData data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            _accessGroupDataToLoad.Add(data);
            StartDataLoadTimer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access group data immediate. </summary>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendAccessGroupDataImmediate(GalaxySMS.Business.Entities.SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            if (data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessGroupData data cannot be null"));

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }

            var p = GetNewPacketToSend(data.SendToAddress);
            var d = new SetAccessGroupCrisisGroup
            {
                Cmd = (byte)PacketDataCodeTo6xx.LoadAccessGroupCrisisGroup,
                AccessGroupNumber = (ushort)data.Data.AccessGroupNumber,
                CrisisGroupNumber = (ushort)data.Data.CrisisModeAccessGroupNumber,
            };

            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);

            // Now get the data for any access portal on this panel
            var accessPortalData = data.Data.AccessGroupData.Where(
                i => i.ClusterGroupId == this.ClusterGroupId &&
                i.ClusterNumber == this.ClusterId &&
                i.PanelNumber == this.PanelId).ToList();

            if (data.Data.IsEnabled.GetValueOrDefault() == false || ((data.Data.ActivationDate > data.Data.CurrentTimeForCluster || data.Data.ExpirationDate < data.Data.CurrentTimeForCluster) && data.Data.ActivationDate != data.Data.ExpirationDate))
                data.Data.IsEnabled = false;

            foreach (var ap in accessPortalData)
            {
                data.SendToAddress.BoardNumber = ap.BoardNumber;
                data.SendToAddress.SectionNumber = ap.SectionNumber;
                switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)ap.AccessPortalBoardTypeTypeCode)
                {
                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                    case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        break;

                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                    case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                        data.SendToAddress.NodeNumber = ap.NodeNumber;
                        break;

                    default:
                        break;
                }

                var pAg = GetNewPacketToSend(data.SendToAddress);
                var dAg = new AccessGroupSchedule(null);
                dAg.AccessGroupNumber = (ushort)data.Data.AccessGroupNumber;
                if (dAg.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None)
                    dAg.ScheduleNumber = (byte)GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never;
                else if (dAg.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                    dAg.ScheduleNumber = (byte)GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always;
                else
                {
                    if (data.Data.IsEnabled == false)
                        dAg.ScheduleNumber = (byte)TimeScheduleNumbers.TimeScheduleNever;
                    else
                    {
                        dAg.ScheduleNumber = (byte)ap.ScheduleNumber;
                    }
                }

                pAg.FillData(dAg);
                SetExpectedResponseInfo(SpecialOpIdOr | (uint)dAg.Cmd, new MessageTrackingData(data, data.GetType()), false);
                pAg.PrepareForTransmission(false, true, TimeZoneId);
                Send(ref pAg);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a day type data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="data">             The data. </param>
        /// <param name="forMonth">         for month. </param>
        /// <param name="defaultBehavior">  The default behavior. </param>
        /// <param name="parameters">       The SendDataParameters</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDayTypeData(IEnumerable<DateType_PanelLoadData> data, int forMonth,
            DateTypeDefaultBehavior_PanelLoadData defaultBehavior, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDayTypeData data cannot be null"));

            var first = data.FirstOrDefault();
            if (first == null)
                return;
            // Get all the dates from today though the next year. Ignore any dates that have already passed and any dates that are more than one year into the future
            var datesToLoad = data.Where(d => d.Date_x >= DateTime.Today && d.Date_x <= DateTime.Today.AddYears(1)).OrderBy(d => d.Date_x).ToList();
            var startingDate = DateTime.Today.StartOfMonth();
            var scheduleType = (TimeScheduleType)first.ScheduleTypeCode;

            if (scheduleType == TimeScheduleType.GalaxyFifteenMinuteInterval)
            {
                if (forMonth == 0)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        var datesForMonth = datesToLoad.Where(d1 => d1.Date_x >= startingDate && d1.Date_x <= startingDate.EndOfMonth()).ToList();
                        var p = GetNewPacketToSend();
                        var d = new FifteenMinuteScheduleMonthHolidayTypes((byte)(startingDate.Month - 1));
                        foreach (var date in datesForMonth)
                        {
                            d.DayTypes[date.Date_x.Day - 1] = (byte)date.PanelDayTypeNumber;
                        }

                        p.FillData(d);
                        SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
                        p.PrepareForTransmission(false, true, TimeZoneId);
                        Send(ref p);
                        startingDate = startingDate.AddMonths(1);
                    }
                }
                else
                {
                    var datesForMonth = datesToLoad.Where(d1 => d1.Date_x.Month == forMonth).ToList();
                    var p = GetNewPacketToSend();
                    var d = new FifteenMinuteScheduleMonthHolidayTypes((byte)(forMonth - 1));
                    foreach (var date in datesForMonth)
                    {
                        d.DayTypes[date.Date_x.Day - 1] = (byte)date.PanelDayTypeNumber;
                    }

                    p.FillData(d);
                    SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
                    p.PrepareForTransmission(false, true, TimeZoneId);
                    Send(ref p);
                }
            }
            else if (scheduleType == TimeScheduleType.GalaxyOneMinuteInterval)
            {
                var p = GetNewPacketToSend();
                var d = new MinuteScheduleDayTypes(0);

                foreach (var date in datesToLoad)
                {
                    //d.DayTypes[date.Date_x.Month - 1, date.Date_x.Day - 1] = (byte)date.PanelDayTypeNumber;
                    d.DayTypes[date.Date_x.Month - 1, date.Date_x.Day] = (byte)date.PanelDayTypeNumber;
                }

                var datesForTheNextYear = DateTimeOffset.Now.GetAllDatesForRange(DateTimeOffset.Now.AddYears(1));
                foreach (var date in datesForTheNextYear)
                {
                    //if (d.DayTypes[date.Month - 1, date.Day - 1] == Byte.MaxValue)
                    //{   // if not defined
                    //    switch (date.DayOfWeek)
                    //    {
                    //        case DayOfWeek.Sunday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.SundayDayCode;
                    //            break;
                    //        case DayOfWeek.Monday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.MondayDayCode;
                    //            break;
                    //        case DayOfWeek.Tuesday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.TuesdayDayCode;
                    //            break;
                    //        case DayOfWeek.Wednesday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.WednesdayDayCode;
                    //            break;
                    //        case DayOfWeek.Thursday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.ThursdayDayCode;
                    //            break;
                    //        case DayOfWeek.Friday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.FridayDayCode;
                    //            break;
                    //        case DayOfWeek.Saturday:
                    //            d.DayTypes[date.Month - 1, date.Day - 1] = (byte)defaultBehavior.SaturdayDayCode;
                    //            break;
                    //    }
                    //}
                    if (d.DayTypes[date.Month - 1, date.Day] == Byte.MaxValue)
                    {   // if not defined
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.SundayDayCode;
                                break;
                            case DayOfWeek.Monday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.MondayDayCode;
                                break;
                            case DayOfWeek.Tuesday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.TuesdayDayCode;
                                break;
                            case DayOfWeek.Wednesday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.WednesdayDayCode;
                                break;
                            case DayOfWeek.Thursday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.ThursdayDayCode;
                                break;
                            case DayOfWeek.Friday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.FridayDayCode;
                                break;
                            case DayOfWeek.Saturday:
                                d.DayTypes[date.Month - 1, date.Day] = (byte)defaultBehavior.SaturdayDayCode;
                                break;
                        }
                    }
                }

                // now fill in the un-specified dates as the appropriate default
                // 
                p.FillData(d);

                SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);

                p.PrepareForTransmission(false, true, TimeZoneId);
                Send(ref p);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule fifteen minute format data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeScheduleFifteenMinuteFormatData(
            IEnumerable<TimeSchedule15MinuteFormat_GetPanelLoadData> data, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendTimeScheduleFifteenMinuteFormatData data cannot be null"));

            if (!data.Any())
                return;

            var first = data.FirstOrDefault();
            if (first == null)
                return;
            // Get all the dates from today though the next year. Ignore any dates that have already passed and any dates that are more than one year into the future

            if (first.ScheduleTypeCode != TimeScheduleType.GalaxyFifteenMinuteInterval)
                return;

            var dayTypeData = data.GroupBy(x => x.DayTypeCode).ToList();
            var pWeekDays = GetNewPacketToSend();
            var pHolidays = GetNewPacketToSend();
            var dWeekDays = new FifteenMinuteScheduleData((byte)first.PanelScheduleNumber);
            var dHolidays = new FifteenMinuteScheduleHolidayData((byte)first.PanelScheduleNumber);
            foreach (var dtd in dayTypeData)
            {
                foreach (var timeInterval in dtd.ToList())
                {
                    switch (timeInterval.DayTypeCode)
                    {
                        case DayTypeCode.DayType1:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dWeekDays.HolidayType1, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType2:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType2, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType3:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType3, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType4:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType4, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType5:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType5, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType6:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType6, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType7:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType7, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType8:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType8, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.DayType9:
                            if (timeInterval.FifteenMinuteFormatUsesHolidays == true)
                            {
                                SetFifteenMinuteFormatTimeBits(ref dHolidays.HolidayType9, timeInterval.StartTime, timeInterval.EndTime);
                            }
                            break;
                        case DayTypeCode.Sunday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Sunday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Monday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Monday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Tuesday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Tuesday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Wednesday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Wednesday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Thursday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Thursday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Friday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Friday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        case DayTypeCode.Saturday:
                            SetFifteenMinuteFormatTimeBits(ref dWeekDays.Saturday, timeInterval.StartTime, timeInterval.EndTime);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            pWeekDays.FillData(dWeekDays);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)dWeekDays.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
            pWeekDays.PrepareForTransmission(false, true, TimeZoneId);

            pHolidays.FillData(dHolidays);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)dHolidays.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
            pHolidays.PrepareForTransmission(false, true, TimeZoneId);

            Send(ref pWeekDays);
            Send(ref pHolidays);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets fifteen minute format time bits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bits">         [in,out] The bits. </param>
        /// <param name="startTime">    The start time. </param>
        /// <param name="endTime">      The end time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetFifteenMinuteFormatTimeBits(ref byte[] bits, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                if (bits.Length != FifteenMinuteScheduleData.DailyScheduleLength)
                    return;
                switch (startTime.Minutes)
                {
                    case 0:
                    case 15:
                    case 30:
                    case 45:
                        break;

                    default:
                        return;
                }

                switch (endTime.Minutes)
                {
                    case 0:
                    case 15:
                    case 30:
                    case 45:
                    case 59:
                        break;

                    default:
                        return;
                }

                if (endTime <= startTime)
                    return;
                var byteStartIndex = startTime.Hours / 2;    // calculate the offset into the bits array where the start hour 
                var bitIndex = startTime.Minutes / 15;      // figure out which bit in the nibble represents the start minute
                if (startTime.Hours % 2 != 0)               // if the our is odd, then push the starting bit to the next nibble
                    bitIndex += 4;

                var byteEndIndex = endTime.Hours / 2;    // calculate the offset into the bits array where the end hour time 
                var duration = endTime - startTime;
                var numberOfBitsToSet = duration.TotalMinutes / 15;

                byte bitToSet = 0x80;
                // Set the bitToSet correctly to get started
                for (int x = 0; x < bitIndex; x++)
                    bitToSet /= 2;

                for (var x = 0; x < numberOfBitsToSet; x++)
                {
                    bits[byteStartIndex] |= bitToSet;
                    bitToSet /= 2;
                    if (bitToSet == 0)
                    {
                        bitToSet = 0x80;
                        byteStartIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().Info("Connection6xx::SetFifteenMinuteFormatTimeBits", e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an one minute time period data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendOneMinuteTimePeriodData(List<GalaxyTimePeriod_GetPanelLoadData> data, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendOneMinuteTimePeriodData data cannot be null"));

            if (!data.Any())
                return;

            var first = data.FirstOrDefault();
            if (first == null)
                return;

            if (first.ScheduleTypeCode != TimeScheduleType.GalaxyOneMinuteInterval)
                return;

            var p = GetNewPacketToSend();
            var d = new MinuteScheduleTimePeriodData((byte)first.PanelTimePeriodNumber);
            foreach (var ti in data)
            {
                SetMinuteFormatTimeBits(ref d.MinuteBits, ti.StartTime, ti.EndTime);
            }
            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);

            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets minute format time bits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bits">         [in,out] The bits. </param>
        /// <param name="startTime">    The start time. </param>
        /// <param name="endTime">      The end time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetMinuteFormatTimeBits(ref byte[] bits, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                if (bits.Length != MinuteScheduleTimePeriodData.NumberOfMinuteBytes)
                    return;

                if (endTime <= startTime)
                    return;

                var byteStartIndex = startTime.TotalMinutes / 8;    // calculate the offset into the bits array where the start hour 
                var bitIndex = startTime.TotalMinutes % 8;      // figure out which bit in the nibble represents the start minute
                var duration = endTime - startTime;
                var numberOfBitsToSet = duration.TotalMinutes;

                byte bitToSet = 0x80;
                // Set the bitToSet correctly to get started
                for (int x = 0; x < bitIndex; x++)
                    bitToSet /= 2;

                for (var x = 0; x < numberOfBitsToSet; x++)
                {
                    bits[(int)byteStartIndex] |= bitToSet;
                    bitToSet /= 2;
                    if (bitToSet == 0)
                    {
                        bitToSet = 0x80;
                        byteStartIndex++;
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().Info("Connection6xx::SetMinuteFormatTimeBits", e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule one minute format data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeScheduleOneMinuteFormatData(IEnumerable<TimeScheduleOneMinuteFormat_GetPanelLoadData> data, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendTimeScheduleOneMinuteFormatData data cannot be null"));

            if (!data.Any())
                return;

            var first = data.FirstOrDefault();

            if (first?.ScheduleTypeCode != TimeScheduleType.GalaxyOneMinuteInterval)
                return;

            var p = GetNewPacketToSend();
            var d = new MinuteScheduleDayTypeData((byte)first.PanelScheduleNumber);
            foreach (var i in data)
            {
                var dayTypeIndex = (int)i.DayTypeCode;
                if (dayTypeIndex < d.DayTypeTimePeriods.Length)
                    d.DayTypeTimePeriods[(int)i.DayTypeCode] = (byte)i.PanelTimePeriodNumber;
                else
                    Trace.WriteLine(string.Format("SendTimeScheduleOneMinuteFormatData incurred and invalid dayTypeIndex:{0}, {1}", dayTypeIndex, i.DayTypeCode));


            }
            p.FillData(d);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(parameters, parameters.GetType()), false);
            p.PrepareForTransmission(false, true, TimeZoneId);

            Send(ref p);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a credential data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SendCredentialData(SendDataParameters<List<Credential_PanelLoadData>> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

            if (!data.Data.Any())
                return;

            if (_credentialDataToSendParams == null || !_credentialDataToSendParams.Data.Any())
            {
                _credentialDataToSendParams = data;
            }
            else
            {
                this.Log().Debug($"SendCredentialData queueing data, Panel:Cpu - {this.PanelId}:{this.CpuId}, Count:{data.Data.Count}");
                _credentialDataToSendQueue.Add(data);
            }
            StartDataLoadTimer();
        }


        class ActivationAndExpirationResults
        {
            public bool IsActive { get; set; }
            public uint DaysTillActive { get; set; }
            public uint ExpireCount { get; set; }
        }

        private ActivationAndExpirationResults DetermineActivationAndExpiration(Credential_PanelLoadData data)
        {
            var result = new ActivationAndExpirationResults();

            var nowInTz = DateTimeOffset.Now.GetCurrentTimeForTimeZoneId(TimeZoneId);

            // Determine if card is active based on various Active/disabled flags as well as active and expiration settings
            result.IsActive = data.PersonAccessControlPropertiesIsActive &&
                                    data.PersonInactiveState == false &&
                                    data.PersonCredentialIsActive;

            if (result.IsActive)
            {
                // Check the person level activation date
                if (data.PersonActivationDateTime.IsValueNotEquivalentToSqlNull() &&
                    data.PersonActivationDateTime > nowInTz)
                {
                    result.IsActive = false;
                }
            }

            if (result.IsActive)
            {
                // Check the person level expiration date
                if (data.PersonExpirationDateTime.IsValueNotEquivalentToSqlNull() &&
                    data.PersonExpirationDateTime <= nowInTz)
                {
                    result.IsActive = false;
                }
            }

            if (result.IsActive)
            {
                // Check the person level termination date
                if (data.PersonTerminationDate.IsValueNotEquivalentToSqlNull() &&
                    data.PersonTerminationDate <= nowInTz)
                {
                    result.IsActive = false;
                }
            }


            if (result.IsActive)
            {
                // Check the person level employment date
                if (data.PersonEmploymentDate.IsValueNotEquivalentToSqlNull() &&
                    data.PersonEmploymentDate > nowInTz)
                {
                    result.IsActive = false;
                }
            }

            // If the previous flags indicate that the card is active, then validate the activation and expiration settings
            if (result.IsActive)
            {
                switch (data.CredentialActivationModeCode)
                {
                    case PersonActivationModes.ImmediatelyActive:
                        break;
                    case PersonActivationModes.ActivateByDate:
                        if (data.CredentialExpirationModeCode == PersonExpirationModes.ExpireByDate ||
                            data.CredentialExpirationModeCode == PersonExpirationModes.ExpireByDateAndTime ||
                            data.CredentialExpirationModeCode == PersonExpirationModes.ExpireByDateAndTimeAndUsageCount)
                        {   // validate that the expiration date is after the activation date
                            if (data.CredentialExpirationDateTime <= data.CredentialActivationDateTime)
                                result.IsActive = false;
                            if (data.CredentialExpirationModeCode == PersonExpirationModes.ExpireByDateAndTimeAndUsageCount && data.CredentialUsageCount == 0)
                                result.IsActive = false;

                        }
                        if (result.IsActive == true)
                        {
                            // If the activation date is sometime in the future, mark as inactive
                            if (data.CredentialActivationDateTime.IsValueNotEquivalentToSqlNull())
                            {
                                if (data.CredentialActivationDateTime.Value.Date.DateOnly() > nowInTz.Date.DateOnly())
                                    result.IsActive = false;
                                // If the activation date is within the next 31 days, calculate the # of days till activation and let the panel handle it
                                if (data.CredentialActivationDateTime.Value.Date.DateOnly() <=
                                    nowInTz.Date.DateOnly().AddDays(31))
                                {
                                    result.DaysTillActive = (uint)(data.CredentialActivationDateTime.Value.Date.DateOnly() -
                                                                    nowInTz.Date.DateOnly()).TotalDays;
                                }
                            }
                        }
                        break;
                }
            }

            // If the previous checks indicate that the card is active, then validate the expiration settings
            //if (result.IsActive)
            //{
            switch (data.CredentialExpirationModeCode)
            {
                case PersonExpirationModes.ExpireByDate:
                    // if the expiration date has already passed
                    if (data.CredentialActivationDateTime.IsValueNotEquivalentToSqlNull())
                    {
                        if (data.CredentialExpirationDateTime.Value.Date.EndOfDay() <= nowInTz)
                        {
                            result.IsActive = false;
                        }
                        else
                        {
                            result.ExpireCount =
                                (uint)(data.CredentialExpirationDateTime.Value.Date.EndOfDay() - nowInTz.Date.EndOfDay())
                                .TotalDays + 1;
                            if (result.DaysTillActive > 0 && result.ExpireCount > result.DaysTillActive)
                                result.ExpireCount -= result.DaysTillActive;
                            if (result.ExpireCount > byte.MaxValue)
                                result.ExpireCount = 0;
                        }
                    }

                    break;

                case PersonExpirationModes.ExpireByDateAndTime:
                    // if the expiration date/time has already passed
                    if (data.CredentialActivationDateTime.IsValueNotEquivalentToSqlNull())
                    {
                        if (data.CredentialExpirationDateTime.Value <= nowInTz)
                        {
                            result.IsActive = false;
                        }
                        else
                        {
                            result.ExpireCount =
                                (uint)(data.CredentialExpirationDateTime.Value.Date.EndOfDay() - nowInTz.Date.EndOfDay())
                                .TotalDays + 1;
                            if (result.DaysTillActive > 0 && result.ExpireCount > result.DaysTillActive)
                                result.ExpireCount -= result.DaysTillActive;
                            if (result.ExpireCount > byte.MaxValue)
                                result.ExpireCount = 0;
                        }
                    }

                    break;

                case PersonExpirationModes.ExpireByUsageCount:
                    result.ExpireCount = (uint)data.CredentialUsageCount;
                    break;

                case PersonExpirationModes.ExpireByDateAndTimeAndUsageCount:
                    if (data.CredentialActivationDateTime.IsValueNotEquivalentToSqlNull())
                    {
                        if (data.CredentialExpirationDateTime.Value <= nowInTz || data.CredentialUsageCount == 0)
                        {
                            result.IsActive = false;
                        }
                        else
                        {
                            result.ExpireCount =
                                (uint)(data.CredentialExpirationDateTime.Value.Date.EndOfDay() - nowInTz.Date.EndOfDay())
                                .TotalDays + 1;
                            if (result.DaysTillActive > 0 && result.ExpireCount > result.DaysTillActive)
                                result.ExpireCount -= result.DaysTillActive;
                            if (result.ExpireCount > byte.MaxValue)
                                result.ExpireCount = 0;
                        }
                    }

                    break;
                case PersonExpirationModes.NeverExpires:
                default:
                    break;
            }

            //}
            return result;
        }

        //public void SendCredentialDataImmediate(IEnumerable<Credential_PanelLoadData> data)
        //{
        //    if (data == null)
        //        throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

        //    if (!data.Any())
        //        return;

        //    var first = data.FirstOrDefault();
        //    var p = GetNewPacketToSend();
        //    ushort index = 0;
        //    switch (first.CredentialDataLength)
        //    {
        //        case GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Standard48Bit:
        //            var d48 = new CredentialData48Bit(0);
        //            foreach (var i in data)
        //            {
        //                if (index == CredentialData48Bit.NumberOfCredentials)
        //                    break;

        //                var activeExpireResults = DetermineActivationAndExpiration(i);
        //                //var isActive = true;

        //                switch (i.CredentialRoleCode)
        //                {
        //                    case PersonCredentialRoles.AccessControl:
        //                        d48.CredentialData[index].AccessControlCredential = new AccessControlCredentialData48Bit(i.CredentialBits);
        //                        d48.CredentialData[index].AccessControlCredential.AccessGroup1 = (byte)i.AccessGroup1;
        //                        d48.CredentialData[index].AccessControlCredential.AccessGroup2 = (byte)i.AccessGroup2;
        //                        d48.CredentialData[index].AccessControlCredential.AccessGroup3 = (ushort)i.AccessGroup3;
        //                        if (i.AccessGroup4 == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
        //                            d48.CredentialData[index].AccessControlCredential.AccessGroup4 = (ushort)(i.AccessGroup4 + i.PersonalAccessGroupNumber - 1);
        //                        else
        //                            d48.CredentialData[index].AccessControlCredential.AccessGroup4 = (ushort)i.AccessGroup4;
        //                        if (i.PIN <= 0 || i.PIN > 0xffff)
        //                            i.PIN = 0xffff;
        //                        d48.CredentialData[index].AccessControlCredential.PIN = (ushort)i.PIN;

        //                        if (activeExpireResults.DaysTillActive != 0)
        //                        {
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex10) != 0)
        //                            {
        //                                d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex10;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex08) != 0)
        //                            {
        //                                d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex08;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex04) != 0)
        //                            {
        //                                d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex04;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex02) != 0)
        //                            {
        //                                d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex02;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex01) != 0)
        //                            {
        //                                d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex01;
        //                            }
        //                        }

        //                        switch (i.CredentialExpirationModeCode)
        //                        {
        //                            case PersonExpirationModes.NeverExpires:
        //                                break;
        //                            case PersonExpirationModes.ExpireByDate:
        //                            case PersonExpirationModes.ExpireByDateAndTime:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                {
        //                                    d48.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.ExpireByDays;
        //                                    d48.CredentialData[index].AccessControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                }

        //                                break;
        //                            case PersonExpirationModes.ExpireByUsageCount:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                    d48.CredentialData[index].AccessControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                break;
        //                        }

        //                        if (activeExpireResults.IsActive)
        //                            d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.CardIsEnabled;

        //                        if (i.ReverseBits)
        //                            d48.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.CredentialDataReversed;

        //                        if (i.PassbackExempt)
        //                            d48.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.PassbackExempt;

        //                        if (i.DuressEnabled)
        //                            d48.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.DuressEnabled;

        //                        if (i.PINExempt)
        //                            d48.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.PinRequiredExempt;

        //                        //d48.CredentialData[index].AccessControlCredential.Flags2 |= 0;


        //                        switch (i.DeferToServerBehaviorCode)
        //                        {
        //                            case AccessPortalDeferToServerBehavior.WhenPanelWouldDenyAccess:
        //                                d48.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessDenied;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.WhenPanelWouldGrantAccess:
        //                                d48.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessGranted;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.Always:
        //                                d48.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferAlways;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.Never:
        //                            default:
        //                                break;
        //                        }

        //                        switch (i.NoServerReplyBehaviorCode)
        //                        {
        //                            case AccessPortalNoServerReplyBehavior.AlwaysGrantAccess:
        //                                d48.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.GrantAccessIfServerFailsToRespond;
        //                                break;
        //                            case AccessPortalNoServerReplyBehavior.AlwaysDenyAccess:
        //                                d48.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DenyAccessIfServerFailsToRespond;
        //                                break;
        //                            case AccessPortalNoServerReplyBehavior.FollowPanelDecision:
        //                            default:
        //                                break;
        //                        }

        //                        if (i.HasPhysicalDisability)
        //                            d48.CredentialData[index].AccessControlCredential.Flags3 |= AccessCredentialFlags3.OtisElevatorHasPhysicalDisability;
        //                        break;

        //                    case PersonCredentialRoles.AlarmControl:
        //                        d48.CredentialData[index].AlarmControlCredential = new AlarmControlCredentialData48Bit(i.CredentialBits);
        //                        d48.CredentialData[index].AlarmControlCredential.InputOutputGroup1 = (byte)i.InputOutputGroup1;
        //                        d48.CredentialData[index].AlarmControlCredential.InputOutputGroup2 = (byte)i.InputOutputGroup2;
        //                        d48.CredentialData[index].AlarmControlCredential.InputOutputGroup3 = (ushort)i.InputOutputGroup3;
        //                        d48.CredentialData[index].AlarmControlCredential.InputOutputGroup4 = (ushort)i.InputOutputGroup4;
        //                        if (i.PIN <= 0 || i.PIN > 0xffff)
        //                            i.PIN = 0xffff;
        //                        d48.CredentialData[index].AlarmControlCredential.PIN = (ushort)i.PIN;

        //                        if (activeExpireResults.IsActive)
        //                            d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CardIsEnabled;

        //                        if (i.ReverseBits)
        //                            d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CredentialDataReversed;


        //                        if (i.PINExempt == false)
        //                            d48.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.PinRequired;


        //                        if (activeExpireResults.DaysTillActive != 0)
        //                        {
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex10) != 0)
        //                            {
        //                                d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex10;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex08) != 0)
        //                            {
        //                                d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex08;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex04) != 0)
        //                            {
        //                                d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex04;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex02) != 0)
        //                            {
        //                                d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex02;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex01) != 0)
        //                            {
        //                                d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex01;
        //                            }
        //                        }

        //                        switch (i.CredentialExpirationModeCode)
        //                        {
        //                            case PersonExpirationModes.NeverExpires:
        //                                break;
        //                            case PersonExpirationModes.ExpireByDate:
        //                            case PersonExpirationModes.ExpireByDateAndTime:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                {
        //                                    d48.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.ExpireByDays;
        //                                    d48.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                }

        //                                break;
        //                            case PersonExpirationModes.ExpireByUsageCount:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                    d48.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                break;
        //                        }


        //                        break;

        //                    default:
        //                        throw new ArgumentOutOfRangeException();
        //                }


        //                index++;
        //            }
        //            while (index < CredentialData48Bit.NumberOfCredentials)
        //            {
        //                d48.CredentialData[index].AccessControlCredential = new AccessControlCredentialData48Bit(null)
        //                {
        //                    Flags1 = AccessCredentialFlags1.None
        //                };
        //                index++;
        //            }
        //            int size = Marshal.SizeOf(d48);
        //            int sizeAccess = Marshal.SizeOf(new AccessControlCredentialData48Bit());
        //            int sizeAlarm = Marshal.SizeOf(new AlarmControlCredentialData48Bit());

        //            p.FillData(d48);
        //            p.PrepareForTransmission(false, true, TimeZoneId);

        //            Send(ref p);
        //            break;

        //        case GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits:
        //            var d256 = new CredentialData256Bit(0);
        //            foreach (var i in data)
        //            {
        //                if (index == CredentialData48Bit.NumberOfCredentials)
        //                    break;
        //                //bool isActive = false;
        //                var activeExpireResults = DetermineActivationAndExpiration(i);

        //                switch (i.CredentialRoleCode)
        //                {
        //                    case PersonCredentialRoles.AccessControl:
        //                        d256.CredentialData[index].AccessControlCredential = new AccessControlCredentialData256Bit(i.CredentialBits);
        //                        d256.CredentialData[index].AccessControlCredential.AccessGroup1 = (byte)i.AccessGroup1;
        //                        d256.CredentialData[index].AccessControlCredential.AccessGroup2 = (byte)i.AccessGroup2;
        //                        d256.CredentialData[index].AccessControlCredential.AccessGroup3 = (ushort)i.AccessGroup3;
        //                        if (i.AccessGroup4 == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
        //                            d256.CredentialData[index].AccessControlCredential.AccessGroup4 = (ushort)(i.AccessGroup4 + i.PersonalAccessGroupNumber - 1);
        //                        else
        //                            d256.CredentialData[index].AccessControlCredential.AccessGroup4 = (ushort)i.AccessGroup4;
        //                        if (i.PIN <= 0 || i.PIN > 0xffff)
        //                            i.PIN = 0xffff;
        //                        d256.CredentialData[index].AccessControlCredential.PIN = (ushort)i.PIN;

        //                        if (activeExpireResults.DaysTillActive != 0)
        //                        {
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex10) != 0)
        //                            {
        //                                d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex10;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex08) != 0)
        //                            {
        //                                d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex08;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex04) != 0)
        //                            {
        //                                d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex04;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex02) != 0)
        //                            {
        //                                d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex02;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex01) != 0)
        //                            {
        //                                d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.DaysTillActivex01;
        //                            }
        //                        }

        //                        switch (i.CredentialExpirationModeCode)
        //                        {
        //                            case PersonExpirationModes.NeverExpires:
        //                                break;
        //                            case PersonExpirationModes.ExpireByDate:
        //                            case PersonExpirationModes.ExpireByDateAndTime:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                {
        //                                    d256.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.ExpireByDays;
        //                                    d256.CredentialData[index].AccessControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                }

        //                                break;
        //                            case PersonExpirationModes.ExpireByUsageCount:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                    d256.CredentialData[index].AccessControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                break;
        //                        }

        //                        if (activeExpireResults.IsActive)
        //                            d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.CardIsEnabled;

        //                        if (i.ReverseBits)
        //                            d256.CredentialData[index].AccessControlCredential.Flags1 |= AccessCredentialFlags1.CredentialDataReversed;

        //                        if (i.PassbackExempt)
        //                            d256.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.PassbackExempt;

        //                        if (i.DuressEnabled)
        //                            d256.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.DuressEnabled;

        //                        if (i.PINExempt)
        //                            d256.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.PinRequiredExempt;

        //                        //d256.CredentialData[index].AccessControlCredential.Flags2 |= 0;

        //                        switch (i.CredentialExpirationModeCode)
        //                        {
        //                            case PersonExpirationModes.ExpireByDate:
        //                            case PersonExpirationModes.ExpireByDateAndTime:
        //                                d256.CredentialData[index].AccessControlCredential.Flags2 |= AccessCredentialFlags2.ExpireByDays;
        //                                // set expiration data
        //                                break;

        //                            case PersonExpirationModes.NeverExpires:
        //                            case PersonExpirationModes.ExpireByUsageCount:
        //                            default:
        //                                break;
        //                        }

        //                        switch (i.DeferToServerBehaviorCode)
        //                        {
        //                            case AccessPortalDeferToServerBehavior.WhenPanelWouldDenyAccess:
        //                                d256.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessDenied;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.WhenPanelWouldGrantAccess:
        //                                d256.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessGranted;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.Always:
        //                                d256.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferAlways;
        //                                break;
        //                            case AccessPortalDeferToServerBehavior.Never:
        //                            default:
        //                                break;
        //                        }

        //                        switch (i.NoServerReplyBehaviorCode)
        //                        {
        //                            case AccessPortalNoServerReplyBehavior.AlwaysGrantAccess:
        //                                d256.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.GrantAccessIfServerFailsToRespond;
        //                                break;
        //                            case AccessPortalNoServerReplyBehavior.AlwaysDenyAccess:
        //                                d256.CredentialData[index].AccessControlCredential.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DenyAccessIfServerFailsToRespond;
        //                                break;
        //                            case AccessPortalNoServerReplyBehavior.FollowPanelDecision:
        //                            default:
        //                                break;
        //                        }

        //                        if (i.HasPhysicalDisability)
        //                            d256.CredentialData[index].AccessControlCredential.Flags3 |= AccessCredentialFlags3.OtisElevatorHasPhysicalDisability;
        //                        break;

        //                    case PersonCredentialRoles.AlarmControl:
        //                        d256.CredentialData[index].AlarmControlCredential = new AlarmControlCredentialData256Bit(i.CredentialBits);
        //                        d256.CredentialData[index].AlarmControlCredential.InputOutputGroup1 = (byte)i.InputOutputGroup1;
        //                        d256.CredentialData[index].AlarmControlCredential.InputOutputGroup2 = (byte)i.InputOutputGroup2;
        //                        d256.CredentialData[index].AlarmControlCredential.InputOutputGroup3 = (ushort)i.InputOutputGroup3;
        //                        d256.CredentialData[index].AlarmControlCredential.InputOutputGroup4 = (ushort)i.InputOutputGroup4;
        //                        if (i.PIN <= 0 || i.PIN > 0xffff)
        //                            i.PIN = 0xffff;
        //                        d256.CredentialData[index].AlarmControlCredential.PIN = (ushort)i.PIN;

        //                        if (activeExpireResults.IsActive)
        //                            d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CardIsEnabled;

        //                        if (i.ReverseBits)
        //                            d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CredentialDataReversed;


        //                        if (i.PINExempt == false)
        //                            d256.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.PinRequired;


        //                        if (activeExpireResults.DaysTillActive != 0)
        //                        {
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex10) != 0)
        //                            {
        //                                d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex10;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex08) != 0)
        //                            {
        //                                d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex08;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex04) != 0)
        //                            {
        //                                d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex04;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex02) != 0)
        //                            {
        //                                d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex02;
        //                            }
        //                            if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex01) != 0)
        //                            {
        //                                d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex01;
        //                            }
        //                        }

        //                        switch (i.CredentialExpirationModeCode)
        //                        {
        //                            case PersonExpirationModes.NeverExpires:
        //                                break;
        //                            case PersonExpirationModes.ExpireByDate:
        //                            case PersonExpirationModes.ExpireByDateAndTime:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                {
        //                                    d256.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.ExpireByDays;
        //                                    d256.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                }

        //                                break;
        //                            case PersonExpirationModes.ExpireByUsageCount:
        //                                if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                                    d256.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //                                break;
        //                        }
        //                        break;

        //                    default:
        //                        throw new ArgumentOutOfRangeException();
        //                }


        //                index++;
        //            }
        //            while (index < CredentialData256Bit.NumberOfCredentials)
        //            {
        //                d256.CredentialData[index].AccessControlCredential = new AccessControlCredentialData256Bit(null)
        //                {
        //                    Flags1 = AccessCredentialFlags1.None
        //                };
        //                index++;
        //            }
        //            int sizeX = Marshal.SizeOf(d256);
        //            int sizeAccessX = Marshal.SizeOf(new AccessControlCredentialData256Bit());
        //            int sizeAlarmX = Marshal.SizeOf(new AlarmControlCredentialData256Bit());

        //            p.FillData(d256);
        //            p.PrepareForTransmission(false, true, TimeZoneId);

        //            Send(ref p); break;
        //    }


        //}
        public void SendCredentialDataImmediate(SendDataParameters<List<Credential_PanelLoadData>> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

            if (!data.Data.Any())
                return;

            var first = data.Data.FirstOrDefault();
            var p = GetNewPacketToSend();
            ushort index = 0;
            switch (first.CredentialDataLength)
            {
                case GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Standard48Bit:
                    var d48 = new CredentialData48Bit(0);
                    foreach (var i in data.Data)
                    {
                        if (index == CredentialData48Bit.NumberOfCredentials)
                            break;

                        var activeExpireResults = DetermineActivationAndExpiration(i);
                        //var isActive = true;

                        switch (i.CredentialRoleCode)
                        {
                            case PersonCredentialRoles.AccessControl:
                                IAccessControlCredentialData credData = new AccessControlCredentialData48Bit(i.CredentialBits);
                                FillAccessControlCredentialDataProperties(ref credData, i, activeExpireResults);
                                d48.CredentialData[index].AccessControlCredential = (AccessControlCredentialData48Bit)credData;
                                break;

                            case PersonCredentialRoles.AlarmControl:
                                d48.CredentialData[index].AlarmControlCredential = new AlarmControlCredentialData48Bit(i.CredentialBits);
                                d48.CredentialData[index].AlarmControlCredential.InputOutputGroup1 = (byte)i.InputOutputGroup1;
                                d48.CredentialData[index].AlarmControlCredential.InputOutputGroup2 = (byte)i.InputOutputGroup2;
                                d48.CredentialData[index].AlarmControlCredential.InputOutputGroup3 = (ushort)i.InputOutputGroup3;
                                d48.CredentialData[index].AlarmControlCredential.InputOutputGroup4 = (ushort)i.InputOutputGroup4;
                                if (i.PIN <= 0 || i.PIN > 0xffff)
                                    i.PIN = 0xffff;
                                d48.CredentialData[index].AlarmControlCredential.PIN = (ushort)i.PIN;

                                if (activeExpireResults.IsActive)
                                    d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CardIsEnabled;

                                if (i.ReverseBits)
                                    d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CredentialDataReversed;

                                if (i.PINExempt == true || i.PIN != 0xFFFF)
                                    d48.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.PinRequired;


                                if (activeExpireResults.DaysTillActive != 0)
                                {
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex10) != 0)
                                    {
                                        d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex10;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex08) != 0)
                                    {
                                        d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex08;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex04) != 0)
                                    {
                                        d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex04;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex02) != 0)
                                    {
                                        d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex02;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex01) != 0)
                                    {
                                        d48.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex01;
                                    }
                                }

                                switch (i.CredentialExpirationModeCode)
                                {
                                    case PersonExpirationModes.NeverExpires:
                                        break;
                                    case PersonExpirationModes.ExpireByDate:
                                    case PersonExpirationModes.ExpireByDateAndTime:
                                        if (activeExpireResults.ExpireCount <= byte.MaxValue)
                                        {
                                            d48.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.ExpireByDays;
                                            d48.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
                                        }
                                        break;

                                    case PersonExpirationModes.ExpireByDateAndTimeAndUsageCount:
                                    case PersonExpirationModes.ExpireByUsageCount:
                                        if (activeExpireResults.ExpireCount <= byte.MaxValue)
                                            d48.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
                                        break;
                                }


                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }


                        index++;
                    }
                    while (index < CredentialData48Bit.NumberOfCredentials)
                    {
                        d48.CredentialData[index].AccessControlCredential = new AccessControlCredentialData48Bit(null)
                        {
                            Flags1 = (byte)AccessCredentialFlags1.None
                        };
                        index++;
                    }
                    int size = Marshal.SizeOf(d48);
                    int sizeAccess = Marshal.SizeOf(new AccessControlCredentialData48Bit());
                    int sizeAlarm = Marshal.SizeOf(new AlarmControlCredentialData48Bit());

                    p.FillData(d48);

                    SetExpectedResponseInfo(SpecialOpIdOr | (uint)d48.Cmd, new MessageTrackingData(data, data.GetType()), false);

                    p.PrepareForTransmission(false, true, TimeZoneId);

                    Send(ref p);
                    break;

                case GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits:
                    var d256 = new CredentialData256Bit(0);
                    foreach (var i in data.Data)
                    {
                        if (index == CredentialData48Bit.NumberOfCredentials)
                            break;
                        //bool isActive = false;
                        var activeExpireResults = DetermineActivationAndExpiration(i);

                        switch (i.CredentialRoleCode)
                        {
                            case PersonCredentialRoles.AccessControl:
                                IAccessControlCredentialData credData = new AccessControlCredentialData256Bit(i.CredentialBits);
                                FillAccessControlCredentialDataProperties(ref credData, i, activeExpireResults);
                                d256.CredentialData[index].AccessControlCredential = (AccessControlCredentialData256Bit)credData;
                                break;

                            case PersonCredentialRoles.AlarmControl:
                                d256.CredentialData[index].AlarmControlCredential = new AlarmControlCredentialData256Bit(i.CredentialBits);
                                d256.CredentialData[index].AlarmControlCredential.InputOutputGroup1 = (byte)i.InputOutputGroup1;
                                d256.CredentialData[index].AlarmControlCredential.InputOutputGroup2 = (byte)i.InputOutputGroup2;
                                d256.CredentialData[index].AlarmControlCredential.InputOutputGroup3 = (ushort)i.InputOutputGroup3;
                                d256.CredentialData[index].AlarmControlCredential.InputOutputGroup4 = (ushort)i.InputOutputGroup4;
                                if (i.PIN <= 0 || i.PIN > 0xffff)
                                    i.PIN = 0xffff;
                                d256.CredentialData[index].AlarmControlCredential.PIN = (ushort)i.PIN;

                                if (activeExpireResults.IsActive)
                                    d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CardIsEnabled;

                                if (i.ReverseBits)
                                    d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.CredentialDataReversed;


                                if (i.PINExempt == false)
                                    d256.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.PinRequired;


                                if (activeExpireResults.DaysTillActive != 0)
                                {
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex10) != 0)
                                    {
                                        d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex10;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex08) != 0)
                                    {
                                        d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex08;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex04) != 0)
                                    {
                                        d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex04;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex02) != 0)
                                    {
                                        d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex02;
                                    }
                                    if ((activeExpireResults.DaysTillActive & (byte)AlarmCredentialFlags1.DaysTillActivex01) != 0)
                                    {
                                        d256.CredentialData[index].AlarmControlCredential.Flags1 |= AlarmCredentialFlags1.DaysTillActivex01;
                                    }
                                }

                                switch (i.CredentialExpirationModeCode)
                                {
                                    case PersonExpirationModes.NeverExpires:
                                        break;
                                    case PersonExpirationModes.ExpireByDate:
                                    case PersonExpirationModes.ExpireByDateAndTime:
                                        if (activeExpireResults.ExpireCount <= byte.MaxValue)
                                        {
                                            d256.CredentialData[index].AlarmControlCredential.Flags2 |= AlarmCredentialFlags2.ExpireByDays;
                                            d256.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
                                        }

                                        break;
                                    case PersonExpirationModes.ExpireByDateAndTimeAndUsageCount:
                                    case PersonExpirationModes.ExpireByUsageCount:
                                        if (activeExpireResults.ExpireCount <= byte.MaxValue)
                                            d256.CredentialData[index].AlarmControlCredential.ExpireCount = (byte)activeExpireResults.ExpireCount;
                                        break;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }


                        index++;
                    }
                    while (index < CredentialData256Bit.NumberOfCredentials)
                    {
                        d256.CredentialData[index].AccessControlCredential = new AccessControlCredentialData256Bit(null)
                        {
                            Flags1 = (byte)AccessCredentialFlags1.None
                        };
                        index++;
                    }
                    int sizeX = Marshal.SizeOf(d256);
                    int sizeAccessX = Marshal.SizeOf(new AccessControlCredentialData256Bit());
                    int sizeAlarmX = Marshal.SizeOf(new AlarmControlCredentialData256Bit());

                    p.FillData(d256);
                    SetExpectedResponseInfo(SpecialOpIdOr | (uint)d256.Cmd, new MessageTrackingData(data, data.GetType()), false);
                    p.PrepareForTransmission(false, true, TimeZoneId);

                    Send(ref p); break;
            }
        }

        //private void FillAccessControlCredentialDataProperties(ref IAccessControlCredentialData credentialData, Credential_PanelLoadData i, ActivationAndExpirationResults activeExpireResults)
        //{
        //    credentialData.AccessGroup1 = (byte)i.AccessGroup1;
        //    credentialData.AccessGroup2 = (byte)i.AccessGroup2;
        //    credentialData.AccessGroup3 = (ushort)i.AccessGroup3;
        //    if (i.AccessGroup4 == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
        //        credentialData.AccessGroup4 = (ushort)(i.AccessGroup4 + i.PersonalAccessGroupNumber - 1);
        //    else
        //        credentialData.AccessGroup4 = (ushort)i.AccessGroup4;
        //    if (i.PIN <= 0 || i.PIN > 0xffff)
        //        i.PIN = 0xffff;
        //    credentialData.PIN = (ushort)i.PIN;

        //    if (activeExpireResults.DaysTillActive != 0)
        //    {
        //        if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex10) != 0)
        //        {
        //            credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex10;
        //        }
        //        if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex08) != 0)
        //        {
        //            credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex08;
        //        }
        //        if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex04) != 0)
        //        {
        //            credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex04;
        //        }
        //        if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex02) != 0)
        //        {
        //            credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex02;
        //        }
        //        if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex01) != 0)
        //        {
        //            credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex01;
        //        }
        //    }

        //    switch (i.CredentialExpirationModeCode)
        //    {
        //        case PersonExpirationModes.NeverExpires:
        //            break;
        //        case PersonExpirationModes.ExpireByDate:
        //        case PersonExpirationModes.ExpireByDateAndTime:
        //            if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //            {
        //                credentialData.Flags2 |= AccessCredentialFlags2.ExpireByDays;
        //                credentialData.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //            }

        //            break;
        //        case PersonExpirationModes.ExpireByUsageCount:
        //            if (activeExpireResults.ExpireCount <= byte.MaxValue)
        //                credentialData.ExpireCount = (byte)activeExpireResults.ExpireCount;
        //            break;
        //    }

        //    if (activeExpireResults.IsActive)
        //        credentialData.Flags1 |= AccessCredentialFlags1.CardIsEnabled;

        //    if (i.ReverseBits)
        //        credentialData.Flags1 |= AccessCredentialFlags1.CredentialDataReversed;

        //    if (i.PassbackExempt)
        //        credentialData.Flags2 |= AccessCredentialFlags2.PassbackExempt;

        //    if (i.DuressEnabled)
        //        credentialData.Flags2 |= AccessCredentialFlags2.DuressEnabled;

        //    if (i.PINExempt)
        //        credentialData.Flags2 |= AccessCredentialFlags2.PinRequiredExempt;

        //    //credentialData.Flags2 |= 0;


        //    switch (i.DeferToServerBehaviorCode)
        //    {
        //        case AccessPortalDeferToServerBehavior.WhenPanelWouldDenyAccess:
        //            credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessDenied;
        //            break;
        //        case AccessPortalDeferToServerBehavior.WhenPanelWouldGrantAccess:
        //            credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessGranted;
        //            break;
        //        case AccessPortalDeferToServerBehavior.Always:
        //            credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferAlways;
        //            break;
        //        case AccessPortalDeferToServerBehavior.Never:
        //        default:
        //            break;
        //    }

        //    switch (i.NoServerReplyBehaviorCode)
        //    {
        //        case AccessPortalNoServerReplyBehavior.AlwaysGrantAccess:
        //            credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.GrantAccessIfServerFailsToRespond;
        //            break;
        //        case AccessPortalNoServerReplyBehavior.AlwaysDenyAccess:
        //            credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DenyAccessIfServerFailsToRespond;
        //            break;
        //        case AccessPortalNoServerReplyBehavior.FollowPanelDecision:
        //        default:
        //            break;
        //    }

        //    if (i.HasPhysicalDisability)
        //        credentialData.Flags3 |= (byte)AccessCredentialFlags3.OtisElevatorHasPhysicalDisability;

        //    if (i.VeryImportantPerson)
        //        credentialData.Flags3 |= (byte)AccessCredentialFlags3.OtisElevatorVeryImportantPerson;

        //    if (i.HasVertigo)
        //        credentialData.Flags3 |= (byte)AccessCredentialFlags3.OtisElevatorHasVertigo;

        //    if (i.OtisSplitGroupOperation)
        //        credentialData.Flags3 |= (byte)AccessCredentialFlags3.OtisSplitGroupOperation;

        //    if (i.CanToggleLockState)
        //        credentialData.Flags3 |= (byte)AccessCredentialFlags3.CanDoublePresent;

        //}

        private void FillAccessControlCredentialDataProperties(ref IAccessControlCredentialData credentialData, Credential_PanelLoadData i, ActivationAndExpirationResults activeExpireResults)
        {
            credentialData.AccessGroup1 = (byte)i.AccessGroup1;
            credentialData.AccessGroup2 = (byte)i.AccessGroup2;
            credentialData.AccessGroup3 = (ushort)i.AccessGroup3;
            if (i.AccessGroup4 == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                credentialData.AccessGroup4 = (ushort)(i.AccessGroup4 + i.PersonalAccessGroupNumber - 1);
            else
                credentialData.AccessGroup4 = (ushort)i.AccessGroup4;
            if (i.PIN <= 0 || i.PIN > 0xffff)
                i.PIN = 0xffff;
            credentialData.PIN = (ushort)i.PIN;

            if (activeExpireResults.DaysTillActive != 0)
            {
                if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex10) != 0)
                {
                    credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex10;
                }
                if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex08) != 0)
                {
                    credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex08;
                }
                if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex04) != 0)
                {
                    credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex04;
                }
                if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex02) != 0)
                {
                    credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex02;
                }
                if ((activeExpireResults.DaysTillActive & (byte)AccessCredentialFlags1.DaysTillActivex01) != 0)
                {
                    credentialData.Flags1 |= AccessCredentialFlags1.DaysTillActivex01;
                }
            }

            switch (i.CredentialExpirationModeCode)
            {
                case PersonExpirationModes.NeverExpires:
                    break;
                case PersonExpirationModes.ExpireByDate:
                case PersonExpirationModes.ExpireByDateAndTime:
                    if (activeExpireResults.ExpireCount <= byte.MaxValue)
                    {
                        credentialData.Flags2 |= AccessCredentialFlags2.ExpireByDays;
                        credentialData.ExpireCount = (byte)activeExpireResults.ExpireCount;
                    }
                    break;

                case PersonExpirationModes.ExpireByDateAndTimeAndUsageCount:
                case PersonExpirationModes.ExpireByUsageCount:
                    if (activeExpireResults.ExpireCount <= byte.MaxValue)
                        credentialData.ExpireCount = (byte)activeExpireResults.ExpireCount;
                    break;
            }

            if (activeExpireResults.IsActive)
                credentialData.Flags1 |= AccessCredentialFlags1.CardIsEnabled;

            if (i.ReverseBits)
                credentialData.Flags1 |= AccessCredentialFlags1.CredentialDataReversed;

            if (i.PassbackExempt)
                credentialData.Flags2 |= AccessCredentialFlags2.PassbackExempt;

            if (i.DuressEnabled)
                credentialData.Flags2 |= AccessCredentialFlags2.DuressEnabled;

            if (i.PINExempt)
                credentialData.Flags2 |= AccessCredentialFlags2.PinRequiredExempt;

            //credentialData.Flags2 |= 0;


            switch (i.DeferToServerBehaviorCode)
            {
                case AccessPortalDeferToServerBehavior.WhenPanelWouldDenyAccess:
                    credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessDenied;
                    break;
                case AccessPortalDeferToServerBehavior.WhenPanelWouldGrantAccess:
                    credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferToServerIfAccessGranted;
                    break;
                case AccessPortalDeferToServerBehavior.Always:
                    credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DeferAlways;
                    break;
                case AccessPortalDeferToServerBehavior.Never:
                default:
                    break;
            }

            switch (i.NoServerReplyBehaviorCode)
            {
                case AccessPortalNoServerReplyBehavior.AlwaysGrantAccess:
                    credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.GrantAccessIfServerFailsToRespond;
                    break;
                case AccessPortalNoServerReplyBehavior.AlwaysDenyAccess:
                    credentialData.ServerOverrideBehavior |= ServerOverrideBehaviorFlags.DenyAccessIfServerFailsToRespond;
                    break;
                case AccessPortalNoServerReplyBehavior.FollowPanelDecision:
                default:
                    break;
            }

            if (i.HasPhysicalDisability)
                credentialData.Flags3 |= AccessCredentialFlags3.OtisElevatorHasPhysicalDisability;

            if (i.VeryImportantPerson)
                credentialData.Flags3 |= AccessCredentialFlags3.OtisElevatorVeryImportantPerson;

            if (i.HasVertigo)
                credentialData.Flags3 |= AccessCredentialFlags3.OtisElevatorHasVertigo;

            if (i.OtisSplitGroupOperation)
                credentialData.Flags3 |= AccessCredentialFlags3.OtisSplitGroupOperation;

            if (i.CanToggleLockState)
                credentialData.Flags3 |= AccessCredentialFlags3.CanDoublePresent;

        }

        public void SendPersonalAccessGroupData(SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>> data)
        {
            if (data == null)
                return;

            if (!data.Data.Any())
                return;

            if (_personalAccessGroupDataToLoadParams == null || !_personalAccessGroupDataToLoadParams.Data.Any())
            {
                _personalAccessGroupDataToLoadParams = data;
            }
            else
            {
                this.Log().Info($"SendPersonalAccessGroupData queueing data, Panel:Cpu - {this.PanelId}:{this.CpuId}, Count:{data.Data.Count}");
                _personalAccessGroupDataToLoadQueue.Add(data);
            }





            StartDataLoadTimer();
        }

        private void SendPersonalAccessGroupDataImmediate(SendDataParameters<List<PersonalAccessGroup_PanelLoadData>> data)
        {
            if (data == null || FlashVersion == null)
                return;

            if (!data.Data.Any())
                return;

            // Filter out duplicates and sort by DoorNumber. This could easily occur if a given door is included in both the explicit list of doors and is also a member of one or more dynamic access groups. This could also occur if the door is a member of two or more dynamic access groups even if it is not assigned explicitly
            var distinctValues = data.Data.DistinctBy(o => new { o.PanelNumber, o.DoorNumber }).Where(o => o.PanelNumber == this.PanelId).OrderBy(o => o.DoorNumber).ToList();
            if (!distinctValues.Any())
                return;
            var first = distinctValues.FirstOrDefault();

            var p = GetNewPacketToSend();

            if (FlashVersion?.Major >= 11)
            {
                var d = new PersonalAccessGroupData((ushort)(first.PersonalAccessGroupNumber - 1 + GalaxySMS.Common.Constants.AccessGroupLimits.MinimumPersonalAccessGroupNumber), true, (byte)first.PanelScheduleNumber);

                int x = 0;
                foreach (var pd in distinctValues)
                {
                    if (pd.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never || 
                        (pd.TimeScheduleUid == null && pd.DefaultTimeScheduleUid == TimeScheduleIds.TimeSchedule_Never))
                        continue;

                    var pdn = new PanelAndDoorNumber((ushort)pd.PanelNumber, (Byte)pd.DoorNumber);
                    d.PanelDoorData[x++] = pdn;
                }

                p.FillData(d);
                SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
                p.PrepareForTransmission(false, true, TimeZoneId);
            }
            else
            {
                var d = new PersonalAccessGroupData_PreV11((ushort)(first.PersonalAccessGroupNumber - 1 + GalaxySMS.Common.Constants.AccessGroupLimits.MinimumPersonalAccessGroupNumber), true, (byte)first.PanelScheduleNumber);

                int x = 0;
                foreach (var pd in distinctValues)
                {
                    var pdn = new PanelAndDoorNumber_PreV11((Byte)pd.PanelNumber, (Byte)pd.DoorNumber);
                    d.PanelDoorData[x++] = pdn;
                }

                p.FillData(d);
                SetExpectedResponseInfo(SpecialOpIdOr | (uint)d.Cmd, new MessageTrackingData(data, data.GetType()), false);
                p.PrepareForTransmission(false, true, TimeZoneId);
            }
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a clear automatic update flash timer. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClearAutoUpdateFlashTimer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandClearAutoTimer, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandClearAutoTimer, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a clear all credentials. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClearAllCredentials(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandClearAllUsers, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandClearAllUsers, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a forgive passback for credential. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendForgivePassbackForCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendForgivePassbackForCredential data cannot be null"));

            var p = GetNewPacketToSend();
            switch (this.CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CardCodeFormat)
            {
                case CredentialDataSize.Standard48Bits:
                    var dStandard = new CardCommand48Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandForgivePassbackCard
                    };
                    dStandard.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Standard48Bit, data.Length - CredentialDataByteArrayLength.Standard48Bit);
                    p.FillData(dStandard);
                    break;

                case CredentialDataSize.Extended256Bits:
                    var dExtended = new CardCommand256Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandForgivePassbackCard
                    };
                    dExtended.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Extended256Bits, data.Length - CredentialDataByteArrayLength.Extended256Bits);
                    p.FillData(dExtended);
                    break;
            }

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeTo6xx.CommandForgivePassbackCard, new MessageTrackingData(parameters, parameters.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a forgive passback for all credentials. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendForgivePassbackForAllCredentials(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandForgivePassbackEverybody, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandForgivePassbackEverybody, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a recalibrate inputs and outputs. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRecalibrateInputsAndOutputs(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRecalibrate, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRecalibrate, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an activate crisis mode. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendActivateCrisisMode(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            if (data == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandSetCrisisMode, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandSetCrisisMode, new MessageTrackingData(data, data.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset crisis mode. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"></param>
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendResetCrisisMode(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            if (data == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandResetCrisisMode, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandResetCrisisMode, new MessageTrackingData(data, data.GetType()));
        }

        public void SendRetransmitLoggingBuffer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            var p = GetNewPacketToSend();

            var d = new SetLoggingParam
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoggingResetPointers,
                Param = 1,
                OpId = p.SequenceNumber
            };
            p.FillData(d);

            p.PrepareForTransmission(false, true, TimeZoneId);

            SetExpectedResponseInfo(p.SequenceNumber, new MessageTrackingData(parameters, parameters.GetType()), true);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        public void SendClearLoggingBuffer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            var p = GetNewPacketToSend();

            var d = new SetLoggingParam
            {
                Cmd = (byte)PacketDataCodeTo6xx.CommandLoggingResetPointers,
                Param = 0,
                OpId = p.SequenceNumber
            };
            p.FillData(d);

            p.PrepareForTransmission(false, true, TimeZoneId);

            SetExpectedResponseInfo(p.SequenceNumber, new MessageTrackingData(parameters, parameters.GetType()), true);

            Send(ref p);
        }
        public void SendFlashCommand(GalaxyLoadFlashCommandAction param, GalaxyFlashImageHelper flashImageHelper)
        {

            switch (param.CommandAction)
            {
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoad:
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoadAutoValidateFlashData:
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoadAutoValidateAndBurnFlashData:
                    if (_flashLoadingData == null)
                    {
                        _flashLoadingData = new FlashLoadingData(_cpuInformationReply.Version, param.CommandAction);
                        _flashLoadingData.PacketsPerLoadMessage = param.PacketsPerLoadMessage;
                        _flashLoadingData.SendPacketIntervalMilliseconds = param.SendPacketIntervalMilliseconds;
                    }
                    switch (CpuModel)
                    {
                        case CpuModel.Cpu600:
                            _flashLoadingData.FlashImageHelper = flashImageHelper;
                            _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandBeginFlashLoad600;
                            SendSingleByteCommand(PacketDataCodeTo6xx.CommandBeginFlashLoad600, null);
                            break;

                        case CpuModel.Cpu635:
                            _flashLoadingData.FlashImageHelper = flashImageHelper;
                            _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandBeginFlashLoad635;
                            SendSingleByteCommand(PacketDataCodeTo6xx.CommandBeginFlashLoad635, null);
                            break;

                        case CpuModel.Unknown:
                        case CpuModel.Cpu5xx:
                        case CpuModel.Cpu708:
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    SendFlashProgressMessageToProcessingQueue(FlashingState.LoadingPackets);

                    break;

                case GalaxyLoadFlashCommandActionCode.CancelFlashLoad:
                    KillFlashLoadTimer();
                    _flashLoadingData = null;
                    SendFlashProgressMessageToProcessingQueue(FlashingState.Idle);
                    break;

                case GalaxyLoadFlashCommandActionCode.PauseFlashLoad:
                    if (_flashLoadingData != null)
                        _flashLoadingData.Paused = true;
                    KillFlashLoadTimer();
                    SendFlashProgressMessageToProcessingQueue(FlashingState.LoadingPaused);
                    break;

                case GalaxyLoadFlashCommandActionCode.ResumeFlashLoad:
                    if (_flashLoadingData != null)
                    {
                        _flashLoadingData.Paused = false;
                        StartFlashLoadTimer();
                    }
                    break;

                case GalaxyLoadFlashCommandActionCode.ValidateFlashData:
                    if (_flashLoadingData != null)
                        SendCheckCrc(false);
                    SendFlashProgressMessageToProcessingQueue(FlashingState.Validating);
                    break;

                case GalaxyLoadFlashCommandActionCode.ValidateAndBurnFlashData:
                    if (_flashLoadingData != null)
                        SendCheckCrc(true);
                    SendFlashProgressMessageToProcessingQueue(FlashingState.Validating);
                    break;
            }
        }

        private void SendNextFlashPacket()
        {
            KillFlashLoadTimer();
            if (_flashLoadingData == null)
                return;
            try
            {
                //var msg = $"SendNextFlashPacket {_flashLoadingData.PacketCounter} of {_flashLoadingData.TotalPacketCount}";
                //Trace.WriteLine(msg);
                var packets = _flashLoadingData.GetNextPackets();
                if (packets.Length == 0)
                {
                    if (_flashLoadingData.Command == GalaxyLoadFlashCommandActionCode.BeginFlashLoadAutoValidateAndBurnFlashData)
                        SendCheckCrc(true);
                    else
                        SendCheckCrc(false);
                    SendFlashProgressMessageToProcessingQueue(FlashingState.Validating);
                    return;
                }

                var dataBytes = packets[0].GetData();
                for (int x = 1; x < packets.Length; x++)
                {
                    dataBytes = dataBytes.Append(packets[x].GetData());
                }

                IDataPacket6xx p = GetNewPacketToSend();

                //                var d = new VariableLengthFlashData((Byte)PacketDataCodeTo6xx.CommandLoadFlashPacket635, packets[0].Address, dataBytes);
                var d = new VariableLengthFlashData((Byte)PacketDataCodeTo6xx.CommandLoadFlashPacket635, packets[0].Address);
                switch (CpuModel)
                {
                    case CpuModel.Cpu600:
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandLoadFlashPacket600;
                        break;
                    case CpuModel.Cpu635:
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandLoadFlashPacket635;
                        break;


                    case CpuModel.Unknown:
                    case CpuModel.Cpu5xx:
                    case CpuModel.Cpu708:
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                d.Cmd = (Byte)_flashLoadingData.LastCommandSent;
                p.FillData(d);
                Buffer.BlockCopy(dataBytes, 0, p.Data, d.GetSize(), dataBytes.Length);
                p.Length += (ushort)dataBytes.Length;
                p.PrepareForTransmission(false, true, TimeZoneId);
                Send(ref p);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex.Message + "\n" + ex.StackTrace);
                this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} Exception", ex);

            }
        }

        private void SendCheckCrc(bool validateAndBurn)
        {
            KillFlashLoadTimer();
            if (_flashLoadingData == null)
                return;
            IDataPacket6xx p = GetNewPacketToSend();
            var d = new ValidateFlashBuffer();
            switch (CpuModel)
            {
                case CpuModel.Cpu600:
                    if (validateAndBurn)
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandValidateThenBurnFlash600;
                    else
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandValidateFlash600;
                    break;
                case CpuModel.Cpu635:
                    if (validateAndBurn)
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandValidateThenBurnFlash635;
                    else
                        _flashLoadingData.LastCommandSent = PacketDataCodeTo6xx.CommandValidateFlash635;
                    break;


                case CpuModel.Unknown:
                case CpuModel.Cpu5xx:
                case CpuModel.Cpu708:
                default:
                    throw new ArgumentOutOfRangeException();

            }

            d.Cmd = (Byte)_flashLoadingData.LastCommandSent;
            d.PacketCount = _flashLoadingData.PacketsSentCounter;//PacketCounter;
            d.Crc = _flashLoadingData.CRC;
            d.CrcExtented = _flashLoadingData.FlashImageHelper.CRC_Ex;

            // Force bad CRC to test failures
            if (this.ClusterId == 6)
            {
                d.CrcExtented = 0;
                d.Crc = 1;
            }

            p.FillData(d);
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an enable credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendEnableCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendEnableCredential data cannot be null"));

            var p = GetNewPacketToSend();
            switch (this.CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CardCodeFormat)
            {
                case CredentialDataSize.Standard48Bits:
                    var dStandard = new CardCommand48Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandCardEnable
                    };
                    dStandard.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Standard48Bit, data.Length - CredentialDataByteArrayLength.Standard48Bit);
                    p.FillData(dStandard);
                    break;

                case CredentialDataSize.Extended256Bits:
                    var dExtended = new CardCommand256Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandCardEnable
                    };
                    dExtended.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Extended256Bits, data.Length - CredentialDataByteArrayLength.Extended256Bits);
                    p.FillData(dExtended);
                    break;
            }

            SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeTo6xx.CommandCardEnable, new MessageTrackingData(parameters, parameters.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a disable credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDisableCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDisableCredential data cannot be null"));

            var p = GetNewPacketToSend();
            switch (this.CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CardCodeFormat)
            {
                case CredentialDataSize.Standard48Bits:
                    var dStandard = new CardCommand48Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandCardDisable
                    };
                    dStandard.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Standard48Bit, data.Length - CredentialDataByteArrayLength.Standard48Bit);
                    p.FillData(dStandard);
                    break;

                case CredentialDataSize.Extended256Bits:
                    var dExtended = new CardCommand256Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandCardDisable
                    };
                    dExtended.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Extended256Bits, data.Length - CredentialDataByteArrayLength.Extended256Bits);
                    p.FillData(dExtended);
                    break;
            }

            //var pTemp = new SendDataParameters<GalaxyCpuCommandAction>(parameters);

            //SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeTo6xx.CommandCardDisable, new MessageTrackingData(pTemp, parameters.GetType()), false);
            SetExpectedResponseInfo(SpecialOpIdOr | (uint)PacketDataCodeTo6xx.CommandCardDisable, new MessageTrackingData(parameters, parameters.GetType()), false);

            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a delete credential. </summary>
        ///
        /// <remarks>   Kevin, 4/5/2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDeleteCredential(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDeleteCredential data cannot be null"));

            var p = GetNewPacketToSend();
            switch (this.CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.CardCodeFormat)
            {
                case CredentialDataSize.Standard48Bits:
                    var dStandard = new CardCommand48Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandDeleteCard
                    };
                    dStandard.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Standard48Bit, data.Length - CredentialDataByteArrayLength.Standard48Bit);
                    p.FillData(dStandard);
                    break;

                case CredentialDataSize.Extended256Bits:
                    var dExtended = new CardCommand256Bit
                    {
                        Cmd = (byte)PacketDataCodeTo6xx.CommandDeleteCard
                    };
                    dExtended.CredentialBits = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, CredentialDataByteArrayLength.Extended256Bits, data.Length - CredentialDataByteArrayLength.Extended256Bits);
                    p.FillData(dExtended);
                    break;
            }


            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a delete credentials. </summary>
        ///
        /// <remarks>   Kevin, 4/8/2019. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDeleteCredentials(IEnumerable<CredentialToDeleteFromCpu> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDeleteCredentials data cannot be null"));

            if (!data.Any())
                return;

            _credentialDataToDelete = data.ToList();
            StartDataLoadTimer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a request input output group counters. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        /// <param name="ioGroupNumber">    The i/o group number. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRequestInputOutputGroupCounters(ushort ioGroupNumber,
            SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (ioGroupNumber < GalaxySMS.Common.Constants.InputOutputGroupLimits.LowestDefinableNumber ||
                ioGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.HighestNumber)
                throw new ArgumentOutOfRangeException("ioGroupNumber", ioGroupNumber, $"The valid range is {GalaxySMS.Common.Constants.InputOutputGroupLimits.LowestDefinableNumber} to {GalaxySMS.Common.Constants.InputOutputGroupLimits.HighestNumber}");

            IDataPacket6xx p = GetNewPacketToSend();
            var c = new GCS.PanelProtocols.Series6xx.Messages.InputOutputGroupCommand();
            c.Cmd = (Byte)PacketDataCodeTo6xx.CommandGetIOGroupCounters;
            c.GroupNumber = (byte)ioGroupNumber;
            p.FillData(c);//, Marshal.SizeOf(c));
            p.PrepareForTransmission(false, true, TimeZoneId);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a request board information. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRequestBoardInformation(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            if (parameters?.ApplicationUserSessionHeader != null)
                SetSessionIdForResponseCode(parameters.ApplicationUserSessionHeader.SessionGuid, (UInt16)PacketDataCodeFrom6xx.ResponseConnectedBoardInformation);

            if (parameters == null)
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation, null);
            else
                SendSingleByteCommand(PacketDataCodeTo6xx.CommandRequestConnectedBoardInformation, new MessageTrackingData(parameters, parameters.GetType()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Keep track of sessionIds that need to receive the response message when it is received from
        /// the panel.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        /// <param name="responseCode"> The response code. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetSessionIdForResponseCode(Guid sessionId, UInt16 responseCode)
        {
            if (sessionId != Guid.Empty)
            {
                List<Guid> sessionIds = null;
                if (_sessionIdsForResponseCodes.ContainsKey(responseCode))
                    sessionIds = _sessionIdsForResponseCodes[responseCode];
                else
                {
                    sessionIds = new List<Guid>();
                    _sessionIdsForResponseCodes.Add(responseCode, sessionIds);
                }
                sessionIds.Add(sessionId);
            }
        }


        private void SetSessionIdForAckNackResponseCode(Guid sessionId, UInt16 responseCode)
        {
            if (sessionId != Guid.Empty)
            {
                List<Guid> sessionIds = null;
                if (_sessionIdsForAckNackResponseCodes.ContainsKey(responseCode))
                    sessionIds = _sessionIdsForAckNackResponseCodes[responseCode];
                else
                {
                    sessionIds = new List<Guid>();
                    _sessionIdsForAckNackResponseCodes.Add(responseCode, sessionIds);
                }
                sessionIds.Add(sessionId);
            }
        }

        private void SetExpectedResponseInfo(uint opId, MessageTrackingData info, bool bRemoveifDuplicate)
        {
            List<MessageTrackingData> existingList;
            if (_messageTrackingDictionary.TryGetValue(opId, out existingList))
            {
                if (bRemoveifDuplicate && existingList.Count > 0)
                    existingList.RemoveAt(0);
                existingList.Add(info);
            }
            else
            {
                existingList = new List<MessageTrackingData> { info };
                _messageTrackingDictionary.Add(opId, existingList);
            }

            this.Log().Debug($"{ConnectionDescription} _messageTrackingDictionary.Count: {_messageTrackingDictionary.Count}");
        }

        private MessageTrackingData GetExpectedResponseInfo(uint opId)
        {
            List<MessageTrackingData> existingList;
            if (_messageTrackingDictionary.TryGetValue(opId, out existingList))
            {
                for (int x = 0; x < existingList.Count; x++)
                {
                    var existingValue = existingList[x];
                    if (existingValue.ObjectType == typeof(SendDataParameters<GalaxyCpuCommandAction>))
                    {
                        var temp = existingValue.OriginalData as SendDataParameters<GalaxyCpuCommandAction>;
                        if (temp != null)
                        {
                            switch (temp.Data.CommandAction)
                            {
                                case GalaxyCpuCommandActionCode.DisableCredential:
                                case GalaxyCpuCommandActionCode.EnableCredential:
                                case GalaxyCpuCommandActionCode.ForgivePassbackForCredential:
                                    if (temp.Data.CredentialBytesList.Count <= 1)
                                        existingList.RemoveAt(0);
                                    break;

                                default:
                                    existingList.RemoveAt(0);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        existingList.RemoveAt(0);
                    }

                    if (existingList.Count == 0)
                    {
                        _messageTrackingDictionary.Remove(opId);
                    }

                    this.Log().Debug($"{ConnectionDescription} _messageTrackingDictionary.Count: {_messageTrackingDictionary.Count}");

                    return existingValue;
                }
            }
            this.Log().Debug($"{ConnectionDescription} _messageTrackingDictionary.Count: {_messageTrackingDictionary.Count}");
            return null;
        }

        //private void SetOperationTimeout(Guid operationUid, int timeout)
        //{
        //    if (timeout <= 0)
        //        timeout = _operationTimeoutSecondsDefaultValue;
        //    if (timeout <= 0)
        //        timeout = 10;
        //    var timeoutAt = DateTimeOffset.UtcNow.AddSeconds(timeout);
        //    _operationTrackingExpirationDictionary.AddOrUpdate(operationUid, timeoutAt, (key, oldValue) => timeoutAt);
        //    this.Log().Debug($"Setting operation timeout: {operationUid}, {timeoutAt}");
        //}

        #endregion
    }
}
