using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.SiteManager.Properties;
using GCS.Core.Common;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Licensing.Extensions;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using PDSA.MessageBroker;
using Portable.Licensing.Prime.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using SplashScreen = GalaxySMS.SiteManager.Views.SplashScreen;

namespace GalaxySMS.SiteManager
{
    public class Globals : ViewModelBase
    {
        #region Private Fields
        private static Globals _instance;

        //        private IServiceFactory _ServiceFactory;
        private ObservableCollection<gcsLanguage> _Languages;

        private ObservableCollection<gcsRole> _Roles;
        private ObservableCollection<gcsEntityEx> _Entities;
        private ObservableCollection<gcsApplication> _Applications;
        private ObservableCollection<GalaxySiteServerConnection> _ServerConnections;

        private LanguageManager _languageManger;
        private EntityManager _entityManager;
        private RoleManager _roleManager;
        private ApplicationManager _applicationManager;

        private Portable.Licensing.Prime.License _license;
        private IEnumerable<IValidationFailure> _licenseValidationFailures;
        private bool _isLicenseValid;

        private gcsApplication _thisApplication;
        private Brush _mainWindowBackgroundBrush = Brushes.DarkSlateGray;
        private Timer _endSplashTimer = null;
        private UserSessionToken _userSessionToken;
        private gcsEntity _currentUserEntity;

        #endregion

        [ImportingConstructor]
        private Globals()
        {
            //            _ServiceFactory = ObjectBase.Container.GetExportedValue<IServiceFactory>();
            _ServerConnections = new ObservableCollection<GalaxySiteServerConnection>();
            MessageBroker = new PDSAMessageBroker();

            GalaxySiteServerConnectionSettings serverConnectionSettings = new GalaxySiteServerConnectionSettings();
            serverConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            serverConnectionSettings.ServerName = Settings.Default.ServerAddress;
            serverConnectionSettings.ServerAddress = Settings.Default.ServerAddress;
            serverConnectionSettings.PortNumber = Settings.Default.ServerPort;
            serverConnectionSettings.ApiServerUrl = Settings.Default.ApiServerUrl;
            serverConnectionSettings.SignalRServerUrl = Settings.Default.SignalRServerUrl;

            GalaxySiteServerConnection siteServerConnection = new GalaxySiteServerConnection(serverConnectionSettings);
            _ServerConnections.Add(siteServerConnection);

            _languageManger = new LanguageManager(siteServerConnection);
            _languageManger.GetAllLanguagesCompletedEvent += LanguageManger_OnGetAllLanguagesCompletedEvent;
            _languageManger.ErrorsOccurredEvent += LanguageManger_OnErrorsOccurredEvent;

            _roleManager = new RoleManager(siteServerConnection);
            _roleManager.GetAllRolesCompletedEvent += roleManager_OnGetAllRolesCompletedEvent;
            _roleManager.ErrorsOccurredEvent += roleManager_OnErrorsOccurredEvent;

            _entityManager = new EntityManager(siteServerConnection);
            _entityManager.GetAllEntitesCompletedEvent += _entityManager_GetAllEntitesCompletedEvent;
            _entityManager.ErrorsOccurredEvent += _entityManager_ErrorsOccurredEvent;

            _applicationManager = new ApplicationManager(siteServerConnection);
            _applicationManager.GetAllApplicationsCompletedEvent += applicationManager_OnGetAllApplicationsCompletedEvent;
            _applicationManager.ApplicationValidatedWithServerEvent += _applicationManager_ApplicationValidatedWithServerEvent;
            _applicationManager.ErrorsOccurredEvent += applicationManager_OnErrorsOccurredEvent;

            BackgroundSubduedOpacity = Settings.Default.BackgroundSubduedOpacity;
            if (Settings.Default.BackgroundSubduedBlur == true)
                BackgroundSubduedEffect = new BlurEffect();

            CustomerName = Settings.Default.CustomerName;
            CustomerEmail = Settings.Default.CustomerEmail;

        }

        #region Private Methods

        private void StartSplash()
        {
            Splasher.Splash = new SplashScreen();
            Splasher.Splash.DataContext = this;
            Splasher.ShowSplash();
            MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_Initializing);

        }

        private void EndSplash()
        {
            Splasher.CloseSplash();

        }

        void _applicationManager_ApplicationValidatedWithServerEvent(object sender, ApplicationValidatedWithServerCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.IsValidated == true)
                {
                    ThisApplication = new gcsApplication(e.Application);
                    MainWindowBackgroundBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(Settings.Default.AllGoodBorderColor.ToString()));
                    MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_ApplicationValidatedWithServer);

                    Init();
                    RefreshAll();
                    if (_endSplashTimer == null)
                        _endSplashTimer = new Timer(EndSplashTimer_Tick, null, 1000, Timeout.Infinite);
                }
                else
                {
                    MainWindowBackgroundBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(Settings.Default.NotGoodBorderColor.ToString()));
                    MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_CouldNotValidateApplicationWithServer);
                    if (_endSplashTimer == null)
                        _endSplashTimer = new Timer(EndSplashTimer_Tick, true, 1000, Timeout.Infinite);
                }
            });
        }

        private void EndSplashTimer_Tick(object state)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _endSplashTimer = null;

                EndSplash();
                if (state != null)
                    Application.Current.Shutdown(0);
            });
        }

        private void applicationManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                this.Log().ErrorFormat(error.ToString());
                AddCustomError(error);
            }
        }

        private void applicationManager_OnGetAllApplicationsCompletedEvent(object sender, GetAllApplicationsCompletedEventArgs e)
        {
            //_thisApplication = null;
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Applications = new ObservableCollection<gcsApplication>();
                foreach (gcsApplication application in e.Applications)
                {
                    _Applications.Add(application);
                    //if (application.ApplicationName == App.Current.ToString())
                    //    _thisApplication = application;
                }
                OnPropertyChanged(() => Applications, false);
            });
        }

        private void _entityManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void _entityManager_GetAllEntitesCompletedEvent(object sender, GetAllEntitiesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Entities = new ObservableCollection<gcsEntityEx>();
                foreach (var entity in e.Entities.Items)
                {
                    _Entities.Add(entity);
                }
                OnPropertyChanged(() => Entities, false);
            });
        }

        private void LanguageManger_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void LanguageManger_OnGetAllLanguagesCompletedEvent(object sender, GetAllLanguagesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Languages = new ObservableCollection<gcsLanguage>();
                foreach (gcsLanguage language in e.Languages)
                {
                    _Languages.Add(language);
                }
                OnPropertyChanged(() => Languages, false);
            });
        }

        private void roleManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void roleManager_OnGetAllRolesCompletedEvent(object sender, GetAllRolesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Roles = new ObservableCollection<gcsRole>();
                foreach (gcsRole role in e.Roles)
                {
                    _Roles.Add(role);
                }
                OnPropertyChanged(() => Roles, false);
            });
        }
        #endregion

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

        #region Public Properties
        public PDSAMessageBroker MessageBroker { get; internal set; }

        public ObservableCollection<GalaxySiteServerConnection> ServerConnections
        {
            get { return _ServerConnections; }
        }

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
                Assembly myAssembly = this.
                    GetType().Assembly;
                return SystemUtilities.
                    GetAssemblyAttributes(ref myAssembly);
            }
        }
        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        public Boolean IsLicenseValid
        {
            get { return _isLicenseValid; }
            internal set { _isLicenseValid = value; }
        }

        public Portable.Licensing.Prime.License MyLicense
        {
            get { return _license; }
        }

        public String LicensedCustomerName
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Name;
            }
        }

        public String LicensedCustomerCompany
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Company;
            }
        }

        public String LicensedCustomerEmail
        {
            get
            {
                if (_license == null)
                    return string.Empty;
                return _license.Customer.Email;
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                if (_license == null)
                    return DateTimeOffset.MinValue;
                return _license.Expiration;
            }
        }

        public Portable.Licensing.Prime.LicenseType LicenseType
        {
            get
            {
                if (_license == null)
                    return Portable.Licensing.Prime.LicenseType.Trial;
                return _license.Type;
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                if (_license == null)
                    return Resources.AboutView_LicenseTypeNone;
                switch (LicenseType)
                {
                    case Portable.Licensing.Prime.LicenseType.Standard:
                        return Resources.AboutView_LicenseTypeStandard;
                    case Portable.Licensing.Prime.LicenseType.Trial:
                        return Resources.AboutView_LicenseTypeTrial;
                }
                return Resources.AboutView_LicenseTypeNone;
            }
        }

        public Guid LicenseId
        {
            get
            {
                if (_license == null)
                    return Guid.Empty;
                return _license.Id;
            }
        }

        public IEnumerable<IValidationFailure> LicenseValidationFailures
        {
            get { return _licenseValidationFailures; }
            internal set { _licenseValidationFailures = value; }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _userSessionToken; }
            set
            {
                _userSessionToken = value;
                if (CurrentUserEntities != null)
                {
                    CurrentUserEntity = (from e in CurrentUserEntities
                                         where e.EntityId == UserSessionToken.UserData.PrimaryEntityId
                                         select e).FirstOrDefault();
                }
                else
                {
                    CurrentUserEntity = null;
                }
                foreach (var serverConnection in ServerConnections)
                {
                    if (UserSessionToken == null)
                        serverConnection.ClientUserSessionData.SessionGuid = Guid.Empty;
                    else
                        serverConnection.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                }
                OnPropertyChanged(() => UserSessionToken, false);
                OnPropertyChanged(() => CurrentUserEntities, false);
                OnPropertyChanged(() => IsUserSessionValid, false);
                Instance.MessageBroker.SendMessage(new PDSAMessageBrokerMessage
                {
                    MessageName = MessageNames.UserSessionTokenChanged,
                    MessageBody = UserSessionToken
                });
            }
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


        public gcsEntity CurrentUserEntity
        {
            get { return _currentUserEntity; }
            set
            {
                if (_currentUserEntity != value)
                {
                    _currentUserEntity = value;
                    OnPropertyChanged(() => CurrentUserEntity, false);
                }
            }
        }
        public ObservableCollection<gcsLanguage> Languages
        { get { return _Languages; } }

        public ObservableCollection<gcsRole> Roles
        { get { return _Roles; } }


        public override string CustomErrorsHeaderText
        {
            get
            {
                string ret = string.Empty;

                if (CustomErrors != null)
                {
                    //string verb = (CustomErrors.Count() == 1 ? "is" : "are");
                    //string suffix = (CustomErrors.Count() == 1 ? "" : "s");

                    //ret = string.Format("There {0} {1} error{2}.", verb, CustomErrors.Count(), suffix);
                    ret = string.Format(Resources.CustomMessagesHeader_MessageCount, CustomErrors.Count());
                }

                return ret;
            }
        }


        #endregion

        #region Public methods

        public ObservableCollection<gcsRole> GetRolesForApplication(Guid applicationId)
        {
            return (from r in Roles
                    where r.EntityId == applicationId
                    select r).ToObservableCollection();
        }

        public ObservableCollection<gcsEntityEx> Entities
        { get { return _Entities; } }

        public ObservableCollection<gcsApplication> Applications
        { get { return _Applications; } }

        public gcsApplication ThisApplication
        {
            get
            {
                return _thisApplication;
            }
            internal set
            {
                _thisApplication = value;
                OnPropertyChanged(() => ThisApplication, false);
                OnPropertyChanged(() => IsApplicationValidatedWithServer, false);
            }
        }

        public gcsUserRequirement GetUserRequirementsForEntity(Guid entityId)
        {
            gcsEntity entity = (from e in Entities
                                where e.EntityId == entityId
                                select e).FirstOrDefault();
            if (entity != null)
                return entity.UserRequirements;
            return new gcsUserRequirement();
        }

        public void RefreshAll()
        {
            MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LoadingData);

            bool bUseAsynCallsOriginal = UseAsyncServiceCalls;
            UseAsyncServiceCalls = false;
            Task dTask = Task.Factory.StartNew(() =>
            {
                RefreshEntities();
            });

            Task dTask2 = dTask.ContinueWith((continuation) =>
            {
                RefreshLanguages();
            });
            Task dTask3 = dTask2.ContinueWith((continuation) =>
            {
                RefreshApplications();
            });
            Task dTask4 = dTask3.ContinueWith((continuation) =>
            {
                RefreshRoles();
            });

            // Since a console application otherwise terminates, wait for both tasks to complete.
            Task.WaitAll(new Task[] { dTask, dTask2, dTask3, dTask4 });
            MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_InitializationComplete);

            UseAsyncServiceCalls = bUseAsynCallsOriginal;
        }

        public void RefreshLanguages()
        {
            _Languages = new ObservableCollection<gcsLanguage>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsLanguage> languages = _languageManger.GetAllLanguages();
                foreach (gcsLanguage langauge in languages)
                    _Languages.Add(langauge);
            }
            else
            {
                _languageManger.GetAllLanguagesAsync();
            }
        }

        public void RefreshRoles()
        {
            _Roles = new ObservableCollection<gcsRole>();
            var getParams = new GetParametersWithPhoto()
            {
                IncludeMemberCollections = true
            };

            ArrayResponse<gcsRole> roles = null;

            if (UseAsyncServiceCalls == false)
            {
                roles = _roleManager.GetAllRoles(getParams);
            }
            else
            {
                Task.Run(async () =>
                {
                    roles = await _roleManager.GetAllRolesAsync(getParams);
                }).Wait();
            }
            foreach (gcsRole role in roles.Items)
                _Roles.Add(role);
        }

        public void RefreshEntities()
        {
            _Entities = new ObservableCollection<gcsEntityEx>();
            var parameters = new GetParametersWithPhoto() { IncludeMemberCollections = true };
            if (UseAsyncServiceCalls == false)
            {
                var entities = _entityManager.GetAllEntities(parameters);
                foreach (var entity in entities.Items)
                    _Entities.Add(entity);
            }
            else
            {
                _entityManager.GetAllEntitiesAsync(parameters);
            }
        }

        public void RefreshApplications()
        {
            string thisAppName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);
            string s = App.Current.ToString();
            _Applications = new ObservableCollection<gcsApplication>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsApplication> applications = _applicationManager.GetAllApplications();
                foreach (gcsApplication application in applications)
                {
                    _Applications.Add(application);
                    if (application.ApplicationName == thisAppName)
                        _thisApplication = application;
                }
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

        public bool Init()
        {

            MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LoadingLicense);

            string publicKey = Settings.Default.LicenseKey;
            //int pkLen = publicKey.Length;
            string myProcessName = SystemUtilities.MyProcessName;
            if (myProcessName.EndsWith(".vshost"))
                myProcessName = myProcessName.Replace(".vshost", string.Empty);
            string licenseFilename = string.Format("{0}\\{1}.license",
                SystemUtilities.MyFolderLocation,
                myProcessName);

            LoadLicense(publicKey, licenseFilename);

            if (IsLicenseValid == true)
                MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LicenseLoadedAndValidated);
            else
                MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LicenseInvalid);

            return true;
        }

        public void ValidateThisApplicationWithServer(bool bCreate)
        {
            StartSplash();
            MessageListener.Instance.ReceiveMessage(string.Format(Resources.SplashScreen_ValidatingApplicationWithServer, Settings.Default.ServerAddress));

            var initializeSystemDatabaseManager = new InitializeSystemDatabaseManager(Instance.ServerConnections[0]);
            initializeSystemDatabaseManager.ErrorsOccurredEvent += initializeSystemDatabaseManager_OnErrorsOccurredEvent;
            var requestData = initializeSystemDatabaseManager.GetDefaultRequestData();

            AssemblyAttributes assemblyAttributes = SystemUtilities.GetEntryAssemblyAttributes();

            var language = new gcsLanguage()
            {
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                LanguageName = Resources.LanguageName_enUS,
                CultureName = "en-US",
                Description = Resources.LanguageDescription_enUS,
                Notes = Resources.LanguageNotes_enUS,
                IsActive = true,
                IsDefault = true,
                IsDisplay = true
            };

            requestData.Languages.Add(language);

            var entity = new gcsEntity()
            {
                EntityId = EntityIds.GalaxySMS_DefaultEntity_Id,
                EntityName = Resources.DefaultEntityName,
                EntityDescription = Resources.DefaultEntityDescription,
                EntityKey = Resources.DefaultEntityKey,
                IsDefault = true,
                IsActive = true,
                IsAuthorized = true
            };
            requestData.Entities.Add(entity);

            var application = new gcsApplication()
            {
                ApplicationId = assemblyAttributes.Guid,
                ApplicationName = assemblyAttributes.Product,
                ApplicationDescription = assemblyAttributes.Description,
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                //SystemRoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId,
                IsAuthorized = true
            };

            requestData.Applications.Add(application);

            var user = new gcsUser()
            {
                UserId = UserIds.GalaxySMS_Administrator_Id,
                LanguageId = application.LanguageId,
                FirstName = Resources.DefaultUserFirstName,
                LastName = Resources.DefaultUserLastName,
                Email = Resources.DefaultUserEmail,
                UserName = Resources.DefaultUserLoginName,
                DisplayName = Resources.DefaultUserDisplayName,
                UserPassword = Crypto.EncryptString(Resources.DefaultUserPassword, UserIds.GalaxySMS_Administrator_Id.ToString()),
                IsLockedOut = false,
                IsActive = true,
                ResetPasswordFlag = true,
                ImportedFromActiveDirectory = false,
                PrimaryEntityId = EntityIds.GalaxySMS_DefaultEntity_Id
            };

            var e = new gcsEntity(entity);
            var a = new gcsApplication(application);
            //e.AllApplications.Add(a);
            user.AllEntities.Add(e);

            requestData.Users.Add(user);

            initializeSystemDatabaseManager.InitializeSystemDatabaseCompletedEvent += initializeSystemDatabaseManager_InitializeSystemDatabasCompletedEvent;
            initializeSystemDatabaseManager.InitializeSystemDatabaseAsyncWithEvents(requestData);

        }

        private void initializeSystemDatabaseManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs errorsOccurredEventArgs)
        {
            foreach (CustomError error in errorsOccurredEventArgs.Errors)
            {
                this.Log().ErrorFormat(error.ToString());
                AddCustomError(error);
            }
        }

        void initializeSystemDatabaseManager_InitializeSystemDatabasCompletedEvent(object sender, InitializeSystemDatabaseCompletedEventArgs e)
        {
            //var systemRole = new gcsRole();
            //systemRole.RoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId;
            //systemRole.RoleName = Resources.SystemRole_RoleName;
            //systemRole.RoleDescription = Resources.SystemRole_RoleDescription;
            //systemRole.IsActive = true;
            if (UseAsyncServiceCalls == false)
            {
                ThisApplication = _applicationManager.ValidateMyApplicationWithServer(true/*, systemRole*/);

            }
            else
            {
                _applicationManager.ValidateMyApplicationWithServerAsyncWithEvents(true/*, systemRole*/);
            }
        }
        private string LoadPublicKeyFile(string filename)
        {
            string sReturn = string.Empty;
            using (var streamReader = new StreamReader(filename))
            {
                sReturn = streamReader.ReadToEnd();
            }
            return sReturn;
        }

        public bool LoadLicense(string publicKey, string licenseFilename)
        {
            try
            {
                if (File.Exists(licenseFilename) == false)
                {
                    CustomErrors.Add(new CustomError(string.Format(Resources.LicenseFileDoesNotExist, licenseFilename)));
                    return false;
                }

                using (var streamReader = new StreamReader(licenseFilename))
                {
                    _license = Portable.Licensing.Prime.License.Load(streamReader);
                }

                var validationFailures = _license.Validate()
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
            catch (Exception ex)
            {
                CustomErrors.Add(new CustomError(ex.Message));
            }
            return IsLicenseValid;
        }

        public Brush MainWindowBackgroundBrush
        {
            get { return _mainWindowBackgroundBrush; }
            set
            {
                _mainWindowBackgroundBrush = value;
                OnPropertyChanged(() => MainWindowBackgroundBrush, false);
            }
        }

        #endregion

    }
}