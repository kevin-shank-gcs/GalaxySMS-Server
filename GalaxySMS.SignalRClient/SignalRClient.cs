using GalaxySMS.Business.Entities.NetStd2;
using GalaxySMS.Common.Enums;
using GalaxySMS.SignalRCoreClient;
using GCS.Core.Common.Logger;
using GCS.Core.Common.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace GalaxySMS.SignalRCore
{
    public class SignalRClient : IDisposable
    {
        #region Private fields
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the connection. </summary>
        /// <value> The connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private HubConnection Connection { get; set; }

        /// <summary>   URL of the server. </summary>
        private string _serverUrl = string.Empty;


        /// <summary>   Identifier for the session. </summary>
        private Guid _sessionId;

        #endregion

        #region Constructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SignalRClient()
        {
            Name = Process.GetCurrentProcess().ProcessName;
            LastStateChange = new StateChange(ConnectionState.Disconnected, ConnectionState.Disconnected);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        /// <param name="name"> The name. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SignalRClient(string name)
        {
            LastStateChange = new StateChange(ConnectionState.Disconnected, ConnectionState.Disconnected);
            Name = name;
        }

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name { get; internal set; }
        public ConnectionState ConnectionState => LastStateChange.NewState;
        public StateChange LastStateChange { get; internal set; }
        public string Jwt { get; set; }
        //public bool AutomaticReconnect { get; set; } = true;
        //public int ReconnectRetryInterval { get; set; } = 30000;
        #endregion

        #region Public methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async void Dispose()
        {
            if (Connection != null)
            {
                await Connection.StopAsync();
                await Connection.DisposeAsync();
                Connection = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connects to the SignalR server identified by the serverUrl. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        /// <param name="serverUrl">    URL of the server. </param>
        /// <param name="sessionId">   The session Guid value. </param>
        /// <param name="logFileName"></param>
        /// <param name="bUseJwt"></param>
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<bool> ConnectAsync(string serverUrl, Guid sessionId, string logFileName, bool bUseJwt)
        {
            try
            {

                _sessionId = sessionId;
                await Disconnect();
                _serverUrl = serverUrl;

                if (bUseJwt)
                {
                    var token = await Task.FromResult(Jwt);

                    Connection = new HubConnectionBuilder()
                        .WithUrl($"{_serverUrl}/signalr/galaxySMSSignalRHub",
                            options => { options.AccessTokenProvider = () => Task.FromResult(Jwt); })
                        .WithAutomaticReconnect()
                        .ConfigureLogging(logging =>
                        {
                            // Log to the Console
                            //                    logging.AddConsole();

                            // This will set ALL logging to Debug level
                            logging.SetMinimumLevel(LogLevel.Debug);
                        }).Build();
                }
                else
                {
                    Connection = new HubConnectionBuilder()
                        .WithUrl($"{_serverUrl}/signalr/galaxySMSSignalRHub")
                        .WithAutomaticReconnect()
                        .ConfigureLogging(logging =>
                        {
                            // Log to the Console
                            //                    logging.AddConsole();

                            // This will set ALL logging to Debug level
                            logging.SetMinimumLevel(LogLevel.Debug);
                        }).Build();

                }

                //Connection.Headers.Add("sessionId", _sessionId.ToString());
                Connection.Closed += Connection_Closed;
                Connection.Reconnected += Connection_Reconnected;
                Connection.Reconnecting += Connection_Reconnecting;

                //var traceFilename = logFileName;

                //var writer = new StreamWriter(traceFilename);
                //writer.AutoFlush = true;
                //Connection.TraceLevel = TraceLevels.All;
                //Connection.TraceWriter = writer;

                Connection.On<string, string>("addMessage",
                    (name, message) =>
                    {
                        Trace.WriteLine(string.Format("{0}: {1}" + Environment.NewLine, name, message));
                    });

                Connection.On<PanelBoardInformationCollection>(MethodNames.NotifyPanelBoardInformationCollection,
                    OnNotifyPanelBoardInformationCollection);
                Connection.On<AccessPortalStatusReply>(MethodNames.NotifyAccessPortalStatusReply,
                    OnNotifyAccessPortalStatusReply);
                Connection.On<AccessPortalCommandReply>(MethodNames.NotifyAccessPortalCommandReply,
                    OnNotifyAccessPortalCommandReply);
                Connection.On<PanelActivityLogMessage>(MethodNames.NotifyPanelActivityLogMessage,
                    OnNotifyPanelActivityLogMessage);
                Connection.On<PanelActivityLogMessage>(MethodNames.NotifyPanelActivityAlarmLogMessage,
                    OnNotifyPanelActivityAlarmLogMessage);

                Connection.On<PanelCredentialActivityLogMessage>(MethodNames.NotifyPanelCredentialActivityLogMessage,
                    OnNotifyPanelCredentialActivityLogMessage);

                Connection.On<PanelCredentialActivityLogMessage>(MethodNames
                    .NotifyPanelCredentialActivityAlarmLogMessage,
                    OnNotifyPanelCredentialActivityAlarmLogMessage);
                Connection.On<PanelInqueryReply>(MethodNames.NotifyPanelInqueryReply, OnNotifyPanelInqueryReply);
                Connection.On<PingReplySignalR>(MethodNames.NotifyPingReply, OnNotifyPingReply);
                Connection.On<CredentialCountReply>(MethodNames.NotifyCardCountReply, OnNotifyCardCountReply);
                Connection.On<LoggingStatusReply>(MethodNames.NotifyLoggingStatusReply, OnNotifyLoggingStatusReply);
                Connection.On<FlashProgressMessage>(MethodNames.NotifyFlashProgressMessage,
                    OnNotifyFlashProgressMessage);
                Connection.On<PanelLoadDataReply>(MethodNames.NotifyPanelLoadDataReply, OnNotifyPanelLoadDataReply);
                Connection.On<AcknowledgedAlarmBasicData>(MethodNames.NotifyAcknowledgedAlarmBasicData,
                    OnNotifyAcknowledgedAlarmBasicData);
                Connection.On<SerialChannelGalaxyDoorModuleDataCollection>(
                    MethodNames.NotifySerialChannelGalaxyDoorModuleDataCollection,
                    OnNotifySerialChannelGalaxyDoorModuleDataCollection);
                Connection.On<SerialChannelGalaxyInputModuleDataCollection>(
                    MethodNames.NotifySerialChannelGalaxyInputModuleDataCollection,
                    OnNotifySerialChannelGalaxyInputModuleDataCollection);
                Connection.On<InputDeviceStatusReply>(MethodNames.NotifyInputDeviceStatusReply,
                    OnNotifyInputDeviceStatusReply);
                Connection.On<InputDeviceVoltagesReply>(MethodNames.NotifyInputDeviceVoltagesReply,
                    OnNotifyInputDeviceVoltagesReply);
                Connection.On<CpuConnectionInfo>(MethodNames.NotifyCpuConnectionInfo, OnNotifyCpuConnectionInfo);
                Connection.On<BackgroundJobInfo>(MethodNames.NotifyBackgroundJobInfo, OnNotifyBackgroundJobInfo);
                Connection.On<SignalREnvelope<OperationStatusInfo>>(MethodNames.NotifyOperationStatusInfo, OnNotifyOperationStatusInfo);
                //Connection.On<ActivityLogData>( MethodNames.NotifyNotInSystemActivityLogData, OnNotInSystemActivityLogData);

                //Connection.On<ActivityLogData>( MethodNames.NotifyAlarmEvent, OnAlarmEvent);

                //Connection.On<AcknowledgeAlarmEvent>( MethodNames.NotifyAcknowledgeAlarmEvent, OnAcknowledgeAlarmEvent);

                //Connection.On<ControllerStatusData>( MethodNames.NotifyControllerStatusData, OnControllerStatusData);

                //Connection.On<GenericAlarmEvent>( MethodNames.NotifyGenericAlarmEvent, OnGenericAlarmEvent);

                //Connection.On<DsrEvent>( MethodNames.NotifyAssaDsrNewEventData, OnAssaDsrNewEvent);

                //Connection.On<NotifyUpdated>( MethodNames.NotifyAssaDsrNotifyUpdatedData, OnAssaDsrNotifyUpdated);
                var startResult = await StartConnection(_sessionId);
                return startResult;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient ConnectAsync exception: {ex}");
            }

            return false;
        }

        private Task Connection_Reconnecting(Exception arg)
        {
            LastStateChange = new StateChange(LastStateChange.NewState, ConnectionState.Reconnecting);
            this.Log().Info("Connection_Reconnecting");
            return Task.CompletedTask;
        }

        private Task Connection_Reconnected(string arg)
        {
            LastStateChange = new StateChange(LastStateChange.NewState, ConnectionState.Connected);

            this.Log().Info("Connection_Reconnected");
            return Task.CompletedTask;
        }

        //public async void ReconnectTimerCallback(Object stateInfo)
        //{
        //    if (LastStateChange.NewState == ConnectionState.Disconnected)
        //        await ConnectAsync(_serverUrl, _sessionId, string.Empty, _bUseJwt);
        //}

        private Task Connection_Closed(Exception arg)
        {
            try
            {
                LastStateChange = new StateChange(LastStateChange.NewState, ConnectionState.Disconnected);

                this.Log().Info($"Connection Closed ConnectionID: {Connection.ConnectionId}");
                var handler = ConnectionClosedEvent;
                if (handler != null)
                    handler(this, new SignalRConnectionClosedEventArgs());

                //if (AutomaticReconnect)
                //{
                //    _reconnectTimer = new Timer(ReconnectTimerCallback, null, 0, ReconnectRetryInterval);
                //}
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient Connection_Closed exception: {ex}");
            }

            return Task.CompletedTask;
        }

        private async Task<bool> StartConnection(Guid sessionId)
        {
            try
            {
                await Connection.StartAsync();
                if (sessionId != Guid.Empty)
                {
                    //GCS.Infrastructure.Logger.LoggerHelper.LogMessage(string.Format("SignalRClient.ConnectAsync joining groups"));

                    this.Log().Info($"Joining SignalR group: {sessionId}");

                    await JoinGroup(sessionId.ToString());

                    //foreach (var lc in _sessionId.AllowedLoopClusters)
                    //{
                    //    var id = lc.LoopClusterID;
                    //    //GCS.Infrastructure.Logger.LoggerHelper.LogMessage(string.Format("SignalRClient.ConnectAsync joining loopCluster {0} Group", id));
                    //    await JoinGroup(lc.LoopClusterID.ToString());
                    //}
                }

                return true;
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().ErrorFormat($"SignalRClient.ConnectAsync exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error($"SignalRClient.ConnectAsync Start exception: {ex}");
                //               StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
            }

            return false;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Disconnects this SignalRClient from the SignalR server. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task Disconnect()
        {
            try
            {
                if (Connection != null)
                {
                    await Connection.StopAsync();
                    //Connection.TraceWriter.Close();
                    await Connection.DisposeAsync();
                    Connection = null;
                }
            }
            catch (Exception e)
            {
                Connection = null;
                this.Log().Error($"SignalRClient.Disconnect exception.", e);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Joins a SignalR group. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        /// <param name="groupName">    Name of the group. </param>
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task JoinGroup(string groupName)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.JoinGroup, new SignalRGroup { GroupName = groupName });
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"SignalRClient.JoinGroup exception. ServerUrl:{_serverUrl}, GroupName:{groupName}, Exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"SignalRClient.JoinGroup exception. ServerUrl:{_serverUrl}, GroupName:{groupName}, Exception: {ex}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Leave group. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        /// <param name="groupName">    Name of the group. </param>
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task LeaveGroup(string groupName)
        {
            try
            {
                //               await Connection.InvokeAsync("LeaveGroup", groupName);
                await Connection.InvokeAsync(MethodNames.LeaveGroup, new SignalRGroup { GroupName = groupName });
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error($"{groupName}: SignalRClient LeaveGroup exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error($"{groupName}: SignalRClient LeaveGroup exception: {ex}");
            }
        }

        public async Task UpdateSessionId(Guid sessionId)
        {
            if (_sessionId != Guid.Empty)
            {
                await LeaveGroup(_sessionId.ToString());
                _sessionId = sessionId;
                if (_sessionId != Guid.Empty)
                    await JoinGroup(_sessionId.ToString());
            }
        }


        public async void NotifyPanelBoardInformationCollectionAsync(PanelBoardInformationCollectionSignalR data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyPanelBoardInformationCollection, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifySerialChannelGalaxyDoorModuleDataCollectionAsync(
            SerialChannelGalaxyDoorModuleDataCollection data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifySerialChannelGalaxyDoorModuleDataCollection, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifySerialChannelGalaxyInputModuleDataCollectionAsync(
            SerialChannelGalaxyInputModuleDataCollection data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifySerialChannelGalaxyInputModuleDataCollection, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyPanelInqueryReplyAsync(PanelInqueryReplySignalR data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyPanelInqueryReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }
        
        public async void NotifyPingReplyAsync(PingReplySignalR data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyPingReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyCardCountReplyAsync(CredentialCountReplySignalR data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyCardCountReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }


        public async void NotifyFlashProgressMessageAsync(FlashProgressMessage data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyFlashProgressMessage, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyPanelLoadDataReplyAsync(PanelLoadDataReplySignalR data)
        {
            try
            {
                await Connection.SendAsync(MethodNames.NotifyPanelLoadDataReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyLoggingStatusReplyAsync(LoggingStatusReplySignalR data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyLoggingStatusReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyAccessPortalStatusReplyAsync(AccessPortalStatusReply data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyAccessPortalStatusReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyAccessPortalCommandReplyAsync(AccessPortalCommandReply data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyAccessPortalCommandReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyInputDeviceStatusReplyAsync(InputDeviceStatusReply data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyInputDeviceStatusReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyInputDeviceVoltagesReplyAsync(InputDeviceVoltagesReply data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyInputDeviceVoltagesReply, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyPanelActivityMessageAsync(PanelActivityLogMessage data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyPanelActivityLogMessage, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        public async void NotifyPanelCredentialActivityMessageAsync(PanelCredentialActivityLogMessage data)
        {
            try
            {
                //                await Connection.InvokeAsync(MethodNames.NotifyPanelCredentialActivityLogMessage, data);
                await Connection.SendAsync(MethodNames.NotifyPanelCredentialActivityLogMessage, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }
        public async void NotifyPanelActivityAlarmMessageAsync(PanelActivityLogMessage data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyPanelActivityAlarmLogMessage, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        public async void NotifyPanelCredentialActivityAlarmMessageAsync(PanelCredentialActivityLogMessage data)
        {
            try
            {
                //                await Connection.InvokeAsync(MethodNames.NotifyPanelCredentialActivityLogMessage, data);
                await Connection.SendAsync(MethodNames.NotifyPanelCredentialActivityAlarmLogMessage, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        public async void NotifyAcknowledgedAlarmBasicDataAsync(AcknowledgedAlarmBasicData data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyAcknowledgedAlarmBasicData, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        public async void NotifyCpuConnectionInfoAsync(CpuConnectionInfo data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyCpuConnectionInfo, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }

        public async void NotifyBackgroundJobInfoAsync(BackgroundJobInfo data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyBackgroundJobInfo, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                    this.Log().Error(
                        $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx}");
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex}");
            }
        }


        public async void NotifyOperationStatusInfoAsync(SignalREnvelope<OperationStatusInfo> data)
        {
            try
            {
                await Connection.InvokeAsync(MethodNames.NotifyOperationStatusInfo, data);
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                {
                    this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {innerEx.ToString()}");
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName}  exception: {ex.ToString()}");
            }

        }


        //public async void NotifyActivityLogDataAsync(ActivityLogData eventLog)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyActivityLogData", eventLog);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyActivityLogDataAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyActivityLogDataAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys a not in system activity log data asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventLog"> The event log. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyNotInSystemActivityLogDataAsync(ActivityLogData eventLog)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyNotInSystemActivityLogData", eventLog);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyNotInSystemActivityLogDataAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyNotInSystemActivityLogDataAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys an alarm event asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventLog"> The event log. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyAlarmEventAsync(ActivityLogData eventLog)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyAlarmEvent", eventLog);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyAlarmEventAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyAlarmEventAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys a generic alarm event. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyGenericAlarmEvent(GenericAlarmEvent eventData)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyGenericAlarmEvent", eventData);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyGenericAlarmEvent exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyGenericAlarmEvent exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys an acknowledge alarm event asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="acknowledgeEventData"> Information describing the acknowledge event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyAcknowledgeAlarmEventAsync(AcknowledgeAlarmEvent acknowledgeEventData)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyAcknowledgeAlarmEvent", acknowledgeEventData);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx,
        //                string.Format("{0}: SignalRClient NotifyAcknowledgeAlarmEventAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyAcknowledgeAlarmEventAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys a door reader status data asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="statusData">   Information describing the status. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyDoorReaderStatusDataAsync(DoorReaderStatus statusData)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyDoorReaderStatusData", statusData);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyControllerStatusDataAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyControllerStatusDataAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys a controller status data asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="controllerData">   Information describing the controller. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyControllerStatusDataAsync(ControllerStatusData controllerData)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyControllerStatusData", controllerData);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyControllerStatusDataAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyControllerStatusDataAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   public async void NotifyAssaDsrNewEventDataAsync(NewEvent eventLog) </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventLog"> The event log. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyAssaDsrNewEventDataAsync(DsrEvent eventLog)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyAssaDsrNewEventData", eventLog);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyAssaDsrNewEventDataAsync exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyAssaDsrNewEventDataAsync exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Notifys an assa dsr Notify updated data asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyAssaDsrNotifyUpdatedDataAsync(NotifyUpdated eventData)
        //{
        //    try
        //    {
        //        await Connection.InvokeAsync(MethodNames.NotifyAssaDsrNotifyUpdatedData", eventData);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            GCS.Infrastructure.Logger.LoggerHelper.LogException(innerEx, string.Format("{0}: SignalRClient NotifyAssaDsrNotifyUpdatedData exception", Name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient NotifyAssaDsrNotifyUpdatedData exception", Name));
        //    }
        //}

        #endregion

        #region EventArgs

        public class PanelBoardInformationCollectionEventArgs : EventArgs
        {
            public PanelBoardInformationCollectionEventArgs(PanelBoardInformationCollection arg)
            {
                EventData = arg;
            }

            public PanelBoardInformationCollection EventData { get; }
        }

        public class SerialChannelGalaxyDoorModuleDataCollectionEventArgs : EventArgs
        {
            public SerialChannelGalaxyDoorModuleDataCollectionEventArgs(SerialChannelGalaxyDoorModuleDataCollection arg)
            {
                EventData = arg;
            }

            public SerialChannelGalaxyDoorModuleDataCollection EventData { get; }
        }

        public class SerialChannelGalaxyInputModuleDataCollectionEventArgs : EventArgs
        {
            public SerialChannelGalaxyInputModuleDataCollectionEventArgs(
                SerialChannelGalaxyInputModuleDataCollection arg)
            {
                EventData = arg;
            }

            public SerialChannelGalaxyInputModuleDataCollection EventData { get; }
        }

        public class PanelInqueryReplyEventArgs : EventArgs
        {
            public PanelInqueryReplyEventArgs(PanelInqueryReply arg)
            {
                EventData = arg;
            }

            public PanelInqueryReply EventData { get; }
        }

        public class PingReplyEventArgs : EventArgs
        {
            public PingReplyEventArgs(PingReplySignalR arg)
            {
                EventData = arg;
            }

            public PingReplySignalR EventData { get; }
        }

        public class LoggingStatusReplyEventArgs : EventArgs
        {
            public LoggingStatusReplyEventArgs(LoggingStatusReply arg)
            {
                EventData = arg;
            }

            public LoggingStatusReply EventData { get; }
        }

        public class FlashProgressMessageEventArgs : EventArgs
        {
            public FlashProgressMessageEventArgs(FlashProgressMessage arg)
            {
                EventData = arg;
            }

            public FlashProgressMessage EventData { get; }
        }

        public class PanelLoadDataReplyEventArgs : EventArgs
        {
            public PanelLoadDataReplyEventArgs(PanelLoadDataReply arg)
            {
                EventData = arg;
            }

            public PanelLoadDataReply EventData { get; }
        }

        public class CardCountReplyEventArgs : EventArgs
        {
            public CardCountReplyEventArgs(CredentialCountReply arg)
            {
                EventData = arg;
            }

            public CredentialCountReply EventData { get; }
        }

        public class AccessPortalStatusReplyEventArgs : EventArgs
        {
            public AccessPortalStatusReplyEventArgs(AccessPortalStatusReply arg)
            {
                EventData = arg;
            }

            public AccessPortalStatusReply EventData { get; set; }
        }

        public class AccessPortalCommandReplyEventArgs : EventArgs
        {
            public AccessPortalCommandReplyEventArgs(AccessPortalCommandReply arg)
            {
                EventData = arg;
            }

            public AccessPortalCommandReply EventData { get; set; }
        }

        public class InputDeviceStatusReplyEventArgs : EventArgs
        {
            public InputDeviceStatusReplyEventArgs(InputDeviceStatusReply arg)
            {
                EventData = arg;
            }

            public InputDeviceStatusReply EventData { get; set; }
        }

        public class InputDeviceVoltagesReplyEventArgs : EventArgs
        {
            public InputDeviceVoltagesReplyEventArgs(InputDeviceVoltagesReply arg)
            {
                EventData = arg;
            }

            public InputDeviceVoltagesReply EventData { get; set; }
        }

        public class CpuConnectionInfoEventArgs : EventArgs
        {
            public CpuConnectionInfoEventArgs(CpuConnectionInfo arg)
            {
                EventData = arg;
            }

            public CpuConnectionInfo EventData { get; set; }
        }

        public class BackgroundJobInfoEventArgs : EventArgs
        {
            public BackgroundJobInfoEventArgs(BackgroundJobInfo arg)
            {
                EventData = arg;
            }

            public BackgroundJobInfo EventData { get; set; }
        }


        public class OperationStatusInfoEventArgs : EventArgs
        {
            public OperationStatusInfoEventArgs(SignalREnvelope<OperationStatusInfo> arg)
            {
                EventData = arg;
            }
            public SignalREnvelope<OperationStatusInfo> EventData { get; set; }
        }

        public class PanelActivityLogMessageEventArgs : EventArgs
        {
            public PanelActivityLogMessageEventArgs(PanelActivityLogMessage arg)
            {
                EventData = arg;
            }

            public PanelActivityLogMessage EventData { get; }
        }

        public class PanelCredentialActivityLogMessageEventArgs : EventArgs
        {
            public PanelCredentialActivityLogMessageEventArgs(PanelCredentialActivityLogMessage arg)
            {
                EventData = arg;
            }

            public PanelCredentialActivityLogMessage EventData { get; }
        }

        public class AcknowledgedAlarmBasicDataEventArgs : EventArgs
        {
            public AcknowledgedAlarmBasicDataEventArgs(AcknowledgedAlarmBasicData arg)
            {
                EventData = arg;
            }

            public AcknowledgedAlarmBasicData EventData { get; }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Contains details about an activity that has occurred on the system. </summary>
        /////
        ///// <remarks>   Kevin, 6/9/2014. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ActivityLogDataEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ActivityLogDataEventArgs(ActivityLogData arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ActivityLogData EventData { get; private set; }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for signal r connection closed events. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public class SignalRConnectionClosedEventArgs : EventArgs
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            /// <remarks>   Kevin, 9/6/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public SignalRConnectionClosedEventArgs()
            {
                WhenClosed = DateTimeOffset.Now;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the Date/Time of the when closed. </summary>
            /// <value> The when closed. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public DateTimeOffset WhenClosed { get; internal set; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for acknowledge alarm events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class AcknowledgeAlarmEventArgs : EventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 9/6/2018. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public AcknowledgeAlarmEventArgs(AcknowledgeAlarmEvent arg)
        //        : base()
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public AcknowledgeAlarmEvent EventData { get; private set; }

        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for generic alarm events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class GenericAlarmEventArgs : EventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 9/6/2018. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public GenericAlarmEventArgs(GenericAlarmEvent arg)
        //        : base()
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public GenericAlarmEvent EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// // <summary>   Contains details about the current status of a specific door. </summary>
        ///// //// <remarks>   Kevin, 6/9/2014. </remarks>
        ///// </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class DoorStatusEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public DoorStatusEventArgs(DoorReaderStatus arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public DoorReaderStatus EventData { get; private set; }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////// <summary>   Contains details about the current status of a input device. </summary>
        ///////
        /////// <remarks>   Kevin, 6/9/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public class InputDeviceStatusEventArgs
        ////{
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 6/9/2014. </remarks>
        ////    ///
        ////    /// <param name="arg">  The argument. </param>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public InputDeviceStatusEventArgs(InputDeviceStatus arg)
        ////    {
        ////        EventData = arg;
        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Gets or sets information describing the event. </summary>
        ////    ///
        ////    /// <value> Information describing the event. </value>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public InputDeviceStatus EventData { get; private set; }
        ////}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////// <summary>
        /////// Contains details about the current voltage levels of a specific input device.
        /////// </summary>
        ///////
        /////// <remarks>   Kevin, 6/9/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public class InputDeviceVoltageEventArgs
        ////{
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 6/9/2014. </remarks>
        ////    ///
        ////    /// <param name="arg">  The argument. </param>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public InputDeviceVoltageEventArgs(InputDeviceVoltages arg)
        ////    {
        ////        EventData = arg;
        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Gets or sets information describing the event. </summary>
        ////    ///
        ////    /// <value> Information describing the event. </value>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public InputDeviceVoltages EventData { get; private set; }
        ////}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////// <summary>   Contains details about the current status of a specific output device. </summary>
        ///////
        /////// <remarks>   Kevin, 6/9/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public class OutputPortStatusEventArgs
        ////{
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 6/9/2014. </remarks>
        ////    ///
        ////    /// <param name="arg">  The argument. </param>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public OutputPortStatusEventArgs(OutputPortStatus arg)
        ////    {
        ////        EventData = arg;
        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Gets or sets information describing the event. </summary>
        ////    ///
        ////    /// <value> Information describing the event. </value>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public OutputPortStatus EventData { get; private set; }
        ////}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller information events. </summary>
        /////
        ///// <remarks>   Kevin, 4/8/2015. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerInformationEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerInformationEventArgs(ControlUnitInformation arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControlUnitInformation EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller logging status information events. </summary>
        /////
        ///// <remarks>   Kevin, 4/8/2015. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerLoggingStatusInformationEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerLoggingStatusInformationEventArgs(ControlUnitLoggingStatusInformation arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControlUnitLoggingStatusInformation EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller card count events. </summary>
        /////
        ///// <remarks>   Kevin, 4/8/2015. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerCardCountEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerCardCountEventArgs(ControllerCardCount arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerCardCount EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller ping reply events. </summary>
        /////
        ///// <remarks>   Kevin, 4/8/2015. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerPingReplyEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerPingReplyEventArgs(ControllerPingReply arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerPingReply EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller reply events. </summary>
        /////
        ///// <remarks>   Kevin, 7/27/2015. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerReplyEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerReplyEventArgs(ControllerReplyBase arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerReplyBase EventData { get; private set; }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for controller status data events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class ControllerStatusDataEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerStatusDataEventArgs(ControllerStatusData arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public ControllerStatusData EventData { get; private set; }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////// <summary>   Additional information for execute command script events. </summary>
        ///////
        /////// <remarks>   Kevin, 7/27/2015. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public class ExecuteCommandScriptEventArgs : EventArgs
        ////{
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Default constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 7/27/2015. </remarks>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public ExecuteCommandScriptEventArgs()
        ////        : base()
        ////    {

        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 7/27/2015. </remarks>
        ////    ///
        ////    /// <param name="scriptId"> Identifier for the script. </param>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public ExecuteCommandScriptEventArgs(UInt32 scriptId)
        ////        : base()
        ////    {
        ////        CommandScriptId = scriptId;
        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Gets or sets the identifier of the command script. </summary>
        ////    ///
        ////    /// <value> The identifier of the command script. </value>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public UInt32 CommandScriptId { get; set; }
        ////}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for assa dsr Notify updated events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class AssaDsrNotifyUpdatedEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public AssaDsrNotifyUpdatedEventArgs(NotifyUpdated arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public NotifyUpdated EventData { get; private set; }
        //}

        ////public class AssaDsrNewEventEventArgs
        ////{
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Constructor. </summary>
        ////    ///
        ////    /// <remarks>   Kevin, 6/9/2014. </remarks>
        ////    ///
        ////    /// <param name="arg">  The argument. </param>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public AssaDsrNewEventEventArgs(NewEvent arg)
        ////    {
        ////        EventData = arg;
        ////    }

        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////    /// <summary>   Gets or sets information describing the event. </summary>
        ////    ///
        ////    /// <value> Information describing the event. </value>
        ////    ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////    public NewEvent EventData { get; private set; }
        ////}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Additional information for assa dsr new event events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public class AssaDsrNewEventEventArgs
        //{
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Constructor. </summary>
        //    ///
        //    /// <remarks>   Kevin, 6/9/2014. </remarks>
        //    ///
        //    /// <param name="arg">  The argument. </param>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public AssaDsrNewEventEventArgs(DsrEvent arg)
        //    {
        //        EventData = arg;
        //    }

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////
        //    /// <summary>   Gets or sets information describing the event. </summary>
        //    ///
        //    /// <value> Information describing the event. </value>
        //    ////////////////////////////////////////////////////////////////////////////////////////////////////

        //    public DsrEvent EventData { get; private set; }
        //}

        #endregion

        #region Events

        #region PanelBoardInformationCollection Event

        public delegate void PanelBoardInformationCollectionHandler(object sender,
            PanelBoardInformationCollectionEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PanelBoardInformationCollectionHandler PanelBoardInformationCollectionEvent;

        #endregion

        #region SerialChannelGalaxyDoorModuleDataCollection Event

        public delegate void SerialChannelGalaxyDoorModuleDataCollectionHandler(object sender,
            SerialChannelGalaxyDoorModuleDataCollectionEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event SerialChannelGalaxyDoorModuleDataCollectionHandler
            SerialChannelGalaxyDoorModuleDataCollectionEvent;

        #endregion

        #region SerialChannelGalaxyInputModuleDataCollection Event

        public delegate void SerialChannelGalaxyInputModuleDataCollectionHandler(object sender,
            SerialChannelGalaxyInputModuleDataCollectionEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event SerialChannelGalaxyInputModuleDataCollectionHandler
            SerialChannelGalaxyInputModuleDataCollectionEvent;

        #endregion

        #region PanelInqueryReply Event

        public delegate void PanelInqueryReplyHandler(object sender, PanelInqueryReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PanelInqueryReplyHandler PanelInqueryReplyEvent;

        #endregion

        #region PingReply Event

        public delegate void PingReplyHandler(object sender, PingReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PingReplyHandler PingReplyEvent;

        #endregion

        #region CardCountReply Event

        public delegate void CardCountReplyHandler(object sender, CardCountReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event CardCountReplyHandler CardCountReplyEvent;

        #endregion

        #region LoggingStatusReply Event

        public delegate void LoggingStatusReplyHandler(object sender, LoggingStatusReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event LoggingStatusReplyHandler LoggingStatusReplyEvent;

        #endregion

        #region FlashProgressMessage Event

        public delegate void FlashProgressMessageHandler(object sender, FlashProgressMessageEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event FlashProgressMessageHandler FlashProgressMessageEvent;

        #endregion

        #region PanelLoadDataReply Event

        public delegate void PanelLoadDataReplyHandler(object sender, PanelLoadDataReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PanelLoadDataReplyHandler PanelLoadDataReplyEvent;

        #endregion

        #region AccessPortalStatusReply Event

        public delegate void AccessPortalStatusReplyHandler(object sender, AccessPortalStatusReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event AccessPortalStatusReplyHandler AccessPortalStatusReplyEvent;

        #endregion

        #region AccessPortalCommandReply Event

        public delegate void AccessPortalCommandReplyHandler(object sender, AccessPortalCommandReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event AccessPortalCommandReplyHandler AccessPortalCommandReplyEvent;

        #endregion

        #region InputDeviceStatusReply Event

        public delegate void InputDeviceStatusReplyHandler(object sender, InputDeviceStatusReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event InputDeviceStatusReplyHandler InputDeviceStatusReplyEvent;

        #endregion

        #region InputDeviceVoltagesReply Event

        public delegate void InputDeviceVoltagesReplyHandler(object sender, InputDeviceVoltagesReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event InputDeviceVoltagesReplyHandler InputDeviceVoltagesReplyEvent;

        #endregion


        #region CpuConnectionInfo Event

        public delegate void CpuConnectionInfoHandler(object sender, CpuConnectionInfoEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event CpuConnectionInfoHandler CpuConnectionInfoEvent;

        #endregion


        #region BackgroundJobInfo Event

        public delegate void BackgroundJobInfoHandler(object sender, BackgroundJobInfoEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event BackgroundJobInfoHandler BackgroundJobInfoEvent;

        #endregion


        #region SignalREnvelope<OperationStatusInfo> Event
        public delegate void OperationStatusInfoHandler(object sender, OperationStatusInfoEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event OperationStatusInfoHandler OperationStatusInfoEvent;

        #endregion


        #region Panel Credential Activity Log Events

        public delegate void PanelCredentialActivityLogMessageEventHandler(object sender,
            PanelCredentialActivityLogMessageEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler CredentialActivityLogEvent;

        /// <summary>   Event queue for all listeners interested in notInSystemActivityLog events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler NotInPanelMemoryCredentialActivityLogEvent;

        /// <summary>   Event queue for all listeners interested in alarm events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler CredentialAlarmEvent;

        #endregion

        #region Panel Activity Log Events

        public delegate void PanelActivityLogMessageEventHandler(object sender, PanelActivityLogMessageEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event PanelActivityLogMessageEventHandler ActivityLogEvent;

        /// <summary>   Event queue for all listeners interested in alarm events. </summary>
        public event PanelActivityLogMessageEventHandler AlarmEvent;

        #endregion

        #region AcknowledgedAlarmBasicData Event

        public delegate void AcknowledgedAlarmBasicDataHandler(object sender, AcknowledgedAlarmBasicDataEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event AcknowledgedAlarmBasicDataHandler AcknowledgedAlarmBasicDataEvent;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Delegate for handling ControllerStatusData events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name = "sender" > Source of the event. </param>
        ///// <param name="e">        Controller status data event information. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public delegate void ControllerStatusDataEventHandler(object sender, ControllerStatusDataEventArgs e);

        ///// <summary>   Event queue for all listeners interested in controllerStatusData events. </summary>
        ////public event ControllerStatusDataEventHandler ControllerStatusDataEvent;


        //#region Generic Alarm Event

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Delegate for handling GenericAlarm events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="sender">   Source of the event. </param>
        ///// <param name="e">        Generic alarm event information. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public delegate void GenericAlarmEventHandler(object sender, GenericAlarmEventArgs e);

        ///// <summary>   Declare the event. </summary>
        //public event GenericAlarmEventHandler GenericAlarmEvent;
        //#endregion

        #region Connection closed

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ConnectionClosed events. </summary>
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Signal r connection closed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public delegate void ConnectionClosedEventHandler(object sender, SignalRConnectionClosedEventArgs e);

        /// <summary>   Event queue for all listeners interested in connectionClosed events. </summary>
        public event ConnectionClosedEventHandler ConnectionClosedEvent;

        #endregion Connection closed

        //#region Alarm Acknowledge Events

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Declare the delegate. </summary>
        /////
        ///// <remarks>   Kevin, 6/9/2014. </remarks>
        /////
        ///// <param name="sender">   Source of the event. </param>
        ///// <param name="e">        Activity log event information. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public delegate void AcknowledgeAlarmEventHandler(object sender, AcknowledgeAlarmEventArgs e);

        ///// <summary>   Declare the event. </summary>
        //public event AcknowledgeAlarmEventHandler AcknowledgeAlarmEvent;

        //#endregion Alarm Acknowledge Events

        //#region Door Status Event

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Delegate for handling DoorStatus events. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="sender">   Source of the event. </param>
        ///// <param name="e">        Door status event information. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public delegate void DoorStatusEventHandler(object sender, DoorStatusEventArgs e);

        ///// <summary>   Declare the event. </summary>
        //public event DoorStatusEventHandler DoorReaderStatusEvent;

        //#endregion Door Status Events

        //#region Assa DSR Events

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Delegate for handling AssaDsrNotifyUpdated events. </summary>
        /////
        ///// <remarks>   Kevin, 10/3/2016. </remarks>
        /////
        ///// <param name="sender">   Source of the event. </param>
        ///// <param name="e">        Assa dsr Notify updated event information. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public delegate void AssaDsrNotifyUpdatedEventHandler(object sender, AssaDsrNotifyUpdatedEventArgs e);

        ///// <summary>   Event queue for all listeners interested in assaDsrNotifyUpdated events. </summary>
        //public event AssaDsrNotifyUpdatedEventHandler AssaDsrNotifyUpdatedEvent;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Delegate for handling OnAssaDsrNewEvent events. </summary>
        /////
        ///// <remarks>   Kevin, 10/3/2016. </remarks>
        /////
        ///// <param name="sender">   Source of the event. </param>
        ///// <param name="e">        Event information to send to registered event handlers. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public delegate void OnAssaDsrNewEventEventHandler(object sender, AssaDsrNewEventEventArgs e);

        ///// <summary>   Event queue for all listeners interested in onAssaDsrNewEvent events. </summary>
        //public event OnAssaDsrNewEventEventHandler OnAssaDsrNewEventEvent;

        //#endregion

        #endregion Events

        #region Private methods

        private void OnNotifyPanelBoardInformationCollection(PanelBoardInformationCollection data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyPanelBoardInformationCollection ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = PanelBoardInformationCollectionEvent;
                if (handler != null)
                    handler(this, new PanelBoardInformationCollectionEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyPanelInqueryReply(PanelInqueryReply data)
        {
            try
            {
                var handler = PanelInqueryReplyEvent;
                if (handler != null)
                    handler(this, new PanelInqueryReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyPingReply(PingReplySignalR data)
        {
            try
            {
                var handler = PingReplyEvent;
                if (handler != null)
                    handler(this, new PingReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifySerialChannelGalaxyDoorModuleDataCollection(
            SerialChannelGalaxyDoorModuleDataCollection data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyPanelBoardInformationCollection ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = SerialChannelGalaxyDoorModuleDataCollectionEvent;
                if (handler != null)
                    handler(this, new SerialChannelGalaxyDoorModuleDataCollectionEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifySerialChannelGalaxyInputModuleDataCollection(
            SerialChannelGalaxyInputModuleDataCollection data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyPanelBoardInformationCollection ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = SerialChannelGalaxyInputModuleDataCollectionEvent;
                if (handler != null)
                    handler(this, new SerialChannelGalaxyInputModuleDataCollectionEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyCardCountReply(CredentialCountReply data)
        {
            try
            {
                var handler = CardCountReplyEvent;
                if (handler != null)
                    handler(this, new CardCountReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyLoggingStatusReply(LoggingStatusReply data)
        {
            try
            {
                var handler = LoggingStatusReplyEvent;
                if (handler != null)
                    handler(this, new LoggingStatusReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyFlashProgressMessage(FlashProgressMessage data)
        {
            try
            {
                var handler = FlashProgressMessageEvent;
                if (handler != null)
                    handler(this, new FlashProgressMessageEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }


        private void OnNotifyPanelLoadDataReply(PanelLoadDataReply data)
        {
            try
            {
                var handler = PanelLoadDataReplyEvent;
                if (handler != null)
                    handler(this, new PanelLoadDataReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyAccessPortalStatusReply(AccessPortalStatusReply data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyAccessPortalStatusReply ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = AccessPortalStatusReplyEvent;
                if (handler != null)
                    handler(this, new AccessPortalStatusReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyAccessPortalCommandReply(AccessPortalCommandReply data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyAccessPortalStatusReply ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = AccessPortalCommandReplyEvent;
                if (handler != null)
                    handler(this, new AccessPortalCommandReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }


        private void OnNotifyInputDeviceStatusReply(InputDeviceStatusReply data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyInputDeviceStatusReply ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = InputDeviceStatusReplyEvent;
                if (handler != null)
                    handler(this, new InputDeviceStatusReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyInputDeviceVoltagesReply(InputDeviceVoltagesReply data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyInputDeviceVoltagesReply ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = InputDeviceVoltagesReplyEvent;
                if (handler != null)
                    handler(this, new InputDeviceVoltagesReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyCpuConnectionInfo(CpuConnectionInfo data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyCpuConnectionInfo ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = CpuConnectionInfoEvent;
                if (handler != null)
                    handler(this, new CpuConnectionInfoEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyBackgroundJobInfo(BackgroundJobInfo data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyCpuConnectionInfo ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = BackgroundJobInfoEvent;
                if (handler != null)
                    handler(this, new BackgroundJobInfoEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyOperationStatusInfo(SignalREnvelope<OperationStatusInfo> data)
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotifyBackgroundJobInfo ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = OperationStatusInfoEvent;
                if (handler != null)
                    handler(this, new OperationStatusInfoEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }


        private void OnNotifyPanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage data)
        {
            try
            {
                if (data.PanelActivityType == PanelActivityEventCode.CredentialNotInPanelMemory ||
                    data.PanelActivityType == PanelActivityEventCode.CredentialNotInPanelMemoryReverse)
                {
                    var handlerNotInMemory = NotInPanelMemoryCredentialActivityLogEvent;
                    if (handlerNotInMemory != null)
                        handlerNotInMemory(this, new PanelCredentialActivityLogMessageEventArgs(data));
                }
                else
                {
                    var handler = CredentialActivityLogEvent;
                    if (handler != null)
                        handler(this, new PanelCredentialActivityLogMessageEventArgs(data));
                }

                if (data.IsAlarmEvent)
                {
                    var alarmHandler = CredentialAlarmEvent;
                    if (alarmHandler != null)
                        alarmHandler(this, new PanelCredentialActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyPanelCredentialActivityAlarmLogMessage(PanelCredentialActivityLogMessage data)
        {
            try
            {
                //if (data.PanelActivityType == PanelActivityEventCode.CredentialNotInPanelMemory ||
                //    data.PanelActivityType == PanelActivityEventCode.CredentialNotInPanelMemoryReverse)
                //{
                //    var handlerNotInMemory = NotInPanelMemoryCredentialActivityLogEvent;
                //    if (handlerNotInMemory != null)
                //        handlerNotInMemory(this, new PanelCredentialActivityLogMessageEventArgs(data));
                //}
                //else
                //{
                //    var handler = CredentialActivityLogEvent;
                //    if (handler != null)
                //        handler(this, new PanelCredentialActivityLogMessageEventArgs(data));
                //}

                if (data.IsAlarmEvent)
                {
                    var alarmHandler = CredentialAlarmEvent;
                    if (alarmHandler != null)
                        alarmHandler(this, new PanelCredentialActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }


        private void OnNotifyPanelActivityLogMessage(PanelActivityLogMessage data)
        {
            try
            {
                var handler = ActivityLogEvent;
                if (handler != null)
                    handler(this, new PanelActivityLogMessageEventArgs(data));

                if (data.IsAlarmEvent)
                {
                    var alarmHandler = AlarmEvent;
                    if (alarmHandler != null)
                        alarmHandler(this, new PanelActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }
        
        private void OnNotifyPanelActivityAlarmLogMessage(PanelActivityLogMessage data)
        {
            try
            {
                var handler = ActivityLogEvent;
                if (handler != null)
                    handler(this, new PanelActivityLogMessageEventArgs(data));

                if (data.IsAlarmEvent)
                {
                    var alarmHandler = AlarmEvent;
                    if (alarmHandler != null)
                        alarmHandler(this, new PanelActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }

        private void OnNotifyAcknowledgedAlarmBasicData(AcknowledgedAlarmBasicData data)
        {
            try
            {
                var handler = AcknowledgedAlarmBasicDataEvent;
                if (handler != null)
                    handler(this, new AcknowledgedAlarmBasicDataEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{Name}: SignalRClient {MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex}");
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the activity log data action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnNotifyPanelCredentialActivityLogMessage(ActivityLogData eventData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnActivityLogData ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
        //        var handler = ActivityLogEvent;
        //        if (handler != null)
        //            handler(this, new ActivityLogDataEventArgs(eventData));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnActivityLogData exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the not in system activity log data action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnNotInSystemActivityLogData(ActivityLogData eventData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnNotInSystemActivityLogData ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
        //        var handler = NotInSystemActivityLogEvent;
        //        if (handler != null)
        //            handler(this, new ActivityLogDataEventArgs(eventData));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnNotInSystemActivityLogData exception", Name));
        //    }

        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the alarm event action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnAlarmEvent(ActivityLogData eventData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAlarmEvent ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
        //        if (eventData.Acknowledgable)
        //        {
        //            var handler = AlarmEvent;
        //            if (handler != null)
        //                handler(this, new ActivityLogDataEventArgs(eventData));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnAlarmEvent exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the acknowledge alarm event action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="acknowledgeEventData"> Information describing the acknowledge event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnAcknowledgeAlarmEvent(AcknowledgeAlarmEvent acknowledgeEventData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAcknowledgeAlarmEvent ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
        //        var handler = AcknowledgeAlarmEvent;
        //        if (handler != null)
        //            handler(this, new AcknowledgeAlarmEventArgs(acknowledgeEventData));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnAcknowledgeAlarmEvent exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the door reader status data action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="doorStatusData">   Information describing the door status. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnDoorReaderStatusData(DoorReaderStatus doorStatusData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnDoorReaderStatusData ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));

        //        var handler = DoorReaderStatusEvent;
        //        if (handler != null)
        //            handler(this, new DoorStatusEventArgs(doorStatusData));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnDoorReaderStatusData exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the controller status data action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="controllerData">   Information describing the controller. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnControllerStatusData(ControllerStatusData controllerData)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnControllerStatusData ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));

        //        var handler = ControllerStatusDataEvent;
        //        if (handler != null)
        //            handler(this, new ControllerStatusDataEventArgs(controllerData));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnControllerStatusData exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the generic alarm event action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="genericAlarmEvent">    The generic alarm event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnGenericAlarmEvent(GenericAlarmEvent genericAlarmEvent)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnGenericAlarmEvent ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));

        //        var handler = GenericAlarmEvent;
        //        if (handler != null)
        //            handler(this, new GenericAlarmEventArgs(genericAlarmEvent));
        //    }
        //    catch (Exception ex)
        //    {
        //        GCS.Infrastructure.Logger.LoggerHelper.LogException(ex, string.Format("{0}: SignalRClient OnGenericAlarmEvent exception", Name));
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the assa dsr Notify updated action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="obj">  The object. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnAssaDsrNotifyUpdated(NotifyUpdated obj)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAssaDsrNotifyUpdated AccessPoint.Id:{2}", DateTimeOffset.Now, Name, obj.accessPoint.id));

        //        var handler = AssaDsrNotifyUpdatedEvent;
        //        if (handler != null)
        //            handler(this, new AssaDsrNotifyUpdatedEventArgs(obj));
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAssaDsrNotifyUpdated Exception:{2}", DateTimeOffset.Now, Name, ex.ToString()));
        //    }
        //}

        ////private void OnAssaDsrNewEvent(NewEvent obj)
        ////{
        ////    Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAssaDsrNewEvent {2}", DateTimeOffset.Now, Name, obj.logEntry.code));

        ////    var handler = OnAssaDsrNewEventEvent;
        ////    if (handler != null)
        ////        handler(this, new AssaDsrNewEventEventArgs(obj));
        ////}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the assa dsr new event action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="obj">  The object. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnAssaDsrNewEvent(DsrEvent obj)
        //{
        //    try
        //    {
        //        //Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAssaDsrNewEvent {2}", DateTimeOffset.Now, Name, obj.logEntry.code));

        //        var handler = OnAssaDsrNewEventEvent;
        //        if (handler != null)
        //            handler(this, new AssaDsrNewEventEventArgs(obj));
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(string.Format("{0}: SignalRClient {1} OnAssaDsrNotifyUpdated Exception:{2}", DateTimeOffset.Now, Name, ex.ToString()));
        //    }
        //}

        #endregion
    }
}