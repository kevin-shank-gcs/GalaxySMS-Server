using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Logger;
using GCS.Core.Common.SignalR;
using GCS.Core.Common.Utils;
using Microsoft.AspNet.SignalR.Client;
using ConnectionState = GCS.Core.Common.SignalR.ConnectionState;
using StateChange = GCS.Core.Common.SignalR.StateChange;

namespace GalaxySMS.Client.SignalRClient
{
    public class SignalRClient : IDisposable
    {
        #region Private fields
        /// <summary>   URL of the server. </summary>
        private string _serverUrl = string.Empty;
        private Guid _sessionId;
        private bool _bDontAutoReconnect = false;

        #endregion

        #region Constructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SignalRClient()
        {
            Name = GCS.Core.Common.Utils.SystemUtilities.MyProcessName;
            LastStateChange = new StateChange(ConnectionState.Disconnected, ConnectionState.Disconnected);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="name"> The name. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SignalRClient(string name)
        {
            Name = name;
            LastStateChange = new StateChange(ConnectionState.Disconnected, ConnectionState.Disconnected);
        }
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name { get; internal set; }

        public ConnectionState ConnectionState
        {
            get => LastStateChange.NewState;
        }

        public StateChange LastStateChange { get; internal set; }

        #endregion

        #region Public methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
                Connection = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connects to the SignalR server identified by the serverUrl. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="serverUrl">    URL of the server. </param>
        /// <param name="_sessionId">   The session Guid value. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> ConnectAsync(string serverUrl, Guid sessionId)
        {
            _sessionId = sessionId;
            Disconnect();
            _serverUrl = serverUrl;
            Connection = new HubConnection(_serverUrl);
            if (_sessionId != null)
                Connection.Headers.Add("sessionId", _sessionId.ToString());
            Connection.Closed += Connection_Closed;
            Connection.StateChanged += Connection_StateChanged;

            var traceFilename = string.Format("{0}\\ClientSignalRLog.txt", GCS.Core.Common.Utils.SystemUtilities.MyFolderLocation);

            var writer = new StreamWriter(traceFilename);
            writer.AutoFlush = true;
            Connection.TraceLevel = TraceLevels.All;
            Connection.TraceWriter = writer;

            HubProxy = Connection.CreateHubProxy("GalaxySMSSignalRHub");
            Connection.Error += Connection_Error;
            HubProxy.On<string, string>("addMessage",
                (name, message) => { Trace.WriteLine(string.Format("{0}: {1}" + Environment.NewLine, name, message)); });

            HubProxy.On<PanelBoardInformationCollection>("notifyPanelBoardInformationCollection", OnNotifyPanelBoardInformationCollection);
            HubProxy.On<AccessPortalStatusReply>("notifyAccessPortalStatusReply", OnAccessPortalStatusReply);
            HubProxy.On<AccessPortalCommandReply>("notifyAccessPortalCommandReply", OnAccessPortalCommandReply);
            HubProxy.On<InputDeviceStatusReply>("notifyInputDeviceStatusReply", OnInputDeviceStatusReply);
            HubProxy.On<InputDeviceVoltagesReply>("notifyInputDeviceVoltagesReply", OnInputDeviceVoltagesReply);
            HubProxy.On<PanelActivityLogMessage>("notifyPanelActivityLogMessage", OnNotifyPanelActivityLogMessage);
            HubProxy.On<PanelCredentialActivityLogMessage>("notifyPanelCredentialActivityLogMessage", OnNotifyPanelCredentialActivityLogMessage);
            HubProxy.On<PanelInqueryReply>("notifyPanelInqueryReply", OnNotifyPanelInqueryReply);
            HubProxy.On<CredentialCountReply>("notifyCardCountReply", OnNotifyCardCountReply);
            HubProxy.On<LoggingStatusReply>("notifyLoggingStatusReply", OnNotifyLoggingStatusReply);
            HubProxy.On<FlashProgressMessage>("notifyFlashProgressMessage", OnNotifyFlashProgressMessage);
            HubProxy.On<PanelLoadDataReply>("notifyPanelLoadDataReply", OnNotifyPanelLoadDataReply);
            HubProxy.On<AcknowledgedAlarmBasicData>("notifyAcknowledgedAlarmBasicData", OnNotifyAcknowledgedAlarmBasicData);
            HubProxy.On<SerialChannelGalaxyDoorModuleDataCollection>("notifySerialChannelGalaxyDoorModuleDataCollection", OnNotifySerialChannelGalaxyDoorModuleDataCollection);
            HubProxy.On<SerialChannelGalaxyInputModuleDataCollection>("notifySerialChannelGalaxyInputModuleDataCollection", OnNotifySerialChannelGalaxyInputModuleDataCollection);


            //HubProxy.On<ActivityLogData>("notifyNotInSystemActivityLogData", OnNotInSystemActivityLogData);

            //HubProxy.On<ActivityLogData>("notifyAlarmEvent", OnAlarmEvent);

            //HubProxy.On<AcknowledgeAlarmEvent>("notifyAcknowledgeAlarmEvent", OnAcknowledgeAlarmEvent);

            //HubProxy.On<DoorReaderStatus>("notifyDoorReaderStatusData", OnDoorReaderStatusData);

            //HubProxy.On<ControllerStatusData>("notifyControllerStatusData", OnControllerStatusData);

            //HubProxy.On<GenericAlarmEvent>("notifyGenericAlarmEvent", OnGenericAlarmEvent);

            //HubProxy.On<DsrEvent>("notifyAssaDsrNewEventData", OnAssaDsrNewEvent);

            //HubProxy.On<NotifyUpdated>("notifyAssaDsrNotifyUpdatedData", OnAssaDsrNotifyUpdated);
            return await StartConnection(_sessionId);
        }

        public void Disconnect()
        {
            if (Connection != null)
            {
                var writer = Connection.TraceWriter as StreamWriter;
                Connection.Stop();
                //Connection.TraceWriter.Close();
                Connection.Dispose();
                if (writer != null && writer.BaseStream != null)
                    writer.Close();
                Connection = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Joins a SignalR group. </summary>
        ///
        /// <remarks>   The groupName should be the EntityId or SessionId value that the application wants to receive notifications from. </remarks>
        ///
        /// <param name="groupName">    Name of the group. This should be a Guid value in string format.</param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task JoinGroup(string groupName)
        {
            try
            {
                //GCS.Infrastructure.Logger.LoggerHelper.LogMessage(string.Format("SignalRClient JoinGroup({0})", groupName));

                //                await HubProxy.Invoke("JoinGroup", groupName);
                await HubProxy.Invoke("JoinGroup", new SignalRGroup() { GroupName = groupName });
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                {
                    this.Log().Error($"SignalRClient.JoinGroup exception. ServerUrl:{_serverUrl}, GroupName:{groupName}, Exception: {innerEx.ToString()}");
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"SignalRClient.JoinGroup exception. ServerUrl:{_serverUrl}, GroupName:{groupName}, Exception: {ex.ToString()}");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Leave group. </summary>
        ///
        /// <remarks>   The groupName should be the EntityId or SessionId value that the application wants to stop receiving notifications from. </remarks>
        ///
        /// <param name="groupName">    Name of the group. This should be a Guid value in string format. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task LeaveGroup(string groupName)
        {
            try
            {
                //               await HubProxy.Invoke("LeaveGroup", groupName);
                await HubProxy.Invoke("LeaveGroup", new SignalRGroup() { GroupName = groupName });
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                {
                    this.Log().Error($"{groupName}: SignalRClient LeaveGroup exception: {innerEx.ToString()}");
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{groupName}: SignalRClient LeaveGroup exception: {ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the session identifier described by sessionId. </summary>
        ///
        /// <remarks>   If an application signs in or changes login so that the SessionId changes, this method should be called. This will leave the group with the previous SessionId value and join a new group with the new value. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        //public async void NotifyPanelBoardInformationCollectionAsync(PanelBoardInformationCollection data)
        //{
        //    try
        //    {
        //        await HubProxy.Invoke("NotifyPanelBoardInformationCollection", data);
        //    }
        //    catch (AggregateException ex)
        //    {
        //        var flattenedEx = ex.Flatten();
        //        foreach (var innerEx in flattenedEx.InnerExceptions)
        //        {
        //            this.Log().Error($"{Name}: SignalRClient NotifyActivityLogDataAsync exception: {innerEx.ToString()}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //            this.Log().Error($"{Name}: SignalRClient NotifyActivityLogDataAsync exception: {ex.ToString()}");
        //    }
        //}

        //public async void NotifyActivityLogDataAsync(ActivityLogData eventLog)
        //{
        //    try
        //    {
        //        await HubProxy.Invoke("NotifyActivityLogData", eventLog);
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
        //        await HubProxy.Invoke("NotifyNotInSystemActivityLogData", eventLog);
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
        //        await HubProxy.Invoke("NotifyAlarmEvent", eventLog);
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
        //        await HubProxy.Invoke("NotifyGenericAlarmEvent", eventData);
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
        //        await HubProxy.Invoke("NotifyAcknowledgeAlarmEvent", acknowledgeEventData);
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
        //        await HubProxy.Invoke("NotifyDoorReaderStatusData", statusData);
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
        //        await HubProxy.Invoke("NotifyControllerStatusData", controllerData);
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
        //        await HubProxy.Invoke("NotifyAssaDsrNewEventData", eventLog);
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
        ///// <summary>   Notifys an assa dsr notify updated data asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async void NotifyAssaDsrNotifyUpdatedDataAsync(NotifyUpdated eventData)
        //{
        //    try
        //    {
        //        await HubProxy.Invoke("NotifyAssaDsrNotifyUpdatedData", eventData);
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

        #endregion Public Methods

        #region Private fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the hub proxy. </summary>
        ///
        /// <value> The hub proxy. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IHubProxy HubProxy { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the connection. </summary>
        ///
        /// <value> The connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private HubConnection Connection { get; set; }

        #endregion

        #region EventArgs

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for panel board information collection events. </summary>
        ///
        /// <remarks>   Contains a collection of PanelBoardInformation objects that represent the boards connected to a specific panel. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class PanelBoardInformationCollectionEventArgs : EventArgs
        {
            public PanelBoardInformationCollectionEventArgs(PanelBoardInformationCollection arg)
            {
                BoardsInfo = arg;
            }

            public PanelBoardInformationCollection BoardsInfo { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Additional information for serial channel galaxy door module data collection events.
        /// </summary>
        ///
        /// <seealso cref="T:System.EventArgs"/>
        ///=================================================================================================

        public class SerialChannelGalaxyDoorModuleDataCollectionEventArgs : EventArgs
        {
            public SerialChannelGalaxyDoorModuleDataCollectionEventArgs(SerialChannelGalaxyDoorModuleDataCollection arg)
            {
                EventData = arg;
            }

            public SerialChannelGalaxyDoorModuleDataCollection EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Additional information for serial channel galaxy input module data collection events.
        /// </summary>
        ///
        /// <seealso cref="T:System.EventArgs"/>
        ///=================================================================================================

        public class SerialChannelGalaxyInputModuleDataCollectionEventArgs : EventArgs
        {
            public SerialChannelGalaxyInputModuleDataCollectionEventArgs(SerialChannelGalaxyInputModuleDataCollection arg)
            {
                EventData = arg;
            }

            public SerialChannelGalaxyInputModuleDataCollection EventData { get; private set; }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for panel inquery reply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class PanelInqueryReplyEventArgs : EventArgs
        {
            public PanelInqueryReplyEventArgs(PanelInqueryReply arg)
            {
                EventData = arg;
            }

            public PanelInqueryReply EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for logging status reply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class LoggingStatusReplyEventArgs : EventArgs
        {
            public LoggingStatusReplyEventArgs(LoggingStatusReply arg)
            {
                EventData = arg;
            }

            public LoggingStatusReply EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for flash progress message events. </summary>
        ///
        /// <remarks>   Kevin, 1/24/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class FlashProgressMessageEventArgs : EventArgs
        {
            public FlashProgressMessageEventArgs(FlashProgressMessage arg)
            {
                EventData = arg;
            }

            public FlashProgressMessage EventData { get; private set; }
        }


        public class PanelLoadDataReplyEventArgs : EventArgs
        {
            public PanelLoadDataReplyEventArgs(PanelLoadDataReply arg)
            {
                EventData = arg;
            }

            public PanelLoadDataReply EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for card count reply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class CredentialCountReplyEventArgs : EventArgs
        {
            public CredentialCountReplyEventArgs(CredentialCountReply arg)
            {
                EventData = arg;
            }

            public CredentialCountReply EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for access portal status reply events. </summary>
        ///
        /// <remarks>   Contains a AccessPortalStatusReply object that provides information about the current state of a access portal. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class AccessPortalStatusReplyEventArgs : EventArgs
        {
            public AccessPortalStatusReplyEventArgs(AccessPortalStatusReply arg)
            {
                StatusData = arg;
            }

            public AccessPortalStatusReply StatusData { get; private set; }
        }

        public class AccessPortalCommandReplyEventArgs : EventArgs
        {
            public AccessPortalCommandReplyEventArgs(AccessPortalCommandReply arg)
            {
                EventData = arg;
            }

            public AccessPortalCommandReply EventData { get; set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for input device status reply events. </summary>
        ///
        /// <seealso cref="T:System.EventArgs"/>
        ///=================================================================================================

        public class InputDeviceStatusReplyEventArgs : EventArgs
        {
            public InputDeviceStatusReplyEventArgs(InputDeviceStatusReply arg)
            {
                StatusData = arg;
            }

            public InputDeviceStatusReply StatusData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for input device voltages reply events. </summary>
        ///
        /// <seealso cref="T:System.EventArgs"/>
        ///=================================================================================================

        public class InputDeviceVoltagesReplyEventArgs : EventArgs
        {
            public InputDeviceVoltagesReplyEventArgs(InputDeviceVoltagesReply arg)
            {
                StatusData = arg;
            }

            public InputDeviceVoltagesReply StatusData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for panel activity log message events. </summary>
        ///
        /// <remarks>   Contains a PanelActivityLogMessage object that provides information about a specific activity that occured on the system. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class PanelActivityLogMessageEventArgs : EventArgs
        {
            public PanelActivityLogMessageEventArgs(PanelActivityLogMessage arg)
            {
                EventData = arg;
            }

            public PanelActivityLogMessage EventData { get; private set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Additional information for panel credential activity log message events.
        /// </summary>
        ///
        /// <remarks>   Contains a PanelCredentialActivityLogMessage object that provides information about a specific credential based activity that occured on the system. </remarks>
        ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class PanelCredentialActivityLogMessageEventArgs : EventArgs
        {
            public PanelCredentialActivityLogMessageEventArgs(PanelCredentialActivityLogMessage arg)
            {
                EventData = arg;
            }

            public PanelCredentialActivityLogMessage EventData { get; private set; }
        }

        public class AcknowledgedAlarmBasicDataEventArgs : EventArgs
        {
            public AcknowledgedAlarmBasicDataEventArgs(AcknowledgedAlarmBasicData arg)
            {
                EventData = arg;
            }
            public AcknowledgedAlarmBasicData EventData { get; private set; }
        }

        #endregion

        #region Events
        #region PanelBoardInformationCollection Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling PanelBoardInformationCollection events. </summary>
        /// 
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel board information collection event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelBoardInformationCollectionHandler(object sender, PanelBoardInformationCollectionEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in PanelBoardInformationCollection events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event PanelBoardInformationCollectionHandler PanelBoardInformationCollectionEvent;

        #endregion

        #region SerialChannelGalaxyDoorModuleDataCollection Event
        public delegate void SerialChannelGalaxyDoorModuleDataCollectionHandler(object sender, SerialChannelGalaxyDoorModuleDataCollectionEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event SerialChannelGalaxyDoorModuleDataCollectionHandler SerialChannelGalaxyDoorModuleDataCollectionEvent;

        #endregion

        #region SerialChannelGalaxyInputModuleDataCollection Event
        public delegate void SerialChannelGalaxyInputModuleDataCollectionHandler(object sender, SerialChannelGalaxyInputModuleDataCollectionEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event SerialChannelGalaxyInputModuleDataCollectionHandler SerialChannelGalaxyInputModuleDataCollectionEvent;
        #endregion

        #region PanelInqueryReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling PanelInqueryReply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel inquery reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelInqueryReplyHandler(object sender, PanelInqueryReplyEventArgs e);


        /// <summary>   Event queue for all listeners interested in panelInqueryReply events. </summary>
        public event PanelInqueryReplyHandler PanelInqueryReplyEvent;

        #endregion

        #region CardCountReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling CardCountReply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Card count reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void CredentialCountReplyHandler(object sender, CredentialCountReplyEventArgs e);


        /// <summary>   Event queue for all listeners interested in cardCountReply events. </summary>
        public event CredentialCountReplyHandler CredentialCountReplyEvent;

        #endregion

        #region LoggingStatusReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling LoggingStatusReply events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Logging status reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void LoggingStatusReplyHandler(object sender, LoggingStatusReplyEventArgs e);

        /// <summary>   Event queue for all listeners interested in loggingStatusReply events. </summary>
        public event LoggingStatusReplyHandler LoggingStatusReplyEvent;

        #endregion

        #region FlashProgressMessage Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Handler, called when the flash progress message. </summary>
        ///
        /// <remarks>   Kevin, 1/24/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Flash progress message event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void FlashProgressMessageHandler(object sender, FlashProgressMessageEventArgs e);


        /// <summary>   Event queue for all listeners interested in flashProgressMessage events. </summary>
        public event FlashProgressMessageHandler FlashProgressMessageEvent;
        #endregion

        #region PanelLoadDataReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Handler, called when the flash progress message. </summary>
        ///
        /// <remarks>   Kevin, 1/24/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Flash progress message event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelLoadDataReplyHandler(object sender, PanelLoadDataReplyEventArgs e);


        /// <summary>   Event queue for all listeners interested in flashProgressMessage events. </summary>
        public event PanelLoadDataReplyHandler PanelLoadDataReplyEvent;
        #endregion        

        #region AccessPortalStatusReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling AccessPortalStatusReply events. </summary>
        /// 
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Access portal status reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void AccessPortalStatusReplyHandler(object sender, AccessPortalStatusReplyEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in AccessPortalStatusReply events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event AccessPortalStatusReplyHandler AccessPortalStatusReplyEvent;
        #endregion

        #region AccessPortalCommandReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling AccessPortalCommandReply events. </summary>
        /// 
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Access portal status reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void AccessPortalCommandReplyHandler(object sender, AccessPortalCommandReplyEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in AccessPortalCommandReply events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event AccessPortalCommandReplyHandler AccessPortalCommandReplyEvent;
        #endregion


        #region InputDeviceStatusReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling InputDeviceStatusReply events. </summary>
        /// 
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        input device status reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void InputDeviceStatusReplyHandler(object sender, InputDeviceStatusReplyEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in InputDeviceStatusReply events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event InputDeviceStatusReplyHandler InputDeviceStatusReplyEvent;
        #endregion

        #region InputDeviceVoltagesReply Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling InputDeviceVoltagesReply events. </summary>
        /// 
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Input device voltages reply event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void InputDeviceVoltagesReplyHandler(object sender, InputDeviceVoltagesReplyEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in InputDeviceVoltagesReply events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event InputDeviceVoltagesReplyHandler InputDeviceVoltagesReplyEvent;
        #endregion

        #region Panel Credential Activity Log Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling PanelCredentialActivityLogMessage events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel credential activity log message event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelCredentialActivityLogMessageEventHandler(object sender, PanelCredentialActivityLogMessageEventArgs e);

        /// <summary>   Event queue for all listeners interested in CredentialActivityLog events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler CredentialActivityLogEvent;
        /// <summary>   Event queue for all listeners interested in NotInPanelMemoryCredentialActivity events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler NotInPanelMemoryCredentialActivityLogEvent;
        /// <summary>   Event queue for all listeners interested in CredentialAlarm events. </summary>
        public event PanelCredentialActivityLogMessageEventHandler CredentialAlarmEvent;
        #endregion

        #region Panel Activity Log Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling PanelActivityLogMessage events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Panel activity log message event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void PanelActivityLogMessageEventHandler(object sender, PanelActivityLogMessageEventArgs e);
        /// <summary>   Event queue for all listeners interested in ActivityLog events. </summary>
        public event PanelActivityLogMessageEventHandler ActivityLogEvent;
        /// <summary>   Event queue for all listeners interested in Alarm events. </summary>
        public event PanelActivityLogMessageEventHandler AlarmEvent;
        #endregion

        #region AcknowledgedAlarmBasicData Event
        public delegate void AcknowledgedAlarmBasicDataHandler(object sender, AcknowledgedAlarmBasicDataEventArgs e);

        /// <summary>   Event queue for all listeners interested in activityLog events. </summary>
        public event AcknowledgedAlarmBasicDataHandler AcknowledgedAlarmBasicDataEvent;
        #endregion

        #region Connection closed

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ConnectionClosed events. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Signal r connection closed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ConnectionClosedEventHandler(object sender, SignalRConnectionClosedEventArgs e);

        /// <summary>   Event queue for all listeners interested in ConnectionClosed events. </summary>
        public event ConnectionClosedEventHandler ConnectionClosedEvent;

        #endregion Connection closed

        #region Connection State Changed

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ConnectionClosed events. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Signal r connection closed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ConnectionStateChangedEventHandler(object sender, SignalRConnectionStateChangedEventArgs e);

        /// <summary>   Event queue for all listeners interested in connectionClosed events. </summary>
        public event ConnectionStateChangedEventHandler ConnectionStateChangedEvent;

        #endregion Connection State Changed

        #region Connection Error

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ConnectionError events. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Signal r connection error event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ConnectionErrorEventHandler(object sender, SignalRConnectionErrorEventArgs e);


        /// <summary>   Event queue for all listeners interested in connectionError events. </summary>
        public event ConnectionErrorEventHandler ConnectionErrorEvent;

        #endregion Connection Error

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
        ///// <param name="e">        Assa dsr notify updated event information. </param>
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

        #region Private Methods
        private async Task<bool> StartConnection(Guid sessionId)
        {
            try
            {
                await Connection.Start();
                if (sessionId != Guid.Empty)
                {
                    //GCS.Infrastructure.Logger.LoggerHelper.LogMessage(string.Format("SignalRClient.ConnectAsync joining groups"));
                    await JoinGroup(sessionId.ToString());

                    //foreach (var lc in _sessionId.AllowedLoopClusters)
                    //{
                    //    var id = lc.LoopClusterID;
                    //    //GCS.Infrastructure.Logger.LoggerHelper.LogMessage(string.Format("SignalRClient.ConnectAsync joining loopCluster {0} Group", id));
                    //    await JoinGroup(lc.LoopClusterID.ToString());
                    //}
                }
                else
                {

                }
                return true;
            }
            catch (AggregateException ex)
            {
                var flattenedEx = ex.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                {
                    this.Log().ErrorFormat($"SignalRClient.ConnectAsync exception: {innerEx.ToString()}");
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"SignalRClient.ConnectAsync Start exception: {ex.ToString()}");
                //               StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connection closed. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Connection_Closed()
        {
            try
            {
                //Trace.WriteLine(string.Format("{0}: SignalRClient {1} Connection_Closed ConnectionId:{2}", DateTimeOffset.Now, Name, Connection.ConnectionId));
                var handler = ConnectionClosedEvent;
                if (handler != null)
                    handler(this, new SignalRConnectionClosedEventArgs());

                //if (_bDontAutoReconnect == false)
                //    await StartConnection(_sessionId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient Connection_Closed exception: {ex.ToString()}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connection state changed. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Connection_StateChanged(Microsoft.AspNet.SignalR.Client.StateChange obj)
        {
            this.Log().Info($"SignalRClient Connection_StateChanged from {obj.OldState} to {obj.NewState}");

            try
            {
                LastStateChange = new StateChange(GCS.Core.Common.Extensions.EnumExtensions.GetOne<ConnectionState>(obj.OldState),
                    GCS.Core.Common.Extensions.EnumExtensions.GetOne<ConnectionState>(obj.NewState));

                var handler = ConnectionStateChangedEvent;
                if (handler != null)
                    handler(this, new SignalRConnectionStateChangedEventArgs(LastStateChange));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient Connection_StateChanged exception: {ex.ToString()}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connection error. </summary>
        ///
        /// <remarks>   Kevin, 9/6/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Connection_Error(Exception obj)
        {
            this.Log().Info($"SignalRClient Connection_Error: {obj.ToString()}");
            try
            {
                var handler = ConnectionErrorEvent;
                if (handler != null)
                    handler(this, new SignalRConnectionErrorEventArgs(obj));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }


        private void OnNotifyPanelBoardInformationCollection(PanelBoardInformationCollection data)
        {
            try
            {
                var handler = PanelBoardInformationCollectionEvent;
                if (handler != null)
                    handler(this, new PanelBoardInformationCollectionEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnNotifySerialChannelGalaxyDoorModuleDataCollection(SerialChannelGalaxyDoorModuleDataCollection data)
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnNotifySerialChannelGalaxyInputModuleDataCollection(SerialChannelGalaxyInputModuleDataCollection data)
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnNotifyCardCountReply(CredentialCountReply data)
        {
            try
            {
                var handler = CredentialCountReplyEvent;
                if (handler != null)
                    handler(this, new CredentialCountReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }
        private void OnAccessPortalStatusReply(AccessPortalStatusReply data)
        {
            try
            {
                var handler = AccessPortalStatusReplyEvent;
                if (handler != null)
                    handler(this, new AccessPortalStatusReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnAccessPortalCommandReply(AccessPortalCommandReply data)
        {
            try
            {
                var handler = AccessPortalCommandReplyEvent;
                if (handler != null)
                    handler(this, new AccessPortalCommandReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnInputDeviceStatusReply(InputDeviceStatusReply data)
        {
            try
            {
                var handler = InputDeviceStatusReplyEvent;
                if (handler != null)
                    handler(this, new InputDeviceStatusReplyEventArgs(data));
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }

        private void OnInputDeviceVoltagesReply(InputDeviceVoltagesReply data)
        {
            try
            {
                var handler = InputDeviceVoltagesReplyEvent;
                if (handler != null)
                    handler(this, new InputDeviceVoltagesReplyEventArgs(data));
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
                if (data.PanelActivityType == Common.Enums.PanelActivityEventCode.CredentialNotInPanelMemory ||
                   data.PanelActivityType == Common.Enums.PanelActivityEventCode.CredentialNotInPanelMemoryReverse)
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
                    var handlerAlarm = CredentialAlarmEvent;
                    if (handlerAlarm != null)
                        handlerAlarm(this, new PanelCredentialActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                    var handlerAlarm = AlarmEvent;
                    if (handlerAlarm != null)
                        handlerAlarm(this, new PanelActivityLogMessageEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
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
                this.Log().Error($"{Name}: SignalRClient {System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {ex.ToString()}");
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the activity log data action. </summary>
        /////
        ///// <remarks>   Kevin, 9/6/2018. </remarks>
        /////
        ///// <param name="eventData">    Information describing the event. </param>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void OnActivityLogData(ActivityLogData eventData)
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
        ///// <summary>   Executes the assa dsr notify updated action. </summary>
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
        #endregion Private Methods
    }

}
