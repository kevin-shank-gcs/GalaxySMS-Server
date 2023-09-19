using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
#if SignalRCore
using GalaxySMS.SignalRCore;
#else
using GalaxySMS.Client.SignalRClient;
#endif
using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.SignalR;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Licensing;
using GCS.Framework.Licensing.Extensions;
using GCS.Framework.Utilities;
using Portable.Licensing.Prime.Validation;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaxySMS.Common.AutoMapper;
using LicenseType = Portable.Licensing.Prime.LicenseType;
using LocalReources = GalaxySMS.SharedServicesModule.Properties;
using AutoMapper;
using GCS.Core.Common.Logger;

namespace GalaxySMS.SharedServicesModule
{
    [Export(typeof(IClientServices))]
    public class ClientServices : ViewModelBase, IClientServices
    {
        private readonly IEventAggregator _eventAggregator;

        #region Private fields
        private LicenseData _license;
        private gcsSystem _systemData;
        private IEnumerable<IValidationFailure> _licenseValidationFailures;
        private bool _isLicenseValid;
        private ApplicationManager _applicationManager;
        private InitializeSystemDatabaseManager _initializeSystemDatabaseManager;
        private UserSessionToken _userSessionToken;
        private SignalRClient _signalRClient;
        private int _DefaultGridPageSize;
        private ReadOnlyCollection<EntityMapPermissionLevel> _entityMapPermissionLevels;
        private Site _currentSite;

        #endregion

        [ImportingConstructor]
        public ClientServices(IEventAggregator eventAggregator)
        {
            this.ServerConnections = new ObservableCollection<IGalaxySiteServerConnection>();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PubSubEvent<ChangeCurrentEntityForSession>>().Subscribe(SendChangeCurrentEntityForSessionToServer);
            //            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(SendChangeCurrentSiteForSessionToServer);

#if SignalRCore
            _signalRClient = new SignalRCore.SignalRClient();

            _signalRClient.PanelBoardInformationCollectionEvent += _signalRClient_PanelBoardInformationCollectionEvent;
            _signalRClient.NotInPanelMemoryCredentialActivityLogEvent += _signalRClient_NotInPanelMemoryCredentialActivityLogEvent;
            _signalRClient.CredentialActivityLogEvent += _signalRClient_CredentialActivityLogEvent;
            _signalRClient.CredentialAlarmEvent += _signalRClient_CredentialAlarmEvent;
            _signalRClient.ActivityLogEvent += _signalRClient_ActivityLogEvent;
            _signalRClient.AlarmEvent += _signalRClient_AlarmEvent;
            _signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            _signalRClient.SerialChannelGalaxyDoorModuleDataCollectionEvent += _signalRClient_SerialChannelGalaxyDoorModuleDataCollectionEvent;
            _signalRClient.SerialChannelGalaxyInputModuleDataCollectionEvent += _signalRClient_SerialChannelGalaxyInputModuleDataCollectionEvent;
            _signalRClient.InputDeviceVoltagesReplyEvent += _signalRClient_InputDeviceVoltagesReplyEvent;
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
            _signalRClient.AccessPortalStatusReplyEvent += _signalRClient_AccessPortalStatusReplyEvent;
            _signalRClient.SerialChannelGalaxyDoorModuleDataCollectionEvent += _signalRClient_SerialChannelGalaxyDoorModuleDataCollectionEvent;
            _signalRClient.SerialChannelGalaxyInputModuleDataCollectionEvent += _signalRClient_SerialChannelGalaxyInputModuleDataCollectionEvent;
            _signalRClient.InputDeviceVoltagesReplyEvent += _signalRClient_InputDeviceVoltagesReplyEvent;
#endif
            EntityAlias = "Customer";
            EntityAliasPlural = "Customers";
            ThumbnailPixelWidth = 200;
        }

        #region Private methods
        private void SendChangeCurrentEntityForSessionToServer(ChangeCurrentEntityForSession obj)
        {
            if (CurrentEntityId != obj?.UserEntity?.EntityId)
            {
                var userSessionManager = GetManager<UserSessionManager>();
                if (obj?.UserEntity != null)
                {
                    var userSessionToken = userSessionManager.UpdateSessionSettings(new SaveParameters<UserSessionSettings>()
                    {
                        //SessionId = UserSessionToken.SessionId,
                        CurrentEntityId = obj.UserEntity.EntityId
                    });

                    if (userSessionToken?.SessionId == UserSessionToken.SessionId)
                    {
                        UserSessionToken.ExpirationDateTime = userSessionToken.ExpirationDateTime;
                        UserSessionToken.CurrentEntityId = userSessionToken.CurrentEntityId;
                        var userEntity = (from ue in userSessionToken.UserData.UserEntities
                                          where ue.EntityId == CurrentEntityId
                                          select ue).FirstOrDefault();
                        _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Publish(new CurrentEntityForSessionChanged(userEntity));
                    }
                }
            }
        }

        //private void SendChangeCurrentSiteForSessionToServer(CurrentSiteForSessionChanged obj)
        //{
        //    if (CurrentSite.SiteUid != obj?.CurrentSite.SiteUid)
        //    {
        //        var userSessionManager = GetManager<UserSessionManager>();
        //        if (obj?.CurrentSite != null)
        //        {
        //            var userSessionToken = userSessionManager.UpdateSessionSettings(new SaveParameters<UserSessionSettings>()
        //            {
        //                //SessionId = UserSessionToken.SessionId,
        //                CurrentSiteUid = obj.CurrentSite.SiteUid
        //            });

        //            if (userSessionToken?.SessionId == UserSessionToken.SessionId)
        //            {
        //                UserSessionToken = userSessionToken;
        //                _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Publish(new CurrentEntityForSessionChanged(userEntity));
        //            }
        //        }
        //    }

        //}

        private void RefreshEntitySites()
        {
            var parameters = new GetParametersWithPhoto();
            var siteManager = GetManager<SiteManager>();
            var sites = siteManager.GetAllSitesForEntity(parameters);
            CurrentEntitySites = new ListCollectionView(sites.ToList<Client.Entities.Site>());
            CurrentEntitySites?.GroupDescriptions?.Add(new PropertyGroupDescription("RegionName"));

            if (siteManager.HasErrors)
            {
                base.AddCustomErrors(siteManager.Errors, true);
            }
        }
#if SignalRCore
        private void _signalRClient_PanelBoardInformationCollectionEvent(object sender, SignalRClient.PanelBoardInformationCollectionEventArgs e)
        {
            try
            {

                var eventData = Mapper.Map<PanelBoardInformationCollection>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelBoardInformationCollection>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_SerialChannelGalaxyInputModuleDataCollectionEvent(object sender, SignalRClient.SerialChannelGalaxyInputModuleDataCollectionEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<SerialChannelGalaxyInputModuleDataCollection>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyInputModuleDataCollection>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_InputDeviceVoltagesReplyEvent(object sender, SignalRClient.InputDeviceVoltagesReplyEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<InputDeviceVoltagesReply>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<InputDeviceVoltagesReply>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }


        private void _signalRClient_SerialChannelGalaxyDoorModuleDataCollectionEvent(object sender, SignalRClient.SerialChannelGalaxyDoorModuleDataCollectionEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<SerialChannelGalaxyDoorModuleDataCollection>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyDoorModuleDataCollection>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_AccessPortalStatusReplyEvent(object sender, SignalRClient.AccessPortalStatusReplyEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<AccessPortalStatusReply>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<AccessPortalStatusReply>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }


        private void _signalRClient_AlarmEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<PanelActivityLogMessage>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelActivityLogMessage>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_ActivityLogEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<PanelActivityLogMessage>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelActivityLogMessage>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_CredentialAlarmEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_CredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }

        private void _signalRClient_NotInPanelMemoryCredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            try
            {
                var eventData = Mapper.Map<PanelCredentialActivityLogMessage>(e.EventData);
                _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(eventData);
            }
            catch (Exception exception)
            {
                this.Log().Error($"{exception}");
            }
        }
#else
        private void _signalRClient_PanelBoardInformationCollectionEvent(object sender, SignalRClient.PanelBoardInformationCollectionEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelBoardInformationCollection>>().Publish(e.BoardsInfo);
        }

        private void _signalRClient_SerialChannelGalaxyInputModuleDataCollectionEvent(object sender, SignalRClient.SerialChannelGalaxyInputModuleDataCollectionEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyInputModuleDataCollection>>().Publish(e.EventData);
        }

        private void _signalRClient_InputDeviceVoltagesReplyEvent(object sender, SignalRClient.InputDeviceVoltagesReplyEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<InputDeviceVoltagesReply>>().Publish(e.StatusData);
        }


        private void _signalRClient_SerialChannelGalaxyDoorModuleDataCollectionEvent(object sender, SignalRClient.SerialChannelGalaxyDoorModuleDataCollectionEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<SerialChannelGalaxyDoorModuleDataCollection>>().Publish(e.EventData);
        }

        private void _signalRClient_AccessPortalStatusReplyEvent(object sender, SignalRClient.AccessPortalStatusReplyEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<AccessPortalStatusReply>>().Publish(e.StatusData);
        }


        private void _signalRClient_AlarmEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelActivityLogMessage>>().Publish(e.EventData);
        }

        private void _signalRClient_ActivityLogEvent(object sender, SignalRClient.PanelActivityLogMessageEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelActivityLogMessage>>().Publish(e.EventData);
        }

        private void _signalRClient_CredentialAlarmEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(e.EventData);
        }

        private void _signalRClient_CredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(e.EventData);
        }

        private void _signalRClient_NotInPanelMemoryCredentialActivityLogEvent(object sender, SignalRClient.PanelCredentialActivityLogMessageEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Publish(e.EventData);
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
#endif

        #endregion

        #region Public properties

        public ObservableCollection<IGalaxySiteServerConnection> ServerConnections { get; set; }

        public UserSessionToken UserSessionToken
        {
            get { return _userSessionToken; }
            set
            {
                Task.Run(async () => { await LeaveSignalRGroups(_userSessionToken); }).Wait();
                _userSessionToken = value;
                UpdateServerConnectionsClientUserSessionData();
                Task.Run(() => { RefreshEntitySites(); }).Wait();
            }
        }

        private async Task LeaveSignalRGroups(UserSessionToken userSessionToken)
        {
            if (_userSessionToken == null ||
                _signalRClient == null ||
                userSessionToken.UserData == null)
                return;

            foreach (var e in userSessionToken.UserData.Entities)
            {
                await _signalRClient.LeaveGroup(e.EntityId.ToString());
            }
        }

        public Guid CurrentSessionId
        {
            get
            {
                if (UserSessionToken != null)
                    return UserSessionToken.SessionId;
                return Guid.Empty;
            }
        }

        private void UpdateServerConnectionsClientUserSessionData()
        {
            if (UserSessionToken == null)
            {
                ServerConnections[0].ClientUserSessionData.CurrentEntityId = Guid.Empty;
                ServerConnections[0].ClientUserSessionData.SessionGuid = Guid.Empty;
                ServerConnections[0].ClientUserSessionData.CurrentSiteId = Guid.Empty;
                Task.Run(async () =>
                {
                    await _signalRClient.UpdateSessionId(ServerConnections[0].ClientUserSessionData.SessionGuid);
                });
            }
            else
            {
                if (UserSessionToken?.UserData != null)
                {
                    ServerConnections[0].ClientUserSessionData.CurrentEntityId = UserSessionToken.CurrentEntityId;
                    ServerConnections[0].ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                    if (CurrentSite != null)
                        ServerConnections[0].ClientUserSessionData.CurrentSiteId = CurrentSite.SiteUid;
                    else
                        ServerConnections[0].ClientUserSessionData.CurrentSiteId = Guid.Empty;
                    if (_signalRClient.ConnectionState == ConnectionState.Disconnected)
                    {
                        Task.Run(async () => { await ConnectToSignalRHub(); });
                    }
                    else
                    {
                        Task.Run(async () =>
                        {
                            await _signalRClient.UpdateSessionId(ServerConnections[0].ClientUserSessionData
                                .SessionGuid);
                            if (UserSessionToken?.SessionId != Guid.Empty)
                                foreach (var e in UserSessionToken.UserData?.Entities)
                                {
                                    await _signalRClient.JoinGroup(e.EntityId.ToString());
                                }
                        });
                    }
                }
            }
        }

        public Guid CurrentEntityId
        {
            get
            {
                if (UserSessionToken == null)
                    return Guid.Empty;
                return UserSessionToken.CurrentEntityId;
            }
            internal set
            {
                if (UserSessionToken != null)
                    UserSessionToken.CurrentEntityId = value;
            }
        }

        public string EntityAlias { get; set; }

        public string EntityAliasPlural { get; set; }

        public int ThumbnailPixelWidth { get; set; }

        public Site CurrentSite
        {
            get { return _currentSite; }
            set
            {
                if (_currentSite != value)
                {
                    _currentSite = value;
                    OnPropertyChanged(() => CurrentSite, false);
                    if (CurrentSite != null)
                        ServerConnections[0].ClientUserSessionData.CurrentSiteId = CurrentSite.SiteUid;
                    else
                        ServerConnections[0].ClientUserSessionData.CurrentSiteId = Guid.Empty;
                }
            }
        }

        public ListCollectionView CurrentEntitySites { get; set; }

        public int DefaultGridPageSize
        {
            get { return _DefaultGridPageSize; }
            set
            {
                if (_DefaultGridPageSize != value)
                {
                    _DefaultGridPageSize = value;
                    OnPropertyChanged(() => DefaultGridPageSize, false);
                }
            }
        }

        public ArrayResponse<gcsEntityEx> EntityList { get; set; }

        //private Guid _currentRegionUid;

        //public Guid CurrentRegionUid
        //{
        //    get { return _currentRegionUid; }
        //    set
        //    {
        //        if (_currentRegionUid != value)
        //        {
        //            _currentRegionUid = value;
        //            OnPropertyChanged(() => CurrentRegionUid, false);
        //        }
        //    }
        //}

        public string BingKey { get { return "AsRIgRiC584CyFr72MvQUy7gdt09pbee3UX3Q5vJ08_NAJW3rBDUON07HpHH_XK_"; } }
        public AssemblyAttributes MyAssemblyAttributes { get; set; }

        public gcsApplication ThisApplication { get; internal set; }

        public bool IsApplicationValidatedWithServer
        {
            get
            {
                if (_applicationManager == null)
                    return false;
                return _applicationManager.IsMyApplicationValidatedWithServer;
            }
        }

        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        public Boolean IsLicenseValid
        {
            get { return _isLicenseValid; }
            internal set { _isLicenseValid = value; }
        }

        public LicenseData MyLicense
        {
            get { return _license; }
        }

        public gcsSystem SystemData
        {
            get { return _systemData; }
        }

        public String LicensedCustomerName
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.LicensedCustomerName;
            }
        }

        public String LicensedCustomerCompany
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.LicensedCustomerCompany;
            }
        }

        public String LicensedCustomerEmail
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.LicensedCustomerEmail;
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                if (_license == null)
                    return DateTimeOffset.MinValue;
                return _license.LicenseExpiration;
            }
        }

        public LicenseType LicenseType
        {
            get
            {
                if (_license == null)
                    return LicenseType.Trial;
                return _license.LicenseType;
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                if (_license == null)
                    return LocalReources.Resources.LicenseTypeNone;
                switch (LicenseType)
                {
                    case LicenseType.Standard:
                        return LocalReources.Resources.LicenseTypeStandard;
                    case LicenseType.Trial:
                        return LocalReources.Resources.LicenseTypeTrial;
                }
                return LocalReources.Resources.LicenseTypeNone;
            }
        }

        public Guid LicenseId
        {
            get
            {
                if (_license == null)
                    return Guid.Empty;
                return _license.LicenseId;
            }
        }

        public IEnumerable<IValidationFailure> LicenseValidationFailures
        {
            get { return _licenseValidationFailures; }
            internal set { _licenseValidationFailures = value; }
        }

        public IEnumerable<CustomError> InitializeSystemDatabaseErrors { get; internal set; }
        public IEnumerable<CustomError> ApplicationManagerErrors { get; internal set; }
        public IMapper Mapper { get; internal set; }
        #endregion

        #region Public methods

        public void Initialize(GalaxySiteServerConnection serverConnection, AssemblyAttributes assemblyAttributes)
        {
            this.MyAssemblyAttributes = assemblyAttributes;
            this.ServerConnections.Add(serverConnection);

            _applicationManager = GetManager<ApplicationManager>();
            _initializeSystemDatabaseManager = GetManager<InitializeSystemDatabaseManager>();

            _license = new LicenseData();
        }

        public void ChangeCulture(string culture, string uiCulture)
        {
            foreach (var o in this.ServerConnections)
            {
                o.ClientUserSessionData.Culture = culture;
                o.ClientUserSessionData.UiCulture = uiCulture;
            }
        }

        public T GetManager<T>() where T : ManagerBase, new()
        {
            var serverConnection = this.ServerConnections[0];
            var sessionHeader = serverConnection.ClientUserSessionData;
            var manager = Helpers.GetManager<T>(serverConnection.ConnectionSettings.ServerAddress,
                GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, sessionHeader);
            return manager;
        }

        public bool LoadLicense(string publicKey, string licenseFilename, bool bUseLocalLicenseFile)
        {
            try
            {

                var systemMgr = this.GetManager<SystemManager>();

                Task.Run(async () =>
                {
                    _systemData = await systemMgr.GetSystemAsync(SystemIds.GalaxySMS_System_Id);
                }).Wait();

                IEnumerable<IValidationFailure> validationFailures = null;

                if (bUseLocalLicenseFile)
                {
                    if (File.Exists(licenseFilename) == false)
                    {
                        CustomErrors.Add(new CustomError(string.Format(LocalReources.Resources.LicenseFileDoesNotExist, licenseFilename)));
                        return false;
                    }
                    MyLicense.LoadFromFile(publicKey, licenseFilename);
                    validationFailures = _license.License.Validate()
                        .IsLicensedTo(CustomerName.Trim(), CustomerEmail.Trim())
                        .And()
                        .Signature(publicKey)
                        .AssertValidLicense();
                    _licenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();
                    foreach (var validationFailure in _licenseValidationFailures)
                    {
                        CustomErrors.Add(new CustomError(string.Format("{0}: {1}", validationFailure.Message, validationFailure.HowToResolve)));
                    }

                    if (!_licenseValidationFailures.Any())
                        IsLicenseValid = true;
                    else
                        IsLicenseValid = false;

                }
                else
                {
                    if (SystemData != null)
                        MyLicense.InitializeFromXmlString(SystemData.PublicKey, SystemData.License);
                    IsLicenseValid = MyLicense.IsLicenseValid;

                    validationFailures = MyLicense.LicenseValidationFailures;
                    _licenseValidationFailures = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();
                    foreach (var validationFailure in _licenseValidationFailures)
                    {
                        CustomErrors.Add(new CustomError(string.Format("{0}: {1}", validationFailure.Message, validationFailure.HowToResolve)));
                    }

                }


                //if (File.Exists(licenseFilename) == false)
                //{
                //    CustomErrors.Add(new CustomError(string.Format(LocalReources.Resources.LicenseFileDoesNotExist, licenseFilename)));
                //    return false;
                //}

                //using (var streamReader = new StreamReader(licenseFilename))
                //{
                //    _license.LoadFromFile(publicKey, licenseFilename);
                //}



            }
            catch (Exception ex)
            {
                CustomErrors.Add(new CustomError(ex.Message));
            }
            return IsLicenseValid;
        }

        public InitializeSystemDatabaseRequest GetDefaultRequestData()
        {
            return _initializeSystemDatabaseManager.GetDefaultRequestData();
        }

        public async Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest requestData)
        {
            bool bRet = await _initializeSystemDatabaseManager.InitializeSystemDatabaseAsync(requestData);
            InitializeSystemDatabaseErrors = _initializeSystemDatabaseManager.Errors;
            return bRet;
        }

        public async Task<gcsApplication> ValidateMyApplicationWithServerAsync(bool bCreate)
        {
            ThisApplication = await _applicationManager.ValidateMyApplicationWithServerAsync(bCreate);
            ApplicationManagerErrors = _applicationManager.Errors;
            return ThisApplication;
        }

        public ReadOnlyCollection<Region> GetRegions()
        {
            var parameters = new GetParametersWithPhoto();
            var regionManager = GetManager<RegionManager>();
            ReadOnlyCollection<Region> regions = null;
            Task.Run(() => { regions = regionManager.GetRegions(parameters, false); }).Wait();
            return regions;
        }

        public ReadOnlyCollection<Country> GetCountries(bool bIncludeStatesProvinces)
        {
            var parameters = new GetParametersWithPhoto();
            parameters.IncludeMemberCollections = bIncludeStatesProvinces;
            var countryManager = GetManager<CountryManager>();
            ReadOnlyCollection<Country> countries = null;
            Task.Run(() => { countries = countryManager.GetAllCountries(parameters); }).Wait();
            return countries;
        }

        public async Task<ReadOnlyCollection<Country>> GetCountriesAsync(bool bIncludeStatesProvinces)
        {
            var parameters = new GetParametersWithPhoto();
            parameters.IncludeMemberCollections = bIncludeStatesProvinces;
            var countryManager = GetManager<CountryManager>();
            var countries = await countryManager.GetAllCountriesAsync(parameters);
            return countries;
        }

        public ReadOnlyCollection<StateProvince> GetStatesProvincesForCountry(Country country)
        {
            var parameters = new GetParametersWithPhoto();
            parameters.UniqueId = country.CountryUid;
            var manager = GetManager<StateProvinceManager>();
            ReadOnlyCollection<StateProvince> countries = null;
            Task.Run(() => { countries = manager.GetStatesProvincesForCountry(parameters, true); }).Wait();
            return countries;
        }

        public async Task<ReadOnlyCollection<StateProvince>> GetStatesProvincesForCountryAsync(Country country)
        {
            var parameters = new GetParametersWithPhoto();
            parameters.UniqueId = country.CountryUid;
            var manager = GetManager<StateProvinceManager>();
            ReadOnlyCollection<StateProvince> sp = await manager.GetStatesProvincesForCountryAsync(parameters);
            return sp;
        }

        public ReadOnlyCollection<Client.Entities.TimeZone> GetTimeZones()
        {
            var tzs = TimeZoneInfo.GetSystemTimeZones();
            var timeZones = new List<Client.Entities.TimeZone>();
            foreach (var tz in tzs)
            {
                timeZones.Add(new Client.Entities.TimeZone(tz));
            }
            return new ReadOnlyCollection<Client.Entities.TimeZone>(timeZones);
        }

        public ReadOnlyCollection<StringIntPair> GetAccessRuleOverrideTimeoutValues()
        {
            var values = new List<StringIntPair>();

            values.Add(new StringIntPair(string.Format(GalaxySMS.Resources.Resources.ClusterAccessRuleOverride_Disabled),
                (0)));

            for (short seconds = 0; seconds < 10; seconds++)
            {
                for (short tenths = 0; tenths < 10; tenths++)
                {
                    if (seconds + tenths != 0)
                    {
                        values.Add(new StringIntPair(string.Format(GalaxySMS.Resources.Resources.ClusterAccessRuleOverrideTimeout_Format, seconds, tenths),
                            ((seconds * 100) + tenths * 10)));
                    }
                }
            }
            return new ReadOnlyCollection<StringIntPair>(values);
        }

        public ReadOnlyCollection<StringIntPair> GetUnlimitedCredentialTimeoutValues()
        {
            var values = new List<StringIntPair>();

            values.Add(new StringIntPair(string.Format(GalaxySMS.Resources.Resources.UnlimitedCredential_Disabled),
                (0)));

            for (ushort seconds = 0; seconds < 10; seconds++)
            {
                for (ushort tenths = 0; tenths < 10; tenths++)
                {
                    if (seconds + tenths != 0)
                    {
                        values.Add(new StringIntPair(string.Format(GalaxySMS.Resources.Resources.UnlimitedCredentialTimeout_Format, seconds, tenths),
                            ((seconds * 100) + tenths * 10)));
                    }
                }
            }
            return new ReadOnlyCollection<StringIntPair>(values);
        }

        public ICollection<UserEntitySelect> BuildUserEntitiesSelectionList(IHasEntityMappingList item, Guid ownerEntityId)
        {
            if (_userSessionToken != null)
            {
                var userEntitiesSelectList = _userSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in userEntitiesSelectList)
                {
                    if (item.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                    //var mapEntity = item.MappedEntitiesPermissionLevels.FirstOrDefault(m => m.EntityId == ue.EntityId);
                    //if (mapEntity != null)
                    //{
                    //    ue.Selected = true;
                    //    ue.EntityMapPermissionLevelUid = mapEntity.EntityMapPermissionLevelUid;
                    //}
                    ue.IsOwner = (ue.EntityId == ownerEntityId);
                }
                return userEntitiesSelectList;
            }
            return null;
        }



        public async Task<bool> ConnectToSignalRHub()
        {
            try
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
            }
            catch (Exception e)
            {
                this.Log().Error($"ConnectToSignalRHub exception:{e}");
            }

            this.Log().Info($"Not connected to SignalR. _signalRClient.ConnectionState:{_signalRClient.ConnectionState}, SignalRServerUrl:{ServerConnections[0].ConnectionSettings.SignalRServerUrl}");
            return false;
        }

        public async Task RefreshEntityList(bool bIncludePhoto)
        {
            var parameters = new GetParametersWithPhoto()
            {
                IncludePhoto = bIncludePhoto,
                PhotoPixelWidth = this.ThumbnailPixelWidth,
                IncludeMemberCollections = true,
            };
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllApplications));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ChildEntities));
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.gcsEntityApplications));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ParentEntity));

            var mgr = GetManager<EntityManager>();
            EntityList = await mgr.GetAllEntitiesAsync(parameters);
        }

        public async Task<gcsEntity> GetEntity(Guid entityId)
        {
            if (EntityList == null)
                await RefreshEntityList(true);

            var eb = EntityList?.Items?.FirstOrDefault(e => e.EntityId == entityId);
            return eb;
        }
        //public GetParametersWithPhoto CreateGetParametersWithPhoto()
        //{
        //    var parameters = new GetParametersWithPhoto();
        //    parameters.SessionId = CurrentSessionId;
        //    parameters.CurrentEntityId = CurrentEntityId;
        //    parameters.CurrentSiteUId = CurrentSite.SiteUid;
        //    return parameters;
        //}
        public async Task UserEntitiesChanged()
        {
            UpdateServerConnectionsClientUserSessionData();
            Task.Run(() => { RefreshEntitySites(); }).Wait();
        }
        #endregion

    }
}
