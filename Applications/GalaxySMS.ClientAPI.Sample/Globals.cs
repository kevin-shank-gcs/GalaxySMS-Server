using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
#if SignalRCore
using GalaxySMS.SignalRCore;
#else
using GalaxySMS.Client.SignalRClient;
#endif
using GalaxySMS.ClientAPI.Sample.Properties;
using GCS.Core.Common.SignalR;
using GCS.Core.Common.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using AutoMapper;
using GalaxySMS.Common.AutoMapper;
using GCS.Core.Common.Logger;

namespace GalaxySMS.ClientAPI.Sample
{
    public class Globals : ViewModelBase, IDisposable
    {
        #region Private fields
        private static Globals _instance;
        private UserSignInResult _signInResult;
        private UserEntity _currentUserEntity;
        private ListCollectionView _currentEntitySites;
        private Site _currentSite;
#if SignalRCore
        private SignalRCore.SignalRClient _signalRClient;
#else
private SignalRClient _signalRClient;
#endif
        #endregion

        #region Constructor
        private Globals()
        {
            Messenger = new Messenger();

            var serverConnectionSettings = new GalaxySiteServerConnectionSettings()
            {
                BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp,
                ServerName = Settings.Default.ServerAddress,
                ServerAddress = Settings.Default.ServerAddress,
                PortNumber = Settings.Default.ServerPort,
                ApiServerUrl = Settings.Default.ApiServerUrl,
                SignalRServerUrl = Settings.Default.SignalRServerUrl,
            };

            ServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);
            //// Specify the ApplicationId that this will be used for, if it is not GalaxySMS_Admin_Id, which is the default
            //siteServerConnection.ClientUserSessionData.ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_Admin_Id;

            // Create SignalRClient object and define handlers for the events
#if SignalRCore
            _signalRClient = new SignalRCore.SignalRClient();

            _signalRClient.PanelBoardInformationCollectionEvent += _signalRClient_PanelBoardInformationCollectionEvent;
            _signalRClient.NotInPanelMemoryCredentialActivityLogEvent += _signalRClient_NotInPanelMemoryCredentialActivityLogEvent;
            _signalRClient.CredentialActivityLogEvent += _signalRClient_CredentialActivityLogEvent;
            _signalRClient.CredentialAlarmEvent += _signalRClient_CredentialAlarmEvent;
            _signalRClient.ActivityLogEvent += _signalRClient_ActivityLogEvent;
            _signalRClient.AlarmEvent += _signalRClient_AlarmEvent;
            _signalRClient.AcknowledgedAlarmBasicDataEvent += _signalRClient_AcknowledgedAlarmBasicDataEvent;
            _signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            _signalRClient.InputDeviceStatusReplyEvent += _signalRClient_InputDeviceStatusReplyEvent;
            _signalRClient.LoggingStatusReplyEvent += _signalRClient_LoggingStatusReplyEvent;
            _signalRClient.PanelInqueryReplyEvent += _signalRClient_PanelInqueryReplyEvent;
            _signalRClient.CardCountReplyEvent += _signalRClient_CardCountReplyEvent;
            _signalRClient.FlashProgressMessageEvent += _signalRClient_FlashProgressMessageEvent;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configuration.CreateMapper();


#else
            _signalRClient = new SignalRClient();
            _signalRClient.ConnectionStateChangedEvent += this._signalRClient_ConnectionStateChangedEvent;
            _signalRClient.ConnectionClosedEvent += _signalRClient_ConnectionClosedEvent;
            _signalRClient.ConnectionErrorEvent += _signalRClient_ConnectionErrorEvent;
            _signalRClient.PanelBoardInformationCollectionEvent += _signalRClient_PanelBoardInformationCollectionEvent;
            _signalRClient.NotInPanelMemoryCredentialActivityLogEvent += _signalRClient_NotInPanelMemoryCredentialActivityLogEvent;
            _signalRClient.CredentialActivityLogEvent += _signalRClient_CredentialActivityLogEvent;
            _signalRClient.CredentialAlarmEvent += _signalRClient_CredentialAlarmEvent;
            _signalRClient.ActivityLogEvent += _signalRClient_ActivityLogEvent;
            _signalRClient.AlarmEvent += _signalRClient_AlarmEvent;
            _signalRClient.AcknowledgedAlarmBasicDataEvent += _signalRClient_AcknowledgedAlarmBasicDataEvent;
            _signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            _signalRClient.InputDeviceStatusReplyEvent += _signalRClient_InputDeviceStatusReplyEvent;
            _signalRClient.LoggingStatusReplyEvent += _signalRClient_LoggingStatusReplyEvent;
            _signalRClient.PanelInqueryReplyEvent += _signalRClient_PanelInqueryReplyEvent;
            _signalRClient.CredentialCountReplyEvent += _signalRClient_CardCountReplyEvent;
            _signalRClient.FlashProgressMessageEvent += _signalRClient_FlashProgressMessageEvent;
#endif
        }


        #endregion

        #region Public Properties
        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }
        public Messenger Messenger { get; internal set; }
        public IGalaxySiteServerConnection ServerConnection { get; }
        public UserSessionToken UserSessionToken { get { return SignInResult?.SessionToken; } }
        public bool IsUserSessionValid
        {
            get
            {
                if (UserSessionToken == null)
                    return false;
                if (UserSessionToken.ExpirationDateTime < DateTimeOffset.Now)
                    return false;
                if (UserSessionToken.SignedOutDateTime < DateTimeOffset.Now)
                    return false;
                if (UserSessionToken.SessionId == Guid.Empty)
                    return false;
                return true;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This is the currently selected entity for the user. </summary>
        ///
        /// <value> The current user entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntity CurrentUserEntity
        {
            get { return _currentUserEntity; }
            set
            {
                if (_currentUserEntity != value)
                {
                    _currentUserEntity = value;
                    OnPropertyChanged(() => CurrentUserEntity, false);

                    // Update the ServerConnection.ClientUserSessionData.CurrentEntityId value.
                    // This is important so that future calls to GetManager<T> will initialize the manager with the proper CurrentEntityId value.
                    // This will endure that the server returns data only for the currently selected entity
                    // Also, update the UserSessionToken.CurrentEntityId value to match
                    if (CurrentUserEntity != null)
                    {
                        if (UserSessionToken == null)
                            ServerConnection.ClientUserSessionData.CurrentEntityId = Guid.Empty;
                        else
                        {
                            ServerConnection.ClientUserSessionData.CurrentEntityId = CurrentUserEntity.EntityId;
                            UserSessionToken.CurrentEntityId = CurrentUserEntity.EntityId;
                        }
                        Messenger.Send<NotificationMessage<UserEntity>>(new NotificationMessage<UserEntity>(CurrentUserEntity, string.Empty));
                        Task.Run(async () => { await RefreshEntitySites(); }).Wait();
                    }
                    else
                        ServerConnection.ClientUserSessionData.CurrentEntityId = Guid.Empty;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the currently selected/active site. </summary>
        ///
        /// <value> The current site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Site CurrentSite
        {
            get { return _currentSite; }
            set
            {
                // Update the ServerConnection.ClientUserSessionData.CurrentSiteId value.
                // This is important so that future calls to GetManager<T> will initialize the manager with the proper CurrentSiteId value.
                // This will endure that the server returns data only for the currently selected site
                if (_currentSite != value)
                {
                    _currentSite = value;
                    if (CurrentSite != null)
                        ServerConnection.ClientUserSessionData.CurrentSiteId = CurrentSite.SiteUid;
                    else
                        ServerConnection.ClientUserSessionData.CurrentSiteId = Guid.Empty;

                    OnPropertyChanged(() => CurrentSite, false);
                    Messenger.Send(new NotificationMessage<Site>(CurrentSite, string.Empty));
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sign in result. </summary>
        ///
        /// <value> The sign in result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInResult SignInResult
        {
            get { return _signInResult; }
            set
            {
                if (_signInResult != value)
                {
                    _signInResult = value;

                    // Set the server connection ClientUserSessionData properties
                    //UpdateServerConnectionsClientUserSessionData();

                    OnPropertyChanged(() => SignInResult, false);
                    OnPropertyChanged(() => UserSessionToken, false);
                    OnPropertyChanged(() => IsUserSessionValid, false);
                    OnPropertyChanged(() => CurrentUserEntities, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the current user entities.  </summary>
        ///
        /// <value> The Collection of UserEntities for the currently signed in user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ICollection<UserEntity> CurrentUserEntities
        {
            get { return UserSessionToken?.UserData?.UserEntities; }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This is a list of sites for the current entity. </summary>
        ///
        /// <value> The Collection of Sites for the currently selected entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListCollectionView CurrentEntitySites
        {
            get { return _currentEntitySites; }
            set
            {
                if (_currentEntitySites != value)
                {
                    _currentEntitySites = value;
                    OnPropertyChanged(() => CurrentEntitySites, false);
                }
            }
        }
        public IMapper Mapper { get; internal set; }

        #endregion

        #region Public methods

        public void UserSignedOut(UserSessionToken t)
        {
            if (SignInResult != null)
                SignInResult.SessionToken = t;
            OnPropertyChanged(() => SignInResult, false);
            OnPropertyChanged(() => UserSessionToken, false);
            OnPropertyChanged(() => IsUserSessionValid, false);
            OnPropertyChanged(() => CurrentUserEntities, false);
        }

        public T GetManager<T>() where T : ManagerBase, new()
        {
            var sessionHeader = ServerConnection.ClientUserSessionData;
            var manager = Helpers.GetManager<T>(ServerConnection.ConnectionSettings.ServerAddress,
                GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, sessionHeader);
            return manager;
        }
        #endregion

        #region Private methods
        private async Task RefreshEntitySites()
        {
            var parameters = new GetParametersWithPhoto();
            var siteManager = GetManager<SiteManager>();
            var sites = await siteManager.GetAllSitesForEntityAsync(parameters);
            CurrentEntitySites = new ListCollectionView(sites.ToList<Client.Entities.Site>());
            CurrentEntitySites?.GroupDescriptions?.Add(new PropertyGroupDescription("RegionName"));
            CurrentSite = sites.FirstOrDefault();
            if (siteManager.HasErrors)
            {
                base.AddCustomErrors(siteManager.Errors, true);
            }
        }

        private async void UpdateServerConnectionsClientUserSessionData()
        {
            if (IsUserSessionValid == false)
            {
                ServerConnection.ClientUserSessionData.CurrentEntityId = Guid.Empty;
                ServerConnection.ClientUserSessionData.SessionGuid = Guid.Empty;
                ServerConnection.ClientUserSessionData.CurrentSiteId = Guid.Empty;
            }
            else
            {
                ServerConnection.ClientUserSessionData.CurrentEntityId = UserSessionToken.CurrentEntityId;
                ServerConnection.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                if (CurrentSite != null)
                    ServerConnection.ClientUserSessionData.CurrentSiteId = CurrentSite.SiteUid;
                else
                    ServerConnection.ClientUserSessionData.CurrentSiteId = Guid.Empty;

                if (_signalRClient.ConnectionState == ConnectionState.Disconnected)
                {
                    await ConnectToSignalRHub();

                }
                else
                {

                    await _signalRClient.UpdateSessionId(ServerConnection.ClientUserSessionData.SessionGuid);
                    foreach (var e in UserSessionToken.UserData.Entities)
                    {
                        await _signalRClient.JoinGroup(e.EntityId.ToString());
                    }
                }
            }
        }

        //public async Task<bool> ConnectToSignalRHub()
        //{
        //    if (_signalRClient.ConnectionState != ConnectionState.Connected &&
        //        !string.IsNullOrEmpty(ServerConnection.ConnectionSettings.SignalRServerUrl))
        //    {
        //        _signalRClient.Jwt = UserSessionToken.JwtToken;
        //        var connected = await _signalRClient.ConnectAsync(ServerConnection.ConnectionSettings.SignalRServerUrl, UserSessionToken.SessionId, string.Empty, true);
        //        if (connected != true)
        //            return connected;
        //        foreach (var e in UserSessionToken.UserData.Entities)
        //        {
        //            await _signalRClient.JoinGroup(e.EntityId.ToString());
        //        }
        //    }
        //    return true;
        //}
        public async Task<bool> ConnectToSignalRHub()
        {
            this.Log().Info($"ConnectToSignalRHub entered");
            if (_signalRClient.ConnectionState != ConnectionState.Connected &&
                !string.IsNullOrEmpty(ServerConnection.ConnectionSettings.SignalRServerUrl))
            {
                _signalRClient.Jwt = UserSessionToken.JwtToken;
                var connected = await _signalRClient.ConnectAsync(ServerConnection.ConnectionSettings.SignalRServerUrl, UserSessionToken.SessionId, string.Empty, true);
                if (connected != true)
                {
                    this.Log().Info($"Unable to connect to SignalR: {ServerConnection.ConnectionSettings.SignalRServerUrl}");
                    return false;
                }
                foreach (var e in UserSessionToken.UserData.Entities)
                {
                    this.Log().Info($"Joining SignalR group: {e.EntityId}");
                    await _signalRClient.JoinGroup(e.EntityId.ToString());
                }

                this.Log().Info($"Connected to SignalR: {ServerConnection.ConnectionSettings.SignalRServerUrl}");
                return true;
            }

            if (_signalRClient.ConnectionState == ConnectionState.Connected &&
                !string.IsNullOrEmpty(ServerConnection.ConnectionSettings.SignalRServerUrl))
            {
                this.Log().Info($"Connected to SignalR: {ServerConnection.ConnectionSettings.SignalRServerUrl}");
                return true;
            }
            this.Log().Info($"Not connected to SignalR. _signalRClient.ConnectionState:{_signalRClient.ConnectionState}, SignalRServerUrl:{ServerConnection.ConnectionSettings.SignalRServerUrl}");
            return false;
        }

        private async Task LeaveSignalRGroups(UserSessionToken userSessionToken)
        {
            if (UserSessionToken == null || this._signalRClient == null)
                return;

            foreach (var e in userSessionToken.UserData.Entities)
            {
                await _signalRClient.LeaveGroup(e.EntityId.ToString());
            }
        }

#if SignalRCore
        private void _signalRClient_PanelBoardInformationCollectionEvent(object sender, SignalRClient.PanelBoardInformationCollectionEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelBoardInformationCollection>(Mapper.Map<PanelBoardInformationCollection>(e.EventData), string.Empty));
        }

        private void _signalRClient_AccessPortalStatusReplyEvent(object sender, SignalRClient.AccessPortalStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<AccessPortalStatusReply>(Mapper.Map<AccessPortalStatusReply>(e.EventData), string.Empty));
        }

        private void _signalRClient_InputDeviceStatusReplyEvent(object sender, SignalRClient.InputDeviceStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<InputDeviceStatusReply>(Mapper.Map<InputDeviceStatusReply>(e.EventData), string.Empty));
        }

        private void _signalRClient_FlashProgressMessageEvent(object sender, SignalRClient.FlashProgressMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<FlashProgressMessage>(Mapper.Map<FlashProgressMessage>(e.EventData), string.Empty));
        }


        private void _signalRClient_CardCountReplyEvent(object sender, SignalRClient.CardCountReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<CredentialCountReply>(Mapper.Map<CredentialCountReply>(e.EventData), string.Empty));
        }

        private void _signalRClient_PanelInqueryReplyEvent(object sender, SignalRClient.PanelInqueryReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelInqueryReply>(Mapper.Map<PanelInqueryReply>(e.EventData), string.Empty));
        }

        private void _signalRClient_LoggingStatusReplyEvent(object sender, SignalRClient.LoggingStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<LoggingStatusReply>(Mapper.Map<LoggingStatusReply>(e.EventData), string.Empty));
        }

        private void _signalRClient_AlarmEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelActivityLogMessage>(Mapper.Map<PanelActivityLogMessage>(e.EventData), string.Empty), e.EventData.IsAlarmEvent.ToString());//(string.Empty));
        }

        private void _signalRClient_AcknowledgedAlarmBasicDataEvent(object sender, SignalRCore.SignalRClient.AcknowledgedAlarmBasicDataEventArgs e)
        {
            Messenger.Send(new NotificationMessage<AcknowledgedAlarmBasicData>(Mapper.Map<AcknowledgedAlarmBasicData>(e.EventData), string.Empty));
        }

        private void _signalRClient_ActivityLogEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelActivityLogMessage>(Mapper.Map<PanelActivityLogMessage>(e.EventData), string.Empty));
        }

        private void _signalRClient_CredentialAlarmEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData), string.Empty), e.EventData.IsAlarmEvent.ToString());//(string.Empty));
        }

        private void _signalRClient_CredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData), string.Empty));
        }

        private void _signalRClient_NotInPanelMemoryCredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData), string.Empty));
        }

        private void _signalRClient_ConnectionErrorEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionErrorEventArgs e)
        {
        }

        private void _signalRClient_ConnectionClosedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionClosedEventArgs e)
        {
        }

        private void _signalRClient_ConnectionStateChangedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionStateChangedEventArgs e)
        {
        }

        public void Dispose()
        {
            if (_signalRClient != null)
            {
                _signalRClient.Disconnect();
                _signalRClient.Dispose();
            }
        }
#else
        private void _signalRClient_PanelBoardInformationCollectionEvent(object sender, SignalRClient.PanelBoardInformationCollectionEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelBoardInformationCollection>(e.BoardsInfo, string.Empty));
        }

        private void _signalRClient_AccessPortalStatusReplyEvent(object sender, SignalRClient.AccessPortalStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<AccessPortalStatusReply>(e.StatusData, string.Empty));
        }

        private void _signalRClient_InputDeviceStatusReplyEvent(object sender, SignalRClient.InputDeviceStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<InputDeviceStatusReply>(e.StatusData, string.Empty));
        }

        private void _signalRClient_FlashProgressMessageEvent(object sender, SignalRClient.FlashProgressMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<FlashProgressMessage>(e.EventData, string.Empty));
        }


        private void _signalRClient_CardCountReplyEvent(object sender, SignalRClient.CredentialCountReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<CredentialCountReply>(e.EventData, string.Empty));
        }

        private void _signalRClient_PanelInqueryReplyEvent(object sender, SignalRClient.PanelInqueryReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelInqueryReply>(e.EventData, string.Empty));
        }

        private void _signalRClient_LoggingStatusReplyEvent(object sender, SignalRClient.LoggingStatusReplyEventArgs e)
        {
            Messenger.Send(new NotificationMessage<LoggingStatusReply>(e.EventData, string.Empty));
        }

        private void _signalRClient_AlarmEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelActivityLogMessage>(e.EventData, string.Empty), e.EventData.IsAlarmEvent.ToString());//(string.Empty));
        }

        private void _signalRClient_AcknowledgedAlarmBasicDataEvent(object sender, SignalRClient.AcknowledgedAlarmBasicDataEventArgs e)
        {
            Messenger.Send(new NotificationMessage<AcknowledgedAlarmBasicData>(e.EventData, string.Empty));
        }

        private void _signalRClient_ActivityLogEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelActivityLogMessage>(e.EventData, string.Empty));
        }

        private void _signalRClient_CredentialAlarmEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(e.EventData, string.Empty), e.EventData.IsAlarmEvent.ToString());//(string.Empty));
        }

        private void _signalRClient_CredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(e.EventData, string.Empty));
        }

        private void _signalRClient_NotInPanelMemoryCredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            Messenger.Send(new NotificationMessage<PanelCredentialActivityLogMessage>(e.EventData, string.Empty));
        }

        private void _signalRClient_ConnectionErrorEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionErrorEventArgs e)
        {
        }

        private void _signalRClient_ConnectionClosedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionClosedEventArgs e)
        {
        }

        private void _signalRClient_ConnectionStateChangedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionStateChangedEventArgs e)
        {
        }

        public void Dispose()
        {
            if(_signalRClient != null)
            {
                _signalRClient.Disconnect();
                _signalRClient.Dispose();
            }
        }
#endif
        #endregion


        public void NotifyPropertyChange(object prop)
        {
            OnPropertyChanged(() => CurrentUserEntities, false);
            UpdateServerConnectionsClientUserSessionData();
        }

    }

}
