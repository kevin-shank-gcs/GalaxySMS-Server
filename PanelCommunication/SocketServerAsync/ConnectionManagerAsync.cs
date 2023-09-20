////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ConnectionManagerAsync.cs
//
// summary:	Implements the connection manager asynchronous class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Business.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Flash;
using GCS.PanelCommunicationServerAsync.Entities;
using GCS.PanelCommunicationServerAsync.Interfaces;
using GCS.PanelDataHandlers;
using GCS.PanelDataProcessors.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using GCS.PanelProtocols.Series5xx;
using GalaxyCpuConnection = GalaxySMS.Client.Entities.GalaxyCpuConnection;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;
using System.Security.Cryptography;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ConnectionManagerParameters
    {
        public ConnectionManagerParameters(int numConnections, int receiveBufferSize, int listenPort, ConnectionManagerAsync.IPVersionType ipVersion, string encryptionPhrase, string serverAddress, int ackLogMessageIndexMinimumInterval, int operationTimeoutSecondsDefaultValue)
        {
            NumConnections = numConnections;
            ReceiveBufferSize = receiveBufferSize;
            ListenPort = listenPort;
            IpVersion = ipVersion;
            EncryptionPhrase = encryptionPhrase;
            ServerAddress = serverAddress;
            AckLogMessageIndexMinimumInterval = ackLogMessageIndexMinimumInterval;
            OperationTimeoutSecondsDefaultValue = operationTimeoutSecondsDefaultValue;
        }

        public int NumConnections { get; private set; }
        public int ReceiveBufferSize { get; private set; }
        public int ListenPort { get; private set; }
        public ConnectionManagerAsync.IPVersionType IpVersion { get; private set; }
        public string EncryptionPhrase { get; private set; }
        public string ServerAddress { get; private set; }
        public int AckLogMessageIndexMinimumInterval { get; private set; }
        public int OperationTimeoutSecondsDefaultValue { get; private set; }
    }

    /// <summary>   A connection manager asynchronous. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ConnectionManagerAsync
    {
        #region Private fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// the maximum number of connections the sample is designed to handle simultaneously.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int _numConnections;
        /// <summary>   buffer size to use for each socket I/O operation. </summary>
        private int _receiveBufferSize;
        /// <summary>   represents a large reusable set of buffers for all socket operations. </summary>
        private BufferManager _bufferManager;
        /// <summary>   read, write (don't alloc buffer space for accepts) </summary>
        private const int _opsToPreAlloc = 2;
        /// <summary>   the socket used to listen for incoming connection requests. </summary>
        private Socket _listenSocket;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// pool of reusable SocketAsyncEventArgs objects for write, read and accept socket operations.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private SocketAsyncEventArgsPool _readWritePool;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// int totalBytesRead;           // counter of the total # bytes received by the server.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int _numConnectedSockets;
        /// <summary>   The maximum number accepted clients. </summary>
        private Semaphore _maxNumberAcceptedClients;
        /// <summary>   The local end point. </summary>
        private IPEndPoint _localEndPoint;
        /// <summary>   The aes encryption phrase. </summary>
        private string _aesEncryptionPhrase;

        private readonly string _serverAddress;

        /// <summary>   Queue of processings. </summary>
        private BlockingCollection<object> _processingQueue;
        /// <summary>   Queue of recordings. </summary>
        private BlockingCollection<object> _recordingQueue;
        /// <summary>   The panel output data recorder. </summary>
        private IPanelOutputDataProcessor _panelOutputDataRecorder;
        /// <summary>   The panel traffic data recorder. </summary>
        private IPanelOutputDataProcessor _panelTrafficDataRecorder;

        /// <summary>   The wait for processing queue to empty timer. </summary>
        private Timer _waitForProcessingQueueToEmptyTimer;
        /// <summary>   The wait for recording queue to empty timer. </summary>
        private Timer _waitForRecordingQueueToEmptyTimer;

        /// <summary>   The CPU connections. </summary>
        private ObservableCollection<CpuConnectionInfo> _cpuConnections = new ObservableCollection<CpuConnectionInfo>();
        /// <summary>   The connections. </summary>
        private System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection> _connections;
        private System.Collections.Concurrent.ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>> _credentialLoadDataByCpuUid;

        /// <summary>   The site server connection settings. </summary>
        private GalaxySiteServerConnectionSettings _siteServerConnectionSettings;

        private int _ackLogMessageIndexMinimumInterval;
        private readonly int _operationTimeoutSecondsDefaultValue;

        //private GalaxySiteServerConnection _siteServerConnection;
        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent IP version types. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum IPVersionType { IPv4, IPv6 };

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the listen port. </summary>
        ///
        /// <value> The listen port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Int32 ListenPort { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the encryption is enabled. </summary>
        ///
        /// <value> True if encryption enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool EncryptionEnabled { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP version. </summary>
        ///
        /// <value> The IP version. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IPVersionType IPVersion { get; internal set; }
        //		System.Collections.Concurrent.ConcurrentDic_nvrAdaptertio_nvrAdapternary<int, System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection>> connectionsByCluster;

        #endregion

        #region Public Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DataReceived events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data received event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ConnectionStateChangedEventHandler(object sender, ConnectionStateChangeEventArgs e);
        /// <summary>   Event queue for all listeners interested in connectionStateChanged events. </summary>
        public event ConnectionStateChangedEventHandler ConnectionStateChangedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DebugPacket events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Connection debug packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DebugPacketEventHandler(object sender, ConnectionDebugPacketEventArgs e);
        /// <summary>   Event queue for all listeners interested in debugPacket events. </summary>
        public event DebugPacketEventHandler DebugPacketEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling PanelInformation events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel information event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelInformationEventHandler(object sender, PanelInformationEventArgs e);
        /// <summary>   Event queue for all listeners interested in panelInformation events. </summary>
        public event PanelInformationEventHandler PanelInformationEvent;

        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the CPU connections. </summary>
        ///
        /// <value> The CPU connections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<CpuConnectionInfo> CpuConnections
        {
            get { return _cpuConnections; }
        }

        public bool IsPanelOnline(int clusterGroupId, int clusterNumber, int panelNumber)
        {
            if (_cpuConnections == null)
                return false;
            var count = _cpuConnections.Count(o => o.GalaxyCpuInformation?.ClusterGroupId == clusterGroupId &&
                                                  o.GalaxyCpuInformation?.ClusterNumber == clusterNumber &&
                                                  o.GalaxyCpuInformation?.PanelNumber == panelNumber &&
                                                  o.IsAuthenticated);
            return count > 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets a value indicating whether this ConnectionManagerAsync is running.
        /// </summary>
        ///
        /// <value> True if this ConnectionManagerAsync is running, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsRunning
        {
            get
            {
                if (_listenSocket == null)
                    return false;
                return true;
            }
        }

        #endregion

        #region Constructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create an instance.  To start the server listening for connection requests call the Init
        /// method followed by Start method.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// ### <param name="numConnections">   the maximum number of connections the sample is designed
        ///                                     to handle simultaneously. </param>
        ///
        /// ### <param name="receiveBufferSize">    buffer size to use for each socket I/O operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionManagerAsync()
        {
            //			this.totalBytesRead = 0;
            this._numConnectedSockets = 0;
            this._numConnections = 500;
            this._receiveBufferSize = 1050;
            EncryptionEnabled = false;
            _aesEncryptionPhrase = string.Empty;
            ListenPort = 3001;
            IPVersion = IPVersionType.IPv4;
            if (IPVersion == IPVersionType.IPv4)
                _localEndPoint = new IPEndPoint(IPAddress.Any, ListenPort);
            else
                _localEndPoint = new IPEndPoint(IPAddress.IPv6Any, ListenPort);

            _aesEncryptionPhrase = string.Empty;
            // allocate buffers such that the maximum number of sockets can have one outstanding read and 
            //write posted to the socket simultaneously  
            this._bufferManager = new BufferManager(_receiveBufferSize * _numConnections * _opsToPreAlloc,
                 _receiveBufferSize);

            _connections = new System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection>();
            _credentialLoadDataByCpuUid = new ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>>();

            this._readWritePool = new SocketAsyncEventArgsPool(_numConnections);
            this._maxNumberAcceptedClients = new Semaphore(_numConnections, _numConnections);

            _siteServerConnectionSettings = new GalaxySiteServerConnectionSettings();
            //_siteServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);
            Globals.Instance.ServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);
            Init();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create an uninitialized server instance.  To start the server listening for connection
        /// requests call the Init method followed by Start method.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="numConnections">       the maximum number of connections the sample is designed
        ///                                     to handle simultaneously. </param>
        /// <param name="receiveBufferSize">    buffer size to use for each socket I/O operation. </param>
        /// <param name="listenPort">           The listen port. </param>
        /// <param name="ipVersion">            The IP version. </param>
        /// <param name="encryptionPhrase">     The encryption phrase. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionManagerAsync(ConnectionManagerParameters connectionManagerParameters)
        {
            ListenPort = connectionManagerParameters.ListenPort;
            IPVersion = connectionManagerParameters.IpVersion;
            this._aesEncryptionPhrase = connectionManagerParameters.EncryptionPhrase;
            _serverAddress = connectionManagerParameters.ServerAddress;
            if (!string.IsNullOrEmpty(connectionManagerParameters.EncryptionPhrase))
                EncryptionEnabled = true;

            if (IPVersion == IPVersionType.IPv4)
                _localEndPoint = new IPEndPoint(IPAddress.Any, ListenPort);
            else
                _localEndPoint = new IPEndPoint(IPAddress.IPv6Any, ListenPort);

            //			this.totalBytesRead = 0;
            this._numConnectedSockets = 0;
            this._numConnections = connectionManagerParameters.NumConnections;
            this._receiveBufferSize = connectionManagerParameters.ReceiveBufferSize;
            this._ackLogMessageIndexMinimumInterval = connectionManagerParameters.AckLogMessageIndexMinimumInterval;
            _operationTimeoutSecondsDefaultValue = connectionManagerParameters.OperationTimeoutSecondsDefaultValue;
            // allocate buffers such that the maximum number of sockets can have one outstanding read and 
            //write posted to the socket simultaneously  
            this._bufferManager = new BufferManager(connectionManagerParameters.ReceiveBufferSize * connectionManagerParameters.NumConnections * _opsToPreAlloc,
                 connectionManagerParameters.ReceiveBufferSize);
            //			connections = new System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, Connection6xx>();
            _connections = new System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection>();
            _credentialLoadDataByCpuUid = new ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>>();

            _processingQueue = new System.Collections.Concurrent.BlockingCollection<object>();
            _recordingQueue = new System.Collections.Concurrent.BlockingCollection<object>();
            //			connectionsByCluster = new System.Collections.Concurrent.ConcurrentDictionary<int, System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection>>();

            this._readWritePool = new SocketAsyncEventArgsPool(connectionManagerParameters.NumConnections);
            this._maxNumberAcceptedClients = new Semaphore(connectionManagerParameters.NumConnections, connectionManagerParameters.NumConnections);

            _siteServerConnectionSettings = new GalaxySiteServerConnectionSettings();
            //_siteServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);
            Globals.Instance.ServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);

            Init();
        }
        #endregion

        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Starts the server such that it is listening for incoming connection requests.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// ### <param name="localEndPoint">    The endpoint which the server will listening for
        ///                                     connection requests on. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start()
        {
            try
            {
                this.Log().Info($"Starting panel communication manager. Listening on port:{_localEndPoint.Port}");

                int minWorkerThreads, maxWorkerThreads;
                int minIoCompletionPortThreads, maxIoCompletionPortThreads;
                int availableWorkerThreads, availableIoCompletionPortThreads;

                System.Threading.ThreadPool.GetMinThreads(out minWorkerThreads, out minIoCompletionPortThreads);
                System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxIoCompletionPortThreads);
                System.Threading.ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availableIoCompletionPortThreads);

                StartPanelOutputDataProcessors();

                try
                {
                    Task.Run(async () =>
                    {
                        await UpdateCpuConnectionStatus(new GalaxyCpuConnection()
                        {
                            CpuUid = Guid.Empty,
                            IsConnected = false,
                            ServerAddress = this._serverAddress
                        });
                    }).Wait();
                }
                catch (Exception ex)
                {
                    this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                }


                // create the socket which listens for incoming connections
                _listenSocket = new Socket(_localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _listenSocket.Bind(_localEndPoint);
                // start the server with a listen backlog of 100 connections
                _listenSocket.Listen(100);

                // post accepts on the listening socket
                StartAccept(null);

                ////Console.WriteLine("{0} connected sockets with one outstanding receive posted to each....press any key", m_outstandingReadCount);
                //Console.WriteLine("Press any key to terminate the server process....");
                //Console.ReadKey();
                // }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                Stop();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Stops this ConnectionManagerAsync. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Stop()
        {
            try
            {
                if (_listenSocket != null)
                {
                    _listenSocket.Close();
                }
                _listenSocket = null;
                // Close All Sockets
                CloseAllConnections();
                if (_processingQueue != null)
                {
                    _processingQueue.CompleteAdding();
                    if (_processingQueue.Count > 0)
                    {
                        _waitForProcessingQueueToEmptyTimer = new System.Threading.Timer(WaitForProcessingQueueToEmptyTimerCallback, null, 500, 250);
                    }
                    else
                    {
                        if (_panelOutputDataRecorder != null)
                            _panelOutputDataRecorder.StopProcessor();
                    }
                }

                if (_recordingQueue != null)
                {
                    _recordingQueue.CompleteAdding();
                    if (_recordingQueue.Count > 0)
                    {
                        _waitForRecordingQueueToEmptyTimer = new System.Threading.Timer(WaitForRecordingQueueToEmptyTimerCallback, null, 500, 250);
                    }
                    else
                    {
                        if (_panelTrafficDataRecorder != null)
                            _panelTrafficDataRecorder.StopProcessor();
                    }
                }

            }
            catch (Exception ex)
            {
                _listenSocket = null;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a cluster connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="connection">   The connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddClusterConnection(ClusterConnectionParameters connection)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                e.RemoteEndPoint = connection.EndPointAddress;

                e.UserToken = new AsyncUserToken(s, connection);
                e.Completed += new EventHandler<SocketAsyncEventArgs>(Process5xxConnectCompleted);
                s.ConnectAsync(e);
            }
            catch (Exception ex)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("AddClusterConnection {0}: {1}", ex.GetType(), ex.Message));
                this.Log().DebugFormat("AddClusterConnection {0}: {1}", ex.GetType(), ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enables the debugging. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="instanceGuid"> Unique identifier for the instance. </param>
        /// <param name="bEnable">      True to enable, false to disable. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void EnableDebugging(string instanceGuid, bool bEnable)
        {
            IPanelConnection conn = FindConnectionByInstanceGuid(instanceGuid);
            if (conn != null)
            {
                if (conn.DebuggingMode == false)
                {

                }
                conn.DebuggingMode = bEnable;
                //System.Diagnostics.Trace.WriteLine(string.Format("{0} DebuggingMode:{1}", conn.ConnectionDescription, conn.DebuggingMode));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a raw data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRawData(RawDataToSend data)
        {
            IPanelConnection[] conns = FindConnections(data.Address);//.CpuAddress);

            if (conns != null)
            {
                foreach (IPanelConnection c in conns)
                {
                    c.SendRawData(data, null);
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pings the given target. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Ping(CpuHardwareAddress target)
        {
            IPanelConnection[] conns = FindConnections(target);//.CpuAddress);
            if (conns != null)
            {
                foreach (IPanelConnection c in conns)
                {
                    c.SendPing(null);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets total card count. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetTotalCardCount(CpuHardwareAddress target)
        {
            IPanelConnection[] conns = FindConnections(target);//.CpuAddress);
            if (conns != null)
            {
                foreach (IPanelConnection c in conns)
                {
                    c.SendGetCardCount(null);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets controller information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetControllerInfo(CpuHardwareAddress target)
        {
            IPanelConnection[] conns = FindConnections(target);//.CpuAddress);
            if (conns != null)
            {
                foreach (IPanelConnection c in conns)
                {
                    c.SendGetControllerInfo(null);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets logging information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetLoggingInfo(CpuHardwareAddress target)
        {
            IPanelConnection[] conns = FindConnections(target);//.CpuAddress);
            if (conns != null)
            {
                foreach (IPanelConnection c in conns)
                {
                    c.SendGetLoggingInfo(null);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the board section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitializeBoardSection(InitializeBoardSectionSettings data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter InitializeBoardSectionSettings data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Address.ClusterNumber, data.Address.PanelNumber, data.Address.CpuId, data.Address.ClusterGroupId));
            if (conns == null)
                return;

            foreach (IPanelConnection c in conns)
            {
                c.InitializeBoardSection(new SendDataParameters<InitializeBoardSectionSettings>() { Data = data });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an aba settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAbaSettings(SendDataParameters<AbaSettings> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAbaSettings data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.SendToAddress.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, data.SendToAddress.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for Account: '{0};, ClusterNumber '{1}'.", data.SendToAddress.ClusterGroupId, data.SendToAddress.ClusterNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            foreach (var c in conns)
            {
                c.SendAbaSettings(data);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cluster common settings to panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        /// <exception cref="DataValidationException">              Thrown when a Data Validation error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClusterCommonSettingsToPanels(SendDataParameters<Cluster_CommonPanelLoadData> data)
        {
            if (data == null || data?.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendClusterCommonSettingsToPanels data cannot be null"));

            if (data.SendToAddress.PanelNumber == 0)
                data.SendToAddress.PanelNumber = (int)CpuHardwareAddress.SystemPanelAddress.AllPanels;
            if (data.SendToAddress.CpuId == 0)
                data.SendToAddress.CpuId = (short)CpuHardwareAddress.CpuNumber.Both;

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                        string.Format("There are no connections for cluster number '{0}'.", data.Data.ClusterNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }


            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            var abaData = new AbaSettings();
            abaData.Start = data.Data.AbaStartDigit;
            abaData.End = data.Data.AbaStopDigit;
            if (data.Data.AbaFoldOption == true)
                abaData.Folding = AbaFold.On;
            else
                abaData.Folding = AbaFold.Off;
            if (data.Data.AbaClipOption == true)
                abaData.Clipping = AbaClip.On;
            else
                abaData.Clipping = AbaClip.None;

            var aba = new SendDataParameters<AbaSettings>() { Data = abaData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var wiegandData = new WiegandSettings();
            wiegandData.Start = data.Data.WiegandStartBit;
            wiegandData.End = data.Data.WiegandStopBit;
            var wiegand = new SendDataParameters<WiegandSettings>() { Data = wiegandData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var cardaxData = new CardaxSettings();
            cardaxData.Start = data.Data.CardaxStartBit;
            cardaxData.End = data.Data.CardaxStopBit;
            var cardax = new SendDataParameters<CardaxSettings>() { Data = cardaxData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var lockoutData = new ReaderLockoutSettings();
            lockoutData.MaximumInvalidAttempts = data.Data.LockoutAfterInvalidAttempts;
            lockoutData.LockoutTimeInHundredthsOfSeconds = (ushort)(data.Data.LockoutDurationSeconds * 100);
            var lockout = new SendDataParameters<ReaderLockoutSettings>() { Data = lockoutData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var ledData = new LedBehaviorSettings();
            ledData.BothOff = LedMode.AllOff;
            ledData.BothBlinkFast = LedMode.BothBlink12TimesPerSecond;
            ledData.BothSolid = LedMode.BothSolid;
            ledData.GreenBlink = EnumExtensions.GetOne<LedMode>(data.Data.UnlockedLED);//.UnlockedLED.GetOne<LedMode>(); (LedMode)data.UnlockedLED;// LedMode.GreenBlink6TimesPerSecond;
            ledData.GreenBlinkFast = LedMode.GreenBlink12TimesPerSecond;
            ledData.GreenSolid = EnumExtensions.GetOne<LedMode>(data.Data.LockedLED); //(LedMode)data.LockedLED;//LedMode.GreenSolid;
            ledData.RedBlinkSlow = LedMode.RedBlink2TimesPerSecond;
            ledData.RedSolid = LedMode.RedOnlySolid;
            var led = new SendDataParameters<LedBehaviorSettings>() { Data = ledData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var crisisData = new CrisisModeSettings();
            crisisData.ActivateInputOutputGroupNumber = new GalaxySMS.Business.Entities.InputOutputGroupNumber() { GroupNumber = data.Data.ActivateCrisisIOGroupNumber };
            crisisData.ResetInputOutputGroupNumber = new GalaxySMS.Business.Entities.InputOutputGroupNumber() { GroupNumber = data.Data.ResetCrisisIOGroupNumber };
            var crisis = new SendDataParameters<CrisisModeSettings>() { Data = crisisData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            var serverConsultationData = new ServerConsultationSettings();
            serverConsultationData.AccessDecisionTimeout = data.Data.AccessRuleOverrideTimeout;
            serverConsultationData.UnknownCredentialLookupTimeout = data.Data.UnlimitedCredentialTimeout;
            var serverConsultationSettings = new SendDataParameters<ServerConsultationSettings>() { Data = serverConsultationData, ApplicationUserSessionHeader = data.ApplicationUserSessionHeader, OperationUid = data.OperationUid };

            foreach (var c in conns)
            {
                c.SendAbaSettings(aba);
                c.SendWiegandSettings(wiegand);
                c.SendCardaxSettings(cardax);
                c.SendReaderLockoutSettings(lockout);
                //c.SendLoopTransmitDelaySettings();
                //c.SendTimeAdjustmentSettings();
                c.SendLedBehaviorSettings(led);
                c.SendCrisisModeSettings(crisis);
                c.SendServerConsultationSettings(serverConsultationSettings);
                //c.SendLoadDataFinished(aba, nameof(LoadDataToPanelSettings.ClusterSharedSettings));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an interface board section data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInterfaceBoardSectionData data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.Data.PanelNumber, (short)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}', Controller #: '{2}'.", data.Data.ClusterGroupId, data.Data.ClusterNumber, data.Data.PanelNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            foreach (var c in conns)
            {
                c.SendInterfaceBoardSectionData(data);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendResetCommand(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendResetCommand data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.SendToAddress.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId, data.SendToAddress.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for Account: '{0};, ClusterNumber '{1}', PanelNumber: '{2}', Cpu: '{3}'.",
                    data.SendToAddress.ClusterGroupId, data.SendToAddress.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            foreach (var c in conns)
            {
                c.SendResetCommand(data);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an input device settings to panel. </summary>
        ///
        /// <param name="data"> The data. </param>
        ///=================================================================================================

        public void SendInputDeviceSettingsToPanel(SendDataParameters<InputDevice_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), string.Format("The parameter SendInputDeviceSettingsToPanel data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.Data.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    $"There are no connections for ClusterGroupId: '{data.Data.ClusterGroupId}', Cluster #: '{data.Data.ClusterNumber}', Controller #: '{data.Data.PanelNumber}'.");
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            if (data.Collection.Any())
            {
                foreach (var o in data.Collection)
                {
                    o.Validate();
                    if (!o.IsValid)
                    {
                        throw new DataValidationException(o.ValidationErrors);
                    }
                }
            }

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            foreach (var c in conns)
            {
                c.SendInputDeviceData(data);
                //c.SendLoadDataFinished(data, "InputDevices");//nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));
            }

        }

        public void SendOutputDeviceSettingsToPanel(SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), string.Format("The parameter SendOutputDeviceSettingsToPanel data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.Data.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    $"There are no connections for ClusterGroupId: '{data.Data.ClusterGroupId}', Cluster #: '{data.Data.ClusterNumber}', Controller #: '{data.Data.PanelNumber}'.");
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            if (data.Collection.Any())
            {
                foreach (var o in data.Collection)
                {
                    o.Validate();
                    if (!o.IsValid)
                    {
                        throw new DataValidationException(o.ValidationErrors);
                    }
                }
            }

            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            foreach (var c in conns)
            {
                c.SendOutputDeviceData(data);
                //c.SendLoadDataFinished(data, "OutputDevices");//nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs));
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal settings to panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        /// <exception cref="DataValidationException">              Thrown when a Data Validation error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalSettingsToPanel(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalSettingsToPanel data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.Data.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}', Controller #: '{2}'.", data.Data.ClusterGroupId, data.Data.ClusterNumber, data.Data.PanelNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }


            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            foreach (var c in conns)
            {
                c.SendAccessPortalData(data);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access group settings to panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">                Thrown when one or more required
        ///                                                         arguments are null. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">    Thrown when a fault exception error
        ///                                                         condition occurs. </exception>
        /// <exception cref="DataValidationException">              Thrown when a Data Validation error
        ///                                                         condition occurs. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessGroupSettingsToPanels(SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessGroupSettingsToPanels data cannot be null"));
            if (data.SendToAddress.PanelNumber == 0)
                data.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;
            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, data.SendToAddress.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            //            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, (int)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", data.Data.ClusterGroupId, data.Data.ClusterNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }


            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            foreach (var c in conns)
            {
                c.SendAccessGroupData(data);
            }
        }
        public void SendAccessGroupToCpu(AccessGroup_PanelLoadDataChanges data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessGroupToCpu data cannot be null"));

            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.ClusterNumber, (int)data.PanelNumber, data.CpuNumber, data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                var ex = new NotFoundException(
                    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}', Panel #:{2}, Cpu #: {3}.", data.ClusterGroupId, data.ClusterNumber, data.ClusterNumber, data.PanelNumber, data.CpuNumber));
                var detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }


            data.Validate();
            if (!data.IsValid)
            {
                throw new DataValidationException(data.ValidationErrors);
            }


            foreach (var c in conns)
            {
                c.SendAccessGroupData(new SendDataParameters<AccessGroup_PanelLoadData>()
                {
                    SendToAddress = new BoardSectionNodeHardwareAddress()
                    {
                        ClusterGroupId = data.ClusterGroupId,
                        ClusterNumber = data.ClusterNumber,
                        PanelNumber = data.PanelNumber,
                        CpuId = data.CpuNumber
                    },
                    Data = data
                });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sends Date Type data to the panels. This could be for 15 or 1 minute based schedules.
        ///  For 15 minute schedules, the data must be loaded 1 month at a time, for minute based
        ///  schedules, the data must be loaded one year at a time.
        /// </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        ///                                             occurs. </exception>
        /// 
        /// <param name="data">             The data. </param>
        /// <param name="doMonth">          The do month. </param>
        /// <param name="defaultBehavior">  The default behavior. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDateTypeDataToPanels(IEnumerable<DateType_PanelLoadData> data, int doMonth, DateTypeDefaultBehavior_PanelLoadData defaultBehavior, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDateTypeDataToPanels data cannot be null"));

            if (!data.Any())
                return;

            var scheduleType = TimeScheduleType.GalaxyFifteenMinuteInterval;
            // Validate the data first
            foreach (var i in data)
            {
                scheduleType = (TimeScheduleType)i.ScheduleTypeCode;
                i.Validate();
                if (!i.IsValid)
                {
                    throw new DataValidationException(i.ValidationErrors);
                }
            }


            var distinctClusters = data.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
                .Select(y => new
                {
                    ClusterGroupId = y.Key.ClusterGroupId,
                    ClusterNumber = y.Key.ClusterNumber,
                }
            ).ToList();


            foreach (var cluster in distinctClusters)
            {
                var clusterDayTypeData = data.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();

                if (parameters.SendToAddress.PanelNumber == 0)
                    parameters.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;

                IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, parameters.SendToAddress.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                //                IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (int)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                if (conns == null || conns.Length == 0)
                {
                    //var ex = new NotFoundException(
                    //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                    //var detail = new ExceptionDetailEx(ex);
                    //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    foreach (var c in conns)
                    {
                        c.SendDayTypeData(clusterDayTypeData, doMonth, defaultBehavior, parameters);
                    }
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule data. </summary>
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

        public void SendTimeScheduleData(TimeSchedule_PanelLoadData data, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendTimeScheduleData data cannot be null"));

            if (!data.TimeSchedule15MinuteFormatGetPanelLoadData.Any() && !data.TimeScheduleOneMinuteFormatGetPanelLoadData.Any())
                return;

            // Validate the data first
            foreach (var s in data.TimeSchedule15MinuteFormatGetPanelLoadData)
            {
                s.Validate();
                if (!s.IsValid)
                {
                    throw new DataValidationException(s.ValidationErrors);
                }
            }

            foreach (var s in data.TimeScheduleOneMinuteFormatGetPanelLoadData)
            {
                s.Validate();
                if (!s.IsValid)
                {
                    throw new DataValidationException(s.ValidationErrors);
                }
            }

            // It is possible to have more than one schedule contained in the payload, so separate the data into groups by schedule
            var distinct15MinuteTimeSchedules = data.TimeSchedule15MinuteFormatGetPanelLoadData.GroupBy(x => x.TimeScheduleUid).ToList();

            foreach (var s in distinct15MinuteTimeSchedules)
            {
                var dayTypeTimePeriods = s.ToList();

                var distinctClusters = dayTypeTimePeriods.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
                    .Select(y => new
                    {
                        ClusterGroupId = y.Key.ClusterGroupId,
                        ClusterNumber = y.Key.ClusterNumber,
                    }
                    ).ToList();

                foreach (var cluster in distinctClusters)
                {
                    if (parameters.SendToAddress.PanelNumber == 0)
                        parameters.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;
                    //                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, parameters.SendToAddress.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    if (conns == null || conns.Length == 0)
                    {
                        //var ex = new NotFoundException(
                        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                        //var detail = new ExceptionDetailEx(ex);
                        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }
                    else
                    {
                        foreach (var c in conns)
                        {
                            c.SendTimeScheduleFifteenMinuteFormatData(dayTypeTimePeriods, parameters);
                            //c.SendLoadDataFinished(parameters, nameof(LoadDataToPanelSettings.TimeSchedules));
                        }
                    }
                }
            }

            // It is possible to have more than one schedule contained in the payload, so separate the data into groups by schedule
            var distinctOneMinuteTimeSchedules = data.TimeScheduleOneMinuteFormatGetPanelLoadData.GroupBy(x => x.TimeScheduleUid).ToList();

            foreach (var s in distinctOneMinuteTimeSchedules)
            {
                var dayTypeTimePeriods = s.ToList();

                var distinctClusters = dayTypeTimePeriods.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
                    .Select(y => new
                    {
                        ClusterGroupId = y.Key.ClusterGroupId,
                        ClusterNumber = y.Key.ClusterNumber,
                    }
                    ).ToList();

                foreach (var cluster in distinctClusters)
                {
                    var clusterDayTypeTimePeriods = dayTypeTimePeriods.Where(o =>
                        o.ClusterGroupId == cluster.ClusterGroupId && o.ClusterNumber == cluster.ClusterNumber).ToList();
                    if (parameters.SendToAddress.PanelNumber == 0)
                        parameters.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;
                    //                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, parameters.SendToAddress.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    if (conns == null || conns.Length == 0)
                    {
                        //var ex = new NotFoundException(
                        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                        //var detail = new ExceptionDetailEx(ex);
                        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }
                    else
                    {
                        foreach (var c in conns)
                        {
                            c.SendTimeScheduleOneMinuteFormatData(clusterDayTypeTimePeriods, parameters);
                            //c.SendLoadDataFinished(parameters, nameof(LoadDataToPanelSettings.TimeSchedules));
                        }
                    }
                }
            }

        }

        public void SendGalaxyPanelAlarmData(SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendGalaxyPanelAlarmData data cannot be null"));

            // Validate the data first
            foreach (var o in data.Collection)
            {
                o.Validate();
                if (!o.IsValid)
                {
                    throw new DataValidationException(o.ValidationErrors);
                }
            }

            var distinctPanelData = data.Collection.GroupBy(x => x.GalaxyPanelUid).ToList();

            foreach (var s in distinctPanelData)
            {
                var alerts = s.ToList();
                var o = alerts.FirstOrDefault();
                if (o != null)
                {
                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(o.ClusterNumber, o.PanelNumber, (short)CpuHardwareAddress.CpuNumber.Both, o.ClusterGroupId));
                    if (conns == null || conns.Length == 0)
                    {
                        //var ex = new NotFoundException(
                        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                        //var detail = new ExceptionDetailEx(ex);
                        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }
                    else
                    {

                        foreach (var c in conns)
                        {
                            var sendParams = new SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData>()
                            {
                                ApplicationUserSessionHeader = data.ApplicationUserSessionHeader,
                                Collection = alerts,
                                OperationUid = data.OperationUid
                            };
                            c.SendPanelAlarmSettings(sendParams);
                            //c.SendLoadDataFinished(sendParams, nameof(LoadDataToPanelSettings.PanelAlarms));

                        }
                    }
                }
            }

        }

        //public void SendLoadDataFinished(SendDataParameters<GalaxyPanel> data, string sHint)
        //{
        //    if (data == null)
        //        throw new ArgumentNullException("data", string.Format("The parameter SendLoadDataFinished data cannot be null"));

        //    // Validate the data first
        //    if (data.OperationUid == Guid.Empty)
        //        throw new DataValidationException($"{nameof(data.OperationUid)} cannot be {data.OperationUid}");

        //    var distinctPanelData = data.Collection.GroupBy(x => x.GalaxyPanelUid).ToList();

        //    foreach (var s in distinctPanelData)
        //    {
        //        var panels = s.ToList();
        //        var o = panels.FirstOrDefault();
        //        if (o != null)
        //        {
        //            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(o.ClusterNumber, o.PanelNumber, (short)CpuHardwareAddress.CpuNumber.Both, o.ClusterGroupId));
        //            if (conns == null || conns.Length == 0)
        //            {
        //                //var ex = new NotFoundException(
        //                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
        //                //var detail = new ExceptionDetailEx(ex);
        //                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
        //            }
        //            else
        //            {

        //                foreach (var c in conns)
        //                {
        //                    c.SendLoadDataFinished(new SendDataParameters()
        //                        {
        //                            ApplicationUserSessionHeader = data.ApplicationUserSessionHeader,
        //                            OperationUid = data.OperationUid
        //                        }, sHint);
        //                }
        //            }
        //        }
        //    }

        //}

        public void SendGalaxyInputOutputGroupData(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendGalaxyInputOutputGroupData data cannot be null"));

            // Validate the data first
            data.Data.Validate();
            if (!data.Data.IsValid)
            {
                throw new DataValidationException(data.Data.ValidationErrors);
            }


            IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.Data.ClusterNumber, (int)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, data.Data.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    c.SendInputOutputGroupData(data);
                }
            }
        }

        public void SendAllGalaxyClusterInputOutputGroupData(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            if (data == null || data.Collection == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAllGalaxyClusterInputOutputGroupData data cannot be null"));

            if (!data.Collection.Any())
                return;

            // Validate the data first
            foreach (var i in data.Collection)
            {
                i.Validate();
                if (!i.IsValid)
                {
                    throw new DataValidationException(i.ValidationErrors);
                }
            }

            IPanelConnection[] conns = FindConnections(data.SendToAddress);//FindConnections(new CpuHardwareAddress(first.ClusterNumber, (int)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, first.ClusterGroupId));
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    c.SetInputOutputGroupDataForLoading(data);
                    //c.SendLoadDataFinished(data, nameof(LoadDataToPanelSettings.InputOutputGroups));
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a galaxy time period data. </summary>
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

        public void SendGalaxyTimePeriodData(GalaxyTimePeriod_PanelLoadData data, SendDataParameters parameters)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendGalaxyTimePeriodData data cannot be null"));

            if (!data.PanelLoadData.Any())
                return;

            // Validate the data first
            foreach (var s in data.PanelLoadData)
            {
                s.Validate();
                if (!s.IsValid)
                {
                    throw new DataValidationException(s.ValidationErrors);
                }
            }

            // It is possible to have more than one galaxy time period contained in the payload, so separate the data into groups by time period
            var distinctTimePeriods = data.PanelLoadData.GroupBy(x => x.GalaxyTimePeriodUid).ToList();

            foreach (var s in distinctTimePeriods)
            {
                var gtps = s.ToList();

                var distinctClusters = gtps.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
                    .Select(y => new
                    {
                        ClusterGroupId = y.Key.ClusterGroupId,
                        ClusterNumber = y.Key.ClusterNumber,
                    }
                    ).ToList();

                foreach (var cluster in distinctClusters)
                {
                    if (parameters.SendToAddress.PanelNumber == 0)
                        parameters.SendToAddress.PanelNumber = (int)PanelNumber.AllPanels;
                    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, parameters.SendToAddress.PanelNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    //                   IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                    if (conns == null || conns.Length == 0)
                    {
                        //var ex = new NotFoundException(
                        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                        //var detail = new ExceptionDetailEx(ex);
                        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                    }
                    else
                    {
                        foreach (var c in conns)
                        {
                            c.SendOneMinuteTimePeriodData(gtps, parameters);
                        }
                    }
                }
            }
        }

        //public void SetPersonDataToSend(IEnumerable<Credential_PanelLoadData> personDataToSend, IList<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend, SendDataParameters parameters)
        //{
        //    var iG = personDataToSend.GroupBy(o => o.CpuUid);
        //    foreach (var g in iG)
        //    {
        //        var conn = _connections.Values.FirstOrDefault(o => o.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid == g.Key);
        //        if (conn != null)
        //        {
        //            conn.SendCredentialData(g.ToList());
        //        }
        //    }
        //}

        public void SetPersonDataToSend(IEnumerable<Credential_PanelLoadData> personDataToSend, IList<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend, SendDataParameters parameters)
        {
            var iG = personDataToSend.GroupBy(o => o.CpuUid);
            foreach (var g in iG)
            {
                var conn = _connections.Values.FirstOrDefault(o => o.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid == g.Key);
                if (conn != null)
                {
                    //conn.SendCredentialData(new SendDataParameters<List<Credential_PanelLoadData>>(parameters)
                    //{
                    //    Data = personDataToSend.ToList()
                    //});
                    conn.SendCredentialData(new SendDataParameters<List<Credential_PanelLoadData>>(parameters)
                    {
                        Data = g.ToList()
                    });
                    if (personalAccessGroupDataToSend.Any())
                    {
                        conn.SendPersonalAccessGroupData(new SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>>(parameters)
                        {
                            Data = personalAccessGroupDataToSend.GroupBy(o => o.PersonUid).ToList()
                        });
                    }
                }
            }
        }

        public void SendDeleteCredentialData(IEnumerable<CredentialToDeleteFromCpu> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendDeleteCredentialData data cannot be null"));

            if (!data.Any())
                return;

            // Validate the data first
            //foreach (var i in data)
            //{
            //    if (!i.IsValid)
            //    {
            //        throw new DataValidationException(i.ValidationErrors);
            //    }
            //}

            var deleteCredentialsByCpuUid = data.GroupBy(x => new { x.ClusterNumber, x.PanelNumber, x.CpuNumber, x.ClusterGroupId }).Select(y => new { ClusterNumber = y.Key.ClusterNumber, PanelNumber = y.Key.PanelNumber, CpuNumber = y.Key.CpuNumber, ClusterGroupId = y.Key.ClusterGroupId }).ToList();


            foreach (var cpu in deleteCredentialsByCpuUid)
            {
                IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cpu.ClusterNumber, cpu.PanelNumber, (short)cpu.CpuNumber, cpu.ClusterGroupId));
                if (conns == null || conns.Length == 0)
                {
                    //var ex = new NotFoundException(
                    //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                    //var detail = new ExceptionDetailEx(ex);
                    //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    foreach (var c in conns)
                    {
                        foreach (var credToDelete in data.Where(x => x.CpuUid == c.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid).ToList())
                            c.SendDeleteCredential(credToDelete.CardBinaryData);
                    }
                }
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Sends a credential data. </summary>
        ///// 
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        ///// 
        ///// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        /////                                             null. </exception>
        ///// <exception cref="DataValidationException">  Thrown when a Data Validation error condition
        /////                                             occurs. </exception>
        ///// <param name="data"> The data. </param>
        ///// <param name="personalAccessGroupData"></param>
        ///// <param name="sendToAddress"></param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void SendCredentialData(IEnumerable<Credential_PanelLoadData> data, IEnumerable<PersonalAccessGroup_PanelLoadData> personalAccessGroupData, CpuHardwareAddress sendToAddress)
        //{
        //    if (data == null)
        //        throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

        //    if (!data.Any())
        //        return;

        //    // Validate the data first
        //    foreach (var i in data)
        //    {
        //        i.Validate();
        //        if (!i.IsValid)
        //        {
        //            throw new DataValidationException(i.ValidationErrors);
        //        }
        //    }

        //    // validate the personal access group rows
        //    foreach (var i in personalAccessGroupData)
        //    {
        //        i.Validate();
        //        if (!i.IsValid)
        //        {
        //            throw new DataValidationException(i.ValidationErrors);
        //        }
        //    }

        //    var distinctClusters = data.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
        //        .Select(y => new
        //        {
        //            ClusterGroupId = y.Key.ClusterGroupId,
        //            ClusterNumber = y.Key.ClusterNumber,
        //        }
        //    ).ToList();


        //    var distinctPersonalAccessGroupClusters = personalAccessGroupData.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
        //        .Select(y => new
        //        {
        //            ClusterGroupId = y.Key.ClusterGroupId,
        //            ClusterNumber = y.Key.ClusterNumber,
        //        }
        //    ).ToList();

        //    foreach (var cluster in distinctClusters)
        //    {
        //        //IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
        //        if (sendToAddress.PanelNumber == 0)
        //            sendToAddress.PanelNumber = (int)CpuHardwareAddress.SystemPanelAddress.AllPanels;
        //        if (sendToAddress.CpuId == 0)
        //            sendToAddress.CpuId = (short)CpuHardwareAddress.CpuNumber.Both;

        //        IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, sendToAddress.PanelNumber, sendToAddress.CpuId, cluster.ClusterGroupId));
        //        if (conns == null || conns.Length == 0)
        //        {
        //            //var ex = new NotFoundException(
        //            //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
        //            //var detail = new ExceptionDetailEx(ex);
        //            //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
        //        }
        //        else
        //        {
        //            // Pick out the credential data for this cluster
        //            var clusterCredentialData = data.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();


        //            // Pick out the personal access group data for this cluster
        //            var pagData = personalAccessGroupData.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();

        //            foreach (var c in conns)
        //            {
        //                c.SendCredentialData(clusterCredentialData);
        //                if (pagData != null)
        //                {
        //                    // select only those records for this panel
        //                    var panelPagData = pagData.Where(i => i.PanelNumber == c.PanelId).ToList();
        //                    if (panelPagData.Any())
        //                        c.SendPersonalAccessGroupData(panelPagData);
        //                }
        //            }
        //        }
        //    }


        //}

        public void SendCredentialData(SendDataParameters<List<Credential_PanelLoadData>> data, SendDataParameters<List<PersonalAccessGroup_PanelLoadData>> personalAccessGroupData)
        {
            if (data == null || data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

            if (!data.Data.Any())
                return;

            // Validate the data first
            foreach (var i in data.Data)
            {
                i.Validate();
                if (!i.IsValid)
                {
                    throw new DataValidationException(i.ValidationErrors);
                }
            }

            // validate the personal access group rows
            foreach (var i in personalAccessGroupData.Data)
            {
                i.Validate();
                if (!i.IsValid)
                {
                    throw new DataValidationException(i.ValidationErrors);
                }
            }

            var distinctClusters = data.Data.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
                .Select(y => new
                {
                    ClusterGroupId = y.Key.ClusterGroupId,
                    ClusterNumber = y.Key.ClusterNumber,
                }
            ).ToList();


            //var distinctPersonalAccessGroupClusters = personalAccessGroupData.Data.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
            //    .Select(y => new
            //    {
            //        ClusterGroupId = y.Key.ClusterGroupId,
            //        ClusterNumber = y.Key.ClusterNumber,
            //    }
            //).ToList();

            foreach (var cluster in distinctClusters)
            {
                //IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
                if (data.SendToAddress.PanelNumber == 0)
                    data.SendToAddress.PanelNumber = (int)CpuHardwareAddress.SystemPanelAddress.AllPanels;
                if (data.SendToAddress.CpuId == 0)
                    data.SendToAddress.CpuId = (short)CpuHardwareAddress.CpuNumber.Both;

                IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId, cluster.ClusterGroupId));
                if (conns == null || conns.Length == 0)
                {
                    //var ex = new NotFoundException(
                    //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                    //var detail = new ExceptionDetailEx(ex);
                    //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    // Pick out the credential data for this cluster

                    var clusterCredentialData = new SendDataParameters<List<Credential_PanelLoadData>>(data)
                    {
                        Data = data.Data.Where(i =>
                                i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber)
                            .ToList()

                    };

                    // Pick out the personal access group data for this cluster
                    var pagData = personalAccessGroupData.Data.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();

                    foreach (var c in conns)
                    {
                        var sendThis = new SendDataParameters<List<Credential_PanelLoadData>>(clusterCredentialData)
                        { Data = clusterCredentialData.Data.ToList() };
                        c.SendCredentialData(sendThis);
                        if (pagData != null)
                        {
                            // select only those records for this panel
                            var panelPagData =
                                new SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>>(personalAccessGroupData)
                                {
                                    Data = pagData.Where(i => i.PanelNumber == c.PanelId).GroupBy(i => i.PersonUid).ToList()

                                };
                            if (panelPagData.Data.Any())
                            {
                                //               c.SendPersonalAccessGroupData(panelPagData);
                                c.SendPersonalAccessGroupData(panelPagData);
                            }
                        }
                        //c.SendLoadDataFinished(sendThis, nameof(LoadDataToPanelSettings.AllCardData));

                    }
                }
            }


        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a CPU command to panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCpuCommandToPanels(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case GalaxyCpuCommandActionCode.ResetCpuWarm:
                            c.SendResetCommand(new SendDataParameters<GalaxyPanelResetCommand>()
                            {
                                Data = new GalaxyPanelResetCommand() { ResetType = CpuResetType.WarmReset }
                            });
                            break;
                        case GalaxyCpuCommandActionCode.ResetCpuCold:
                            c.SendResetCommand(new SendDataParameters<GalaxyPanelResetCommand>()
                            {
                                Data = new GalaxyPanelResetCommand() { ResetType = CpuResetType.ColdReset }
                            });
                            break;
                        case GalaxyCpuCommandActionCode.EnableDaughterBoardFlashUpdate:
                            c.SendClearAutoUpdateFlashTimer(data);
                            break;
                        case GalaxyCpuCommandActionCode.ClearAllCredentials:
                            c.SendClearAllCredentials(data);
                            break;
                        case GalaxyCpuCommandActionCode.Ping:
                            c.SendPing(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestControllerInformation:
                            c.SendGetControllerInfo(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestCredentialCount:
                            c.SendGetCardCount(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestLoggingInformation:
                            c.SendGetLoggingInfo(data);
                            break;
                        case GalaxyCpuCommandActionCode.ForgivePassbackForCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                    newData.OperationUid = data.OperationUid;
                                    newData.Data.CredentialBytes = data.Data.CredentialBytesList[x].DeepCopy();
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytes);
                                    newData.Data.CredentialUid = data.Data.CredentialUids[x];
                                    newData.Data.CredentialUids.Add(newData.Data.CredentialUid);
                                    c.SendForgivePassbackForCredential(newData.Data.CredentialBytes, newData);
                                }
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendForgivePassbackForCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.ForgivePassbackForAllCredentials:
                            c.SendForgivePassbackForAllCredentials(data);
                            break;
                        case GalaxyCpuCommandActionCode.RecalibrateInputsAndOutputs:
                            c.SendRecalibrateInputsAndOutputs(data);
                            break;
                        case GalaxyCpuCommandActionCode.ActivateCrisisMode:
                            c.SendActivateCrisisMode(data);
                            break;
                        case GalaxyCpuCommandActionCode.ResetCrisisMode:
                            c.SendResetCrisisMode(data);
                            break;
                        case GalaxyCpuCommandActionCode.EnableCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                    newData.OperationUid = data.OperationUid;
                                    newData.Data.CredentialBytes = data.Data.CredentialBytesList[x].DeepCopy();
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytes);
                                    newData.Data.CredentialUid = data.Data.CredentialUids[x];
                                    newData.Data.CredentialUids.Add(newData.Data.CredentialUid);
                                    c.SendEnableCredential(newData.Data.CredentialBytes, newData);
                                }
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendEnableCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.DisableCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                    newData.OperationUid = data.OperationUid;
                                    newData.Data.CredentialBytes = data.Data.CredentialBytesList[x].DeepCopy();
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytes);
                                    newData.Data.CredentialUid = data.Data.CredentialUids[x];
                                    newData.Data.CredentialUids.Add(newData.Data.CredentialUid);
                                    c.SendDisableCredential(newData.Data.CredentialBytes, newData);
                                }
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendDisableCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestInputOutputGroupCounters:
                            c.SendRequestInputOutputGroupCounters(data.Data.InputOutputGroupNumber, data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestBoardInformation:
                            data.Data.CommandUid = GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_RequestBoardInformation;
                            c.SendRequestBoardInformation(data);
                            break;
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cluster command to panels. </summary>
        ///
        /// <remarks>   Kevin, 1/7/2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClusterCommandToPanels(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendClusterCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendClusterCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case GalaxyCpuCommandActionCode.ResetCpuWarm:
                            c.SendResetCommand(new SendDataParameters<GalaxyPanelResetCommand>()
                            {
                                Data = new GalaxyPanelResetCommand() { ResetType = CpuResetType.WarmReset }
                            });
                            break;
                        case GalaxyCpuCommandActionCode.ResetCpuCold:
                            c.SendResetCommand(new SendDataParameters<GalaxyPanelResetCommand>()
                            {
                                Data = new GalaxyPanelResetCommand() { ResetType = CpuResetType.ColdReset }
                            });
                            break;
                        case GalaxyCpuCommandActionCode.EnableDaughterBoardFlashUpdate:
                            c.SendClearAutoUpdateFlashTimer(data);
                            break;
                        case GalaxyCpuCommandActionCode.ClearAllCredentials:
                            c.SendClearAllCredentials(data);
                            break;
                        case GalaxyCpuCommandActionCode.Ping:
                            c.SendPing(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestControllerInformation:
                            c.SendGetControllerInfo(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestCredentialCount:
                            c.SendGetCardCount(data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestLoggingInformation:
                            c.SendGetLoggingInfo(data);
                            break;
                        case GalaxyCpuCommandActionCode.ForgivePassbackForCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                newData.OperationUid = data.OperationUid;
                                newData.Data.CommandAction = data.Data.CommandAction;

                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytesList[x].DeepCopy());
                                    newData.Data.CredentialUids.Add(data.Data.CredentialUids[x]);
                                }
                                foreach (var cb in data.Data.CredentialBytesList)
                                    c.SendForgivePassbackForCredential(cb, newData);
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendForgivePassbackForCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.ForgivePassbackForAllCredentials:
                            c.SendForgivePassbackForAllCredentials(data);
                            break;
                        case GalaxyCpuCommandActionCode.RecalibrateInputsAndOutputs:
                            c.SendRecalibrateInputsAndOutputs(data);
                            break;
                        case GalaxyCpuCommandActionCode.ActivateCrisisMode:
                            c.SendActivateCrisisMode(data);
                            break;
                        case GalaxyCpuCommandActionCode.ResetCrisisMode:
                            c.SendResetCrisisMode(data);
                            break;
                        case GalaxyCpuCommandActionCode.EnableCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                newData.OperationUid = data.OperationUid;
                                newData.Data.CommandAction = data.Data.CommandAction;

                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytesList[x].DeepCopy());
                                    newData.Data.CredentialUids.Add(data.Data.CredentialUids[x]);
                                }
                                foreach (var cb in data.Data.CredentialBytesList)
                                    c.SendEnableCredential(cb, newData);
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendEnableCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.DisableCredential:
                            if (data.Data.CredentialBytesList != null && data.Data.CredentialBytesList.Any())
                            {
                                var newData = new SendDataParameters<GalaxyCpuCommandAction>();
                                newData.OperationUid = data.OperationUid;
                                newData.Data.CommandAction = data.Data.CommandAction;
                                for (int x = 0; x < data.Data.CredentialBytesList.Count; x++)
                                {
                                    newData.Data.CredentialBytesList.Add(data.Data.CredentialBytesList[x].DeepCopy());
                                    newData.Data.CredentialUids.Add(data.Data.CredentialUids[x]);
                                }
                                foreach (var cb in data.Data.CredentialBytesList)
                                    c.SendDisableCredential(cb, newData);
                            }
                            else if (data.Data.CredentialUid != Guid.Empty)
                                c.SendDisableCredential(data.Data.CredentialBytes, data);
                            break;
                        case GalaxyCpuCommandActionCode.ClearLoggingBuffer:
                            c.SendClearLoggingBuffer(data);
                            break;
                        case GalaxyCpuCommandActionCode.RetransmitLoggingBuffer:
                            c.SendRetransmitLoggingBuffer(data);
                            break;
                        case GalaxyCpuCommandActionCode.StartLogging:
                            c.SetLoggingState(ActivityLoggingState.On, data);
                            break;
                        case GalaxyCpuCommandActionCode.StopLogging:
                            c.SetLoggingState(ActivityLoggingState.Off, data);
                            break;
                        case GalaxyCpuCommandActionCode.RequestInputOutputGroupCounters:
                            break;
                        case GalaxyCpuCommandActionCode.RequestBoardInformation:
                            c.SendRequestBoardInformation(data);
                            break;
                        case GalaxyCpuCommandActionCode.BeginFlashLoad:
                            break;
                        case GalaxyCpuCommandActionCode.ValidateFlash:
                            break;
                        case GalaxyCpuCommandActionCode.ValidateAndBurnFlash:
                            break;
                            //case GalaxyCpuCommandActionCode.RequestInputOutputGroupCounters:
                            //    c.SendRequestInputOutputGroupCounters(data.Data.InputOutputGroupNumber);
                            //    break;
                            //case GalaxyCpuCommandActionCode.RequestBoardInformation:
                            //    c.SendRequestBoardInformation(data.ApplicationUserSessionHeader.SessionGuid);
                            //    break;
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a galaxy load flash command to panels. </summary>
        ///
        /// <remarks>   Kevin, 4/5/2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">        Thrown when one or more required arguments
        ///                                                 are null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async void SendGalaxyLoadFlashCommandToPanels(SendDataParameters<GalaxyLoadFlashCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendGalaxyLoadFlashCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendGalaxyLoadFlashCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}
            GalaxyFlashImageHelper flashImageHelper = null;
            switch (data.Data.CommandAction)
            {
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoad:
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoadAutoValidateFlashData:
                case GalaxyLoadFlashCommandActionCode.BeginFlashLoadAutoValidateAndBurnFlashData:
                    flashImageHelper = await Globals.Instance.GetGalaxyFlashImage(data.Data.GalaxyFlashImageUid);   // preload the flash data
                    break;
                case GalaxyLoadFlashCommandActionCode.CancelFlashLoad:
                    break;
                case GalaxyLoadFlashCommandActionCode.ValidateFlashData:
                    break;
                case GalaxyLoadFlashCommandActionCode.ValidateAndBurnFlashData:
                    break;
                case GalaxyLoadFlashCommandActionCode.PauseFlashLoad:
                    break;
                case GalaxyLoadFlashCommandActionCode.ResumeFlashLoad:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {

                foreach (var c in conns)
                {
                    if (flashImageHelper != null)
                        c.SendFlashCommand(data.Data, new GalaxyFlashImageHelper(flashImageHelper));
                    else
                        c.SendFlashCommand(data.Data, flashImageHelper);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal command to panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalCommandToPanels(SendDataParameters<AccessPortalCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendAccessPortalCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case AccessPortalCommandActionCode.None:
                            break;
                        case AccessPortalCommandActionCode.Pulse:
                        case AccessPortalCommandActionCode.Unlock:
                        case AccessPortalCommandActionCode.Lock:
                        case AccessPortalCommandActionCode.Enable:
                        case AccessPortalCommandActionCode.Disable:
                        case AccessPortalCommandActionCode.AuxRelayOn:
                        case AccessPortalCommandActionCode.AuxRelayOff:
                        case AccessPortalCommandActionCode.SetLedTemporaryState:
                        case AccessPortalCommandActionCode.RequestStatus:
                            c.SendAccessPortalCommand(data);
                            break;
                    }
                }
            }
        }

        public void SendInputDeviceCommandToPanels(SendDataParameters<InputDeviceCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputDeviceCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputDeviceCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case InputDeviceCommandActionCode.None:
                            break;
                        case InputDeviceCommandActionCode.Shunt:
                        case InputDeviceCommandActionCode.Unshunt:
                        case InputDeviceCommandActionCode.Enable:
                        case InputDeviceCommandActionCode.Disable:
                        case InputDeviceCommandActionCode.RequestStatus:
                        case InputDeviceCommandActionCode.ReadVoltages:
                            c.SendInputDeviceCommand(data);
                            break;
                    }
                }
            }
        }

        public void SendOutputDeviceCommandToPanels(SendDataParameters<OutputDeviceCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendOutputDeviceCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendOutputDeviceCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case OutputDeviceCommandActionCode.None:
                            break;
                        case OutputDeviceCommandActionCode.Off:
                        case OutputDeviceCommandActionCode.On:
                        case OutputDeviceCommandActionCode.Enable:
                        case OutputDeviceCommandActionCode.Disable:
                        case OutputDeviceCommandActionCode.RequestStatus:
                            c.SendOutputDeviceCommand(data);
                            break;
                    }
                }
            }
        }

        public void SendBoardSectionCommandToPanels(SendDataParameters<GalaxyInterfaceBoardSectionCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendBoardSectionCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendBoardSectionCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case GalaxyInterfaceBoardSectionCommandActionCode.None:
                            break;
                        case GalaxyInterfaceBoardSectionCommandActionCode.RequestSerialChannelRS485DeviceInfo:
                            c.SendInterfaceBoardSectionCommand(data);
                            break;
                    }
                }
            }
        }

        public void SendInputOutputGroupCommandToPanels(SendDataParameters<InputOutputGroupCommandAction> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputOutputGroupCommandToPanels data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendInputOutputGroupCommandToPanels data.Data cannot be null"));

            // Validate the data first

            //data.Data.Validate();
            //if (!data.Data.IsValid)
            //{
            //    throw new DataValidationException(data.Data.ValidationErrors);
            //}


            IPanelConnection[] conns = FindConnections(data.SendToAddress);
            if (conns == null || conns.Length == 0)
            {
                //var ex = new NotFoundException(
                //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
                //var detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }
            else
            {
                foreach (var c in conns)
                {
                    switch (data.Data.CommandAction)
                    {
                        case InputOutputGroupCommandActionCode.Arm:
                        case InputOutputGroupCommandActionCode.Disarm:
                        case InputOutputGroupCommandActionCode.Shunt:
                        case InputOutputGroupCommandActionCode.Unshunt:
                        case InputOutputGroupCommandActionCode.UnlockAccessPortals:
                        case InputOutputGroupCommandActionCode.LockAccessPortals:
                        case InputOutputGroupCommandActionCode.EnableAccessPortals:
                        case InputOutputGroupCommandActionCode.DisableAccessPortals:
                            c.SendInputOutputGroupCommand(data);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public void SendCpuDatabaseDataToConnection(SendDataParameters<GalaxyCpuDatabaseInformation> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuDatabaseDataToConnection data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuDatabaseDataToConnection data.Data cannot be null"));

            data.SendToAddress.CpuModel = CpuModel.Cpu635;
            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.ClusterUid = data.Data.ClusterUid;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.PanelUid = data.Data.GalaxyPanelUid;
            data.SendToAddress.CpuId = data.Data.CpuNumber;
            data.SendToAddress.CpuUid = data.Data.CpuUid;
            //           data.Data.PanelModelTypeCode

            var conns = FindConnectionsNotInDb(data.SendToAddress);
            if (conns != null && conns.Length > 0)
            {
                foreach (var conn in conns)
                {
                    conn.TakeAction(ActionCode.RefreshCpuDatabaseInformation, 100);
                    //Task.Run(async () =>
                    // {
                    //     await conn.SetCpuDatabaseInformation(data.Data);
                    // }).Wait();
                }
            }
        }

        public void SendPanelDatabaseDataToConnection(SendDataParameters<GalaxyCpuDatabaseInformation> data)
        {
            if (data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuDatabaseDataToConnection data cannot be null"));

            if (data.Data == null)
                throw new ArgumentNullException("data", string.Format("The parameter SendCpuDatabaseDataToConnection data.Data cannot be null"));

            data.SendToAddress.CpuModel = CpuModel.Cpu635;
            data.SendToAddress.ClusterGroupId = data.Data.ClusterGroupId;
            data.SendToAddress.ClusterNumber = data.Data.ClusterNumber;
            data.SendToAddress.ClusterUid = data.Data.ClusterUid;
            data.SendToAddress.PanelNumber = data.Data.PanelNumber;
            data.SendToAddress.PanelUid = data.Data.GalaxyPanelUid;
            data.SendToAddress.CpuId = data.Data.CpuNumber;
            data.SendToAddress.CpuUid = data.Data.CpuUid;
            //           data.Data.PanelModelTypeCode

            var conns = FindConnections(data.SendToAddress);
            if (conns != null && conns.Length > 0)
            {
                foreach (var conn in conns)
                {
                    conn.TakeAction(ActionCode.RefreshCpuDatabaseInformation, 100);
                    //Task.Run(async () =>
                    // {
                    //     await conn.SetCpuDatabaseInformation(data.Data);
                    // }).Wait();
                }
            }
        }

        #endregion

        #region Private Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Begins an operation to accept a connection request from the client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="acceptEventArg">   The context object to use when issuing the accept operation
        ///                                 on the server's listening socket. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                // socket must be cleared since the context object is being reused
                acceptEventArg.AcceptSocket = null;
            }

            _maxNumberAcceptedClients.WaitOne();
            if (_listenSocket != null)
            {
                bool willRaiseEvent = _listenSocket.AcceptAsync(acceptEventArg);
                if (!willRaiseEvent)
                {
                    ProcessAccept(acceptEventArg);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes the server by preallocating reusable buffers and context objects.  These objects
        /// do not need to be preallocated or reused, by is done this way to illustrate how the API can
        /// easily be used to create reusable objects to increase server performance.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void Init()
        {
            // Allocates one large byte buffer which all I/O operations use a piece of.  This gaurds 
            // against memory fragmentation
            _bufferManager.InitBuffer();

            // preallocate pool of SocketAsyncEventArgs objects
            SocketAsyncEventArgs readWriteEventArg;

            for (int i = 0; i < _numConnections; i++)
            {
                //Pre-allocate a set of reusable SocketAsyncEventArgs
                readWriteEventArg = new SocketAsyncEventArgs();
                readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                readWriteEventArg.UserToken = new AsyncUserToken();

                // assign a byte buffer from the buffer pool to the SocketAsyncEventArg object
                _bufferManager.SetBuffer(readWriteEventArg);

                // add SocketAsyncEventArg to the pool
                _readWritePool.Push(readWriteEventArg);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This method is the callback method associated with Socket.AcceptAsync operations and is
        /// invoked when an accept operation is complete.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            string sDbg = string.Empty;
            if (e.AcceptSocket != null)
            {
                string sRemoteEndpointAddress = string.Empty;
                if (e.AcceptSocket.RemoteEndPoint != null)
                    sRemoteEndpointAddress = e.AcceptSocket.RemoteEndPoint.ToString();
                sDbg = string.Format("AcceptEventArg_Completed(e):{6}, AcceptSocket.Connected:{0}; Available:{1}; IsBound:{2}; ConnectSocket:{3}; LastOperation:{4}; SocketError:{5} ",
                    e.AcceptSocket.Connected,
                    e.AcceptSocket.Available,
                    e.AcceptSocket.IsBound,
                    e.ConnectSocket,
                    e.LastOperation,
                    e.SocketError,
                    sRemoteEndpointAddress);

                if (e.AcceptSocket.Connected == true && e.AcceptSocket.IsBound == true && e.LastOperation == SocketAsyncOperation.Accept && e.SocketError == SocketError.Success)
                    ProcessAccept(e);
            }
            //GCS.Framework.Logging.LogWriter.Trace(sDbg);
            this.Log().Debug(sDbg);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the accept described by e. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            Task task1 = new Task(delegate
            {
                Interlocked.Increment(ref _numConnectedSockets);
                // Get the socket for the accepted client connection and put it into the 
                //ReadEventArg object user token
                SocketAsyncEventArgs readEventArgs = _readWritePool.Pop();
                ((AsyncUserToken)readEventArgs.UserToken).Socket = e.AcceptSocket;

                // Create an Connection6xx object and store it in a collection keyed to the socket handle
                Connection6xx clientConnection;
                if (EncryptionEnabled == true)
                    //clientConnection = new Connection6xx(this, e, PanelProtocols.CryptoType.Aes, _aesEncryptionPhrase, _processingQueue, _recordingQueue, _siteServerConnection);
                    clientConnection = new Connection6xx(new Connection6xxParameters(this, e, PanelProtocols.CryptoType.Aes, _aesEncryptionPhrase, _processingQueue, _recordingQueue, _serverAddress, _ackLogMessageIndexMinimumInterval, _operationTimeoutSecondsDefaultValue));
                else
                    //clientConnection = new Connection6xx(this, e, PanelProtocols.CryptoType.None, string.Empty, _processingQueue, _recordingQueue, _siteServerConnection);
                    clientConnection = new Connection6xx(new Connection6xxParameters(this, e, PanelProtocols.CryptoType.None, string.Empty, _processingQueue, _recordingQueue, _serverAddress, _ackLogMessageIndexMinimumInterval, _operationTimeoutSecondsDefaultValue));

                clientConnection.DebugPacketEvent += clientConnection_DebugPacketEvent;
                clientConnection.DataReceivedEvent += clientConnection_DataReceivedEvent;
                clientConnection.PanelToPanelPacketReceivedEvent += clientConnection_PanelToPanelPacketReceivedEvent;
                clientConnection.ConnectionStateChangedEvent += clientConnection_ConnectionStateChangedEvent;
                clientConnection.ConnectionClosedEvent += clientConnection_ConnectionClosedEvent;
                clientConnection.PanelInformationEvent += clientConnection_PanelInformationEvent;

                AddConnectionToCollections(readEventArgs, clientConnection);

                this.Log().DebugFormat("Client has been connected to the server. {0}", clientConnection.InstanceGuid);
                this.Log().DebugFormat("numConnectedSockets:{0}; connections.Count:{1}", _numConnectedSockets, _connections.Count);

                // As soon as the client is connected, post a receive to the connection
                try
                {
                    bool willRaiseEvent = e.AcceptSocket.ReceiveAsync(readEventArgs);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(readEventArgs);
                    }
                }
                catch (Exception ex)
                {
                    this.Log().Debug("ProcessAccept exception", ex);
                }

                // Accept the next connection request
                StartAccept(e);
                //}
            });
            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by clientConnection for connection closed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void clientConnection_ConnectionClosedEvent(object sender, SocketAsyncEventArgs e)
        {
            CloseClientSocket(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a connection to collections to 'clientConnection'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="readEventArgs">    Socket asynchronous event information. </param>
        /// <param name="clientConnection"> The client connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AddConnectionToCollections(SocketAsyncEventArgs readEventArgs, IPanelConnection clientConnection)
        {

            bool bAdded = _connections.TryAdd(readEventArgs, clientConnection);
            _cpuConnections.Add(clientConnection.CpuConnectionInfo);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the 5xx connect completed. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Process5xxConnectCompleted(object sender, SocketAsyncEventArgs e)
        {
            Task task1 = new Task(delegate
            {
                if (e.ConnectSocket.Connected == true)
                {
                    Interlocked.Increment(ref _numConnectedSockets);
                    // Get the socket for the connection and put it into the 
                    //ReadEventArg object user token
                    SocketAsyncEventArgs readEventArgs = _readWritePool.Pop();
                    ((AsyncUserToken)readEventArgs.UserToken).Socket = e.ConnectSocket;

                    // Create an Connection5xx object and store it in a collection keyed to the socket handle
                    Connection5xx clientConnection;
                    clientConnection = new Connection5xx(this, e, ((AsyncUserToken)e.UserToken).ClusterConnectionParameters, _processingQueue);

                    clientConnection.DebugPacketEvent += clientConnection_DebugPacketEvent;
                    clientConnection.DataReceivedEvent += clientConnection_DataReceivedEvent;
                    //			clientConnection.PanelToPanelPacketReceivedEvent += clientConnection_PanelToPanelPacketReceivedEvent;
                    clientConnection.ConnectionStateChangedEvent += clientConnection_ConnectionStateChangedEvent;
                    clientConnection.ConnectionClosedEvent += clientConnection_ConnectionClosedEvent;
                    clientConnection.PanelInformationEvent += clientConnection_PanelInformationEvent;
                    AddConnectionToCollections(readEventArgs, clientConnection);

                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("Client has been connected to the server. {0}", clientConnection.InstanceGuid));
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("numConnectedSockets:{0}; connections.Count:{1}", _numConnectedSockets, connections.Count));

                    this.Log().DebugFormat("Client has been connected to the server. {0}", clientConnection.InstanceGuid);
                    this.Log().DebugFormat("numConnectedSockets:{0}; connections.Count:{1}", _numConnectedSockets, _connections.Count);

                    // As soon as the socket is connected, post a receive to the connection
                    bool willRaiseEvent = e.ConnectSocket.ReceiveAsync(readEventArgs);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(readEventArgs);
                    }
                }
                else
                {
                    this.Log().DebugFormat("Process5xxConnectCompleted failed to connect on Thread 0x{0:X}",
                        System.Threading.Thread.CurrentThread.ManagedThreadId);
                }
            });
            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by clientConnection for debug packet events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Connection debug packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void clientConnection_DebugPacketEvent(object sender, ConnectionDebugPacketEventArgs e)
        {
            Task task1 = new Task(delegate
            {
                var handler = DebugPacketEvent;
                if (handler != null)
                {
                    handler(sender, e);
                }
            });
            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by clientConnection for connection state changed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Connection state change event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void clientConnection_ConnectionStateChangedEvent(object sender, ConnectionStateChangeEventArgs e)
        {
            RaiseConnectionStateChangedEvent(sender, e);
            if (e.ConnectionInfo.IsConnected == false)
            {   // Remove from collections

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by clientConnection for panel information events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel information event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void clientConnection_PanelInformationEvent(object sender, PanelInformationEventArgs e)
        {
            RaisePanelInformationEvent(sender, e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by clientConnection for panel to panel packet received events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel data packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void clientConnection_PanelToPanelPacketReceivedEvent(object sender, PanelProtocols.Series6xx.PanelDataPacketEventArgs e)
        {
            Task task1 = new Task(delegate
            {
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("clientConnection_PanelToPanelPacketReceivedEvent on Thread 0x{0:X} - packet for distribution to other panels",
                //    System.Threading.Thread.CurrentThread.ManagedThreadId));
                this.Log().InfoFormat("clientConnection_PanelToPanelPacketReceivedEvent on Thread 0x{0:X} - packet for distribution to other panels",
                    System.Threading.Thread.CurrentThread.ManagedThreadId);
                CpuHardwareAddress addr;
                IPanelConnection[] conns;

                switch (e.Packet.Distribute)
                {
                    case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToAllPanels:
                        addr = new CpuHardwareAddress(e.Packet.ClusterId, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, e.ClusterGroupId);
                        conns = FindConnections(addr);
                        foreach (IPanelConnection c in conns)
                        {
                            if (c.PanelId == e.Packet.PanelId &&
                                c.CpuId == (uint)e.Packet.Cpu)
                            {
                                continue;
                            }
                            c.SendPacket(e.Packet);
                        }
                        break;

                    case GCS.PanelProtocols.Series6xx.PacketDistribution.FromPanelToSpecificPanel:
                        addr = new CpuHardwareAddress(e.Packet.ClusterId, e.Packet.BoardNumber, (Int32)CpuHardwareAddress.CpuNumber.Both, e.ClusterGroupId);
                        conns = FindConnections(addr);

                        foreach (IPanelConnection c in conns)
                        {
                            if (c.PanelId != e.Packet.PanelId &&
                                c.CpuId != (uint)e.Packet.Cpu)
                            {
                                c.SendPacket(e.Packet);
                            }
                        }
                        break;
                }
            });
            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by clientConnection for data received events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data received event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void clientConnection_DataReceivedEvent(object sender, DataReceivedEventArgs e)
        {
            //GCS.Framework.Logging.LogWriter.Trace(string.Format("clientConnection_DataReceivedEvent on Thread 0x{0:X}",
            //    System.Threading.Thread.CurrentThread.ManagedThreadId));
            this.Log().DebugFormat("clientConnection_DataReceivedEvent on Thread 0x{0:X}",
                System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This method is called whenever a receive or send opreation is completed on a socket.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentException">    Thrown when one or more arguments have unsupported or
        ///                                         illegal values. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        SocketAsyncEventArg associated with the completed receive operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            // determine which type of operation just completed and call the associated handler
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This method is invoked when an asycnhronous receive operation completes. If the remote host
        /// closed the connection, then the socket is closed.  If data was received then the data is
        /// echoed back to the client.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            //			System.Diagnostics.Trace.WriteLine(string.Format("ProcessReceive on thread:{0}, IsThreadPoolThread:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread));
            Task task1 = new Task(delegate
            {
                // check if the remote host closed the connection
                //				System.Diagnostics.Trace.WriteLine(string.Format("ProcessReceive Task: on thread:{0}, IsThreadPoolThread:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread));

                AsyncUserToken token = (AsyncUserToken)e.UserToken;
                if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success && token.Socket.Connected == true)
                {
                    IPanelConnection connection;
                    bool bConnectionFound = _connections.TryGetValue(e, out connection);
                    if (bConnectionFound)
                    {
                        connection.HandleReceiveData(ref e);
                    }
                    else
                    {
                        //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("ProcessReceive: Connection not found"));
                        this.Log().InfoFormat("ProcessReceive: Connection not found");
                    }
                    try
                    {
                        //this.Log().DebugFormat("ProcessRecieve thread count:{0}", Process.GetCurrentProcess().Threads.Count);
                        bool willRaiseEvent = token.Socket.ReceiveAsync(e);
                        if (!willRaiseEvent)
                        {
                            ProcessReceive(e);
                        }
                    }
                    catch (ObjectDisposedException objectDisposedException)
                    {
                        //GCS.Framework.Logging.LogWriter.Trace(string.Format("ProcessReceive exception:{0}", objectDisposedException.Message));
                        this.Log().Debug("ProcessReceive exception:", objectDisposedException);
                        CloseClientSocket(e);
                    }
                    catch (Exception ex)
                    {
                        //GCS.Framework.Logging.LogWriter.Trace(string.Format("ProcessReceive exception:{0}", ex.Message));
                        this.Log().Debug("ProcessReceive exception", ex);
                        CloseClientSocket(e);
                    }
                }
                else
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("ProcessReceive calling CloseClientSocket. BytesTransferred:{0}, SocketError:{1}, Socket.Connected:{2}",
                    //    e.BytesTransferred, e.SocketError, token.Socket.Connected));
                    this.Log().DebugFormat("ProcessReceive calling CloseClientSocket. BytesTransferred:{0}, SocketError:{1}, Socket.Connected:{2}",
                        e.BytesTransferred, e.SocketError, token.Socket.Connected);

                    CloseClientSocket(e);
                }
            });

            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This method is invoked when an asynchronous send operation completes.  The method issues
        /// another receive on the socket to read any additional data sent from the client.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ProcessSend(SocketAsyncEventArgs e)
        {
            Task task1 = new Task(delegate
            {
                this.Log()
                    .DebugFormat("ProcessSend task on thread:{0}, IsThreadPoolThread:{1}", Thread.CurrentThread.ManagedThreadId,
                        Thread.CurrentThread.IsThreadPoolThread);
                if (e.SocketError == SocketError.Success)
                {
                    // done echoing data back to the client
                    AsyncUserToken token = (AsyncUserToken)e.UserToken;
                    // read the next block of data send from the client
                    bool willRaiseEvent = token.Socket.ReceiveAsync(e);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(e);
                    }
                }
                else
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("ProcessSend calling CloseClientSocket. SocketError:{0}",
                    //    e.SocketError));
                    this.Log().DebugFormat(string.Format("ProcessSend calling CloseClientSocket. SocketError:{0}", e.SocketError));
                    CloseClientSocket(e);
                }
            });
            task1.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Closes client socket. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Socket asynchronous event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = e.UserToken as AsyncUserToken;

            // close the socket associated with the client
            try
            {
                string instanceGuid = string.Empty;
                ConnectionStateChangeEventArgs connectionStateChangedEventArgs = null;
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("socketClosed:{0}", token.Socket.Handle));
                if (token != null)
                    this.Log().DebugFormat("socketClosed:{0}", token.Socket.Handle);
                //				Connection6xx clientConnection;
                IPanelConnection clientConnection;
                bool bRemoved = _connections.TryRemove(e, out clientConnection);
                if (bRemoved == true)
                {
                    clientConnection.PrepareToClose(false);
                    foreach (CpuConnectionInfo cpuInfo in _cpuConnections)
                    {
                        if (cpuInfo.GalaxyCpuInformation.InstanceGuid == clientConnection.CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid)
                        {
                            _processingQueue.Add(cpuInfo);
                            _cpuConnections.Remove(cpuInfo);
                            connectionStateChangedEventArgs = new ConnectionStateChangeEventArgs(cpuInfo);
                            break;
                        }
                    }
                    instanceGuid = clientConnection.CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid;
                    clientConnection = null;
                    // decrement the counter keeping track of the total number of clients connected to the server
                    Interlocked.Decrement(ref _numConnectedSockets);
                    _maxNumberAcceptedClients.Release();
                    //if( _numConnectedSockets == 0 )
                    //    KillRequestDataThatNeedsLoadedTimer();

                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("Client has been disconnected from the server. {0}", instanceGuid));
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("numConnectedSockets:{0}; connections.Count:{1}", _numConnectedSockets, connections.Count));

                    this.Log().DebugFormat("Client has been disconnected from the server. {0}", instanceGuid);
                    this.Log().DebugFormat("numConnectedSockets:{0}; connections.Count:{1}", _numConnectedSockets, _connections.Count);
                    // Free the SocketAsyncEventArg so they can be reused by another client
                    _readWritePool.Push(e);

                    if (connectionStateChangedEventArgs != null)
                        RaiseConnectionStateChangedEvent(this, connectionStateChangedEventArgs);
                }

                if (token != null &&
                    token.Socket != null)
                {
                    if (token.Socket.Connected == true)
                    {
                        token.Socket.Shutdown(SocketShutdown.Send);
                        token.Socket.Close();
                    }
                }
            }
            // throws if client process has already closed
            catch (Exception ex)
            {
                //GCS.Framework.Logging.LogWriter.LogException(ex);
                this.Log().Warn("CloseClientSocket", ex);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the connection state changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaiseConnectionStateChangedEvent(object sender, ConnectionStateChangeEventArgs e)
        {
            var handler = ConnectionStateChangedEvent;
            if (handler != null)
            {
                //				GCS.Framework.Logging.LogWriter.Trace(string.Format("RaiseConnectionStateChangedEvent InstanceGuid:{0}", e.ConnectionInfo.GalaxyCpuInformation.InstanceGuid));
                this.Log().DebugFormat("RaiseConnectionStateChangedEvent InstanceGuid:{0}", e.ConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                handler(sender, e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the panel information event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaisePanelInformationEvent(object sender, PanelInformationEventArgs e)
        {
            var handler = PanelInformationEvent;
            if (handler != null)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("RaisePanelInformationEvent InstanceGuid:{0}", e.GalaxyCpuInformation.InstanceGuid));
                this.Log().DebugFormat("RaisePanelInformationEvent InstanceGuid:{0}", e.GalaxyCpuInformation.InstanceGuid);
                handler(sender, e);
            }
        }

        //private IPanelConnection[] FindConnections(CpuHardwareAddress address)
        //{
        //    if (address == null)
        //        throw new ArgumentNullException("FindConnections", string.Format("The parameter CpuHardwareAddress address cannot be null"));

        //    List<IPanelConnection> conns = new List<IPanelConnection>();

        //    foreach (IPanelConnection c in connections.Values)
        //    {
        //        if (address.CpuModel == CpuModel.Cpu5xx)
        //        {
        //            if (c.ClusterId == address.ClusterId && c.ClusterGroupId == address.ClusterGroupId)
        //            {
        //                conns.Add(c);
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            if (address.PanelId == (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
        //                address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
        //            {
        //                if (c.ClusterId == address.ClusterId && c.ClusterGroupId == address.ClusterGroupId)
        //                    conns.Add(c);
        //            }
        //            else if (address.PanelId != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
        //                address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
        //            {
        //                if (c.ClusterId == address.ClusterId && c.PanelId == address.PanelId && c.ClusterGroupId == address.ClusterGroupId)
        //                    conns.Add(c);
        //            }

        //            if (address.PanelId != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
        //                address.CpuId != (Int32)CpuHardwareAddress.CpuNumber.Both)
        //            {
        //                if (c.ClusterId == address.ClusterId && c.PanelId == address.PanelId && c.CpuId == address.CpuId && c.ClusterGroupId == address.ClusterGroupId)
        //                    conns.Add(c);
        //            }
        //        }
        //    }
        //    return conns.ToArray();
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Searches for the first connections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="address">  The address. </param>
        ///
        /// <returns>   The found connections. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IPanelConnection[] FindConnections(CpuHardwareAddress address)
        {
            if (address == null)
                throw new ArgumentNullException("FindConnections", string.Format("The parameter CpuHardwareAddress address cannot be null"));

            List<IPanelConnection> conns = new List<IPanelConnection>();

            if (address.CpuModel == CpuModel.Cpu5xx)
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber && c.ClusterGroupId == address.ClusterGroupId).ToList());
            else
            {
                if (address.PanelNumber == (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                    address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
                {
                    conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                    c.ClusterGroupId == address.ClusterGroupId).ToList());
                }
                else if (address.PanelNumber != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                    address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
                {
                    conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                    c.PanelId == address.PanelNumber &&
                    c.ClusterGroupId == address.ClusterGroupId).ToList());
                }
                else if (address.PanelNumber != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                    address.CpuId != (Int32)CpuHardwareAddress.CpuNumber.Both)
                {
                    conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                    c.PanelId == address.PanelNumber &&
                    c.CpuId == address.CpuId &&
                    c.ClusterGroupId == address.ClusterGroupId).ToList());
                }
            }

            return conns.ToArray();
        }
        private IPanelConnection[] FindConnections(CpuHardwareAddress address, bool noPanelUid)
        {
            if (address == null)
                throw new ArgumentNullException("FindConnections", string.Format("The parameter CpuHardwareAddress address cannot be null"));

            List<IPanelConnection> conns = new List<IPanelConnection>();

            if (address.CpuModel == CpuModel.Cpu5xx)
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber && c.ClusterGroupId == address.ClusterGroupId).ToList());
            else
            {
                if (noPanelUid)
                {
                    conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                                  c.PanelId == address.PanelNumber &&
                                                                  c.ClusterGroupId == address.ClusterGroupId &&
                                                                  !c.GalaxyPanelUid.HasValue)
                        .ToList());

                }
                else
                {
                    if (address.PanelNumber == (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                        address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
                    {
                        conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                                      c.ClusterGroupId == address.ClusterGroupId)
                            .ToList());
                    }
                    else if (address.PanelNumber != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                             address.CpuId == (Int32)CpuHardwareAddress.CpuNumber.Both)
                    {
                        conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                                      c.PanelId == address.PanelNumber &&
                                                                      c.ClusterGroupId == address.ClusterGroupId)
                            .ToList());
                    }
                    else if (address.PanelNumber != (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels &&
                             address.CpuId != (Int32)CpuHardwareAddress.CpuNumber.Both)
                    {
                        conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                                      c.PanelId == address.PanelNumber &&
                                                                      c.CpuId == address.CpuId &&
                                                                      c.ClusterGroupId == address.ClusterGroupId)
                            .ToList());
                    }
                }
            }

            return conns.ToArray();
        }

        private IPanelConnection[] FindConnections(ClusterAddress address, bool noClusterUid)
        {
            if (address == null)
                throw new ArgumentNullException("FindConnections", string.Format("The parameter ClusterAddress address cannot be null"));

            List<IPanelConnection> conns = new List<IPanelConnection>();
            if (noClusterUid)
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                              c.ClusterGroupId == address.ClusterGroupId &&
                                                              !c.ClusterUid.HasValue).ToList());
            else
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                                                                  c.ClusterGroupId == address.ClusterGroupId).ToList());

            return conns.ToArray();
        }


        public bool IsConnected(CpuHardwareAddress address)
        {
            var conns = FindConnections(address);
            return conns.Any();
        }

        // Find all connections 
        private IPanelConnection[] FindConnectionsNotInDb(CpuHardwareAddress address)
        {
            if (address == null)
                throw new ArgumentNullException("FindConnectionsNotInDb", string.Format("The parameter CpuHardwareAddress address cannot be null"));

            List<IPanelConnection> conns = new List<IPanelConnection>();

            if (address.CpuModel == CpuModel.Cpu5xx)
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber && c.ClusterGroupId == address.ClusterGroupId).ToList());
            else
            {
                conns.AddRange(_connections.Values.Where(c => c.ClusterId == address.ClusterNumber &&
                c.ClusterGroupId == address.ClusterGroupId &&
                (c.CpuConnectionInfo.CpuDatabaseInformation == null || c.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid == Guid.Empty)).ToList());
            }

            return conns.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Searches for the first connection by instance unique identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="instanceGuid"> Unique identifier for the instance. </param>
        ///
        /// <returns>   The found connection by instance unique identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IPanelConnection FindConnectionByInstanceGuid(string instanceGuid)
        {
            if (instanceGuid == string.Empty)
                throw new ArgumentNullException("FindConnectionByInstanceGuid", string.Format("The parameter instanceGuid cannot be empty"));

            return _connections.Values.FirstOrDefault(c => c.InstanceGuid == instanceGuid);
            //foreach (IPanelConnection conn in connections.Values)
            //{
            //    if (conn.InstanceGuid == instanceGuid)
            //        return conn;
            //}
            //return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Closes all connections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CloseAllConnections()
        {
            try
            {
                foreach (IPanelConnection conn in _connections.Values)
                {
                    conn.PrepareToClose(false);
                }
            }
            catch (Exception ex)
            {
                //				GCS.Framework.Logging.LogWriter.LogException(ex, string.Format("ConnectionManagerAsync::CloseAllConnections"));
                this.Log().Info(string.Format("ConnectionManagerAsync::CloseAllConnections"), ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the wait for processing queue to empty timer. </summary>
        ///
        /// <remarks>   Kevin, 1/30/2014. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WaitForProcessingQueueToEmptyTimerCallback(object state)
        {
            if (_processingQueue.Count == 0)
            {
                if (_waitForProcessingQueueToEmptyTimer != null)
                    _waitForProcessingQueueToEmptyTimer.Dispose();
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0}, WaitForProcessingQueueToEmptyTimerCallback called. ProcessingQueue is now empty.", System.Environment.TickCount));
                this.Log().DebugFormat("{0}, WaitForProcessingQueueToEmptyTimerCallback called. ProcessingQueue is now empty.", System.Environment.TickCount);
                if (_panelOutputDataRecorder != null)
                    _panelOutputDataRecorder.StopProcessor();

                _waitForProcessingQueueToEmptyTimer = null;
            }
            else
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0} WaitForProcessingQueueToEmptyTimerCallback called while waiting for processingQueue to empty. Count:{1}", System.Environment.TickCount, _processingQueue.Count));
                this.Log().DebugFormat("{0} WaitForProcessingQueueToEmptyTimerCallback called while waiting for processingQueue to empty. Count:{1}", System.Environment.TickCount, _processingQueue.Count);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Callback, called when the wait for processing queue to empty timer. </summary>
        ///
        /// <remarks>   Kevin, 1/30/2014. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WaitForRecordingQueueToEmptyTimerCallback(object state)
        {
            if (_recordingQueue.Count == 0)
            {
                if (_waitForRecordingQueueToEmptyTimer != null)
                    _waitForRecordingQueueToEmptyTimer.Dispose();
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0}, WaitForProcessingQueueToEmptyTimerCallback called. ProcessingQueue is now empty.", System.Environment.TickCount));
                this.Log().DebugFormat("{0}, WaitForRecordingQueueToEmptyTimerCallback called. RecordingQueue is now empty.", System.Environment.TickCount);
                if (_panelTrafficDataRecorder != null)
                    _panelTrafficDataRecorder.StopProcessor();

                _waitForRecordingQueueToEmptyTimer = null;
            }
            else
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0} WaitForProcessingQueueToEmptyTimerCallback called while waiting for processingQueue to empty. Count:{1}", System.Environment.TickCount, _processingQueue.Count));
                this.Log().DebugFormat("{0} WaitForRecordingQueueToEmptyTimerCallback called while waiting for recordingQueue to empty. Count:{1}", System.Environment.TickCount, _recordingQueue.Count);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts panel output data processors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void StartPanelOutputDataProcessors()
        {
            // Create the thread object. This does not start the thread.
            _panelOutputDataRecorder = new PanelOutputDataProcessor();
            _panelOutputDataRecorder.ProcessData(this._processingQueue);

            _panelTrafficDataRecorder = new PanelDataRecorderProcessor();
            _panelTrafficDataRecorder.ProcessData(this._recordingQueue);
        }

        #endregion


        public void SendDisconnectCpusForPanelAddress(CpuHardwareAddress panelAddress, Boolean newPanel, bool deletedPanel)
        {
            if (panelAddress == null)
                throw new ArgumentNullException("panelAddress", string.Format("The parameter SendDisconnectCpusForPanelAddress data cannot be null"));

            var conns = FindConnections(panelAddress, newPanel);
            if (conns != null && conns.Length > 0)
            {
                foreach (var conn in conns)
                {
                    if (deletedPanel)
                        conn.TakeAction(ActionCode.DisconnectDeletedCpu, 100);
                    else
                        conn.TakeAction(ActionCode.DisconnectCpu, 100);
                    //Task.Run(async () =>
                    // {
                    //     await conn.SetCpuDatabaseInformation(data.Data);
                    // }).Wait();
                }
            }
        }

        public void SendDisconnectPanelsForClusterAddress(ClusterAddress clusterAddress, Boolean newCluster)
        {
            if (clusterAddress == null)
                throw new ArgumentNullException("clusterAddress", string.Format("The parameter SendDisconnectPanelsForClusterAddress data cannot be null"));

            //           data.Data.PanelModelTypeCode

            var conns = FindConnections(clusterAddress, newCluster);
            if (conns != null && conns.Length > 0)
            {
                foreach (var conn in conns)
                {
                    conn.TakeAction(ActionCode.DisconnectCpu, 100);
                    //Task.Run(async () =>
                    // {
                    //     await conn.SetCpuDatabaseInformation(data.Data);
                    // }).Wait();
                }
            }
        }
        public void SendTimeZoneChangedClusterAddress(ClusterTimeZone clusterAddress)
        {
            if (clusterAddress == null)
                throw new ArgumentNullException("clusterAddress", string.Format("The parameter SendTimeZoneChangedClusterAddress data cannot be null"));

            //           data.Data.PanelModelTypeCode

            var conns = FindConnections(clusterAddress, false);
            if (conns != null && conns.Length > 0)
            {
                foreach (var conn in conns)
                {
                    if (conn.CpuConnectionInfo?.CpuDatabaseInformation != null)
                    {
                        conn.ChangeTimeZone(clusterAddress.TimeZoneId);
                        //conn.TakeAction(ActionCode.SendTimeToPanel, 100);
                    }
                    else
                    {
                        conn.TakeAction(ActionCode.RefreshCpuDatabaseInformation, 100);
                    }
                }
                //Task.Run(async () =>
                    // {
                    //     await conn.SetCpuDatabaseInformation(data.Data);
                    // }).Wait();
            }
        }
    }
}
