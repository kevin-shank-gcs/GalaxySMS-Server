using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.FacilityManager.Themes;
using GalaxySMS.FacilityManager.Views;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GalaxySMS.TelerikWPF.Infrastructure;
using GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using Prism.Events;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.RibbonView;
using Prism6Regions = Prism.Regions;
using SplashScreen = GalaxySMS.FacilityManager.Views.SplashScreen;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using LocalResources = GalaxySMS.FacilityManager.Properties;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.FacilityManager.ViewModels
{
    [Export(typeof(MainWindowViewModel))]
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
            LoadLayoutCommand = new global::Prism.Commands.DelegateCommand<object>(LoadLayout);
            SaveLayoutCommand = new global::Prism.Commands.DelegateCommand<object>(SaveLayout);
            OpenHelpPageCommand = new global::Prism.Commands.DelegateCommand<object>(ExecuteOpenHelpPage);
            RadPaneClosedCommand = new global::Prism.Commands.DelegateCommand<StateChangeEventArgs>(RadPaneClosed);

            _eventAggregator.GetEvent<PubSubEvent<UserSignedInOutEvent>>()
                .Subscribe(UserSignedInOut, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<InitializeApplicationEvent>>()
                .Subscribe(InitializeApplication, ThreadOption.UIThread);
            eventAggregator.GetEvent<NavigateToEvent>().Subscribe(this.Navigate, ThreadOption.PublisherThread);


            showBusyIndactorAction = () =>
            {
                isLoadingModule = false;
                // we want to show indeterminate indication after first load
                BusyIndicatorIsIndeterminate = true;
            };

            _eventAggregator.GetEvent<PubSubEvent<StateChangeEventArgs>>()
                .Subscribe(RadPaneClosed, ThreadOption.UIThread);

            SwitchContentRegionViewCommand = new global::Prism.Commands.DelegateCommand<string>(SwitchContentRegionView);

            ShowSettingsPanelCommand = new global::Prism.Commands.DelegateCommand<bool?>(ShowSettingsPanel,
                canExecute => canExecuteShowSettingsPanelCommand);
            CurrentViewName = "DashboardView";

            CreateUserImageFromResourceImage();
            _eventAggregator.GetEvent<PubSubEvent<InitializeApplicationEvent>>()
                .Publish(new InitializeApplicationEvent());
            Panes = new ObservableCollection<IPaneViewModel>();
            GenerateRibbonTabs();
            this.SelectedTab = this.RibbonTabs[0];
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
        private void GenerateRibbonTabs()
        {
            _ribbonTabs = new ObservableCollection<RibbonTabViewModel>();

            var homeTab = new RibbonTabViewModel();
            homeTab.Text = LocalResources.Resources.RibbonTabHome_Header;
            homeTab.Groups.Add(GetUserRibbonGroup());
            _ribbonTabs.Add(homeTab);

            if (IsUserSessionValid)
            {
                var hardwareDevicesTab = new RibbonTabViewModel();
                hardwareDevicesTab.Text = LocalResources.Resources.RibbonTabHardwareDevices_Header;

                var settingsTab = new RibbonTabViewModel();
                settingsTab.Text = LocalResources.Resources.RibbonTabSettings_Header;

                _ribbonTabs.Add(hardwareDevicesTab);
                _ribbonTabs.Add(settingsTab);
            }
        }

        private const string format = "/GalaxySMS.FacilityManager;component/Images/{0}";

        private string GetPath(string fileName)
        {
            string icon = string.Format(format, fileName);

            return icon;
        }

        private GroupViewModel GetUserRibbonGroup()
        {
            GroupViewModel userGroup = new GroupViewModel();
            userGroup.Text = LocalResources.Resources.RibbonTabGroup_User;
            if (IsUserSessionValid)
            {
            }
            return userGroup;
        }

        private void StartSplash()
        {
            Splasher.Splash = new SplashScreen();
            Splasher.Splash.DataContext = this;
            Splasher.ShowSplash();
            MessageListener.Instance.ReceiveMessage(LocalResources.Resources.SplashScreen_Initializing);
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
            MessageListener.Instance.ReceiveMessage(LocalResources.Resources.SplashScreen_LoadingLicense);
            BackgroundSubduedOpacity = LocalResources.Settings.Default.BackgroundSubduedOpacity;
            if (LocalResources.Settings.Default.BackgroundSubduedBlur)
                BackgroundSubduedEffect = new BlurEffect();

            CustomerName = LocalResources.Settings.Default.CustomerName;
            _clientServices.CustomerEmail = LocalResources.Settings.Default.CustomerEmail;

            var publicKey = LocalResources.Settings.Default.LicenseKey1;
            //int pkLen = publicKey.Length;
            var myProcessName = SystemUtilities.MyProcessName;
            if (myProcessName.EndsWith(".vshost"))
                myProcessName = myProcessName.Replace(".vshost", string.Empty);
            var licenseFilename = string.Format("{0}\\{1}.license",
                SystemUtilities.MyFolderLocation,
                myProcessName);

            _clientServices.LoadLicense(publicKey, licenseFilename, false);

            if (_clientServices.IsLicenseValid)
                MessageListener.Instance.ReceiveMessage(LocalResources.Resources.SplashScreen_LicenseLoadedAndValidated);
            else
                MessageListener.Instance.ReceiveMessage(LocalResources.Resources.SplashScreen_LicenseInvalid);

            return true;
        }

        private InitializeSystemDatabaseRequest CreateInitializeSystemDatabaseRequestData()
        {
            var requestData = _clientServices.GetDefaultRequestData();
            return requestData;
        }

        private async void InitializeApplication(InitializeApplicationEvent obj)
        {
            StartSplash();
            var s = string.Format(
                LocalResources.Resources.SplashScreen_ValidatingApplicationWithServer, LocalResources.Settings.Default.ServerAddress);

            MessageListener.Instance.ReceiveMessage(s);

            var requestData = CreateInitializeSystemDatabaseRequestData();

            var bResult = await _clientServices.InitializeSystemDatabaseAsync(requestData);

            if (bResult)
            {
                var thisApplication = await _clientServices.ValidateMyApplicationWithServerAsync(true);
                if (thisApplication == null)
                {
                    MessageListener.Instance.ReceiveMessage(string.Format(LocalResources.Resources.SplashScreen_CouldNotValidateApplicationWithServer, LocalResources.Settings.Default.ServerAddress));
                    foreach (var error in _clientServices.ApplicationManagerErrors)
                    {
                        this.Log().ErrorFormat(error.ToString());
                        AddCustomError(error);
                    }
                }
                else
                {
                    MessageListener.Instance.ReceiveMessage(string.Format(LocalResources.Resources.SplashScreen_ApplicationValidatedWithServer, LocalResources.Settings.Default.ServerAddress));

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
                    GenerateRibbonTabs();

                    if (UserSessionToken.HasPermission(UserSessionToken.UserData.PrimaryEntityId, UserSessionToken.ApplicationId, PermissionIds.CanExecuteIds.GalaxySMS_FacilityManager_CanExecuteId))
                    {
                        GenerateRibbonTabs();
                    }
                    else
                    {
                        MessageBox.Show("Not permitted to run.");
                    }
                    // Load modules here
                    break;
                case UserSignedInOutEvent.SignedInOutAction.SignedOut:
                    sMessage = string.Format("{0} signed out", obj.UserSessionToken.UserData.DisplayName);
                    CreateUserImageFromResourceImage();
                    GenerateRibbonTabs();
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
            bool bContainsRegion = false;
            try
            {
                bContainsRegion = MyRegionManager.Regions.ContainsRegionWithName(navigationPath);
            }
            catch (Exception ex)
            {   // I don't know why this exception occurs, It occurs after the region is initially added, then deleted by closing the pane, then re-opening the pane
                var exceptionType = ex.GetType();
                //bContainsRegion = MyRegionManager.Regions.ContainsRegionWithName(navigationPath);
            }
            try
            {
                if (bContainsRegion == false)
                {
                    var newPane = GetNewDocumentPaneView(navigationPath);
                    MyRegionManager.AddToRegion(RegionNames.ContentRegion, newPane);

                    MyRegionManager.RequestNavigate(navigationPath, navigationPath);
                    //Panes.Add(vm);
                }
                else
                {
                    var region = MyRegionManager.Regions[RegionNames.ContentRegion];
                    var activeView = region.ActiveViews.FirstOrDefault();
                    if (activeView != null)
                        region.Deactivate(activeView);
                    var view = region.Views.FirstOrDefault(p => ((RadPane)p).Header.ToString() == navigationPath);
                    if (view != null)
                    {
                        region.Activate(view);
                    }
                }
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
            }
        }

        public void Navigate(DocumentPaneView pane)
        {
            bool bContainsRegion = false;
            try
            {
                bContainsRegion = MyRegionManager.Regions.ContainsRegionWithName(pane.Uid);
            }
            catch (Exception ex)
            {   // I don't know why this exception occurs, It occurs after the region is initially added, then deleted by closing the pane, then re-opening the pane
                var exceptionType = ex.GetType();
                //bContainsRegion = MyRegionManager.Regions.ContainsRegionWithName(navigationPath);
            }
            try
            {
                if (bContainsRegion == false)
                {
                    MyRegionManager.AddToRegion(RegionNames.ContentRegion, pane);

                    MyRegionManager.RequestNavigate(pane.Uid, pane.Uid);
                    //Panes.Add(vm);
                }
                else
                {
                    var region = MyRegionManager.Regions[RegionNames.ContentRegion];
                    var activeView = region.ActiveViews.FirstOrDefault();
                    if (activeView != null)
                        region.Deactivate(activeView);
                    var view = region.Views.FirstOrDefault(p => ((RadPane)p).Header.ToString() == pane.Uid);
                    if (view != null)
                    {
                        region.Activate(view);
                    }
                }
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
            }
        }

        public DocumentPaneView GetNewDocumentPaneView(string navigationPath)
        {
            var newPane = new DocumentPaneView();
            newPane.SetResourceReference(Control.StyleProperty, "RadPaneStyle");
            RadDocking.SetSerializationTag(newPane, navigationPath);

            //              newPane.DockPosition = DockState.DockedLeft;
            var vm = newPane.DataContext as IPaneViewModel;
            vm.PrismRegionName = navigationPath;
            vm.IsDocument = true;
            //                vm.DockPosition = DockState.FloatingDockable;
            vm.IsActive = true;
            newPane.Header = navigationPath;
            newPane.Name = navigationPath;
            newPane.Uid = navigationPath;
            newPane.PaneHeaderVisibility = Visibility.Visible;
            return newPane;
        }

        //private void Navigate(string navigationPath)
        //{
        //    if (MyRegionManager.Regions.ContainsRegionWithName(navigationPath) == false)
        //    {
        //        var vm = new PaneViewModel(null);
        //        vm.IsDocument = true;
        //        vm.PrismRegionName = navigationPath;
        //        vm.Header = navigationPath;
        //        vm.DockPosition = DockState.DockedTop;
        //        this.Panes.Add(vm);

        //        MyRegionManager.AddToRegion(RegionNames.ContentRegion, vm.Content);

        //        MyRegionManager.RequestNavigate(navigationPath, navigationPath);
        //    }
        //    else
        //    {
        //        var region = MyRegionManager.Regions[navigationPath];
        //        var view = region.GetView(navigationPath);
        //        if (view != null)
        //        {
        //            region.Activate(view);
        //        }
        //    }
        //}

        private void LoadLayout(object o)
        {
            this._eventAggregator.GetEvent<LoadLayoutEvent>().Publish(null);

        }
        private void SaveLayout(object o)
        {
            this._eventAggregator.GetEvent<SaveLayoutEvent>().Publish(null);
        }


        private void RadPaneClosed(StateChangeEventArgs obj)
        {
            try
            {
                var paneCount = obj.Panes.Count();
                if (paneCount > 0)
                {
                    var pane = obj.Panes.FirstOrDefault();
                    if (pane != null)
                    {
                        if (MyRegionManager.Regions.ContainsRegionWithName(pane.Uid))
                        {
                            MyRegionManager.Regions.Remove(pane.Uid);
                            var region = MyRegionManager.Regions[RegionNames.ContentRegion];
                            var view = region.Views.FirstOrDefault(p => ((RadPane)p).Header.ToString() == pane.Uid);
                            if (view != null)
                            {
                                region.Remove(view);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
                LocalResources.Resources.ThemeDisplayName_Expression_Dark, string.Empty));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green,
                LocalResources.Resources.ThemeDisplayName_Green_Dark, GreenPalette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green,
                LocalResources.Resources.ThemeDisplayName_Green_Light, GreenPalette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                LocalResources.Resources.ThemeDisplayName_Office2013_DarkGray, Office2013Palette.ColorVariation.DarkGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                LocalResources.Resources.ThemeDisplayName_Office2013_LightGray, Office2013Palette.ColorVariation.LightGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                LocalResources.Resources.ThemeDisplayName_Office2013_White, Office2013Palette.ColorVariation.White.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlack, LocalResources.Resources.ThemeDisplayName_Office_Black,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlue, LocalResources.Resources.ThemeDisplayName_Office_Blue,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeSilver, LocalResources.Resources.ThemeDisplayName_Office_Silver,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Summer, LocalResources.Resources.ThemeDisplayName_Summer,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Transparent, LocalResources.Resources.ThemeDisplayName_Transparent,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Vista, LocalResources.Resources.ThemeDisplayName_Vista, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_Dark, VisualStudio2013Palette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_Blue, VisualStudio2013Palette.ColorVariation.Blue.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_Light,
                VisualStudio2013Palette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_Green, ThemeVariationNames.Green));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_DarkOlive, ThemeVariationNames.DarkOlive));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_EarthtoneBrown, ThemeVariationNames.EarthtoneBrowns));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2013_DarkGold, ThemeVariationNames.DarkGold));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7, LocalResources.Resources.ThemeDisplayName_Windows7,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, LocalResources.Resources.ThemeDisplayName_Windows8_CoolBlue,
                ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                LocalResources.Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, LocalResources.Resources.ThemeDisplayName_Windows8_DarkBlue,
                ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                LocalResources.Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                LocalResources.Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                LocalResources.Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, LocalResources.Resources.ThemeDisplayName_Windows8_DullBlue,
                ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch,
                LocalResources.Resources.ThemeDisplayName_Windows8Touch, string.Empty));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Crystal,
                LocalResources.Resources.ThemeDisplayName_Crystal, string.Empty));
            foreach (var colorVar in (CrystalPalette.ColorVariation[])Enum.GetValues(typeof(CrystalPalette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Crystal,
                    LocalResources.Resources.ThemeDisplayName_Crystal + $" ({colorVar})", colorVar.ToString()));
            }

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Fluent,
                LocalResources.Resources.ThemeDisplayName_Fluent, string.Empty));
            foreach (var colorVar in (FluentPalette.ColorVariation[])Enum.GetValues(typeof(FluentPalette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Fluent,
                    LocalResources.Resources.ThemeDisplayName_Fluent + $" ({colorVar})", colorVar.ToString()));
            }


            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Material,
                LocalResources.Resources.ThemeDisplayName_Material, string.Empty));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016,
                LocalResources.Resources.ThemeDisplayName_Office2016, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016Touch,
                LocalResources.Resources.ThemeDisplayName_Office2016Touch, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2019,
                LocalResources.Resources.ThemeDisplayName_VisualStudio2019, string.Empty));
            foreach (var colorVar in (VisualStudio2019Palette.ColorVariation[])Enum.GetValues(typeof(VisualStudio2019Palette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2019,
                    LocalResources.Resources.ThemeDisplayName_VisualStudio2019 + $" ({colorVar})", colorVar.ToString()));
            }

            Themes = new ReadOnlyObservableCollection<ThemeNameValuePair>(_themes);

            var defaultTheme = LocalResources.Settings.Default.Theme;
            var defaultThemeVariation = LocalResources.Settings.Default.ThemeVariation;
            var selectedTheme = Themes.FirstOrDefault(o => o.AssemblyName == defaultTheme && o.VariationName == defaultThemeVariation);
            if (selectedTheme != null)
                SelectedTheme = selectedTheme;
            else
            {
                selectedTheme = Themes.FirstOrDefault(o => o.AssemblyName == defaultTheme);
                if (selectedTheme != null)
                    SelectedTheme = selectedTheme;
            }

            if (selectedTheme == null)
            {
                SelectedTheme = Themes.FirstOrDefault();
            }
        }

        private void RefreshLanguages()
        {
            var parameters = new GetParametersWithPhoto();
            var mgr = _clientServices.GetManager<LanguageManager>();
            Languages = mgr.GetAllLanguages();
            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
        }


        private void RefreshEntitySites()
        {
            var parameters = new GetParametersWithPhoto();
            var siteManager = _clientServices.GetManager<SiteManager>();
            var sites = siteManager.GetAllSitesForEntity(parameters);
            CurrentEntitySites = new ListCollectionView(sites.ToList<Client.Entities.Site>());
            CurrentEntitySites?.GroupDescriptions?.Add(new PropertyGroupDescription("RegionName"));

            if (siteManager.HasErrors)
            {
                base.AddCustomErrors(siteManager.Errors, true);
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
                return LocalResources.Resources.User_SignIn;
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

        public ObservableCollection<IPaneViewModel> Panes { get; set; }

        public ICollection<UserEntity> CurrentUserEntities
        {
            get { return UserSessionToken?.UserData?.UserEntities; }
        }

        public ICollection<UserEntity> CurrentUserEntitiesTree
        {
            get; set;
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
                    _eventAggregator.GetEvent<PubSubEvent<ChangeCurrentEntityForSession>>().Publish(new ChangeCurrentEntityForSession(CurrentUserEntity));
                    Task.Run(() => { RefreshEntitySites(); }).Wait();
                }
            }
        }


        public Client.Entities.Site CurrentSite
        {
            get { return _clientServices.CurrentSite; }
            set
            {
                if (_clientServices.CurrentSite != value)
                {
                    _clientServices.CurrentSite = value;
                    OnPropertyChanged(() => CurrentSite, false);
                    _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Publish(new CurrentSiteForSessionChanged(CurrentSite));
                }
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

        public string CurrentModuleName
        {
            get { return currentModuleName; }
            set
            {
                currentModuleName = value;
                OnPropertyChanged(() => CurrentModuleName, false);
            }
        }

        public DateTime CurrentDate
        {
            get { return DateTime.Today; }
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
                    LocalResources.Settings.Default.Theme = _selectedTheme.AssemblyName;
                    LocalResources.Settings.Default.ThemeVariation = _selectedTheme.VariationName;
                    LocalResources.Settings.Default.Save();
                }
            }
        }

        public ReadOnlyCollection<gcsLanguage> Languages { get; internal set; }

        private gcsLanguage _selectedLanguage;

        public gcsLanguage SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(() => SelectedLanguage, false);
                    (Application.Current as App).SwitchCulture(SelectedLanguage.CultureName, SelectedLanguage.CultureName);
                    _clientServices.ChangeCulture(SelectedLanguage.CultureName, SelectedLanguage.CultureName);
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
        public global::Prism.Commands.DelegateCommand<StateChangeEventArgs> RadPaneClosedCommand { get; set; }

        public global::Prism.Commands.DelegateCommand<object> LoadLayoutCommand { get; set; }
        public global::Prism.Commands.DelegateCommand<object> SaveLayoutCommand { get; set; }


        public Prism6Regions.RegionManager MyRegionManager { get; set; }

        public ObservableCollection<RibbonContextualGroupViewModel> ContextualGroups { get; set; }

        public ObservableCollection<RibbonTabViewModel> RibbonTabs
        {
            get { return _ribbonTabs; }
        }

        public ObservableCollection<ButtonViewModel> QuickAccessItems
        {
            get { return _quickAccessItems; }
        }

        public ObservableCollection<ButtonViewModel> ApplicationMenuItems
        {
            get { return _applicationMenuItems; }
        }

        public RibbonTabViewModel SelectedTab
        {
            get { return this._selectedTab; }
            set
            {
                if (this._selectedTab != value)
                {
                    this._selectedTab = value;
                    OnPropertyChanged("SelectedTab");
                }
            }
        }

        [Import] public ApplicationNavigator ApplicationNavigator;

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

        //private readonly InitializeSystemDatabaseManager _initSystemManager;
        private Timer _endSplashTimer;

        private RibbonTabViewModel _selectedTab;
        private ObservableCollection<ButtonViewModel> _applicationMenuItems;
        private ObservableCollection<ButtonViewModel> _quickAccessItems;
        private ObservableCollection<RibbonTabViewModel> _ribbonTabs;

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