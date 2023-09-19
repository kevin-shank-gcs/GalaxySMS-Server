////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MercuryManagerAsync.cs
//
// summary:	Implements the connection manager asynchronous class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.PanelCommunicationServerAsync.Entities;
using GCS.PanelCommunicationServerAsync.Interfaces;
using System.Threading.Tasks;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelDataHandlers;
using System.Collections.Concurrent;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Exceptions;
//using GalaxySMS.Business.Entities;
using GCS.Core.Common.Extensions;
using GalaxySMS.Business.Entities;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GCS.Framework.Flash;
using GalaxyCpuConnection = GalaxySMS.Client.Entities.GalaxyCpuConnection;
using GCS.Merc.Core;
using System.ComponentModel.DataAnnotations;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A connection manager asynchronous. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercuryManagerAsync
    {
        #region Private fields

        /// <summary>   the socket used to listen for incoming connection requests. </summary>
        private string _serverAddress = string.Empty;
        private MercCommunicationServer _mercServer;
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

        ///// <summary>   The CPU connections. </summary>
        //private ObservableCollection<CpuConnectionInfo> _cpuConnections = new ObservableCollection<CpuConnectionInfo>();
        ///// <summary>   The connections. </summary>
        //private System.Collections.Concurrent.ConcurrentDictionary<SocketAsyncEventArgs, IPanelConnection> _connections;
        private System.Collections.Concurrent.ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>> _credentialLoadDataByCpuUid;

        ///// <summary>   The site server connection settings. </summary>
        private GalaxySiteServerConnectionSettings _siteServerConnectionSettings;

        private int _ackLogMessageIndexMinimumInterval;

        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the listen port. </summary>
        ///
        /// <value> The listen port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Range(1, 65535)]
        public Int32 ListenPort { get; private set; }
        public bool DebuggingEnabled { get; set; }
        public string DebugFilename { get; set; }
        public bool MercInitialized { get; private set; }
        public bool MercConfigured { get; private set; }
        public bool ListenChannelCreated { get; private set; }
        [Range(1, 1024)]
        public short MaxChannels { get; private set; } = 1024;
        [Range(1, 1024)]
        public short MaxScps { get; private set; } = 1024;
        public bool IsRunning { get; private set; }
        public ObservableCollection<ScpIdReportEventArgs> ScpIdData
        {
            get; internal set;
        }


        #endregion

        #region Public Events

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

        public MercuryManagerAsync()
        {
            ListenPort = 3101;

            _credentialLoadDataByCpuUid = new ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>>();

            if (Globals.Instance.ServerConnection == null)
            {
                _siteServerConnectionSettings = new GalaxySiteServerConnectionSettings();
                Globals.Instance.ServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);
            }
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
 
        public MercuryManagerAsync(Int32 listenPort, short maxScps, short maxChannels, string serverAddress, int ackLogMessageIndexMinimumInterval)
        {
            ListenPort = listenPort;
            _serverAddress = serverAddress;

            if (maxScps > 0 && maxScps <= 1024)
                MaxScps = maxScps;

            if (maxChannels > 0 && maxChannels <= 1024)
                MaxChannels = maxChannels;

            this._ackLogMessageIndexMinimumInterval = ackLogMessageIndexMinimumInterval;

            _credentialLoadDataByCpuUid = new ConcurrentDictionary<Guid, IGrouping<Guid, IEnumerable<Credential_PanelLoadData>>>();

            _processingQueue = new System.Collections.Concurrent.BlockingCollection<object>();
            _recordingQueue = new System.Collections.Concurrent.BlockingCollection<object>();

            if (Globals.Instance.ServerConnection == null)
            {
                _siteServerConnectionSettings = new GalaxySiteServerConnectionSettings();
                Globals.Instance.ServerConnection = new GalaxySiteServerConnection(_siteServerConnectionSettings);
            }
            Init();
        }
        #endregion

        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Starts the server such that it is listening for incoming connection requests.
        /// </summary>
        ///
        /// <remarks>   Kevin, 7/27/2021. </remarks>
        ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start()
        {
            try
            {
                this.Log().Info($"Starting Mercury communication manager. Listening on port:{this.ListenPort}");

                StartPanelOutputDataProcessors();

                //try
                //{
                //    Task.Run(async () =>
                //    {
                //        await UpdateCpuConnectionStatus(new GalaxyCpuConnection()
                //        {
                //            CpuUid = Guid.Empty,
                //            IsConnected = false,
                //            ServerAddress = this._serverAddress
                //        });
                //    }).Wait();
                //}
                //catch (Exception ex)
                //{
                //    this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                //}

            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                Stop();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Stops this MercuryManagerAsync. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Stop()
        {
            try
            {
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
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }


        //private async Task UpdateCpuConnectionStatus(GalaxyCpuConnection cpuConnection)
        //{
        //    try
        //    {
        //        var mgr = Globals.Instance.GetManager<PanelDataProcessingManager>();

        //        var bRet = await mgr.UpdateGalaxyCpuConnectionAsync(cpuConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
        //    }
        //}

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
            //IPanelConnection conn = FindConnectionByInstanceGuid(instanceGuid);
            //if (conn != null)
            //{
            //    if (conn.DebuggingMode == false)
            //    {

            //    }
            //    conn.DebuggingMode = bEnable;
            //    //System.Diagnostics.Trace.WriteLine(string.Format("{0} DebuggingMode:{1}", conn.ConnectionDescription, conn.DebuggingMode));
            //}
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
            //IPanelConnection[] conns = FindConnections(data.Address);//.CpuAddress);

            //if (conns != null)
            //{
            //    foreach (IPanelConnection c in conns)
            //    {
            //        c.SendRawData(data, null);
            //    }
            //}
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
            //if (data == null)
            //    throw new ArgumentNullException("data", string.Format("The parameter SendResetCommand data cannot be null"));

            //IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(data.SendToAddress.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId, data.SendToAddress.ClusterGroupId));
            //if (conns == null || conns.Length == 0)
            //{
            //    var ex = new NotFoundException(
            //        string.Format("There are no connections for Account: '{0};, ClusterNumber '{1}', PanelNumber: '{2}', Cpu: '{3}'.",
            //        data.SendToAddress.ClusterGroupId, data.SendToAddress.ClusterNumber, data.SendToAddress.PanelNumber, data.SendToAddress.CpuId));
            //    var detail = new ExceptionDetailEx(ex);
            //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            //}

            //foreach (var c in conns)
            //{
            //    c.SendResetCommand(data);
            //}
        }

        public void SetPersonDataToSend(IEnumerable<Credential_PanelLoadData> personDataToSend, IList<PersonalAccessGroup_PanelLoadData> personalAccessGroupDataToSend)
        {
            //var iG = personDataToSend.GroupBy(o => o.CpuUid);
            //foreach (var g in iG)
            //{
            //    var conn = _connections.Values.FirstOrDefault(o => o.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid == g.Key);
            //    if (conn != null)
            //    {
            //        conn.SendCredentialData(g);
            //    }

            //}
        }

        public void SendDeleteCredentialData(IEnumerable<CredentialToDeleteFromCpu> data)
        {
            //if (data == null)
            //    throw new ArgumentNullException("data", string.Format("The parameter SendDeleteCredentialData data cannot be null"));

            //if (!data.Any())
            //    return;


            //var deleteCredentialsByCpuUid = data.GroupBy(x => new { x.ClusterNumber, x.PanelNumber, x.CpuNumber, x.ClusterGroupId }).Select(y => new { ClusterNumber = y.Key.ClusterNumber, PanelNumber = y.Key.PanelNumber, CpuNumber = y.Key.CpuNumber, ClusterGroupId = y.Key.ClusterGroupId }).ToList();


            //foreach (var cpu in deleteCredentialsByCpuUid)
            //{
            //    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cpu.ClusterNumber, cpu.PanelNumber, (short)cpu.CpuNumber, cpu.ClusterGroupId));
            //    if (conns == null || conns.Length == 0)
            //    {
            //        //var ex = new NotFoundException(
            //        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
            //        //var detail = new ExceptionDetailEx(ex);
            //        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            //    }
            //    else
            //    {
            //        foreach (var c in conns)
            //        {
            //            foreach (var credToDelete in data.Where(x => x.CpuUid == c.CpuConnectionInfo.CpuDatabaseInformation?.CpuUid).ToList())
            //                c.SendDeleteCredential(credToDelete.CardBinaryData);
            //        }
            //    }
            //}

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a credential data. </summary>
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

        public void SendCredentialData(IEnumerable<Credential_PanelLoadData> data, IEnumerable<PersonalAccessGroup_PanelLoadData> personalAccessGroupData, CpuHardwareAddress sendToAddress)
        {
            //if (data == null)
            //    throw new ArgumentNullException("data", string.Format("The parameter SendCredentialData data cannot be null"));

            //if (!data.Any())
            //    return;

            //// Validate the data first
            //foreach (var i in data)
            //{
            //    i.Validate();
            //    if (!i.IsValid)
            //    {
            //        throw new DataValidationException(i.ValidationErrors);
            //    }
            //}

            //// validate the personal access group rows
            //foreach (var i in personalAccessGroupData)
            //{
            //    i.Validate();
            //    if (!i.IsValid)
            //    {
            //        throw new DataValidationException(i.ValidationErrors);
            //    }
            //}

            //var distinctClusters = data.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
            //    .Select(y => new
            //    {
            //        ClusterGroupId = y.Key.ClusterGroupId,
            //        ClusterNumber = y.Key.ClusterNumber,
            //    }
            //).ToList();


            //var distinctPersonalAccessGroupClusters = personalAccessGroupData.GroupBy(x => new { x.ClusterGroupId, x.ClusterNumber })
            //    .Select(y => new
            //    {
            //        ClusterGroupId = y.Key.ClusterGroupId,
            //        ClusterNumber = y.Key.ClusterNumber,
            //    }
            //).ToList();

            //foreach (var cluster in distinctClusters)
            //{
            //    //IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, (Int32)CpuHardwareAddress.SystemPanelAddress.AllPanels, (Int32)CpuHardwareAddress.CpuNumber.Both, cluster.ClusterGroupId));
            //    if (sendToAddress.PanelNumber == 0)
            //        sendToAddress.PanelNumber = (int)CpuHardwareAddress.SystemPanelAddress.AllPanels;
            //    if (sendToAddress.CpuId == 0)
            //        sendToAddress.CpuId = (short)CpuHardwareAddress.CpuNumber.Both;

            //    IPanelConnection[] conns = FindConnections(new CpuHardwareAddress(cluster.ClusterNumber, sendToAddress.PanelNumber, sendToAddress.CpuId, cluster.ClusterGroupId));
            //    if (conns == null || conns.Length == 0)
            //    {
            //        //var ex = new NotFoundException(
            //        //    string.Format("There are no connections for ClusterGroupId: '{0}', Cluster #: '{1}'.", cluster.ClusterGroupId, cluster.ClusterNumber));
            //        //var detail = new ExceptionDetailEx(ex);
            //        //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            //    }
            //    else
            //    {
            //        // Pick out the credential data for this cluster
            //        var clusterCredentialData = data.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();

            //        // Pick out the personal access group data for this cluster
            //        var pagData = personalAccessGroupData.Where(i => i.ClusterGroupId == cluster.ClusterGroupId && i.ClusterNumber == cluster.ClusterNumber).ToList();

            //        foreach (var c in conns)
            //        {
            //            c.SendCredentialData(clusterCredentialData);
            //            if (pagData != null)
            //            {
            //                // select only those records for this panel
            //                var panelPagData = pagData.Where(i => i.PanelNumber == c.PanelId).ToList();
            //                if (panelPagData.Any())
            //                    c.SendPersonalAccessGroupData(panelPagData);
            //            }
            //        }
            //    }
            //}


        }

        #endregion

        #region Private Methods

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
                //foreach (IPanelConnection conn in _connections.Values)
                //{
                //    conn.PrepareToClose();
                //}
            }
            catch (Exception ex)
            {
                //				GCS.Framework.Logging.LogWriter.LogException(ex, string.Format("MercuryManagerAsync::CloseAllConnections"));
                this.Log().Info(string.Format("MercuryManagerAsync::CloseAllConnections"), ex);
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



        private void _mercServer_ScpIdReport(object sender, ScpIdReportEventArgs e)
        {   // Stick this in a queue that is processed by some other thread or process. This event should be handled quickly so that the server is not blocked or held up by potentially long-running code, such as looking something up in the database
            if (this.ScpIdData == null)
                ScpIdData = new ObservableCollection<ScpIdReportEventArgs>();

            if (ScpIdData.Any())
            {
                var existingScpIdReport = ScpIdData.FirstOrDefault(o => o.Data.sMacAddress == e.Data.sMacAddress);
                if (existingScpIdReport != null)
                    ScpIdData.Remove(existingScpIdReport);
            }
            ScpIdData.Add(e);

            //if (/*e.Data.ScpId == 1 &&*/ (e.Data.ConfigurationFlags & ConfigFlags.NeedsConfiguration) != 0)
            //{   // If the default ScpId # is used AND the NeedsConfiguration flag is on, then renumber the Spc to an available #.
            //    // To find an available #, look up the Spc in the DB based on MAC address. If it does exist, 
            //}
            //else if ((e.Data.ConfigurationFlags & ConfigFlags.NeedsConfiguration) != 0)
            //{

            //}
        }

        private void _mercServer_CommStatusChanged(object sender, CommStatusEventArgs e)
        {
            if (ScpIdData != null && ScpIdData.Any() && e.Status == CommStatusEventArgs.CommStatus.CommFailed)
            {
                var existingScpIdReport = ScpIdData.FirstOrDefault(o => o.DriverScpId == e.DriverScpId);
                if (existingScpIdReport != null)
                    ScpIdData.Remove(existingScpIdReport);
            }
            else if (e.Status == CommStatusEventArgs.CommStatus.CommOk)
            {

            }
        }
        #endregion


    }
}
