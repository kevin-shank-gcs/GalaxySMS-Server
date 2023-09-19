using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.FacilityManager.Properties;
using GalaxySMS.FacilityManager.Themes;
using GalaxySMS.FacilityManager.Views;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using Prism.Events;
using Prism6Regions = Prism.Regions;
using Telerik.Windows.Controls;
using SplashScreen = GalaxySMS.FacilityManager.Views.SplashScreen;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.FacilityManager.ViewModels
{
    [Export(typeof (MainWindowViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Constructors

        [ImportingConstructor]
        public MainWindowViewModel(Prism6Regions.IRegionManager regionManager, IEventAggregator eventAggregator,
            IClientServices clientServices)
        {
            MyRegionManager = regionManager as Prism6Regions.RegionManager;
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            Title = SystemUtilities.GetEntryAssemblyAttributes().Title;

            BuildThemesCollection();

            NavigateCommand = new global::Prism.Commands.DelegateCommand<string>(Navigate);
            OpenHelpPageCommand = new global::Prism.Commands.DelegateCommand<object>(ExecuteOpenHelpPage);

            _eventAggregator.GetEvent<PubSubEvent<UserSignedInOutEvent>>()
                .Subscribe(UserSignedInOut, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<InitializeApplicationEvent>>()
                .Subscribe(InitializeApplication, ThreadOption.UIThread);
            showBusyIndactorAction = () =>
            {
                isLoadingModule = false;
                // we want to show indeterminate indication after first load
                BusyIndicatorIsIndeterminate = true;
            };

            SwitchContentRegionViewCommand = new global::Prism.Commands.DelegateCommand<string>(SwitchContentRegionView);

            ShowSettingsPanelCommand = new global::Prism.Commands.DelegateCommand<bool?>(ShowSettingsPanel,
                canExecute => canExecuteShowSettingsPanelCommand);
            CurrentViewName = "DashboardView";

            CreateUserImageFromResourceImage();
            _eventAggregator.GetEvent<PubSubEvent<InitializeApplicationEvent>>()
                .Publish(new InitializeApplicationEvent());
        }

        #endregion

        #region Private Methods

        //private ObservableCollection<RibbonContextualGroupViewModel> GenerateContextualGroups()
        //{
        //    var groups = new ObservableCollection<RibbonContextualGroupViewModel>();
        //    //for (int i = 0; i < ContextualGroupsCount; i++)
        //    //{
        //    //    var contextualGroup = new RibbonContextualGroupViewModel()
        //    //    {
        //    //        Header = "Contextual Group Header",
        //    //        GroupName = ContextualGroupName,
        //    //        IsActive = true,
        //    //    };
        //    //    groups.Add(contextualGroup);
        //    //}
        //    return groups;
        //}

        //private ObservableCollection<RibbonTabViewModel> GenerateRibbonTabs()
        //{
        //    var tabViewModels = new ObservableCollection<RibbonTabViewModel>();

        //    var tabItemHome = new RibbonTabViewModel
        //    {
        //        Header = Resources.RibbonTabHome_Header,
        //        ContextualGroupName = string.Empty
        //    };
        //    tabViewModels.Add(tabItemHome);

        //    var tabItemSettings = new RibbonTabViewModel
        //    {
        //        Header = Resources.RibbonTabSettings_Header,
        //        ContextualGroupName = string.Empty
        //    };
        //    tabViewModels.Add(tabItemHome);

        //    return tabViewModels;
        //}

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

        private bool Init()
        {
            MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LoadingLicense);
            BackgroundSubduedOpacity = Settings.Default.BackgroundSubduedOpacity;
            if (Settings.Default.BackgroundSubduedBlur)
                BackgroundSubduedEffect = new BlurEffect();

            CustomerName = Settings.Default.CustomerName;
            _clientServices.CustomerEmail = Settings.Default.CustomerEmail;

            var publicKey = Settings.Default.LicenseKey;
            //int pkLen = publicKey.Length;
            var myProcessName = SystemUtilities.MyProcessName;
            if (myProcessName.EndsWith(".vshost"))
                myProcessName = myProcessName.Replace(".vshost", string.Empty);
            var licenseFilename = string.Format("{0}\\{1}.license",
                SystemUtilities.MyFolderLocation,
                myProcessName);

            _clientServices.LoadLicense(publicKey, licenseFilename);

            if (_clientServices.IsLicenseValid)
                MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LicenseLoadedAndValidated);
            else
                MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_LicenseInvalid);

            return true;
        }

        private InitializeSystemDatabaseRequest CreateInitializeSystemDatabaseRequestData()
        {
            var requestData = _clientServices.GetDefaultRequestData();

            var assemblyAttributes = SystemUtilities.GetEntryAssemblyAttributes();

            var language = new gcsLanguage
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

            var entity = new gcsEntity
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

            var application = new gcsApplication
            {
                ApplicationId = assemblyAttributes.Guid,
                ApplicationName = assemblyAttributes.Product,
                ApplicationDescription = assemblyAttributes.Description,
                LanguageId = LanguageIds.GalaxySMS_EN_US_Language_Id,
                SystemRoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId,
                IsAuthorized = true
            };

            var role = new gcsRole
            {
                RoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId,
                ApplicationId = application.ApplicationId,
                RoleName = Resources.SystemRole_RoleName,
                RoleDescription = Resources.SystemRole_RoleDescription,
                IsActive = true,
                IsDefault = false,
                IsAuthorized = true
            };

            application.AllRoles.Add(role);

            application.gcsEntityApplications.Add(new gcsEntityApplication
            {
                EntityId = entity.EntityId,
                ApplicationId = application.ApplicationId
            });


            requestData.Applications.Add(application);

            var user = new gcsUser
            {
                UserId = UserIds.GalaxySMS_Administrator_Id,
                LanguageId = application.LanguageId,
                FirstName = Resources.DefaultUserFirstName,
                LastName = Resources.DefaultUserLastName,
                Email = Resources.DefaultUserEmail,
                UserName = Resources.DefaultUserLoginName,
                DisplayName = Resources.DefaultUserDisplayName,
                UserPassword =
                    Crypto.EncryptString(Resources.DefaultUserPassword, UserIds.GalaxySMS_Administrator_Id.ToString()),
                IsLockedOut = false,
                IsActive = true,
                ResetPasswordFlag = true,
                ImportedFromActiveDirectory = false,
                PrimaryEntityId = EntityIds.GalaxySMS_DefaultEntity_Id
            };

            var e = new gcsEntity(entity);
            var a = new gcsApplication(application);
            e.AllApplications.Add(a);
            user.AllEntities.Add(e);

            requestData.Users.Add(user);

            var auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_ApplicationLaunched;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_ApplicationLaunched;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_ApplicationLaunched;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_ApplicationShutdown;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_ApplicationShutdown;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_ApplicationShutdown;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInRequest;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInRequest;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInRequest;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignOut;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignOut;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignOut;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultSuccess;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultSuccess;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultSuccess;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoNone;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInSuccessInfoNone;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoNone;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId =
                ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire;
            auditType.Description =
                Common.Properties.Resources.ApplicationAudit_UserSignInSuccessInfoUserAccountSoonToExpire;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId =
                ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
            auditType.Description =
                Common.Properties.Resources.ApplicationAudit_UserSignInSuccessInfoPasswordMustBeChanged;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidUserName;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultInvalidUserName;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidUserName;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidPassword;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultInvalidPassword;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidPassword;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsNotActive;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultUserAccountIsNotActive;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsNotActive;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsLockedOut;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultUserAccountIsLockedOut;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsLockedOut;
            requestData.ApplicationAuditTypes.Add(auditType);

            auditType = new gcsApplicationAuditType();
            auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultApplicationNotPermitted;
            auditType.Description = Common.Properties.Resources.ApplicationAudit_UserSignInResultApplicationNotPermitted;
            auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultApplicationNotPermitted;
            requestData.ApplicationAuditTypes.Add(auditType);
            return requestData;
        }

        private async void InitializeApplication(InitializeApplicationEvent obj)
        {
            StartSplash();
            MessageListener.Instance.ReceiveMessage(string.Format(
                Resources.SplashScreen_ValidatingApplicationWithServer, Settings.Default.ServerAddress));

            var requestData = CreateInitializeSystemDatabaseRequestData();

            var bResult = await _clientServices.InitializeSystemDatabaseAsync(requestData);

            if (bResult)
            {
                var systemRole = new gcsRole();
                systemRole.RoleId = ApplicationRoleIds.GalaxySMS_Admin_AdministatorId;
                systemRole.RoleName = Resources.SystemRole_RoleName;
                systemRole.RoleDescription = Resources.SystemRole_RoleDescription;
                systemRole.IsActive = true;
                var thisApplication = await _clientServices.ValidateMyApplicationWithServerAsync(true, systemRole);
                if (thisApplication == null)
                {
                    MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_CouldNotValidateApplicationWithServer);
                    foreach (var error in _clientServices.ApplicationManagerErrors)
                    {
                        this.Log().ErrorFormat(error.ToString());
                        AddCustomError(error);
                    }
                }
                else
                {
                    MessageListener.Instance.ReceiveMessage(Resources.SplashScreen_ApplicationValidatedWithServer);

                    Init();
                }
                if (_endSplashTimer == null)
                    _endSplashTimer = new Timer(EndSplashTimer_Tick, null, 1000, Timeout.Infinite);
            }
        }

        private void CreateUserImageFromResourceImage()
        {
            var uriSource = new Uri(@"/GalaxySMS.FacilityManager;component/Images/user_man.png", UriKind.Relative);
            UserImage = new BitmapImage(uriSource);
        }
        // Load the modules for this person
        private void UserSignedInOut(UserSignedInOutEvent obj)
        {
            var sMessage = string.Empty;
            switch (obj.UserAction)
            {
                case UserSignedInOutEvent.SignedInOutAction.SignedIn:
                    sMessage = string.Format("{0} signed in", obj.UserSessionToken.UserData.DisplayName);
                    if (obj?.UserSessionToken?.UserData?.UserImage != null)
                    {
                        var c = new ImageSourceConverter();
                        var temp = c.ConvertFrom(obj.UserSessionToken.UserData.UserImage);
                        UserImage = temp as ImageSource;
                    }
                    else
                        CreateUserImageFromResourceImage();

                    CurrentUserEntity = (from e in CurrentUserEntities
                                         where e.EntityId == UserSessionToken.UserData.PrimaryEntityId
                                         select e).FirstOrDefault();
                    // Load modules here
                    break;
                case UserSignedInOutEvent.SignedInOutAction.SignedOut:
                    sMessage = string.Format("{0} signed out", obj.UserSessionToken.UserData.DisplayName);
                    CreateUserImageFromResourceImage();
                    // Unload modules here
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            OnPropertyChanged(() => UserButtonText, false);
            OnPropertyChanged(() => CurrentUserEntities, false);
            OnPropertyChanged(() => IsUserSessionValid, false);

            this.Log().InfoFormat(sMessage);
        }

        private void Navigate(string navigationPath)
        {
            //var regionName = RegionNames.ContentRegion;

            var newPane = new NewDocumentView();

            var vm = newPane.DataContext as INewDocumentViewModel;
            vm.PrismRegionName = navigationPath;
            newPane.Header = navigationPath;

            MyRegionManager.AddToRegion(RegionNames.ContentRegion, newPane);



            MyRegionManager.RequestNavigate(navigationPath, navigationPath);
        }



        private void ExecuteOpenHelpPage(object obj)
        {
            var helpWindow = HelpWindow.Instance;
            helpWindow.Show();
            helpWindow.Focus();
        }
        private void BuildThemesCollection()
        {
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.ExpressionDark,
                Resources.ThemeDisplayName_Expression_Dark, string.Empty));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green,
                Resources.ThemeDisplayName_Green_Dark, GreenPalette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green,
                Resources.ThemeDisplayName_Green_Light, GreenPalette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Resources.ThemeDisplayName_Office2013_DarkGray, Office2013Palette.ColorVariation.DarkGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Resources.ThemeDisplayName_Office2013_LightGray, Office2013Palette.ColorVariation.LightGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Resources.ThemeDisplayName_Office2013_White, Office2013Palette.ColorVariation.White.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlack, Resources.ThemeDisplayName_Office_Black,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlue, Resources.ThemeDisplayName_Office_Blue,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeSilver, Resources.ThemeDisplayName_Office_Silver,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Summer, Resources.ThemeDisplayName_Summer,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Transparent, Resources.ThemeDisplayName_Transparent,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Vista, Resources.ThemeDisplayName_Vista, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_Dark, VisualStudio2013Palette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_Blue, VisualStudio2013Palette.ColorVariation.Blue.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_Light,
                VisualStudio2013Palette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_Green, ThemeVariationNames.Green));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_DarkOlive, ThemeVariationNames.DarkOlive));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_EarthtoneBrown, ThemeVariationNames.EarthtoneBrowns));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Resources.ThemeDisplayName_VisualStudio2013_DarkGold, ThemeVariationNames.DarkGold));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7, Resources.ThemeDisplayName_Windows7,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_CoolBlue,
                ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_DarkBlue,
                ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_DullBlue,
                ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch,
                Resources.ThemeDisplayName_Windows8Touch, string.Empty));
            Themes = new ReadOnlyObservableCollection<ThemeNameValuePair>(_themes);

            var defaultTheme = Settings.Default.Theme;
            foreach (var theme in _themes)
            {
                if (theme.AssemblyName == defaultTheme)
                {
                    SelectedTheme = theme;
                    break;
                }
            }
        }
        #endregion

        #region Public Properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(() => Title, false);
                }
            }
        }

        public string CustomerName
        {
            get { return _clientServices?.CustomerName; }
            set
            {
                if (_clientServices?.CustomerName != value)
                {
                    if (_clientServices != null)
                    {
                        _clientServices.CustomerName = value;
                        OnPropertyChanged(() => CustomerName, false);
                    }
                }
            }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
        }

        private ImageSource _userImage;

        public ImageSource UserImage
        {
            get { return _userImage; }
            set
            {
                if (_userImage != value)
                {
                    _userImage = value;
                    OnPropertyChanged(() => UserImage, false);
                }
            }
        }

        public string UserButtonText
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_clientServices?.UserSessionToken?.UserData?.DisplayName))
                    return _clientServices?.UserSessionToken?.UserData?.DisplayName;
                return Resources.User_SignIn;
            }
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

        public ICollection<UserEntity> CurrentUserEntities
        {
            get { return UserSessionToken?.UserData?.UserEntities; }
        }

        private UserEntity _currentUserEntity;

        public UserEntity CurrentUserEntity
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

        public string CurrentModuleName
        {
            get { return currentModuleName; }
            set
            {
                currentModuleName = value;
                OnPropertyChanged(() => CurrentModuleName, false);
            }
        }

        public DateTimeOffset CurrentDate
        {
            get { return DateTimeOffset.Today; }
        }

        public bool IsBusy
        {
            get { return isLoadingData || isLoadingModule; }
        }

        public bool IsLoadingModule
        {
            get { return isLoadingModule; }
            set
            {
                isLoadingModule = value;
                OnPropertyChanged(() => IsBusy, false);
            }
        }

        public bool BusyIndicatorIsIndeterminate
        {
            get { return busyIndicatorIsIndeterminate; }
            set
            {
                busyIndicatorIsIndeterminate = value;
                OnPropertyChanged(() => BusyIndicatorIsIndeterminate, false);
            }
        }

        public int ProgressPercentage
        {
            get { return progressPercentage; }
            set
            {
                progressPercentage = value;
                OnPropertyChanged(() => ProgressPercentage, false);
            }
        }

        public ReadOnlyObservableCollection<ThemeNameValuePair> Themes { get; internal set; }

        public ThemeNameValuePair SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    OnPropertyChanged(() => SelectedTheme, false);
                    (Application.Current as App).SwitchTheme(_selectedTheme);
                    Settings.Default.Theme = _selectedTheme.AssemblyName;
                    Settings.Default.ThemeVariation = _selectedTheme.VariationName;
                    Settings.Default.Save();
                }
            }
        }

        public ICommand SwitchContentRegionViewCommand { get; }
        public ICommand ShowSettingsPanelCommand { get; }

        public bool IsLoadingData
        {
            get { return isLoadingData; }
            set
            {
                isLoadingData = value;
                OnPropertyChanged(() => IsBusy, false);
            }
        }

        public string CurrentViewName
        {
            get { return currentViewName; }
            set
            {
                if (currentViewName == value)
                {
                    return;
                }

                currentViewName = value;
                OnPropertyChanged(() => CurrentViewName, false);
            }
        }

        public global::Prism.Commands.DelegateCommand<string> NavigateCommand { get; set; }
        public global::Prism.Commands.DelegateCommand<object> OpenHelpPageCommand { get; set; }

        public Prism6Regions.RegionManager MyRegionManager { get; set; }

        public ObservableCollection<RibbonContextualGroupViewModel> ContextualGroups { get; set; }

        public ObservableCollection<RibbonTabViewModel> Tabs { get; set; }

        [Import]
        public ApplicationNavigator ApplicationNavigator;


        #endregion

        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private readonly Action showBusyIndactorAction;

        private bool busyIndicatorIsIndeterminate;
        private string currentViewName;
        private string currentModuleName;
        private int progressPercentage;
        private bool isLoadingData;
        private bool isLoadingModule;
        private bool isSettingsPanelShown;

        private bool isInitialLoading = true;
        private bool canExecuteShowSettingsPanelCommand = true;
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private string _title = "Prism MEF Application";

        private readonly ObservableCollection<ThemeNameValuePair> _themes =
            new ObservableCollection<ThemeNameValuePair>();

        private ThemeNameValuePair _selectedTheme;

        private readonly InitializeSystemDatabaseManager _initSystemManager;
        private Timer _endSplashTimer;
        //private const int TabsCount = 5;
        //private const int ContextualGroupsCount = 1;
        //private const string ContextualGroupName = "ContextualGroup1";

        #endregion

        #region Public Methods

        public void SwitchContentRegionView(string moduleName)
        {
            CurrentModuleName = moduleName;

            isLoadingModule = true;
            ApplicationNavigator.NavigateToModule(moduleName,
                progress => { ProgressPercentage = progress; },
                showBusyIndactorAction);
        }

        public void ShowSettingsPanel(bool? parameter)
        {
            var shouldShow = parameter ?? isSettingsPanelShown;
            if (shouldShow)
            {
                MyRegionManager.RequestNavigate(RegionNames.SubHeader, "SettingsView");
            }
            else
            {
                var region = MyRegionManager.Regions[RegionNames.SubHeader];
                foreach (var view in region.ActiveViews)
                {
                    var settingsView = view as SettingsView;
                    if (view != null)
                    {
                        settingsView.PlayUnloadAnimation(region);
                    }
                }
            }

            isSettingsPanelShown = !isSettingsPanelShown;

            if (!isInitialLoading)
            {
                canExecuteShowSettingsPanelCommand = false;
                (ShowSettingsPanelCommand as global::Prism.Commands.DelegateCommand<bool?>).RaiseCanExecuteChanged();
                timer.Start();
            }
            else
            {
                isInitialLoading = false;
            }
        }
        #endregion

    }
}