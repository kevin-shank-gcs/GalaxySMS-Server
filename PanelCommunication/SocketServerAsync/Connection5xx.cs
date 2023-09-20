////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Connection5xx.cs
//
// summary:	Implements the connection 5xx class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.PanelCommunication.PanelCommunicationServerAsync;
using GCS.PanelCommunicationServerAsync.Entities;
using GCS.PanelCommunicationServerAsync.Interfaces;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series5xx;
using GCS.PanelProtocols.Series5xx.Messages;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Logger;
using GCS.Framework.Flash;
using System.Security.Cryptography;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A connection 5xx. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Connection5xx : IPanelConnection
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
            SentSignOnRequest,
            /// <summary>	An enum constant representing the sent date time synchronise option. </summary>
            SentSignOnChallengeResponse,
            /// <summary>	An enum constant representing the authenticated option. </summary>
            Authenticated
        }

        /// <summary>   The minimum send interval minimum value. </summary>
        private const int minimumSendIntervalMinimumValue = 0;
        /// <summary>   The minimum send interval maximum value. </summary>
        private const int minimumSendIntervalMaximumValue = 100;
        #endregion


        #region Private fields
        /// <summary>   The panel properties. </summary>
        private Dictionary<PanelNumber, GalaxyCpuInformation> panelProperties = new Dictionary<PanelNumber, GalaxyCpuInformation>();
        /// <summary>   Queue of processings. </summary>
        private System.Collections.Concurrent.BlockingCollection<object> processingQueue;
        /// <summary>   true if disposed. </summary>
		private bool disposed = false;
        /// <summary>   The client. </summary>
        private SocketAsyncEventArgs socketEventArgs;
        /// <summary>   The owner. </summary>
        private ConnectionManagerAsync owner;
        /// <summary>   The receiver. </summary>
        private GCS.PanelProtocols.SenderReceiver5xx receiver;
        /// <summary>   Number of last heartbeat received ticks. </summary>
        private int lastHeartbeatReceivedTickCount;
        /// <summary>   Number of last send ticks. </summary>
        private int lastSendTickCount = System.Environment.TickCount;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /// <summary>   The transmit sequence. </summary>
        /// private UInt32 transmitSequence = 1;
        /// / <summary> State of the sign on. </summary>
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private SignOnState signOnState;
        /// <summary>   The timer. </summary>
        private System.Threading.Timer timer;
        /// <summary>   The minimum send interval for 600 panels. </summary>
        private int minimumSendInterval = 0;

        /// <summary>   True if connection close event raised. </summary>
        private bool connectionCloseEventRaised = false;

        /// <summary>   Options for controlling the cluster connection. </summary>
        private ClusterConnectionParameters clusterConnectionParameters = null;

        /// <summary>   / &lt;summary&gt;   Date/Time of the date time created. </summary>

        private DateTimeOffset dateTimeLastReceive = DateTimeOffset.MinValue;
        /// <summary>   Date/Time of the datetime last send. </summary>
        private DateTimeOffset datetimeLastSend = DateTimeOffset.MinValue;

        /// <summary>   Information describing the CPU connection. </summary>
        private CpuConnectionInfo cpuConnectionInfo = new CpuConnectionInfo();

        /// <summary>   The CPU information reply. </summary>
        private PanelInformationReply panelInformationReply;
        /// <summary>   The CPU total card count reply. </summary>
        private CpuTotalCardCountReply cpuTotalCardCountReply;
        /// <summary>   The CPU activity logging information reply. </summary>
        private CpuActivityLoggingInformationReply cpuActivityLoggingInformationReply;


        /// <summary>   Unique identifier for the instance. </summary>
        private Guid instanceGuid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the socket. </summary>
        ///
        /// <value> The socket. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Socket Socket
        {
            get
            {
                if (this.socketEventArgs.UserToken == null)
                    return this.socketEventArgs.ConnectSocket;
                return ((AsyncUserToken)this.socketEventArgs.UserToken).Socket;
            }
        }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parent">               The parent. </param>
        /// <param name="socketAsyncEventArgs"> The TCP client. </param>
        /// <param name="parameters">           Type of the crypto. </param>
        /// <param name="processingQueue">      Queue of processings. </param>
        ///
        /// ### <param name="phrase">   The phrase. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Connection5xx(ConnectionManagerAsync parent, SocketAsyncEventArgs socketAsyncEventArgs, ClusterConnectionParameters parameters, System.Collections.Concurrent.BlockingCollection<object> processingQueue)
        {
            this.owner = parent;
            this.processingQueue = processingQueue;
            instanceGuid = Guid.NewGuid();
            cpuConnectionInfo.GalaxyCpuInformation.InstanceGuid = InstanceGuid;
            cpuConnectionInfo.GalaxyCpuInformation.ClusterNumber = parameters.ClusterId;

            clusterConnectionParameters = parameters;
            // Get Stream Object
            this.socketEventArgs = socketAsyncEventArgs;

            //			GCS.Framework.Logging.LogWriter.LogInformation("Connection5xx constructor. Setting signOnState = SignOnState.NotAuthenticated");
            this.Log().Debug("Connection5xx constructor. Setting signOnState = SignOnState.NotAuthenticated");
            signOnState = SignOnState.NotAuthenticated;
            CpuConnectionInfo.CreatedDateTime = DateTimeOffset.Now;

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = Socket;

            receiver = new PanelProtocols.SenderReceiver5xx();

            //recentReceivedPackets = new ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket>();
            //recentTransmittedPackets = new ObservableCollection<GCS.PanelProtocols.Series6xx.DataPacket>();

            //			transmitSequence = 1;

            SendSignOnRequest();
            timer = new System.Threading.Timer(TimerCallback, null, 5000, 1000);
        }
        #endregion

        #region IPanelConnection Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClusterGroupId
        {
            get { return 0; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Guid? ClusterUid { get; }
        public Guid? GalaxyPanelUid { get; }
        public Guid? CpuUid { get; }

        /// <summary>   Gets the identifier of the cluster. </summary>
        ///
        /// <value> The identifier of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ClusterId
        {
            get { return CpuConnectionInfo.GalaxyCpuInformation.ClusterNumber; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the panel. </summary>
        ///
        /// <value> The identifier of the panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int PanelId
        {
            get { return 0; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the CPU. </summary>
        ///
        /// <value> The identifier of the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public short CpuId
        {
            get { return 0; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the connection. </summary>
        ///
        /// <value> Information describing the connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ConnectionDescription
        {
            get { return string.Format("Cluster:{0}, Panel:{1}, CPU:{2}", ClusterId, PanelId, CpuId); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the minimum send interval. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The minimum send interval. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MinimumSendInterval
        {
            get { return minimumSendInterval; }
            set
            {
                if (value < minimumSendIntervalMinimumValue || value > minimumSendIntervalMaximumValue)
                {
                    throw new ArgumentOutOfRangeException("MinimumSendInterval", value, string.Format("The value must be between {0} and {1}", minimumSendIntervalMinimumValue, minimumSendIntervalMaximumValue));
                }
                else
                {
                    minimumSendInterval = value;
                }
            }
        }

        public void ChangeTimeZone(string timeZoneId)
        {
            //throw new NotImplementedException();
        }

        /// <summary>   Event queue for all listeners interested in connectionStateChanged events. </summary>
        public event ConnectionStateChangedEventHandler ConnectionStateChangedEvent;
        /// <summary>   Event queue for all listeners interested in dataReceived events. </summary>
        public event DataReceivedEventHandler DataReceivedEvent;
        /// <summary>   Event queue for all listeners interested in connectionClosed events. </summary>
        public event ConnectionClosedEventHandler ConnectionClosedEvent;
        /// <summary>   Event queue for all listeners interested in panelInformation events. </summary>
        public event PanelInformationEventHandler PanelInformationEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the CPU connection. </summary>
        ///
        /// <value> Information describing the CPU connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuConnectionInfo CpuConnectionInfo
        {
            get { return cpuConnectionInfo; }
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

        public DateTimeOffset DateTimeLastReceive { get { return dateTimeLastReceive; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Date/Time of the date time last send. </summary>
        ///
        /// <value> The date time last send. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeLastSend { get { return datetimeLastSend; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the debugging mode. </summary>
        ///
        /// <value> True if debugging mode, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DebuggingMode { get; set; }

        /// <summary>   Event queue for all listeners interested in debugPacket events. </summary>
        public event DebugPacketEventHandler DebugPacketEvent;

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
            System.Diagnostics.Trace.WriteLine(string.Format("HandleReceiveData on thread:{0}, {1}", Thread.CurrentThread.ManagedThreadId, this.ConnectionDescription));
            try
            {
                socketEventArgs = e;
                // There  might be more data, so store the data received so far.
                byte[] theData = new byte[socketEventArgs.BytesTransferred];
                Array.Copy(socketEventArgs.Buffer, socketEventArgs.Offset, theData, 0, socketEventArgs.BytesTransferred);
                Int32 index = 0;
                int len = socketEventArgs.BytesTransferred;

                if (DebuggingMode == true)
                {
                    string dbg = string.Empty;
                    for (int x = 0; x < theData.Length; x++)
                        dbg += string.Format("{0:x2}", theData[x]);
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("Raw data: {0}", dbg));
                    this.Log().DebugFormat("Raw data: {0}", dbg);
                }


                while ((len--) > 0)
                {
                    if (receiver.ReceiveByte(theData[index++]) == true)
                    {   // A COMPLETE MESSAGE HAS BEEN RECEIVED
                        this.dateTimeLastReceive = DateTimeOffset.Now;

                        DataPacket5xx packet = receiver.Packet;
                        receiver.Init();
                        bool bValid = packet.IsValid();
                        lastHeartbeatReceivedTickCount = System.Environment.TickCount;
                        if (bValid == true)
                        {
                            ProcessPacket(ref packet);
                        }
                        else
                        {
                            if (IsAuthenticated == false)
                            {	// if the connection is not authenticated, drop the connection
                                //GCS.Framework.Logging.LogWriter.LogInformation("Dropping connection. Not Authenticated!!!\n");
                                this.Log().InfoFormat("Dropping connection. Not Authenticated!!!\n");
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
                    this.Log().ErrorFormat("OnReceive() SocketException.ErrorCode: {0}", socketException.ErrorCode);
                    PrepareToClose(false);
                }
            }

            // Eat up exception....Hmmmm I'm loving eat!!!
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
            //			GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0} OnReceive exited", DateTimeOffset.Now.ToString()));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the board section. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitializeBoardSection(SendDataParameters<InitializeBoardSectionSettings> data)
        {
            //if (data == null)
            //	throw new ArgumentNullException("data", string.Format("The parameter InitializeBoardSectionSettings data cannot be null"));

            //if (data.Address.ClusterId != this.ClusterId)
            //{
            //	GCS.Framework.Logging.LogWriter.LogInformation(string.Format("InitializeBoardSection data.Address.ClusterId != this.ClusterId."));
            //	return;
            //}

            //if (data.Address.PanelId != this.PanelId)
            //{
            //	GCS.Framework.Logging.LogWriter.LogInformation(string.Format("InitializeBoardSection data.Address.PanelId != this.PanelId."));
            //	return;
            //}

            //DataPacket6xx p = GetNewPacketToSend(data.Address);
            //InitializeBoardSection d = new InitializeBoardSection();

            //d.Cmd = (byte)PacketDataCode6xx.CommandInitializeBoardSection;
            //d.Type = (byte)data.SectionType;
            //d.RelayCount = (byte)data.RelayCount;

            //p.FillData(d);//, Marshal.SizeOf(c));
            //Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier of the instance. </summary>
        ///
        /// <value> Unique identifier of the instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string InstanceGuid
        {
            get { return instanceGuid.ToString(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this Connection5xx is authenticated. </summary>
        ///
        /// <value> True if this Connection5xx is authenticated, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsAuthenticated
        {
            get
            {
                if (signOnState == SignOnState.Authenticated)
                    return true;
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Kill timer. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void KillTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prepare to close. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrepareToClose(bool panelDeleted)
        {
            KillTimer();
            cpuConnectionInfo.IsConnected = false;
            RaiseConnectionClosedEvent();
            //KillTimer();
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
        /// <summary>   Gets the serial number. </summary>
        ///
        /// <value> The serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SerialNumber
        {
            get { return string.Empty; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the socket event arguments. </summary>
        ///
        /// <value> The socket event arguments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SocketAsyncEventArgs SocketEventArgs
        {
            get { return socketEventArgs; }
        }

        #endregion

        #region Private Methods

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
        /// <summary>   Raises the panel information event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxyCpuInfo">    Information describing the galaxy CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaisePanelInformationEvent(GalaxyCpuInformation galaxyCpuInfo)
        {
            var handler = PanelInformationEvent;
            if (handler != null)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("Connection5xx::RaisePanelInformationEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid));
                this.Log().DebugFormat("Connection5xx::RaisePanelInformationEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                PanelInformationEventArgs args = new PanelInformationEventArgs(galaxyCpuInfo);
                handler(this, args);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the connection state changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RaiseConnectionClosedEvent()
        {
            if (connectionCloseEventRaised == false)
            {
                var handler = ConnectionClosedEvent;
                if (handler != null)
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("Connection5xx::RaiseConnectionClosedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid));
                    this.Log().DebugFormat("Connection5xx::RaiseConnectionClosedEvent called for InstanceGuid:{0}", CpuConnectionInfo.GalaxyCpuInformation.InstanceGuid);
                    handler(this, this.SocketEventArgs);
                    connectionCloseEventRaised = true;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Send this message. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    [in,out] The DataPacket5xx to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Send(ref DataPacket5xx p)
        {
            byte[] msgToSend = p.GetBytes();
            Send(msgToSend);
        }

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
                System.Diagnostics.Trace.WriteLine(string.Format("Send on thread:{0}, {1}", Thread.CurrentThread.ManagedThreadId, this.ConnectionDescription));
                if (Socket.Connected == false)
                {
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("{0}, {1} {2} - Skipping send because object has been disposed", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
                    this.Log().DebugFormat("{0}, {1} {2} - Skipping send because object has been disposed", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    return;
                }

                if (CpuConnectionInfo != null)
                {
                    int ticksSinceLastSend = System.Environment.TickCount - lastSendTickCount;
                    int sleepTicks = 0;

                    if (ticksSinceLastSend < MinimumSendInterval)
                    {
                        sleepTicks = MinimumSendInterval - ticksSinceLastSend;
                        //GCS.Framework.Logging.LogWriter.Trace(string.Format("sleeping for {0} ms", sleepTicks));
                        this.Log().DebugFormat("sleeping for {0} ms", sleepTicks);
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

                lastSendTickCount = System.Environment.TickCount;


                if (DebuggingMode == true)
                {
                    DataPacket5xx pkt = new DataPacket5xx(data);
                    var debugHandler = DebugPacketEvent;
                    if (debugHandler != null)
                    {
                        debugHandler(this, new ConnectionDebugPacketEventArgs(ref pkt, DataDirection.TransmittedToPanel, this.CpuConnectionInfo));
                    }

                    //if (this.RecentPacketsTransmittedBufferSize > 0)
                    //{
                    //	if (this.recentTransmittedPackets.Count > RecentPacketsTransmittedBufferSize)
                    //		recentTransmittedPackets.RemoveAt(recentTransmittedPackets.Count - 1);
                    //	recentTransmittedPackets.Add(pkt);
                    //}
                }


                Socket.Send(data);
                datetimeLastSend = DateTimeOffset.Now;

            }
            catch (SocketException socketException)
            {
                //if (socketException.ErrorCode == 10054 || ((socketException.ErrorCode != 10004) && (socketException.ErrorCode != 10053)))
                {
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("Send() SocketException.ErrorCode: {0}", socketException.ErrorCode));
                    this.Log().InfoFormat("Send() SocketException.ErrorCode: {0}", socketException.ErrorCode);
                    if (Socket.Connected == true)
                    {
                        // Complete the disconnect request.
                        //this.owner.CloseClientSocket(this.socketEventArgs);
                    }
                    PrepareToClose(false);

                }
            }
            catch (ObjectDisposedException objectDisposedException)
            {
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("Send() objectDisposedException: {0}", objectDisposedException.Message));
                this.Log().DebugFormat("Send() objectDisposedException: {0}", objectDisposedException.Message);
                if (Socket.Connected == true)
                {
                    // Complete the disconnect request.
                    //this.owner.CloseClientSocket(this.socketEventArgs);
                }
            }
            // Eat up exception....Hmmmm I'm loving eat!!!
            catch (Exception exception)
            {
                this.Log().DebugFormat(exception.Message + "\n" + exception.StackTrace);
            }
        }

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

        private bool ProcessPacket(ref DataPacket5xx pkt)
        {
            //if (IsAuthenticated == true)
            //{
            //	if (pkt. != ClusterId ||
            //		pkt.PanelId != PanelId ||
            //		pkt.Cpu != CpuId)
            //	{
            //		PrepareToClose();
            //		throw new ApplicationException(string.Format("Connection6xx object {0} {1} received packet from Cluster:{2}, Panel:{3}, CPU:{4}", ConnectionDescription, InstanceGuid, pkt.ClusterId, pkt.PanelId, pkt.Cpu));
            //	}
            //}

            if (DebuggingMode == true)
            {
                var debugHandler = DebugPacketEvent;
                if (debugHandler != null)
                {
                    debugHandler(this, new ConnectionDebugPacketEventArgs(ref pkt, DataDirection.ReceivedFromPanel, this.CpuConnectionInfo));
                }

                //if (this.RecentPacketsReceivedBufferSize > 0)
                //{
                //	if (recentReceivedPackets.Count > RecentPacketsReceivedBufferSize)
                //		recentReceivedPackets.RemoveAt(recentReceivedPackets.Count - 1);
                //	recentReceivedPackets.Add(pkt);
                //}
            }


            GalaxyCpuInformation galaxyCpuInfo;

            switch ((PacketDataCode5xx)pkt.Data[0])
            {
                case PacketDataCode5xx.CpuHeartbeat:
                    //					GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} {2} - heartbeat received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
                    this.Log().DebugFormat("{0}, {1} {2} - heartbeat received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    break;

                case PacketDataCode5xx.ResponseSignOnRequestWithChallenge:
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} {2} - ResponseSignOnRequestWithChallenge received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
                    this.Log().DebugFormat("{0}, {1} {2} - ResponseSignOnRequestWithChallenge received", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                    if (this.signOnState == SignOnState.SentSignOnRequest && pkt.Length == 7)
                    {
                        Byte[] key = new Byte[6];
                        Array.Copy(pkt.Data, 1, key, 0, key.Length);
                        if (SendSignOnChallenge(key) == false)
                        {
                            PrepareToClose(false);
                            return false;
                        }
                    }
                    else
                    {
                        PrepareToClose(false);
                        return false;
                    }
                    break;

                case PacketDataCode5xx.ResponseSignOnSuccessful:
                    signOnState = SignOnState.Authenticated;
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString()));
                    this.Log().InfoFormat("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString());

                    SetLoggingState(ActivityLoggingState.Off, null);
                    var sendToAddress = new SendDataParameters<GalaxyCpuCommandAction>()
                    {
                        SendToAddress = new BoardSectionNodeHardwareAddress()
                        {
                            PanelNumber = (int) PanelNumber.AllPanels
                        }
                    };

                    SendGetLoggingInfo(sendToAddress);
                    SendGetControllerInfo(sendToAddress);
                    SendGetCardCount(sendToAddress);

                    cpuConnectionInfo.RemoteIpEndpoint = this.Socket.RemoteEndPoint.ToString();
                    cpuConnectionInfo.LocalIpEndpoint = this.Socket.LocalEndPoint.ToString();
                    cpuConnectionInfo.IsAuthenticated = IsAuthenticated;
                    cpuConnectionInfo.IsConnected = true;
                    cpuConnectionInfo.Description = ConnectionDescription;
                    cpuConnectionInfo.SocketHandle = this.Socket.Handle.ToString();
                    RaiseConnectionStateChangedEvent();
                    break;

                case PacketDataCode5xx.ResponseSignOnDenied:
                    signOnState = SignOnState.NotAuthenticated;
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString()));
                    this.Log().DebugFormat("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString());
                    PrepareToClose(false);
                    return false;

                case PacketDataCode5xx.ResponseAck:
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString()));
                    this.Log().DebugFormat("{0}, {1} - Ack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString());
                    break;

                case PacketDataCode5xx.ResponseNack:
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - Nack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString()));
                    this.Log().DebugFormat("{0}, {1} - Nack received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString());
                    break;

                case PacketDataCode5xx.ResponsePanelInquire:
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - ResponsePanelInquire received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString()));
                    this.Log().DebugFormat("{0}, {1} - ResponsePanelInquire received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[1]).ToString());
                    panelInformationReply = new PanelInformationReply(ref pkt);
                    if (panelProperties.TryGetValue((PanelNumber)pkt.Route.FromController, out galaxyCpuInfo) == false)
                    {
                        galaxyCpuInfo = new GalaxyCpuInformation();
                        galaxyCpuInfo.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.PanelNumber = pkt.Route.FromController;

                        galaxyCpuInfo.InqueryReply.CardCodeFormat = CredentialDataSize.Standard48Bits;
                        galaxyCpuInfo.InqueryReply.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.InqueryReply.PanelNumber = pkt.Route.FromController;
                        galaxyCpuInfo.InqueryReply.CpuModel = CpuModel.Cpu5xx;
                    }

                    if (panelInformationReply.ActivityLoggingEnabled == 0)
                        galaxyCpuInfo.LoggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingNotEnabled;
                    else
                        galaxyCpuInfo.LoggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingEnabled;

                    galaxyCpuInfo.LoggingStatusReply.UnacknowledgedActivityLogCount = panelInformationReply.UnacknowledgedActivityLogCount;

                    if (panelInformationReply.CrisisModeActive == 0)
                        galaxyCpuInfo.InqueryReply.CrisisModeActive = CrisisModeState.Inactive;
                    else
                        galaxyCpuInfo.InqueryReply.CrisisModeActive = CrisisModeState.Active;

                    galaxyCpuInfo.InqueryReply.Version.Major = panelInformationReply.VersionFlashLo.Major;
                    galaxyCpuInfo.InqueryReply.Version.Minor = panelInformationReply.VersionFlashLo.Minor;

                    if (panelInformationReply.LastRestartColdOrWarm == 0)
                        galaxyCpuInfo.InqueryReply.LastRestartColdOrWarm = CpuResetType.ColdReset;
                    else
                        galaxyCpuInfo.InqueryReply.LastRestartColdOrWarm = CpuResetType.WarmReset;

                    galaxyCpuInfo.InqueryReply.SerialNumber = System.Text.Encoding.ASCII.GetString(panelInformationReply.SerialNumber);
                    galaxyCpuInfo.InstanceGuid = InstanceGuid;
                    panelProperties[(PanelNumber)pkt.Route.FromController] = galaxyCpuInfo;

                    if (pkt.Route.FromController == (byte)PanelNumber.Primary)
                    {
                        CpuConnectionInfo.GalaxyCpuInformation.CpuModel = CpuModel.Cpu5xx;
                        CpuConnectionInfo.RemoteIpEndpoint = this.Socket.RemoteEndPoint.ToString();
                        CpuConnectionInfo.LocalIpEndpoint = this.Socket.LocalEndPoint.ToString();
                        CpuConnectionInfo.IsAuthenticated = IsAuthenticated;
                        CpuConnectionInfo.IsConnected = true;
                        CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.SerialNumber = System.Text.Encoding.ASCII.GetString(panelInformationReply.SerialNumber);
                        CpuConnectionInfo.Description = ConnectionDescription;
                        CpuConnectionInfo.SocketHandle = this.Socket.Handle.ToString();
                        CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.Version.Major = panelInformationReply.VersionFlashLo.Major;
                        CpuConnectionInfo.GalaxyCpuInformation.InqueryReply.Version.Minor = panelInformationReply.VersionFlashLo.Minor;
                    }
                    SendToProcessingQueue(galaxyCpuInfo);
                    RaisePanelInformationEvent(galaxyCpuInfo);
                    break;

                case PacketDataCode5xx.ResponseRequestLoggingInformation:
                    cpuActivityLoggingInformationReply = new CpuActivityLoggingInformationReply(ref pkt);
                    if (panelProperties.TryGetValue((PanelNumber)pkt.Route.FromController, out galaxyCpuInfo) == false)
                    {
                        galaxyCpuInfo = new GalaxyCpuInformation();
                        galaxyCpuInfo.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.PanelNumber = pkt.Route.FromController;

                        galaxyCpuInfo.InqueryReply.CardCodeFormat = CredentialDataSize.Standard48Bits;
                        galaxyCpuInfo.InqueryReply.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.InqueryReply.PanelNumber = pkt.Route.FromController;
                        galaxyCpuInfo.InqueryReply.CpuModel = CpuModel.Cpu5xx;
                    }

                    if (cpuActivityLoggingInformationReply.ActivityLoggingEnabled == 0)
                        galaxyCpuInfo.LoggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingNotEnabled;
                    else
                        galaxyCpuInfo.LoggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingEnabled;

                    galaxyCpuInfo.LoggingStatusReply.UnacknowledgedActivityLogCount = cpuActivityLoggingInformationReply.UnacknowledgedActivityLogCount;
                    galaxyCpuInfo.LoggingStatusReply.BufferedActivityLogCount = cpuActivityLoggingInformationReply.BufferedActivityLogCount;
                    galaxyCpuInfo.InstanceGuid = InstanceGuid;
                    panelProperties[(PanelNumber)pkt.Route.FromController] = galaxyCpuInfo;
                    SendToProcessingQueue(galaxyCpuInfo);
                    RaisePanelInformationEvent(galaxyCpuInfo);
                    break;

                case PacketDataCode5xx.ResponseTotalCardCount:
                    cpuTotalCardCountReply = new CpuTotalCardCountReply(ref pkt);
                    if (panelProperties.TryGetValue((PanelNumber)pkt.Route.FromController, out galaxyCpuInfo) == false)
                    {
                        galaxyCpuInfo = new GalaxyCpuInformation();
                        galaxyCpuInfo.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.PanelNumber = pkt.Route.FromController;

                        galaxyCpuInfo.InqueryReply.CardCodeFormat = CredentialDataSize.Standard48Bits;
                        galaxyCpuInfo.InqueryReply.ClusterNumber = this.ClusterId;
                        galaxyCpuInfo.InqueryReply.PanelNumber = pkt.Route.FromController;
                        galaxyCpuInfo.InqueryReply.CpuModel = CpuModel.Cpu5xx;
                    }

                    galaxyCpuInfo.CardCountReply.Value = cpuTotalCardCountReply.TotalCardCount;
                    galaxyCpuInfo.InstanceGuid = InstanceGuid;
                    panelProperties[(PanelNumber)pkt.Route.FromController] = galaxyCpuInfo;
                    SendToProcessingQueue(galaxyCpuInfo);
                    RaisePanelInformationEvent(galaxyCpuInfo);
                    break;

                default:
                    //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1} - Received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[0]).ToString()));
                    this.Log().DebugFormat("{0}, {1} - Received - {2}", DateTimeOffset.Now.ToString(), ConnectionDescription, ((PacketDataCode5xx)pkt.Data[0]).ToString());
                    if (signOnState != SignOnState.Authenticated)
                    {   // if the connection is not authenticated, drop the connection
                        if (pkt.Data[0] != (byte)PacketDataCode5xx.NotificationEventIOLevel)
                        {
                            PrepareToClose(false);
                        }
                        return false;
                    }
                    break;

            }

            if (IsAuthenticated == true)
            {

            }
            //	if( m_AuthenticateMode == AUTHENTICATED )
            //	{
            //		COleDateTime dt;
            //		BOOL bNotifyCommServiceOfNewConnection = FALSE;
            //		switch( pPkt->pkt.dist )
            //		{
            //			case PACKET_EVENT_SERVER_DIST_PANEL_TO_ALL_PANELS:
            //			case PACKET_EVENT_SERVER_DIST_PANEL_TO_SPECIFIC_PANEL:
            //				packet_event_server*	pDbg;
            //				pDbg = new packet_event_server;
            //				memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //				::PostThreadMessage( m_hCoreThread, UWM_DISTRIBUTE_600_EVENT, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );	
            //				break;

            //			case PACKET_EVENT_SERVER_DIST_PANEL_TO_PC:	// send this up to the GCS_Comm service
            //				BOOL	bSendToSSPIClients = TRUE;

            //				switch( pPkt->pkt.data[0] )
            //				{
            //					case TCP_IP_HEARTBEAT:
            //						if( globals.bPassHeartbeatsToSSPIClients == FALSE )
            //							bSendToSSPIClients = FALSE;
            //						break;

            //					case CARD_NOT_IN_MEMORY_REQUEST:
            //						p = new packet_event_server;
            //						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_NOT_IN_MEMORY, (WPARAM)this->m_nThreadID, (LPARAM)p );	
            //						break;

            //					case CARD_HAS_BEEN_READ:
            //						p = new packet_event_server;
            //						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_HAS_BEEN_READ, (WPARAM)this->m_nThreadID, (LPARAM)p );	
            //						break;

            //					case CARD_REMOTE_ACCESS_RULE_OVERRIDE:						
            //						p = new packet_event_server;
            //						memcpy( p, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //						::PostThreadMessage( m_hCoreThread, UWM_HANDLE_CARD_REMOTE_ACCESS_RULE_OVERRIDE, (WPARAM)this->m_nThreadID, (LPARAM)p );	
            //						break;

            //					case RESP_UNIT_INQUIRE:
            //						if( m_ControllerInfo.serial_number[0] == 0 )
            //							bNotifyCommServiceOfNewConnection = TRUE;

            //						memcpy(&m_ControllerInfo, pPkt->pkt.data, sizeof(m_ControllerInfo));
            //						m_ConnectionStatus.m_CPU_MODEL	= m_ControllerInfo.cpu_model_number;
            //						m_ConnectionStatus.m_LogsNotAckedCount = m_ControllerInfo.unacked_log_count;
            //						if( bNotifyCommServiceOfNewConnection == TRUE )
            //							NotifyCommServerOfNewConnection(1);

            //						ReportStatus();
            //						break;

            //					case RESP_TOTAL_CARD_COUNT:
            //						memcpy( &m_ConnectionStatus.m_CardCount, &pPkt->pkt.data[1], sizeof( m_CardCount ) );
            //						if( m_ConnectionStatus.m_CardCount < 0 || m_ConnectionStatus.m_CardCount > MAXWORD )
            //							OutputDebugString(_T("Card count looks to be bogus. Possible cold start needed.\n"));
            //						break;

            //					case RESP_GET_LOGGING_INFO:
            //						m_ConnectionStatus.m_LogsNotAckedCount	= MAKEWORD( pPkt->pkt.data[2], pPkt->pkt.data[3] );
            //						m_ConnectionStatus.m_LogsNotSentCount	= MAKEWORD( pPkt->pkt.data[4], pPkt->pkt.data[5] );
            //						if( m_ConnectionStatus.m_LogsNotAckedCount < 0 || m_ConnectionStatus.m_LogsNotAckedCount > 11000 ||
            //							m_ConnectionStatus.m_LogsNotSentCount < 0 || m_ConnectionStatus.m_LogsNotSentCount > 11000)
            //						{
            //							OutputDebugString(_T("Log buffer counts appear to be bogus. Possible cold start needed.\n"));
            //						}
            //						break;

            //					case LOG_MESSAGE:
            //						if( m_ControllerInfo.code == RESP_UNIT_INQUIRE && m_ControllerInfo.jumbo_card_format != 0 )
            //						{
            //							bSendToSSPIClients = FALSE;
            //							switch( pPkt->pkt.data[3])
            //							{
            //								case NOT_IN_SYS:
            //								case NOT_IN_SYS_REV:
            //								case PIV_CARD_EXPIRED:
            //								case INVALID_ATTEMPT_X:
            //								case VALID_ACCESS_X:
            //								case DURESS_X:
            //								case PASSBACK_VIOLATION_X:
            //								case BAD_PIN_X:
            //								case MANUAL_ARM_X:
            //								case MANUAL_DISARM_X:
            //								case ACCESS_DENIED_KEYS_X:	// added with key control features
            //								case VALID_ACCESS_W_PIN_DATA:	// VALID ACCESS WITH PIN INFO (2 bytes at the end) - Flash Version 1.12 and higher
            //								case OTIS_AUDIT_DATA:
            //								case CARD_TOUR_STARTING:
            //								case CARD_TOUR_CONTINUING:
            //								case CARD_TOUR_COMPLETED:
            //								case CARD_TOUR_OVERDUE:
            //								case CARD_TOUR_INCORRECT_START_READER:
            //								case CARD_TOUR_NON_EXISTENT_TOUR:
            //									log_event_600 logStart;
            //									memcpy(&logStart, &pPkt->pkt.data[3], sizeof( logStart));
            //									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logStart.month, logStart.day, logStart.hour, logStart.minute, logStart.second);
            //									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
            //									{
            //										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
            //										bSendToSSPIClients = FALSE;
            //										break;
            //									}
            //									if( m_JumboCard.HandleLogStart(&logStart) == FALSE )
            //										OutputDebugString(_T("HandleLogStart returned false\n"));
            //									break;

            //								case JUMBO_CARD_MID:
            //								case JUMBO_CARD_END:
            //									card_event_code_ex logEx;
            //									memcpy(&logEx, &pPkt->pkt.data[3], sizeof( logEx));
            //									if( m_JumboCard.HandleCardExLog(&logEx) == FALSE )
            //										OutputDebugString(_T("HandleCardExLog returned false\n"));
            //									else
            //									{
            //										if( pPkt->pkt.data[3] == JUMBO_CARD_END)
            //										{
            //											jumbo_log_event jumboEvent;
            //											m_JumboCard.GetJumboLogEvent(&jumboEvent);
            //											packet_event_server*	pDbg = new packet_event_server;
            //											memset(pDbg, 0, sizeof(packet_event_server));
            //											memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //											memcpy( &pDbg->pkt.data[3], &jumboEvent, sizeof( jumboEvent));
            //											pDbg->pkt.length += sizeof(jumboEvent.card_data);
            //											::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
            //										}
            //									}
            //									break;

            //								default:
            //									log_event_600 logTemp;
            //									memcpy(&logTemp, &pPkt->pkt.data[3], sizeof( logTemp));
            //									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logTemp.month, logTemp.day, logTemp.hour, logTemp.minute, logTemp.second);
            //									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
            //									{
            //										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
            //										bSendToSSPIClients = FALSE;
            //										break;
            //									}
            //									bSendToSSPIClients = TRUE;
            //									break;
            //							}
            //						}
            //						else if( m_ControllerInfo.code == RESP_UNIT_INQUIRE && m_ControllerInfo.jumbo_card_format == 0 )
            //						{
            //							switch( pPkt->pkt.data[3])
            //							{
            //								case NOT_IN_SYS:
            //								case NOT_IN_SYS_REV:
            //								case PIV_CARD_EXPIRED:
            //								case INVALID_ATTEMPT_X:
            //								case VALID_ACCESS_X:
            //								case DURESS_X:
            //								case PASSBACK_VIOLATION_X:
            //								case BAD_PIN_X:
            //								case MANUAL_ARM_X:
            //								case MANUAL_DISARM_X:
            //								case ACCESS_DENIED_KEYS_X:	// added with key control features
            //								case VALID_ACCESS_W_PIN_DATA:	// VALID ACCESS WITH PIN INFO (2 bytes at the end) - Flash Version 1.12 and higher
            //								case OTIS_AUDIT_DATA:
            //								case CARD_TOUR_STARTING:
            //								case CARD_TOUR_CONTINUING:
            //								case CARD_TOUR_COMPLETED:
            //								case CARD_TOUR_OVERDUE:
            //								case CARD_TOUR_INCORRECT_START_READER:
            //								case CARD_TOUR_NON_EXISTENT_TOUR:
            //									log_event_600 logStart;
            //									memcpy(&logStart, &pPkt->pkt.data[3], sizeof( logStart));
            //									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logStart.month, logStart.day, logStart.hour, logStart.minute, logStart.second);
            //									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
            //									{
            //										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
            //										bSendToSSPIClients = FALSE;
            //										break;
            //									}

            //									if( m_JumboCard.HandleLogStart(&logStart) == FALSE )
            //										OutputDebugString(_T("HandleLogStart returned false\n"));
            //									else
            //									{
            //										bSendToSSPIClients = FALSE;
            //										jumbo_log_event jumboEvent;
            //										m_JumboCard.GetJumboLogEvent(&jumboEvent);
            //										packet_event_server*	pDbg = new packet_event_server;
            //										memset(pDbg, 0, sizeof(packet_event_server));
            //										memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //										memcpy( &pDbg->pkt.data[3], &jumboEvent, sizeof( jumboEvent));
            //										pDbg->pkt.length += sizeof(jumboEvent.card_data);
            //										::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
            //									}
            //									break;

            //								case JUMBO_CARD_MID:
            //								case JUMBO_CARD_END:
            //									bSendToSSPIClients = FALSE;
            //									break;

            //								default:
            //									log_event_600 logTemp;
            //									memcpy(&logTemp, &pPkt->pkt.data[3], sizeof( logTemp));
            //									dt.SetDateTime(COleDateTime::GetCurrentTime().GetYear(), logTemp.month, logTemp.day, logTemp.hour, logTemp.minute, logTemp.second);
            //									if( dt.GetStatus() != COleDateTime::DateTimeStatus::valid )
            //									{
            //										OutputDebugString(_T("Bogus LOG_MESSAGE. Discarding\n"));
            //										bSendToSSPIClients = FALSE;
            //										break;
            //									}
            //									break;
            //							}
            //						}
            //						break;

            //					//case RESP_ACK_500:
            //					//case RESP_NACK_500:
            //						//if( pPkt->pkt.data[1] == TCP_IP_HEARTBEAT )
            //						//	break;	// only if this is a heartbeat, do I break and not notify the clients

            //					default:
            //						break;
            //				}
            //				if( bSendToSSPIClients == TRUE )
            //				{
            //					packet_event_server*	pDbg = new packet_event_server;
            //					memset( pDbg, 0, sizeof( packet_event_server) );
            //					memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //					::PostThreadMessage( m_hCoreThread, UWM_SEND_EVENT_SERVER_PACKET_TO_SSPI_CLIENTS, (WPARAM)this->m_nThreadID, (LPARAM)pDbg );				
            //				}
            //				break;
            //		}

            //		switch( pPkt->pkt.data[0] )
            //		{
            //			case EVENT_AREA_500:
            //				if( globals.bRecordAreaPackets)
            //				{
            //					packet_event_server*	p1 = new packet_event_server;
            //					memcpy( p1, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //					::PostThreadMessage( m_hCoreThread, UWM_RECORD_AREA_EVENT_RECEIVED, 0, (LPARAM)p1 );
            //				}

            //				///*************************************************************************
            //				// *                                                                       *
            //				// *   Process Area Event Messages (called by TASK4)                       *
            //				// *                                                                       *
            //				// *      str format:                                                      *
            //				// *            str[0] - str[5] = card code                                *
            //				// *            str[6] = area entered (if any, 255 means none)             *
            //				// *            str[7] = passback forgive code                             *
            //				// *************************************************************************/
            //				//void AreaEventProcess(unsigned char* str)
            //				//{
            //				//	static struct USER_SAV slot;
            //				//	if(UserFind( &slot, &str[0] ) )
            //				//	{          // if this user is in our database
            //				//		if( str[6] != 255)
            //				//		{                             /* if an area was entered */
            //				//			slot.ptr->common.area = str[6];              /* copy in new area code */
            //				//			slot.ptr->common.flags[1] &= ~7;
            //				//			slot.ptr->common.flags[1] |= str[7] & 7;     /* copy in new passback forgive code */
            //				//		}
            //				//		if( slot.ptr->common.expire == 0 ) return;         /* only if expire counter is != 0 */
            //				//		if( slot.ptr->common.flags[1] & 0x20 )  return;    /* only if swiped limited card (not date limited) */
            //				//		if(str[7] & 0x80)   return;                 /* only if expire is #swipes is not supressed on this door */
            //				//		slot.ptr->common.expire--;       /* then decrement it */
            //				//		if( !slot.ptr->common.expire )   /* if it now becomes zero */
            //				//			slot.ptr->common.flags[0] &= ~0x20;   /* then disable the card */
            //				//	} // if(UserFind(&slot, &str[0]))



            //				break;

            //			default:
            //				break;
            //		}
            //	}

            //	if( m_hDebugWnd )
            //	{
            //		switch( pPkt->pkt.data[0] )
            //		{
            //			case TCP_IP_HEARTBEAT:
            //				if( globals.bShowHeartbeatsInDebugWindow == FALSE )
            //					break;

            //			case RESP_ACK_500:
            //			case RESP_NACK_500:
            //				if( pPkt->pkt.data[1] == TCP_IP_HEARTBEAT )
            //					if( globals.bShowHeartbeatsInDebugWindow == FALSE )
            //						break;	// only if this is a heartbeat, do I break and not notify the clients

            //			default:
            //	//			if( ::IsWindow( m_hDebugWnd ) )
            //				{
            //					packet_event_server*	pDbg = new packet_event_server;
            //					memcpy( pDbg, pPkt, pPkt->pkt.length + PACKET_EVENT_SERVER_HEADER_SIZE );
            //					::PostMessage( m_hDebugWnd, UWM_PROCESS_600_PACKET, 0, (LPARAM)pDbg );
            //				}
            //				break;
            //		}
            //	}
            //	return true;
            //}
            return true;

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
                //				GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - TimerCallback called before Authenticated", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
                this.Log().DebugFormat("{0}, {1}, {2} - TimerCallback called before Authenticated", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid);
                return;
            }

            if (System.Environment.TickCount < this.lastSendTickCount ||
                (System.Environment.TickCount - this.lastSendTickCount) > 14000)
                SendHeartbeat();

            if (System.Environment.TickCount < this.lastHeartbeatReceivedTickCount)
                this.lastHeartbeatReceivedTickCount = System.Environment.TickCount;

            int ticksSinceLastHeartbeatReceived = (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount);
            if (ticksSinceLastHeartbeatReceived > 17000)
            {
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2}, lastHeartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount)));
                this.Log().InfoFormat("{0}, {1}, {2}, lastHeartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount));
            }

            if (ticksSinceLastHeartbeatReceived > 20000)
            {
                //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - closing connection, last heartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount)));
                this.Log().InfoFormat("{0}, {1}, {2} - closing connection, last heartbeat received {3} ms ago", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid, (System.Environment.TickCount - this.lastHeartbeatReceivedTickCount));
                PrepareToClose(false);
            }

            return;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets new packet to send. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new packet to send. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataPacket5xx GetNewPacketToSend()
        {
            DataPacket5xx p = new DataPacket5xx();
            p.Route = new Route();
            p.Route.FromPortBoard = 0x11;
            p.Route.ToPortBoard = 0x10;
            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets new packet to send. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="route">    The route. </param>
        ///
        /// <returns>   The new packet to send. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataPacket5xx GetNewPacketToSend(Panel5xxRoute route)
        {
            DataPacket5xx p = new DataPacket5xx();
            p.Route = new Route();
            p.Route.FromController = (byte)route.FromPanelId;
            p.Route.FromPortBoard = (byte)route.FromPortBoard;
            p.Route.ToController = (byte)route.ToPanelId;
            p.Route.ToPortBoard = (byte)route.ToPortBoard;
            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the sign on challenge. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendSignOnRequest()
        {
            DataPacket5xx p = GetNewPacketToSend();
            SignOnRequest c = new SignOnRequest();

            c.Cmd = (byte)PacketDataCode5xx.CommandSignOnRequest;
            p.FillData(c);
            //GCS.Framework.Logging.LogWriter.LogInformation("SendSignOnRequest. Setting signOnState = SignOnState.SendSignOnRequest");
            this.Log().DebugFormat("SendSignOnRequest. Setting signOnState = SignOnState.SendSignOnRequest");
            signOnState = SignOnState.SentSignOnRequest;
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a sign on challenge. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="key">  The key. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool SendSignOnChallenge(Byte[] key)
        {
            if (key.Length != 6)
                return false;

            Byte[] Buffer = new Byte[14];
            Array.Copy(key, Buffer, key.Length);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            Byte[] temp = encoding.GetBytes(clusterConnectionParameters.Password);
            int pwdLen = clusterConnectionParameters.Password.Length;
            if (pwdLen > 8)
                pwdLen = 8;
            Array.Copy(temp, 0, Buffer, 6, pwdLen);

            DataPacket5xx p = GetNewPacketToSend();
            AuthenticateSignOnRequestWithChallenge c = new AuthenticateSignOnRequestWithChallenge();
            c.Cmd = (Byte)PacketDataCode5xx.CommandSignOnChallengeResponse;
            c.Crc = GCS.Security.Crc32.GetCRC(Buffer);
            p.FillData(c);
            signOnState = SignOnState.SentSignOnChallengeResponse;
            Send(ref p);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a single byte command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="panel">    The panel. </param>
        /// <param name="cmd">      The command. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendSingleByteCommand(PanelNumber panel, PacketDataCode5xx cmd)
        {
            DataPacket5xx p = GetNewPacketToSend();
            SingleByteCommand c = new SingleByteCommand();
            c.Cmd = (Byte)cmd;
            p.FillData(c);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the heartbeat. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendHeartbeat()
        {
            SendSingleByteCommand(PanelNumber.Primary, PacketDataCode5xx.CpuHeartbeat);
            //DataPacket5xx p = GetNewPacketToSend();
            //Heatbeat c = new Heatbeat();

            //c.Cmd = (byte)PacketDataCode5xx.CpuHeartbeat;
            //p.FillData(c);
            //GCS.Framework.Logging.LogWriter.LogInformation(string.Format("{0}, {1}, {2} - Sending heartbeat", DateTimeOffset.Now.ToString(), ConnectionDescription, InstanceGuid));
            //Send(ref p);
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
            DataPacket5xx p = GetNewPacketToSend();
            SetLoggingState c = new SetLoggingState();

            c.Cmd = (byte)PacketDataCode5xx.CommandLoggingSetOnOff;
            switch (state)
            {
                case ActivityLoggingState.Off:
                    c.State = 0;
                    break;

                case ActivityLoggingState.On:
                    c.State = 1;
                    break;
            }

            p.FillData(c);
            Send(ref p);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Sets CPU database information. </summary>
        /////
        ///// <param name="data"> The data. </param>
        /////=================================================================================================

        //public async Task SetCpuDatabaseInformation(GalaxyCpuDatabaseInformation data)
        //{

        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a get card count. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetCardCount(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            //if (param is PanelNumber)
            //    SendSingleByteCommand((PanelNumber)param, PacketDataCode5xx.CommandRequestTotalCardCount);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a get controller information. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetLoggingInfo(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            //if (param is PanelNumber)
            //    SendSingleByteCommand((PanelNumber)param, PacketDataCode5xx.CommandPanelInquire);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a get logging information. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="param">    The parameter. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendGetControllerInfo(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            //if (param is PanelNumber)
            //    SendSingleByteCommand((PanelNumber)param, PacketDataCode5xx.CommandRequestLoggingInformation);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a ping. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendPing(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            //if (param is PanelNumber)
            //    SendSingleByteCommand((PanelNumber)param, PacketDataCode5xx.CommandPing);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a raw data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data">     The data. </param>
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void TakeAction(ActionCode actionCode, int delayMs)
        {
        }

        public void SendRawData(RawDataToSend data, object param)
        {
            DataPacket5xx p = GetNewPacketToSend(data.Route5xx);
            Int32 discarded;
            Byte[] bytes = GCS.Framework.Utilities.HexEncoding.GetBytesFromHexString(data.StringData, 0, out discarded);
            p.FillData(bytes);
            Send(ref p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends to processing queue. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The object to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SendToProcessingQueue(object o)
        {
            Task task1 = new Task(delegate
            {
                try
                {
                    if (o != null)
                        processingQueue.Add(o);
                }
                catch (Exception ex)
                {
                    this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                }
            });
            task1.Start();
        }

        #endregion

        #region IDisposable Members

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
            if (disposed)
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
                if (disposed)
                    return;

                if (disposing)
                {
                    PrepareToClose(false);
                }
                disposed = true;
            }
            catch (Exception)
            { }
        }


        #endregion

        #region IPanelConnection Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a packet. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="param">    The parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendPacket(object param)
        {
            if (param is DataPacket5xx)
            {
                DataPacket5xx pkt = (DataPacket5xx)param;
                Send(ref pkt);
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an aba settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAbaSettings(SendDataParameters<AbaSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a wiegand settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendWiegandSettings(SendDataParameters<WiegandSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cardax settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCardaxSettings(SendDataParameters<CardaxSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reader lockout settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendReaderLockoutSettings(SendDataParameters<ReaderLockoutSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a loop transmit delay settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendLoopTransmitDelaySettings(SendDataParameters<LoopTransmitDelaySettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time adjustment settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeAdjustmentSettings(SendDataParameters<DaylightSavingsTimeAdjustmentSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a LED behavior settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendLedBehaviorSettings(SendDataParameters<LedBehaviorSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the crisis mode settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCrisisModeSettings(SendDataParameters<CrisisModeSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a day type data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data">             The data. </param>
        /// <param name="forMonth">         for month. </param>
        /// <param name="defaultBehavior">  The default behavior. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDayTypeData(IEnumerable<DateType_PanelLoadData> data, int forMonth,
            DateTypeDefaultBehavior_PanelLoadData defaultBehavior, SendDataParameters parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule fifteen minute format data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeScheduleFifteenMinuteFormatData(
            IEnumerable<TimeSchedule15MinuteFormat_GetPanelLoadData> data, SendDataParameters parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access group data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessGroupData(SendDataParameters<AccessGroup_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a fifteen minute schedule data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendFifteenMinuteScheduleData(IEnumerable<TimeSchedule15MinuteFormat_GetPanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an one minute date day type data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="gtps"> The gtps. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendOneMinuteDateDayTypeData(List<GalaxyTimePeriod_GetPanelLoadData> gtps, SendDataParameters parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an one minute time period data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="gtps"> The gtps. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendOneMinuteTimePeriodData(List<GalaxyTimePeriod_GetPanelLoadData> gtps, SendDataParameters parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule one minute format data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeScheduleOneMinuteFormatData(IEnumerable<TimeScheduleOneMinuteFormat_GetPanelLoadData> data, SendDataParameters parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalData(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        public void SendInputDeviceData(SendDataParameters<InputDevice_PanelLoadData> data)
        {
            throw new NotImplementedException();

        }
        
        public void SendOutputDeviceData(SendDataParameters<OutputDevice_PanelLoadData> data)
        {
            throw new NotImplementedException();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a server consultation settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendServerConsultationSettings(SendDataParameters<ServerConsultationSettings> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendResetCommand(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an interface board section data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an input output group data. </summary>
        ///
        /// <remarks>   Kevin, 3/4/2019. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendInputOutputGroupData(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a time schedule fifteen minute format data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendTimeScheduleFifteenMinuteFormatData(SendDataParameters<TimeSchedule15MinuteFormat_GetPanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a credential data. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendCredentialData(List<Credential_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }
        public void SendCredentialData(SendDataParameters<List<Credential_PanelLoadData>> data)
        {
            throw new NotImplementedException();
        }

        public void SendPersonalAccessGroupData(IEnumerable<PersonalAccessGroup_PanelLoadData> personalAccessGroupData)
        {
            throw new NotImplementedException();
        }

        public void SendPersonalAccessGroupData(SendDataParameters<List<IGrouping<Guid, PersonalAccessGroup_PanelLoadData>>> personalAccessGroupData)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a clear automatic update flash timer. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClearAutoUpdateFlashTimer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a clear all credentials. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendClearAllCredentials(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a forgive passback for credential. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendForgivePassbackForCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a forgive passback for all credentials. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendForgivePassbackForAllCredentials(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a recalibrate inputs and outputs. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRecalibrateInputsAndOutputs(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an activate crisis mode. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="data"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendActivateCrisisMode(SendDataParameters<GalaxyCpuCommandAction> data)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void SendRetransmitLoggingBuffer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        public void SendClearLoggingBuffer(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        public void SendFlashCommand(GalaxyLoadFlashCommandAction param, GalaxyFlashImageHelper flashImageHelper)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an enable credential. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="data"> The data. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendEnableCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a disable credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDisableCredential(byte[] data, SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a delete credential. </summary>
        ///
        /// <remarks>   Kevin, 4/5/2019. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDeleteCredential(byte[] data)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a request input output group counters. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="ioGroupNumber">    The i/o group number. </param>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRequestInputOutputGroupCounters(ushort ioGroupNumber,
            SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a request board information. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// <param name="parameters"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendRequestBoardInformation(SendDataParameters<GalaxyCpuCommandAction> parameters)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends the access portal command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendAccessPortalCommand(SendDataParameters<AccessPortalCommandAction> data)
        {
            throw new NotImplementedException();
        }

        
        public void SendInputDeviceCommand(SendDataParameters<InputDeviceCommandAction> data)
        {
            throw new NotImplementedException();
        }

        public void SendOutputDeviceCommand(SendDataParameters<OutputDeviceCommandAction> data)
        {
            throw new NotImplementedException();
        }

        public void SendInputOutputGroupCommand(SendDataParameters<InputOutputGroupCommandAction>data )
        {
            throw new NotImplementedException();
        }

        public void SendInterfaceBoardSectionCommand(SendDataParameters<GalaxyInterfaceBoardSectionCommandAction> data)
        {
            throw new NotImplementedException();
        }

        public void SetInputOutputGroupDataForLoading(SendDataParameters<InputOutputGroup_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        public void SendPanelAlarmSettings(SendDataParameters<GalaxyPanelAlarmSettings_PanelLoadData> data)
        {
            throw new NotImplementedException();
        }

        public void SendLoadDataFinished(SendDataParameters data, string hint)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
