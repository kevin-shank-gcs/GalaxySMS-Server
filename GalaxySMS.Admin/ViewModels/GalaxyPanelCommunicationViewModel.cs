using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Views;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using PDSA.MessageBroker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    //public class GalaxyPanelCommunicationViewModel : ViewModelBase, IGalaxyPanelCommunicationEventServiceCallback
    public class GalaxyPanelCommunicationViewModel : ViewModelBase
    {
        private IServiceFactory _ServiceFactory;

        //private IGalaxyPanelCommunicationEventService _GalaxyPanelCommunicationEventService;
        //private GalaxyPanelCommunicationManagerEventSubscriber _GalaxyPanelCommunicationManagerEventSubscriber;
        private Dictionary<Guid, GalaxyConnectionDebugWindow> _debugWindows = new Dictionary<Guid, GalaxyConnectionDebugWindow>();
        private PDSAMessageBroker _MessageBroker = null;
        private GalaxyPanelCommunicationManager _galaxyPanelCommunicationManager;

        [ImportingConstructor]
        public GalaxyPanelCommunicationViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;
            StartCommunicationServerCommand = new DelegateCommand<object>(OnStartCommunicationServerCommand,
                OnStartCommunicationServerCommandCanExecute);
            StopCommunicationServerCommand = new DelegateCommand<object>(OnStopCommunicationServerCommand,
               OnStopCommunicationServerCommandCanExecute);
            RefreshConnectionsCommand = new DelegateCommand<object>(OnRefreshConnectionsCommand,
                OnRefreshConnectionsCommandCanExecute);
            DebugConnectionCommand = new DelegateCommand<CpuConnection>(OnDebugConnectionCommand,
                OnDebugConnectionCommandCanExecute);
            AddNewCpuCommand = new DelegateCommand<CpuConnection>(OnAddNewCpuCommand,
                OnAddNewCpuCommandCanExecute);
            BeginFlashLoadCommand = new DelegateCommand<CpuConnection>(OnBeginFlashLoadCommand,
                OnBeginFlashLoadCommandCanExecute);
            PauseFlashLoadCommand = new DelegateCommand<CpuConnection>(OnPauseFlashLoadCommand,
                OnPauseFlashLoadCommandCanExecute);
            ResumeFlashLoadCommand = new DelegateCommand<CpuConnection>(OnResumeFlashLoadCommand,
                OnResumeFlashLoadCommandCanExecute);
            CancelFlashLoadCommand = new DelegateCommand<CpuConnection>(OnCancelFlashLoadCommand,
                OnCancelFlashLoadCommandCanExecute);
            ValidateFlashCommand = new DelegateCommand<CpuConnection>(OnValidateFlashCommand,
                OnValidateFlashCommandCanExecute);
            ValidateAndBurnFlashCommand = new DelegateCommand<CpuConnection>(OnValidateAndBurnFlashCommand,
                OnValidateAndBurnFlashCommandCanExecute);


            LoadClusterDataCommand = new DelegateCommand<CpuConnection>(OnLoadClusterDataCommand,
                OnLoadClusterDataCommandCanExecute);

            ClearPanelLoadDataRepliesCommand = new DelegateCommand<CpuConnection>(OnClearPanelLoadDataRepliesCommand,
                OnClearPanelLoadDataRepliesCommandCanExecute);

            EnableFlashBoardsCommand = new DelegateCommand<CpuConnection>(OnEnableFlashBoardsCommand,
              OnEnableFlashBoardsCommandCanExecute);

            RequestBoardsCommand = new DelegateCommand<CpuConnection>(OnRequestBoardsCommand,
                OnRequestBoardsCommandCanExecute);


            //LoadSchedulesDataCommand = new DelegateCommand<CpuConnection>(OnLoadSchedulesDataCommand,
            //OnLoadSchedulesDataCommandCanExecute);

            //LoadAccessPortalDataCommand = new DelegateCommand<CpuConnection>(OnLoadAccessPortalDataCommand,
            //OnLoadAccessPortalDataCommandCanExecute);

            //LoadCredentialDataCommand = new DelegateCommand<CpuConnection>(OnLoadCredentialDataCommand,
            //OnLoadCredentialDataCommandCanExecute);

            //LoadInputOutputGroupDataCommand = new DelegateCommand<CpuConnection>(OnLoadInputOutputGroupDataCommand,
            //OnLoadInputOutputGroupDataCommandCanExecute);


            _MessageBroker = Globals.Instance.MessageBrokerPanelCommunication;
            _MessageBroker.MessageReceived += new MessageReceivedEventHandler(MessageBroker_MessageReceived);


            Globals.Instance.MessageBroker.MessageReceived += MessageBroker_GlobalMessageReceived;

            _galaxyPanelCommunicationManager = new GalaxyPanelCommunicationManager(Globals.Instance.ServerConnections[0]);
            _galaxyPanelCommunicationManager.ErrorsOccurredEvent += GalaxyPanelCommunicationManager_OnErrorsOccurredEvent;
            _galaxyPanelCommunicationManager.GetIsCommunicationServerRunningStatusAsyncCompletedEvent += GalaxyPanelCommunicationManager_OnGetIsCommunicationServerRunningStatusAsyncCompletedEvent;
            _galaxyPanelCommunicationManager.RefreshGalaxyCpuConnectionsAsyncCompletedEvent += GalaxyPanelCommunicationManager_OnRefreshGalaxyCpuConnectionsAsyncCompletedEvent;
            _galaxyPanelCommunicationManager.GalaxyCpuConnectionInfoEvent += GalaxyPanelCommunicationManager_OnGalaxyCpuConnectionInfoEvent;
            _galaxyPanelCommunicationManager.GalaxyCpuInformationEvent += GalaxyPanelCommunicationManager_OnGalaxyCpuInformationEvent;
            _galaxyPanelCommunicationManager.GalaxyCpuDataPacketEvent += GalaxyPanelCommunicationManager_OnGalaxyCpuDataPacketEvent;
        }

        private void MessageBroker_GlobalMessageReceived(object sender, PDSAMessageBrokerEventArgs e)
        {
            base.ClearCustomErrors();

            // Use this event to receive all messages
            switch (e.MessageName)
            {
                case MessageNames.FlashProgressMessage:
                    if (e.MessageObject.MessageBody is FlashProgressMessage msg)
                    {
                        var c = Connections.FirstOrDefault(o => o.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId == msg.ClusterGroupId && o.ConnectionInfo.GalaxyCpuInformation.ClusterNumber == msg.ClusterNumber && o.ConnectionInfo.GalaxyCpuInformation.PanelNumber == msg.PanelNumber && o.ConnectionInfo.GalaxyCpuInformation.CpuId == msg.CpuId);
                        if (c != null)
                        {
                            c.ConnectionInfo.GalaxyCpuInformation.FlashProgressMessage = msg;
                            Trace.WriteLine($"FlashProgressMessage CurrentState: {msg.CurrentState}, ValidationResult: {msg.ValidationResult}, {msg.ProgressMessage}");
                        }
                    }
                    break;

                case MessageNames.PanelLoadDataReply:
                    if (e.MessageObject.MessageBody is PanelLoadDataReply loadDataReply)
                    {
                        var c = Connections.FirstOrDefault(o => o.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId == loadDataReply.ClusterGroupId && o.ConnectionInfo.GalaxyCpuInformation.ClusterNumber == loadDataReply.ClusterNumber && o.ConnectionInfo.GalaxyCpuInformation.PanelNumber == loadDataReply.PanelNumber && o.ConnectionInfo.GalaxyCpuInformation.CpuId == loadDataReply.CpuId);
                        if (c != null)
                        {
                            if (c.PanelLoadDataReplies == null)
                                c.PanelLoadDataReplies = new ObservableCollection<PanelLoadDataReply>();
                            while (c.PanelLoadDataReplies.Count > Properties.Settings.Default.NumberOfLoadRepliesToDisplay)
                            {
                                c.PanelLoadDataReplies.RemoveAt(c.PanelLoadDataReplies.Count - 1);
                            }
                            c.PanelLoadDataReplies.Insert(0, loadDataReply);
                            Trace.WriteLine($"PanelLoadDataReply {loadDataReply.CreatedDateTime} {loadDataReply.UniqueId} DataType: {loadDataReply.DataType}, {loadDataReply.AckNack}");
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void GalaxyPanelCommunicationManager_OnGalaxyCpuDataPacketEvent(object sender, GalaxyPanelCommunicationManager.GalaxyCpuDataPacketEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                try
                {
                    if (e.DataPacket != null)
                    {
                        foreach (GalaxyConnectionDebugWindow debugWin in _debugWindows.Values)
                        {
                            if (debugWin.ViewModel.InstanceGuid == e.DataPacket.ConnectionGuid)
                            {
                                debugWin.ViewModel.HandlePacket(e.DataPacket);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Log().ErrorFormat("BroadcastPanelDebugPacketToClient exception: {0}", ex.Message);
                }
            });
        }

        private void GalaxyPanelCommunicationManager_OnGalaxyCpuInformationEvent(object sender, GalaxyPanelCommunicationManager.GalaxyCpuInformationEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (Connections != null)
                {
                    foreach (CpuConnection cpu in Connections)
                    {
                        if (cpu.ConnectionInfo.EntityGuid.ToString() == e.GalaxyCpuInformation.InstanceGuid)
                        {
                            cpu.ConnectionInfo.GalaxyCpuInformation = e.GalaxyCpuInformation;
                            break;
                        }
                    }
                }
            });
        }

        private void GalaxyPanelCommunicationManager_OnGalaxyCpuConnectionInfoEvent(object sender, GalaxyPanelCommunicationManager.GalaxyCpuConnectionInfoEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (Connections == null)
                    Connections = new ObservableCollection<CpuConnection>();
                var existingConnection = Connections.FirstOrDefault(o => o.ConnectionInfo.EntityGuid == e.GalaxyCpuConnectionInfo.EntityGuid);
                if (e.GalaxyCpuConnectionInfo.IsConnected)
                {
                    if (existingConnection != null)
                        Connections.Remove(existingConnection);
                    e.GalaxyCpuConnectionInfo.GalaxyCpuInformation.FlashProgressMessage = new FlashProgressMessage();
                    var c = new CpuConnection();
                    c.ConnectionInfo = e.GalaxyCpuConnectionInfo;
                    Connections.Add(c);
                    if (Settings.Default.OpenDebugOnConnect == true)
                        OnDebugConnectionCommand(c);
                }
                else
                {
                    if (existingConnection != null)
                    {
                        bool bDeleted = Connections.Remove(existingConnection);

                        if (_debugWindows.ContainsKey(existingConnection.ConnectionInfo.EntityGuid))
                        {
                            GalaxyConnectionDebugWindow debugWin = _debugWindows[existingConnection.ConnectionInfo.EntityGuid];
                            if (debugWin != null)
                            {
                                debugWin.Close();
                                _debugWindows.Remove(existingConnection.ConnectionInfo.EntityGuid);
                            }
                        }
                    }

                    //foreach (var cpu in Connections)
                    //{
                    //    if (cpu.ConnectionInfo.EntityGuid == e.GalaxyCpuConnectionInfo.EntityGuid)
                    //    {
                    //        bool bDeleted = Connections.Remove(cpu);

                    //        if (_debugWindows.ContainsKey(cpu.ConnectionInfo.EntityGuid))
                    //        {
                    //            GalaxyConnectionDebugWindow debugWin = _debugWindows[cpu.ConnectionInfo.EntityGuid];
                    //            if (debugWin != null)
                    //            {
                    //                debugWin.Close();
                    //                _debugWindows.Remove(cpu.ConnectionInfo.EntityGuid);
                    //            }
                    //        }
                    //        break;
                    //    }
                    //}
                }
                GetIsCommunicationServerRunningStatus();
            });
        }

        private void GalaxyPanelCommunicationManager_OnRefreshGalaxyCpuConnectionsAsyncCompletedEvent(object sender, GalaxyPanelCommunicationManager.GalaxyCpuConnectionsEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                Connections = new ObservableCollection<CpuConnection>();
                foreach (var c in e.GalaxyCpuConnections)
                {
                    Connections.Add(new CpuConnection() { ConnectionInfo = c, });
                }
            });
        }

        private void GalaxyPanelCommunicationManager_OnGetIsCommunicationServerRunningStatusAsyncCompletedEvent(object sender, GalaxyPanelCommunicationManager.CommunicationServerRunningStatusEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                CommunicationServerRunningStatus = e.CommunicationServerRunningStatus;
            });
        }

        private void GalaxyPanelCommunicationManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private async void MessageBroker_MessageReceived(object sender, PDSAMessageBrokerEventArgs e)
        {
            base.ClearCustomErrors();

            // Use this event to receive all messages
            switch (e.MessageName)
            {
                case MessageNames.SendRawData:
                    SendDataPacketToServer((RawDataToSend)e.MessageObject.MessageBody);
                    break;

                case MessageNames.SendAbaSettings:
                    SendDataResponse<AbaSettings> result = null;

                    _galaxyPanelCommunicationManager.UseAsyncServiceCalls = UseAsyncServiceCalls;
                    if (e.MessageObject.MessageBody is SendDataParameters<AbaSettings>)
                    {
                        result = await _galaxyPanelCommunicationManager.SendAbaSettingsAsync((SendDataParameters<AbaSettings>)e.MessageObject.MessageBody);
                        //result = _galaxyPanelCommunicationManager.SendAbaSettings((SendDataParameters<AbaSettings>)e.MessageObject.MessageBody);

                    }
                    break;

                default:
                    break;
            }
        }

        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        private bool _isVisible = true;

        public bool IsVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isVisible;
            }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged(() => _isVisible, false);
                }
            }
        }

        //private void SendDataPacketToServer(RawDataToSend data)
        //{
        //    if (UseAsyncServiceCalls == false)
        //    {
        //        WithClient<IGalaxyPanelCommunicationManagerService>(
        //            _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
        //            Globals.Instance.ServerConnections[0].Binding,
        //            Globals.Instance.ServerConnections[0].EndpointBaseAddress, 
        //            Globals.Instance.ServerConnections[0].ClientUserSessionData), proxy =>
        //            {
        //                proxy.SendDataPacket(data);
        //            });
        //    }
        //    else
        //    {
        //        WithClientAsync<IGalaxyPanelCommunicationManagerService>(
        //            _ServiceFactory.CreateClient<IGalaxyPanelCommunicationManagerService>(
        //            Globals.Instance.ServerConnections[0].Binding,
        //            Globals.Instance.ServerConnections[0].EndpointBaseAddress,
        //            Globals.Instance.ServerConnections[0].ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        Task t = proxy.SendDataPacketAsync(data);
        //                        await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                    }
        //                    catch (AggregateException ae)
        //                    {
        //                        ae = ae.Flatten();
        //                        foreach (Exception ex in ae.InnerExceptions)
        //                            this.Log().Debug(ex.Message);
        //                    }
        //                }
        //            });
        //    }

        //}

        private void SendDataPacketToServer(RawDataToSend data)
        {
            _galaxyPanelCommunicationManager.UseAsyncServiceCalls = UseAsyncServiceCalls;
            _galaxyPanelCommunicationManager.SendDataPacketToServer(data);
        }

        public override string ViewTitle
        {
            get { return Properties.Resources.GalaxyPanelCommunicationView_Title; }
        }

        protected override void OnViewLoaded()
        {
            UseAsyncServiceCalls = true;
            _galaxyPanelCommunicationManager.Initialize();
            GetIsCommunicationServerRunningStatus();
            Task.Run(async () =>
            {
                await RefreshGalaxyFlashImageCollections();

            }).Wait();
        }

        public override void ViewUnloaded(object arg)
        {
            PDSAMessageBrokerMessage msg = new PDSAMessageBrokerMessage();

            msg.MessageName = MessageNames.CloseAllDebugWindows;
            msg.MessageBody = null;
            _MessageBroker.SendMessage(msg);
        }

        private void GetIsCommunicationServerRunningStatus()
        {
            if (UseAsyncServiceCalls == false)
            {
                CommunicationServerRunningStatus = _galaxyPanelCommunicationManager.GetIsCommunicationServerRunningStatus();
            }
            else
            {
                _galaxyPanelCommunicationManager.GetIsCommunicationServerRunningStatusAsync();
            }
        }
        private ObservableCollection<CpuConnection> _Connections;
        private bool _communicationServerRunningStatus;
        private Timer _timerRefreshConnections;

        public ObservableCollection<CpuConnection> Connections
        {
            get { return _Connections; }
            set
            {
                if (_Connections != value)
                {
                    _Connections = value;
                    OnPropertyChanged(() => Connections, false);
                }
            }
        }

        public ObservableCollection<GalaxyFlashImage> GalaxyFlashImages635 { get; set; }
        public ObservableCollection<GalaxyFlashImage> GalaxyFlashImages600 { get; set; }

        private GalaxyFlashImage _Selected600FlashImage;

        public GalaxyFlashImage Selected600FlashImage
        {
            get { return _Selected600FlashImage; }
            set
            {
                if (_Selected600FlashImage != value)
                {
                    _Selected600FlashImage = value;
                    OnPropertyChanged(() => Selected600FlashImage, false);
                }
            }
        }


        private GalaxyFlashImage _Selected635FlashImage;

        public GalaxyFlashImage Selected635FlashImage
        {
            get { return _Selected635FlashImage; }
            set
            {
                if (_Selected635FlashImage != value)
                {
                    _Selected635FlashImage = value;
                    OnPropertyChanged(() => Selected635FlashImage, false);
                }
            }
        }

        public bool CommunicationServerRunningStatus
        {
            get { return _communicationServerRunningStatus; }
            set
            {
                if (_communicationServerRunningStatus != value)
                {
                    _communicationServerRunningStatus = value;
                    OnPropertyChanged(() => CommunicationServerRunningStatus, false);
                    OnStartCommunicationServerCommandCanExecute(null);
                    OnStopCommunicationServerCommandCanExecute(null);
                    if (CommunicationServerRunningStatus == true)
                        StartRefreshConnectionsTimer();
                }
            }
        }

        private void RefreshConnectionsTimerCallback(object o)
        {
            OnRefreshConnectionsCommand(null);
        }
        private void StartRefreshConnectionsTimer()
        {
            _timerRefreshConnections = new Timer(RefreshConnectionsTimerCallback, null, 250, Timeout.Infinite);
        }

        private void StopRefreshConnectionsTimer()
        {
            if (_timerRefreshConnections != null)
            {
                _timerRefreshConnections.Dispose();
            }

        }

        public DelegateCommand<object> StartCommunicationServerCommand { get; private set; }
        public DelegateCommand<object> StopCommunicationServerCommand { get; private set; }
        public DelegateCommand<object> RefreshConnectionsCommand { get; private set; }
        public DelegateCommand<CpuConnection> DebugConnectionCommand { get; private set; }
        public DelegateCommand<CpuConnection> AddNewCpuCommand { get; private set; }
        public DelegateCommand<CpuConnection> BeginFlashLoadCommand { get; private set; }
        public DelegateCommand<CpuConnection> CancelFlashLoadCommand { get; private set; }
        public DelegateCommand<CpuConnection> PauseFlashLoadCommand { get; private set; }
        public DelegateCommand<CpuConnection> ResumeFlashLoadCommand { get; private set; }
        public DelegateCommand<CpuConnection> ValidateFlashCommand { get; private set; }
        public DelegateCommand<CpuConnection> ValidateAndBurnFlashCommand { get; private set; }
        public DelegateCommand<CpuConnection> LoadClusterDataCommand { get; private set; }
        public DelegateCommand<CpuConnection> ClearPanelLoadDataRepliesCommand { get; private set; }
        public DelegateCommand<CpuConnection> EnableFlashBoardsCommand { get; private set; }

        public DelegateCommand<CpuConnection> RequestBoardsCommand { get; private set; }

        //public DelegateCommand<CpuConnection> LoadSchedulesDataCommand { get; private set; }
        //public DelegateCommand<CpuConnection> LoadAccessPortalDataCommand { get; private set; }
        //public DelegateCommand<CpuConnection> LoadCredentialDataCommand { get; private set; }
        //public DelegateCommand<CpuConnection> LoadInputOutputGroupDataCommand { get; private set; }

        private void OnStopCommunicationServerCommand(object obj)
        {
            if (UseAsyncServiceCalls == false)
            {
                _galaxyPanelCommunicationManager.StopCommunicationServer(obj);
            }
            else
            {
                _galaxyPanelCommunicationManager.StopCommunicationServerAsync(obj);
            }
        }

        private bool OnStopCommunicationServerCommandCanExecute(object obj)
        {
            return CommunicationServerRunningStatus;
        }

        private bool OnStartCommunicationServerCommandCanExecute(object obj)
        {
            return !CommunicationServerRunningStatus;
        }

        private void OnStartCommunicationServerCommand(object obj)

        {
            if (UseAsyncServiceCalls == false)
            {
                _galaxyPanelCommunicationManager.StartCommunicationServer(obj);
            }
            else
            {
                _galaxyPanelCommunicationManager.StartCommunicationServerAsync(obj);
                GetIsCommunicationServerRunningStatus();

            }
        }

        private void OnRefreshConnectionsCommand(object obj)
        {
            if (UseAsyncServiceCalls == false)
            {
                Connections =
                    new ObservableCollection<CpuConnection>();
                var conns = _galaxyPanelCommunicationManager.RefreshGalaxyCpuConnections(new GetCpuConnectionsParameters() { GetOption = GetCpuConnectionParams.All });
                foreach (var c in conns)
                {
                    Connections.Add(new CpuConnection() { ConnectionInfo = c, });
                }
            }
            else
            {
                _galaxyPanelCommunicationManager.RefreshGalaxyCpuConnectionsAsync(new GetCpuConnectionsParameters() { GetOption = GetCpuConnectionParams.All });
            }
        }

        private bool OnRefreshConnectionsCommandCanExecute(object obj)
        {
            //return true;
            return CommunicationServerRunningStatus;
        }

        private bool OnDebugConnectionCommandCanExecute(CpuConnection cpu)
        {
            return true;
        }

        private void OnDebugConnectionCommand(CpuConnection cpu)
        {
            try
            {
                if (cpu != null)
                {

                    bool bFound = false;
                    foreach (GalaxyConnectionDebugWindow debugWin in _debugWindows.Values)
                    {
                        if (debugWin.ViewModel.InstanceGuid == cpu.ConnectionInfo.EntityGuid)
                        {
                            bFound = true;
                            debugWin.Activate();
                            break;
                        }
                    }

                    if (bFound == false)
                    {
                        GalaxyConnectionDebugWindow debugWin = new GalaxyConnectionDebugWindow();
                        if (debugWin != null)
                        {
                            debugWin.Closing += DebugWinOnClosing;
                            debugWin.ViewModel.Initialize(cpu.ConnectionInfo);
                            _debugWindows.Add(cpu.ConnectionInfo.EntityGuid, debugWin);
                            debugWin.Show();
                        }

                        _galaxyPanelCommunicationManager.DebugConnection(cpu.ConnectionInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("OnDebugConnectionCommand exception: {0}", ex.Message);
            }
        }

        private bool OnAddNewCpuCommandCanExecute(CpuConnection obj)
        {
            if (obj == null)
                return false;

            if (obj.ConnectionInfo?.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.ClusterUid != Guid.Empty)
            {
                return Globals.Instance.UserSessionToken.HasPermission(PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId);
            }

            return Globals.Instance.UserSessionToken.HasPermission(
                PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) && Globals.CurrentSite != null;
        }

        private async void OnAddNewCpuCommand(CpuConnection obj)
        {
            await SaveCpuInfo(obj);
        }

        private async Task SaveCpuInfo(CpuConnection obj)
        {
            try
            {
                Globals.Instance.IsBusy = true;
                Globals.Instance.BusyContent = Properties.Resources.BusyContent_PleaseWait_SavingCpuInformation;
                var mgr = Globals.Instance.GetManager<GalaxyCpuManager>();
                var savedData = await mgr.SaveGalaxyCpuConnectionInfoAsync(new SaveParameters<CpuConnectionInfo>()
                { Data = obj.ConnectionInfo });
                if (mgr.HasErrors)
                {
                    AddCustomErrors(mgr.Errors, true);
                }
                else
                {
                    var existingConnection = Connections.FirstOrDefault(o => o.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId == savedData.ClusterGroupId &&
                     o.ConnectionInfo.GalaxyCpuInformation.ClusterNumber == savedData.ClusterNumber && o.ConnectionInfo.GalaxyCpuInformation.PanelNumber == savedData.PanelNumber &&
                     o.ConnectionInfo.GalaxyCpuInformation.CpuId == savedData.CpuNumber);
                    if (existingConnection != null)
                    {   // Update the properties
                        existingConnection.ConnectionInfo.CpuDatabaseInformation = savedData;
                        existingConnection.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId = savedData.ClusterGroupId;
                        existingConnection.ConnectionInfo.GalaxyCpuInformation.ClusterUid = savedData.ClusterUid;
                        existingConnection.ConnectionInfo.GalaxyCpuInformation.PanelUid = savedData.GalaxyPanelUid;
                        existingConnection.ConnectionInfo.GalaxyCpuInformation.CpuUid = savedData.CpuUid;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
            Globals.Instance.IsBusy = false;
        }

        private async Task RefreshGalaxyFlashImageCollections()
        {
            try
            {
                Globals.Instance.IsBusy = true;
                var mgr = Globals.Instance.GetManager<GalaxyFlashImageManager>();
                var flashImages = await mgr.GetAllGalaxyFlashImagesAsync(new GetParametersWithPhoto());
                if (mgr.HasErrors)
                {
                    AddCustomErrors(mgr.Errors, true);
                }
                else
                {
                    //this.GalaxyFlashImages600 = flashImages.Where(o => o.GalaxyCpuModelUid == GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_600).ToObservableCollection();
                    this.GalaxyFlashImages635 = flashImages.Where(o => o.GalaxyCpuModelUid == GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635).ToObservableCollection();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
            Globals.Instance.IsBusy = false;

        }


        private bool OnRequestBoardsCommandCanExecute(CpuConnection obj)
        {
            return obj?.ConnectionInfo?.GalaxyCpuInformation != null;
        }

        private async void OnRequestBoardsCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;

            Globals.BusyContent = string.Empty;

            Globals.IsBusy = true;
            var manager = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyCpuCommandAction>()
            {
                Data = new GalaxyCpuCommandAction()
                {
                    CommandAction = GalaxyCpuCommandActionCode.RequestBoardInformation
                },
                SessionId = Globals.Instance.UserSessionToken.SessionId,
                CurrentEntityId = Globals.Instance.UserSessionToken.CurrentEntityId
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }

            bool bResult = false;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteGalaxyCpuCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteGalaxyCpuCommandAsync(parameters);
            }

            if (bResult == true && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnEnableFlashBoardsCommandCanExecute(CpuConnection obj)
        {
            return true;
        }

        private async void OnEnableFlashBoardsCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;

            Globals.BusyContent = string.Empty;

            Globals.IsBusy = true;
            var manager = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyCpuCommandAction>()
            {
                Data = new GalaxyCpuCommandAction()
                {
                    CommandAction = GalaxyCpuCommandActionCode.EnableDaughterBoardFlashUpdate
                },
                SessionId = Globals.Instance.UserSessionToken.SessionId,
                CurrentEntityId = Globals.Instance.UserSessionToken.CurrentEntityId
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }

            bool bResult = false;
            if (UseAsyncServiceCalls == false)
            {
                bResult = manager.ExecuteGalaxyCpuCommand(parameters);
            }
            else
            {
                bResult = await manager.ExecuteGalaxyCpuCommandAsync(parameters);
            }

            if (bResult == true && manager.HasErrors == false)
            {

            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private async void OnValidateAndBurnFlashCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;

            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.ValidateAndBurnFlashData,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;

            bool bDeleted = Connections.Remove(obj);

            if (_debugWindows.ContainsKey(obj.ConnectionInfo.EntityGuid))
            {
                GalaxyConnectionDebugWindow debugWin = _debugWindows[obj.ConnectionInfo.EntityGuid];
                if (debugWin != null)
                {
                    debugWin.Close();
                    _debugWindows.Remove(obj.ConnectionInfo.EntityGuid);
                }
            }
        }

        private bool OnValidateAndBurnFlashCommandCanExecute(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation?.FlashProgressMessage == null)
                return false;
            return obj.ConnectionInfo?.GalaxyCpuInformation.FlashProgressMessage?.CurrentState == FlashingState.ValidationFinished;
        }

        private async void OnValidateFlashCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;

            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.ValidateFlashData,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnValidateFlashCommandCanExecute(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation?.FlashProgressMessage == null)
                return false;
            return obj.ConnectionInfo?.GalaxyCpuInformation.FlashProgressMessage?.CurrentState == FlashingState.ValidationFinished;
        }

        private async void OnPauseFlashLoadCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;


            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.PauseFlashLoad,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnPauseFlashLoadCommandCanExecute(CpuConnection obj)
        {
            return true;
        }

        private async void OnResumeFlashLoadCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;

            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.ResumeFlashLoad,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnResumeFlashLoadCommandCanExecute(CpuConnection obj)
        {
            return true;
        }
        private async void OnCancelFlashLoadCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;


            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.CancelFlashLoad,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnCancelFlashLoadCommandCanExecute(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return false;
            switch (obj.ConnectionInfo.GalaxyCpuInformation.CpuModel)
            {
                case Common.Enums.CpuModel.Cpu600:
                case Common.Enums.CpuModel.Cpu635:
                    break;

                default:
                    return false;
            }
            return true;
        }

        private async void OnBeginFlashLoadCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return;
            GalaxyFlashImage flashImage = null;
            switch (obj.ConnectionInfo.GalaxyCpuInformation.CpuModel)
            {
                case Common.Enums.CpuModel.Cpu600:
                    flashImage = Selected600FlashImage;
                    break;

                case Common.Enums.CpuModel.Cpu635:
                    flashImage = Selected635FlashImage;
                    break;
            }

            if (flashImage == null)
                return;

            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<GalaxyLoadFlashCommandAction>()
            {
                Data = new GalaxyLoadFlashCommandAction()
                {
                    CommandAction = GalaxyLoadFlashCommandActionCode.BeginFlashLoad,
                    GalaxyFlashImageUid = flashImage.GalaxyFlashImageUid,
                    PacketsPerLoadMessage = 7,
                    SendPacketIntervalMilliseconds = GalaxyFlashLoadLimits.DefaultFlashPacketInterval,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            if (obj.ConnectionInfo.CpuDatabaseInformation != null && obj.ConnectionInfo.CpuDatabaseInformation.CpuUid != Guid.Empty)
                parameters.Data.CpuUid = obj.ConnectionInfo.CpuDatabaseInformation.CpuUid;
            else
            {
                parameters.Data.CpuAddresses.Add(new CpuHardwareAddress(obj.ConnectionInfo.GalaxyCpuInformation.CpuAddress));
            }
            bool bResult = false;

            bResult = await mgr.ExecuteGalaxyLoadFlashCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;

        }

        private bool OnBeginFlashLoadCommandCanExecute(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null)
                return false;

            switch (obj.ConnectionInfo.GalaxyCpuInformation.CpuModel)
            {
                case Common.Enums.CpuModel.Cpu600:
                    return Selected600FlashImage != null;

                case Common.Enums.CpuModel.Cpu635:
                    return Selected635FlashImage != null;

                case Common.Enums.CpuModel.Unknown:
                case Common.Enums.CpuModel.Cpu5xx:
                case Common.Enums.CpuModel.Cpu708:
                default:
                    return false;

            }
            return false;
        }

        //private async void OnLoadInputOutputGroupDataCommand(CpuConnection obj)
        //{
        //}

        //private bool OnLoadInputOutputGroupDataCommandCanExecute(CpuConnection obj)
        //{
        //    return true;
        //}

        //private async void OnLoadCredentialDataCommand(CpuConnection obj)
        //{
        //}

        //private bool OnLoadCredentialDataCommandCanExecute(CpuConnection obj)
        //{
        //    return true;
        //}

        //private async void OnLoadAccessPortalDataCommand(CpuConnection obj)
        //{
        //}

        //private bool OnLoadAccessPortalDataCommandCanExecute(CpuConnection obj)
        //{
        //    return true;
        //}

        //private async void OnLoadSchedulesDataCommand(CpuConnection obj)
        //{
        //}

        //private bool OnLoadSchedulesDataCommandCanExecute(CpuConnection obj)
        //{
        //    return true;
        //}

        private bool OnClearPanelLoadDataRepliesCommandCanExecute(CpuConnection obj)
        {
            return true;
        }

        private void OnClearPanelLoadDataRepliesCommand(CpuConnection obj)
        {
            obj.PanelLoadDataReplies.Clear();
        }

        private async void OnLoadClusterDataCommand(CpuConnection obj)
        {
            if (obj?.ConnectionInfo?.GalaxyCpuInformation == null || obj?.ConnectionInfo?.CpuDatabaseInformation == null)
                return;

            //Globals.BusyContent = $"Please wait. Sending {flashImage.Version} to {obj.GalaxyCpuInformation..ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.Instance.GetManager<GalaxyPanelCommunicationManager>();

            var parameters = new CommandParameters<ClusterDataLoadParameters>()
            {
                Data = new ClusterDataLoadParameters()
                {
                    ClusterUid = obj.ConnectionInfo.GalaxyCpuInformation.ClusterUid,
                    GalaxyPanelUid = obj.ConnectionInfo.GalaxyCpuInformation.PanelUid,
                    CpuUid = obj.ConnectionInfo.GalaxyCpuInformation.CpuUid,
                    LoadDataSettings = obj.LoadDataSettings,
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            parameters.Data.CpuAddresses.Add(new CpuHardwareAddress()
            {
                ClusterGroupId = obj.ConnectionInfo.GalaxyCpuInformation.ClusterGroupId,
                ClusterNumber = obj.ConnectionInfo.GalaxyCpuInformation.ClusterNumber,
                PanelNumber = obj.ConnectionInfo.GalaxyCpuInformation.PanelNumber,
                CpuId = obj.ConnectionInfo.GalaxyCpuInformation.CpuId
            });



            var bResult = await mgr.SendClusterDataToPanelsAsync(parameters);

            if (bResult != null && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
        }

        private bool OnLoadClusterDataCommandCanExecute(CpuConnection obj)
        {
            return true;
        }


        private void DebugWinOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (sender is GalaxyConnectionDebugWindow)
            {
                _galaxyPanelCommunicationManager.StopDebuggingConnection(((GalaxyConnectionDebugWindow)sender).ViewModel.InstanceGuid);
                _debugWindows.Remove(((GalaxyConnectionDebugWindow)sender).ViewModel.InstanceGuid);
            }
        }
    }
}