using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Licensing;
using GCS.Framework.Utilities;
using PDSA.MessageBroker;
using SplashScreen = GalaxySMS.Admin.Views.SplashScreen;
using SharedResources = GalaxySMS.Resources;
using GalaxySMS.Client.SDK.Helpers;
using AutoMapper;
using GalaxySMS.Common.AutoMapper;
#if SignalRCore
using GalaxySMS.SignalRCore;
#else
using GalaxySMS.Client.SignalRClient;
#endif
using GCS.Core.Common.SignalR;

namespace GalaxySMS.Admin
{
    public class Globals : ViewModelBase
    {
        [ImportingConstructor]
        private Globals()
        {
            //            _ServiceFactory = ObjectBase.Container.GetExportedValue<IServiceFactory>();
            MessageBrokerPanelCommunication = new PDSAMessageBroker();
            MessageBroker = new PDSAMessageBroker();
            ServerConnections = new ObservableCollection<IGalaxySiteServerConnection>();

            var serverConnectionSettings = new GalaxySiteServerConnectionSettings();
            serverConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            serverConnectionSettings.ServerName = Settings.Default.ServerAddress;
            serverConnectionSettings.ServerAddress = Settings.Default.ServerAddress;
            serverConnectionSettings.PortNumber = Settings.Default.ServerPort;
            serverConnectionSettings.ApiServerUrl = Settings.Default.ApiServerUrl;
            serverConnectionSettings.SignalRServerUrl = Settings.Default.SignalRServerUrl;

            var siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);
            ServerConnections.Add(siteServerConnection);

            _systemManager = new SystemManager(siteServerConnection);
            _systemManager.GetSystemCompletedEvent += _systemManager_GetSystemCompletedEvent;
            _systemManager.ErrorsOccurredEvent += _systemManager_ErrorsOccurredEvent;

            _languageManger = new LanguageManager(siteServerConnection);
            _languageManger.GetAllLanguagesCompletedEvent += LanguageManger_OnGetAllLanguagesCompletedEvent;
            _languageManger.ErrorsOccurredEvent += LanguageManger_OnErrorsOccurredEvent;

            _roleManager = new RoleManager(siteServerConnection);
            _roleManager.GetAllRolesCompletedEvent += roleManager_OnGetAllRolesCompletedEvent;
            _roleManager.ErrorsOccurredEvent += roleManager_OnErrorsOccurredEvent;

            _entityManager = new EntityManager(siteServerConnection);
            //_entityManager.GetAllEntitesCompletedEvent += _entityManager_GetAllEntitesCompletedEvent;
            _entityManager.ErrorsOccurredEvent += _entityManager_ErrorsOccurredEvent;

            _siteManager = new SiteManager(siteServerConnection);
            _siteManager.ErrorsOccurredEvent += _siteManager_ErrorsOccurredEvent;

            _applicationManager = new ApplicationManager(siteServerConnection);
            _applicationManager.GetAllApplicationsCompletedEvent +=
                applicationManager_OnGetAllApplicationsCompletedEvent;
            _applicationManager.ApplicationValidatedWithServerEvent +=
                _applicationManager_ApplicationValidatedWithServerEvent;
            _applicationManager.ErrorsOccurredEvent += applicationManager_OnErrorsOccurredEvent;

            BackgroundSubduedOpacity = Settings.Default.BackgroundSubduedOpacity;
            if (Settings.Default.BackgroundSubduedBlur)
                BackgroundSubduedEffect = new BlurEffect();

            CustomerName = Settings.Default.CustomerName;
            CustomerEmail = Settings.Default.CustomerEmail;
            MyLicense = new LicenseData();

#if SignalRCore
            _signalRClient = new SignalRCore.SignalRClient();

            //_signalRClient.PanelBoardInformationCollectionEvent += _signalRClient_PanelBoardInformationCollectionEvent;
            //_signalRClient.NotInPanelMemoryCredentialActivityLogEvent += _signalRClient_NotInPanelMemoryCredentialActivityLogEvent;
            //_signalRClient.CredentialActivityLogEvent += _signalRClient_CredentialActivityLogEvent;
            //_signalRClient.CredentialAlarmEvent += _signalRClient_CredentialAlarmEvent;
            //_signalRClient.ActivityLogEvent += _signalRClient_ActivityLogEvent;
            //_signalRClient.AlarmEvent += _signalRClient_AlarmEvent;
            //_signalRClient.AcknowledgedAlarmBasicDataEvent += _signalRClient_AcknowledgedAlarmBasicDataEvent;
            //_signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            //_signalRClient.InputDeviceStatusReplyEvent += _signalRClient_InputDeviceStatusReplyEvent;
            //_signalRClient.LoggingStatusReplyEvent += _signalRClient_LoggingStatusReplyEvent;
            //_signalRClient.PanelInqueryReplyEvent += _signalRClient_PanelInqueryReplyEvent;
            //_signalRClient.CardCountReplyEvent += _signalRClient_CardCountReplyEvent;
            _signalRClient.FlashProgressMessageEvent += _signalRClient_FlashProgressMessageEvent;
            _signalRClient.PanelLoadDataReplyEvent += _signalRClient_PanelLoadDataReplyEvent;
            _signalRClient.BackgroundJobInfoEvent += _signalRClient_BackgroundJobInfoEvent;
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
            //_signalRClient.PanelBoardInformationCollectionEvent += _signalRClient_PanelBoardInformationCollectionEvent;
            //_signalRClient.NotInPanelMemoryCredentialActivityLogEvent += _signalRClient_NotInPanelMemoryCredentialActivityLogEvent;
            //_signalRClient.CredentialActivityLogEvent += _signalRClient_CredentialActivityLogEvent;
            //_signalRClient.CredentialAlarmEvent += _signalRClient_CredentialAlarmEvent;
            //_signalRClient.ActivityLogEvent += _signalRClient_ActivityLogEvent;
            //_signalRClient.AlarmEvent += _signalRClient_AlarmEvent;
            //_signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            //_signalRClient.LoggingStatusReplyEvent += _signalRClient_LoggingStatusReplyEvent;
            //_signalRClient.PanelInqueryReplyEvent += _signalRClient_PanelInqueryReplyEvent;
            //_signalRClient.CredentialCountReplyEvent += _signalRClient_CardCountReplyEvent;
            _signalRClient.FlashProgressMessageEvent += _signalRClient_FlashProgressMessageEvent;
            _signalRClient.PanelLoadDataReplyEvent += _signalRClient_PanelLoadDataReplyEvent;

#endif


        }

        private void _signalRClient_BackgroundJobInfoEvent(object sender, SignalRClient.BackgroundJobInfoEventArgs e)
        {

        }

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

        #region Private Fields

        private static Globals _instance;

        //        private IServiceFactory _ServiceFactory;

        private readonly SystemManager _systemManager;
        private readonly LanguageManager _languageManger;
        private readonly EntityManager _entityManager;
        private readonly RoleManager _roleManager;
        private readonly ApplicationManager _applicationManager;
        private readonly SiteManager _siteManager;

        //private License _license;
        //private IEnumerable<IValidationFailure> _licenseValidationFailures;
        //private bool _isLicenseValid;

        private gcsSystem _systemData;
        private gcsApplication _thisApplication;
        private Brush _mainWindowBackgroundBrush = Brushes.SaddleBrown;
        private Timer _endSplashTimer;
        private UserSessionToken _userSessionToken;
        private gcsEntity _currentUserEntity;
        private Site _currentSite;
#if SignalRCore
        private SignalRCore.SignalRClient _signalRClient;
#else
private SignalRClient _signalRClient;
#endif
        private Timer _keepSessionAliveTimer;

        #endregion

        #region Private Methods

        private void StartSplash()
        {
            Splasher.Splash = new SplashScreen();
            Splasher.Splash.DataContext = this;
            Splasher.ShowSplash();
            MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_Initializing);
        }

        private void EndSplash()
        {
            Splasher.CloseSplash();
        }

        private void _systemManager_GetSystemCompletedEvent(object sender, GetSystemCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate { UpdateSystemData(e.System); });
        }

        public void UpdateSystemData(gcsSystem systemData)
        {
            try
            {
                SystemData = systemData;

                var myProcessName = SystemUtilities.MyProcessName;
                if (myProcessName.EndsWith(".vshost"))
                    myProcessName = myProcessName.Replace(".vshost", string.Empty);
                var licenseFilename = string.Format("{0}\\{1}.license",
                    SystemUtilities.MyFolderLocation,
                    myProcessName);

                if (Settings.Default.UseLocalLicenseFile)
                    MyLicense.LoadFromFile(SystemData.PublicKey, licenseFilename);
                else
                {
                    if (Instance.SystemData != null && LicenseRequired)
                        MyLicense.InitializeFromXmlString(SystemData.PublicKey, Instance.SystemData.License);
                }

                OnPropertyChanged(() => MyLicense, false);

                if (MyLicense?.IsLicenseValid == true)
                    MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_LicenseLoadedAndValidated);
                else
                    MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_LicenseInvalid);
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new CustomError(ex.Message));
                MessageListener.Instance.ReceiveMessage(ex.Message);
            }
        }

        private void _systemManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                this.Log().ErrorFormat(error.ToString());
                AddCustomError(error);
            }
        }

        private void _applicationManager_ApplicationValidatedWithServerEvent(object sender,
            ApplicationValidatedWithServerCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                if (e.IsValidated)
                {
                    ThisApplication = new gcsApplication(e.Application);
                    //Override to emulate the default GalaxySMS Application Guid
                    //ThisApplication.ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id;
                    //ThisApplication.ApplicationName = MagicStrings.GalaxySMS;
                    MainWindowBackgroundBrush =
                        (SolidColorBrush)
                            (new BrushConverter().ConvertFrom(Settings.Default.AllGoodBorderColor.ToString()));
                    MessageListener.Instance.ReceiveMessage(
                        string.Format(Properties.Resources.SplashScreen_ApplicationValidatedWithServer,
                            e.ServerConnectionSettings.ServerAddress));

                    InitLicense();

                    RefreshAll();
                    if (_endSplashTimer == null)
                        _endSplashTimer = new Timer(EndSplashTimer_Tick, null, 1000, Timeout.Infinite);
                }
                else
                {
                    MainWindowBackgroundBrush =
                        (SolidColorBrush)
                            (new BrushConverter().ConvertFrom(Settings.Default.NotGoodBorderColor.ToString()));
                    MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_CouldNotValidateApplicationWithServer);
                    if (_endSplashTimer == null)
                        _endSplashTimer = new Timer(EndSplashTimer_Tick, true, 1000, Timeout.Infinite);
                }
            });
        }

        private void EndSplashTimer_Tick(object state)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                _endSplashTimer = null;

                EndSplash();
                if (state != null)
                    Application.Current.Shutdown(0);
            });
        }

        private void applicationManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                this.Log().ErrorFormat(error.ToString());
                AddCustomError(error);
            }
        }

        private void applicationManager_OnGetAllApplicationsCompletedEvent(object sender,
            GetAllApplicationsCompletedEventArgs e)
        {
            //_thisApplication = null;
            Application.Current.Dispatcher.Invoke(delegate
            {
                Applications = new ObservableCollection<gcsApplication>();
                foreach (var application in e.Applications)
                {
                    Applications.Add(application);
                    //if (application.ApplicationName == App.Current.ToString())
                    //    _thisApplication = application;
                }
                OnPropertyChanged(() => Applications, false);
            });
        }

        private void _entityManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void _siteManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }


        //private void _entityManager_GetAllEntitesCompletedEvent(object sender, GetAllEntitiesCompletedEventArgs e)
        //{
        //    Application.Current.Dispatcher.Invoke(delegate
        //    {
        //        Entities = new ObservableCollection<gcsEntity>();
        //        foreach (var entity in e.Entities)
        //        {
        //            Entities.Add(entity);
        //        }
        //        OnPropertyChanged(() => Entities, false);
        //    });
        //}

        private void LanguageManger_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void LanguageManger_OnGetAllLanguagesCompletedEvent(object sender, GetAllLanguagesCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                Languages = new ObservableCollection<gcsLanguage>();
                foreach (var language in e.Languages)
                {
                    Languages.Add(language);
                }
                OnPropertyChanged(() => Languages, false);
            });
        }

        private void roleManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void roleManager_OnGetAllRolesCompletedEvent(object sender, GetAllRolesCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                Roles = new ObservableCollection<gcsRole>();
                foreach (var role in e.Roles)
                {
                    Roles.Add(role);
                }
                OnPropertyChanged(() => Roles, false);
            });
        }

        public void RefreshEntitySites()
        {
            var parameters = new GetParametersWithPhoto();
            var sites = _siteManager.GetAllSitesForEntity(parameters);
            CurrentEntitySites = new ListCollectionView(sites.ToList<Client.Entities.Site>());
            CurrentEntitySites?.GroupDescriptions?.Add(new PropertyGroupDescription("RegionName"));

            if (_siteManager.HasErrors)
            {
                base.AddCustomErrors(_siteManager.Errors, true);
            }
        }
        #endregion

        #region Public Properties

        /// <summary>
        ///     Global Message Broker Object
        /// </summary>
        public PDSAMessageBroker MessageBrokerPanelCommunication { get; internal set; }

        public PDSAMessageBroker MessageBroker { get; internal set; }

        public ObservableCollection<IGalaxySiteServerConnection> ServerConnections { get; }

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

        public bool IsApplicationValidatedWithServer
        {
            get
            {
                if (_applicationManager == null)
                    return false;
                return _applicationManager.IsMyApplicationValidatedWithServer;
            }
        }

        public AssemblyAttributes MyAssemblyAtrributes
        {
            get
            {
                var myAssembly = GetType().Assembly;
                return SystemUtilities.
                    GetAssemblyAttributes(ref myAssembly);
            }
        }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public LicenseData MyLicense { get; internal set; }
        public FriendlyLicenseDetails IdProducerFriendlyLicenseDetails { get; set; }

        public UserSessionToken UserSessionToken
        {
            get { return _userSessionToken; }
            set
            {
                _userSessionToken = value;
                foreach (var serverConnection in ServerConnections)
                {
                    if (UserSessionToken == null)
                        serverConnection.ClientUserSessionData.SessionGuid = Guid.Empty;
                    else
                        serverConnection.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                }

                if (CurrentUserEntities != null)
                {
                    CurrentUserEntity = (from e in CurrentUserEntities
                                         where e.EntityId == UserSessionToken.UserData.PrimaryEntityId
                                         select e).FirstOrDefault();
                    if (_keepSessionAliveTimer == null)
                    {
                        if (UserSessionToken != null && UserSessionToken.IsActive)
                        {
                            var ts = UserSessionToken.ExpirationDateTime - DateTimeOffset.Now;
                            if (ts.TotalMinutes > 2)
                                ts = ts.Subtract(new TimeSpan(0, 1, 0));
                            else ts = TimeSpan.FromMinutes(1);
                            //ts = new TimeSpan(0,1,0);
                            _keepSessionAliveTimer = new Timer(KeepUserSessionAlive_Tick, null, ts, ts);
                        }
                    }
                }
                else
                {
                    CurrentUserEntity = null;
                }
                //foreach (var serverConnection in ServerConnections)
                //{
                //    if (UserSessionToken == null)
                //        serverConnection.ClientUserSessionData.SessionGuid = Guid.Empty;
                //    else
                //        serverConnection.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                //}
                OnPropertyChanged(() => UserSessionToken, false);
                OnPropertyChanged(() => CurrentUserEntities, false);
                OnPropertyChanged(() => IsUserSessionValid, false);
                Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
                {
                    MessageName = MessageNames.UserSessionTokenChanged,
                    MessageBody = UserSessionToken
                });

                if (_signalRClient.ConnectionState == ConnectionState.Disconnected)
                {
                    Task.Run(async () =>
                   {
                       await ConnectToSignalRHub();
                   });
                }
                else
                {
                    Task.Run(async () =>
                    {
                        await _signalRClient.UpdateSessionId(ServerConnections[0].ClientUserSessionData.SessionGuid);
                        if (UserSessionToken?.UserData?.Entities != null)
                        {
                            foreach (var e in UserSessionToken.UserData?.Entities)
                            {
                                await _signalRClient.JoinGroup(e.EntityId.ToString());
                            }
                        }
                    });
                }

            }
        }

        private void KeepUserSessionAlive_Tick(object state)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                if (UserSessionToken == null || UserSessionToken?.SessionId == Guid.Empty || UserSessionToken?.SignedOutDateTime < DateTimeOffset.Now)
                    return;
                var userSessionManager = GetManager<UserSessionManager>();
                Trace.WriteLine($"KeepUserSessionAlive_Tick Starting UserSessionToken expiration:{UserSessionToken.ExpirationDateTime}");
                UserSessionToken = userSessionManager.KeepAlive(UserSessionToken.SessionId);
                Trace.WriteLine($"KeepUserSessionAlive_Tick updated UserSessionToken expiration:{UserSessionToken.ExpirationDateTime}");
                //Task.Run(async () =>
                //{
                //    UserSessionToken = await userSessionManager.KeepAliveAsync(UserSessionToken.SessionId);
                //}).Wait();
            });
        }

        public ObservableCollection<gcsEntityEx> CurrentUserEntities
        {
            get
            {
                if (IsUserSessionValid)
                {
                    var data =
                        Entities.Where(e => UserSessionToken.UserData.Entities.Any(ue => ue.EntityId == e.EntityId))
                            .ToObservableCollection();
                    return data;
                }
                return null;
            }
        }


        private ListCollectionView _currentEntitySites;

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

        public gcsEntity CurrentUserEntity
        {
            get { return _currentUserEntity; }
            set
            {
                if (_currentUserEntity != value)
                {
                    _currentUserEntity = value;
                    OnPropertyChanged(() => CurrentUserEntity, false);
                    if (CurrentUserEntity != null)
                    {
                        foreach (var serverConnection in ServerConnections)
                        {
                            if (UserSessionToken == null)
                                serverConnection.ClientUserSessionData.CurrentEntityId = Guid.Empty;
                            else
                                serverConnection.ClientUserSessionData.CurrentEntityId = CurrentUserEntity.EntityId;

                            // Now inform the server that the currentEntityId for this session has changed
                            var userSessionManager = GetManager<UserSessionManager>();

                            var userSessionToken = userSessionManager.UpdateSessionSettings(new SaveParameters<UserSessionSettings>()
                            {
                                //SessionId = UserSessionToken.SessionId,
                                CurrentEntityId = serverConnection.ClientUserSessionData.CurrentEntityId
                            });
                        }
                        Task.Run(() => { RefreshEntitySites(); }).Wait();
                    }
                }
            }
        }


        public Site CurrentSite
        {
            get { return _currentSite; }
            set
            {
                if (_currentSite != value)
                {
                    _currentSite = value;
                    OnPropertyChanged(() => CurrentSite, true);
                    foreach (var serverConnection in ServerConnections)
                    {
                        if (UserSessionToken == null)
                            serverConnection.ClientUserSessionData.CurrentSiteId = Guid.Empty;
                        else
                        {
                            serverConnection.ClientUserSessionData.CurrentSiteId = CurrentSite.SiteUid;
                        }
                    }
                }
            }
        }

        public ObservableCollection<gcsLanguage> Languages { get; private set; }

        public ObservableCollection<gcsRole> Roles { get; private set; }

        public override string CustomErrorsHeaderText
        {
            get
            {
                var ret = string.Empty;

                if (CustomErrors != null)
                {
                    //string verb = (CustomErrors.Count() == 1 ? "is" : "are");
                    //string suffix = (CustomErrors.Count() == 1 ? "" : "s");

                    //ret = string.Format("There {0} {1} error{2}.", verb, CustomErrors.Count(), suffix);
                    ret = string.Format(Properties.Resources.CustomMessagesHeader_MessageCount, CustomErrors.Count());
                }

                return ret;
            }
        }
        public IMapper Mapper { get; internal set; }

        #endregion

        #region Public methods

        public T GetManager<T>() where T : ManagerBase, new()
        {
            var serverConnection = Instance.ServerConnections[0];
            var sessionHeader = serverConnection.ClientUserSessionData;
            var manager = Helpers.GetManager<T>(serverConnection.ConnectionSettings.ServerAddress,
                GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, sessionHeader);
            return manager;
        }

        public ObservableCollection<gcsRole> GetRolesForApplication(Guid applicationId)
        {
            return (from r in Roles
                    where r.EntityId == applicationId
                    select r).ToObservableCollection();
        }

        public ObservableCollection<gcsEntityEx> Entities { get; private set; }

        public ObservableCollection<gcsApplication> Applications { get; private set; }

        public gcsApplication ThisApplication
        {
            get { return _thisApplication; }
            internal set
            {
                _thisApplication = value;
                OnPropertyChanged(() => ThisApplication, false);
                OnPropertyChanged(() => IsApplicationValidatedWithServer, false);
            }
        }

        public gcsSystem SystemData
        {
            get { return _systemData; }
            internal set
            {
                _systemData = value;
                OnPropertyChanged(() => SystemData, false);
            }
        }

        public gcsUserRequirement GetUserRequirementsForEntity(Guid entityId)
        {
            var entity = (from e in Entities
                          where e.EntityId == entityId
                          select e).FirstOrDefault();
            if (entity != null)
                return entity.UserRequirements;
            return new gcsUserRequirement();
        }

        public void RefreshAll()
        {
            MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_LoadingData);

            var bUseAsynCallsOriginal = UseAsyncServiceCalls;
            UseAsyncServiceCalls = false;
            var dTask = Task.Factory.StartNew(async () => { await RefreshEntities(); });

            var dTask2 = dTask.ContinueWith(continuation => { RefreshLanguages(); });
            var dTask3 = dTask2.ContinueWith(continuation => { RefreshApplications(); });
            var dTask4 = dTask3.ContinueWith(continuation => { RefreshRoles(); });

            // Since a console application otherwise terminates, wait for both tasks to complete.
            Task.WaitAll(dTask, dTask2, dTask3, dTask4);
            MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_InitializationComplete);

            UseAsyncServiceCalls = bUseAsynCallsOriginal;
        }

        public void RefreshLanguages()
        {
            Languages = new ObservableCollection<gcsLanguage>();
            if (UseAsyncServiceCalls == false)
            {
                var languages = _languageManger.GetAllLanguages();
                foreach (var langauge in languages)
                    Languages.Add(langauge);
            }
            else
            {
                _languageManger.GetAllLanguagesAsync();
            }
        }

        public void RefreshRoles()
        {
            Roles = new ObservableCollection<gcsRole>();
            var getParams = new GetParametersWithPhoto()
            {
                IncludeMemberCollections = true
            };

            if (UseAsyncServiceCalls == false)
            {
                var roles = _roleManager.GetAllRoles(getParams);
                //foreach (var role in roles.Items)
                Roles.AddRange(roles.Items);
            }
            else
            {
                _roleManager.GetAllRolesAsync(getParams);
            }
        }

        public async Task RefreshEntities()
        {
            Entities = new ObservableCollection<gcsEntityEx>();
            var parameters = new GetParametersWithPhoto() { IncludeMemberCollections = true };// Set to true to included important details that are needed for some editing functions
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllApplications));
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.gcsEntityApplications));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ParentEntity));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ChildEntities));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.Settings));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllRoles));

            if (UseAsyncServiceCalls == false)
            {
                Entities = _entityManager.GetAllEntities(parameters).Items.ToObservableCollection();
                //foreach (var entity in entities)
                //    Entities.Add(entity);
            }
            else
            {
                var entities = await _entityManager.GetAllEntitiesAsync(parameters);
                Entities = entities.Items.ToObservableCollection();
            }
        }

        public void RefreshApplications()
        {
            var thisAppName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);
            var s = Application.Current.ToString();
            Applications = new ObservableCollection<gcsApplication>();
            if (UseAsyncServiceCalls == false)
            {
                var applications = _applicationManager.GetAllApplications();
                Applications.AddRange(applications);
                _thisApplication = Applications.FirstOrDefault(o => o.ApplicationName == thisAppName);
                //foreach (var application in applications)
                //{
                //    Applications.Add(application);
                //    if (application.ApplicationName == thisAppName)
                //        _thisApplication = application;
                //}
            }
            else
            {
                _applicationManager.GetAllApplicationsAsync();
            }
        }

        public void RefreshPermissionCategories()
        {
            //string thisAppName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);
            //string s = App.Current.ToString();
            //_Applications = new ObservableCollection<gcs>();
            //if (UseAsyncServiceCalls == false)
            //{
            //    ReadOnlyCollection<gcsApplication> applications = _applicationManager.GetAllApplications();
            //    foreach (gcsApplication application in applications)
            //    {
            //        _Applications.Add(application);
            //        if (application.ApplicationName == thisAppName)
            //            _thisApplication = application;
            //    }
            //}
            //else
            //{
            //    _applicationManager.GetAllApplicationsAsync();
            //}
        }

        public void RefreshPermissions()
        {
            //string thisAppName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);
            //string s = App.Current.ToString();
            //_Applications = new ObservableCollection<gcsApplication>();
            //if (UseAsyncServiceCalls == false)
            //{
            //    ReadOnlyCollection<gcsApplication> applications = _applicationManager.GetAllApplications();
            //    foreach (gcsApplication application in applications)
            //    {
            //        _Applications.Add(application);
            //        if (application.ApplicationName == thisAppName)
            //            _thisApplication = application;
            //    }
            //}
            //else
            //{
            //    _applicationManager.GetAllApplicationsAsync();
            //}
        }

        public void InitLicense()
        {
            MessageListener.Instance.ReceiveMessage(Properties.Resources.SplashScreen_LoadingLicense);
            _systemManager.GetSystemAsyncWithEvent(SystemIds.GalaxySMS_System_Id);
        }

        private InitializeSystemDatabaseRequest CreateInitializeSystemDatabaseRequestData(InitializeSystemDatabaseManager mgr)
        {
            var requestData = mgr.GetDefaultRequestData();



            return requestData;
        }


        public void ValidateThisApplicationWithServer(bool bCreate)
        {
            StartSplash();
            MessageListener.Instance.ReceiveMessage(string.Format(
                Properties.Resources.SplashScreen_ValidatingApplicationWithServer, Settings.Default.ServerAddress));

            var initializeSystemDatabaseManager = new InitializeSystemDatabaseManager(Instance.ServerConnections[0]);
            var requestData = CreateInitializeSystemDatabaseRequestData(initializeSystemDatabaseManager);
            initializeSystemDatabaseManager.ErrorsOccurredEvent += initializeSystemDatabaseManager_OnErrorsOccurredEvent;
            initializeSystemDatabaseManager.InitializeSystemDatabaseCompletedEvent +=
                InitializeSystemDatabaseManagerInitializeSystemDatabaseCompletedEvent;
            initializeSystemDatabaseManager.InitializeSystemDatabaseAsyncWithEvents(requestData);
        }


#if SignalRCore
        public async Task<bool> ConnectToSignalRHub()
        {
            this.Log().Info($"ConnectToSignalRHub entered");
            if (_signalRClient.ConnectionState != ConnectionState.Connected &&
                !string.IsNullOrEmpty(ServerConnections[0].ConnectionSettings.SignalRServerUrl))
            {
                _signalRClient.Jwt = UserSessionToken.JwtToken;
                var connected = await _signalRClient.ConnectAsync(ServerConnections[0].ConnectionSettings.SignalRServerUrl, UserSessionToken.SessionId, string.Empty, true);
                if (connected != true)
                {
                    this.Log().Info($"Unable to connect to SignalR: {ServerConnections[0].ConnectionSettings.SignalRServerUrl}");
                    return false;
                }
                foreach (var e in UserSessionToken.UserData.Entities)
                {
                    this.Log().Info($"Joining SignalR group: {e.EntityId}");
                    await _signalRClient.JoinGroup(e.EntityId.ToString());
                }

                this.Log().Info($"Connected to SignalR: {ServerConnections[0].ConnectionSettings.SignalRServerUrl}");
                return true;
            }

            if (_signalRClient.ConnectionState == ConnectionState.Connected &&
                !string.IsNullOrEmpty(ServerConnections[0].ConnectionSettings.SignalRServerUrl))
            {
                this.Log().Info($"Connected to SignalR: {ServerConnections[0].ConnectionSettings.SignalRServerUrl}");
                return true;
            }
            this.Log().Info($"Not connected to SignalR. _signalRClient.ConnectionState:{_signalRClient.ConnectionState}, SignalRServerUrl:{ServerConnections[0].ConnectionSettings.SignalRServerUrl}");
            return false;
        }

#else
        public async Task<bool> ConnectToSignalRHub()
        {
            if (_signalRClient.ConnectionState != ConnectionState.Connected &&
                !string.IsNullOrEmpty(ServerConnections[0].ConnectionSettings.SignalRServerUrl))
            {
                var connected = await _signalRClient.ConnectAsync(ServerConnections[0].ConnectionSettings.SignalRServerUrl, UserSessionToken.SessionId);
                if (connected != true)
                    return connected;
                foreach (var e in UserSessionToken.UserData.Entities)
                {
                    await _signalRClient.JoinGroup(e.EntityId.ToString());
                }
            }
            return true;
        }
#endif

        private void initializeSystemDatabaseManager_OnErrorsOccurredEvent(object sender,
            ErrorsOccurredEventArgs errorsOccurredEventArgs)
        {
            foreach (var error in errorsOccurredEventArgs.Errors)
            {
                this.Log().ErrorFormat(error.ToString());
                AddCustomError(error);
            }
        }

        private void InitializeSystemDatabaseManagerInitializeSystemDatabaseCompletedEvent(object sender,
            InitializeSystemDatabaseCompletedEventArgs e)
        {
            //var systemRole = new gcsRole
            //{
            //    RoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId,
            //    RoleName = GalaxySMS.Resources.Resources.SystemRole_RoleName,
            //    RoleDescription = GalaxySMS.Resources.Resources.SystemRole_RoleDescription,
            //    IsActive = true
            //};
            if (UseAsyncServiceCalls == false)
            {
                ThisApplication = _applicationManager.ValidateMyApplicationWithServer(true);
            }
            else
            {
                _applicationManager.ValidateMyApplicationWithServerAsyncWithEvents(true);
            }
        }

#if SignalRCore
        private void _signalRClient_PanelLoadDataReplyEvent(object sender, SignalRClient.PanelLoadDataReplyEventArgs e)
        {
            try
            {

                var panelLoadDataReply = Mapper.Map<PanelLoadDataReply>(e.EventData);
                var bsnMsg = string.Empty;
                if (panelLoadDataReply.ModuleNumber != 0 && panelLoadDataReply.NodeNumber != 0)
                    bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionModuleNodeAddressFormat, panelLoadDataReply.BoardNumber, panelLoadDataReply.SectionNumber,
                        panelLoadDataReply.ModuleNumber, panelLoadDataReply.NodeNumber);
                else if (panelLoadDataReply.NodeNumber != 0)
                    bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionNodeAddressFormat, panelLoadDataReply.BoardNumber, panelLoadDataReply.SectionNumber, panelLoadDataReply.NodeNumber);
                else
                    bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionAddressFormat, panelLoadDataReply.BoardNumber, panelLoadDataReply.SectionNumber, panelLoadDataReply.NodeNumber);
                switch (panelLoadDataReply.DataType)
                {
                    case Common.Enums.PanelLoadDataType.CpuHeartbeat:
                        break;
                    case Common.Enums.PanelLoadDataType.RecalibrateIoCommand1:
                        break;
                    case Common.Enums.PanelLoadDataType.RecalibrateIoCommand2:
                        break;
                    case Common.Enums.PanelLoadDataType.NotificationCardAreaChange:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandResetCpu:
                        break;
                    case Common.Enums.PanelLoadDataType.RecalibrateIoCommand7:
                        break;
                    case Common.Enums.PanelLoadDataType.RecalibrateIoCommand8:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandClearAutoTimer:
                        break;

                    case Common.Enums.PanelLoadDataType.CommandInitializeBoardSection:
                        bsnMsg += $" {SharedResources.Resources.CommandInitializeBoardSectionReply_InitializedAs_Description} ";
                        switch (panelLoadDataReply.BoardSectionType)
                        {
                            case Common.Enums.PanelInterfaceBoardSectionType.Unused:
                                panelLoadDataReply.Description = $"{bsnMsg} {panelLoadDataReply.BoardSectionType}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DrmSection_Description} ";
                                switch (panelLoadDataReply.CredentialReaderDataFormat)
                                {
                                    case Common.Enums.CredentialReaderDataFormat.Unknown:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                        panelLoadDataReply.Description += $"(Galaxy Keypad)";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Cardax:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                        break;
                                }
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Outputs_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Inputs_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.ElevatorRelays:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiElevatorControlRelays_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.CypressClockDisplay:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiCypressClockDisplay_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.OutputRelays:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiOutputControlRelays_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimWiegand_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimAba:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimClockData_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.LCD_4x20Display:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiLcd4x20Display_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.RS485DoorModule:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485DoorModule_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiAssaAbloyAperio_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.SaltoSallis:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiSalto_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485InputModule_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_OtisElevatorInterfaceCpu_Description}";
                                break;
                            //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                            //    panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_CardTourManagerCpu_Description}";
                            //    break;
                            case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_KoneElevatorInterfaceCpu_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtCpu_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtReader_Description}";
                                break;
                        }
                        break;

                    case Common.Enums.PanelLoadDataType.CommandLoadBoardSectionNodeData:
                        bsnMsg += $" {SharedResources.Resources.CommandLoadBoardSectionNodeDataReply_Loaded_Description} ";
                        switch (panelLoadDataReply.BoardSectionType)
                        {
                            case Common.Enums.PanelInterfaceBoardSectionType.Unused:
                                panelLoadDataReply.Description = $"{bsnMsg} {panelLoadDataReply.BoardSectionType}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DrmSection_Description} ";
                                switch (panelLoadDataReply.CredentialReaderDataFormat)
                                {
                                    case Common.Enums.CredentialReaderDataFormat.Unknown:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                        panelLoadDataReply.Description += $"(Galaxy Keypad)";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Cardax:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                        break;
                                }
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Outputs_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Inputs_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.ElevatorRelays:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiElevatorControlRelays_Description}";
                                break;

                            case Common.Enums.PanelInterfaceBoardSectionType.CypressClockDisplay:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiCypressClockDisplay_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.OutputRelays:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiOutputControlRelays_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimWiegand_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AllegionPimAba:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimClockData_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.LCD_4x20Display:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiLcd4x20Display_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.RS485DoorModule:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandLoadBoardSectionNodeDataReply_DsiRs485DoorModule_Description} ";
                                switch (panelLoadDataReply.CredentialReaderDataFormat)
                                {
                                    case Common.Enums.CredentialReaderDataFormat.Unknown:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                        panelLoadDataReply.Description += $"(Galaxy Keypad)";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.Cardax:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                        break;
                                    case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                        panelLoadDataReply.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                        break;
                                }
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiAssaAbloyAperio_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.SaltoSallis:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiSalto_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485InputModule_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_OtisElevatorInterfaceCpu_Description}";
                                break;
                            //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                            //    panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_CardTourManagerCpu_Description}";
                            //    break;
                            case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_KoneElevatorInterfaceCpu_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtCpu_Description}";
                                break;
                            case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                                panelLoadDataReply.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtReader_Description}";
                                break;
                        }
                        break;

                    case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedulesForDoor:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadAccessGroupSchedulesForDoor_Description} {bsnMsg} {SharedResources.Resources.PanelResponse_StartingAccessGroupNumber} {panelLoadDataReply.ItemString}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadTimeSchedule15MinuteFormat:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadTimeSchedule15MinuteFormat_Description} {panelLoadDataReply.ItemNumber}";
                        break;

                    case Common.Enums.PanelLoadDataType.CommandLoadExtendedCards:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadExtendedCards_Description} {panelLoadDataReply.ItemString}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadStandardCards:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadStandardCards_Description} {panelLoadDataReply.ItemString}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandDeleteCard:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedule:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandClearTimeSchedules:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandClearAllUsers:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandClearAccessGroupRange:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandClearAccessGroupRange_Description} {bsnMsg} {SharedResources.Resources.PanelResponse_AccessGroupRange} {panelLoadDataReply.ItemString}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupsCrisisGroups:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSetDateTime:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandPing:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidayTable:
                        var mfi = new System.Globalization.DateTimeFormatInfo();
                        panelLoadDataReply.ItemString = mfi.GetMonthName(panelLoadDataReply.ItemNumber).ToString();
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoad15MinuteScheduleHolidayTable_Description} {panelLoadDataReply.ItemNumber} {panelLoadDataReply.ItemString}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandPanelInquire:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandRequestTotalCardCount:
                        break;
                    case Common.Enums.PanelLoadDataType.NotificationInternalPanelRecalibrate:
                        break;
                    case Common.Enums.PanelLoadDataType.PanelRecalibrateComplete:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadPersonalDoors:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadPersonalDoors_Description} {panelLoadDataReply.ItemNumber}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoggingSetOnOff:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoggingResetPointers:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoggingAcknowledgeToMessageIndex:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSignOnChallenge:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSignOnChallengeResponse:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandRequestConnectedBoardInformation:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadTimeAdjustment:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSetCardLoadAcknowledgePanel:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandRequestLoggingInformation:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadTamperAcFailureLowBattery:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadTamperAcFailureLowBattery_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadABAOptions:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadABAOptions_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadLockoutOptions:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadLockoutOptions_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandForgivePassbackCard:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandForgivePassbackEverybody:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandRecalibrate:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandCardEnable:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandCardDisable:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSetUserAuthority:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadLedOptions:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadLedOptions_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadCrisisModeIOGroup:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadCrisisModeIOGroup_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandResetCrisisMode:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSetCrisisMode:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadWiegandStartStopSettings:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadWiegandStartStopSettings_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidays:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoad15MinuteScheduleHolidays_Description} {panelLoadDataReply.ItemNumber}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadCardaxStartStopSettings:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadCardaxStartStopSettings_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandGetIOGroupCounters:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadIOGroupArmSchedule:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadIOGroupArmSchedule_Description} {panelLoadDataReply.ItemNumber}";
                        break;
                    case Common.Enums.PanelLoadDataType.LoadAccessGroupCrisisGroup:
                        break;
                    case Common.Enums.PanelLoadDataType.CommandSetServerConsultationOptions:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandSetServerConsultationOptions_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleDayTypes:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleDayTypes_Description}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriod:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleTimePeriod_Description} {panelLoadDataReply.ItemNumber}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriodsForDayType:
                        panelLoadDataReply.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleTimePeriodsForDayType_Description} {panelLoadDataReply.ItemNumber}";
                        break;
                    case Common.Enums.PanelLoadDataType.CommandCardRemoteAccessRuleOverrideReply:
                        break;
                }
                Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
                {
                    MessageName = MessageNames.PanelLoadDataReply,
                    MessageBody = panelLoadDataReply
                });
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }

        }

        private void _signalRClient_FlashProgressMessageEvent(object sender, SignalRClient.FlashProgressMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<FlashProgressMessage>(e.EventData);

                Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
                {
                    MessageName = MessageNames.FlashProgressMessage,
                    MessageBody = eventData
                });
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

#else
        private void _signalRClient_ConnectionErrorEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionErrorEventArgs e)
        {
        }

        private void _signalRClient_ConnectionClosedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionClosedEventArgs e)
        {
        }

        private void _signalRClient_ConnectionStateChangedEvent(object sender, GCS.Core.Common.SignalR.SignalRConnectionStateChangedEventArgs e)
        {
        }
        private void _signalRClient_FlashProgressMessageEvent(object sender, SignalRClient.FlashProgressMessageEventArgs e)
        {
            Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
            {
                MessageName = MessageNames.FlashProgressMessage,
                MessageBody = e.EventData
            });
        }
        private void _signalRClient_PanelLoadDataReplyEvent(object sender, SignalRClient.PanelLoadDataReplyEventArgs e)
        {
            var bsnMsg = string.Empty;
            if (e.EventData.ModuleNumber != 0 && e.EventData.NodeNumber != 0)
                bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionModuleNodeAddressFormat, e.EventData.BoardNumber, e.EventData.SectionNumber,
                    e.EventData.ModuleNumber, e.EventData.NodeNumber);
            else if (e.EventData.NodeNumber != 0)
                bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionNodeAddressFormat, e.EventData.BoardNumber, e.EventData.SectionNumber, e.EventData.NodeNumber);
            else
                bsnMsg = string.Format(SharedResources.Resources.PanelResponse_BoardSectionAddressFormat, e.EventData.BoardNumber, e.EventData.SectionNumber, e.EventData.NodeNumber);
            switch (e.EventData.DataType)
            {
                case Common.Enums.PanelLoadDataType.CpuHeartbeat:
                    break;
                case Common.Enums.PanelLoadDataType.RecalibrateIoCommand1:
                    break;
                case Common.Enums.PanelLoadDataType.RecalibrateIoCommand2:
                    break;
                case Common.Enums.PanelLoadDataType.NotificationCardAreaChange:
                    break;
                case Common.Enums.PanelLoadDataType.CommandResetCpu:
                    break;
                case Common.Enums.PanelLoadDataType.RecalibrateIoCommand7:
                    break;
                case Common.Enums.PanelLoadDataType.RecalibrateIoCommand8:
                    break;
                case Common.Enums.PanelLoadDataType.CommandClearAutoTimer:
                    break;

                case Common.Enums.PanelLoadDataType.CommandInitializeBoardSection:
                    bsnMsg += $" {SharedResources.Resources.CommandInitializeBoardSectionReply_InitializedAs_Description} ";
                    switch (e.EventData.BoardSectionType)
                    {
                        case Common.Enums.PanelInterfaceBoardSectionType.None:
                            e.EventData.Description = $"{bsnMsg} {e.EventData.BoardSectionType}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DrmSection_Description} ";
                            switch (e.EventData.CredentialReaderDataFormat)
                            {
                                case Common.Enums.CredentialReaderDataFormat.Unknown:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                    e.EventData.Description += $"(Galaxy Keypad)";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Cardax:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                    break;
                            }
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Outputs_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Inputs_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiElevatorControlRelays_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiCypressClockDisplay_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiOutputControlRelays_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimWiegand_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimClockData_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiLcd4x20Display_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485DoorModule_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiAssaAbloyAperio_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiSalto:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiSalto_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485InputModule:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485InputModule_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_OtisElevatorInterfaceCpu_Description}";
                            break;
                        //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                        //    e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_CardTourManagerCpu_Description}";
                        //    break;
                        case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_KoneElevatorInterfaceCpu_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtCpu_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtReader_Description}";
                            break;
                    }
                    break;

                case Common.Enums.PanelLoadDataType.CommandLoadBoardSectionNodeData:
                    bsnMsg += $" {SharedResources.Resources.CommandLoadBoardSectionNodeDataReply_Loaded_Description} ";
                    switch (e.EventData.BoardSectionType)
                    {
                        case Common.Enums.PanelInterfaceBoardSectionType.None:
                            e.EventData.Description = $"{bsnMsg} {e.EventData.BoardSectionType}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DrmSection_Description} ";
                            switch (e.EventData.CredentialReaderDataFormat)
                            {
                                case Common.Enums.CredentialReaderDataFormat.Unknown:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                    e.EventData.Description += $"(Galaxy Keypad)";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Cardax:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                    break;
                            }
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Outputs_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_Dio8X4Inputs_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiElevatorControlRelays_Description}";
                            break;

                        case Common.Enums.PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiCypressClockDisplay_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiOutputControlRelays_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimWiegand_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiIngersolRandPimClockData_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiLcd4x20Display_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandLoadBoardSectionNodeDataReply_DsiRs485DoorModule_Description} ";
                            switch (e.EventData.CredentialReaderDataFormat)
                            {
                                case Common.Enums.CredentialReaderDataFormat.Unknown:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Unknown})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.GalaxyKeypadFormat:
                                    e.EventData.Description += $"(Galaxy Keypad)";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandFormat:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Wiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.WiegandKey:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_WiegandKey})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataInverted:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataStandard:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Rs232G5:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_RS232G5})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.CardaxWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.Cardax:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_Cardax})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPiv:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv})";
                                    break;
                                case Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand:
                                    e.EventData.Description += $"({SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand})";
                                    break;
                            }
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiAssaAbloyAperio_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiSalto:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiSalto_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485InputModule:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_DsiRs485InputModule_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_OtisElevatorInterfaceCpu_Description}";
                            break;
                        //case Common.Enums.PanelInterfaceBoardSectionType.CardTourManagerCpu:
                        //    e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_CardTourManagerCpu_Description}";
                        //    break;
                        case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_KoneElevatorInterfaceCpu_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtCpu_Description}";
                            break;
                        case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                            e.EventData.Description = $"{bsnMsg} {SharedResources.Resources.CommandInitializeBoardSectionReply_VeridtReader_Description}";
                            break;
                    }
                    break;

                case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedulesForDoor:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadAccessGroupSchedulesForDoor_Description} {bsnMsg} {SharedResources.Resources.PanelResponse_StartingAccessGroupNumber} {e.EventData.ItemString}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadTimeSchedule15MinuteFormat:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadTimeSchedule15MinuteFormat_Description} {e.EventData.ItemNumber}";
                    break;

                case Common.Enums.PanelLoadDataType.CommandLoadExtendedCards:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadExtendedCards_Description} {e.EventData.ItemString}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadStandardCards:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadStandardCards_Description} {e.EventData.ItemString}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandDeleteCard:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedule:
                    break;
                case Common.Enums.PanelLoadDataType.CommandClearTimeSchedules:
                    break;
                case Common.Enums.PanelLoadDataType.CommandClearAllUsers:
                    break;
                case Common.Enums.PanelLoadDataType.CommandClearAccessGroupRange:
                    e.EventData.Description = $"{SharedResources.Resources.CommandClearAccessGroupRange_Description} {bsnMsg} {SharedResources.Resources.PanelResponse_AccessGroupRange} {e.EventData.ItemString}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupsCrisisGroups:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSetDateTime:
                    break;
                case Common.Enums.PanelLoadDataType.CommandPing:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidayTable:
                    var mfi = new System.Globalization.DateTimeFormatInfo();
                    e.EventData.ItemString = mfi.GetMonthName(e.EventData.ItemNumber).ToString();
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoad15MinuteScheduleHolidayTable_Description} {e.EventData.ItemNumber} {e.EventData.ItemString}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandPanelInquire:
                    break;
                case Common.Enums.PanelLoadDataType.CommandRequestTotalCardCount:
                    break;
                case Common.Enums.PanelLoadDataType.NotificationInternalPanelRecalibrate:
                    break;
                case Common.Enums.PanelLoadDataType.PanelRecalibrateComplete:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadPersonalDoors:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadPersonalDoors_Description} {e.EventData.ItemNumber}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoggingSetOnOff:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoggingResetPointers:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoggingAcknowledgeToMessageIndex:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSignOnChallenge:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSignOnChallengeResponse:
                    break;
                case Common.Enums.PanelLoadDataType.CommandRequestConnectedBoardInformation:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadTimeAdjustment:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSetCardLoadAcknowledgePanel:
                    break;
                case Common.Enums.PanelLoadDataType.CommandRequestLoggingInformation:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadTamperAcFailureLowBattery:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadTamperAcFailureLowBattery_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadABAOptions:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadABAOptions_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadLockoutOptions:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadLockoutOptions_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandForgivePassbackCard:
                    break;
                case Common.Enums.PanelLoadDataType.CommandForgivePassbackEverybody:
                    break;
                case Common.Enums.PanelLoadDataType.CommandRecalibrate:
                    break;
                case Common.Enums.PanelLoadDataType.CommandCardEnable:
                    break;
                case Common.Enums.PanelLoadDataType.CommandCardDisable:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSetUserAuthority:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadLedOptions:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadLedOptions_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadCrisisModeIOGroup:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadCrisisModeIOGroup_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandResetCrisisMode:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSetCrisisMode:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadWiegandStartStopSettings:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadWiegandStartStopSettings_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidays:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoad15MinuteScheduleHolidays_Description} {e.EventData.ItemNumber}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadCardaxStartStopSettings:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadCardaxStartStopSettings_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandGetIOGroupCounters:
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadIOGroupArmSchedule:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadIOGroupArmSchedule_Description} {e.EventData.ItemNumber}";
                    break;
                case Common.Enums.PanelLoadDataType.LoadAccessGroupCrisisGroup:
                    break;
                case Common.Enums.PanelLoadDataType.CommandSetServerConsultationOptions:
                    e.EventData.Description = $"{SharedResources.Resources.CommandSetServerConsultationOptions_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleDayTypes:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleDayTypes_Description}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriod:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleTimePeriod_Description} {e.EventData.ItemNumber}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriodsForDayType:
                    e.EventData.Description = $"{SharedResources.Resources.CommandLoadMinuteScheduleTimePeriodsForDayType_Description} {e.EventData.ItemNumber}";
                    break;
                case Common.Enums.PanelLoadDataType.CommandCardRemoteAccessRuleOverrideReply:
                    break;
            }
            Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
            {
                MessageName = MessageNames.PanelLoadDataReply,
                MessageBody = e.EventData
            });
        }
#endif
        public Brush MainWindowBackgroundBrush
        {
            get { return _mainWindowBackgroundBrush; }
            set
            {
                _mainWindowBackgroundBrush = value;
                OnPropertyChanged(() => MainWindowBackgroundBrush, false);
            }
        }

        private bool _licenseRequired = true;

        public bool LicenseRequired
        {
            get { return _licenseRequired; }
            set
            {
                if (_licenseRequired != value)
                {
                    _licenseRequired = value;
                    OnPropertyChanged(() => LicenseRequired, false);
                }
            }
        }

        #endregion
    }
}