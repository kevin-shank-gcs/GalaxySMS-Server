using GalaxySMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Core;
using System.Windows.Data;
using SystemGalaxyDataImporter.Entities;
using SystemGalaxyDataImporter.Properties;
using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common.Logger;

namespace SystemGalaxyDataImporter
{
    public class Globals : ViewModelBase
    {
        #region Private fields
        private static Globals _instance;
        private UserSignInResult _signInResult;
        private UserEntity _currentUserEntity;
        private ListCollectionView _currentEntitySites;
        private Site _currentSite;
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
            };

            ServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);

            SystemGalaxyConnectionData = new SystemGalaxyConnectionData()
            {
                WebApiUrl = Properties.Settings.Default.SGApiUrl,
                UserName = Settings.Default.SGUserName,
                Password = Settings.Default.SGPassword
            };

            GalaxySMSConnectionData = new GalaxySMSConnectionData()
            {
                UserName = Properties.Settings.Default.GalaxySMSUserName,
                Password = Settings.Default.GalaxySMSPassword
            };

            SystemGalaxyData = new SystemGalaxyData();
            //// Specify the ApplicationId that this will be used for, if it is not GalaxySMS_Admin_Id, which is the default
            //siteServerConnection.ClientUserSessionData.ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_Admin_Id;
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
        private SystemGalaxyConnectionData _systemGalaxyConnectionData;

        public SystemGalaxyConnectionData SystemGalaxyConnectionData
        {
            get { return _systemGalaxyConnectionData; }
            set
            {
                if (_systemGalaxyConnectionData != value)
                {
                    _systemGalaxyConnectionData = value;
                    OnPropertyChanged(() => SystemGalaxyConnectionData, true);
                }
            }
        }

        private GalaxySMSConnectionData _galaxySMSConnectionData;

        public GalaxySMSConnectionData GalaxySMSConnectionData
        {
            get { return _galaxySMSConnectionData; }
            set
            {
                if (_galaxySMSConnectionData != value)
                {
                    _galaxySMSConnectionData = value;
                    OnPropertyChanged(() => GalaxySMSConnectionData, true);
                }
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
                        this.Log().Info($"CurrentUserEntity changed to: {CurrentUserEntity.EntityName}");
                    }
                    else
                    {
                        ServerConnection.ClientUserSessionData.CurrentEntityId = Guid.Empty;
                        this.Log().Info($"CurrentUserEntity changed to: null");
                    }
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
                    UpdateServerConnectionsClientUserSessionData();

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

        public SystemGalaxyData SystemGalaxyData { get; set; }
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
            CurrentEntitySites = new ListCollectionView(sites.ToList());
            CurrentEntitySites?.GroupDescriptions?.Add(new PropertyGroupDescription("RegionName"));
            CurrentSite = sites.FirstOrDefault();
            if (siteManager.HasErrors)
            {
                base.AddCustomErrors(siteManager.Errors, true);
            }
        }

        private void UpdateServerConnectionsClientUserSessionData()
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
            }
        }


        #endregion
    }
}
