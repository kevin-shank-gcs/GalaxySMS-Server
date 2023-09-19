////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	WcfManagers\GalaxyPanelCommunicationManager.cs
//
// summary:	Implements the galaxy panel communication manager class
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Proxies;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
//using GalaxySMS.Client.Proxies;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for galaxy panel communications. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPanelCommunicationManager : ManagerBase, IGalaxyPanelCommunicationEventServiceCallback
    {

        #region EventArg Classes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for communication server running status events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class CommunicationServerRunningStatusEventArgs : EventArgsBase
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="status">               True to status. </param>
            /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
            /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public CommunicationServerRunningStatusEventArgs(bool status, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
                : base(requestInvokedAt, requestCompletedAt)
            {
                CommunicationServerRunningStatus = status;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Gets or sets a value indicating whether the communication server running status.
            /// </summary>
            ///
            /// <value> True if communication server running status, false if not. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public bool CommunicationServerRunningStatus { get; internal set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for galaxy CPU connections events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxyCpuConnectionsEventArgs : EventArgsBase
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="cpuConnections">       The CPU connections. </param>
            /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
            /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public GalaxyCpuConnectionsEventArgs(List<CpuConnectionInfo> cpuConnections, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
                : base(requestInvokedAt, requestCompletedAt)
            {
                GalaxyCpuConnections = new ReadOnlyCollection<CpuConnectionInfo>(cpuConnections);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the galaxy CPU connections. </summary>
            ///
            /// <value> The galaxy CPU connections. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public ReadOnlyCollection<CpuConnectionInfo> GalaxyCpuConnections { get; internal set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for galaxy CPU connection information events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxyCpuConnectionInfoEventArgs : EventArgsBase
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="cpuConnectionInfo">    Information describing the CPU connection. </param>
            /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
            /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public GalaxyCpuConnectionInfoEventArgs(CpuConnectionInfo cpuConnectionInfo, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
                : base(requestInvokedAt, requestCompletedAt)
            {
                GalaxyCpuConnectionInfo = cpuConnectionInfo;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets information describing the galaxy CPU connection. </summary>
            ///
            /// <value> Information describing the galaxy CPU connection. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public CpuConnectionInfo GalaxyCpuConnectionInfo { get; internal set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for galaxy CPU information events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxyCpuInformationEventArgs : EventArgsBase
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="galaxyCpuInformation"> Information describing the galaxy CPU. </param>
            /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
            /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public GalaxyCpuInformationEventArgs(GalaxyCpuInformation galaxyCpuInformation, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
                : base(requestInvokedAt, requestCompletedAt)
            {
                GalaxyCpuInformation = galaxyCpuInformation;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets information describing the galaxy CPU. </summary>
            ///
            /// <value> Information describing the galaxy CPU. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public GalaxyCpuInformation GalaxyCpuInformation { get; internal set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Additional information for galaxy CPU data packet events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxyCpuDataPacketEventArgs : EventArgsBase
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="dataPacket">           The data packet. </param>
            /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
            /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public GalaxyCpuDataPacketEventArgs(CpuDataPacket dataPacket, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
                : base(requestInvokedAt, requestCompletedAt)
            {
                DataPacket = dataPacket;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the data packet. </summary>
            ///
            /// <value> The data packet. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public CpuDataPacket DataPacket { get; internal set; }
        }
        #endregion
        #region Private fields
        /// <summary>   The galaxy panel communication event service. </summary>
        private IGalaxyPanelCommunicationEventService _GalaxyPanelCommunicationEventService;
        /// <summary>   The galaxy panel communication manager event subscriber. </summary>
        private GalaxyPanelCommunicationManagerEventSubscriber _GalaxyPanelCommunicationManagerEventSubscriber;
        /// <summary>   The connections. </summary>
        private List<CpuConnectionInfo> _Connections;
        /// <summary>   True to communication server running status. </summary>
        private bool _communicationServerRunningStatus;
        //private bool _communicationServerRunningStatus;
        //private Timer _timerRefreshConnections;
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the connections. </summary>
        ///
        /// <value> The connections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CpuConnectionInfo> Connections
        {
            get; set;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the communication server running status.
        /// </summary>
        ///
        /// <value> True if communication server running status, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CommunicationServerRunningStatus
        {
            get { return _communicationServerRunningStatus; }
            set { _communicationServerRunningStatus = value; }
        }

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommunicationManager() : base()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommunicationManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Connections = new List<CpuConnectionInfo>();
        }
        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GalaxyCpuConnectionInfo events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Galaxy CPU connection information event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GalaxyCpuConnectionInfoEventHandler(object sender, GalaxyCpuConnectionInfoEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in galaxyCpuConnectionInfo events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GalaxyCpuConnectionInfoEventHandler GalaxyCpuConnectionInfoEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GalaxyCpuInformation events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Galaxy CPU information event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GalaxyCpuInformationEventHandler(object sender, GalaxyCpuInformationEventArgs e);
        /// <summary>   Event queue for all listeners interested in galaxyCpuInformation events. </summary>
        public event GalaxyCpuInformationEventHandler GalaxyCpuInformationEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GalaxyCpuDataPacket events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Galaxy CPU data packet event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GalaxyCpuDataPacketEventHandler(object sender, GalaxyCpuDataPacketEventArgs e);
        /// <summary>   Event queue for all listeners interested in galaxyCpuDataPacket events. </summary>
        public event GalaxyCpuDataPacketEventHandler GalaxyCpuDataPacketEvent;

        #endregion

        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyPanelCommunicationManager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            RegisterWithGalaxyPanelCommunicationEventService(false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a data packet to server. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SendDataPacketToServer(RawDataToSend data)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                Binding,
                GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                ClientUserSessionData), proxy =>
                {
                    try
                    {
                        proxy.SendDataPacket(data);
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a data packet to server asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task SendDataPacketToServerAsync(RawDataToSend data)
        {
            InitializeErrorsCollection();

            WithClientAsync<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                Binding,
                GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                {
                    if (proxy != null)
                    {
                        Func<Task> task = async () =>
                        {
                            Task t = proxy.SendDataPacketAsync(data);
                            await t;
                        };
                        try
                        {
                            task().Wait();
                        }
                        catch (AggregateException ae)
                        {
                            ae = ae.Flatten();
                            foreach (Exception ex in ae.InnerExceptions)
                            {
                                AddError(new CustomError(ex.Message));
                                this.Log().Debug(ex.Message);
                            }
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                        }
                    }
                });


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets is communication server running status. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool GetIsCommunicationServerRunningStatus()
        {
            InitializeErrorsCollection();
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                Binding,
                GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                ClientUserSessionData), proxy =>
                {
                    try
                    {
                        CommunicationServerRunningStatus = proxy.GetRunningStatus();
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return CommunicationServerRunningStatus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets is communication server running status asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> GetIsCommunicationServerRunningStatusAsync()
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(Binding,
                        GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.GetRunningStatusAsync();

                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Stops communication server. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopCommunicationServer(object obj)
        {
            InitializeErrorsCollection();
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                Binding,
                GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                ClientUserSessionData), proxy =>
                {
                    try
                    {
                        proxy.Stop();
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Stops communication server asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopCommunicationServerAsync(object obj)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                Binding,
                GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                ClientUserSessionData), async proxy =>
                {
                    if (proxy != null)
                    {
                        Func<Task> task = async () =>
                        {
                            Task t = proxy.StopAsync();
                            await t;
                        };
                        try
                        {
                            task().Wait();
                        }
                        catch (AggregateException ae)
                        {
                            foreach (Exception ex in ae.InnerExceptions)
                            {
                                AddError(new CustomError(ex.Message));
                                this.Log().Debug(ex.Message);
                            }
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                        }
                    }
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts communication server. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartCommunicationServer(object obj)
        {
            InitializeErrorsCollection();
            WithClient<IGalaxyPanelCommunicationManagerService>(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.Start();
                            GetIsCommunicationServerRunningStatus();
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts communication server asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartCommunicationServerAsync(object obj)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClientAsync<IGalaxyPanelCommunicationManagerService>(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task t = proxy.StartAsync();
                                await t;
                                GetIsCommunicationServerRunningStatus();
                            };
                            try
                            {
                                task().Wait();
                            }
                            catch (AggregateException ae)
                            {
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Refresh galaxy CPU connections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   A list of. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CpuConnectionInfo> RefreshGalaxyCpuConnections(GetCpuConnectionsParameters parameters)
        {
            InitializeErrorsCollection();

            WithClient<IGalaxyPanelCommunicationManagerService>(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = new List<CpuConnectionInfo>(proxy.GetConnections(parameters));
                            Connections = new ReadOnlyCollection<CpuConnectionInfo>(data);

                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return Connections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Refresh galaxy CPU connections asynchronous. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<CpuConnectionInfo>> RefreshGalaxyCpuConnectionsAsync(GetCpuConnectionsParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                {
                    var data = await proxy.GetConnectionsAsync(parameters);
                    Connections = new ReadOnlyCollection<CpuConnectionInfo>(data);
                    return Connections;
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpu">  The CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugConnection(CpuConnectionInfo cpu)
        {
            try
            {
                if (_GalaxyPanelCommunicationEventService == null)
                    RegisterWithGalaxyPanelCommunicationEventService(false);

                if (cpu != null && _GalaxyPanelCommunicationEventService != null)
                {
                    ConnectionDebuggingModeForSubscriber data =
                            new ConnectionDebuggingModeForSubscriber(_GalaxyPanelCommunicationManagerEventSubscriber);
                    data.ConnectionGuid = cpu.EntityGuid;
                    data.EnableDebugging = true;
                    _GalaxyPanelCommunicationEventService.SetConnectionDebuggingModeForClient(data);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
            {
                _GalaxyPanelCommunicationEventService = null;
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Stops debugging connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="connectionInstanceGuid">   Unique identifier for the connection instance. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopDebuggingConnection(Guid connectionInstanceGuid)
        {
            try
            {
                if (_GalaxyPanelCommunicationEventService == null)
                    RegisterWithGalaxyPanelCommunicationEventService(false);

                if (_GalaxyPanelCommunicationEventService != null)
                {
                    ConnectionDebuggingModeForSubscriber data =
                        new ConnectionDebuggingModeForSubscriber(_GalaxyPanelCommunicationManagerEventSubscriber);
                    data.ConnectionGuid = connectionInstanceGuid;
                    data.EnableDebugging = false;
                    _GalaxyPanelCommunicationEventService.SetConnectionDebuggingModeForClient(data);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
            {
                _GalaxyPanelCommunicationEventService = null;
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an aba settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   A SendDataResponse&lt;AbaSettings&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse<AbaSettings> SendAbaSettings(SendDataParameters<AbaSettings> data)
        {
            InitializeErrorsCollection();

            SendDataResponse<AbaSettings> result = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), proxy =>
                {
                    try
                    {
                        result = proxy.SendAbaSettings(data);
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an aba settings asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   A Task&lt;SendDataResponse&lt;AbaSettings&gt;&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<SendDataResponse<AbaSettings>> SendAbaSettingsAsync(SendDataParameters<AbaSettings> data)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(Binding,
                        GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                    {
                        return await proxy.SendAbaSettingsAsync(data);
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset command to panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   A SendDataResponse&lt;GalaxyPanelResetCommand&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse<GalaxyPanelResetCommand> SendResetCommandToPanel(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            InitializeErrorsCollection();

            SendDataResponse<GalaxyPanelResetCommand> result = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.SendResetCommandToPanel(data);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a reset command to panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   A Task&lt;SendDataResponse&lt;GalaxyPanelResetCommand&gt;&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<SendDataResponse<GalaxyPanelResetCommand>> SendResetCommandToPanelAsync(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(Binding,
                        GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                        {
                            return await proxy.SendResetCommandToPanelAsync(data);
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an interface board section data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   A SendDataResponse&lt;GalaxyInterfaceBoardSection_PanelLoadData&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            InitializeErrorsCollection();

            SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> result = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<IGalaxyPanelCommunicationManagerService>(
                _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
                    Binding,
                    GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.SendInterfaceBoardSectionData(data);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends an interface board section data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>
        /// A Task&lt;SendDataResponse&lt;GalaxyInterfaceBoardSection_PanelLoadData&gt;&gt;
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData>> SendInterfaceBoardSectionDataAsync(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(Binding,
                        GetServiceAddress(ServiceNames.GalaxyPanelCommunicationManagerService), ClientUserSessionData), async proxy =>
                        {
                            return await proxy.SendInterfaceBoardSectionDataAsync(data);
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the galaxy CPU command operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExecuteGalaxyCpuCommand(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            InitializeErrorsCollection();

            bool result = false;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(
                    Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.ExecuteGalaxyCpuCommand(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the galaxy CPU command asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> ExecuteGalaxyCpuCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteGalaxyCpuCommandAsync(parameters);

                            return data;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the galaxy interface board section command operation. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///=================================================================================================

        public bool ExecuteGalaxyInterfaceBoardSectionCommand(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters)
        {
            InitializeErrorsCollection();

            bool result = false;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(
                    Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.ExecuteGalaxyInterfaceBoardSectionCommand(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Executes the galaxy interface board section command asynchronous operation.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ///=================================================================================================

        public async Task<bool> ExecuteGalaxyInterfaceBoardSectionCommandAsync(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteGalaxyInterfaceBoardSectionCommandAsync(parameters);

                            return data;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return false;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the galaxy load flash command operation. </summary>
        ///
        /// <remarks>   Kevin, 1/21/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExecuteGalaxyLoadFlashCommand(CommandParameters<GalaxyLoadFlashCommandAction> parameters)
        {
            InitializeErrorsCollection();

            bool result = false;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(
                    Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.ExecuteGalaxyLoadFlashCommand(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the galaxy load flash command asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 1/21/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> ExecuteGalaxyLoadFlashCommandAsync(CommandParameters<GalaxyLoadFlashCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteGalaxyLoadFlashCommandAsync(parameters);

                            return data;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cluster data to panels. </summary>
        ///
        /// <remarks>   Kevin, 2/14/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoadDataCommandResponse<ClusterDataLoadParameters> SendClusterDataToPanels(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            InitializeErrorsCollection();
            LoadDataCommandResponse<ClusterDataLoadParameters> ret = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        ret = proxy.SendClusterDataToPanels(parameters);
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sends a cluster data to panels asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 2/14/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsAsync(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            LoadDataCommandResponse<ClusterDataLoadParameters> ret = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        ret = await proxy.SendClusterDataToPanelsAsync(parameters);
                        return ret;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return ret;
        }


        public BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsJob(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            InitializeErrorsCollection();
            BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>> ret = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        ret = proxy.SendClusterDataToPanelsJob(parameters);
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (FaultException<ExceptionDetailEx> ex)
                    {
                        AddError(new CustomError(ex.Detail));
                    }
                    catch (Exception ex)
                    {
                        AddError(new CustomError(ex.Message));
                    }
                });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return ret;
        }


        public async Task<BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>>> SendClusterDataToPanelsJobAsync(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>> ret = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        ret = await proxy.SendClusterDataToPanelsJobAsync(parameters);
                        return ret;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return ret;
        }

        #endregion

        #region Private Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Registers the with galaxy panel communication event service described by bUnRegister.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bUnRegister">  True to un register. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RegisterWithGalaxyPanelCommunicationEventService(bool bUnRegister)
        {
            try
            {
                if (bUnRegister == false)
                {
                    if (_GalaxyPanelCommunicationEventService == null)
                        _GalaxyPanelCommunicationEventService = new GalaxyPanelCommunicationEventClient(this);
                    _GalaxyPanelCommunicationManagerEventSubscriber =
                        new GalaxyPanelCommunicationManagerEventSubscriber();
                    var myAssembly = GCS.Framework.Utilities.SystemUtilities.ExecutingAssembly;
                    _GalaxyPanelCommunicationManagerEventSubscriber.ClientName = string.Format("{0} - ({1})",
                        GCS.Framework.Utilities.SystemUtilities.GetAssemblyAttributes(ref myAssembly).Title,
                        GCS.Framework.Utilities.SystemUtilities.MyMachineName());
                    _GalaxyPanelCommunicationManagerEventSubscriber.EntityGuid = new Guid();

                    _GalaxyPanelCommunicationEventService.RegisterClient(_GalaxyPanelCommunicationManagerEventSubscriber);
                }
                else
                {
                    if (_GalaxyPanelCommunicationEventService != null)
                    {
                        _GalaxyPanelCommunicationEventService.UnregisterClient(
                            _GalaxyPanelCommunicationManagerEventSubscriber);
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
            {
                _GalaxyPanelCommunicationEventService = null;
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
        }
        #endregion

        #region IGalaxyPanelCommunicationEventServiceCallback interface implementation

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Broadcasts a CPU connection information to client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpuInfo">  Information describing the CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BroadcastCpuConnectionInfoToClient(CpuConnectionInfo cpuInfo)
        {
            InitializeErrorsCollection();
            try
            {
                if (_Connections == null)
                    _Connections = new List<CpuConnectionInfo>();
                if (cpuInfo.IsConnected)
                    _Connections.Add(cpuInfo);
                else
                {
                    foreach (CpuConnectionInfo cpu in _Connections)
                    {
                        if (cpu.EntityGuid == cpuInfo.EntityGuid)
                        {
                            bool bDeleted = _Connections.Remove(cpu);
                            break;
                        }
                    }
                }

                var handler = GalaxyCpuConnectionInfoEvent;
                if (handler != null)
                    handler(this, new GalaxyCpuConnectionInfoEventArgs(cpuInfo, DateTimeOffset.Now, DateTimeOffset.Now));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Broadcasts a panel information to client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxyCpuInfo">    Information describing the galaxy CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BroadcastPanelInformationToClient(GalaxyCpuInformation galaxyCpuInfo)
        {
            InitializeErrorsCollection();
            try
            {

                if (_Connections != null)
                {
                    foreach (CpuConnectionInfo cpu in _Connections)
                    {
                        if (cpu.EntityGuid.ToString() == galaxyCpuInfo.InstanceGuid)
                        {
                            cpu.GalaxyCpuInformation = galaxyCpuInfo;
                            break;
                        }
                    }
                }
                var handler = GalaxyCpuInformationEvent;
                if (handler != null)
                    handler(this, new GalaxyCpuInformationEventArgs(galaxyCpuInfo, DateTimeOffset.Now, DateTimeOffset.Now));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Broadcasts a panel debug packet to client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dataPacket">   Message describing the data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BroadcastPanelDebugPacketToClient(CpuDataPacket dataPacket)
        {
            InitializeErrorsCollection();
            try
            {
                var handler = GalaxyCpuDataPacketEvent;
                if (handler != null)
                    handler(this, new GalaxyCpuDataPacketEventArgs(dataPacket, DateTimeOffset.Now, DateTimeOffset.Now));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
