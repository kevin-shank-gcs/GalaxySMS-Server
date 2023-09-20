using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Admin.Themes;
using GalaxySMS.Admin.Views;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.UI.ViewModels;
using GalaxySMS.Client.UI.Views;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using GCS.Framework.Imaging.Helpers;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using PDSA.MessageBroker;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using SharedResources = GalaxySMS.Resources;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;


namespace GalaxySMS.Admin.ViewModels
{
    //public class PauseAndExecuter
    //{
    //    public async void Execute(Action action, int timeoutInMilliseconds)
    //    {
    //        await Task.Delay(timeoutInMilliseconds);
    //        action();
    //    }
    //}


    //public class ScheduledTask
    //{
    //    internal readonly Action Action;
    //    internal System.Timers.Timer Timer;
    //    internal EventHandler TaskComplete;

    //    public ScheduledTask(Action action, int timeoutMs)
    //    {
    //        Action = action;
    //        Timer = new System.Timers.Timer() { Interval = timeoutMs };
    //        Timer.Elapsed += TimerElapsed;
    //    }

    //    private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    //    {
    //        Timer.Stop();
    //        Timer.Elapsed -= TimerElapsed;
    //        Timer = null;

    //        Action();
    //        TaskComplete(this, EventArgs.Empty);
    //    }
    //}

    //public class Scheduler
    //{
    //    private readonly ConcurrentDictionary<Action, ScheduledTask> _scheduledTasks = new ConcurrentDictionary<Action, ScheduledTask>();

    //    public void Execute(Action action, int timeoutMs)
    //    {
    //        var task = new ScheduledTask(action, timeoutMs);
    //        task.TaskComplete += RemoveTask;
    //        _scheduledTasks.TryAdd(action, task);
    //        task.Timer.Start();
    //    }

    //    private void RemoveTask(object sender, EventArgs e)
    //    {
    //        var task = (ScheduledTask)sender;
    //        task.TaskComplete -= RemoveTask;
    //        ScheduledTask deleted;
    //        _scheduledTasks.TryRemove(task.Action, out deleted);
    //    }
    //}

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewModel : ViewModelBase
    {
        #region Private fields

        private readonly ObservableCollection<ThemeNameValuePair> _themes =
            new ObservableCollection<ThemeNameValuePair>();

        private ThemeNameValuePair _selectedTheme;

        private readonly InitializeSystemDatabaseManager _initSystemManager;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            BuildThemesCollection();

            Globals.Instance.ValidateThisApplicationWithServer(true);

            //           InitializeGlobals();
            CreateCommandObjects();

            _initSystemManager = new InitializeSystemDatabaseManager(Globals.Instance.ServerConnections[0]);

            Globals.Instance.MessageBroker.MessageReceived += MessageBroker_MessageReceived;
        }

        #endregion

        #region Private Methods

        private void MessageBroker_MessageReceived(object sender, PDSAMessageBrokerEventArgs e)
        {
            // Use this event to receive all messages
            switch (e.MessageName)
            {
                case MessageNames.UserSessionTokenChanged:
                    if (Globals.UserSessionToken != null)
                        _initSystemManager.ClientUserSessionData.SessionGuid = Globals.Instance.UserSessionToken.SessionId;
                    else
                        _initSystemManager.ClientUserSessionData.SessionGuid = Guid.Empty;
                    OnPropertyChanged(() => IsTabControlVisible, false);
                    OnPropertyChanged(() => IsMaintainLanguagesVisible, false);
                    OnPropertyChanged(() => IsMaintainApplicationsVisible, false);
                    OnPropertyChanged(() => IsMaintainEntitiesVisible, false);
                    OnPropertyChanged(() => IsMaintainRolesVisible, false);
                    OnPropertyChanged(() => IsMaintainUsersVisible, false);
                    SignInOutViewModel.UserSessionToken = Globals.UserSessionToken;
                    break;

                default:
                    break;
            }
        }

        private void CreateCommandObjects()
        {
            CurrentUserControlButtonCommand = new DelegateCommand<object>(ExecuteCurrentUserControlButtonCommand,
                CanExecuteCurrentUserControlButtonCommand);
            SignInCommand = new DelegateCommand<object>(ExecuteSignInCommand, CanExecuteSignInCommand);
            SignOutCommand = new DelegateCommand<object>(ExecuteSignOutCommand, CanExecuteSignOutCommand);
            ExitCommand = new DelegateCommand<object>(ExecuteExitCommand, CanExecuteExitCommand);
            ManageLicenseCommand = new DelegateCommand<object>(ExecuteManageLicenseCommand,
                CanExecuteManageLicenseCommand);
            SeedDatabaseCommand = new DelegateCommand<object>(ExecuteSeedDatabaseCommand,
                CanExecuteSeedDatabaseCommand);
            RefreshSitesCommand = new DelegateCommand<object>(ExecuteRefreshSitesCommand,
                CanExecuteRefreshSitesCommand);
            HelpAboutCommand = new DelegateCommand<object>(ExecuteHelpAboutCommand, CanExecuteHelpAboutCommand);

            TestCommand = new DelegateCommand<object>(ExecuteTestCommand, CanExecuteTextCommand);
        }


        private bool CanExecuteTextCommand(object obj)
        {
            return true;
        }

        private void ExecuteTestCommand(object obj)
        {
            IDialogService dlg = new DialogService();
            dlg.ShowDialog(MaintainEntitiesViewModel, new MaintainEntitiesView(), null,
                MaintainEntitiesViewModel.ViewTitle);
            dlg.ShowRadDialog(MaintainEntitiesViewModel, new MaintainEntitiesView(), null,
                MaintainEntitiesViewModel.ViewTitle);
        }

        private void BuildThemesCollection()
        {
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.ExpressionDark,
                Properties.Resources.ThemeDisplayName_Expression_Dark, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green,
                Properties.Resources.ThemeDisplayName_Green, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Properties.Resources.ThemeDisplayName_Office2013_DarkGray,
                Office2013Palette.ColorVariation.DarkGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Properties.Resources.ThemeDisplayName_Office2013_LightGray,
                Office2013Palette.ColorVariation.LightGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013,
                Properties.Resources.ThemeDisplayName_Office2013_White,
                Office2013Palette.ColorVariation.White.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlack,
                Properties.Resources.ThemeDisplayName_Office_Black,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlue,
                Properties.Resources.ThemeDisplayName_Office_Blue,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeSilver,
                Properties.Resources.ThemeDisplayName_Office_Silver,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Summer, Properties.Resources.ThemeDisplayName_Summer,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Transparent,
                Properties.Resources.ThemeDisplayName_Transparent,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Vista, Properties.Resources.ThemeDisplayName_Vista,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_Dark,
                VisualStudio2013Palette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_Blue,
                VisualStudio2013Palette.ColorVariation.Blue.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_Light,
                VisualStudio2013Palette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_Green, ThemeVariationNames.Green));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_DarkOlive, ThemeVariationNames.DarkOlive));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_EarthtoneBrown,
                ThemeVariationNames.EarthtoneBrowns));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013,
                Properties.Resources.ThemeDisplayName_VisualStudio2013_DarkGold, ThemeVariationNames.DarkGold));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7,
                Properties.Resources.ThemeDisplayName_Windows7,
                string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_CoolBlue,
                ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_DarkBlue,
                ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8,
                Properties.Resources.ThemeDisplayName_Windows8_DullBlue,
                ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch,
                Properties.Resources.ThemeDisplayName_Windows8Touch, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Crystal,
                Properties.Resources.ThemeDisplayName_Crystal, string.Empty));
            foreach (var colorVar in (CrystalPalette.ColorVariation[])Enum.GetValues(typeof(CrystalPalette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Crystal,
                    Properties.Resources.ThemeDisplayName_Crystal + $" ({colorVar})", colorVar.ToString()));
            }

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Fluent,
                Properties.Resources.ThemeDisplayName_Fluent, string.Empty));
            foreach (var colorVar in (FluentPalette.ColorVariation[])Enum.GetValues(typeof(FluentPalette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Fluent,
                    Properties.Resources.ThemeDisplayName_Fluent + $" ({colorVar})", colorVar.ToString()));
            }


            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Material,
                Properties.Resources.ThemeDisplayName_Material, string.Empty));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016,
                Properties.Resources.ThemeDisplayName_Office2016, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016Touch,
                Properties.Resources.ThemeDisplayName_Office2016Touch, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2019,
                Properties.Resources.ThemeDisplayName_VisualStudio2019, string.Empty));
            foreach (var colorVar in (VisualStudio2019Palette.ColorVariation[])Enum.GetValues(typeof(VisualStudio2019Palette.ColorVariation)))
            {
                _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2019,
                    Properties.Resources.ThemeDisplayName_VisualStudio2019 + $" ({colorVar})", colorVar.ToString()));
            }

            Themes = new ReadOnlyObservableCollection<ThemeNameValuePair>(_themes);

            var defaultTheme = Properties.Settings.Default.Theme;
            var defaultThemeVariation = Properties.Settings.Default.ThemeVariation;
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

        //private void InitializeGlobals()
        //{
        //    Globals.Instance.InitLicense();
        //    Globals.Instance.RefreshAll();
        //}

        private bool CanExecuteCurrentUserControlButtonCommand(object obj)
        {
            return true;
        }

        private void ExecuteCurrentUserControlButtonCommand(object obj)
        {
            if (Globals.IsUserSessionValid == false)
                ShowSignOnOffDialog();
        }


        private bool CanExecuteSignOutCommand(object obj)
        {
            return Globals.Instance.IsUserSessionValid;
        }

        private void ExecuteSignOutCommand(object obj)
        {
            ShowSignOnOffDialog();
        }

        private bool CanExecuteSignInCommand(object obj)
        {
            return Globals.IsUserSessionValid == false;
        }

        private void ExecuteSignInCommand(object obj)
        {
            ShowSignOnOffDialog();
        }

        private bool CanExecuteExitCommand(object obj)
        {
            return true;
        }

        private void ExecuteExitCommand(object obj)
        {
            TelerikHelpers.PromptForExit(OnConfirmClosed);
        }

        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                Application.Current.Shutdown(0);
            }
        }

        private bool CanExecuteHelpAboutCommand(object obj)
        {
            return true;
        }

        private void ExecuteHelpAboutCommand(object obj)
        {
            SetBackgroundSubdued();
            TelerikHelpers.ShowHelpAboutDialog(OnHelpAboutClosed);
        }

        private void OnHelpAboutClosed(object sender, WindowClosedEventArgs e)
        {
            ClearBackgroundSubdued();
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }

        private void ShowSignOnOffDialog()
        {
            var assemblyAttributes = Globals.Instance.MyAssemblyAtrributes;

            IDialogService dlgService = new DialogService();
            var signInOutView = new SignInOutView
            {
                ApplicationGuid = assemblyAttributes.Guid,
                ApplicationName = assemblyAttributes.Title,
                CopyrightNotice = assemblyAttributes.Company,
                HeaderText = Properties.Resources.SignInOutView_HeaderText,
                FooterText = Properties.Resources.SignInOutView_FooterText,
                Servers = Settings.Default.Servers.ToObservableCollection(),
                ServerAddress = Settings.Default.ServerAddress
            };
            var authenticationType = GenericEnums.GetOne<AuthenticationType>(Settings.Default.AuthenticationType);
            signInOutView.AuthenticationType = new AuthenticationTypeData(authenticationType);
            signInOutView.UserSessionToken = Globals.Instance.UserSessionToken;
            //signInOutView.HeaderBackground = new SolidColorBrush(System.Windows.Media.Colors.DarkRed);
            //signInOutView.FooterBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x6E, 0x6E, 0xbE));

            SetBackgroundSubdued();
            dlgService.ShowRadDialog(signInOutView, null, assemblyAttributes.Title);
            //.Resources.Dialog_UserSignInOutDialogTitle);
            ClearBackgroundSubdued();
            if (signInOutView.DialogResult == true)
            {
                Globals.Instance.UserSessionToken = signInOutView.UserSessionToken;
                OnPropertyChanged(() => CurrentUserImage, false);
                OnPropertyChanged(() => CurrentUserDisplayName, false);
                IsTabControlVisible = true;
                IsPanelCommunicationVisible = true;
                IsMaintainLanguagesVisible = true;
                IsMaintainEntitiesVisible = true;
                IsMaintainApplicationsVisible = true;
                IsMaintainRolesVisible = true;
                IsMaintainUsersVisible = true;
            }
        }

        #endregion

        #region Commands

        public DelegateCommand<object> TestCommand { get; private set; }
        public DelegateCommand<object> HelpAboutCommand { get; private set; }
        public DelegateCommand<object> ExitCommand { get; private set; }
        public DelegateCommand<object> SignInCommand { get; private set; }
        public DelegateCommand<object> SignOutCommand { get; private set; }
        public DelegateCommand<object> CurrentUserControlButtonCommand { get; private set; }
        public DelegateCommand<object> ManageLicenseCommand { get; private set; }
        public DelegateCommand<object> SeedDatabaseCommand { get; private set; }
        public DelegateCommand<object> RefreshSitesCommand { get; private set; }
        #endregion

        #region Public Properties

        public override string ViewTitle
        {
            get
            {
                return string.Format(Properties.Resources.MainView_ApplicationTitleFormat,
                    Properties.Resources.MainView_ApplicationTitle,
                    Globals.MyAssemblyAtrributes.Version);
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

        [Import]
        public SignInOutViewModel SignInOutViewModel { get; private set; }

        [Import]
        public GalaxyPanelCommunicationViewModel GalaxyPanelCommunicationViewModel { get; private set; }

        [Import]
        public MaintainEntitiesViewModel MaintainEntitiesViewModel { get; private set; }

        [Import]
        public MaintainLanguagesViewModel MaintainLanguagesViewModel { get; private set; }

        [Import]
        public MaintainApplicationsViewModel MaintainApplicationsViewModel { get; private set; }

        [Import]
        public MaintainRolesViewModel MaintainRolesViewModel { get; private set; }

        [Import]
        public MaintainUsersViewModel MaintainUsersViewModel { get; private set; }


        private bool _isTabControlVisible;

        public bool IsTabControlVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isTabControlVisible;
            }
            set
            {
                if (_isTabControlVisible != value)
                {
                    _isTabControlVisible = value;
                    OnPropertyChanged(() => IsTabControlVisible, false);
                }
            }
        }

        private bool _isPanelCommunicationVisible;

        public bool IsPanelCommunicationVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;

                return _isPanelCommunicationVisible;
            }
            set
            {
                if (_isPanelCommunicationVisible != value)
                {
                    _isPanelCommunicationVisible = value;
                    OnPropertyChanged(() => IsPanelCommunicationVisible, false);
                }
            }
        }

        private bool _isMaintainEntitiesVisible;

        public bool IsMaintainEntitiesVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isMaintainEntitiesVisible;
            }
            set
            {
                if (_isMaintainEntitiesVisible != value)
                {
                    _isMaintainEntitiesVisible = value;
                    OnPropertyChanged(() => IsMaintainEntitiesVisible, false);
                }
            }
        }

        private bool _isMaintainLanguagesVisible;

        public bool IsMaintainLanguagesVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isMaintainLanguagesVisible;
            }
            set
            {
                if (_isMaintainLanguagesVisible != value)
                {
                    _isMaintainLanguagesVisible = value;
                    OnPropertyChanged(() => IsMaintainLanguagesVisible, false);
                }
            }
        }

        private bool _isMaintainApplicationsVisible;

        public bool IsMaintainApplicationsVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isMaintainApplicationsVisible;
            }
            set
            {
                if (_isMaintainApplicationsVisible != value)
                {
                    _isMaintainApplicationsVisible = value;
                    OnPropertyChanged(() => IsMaintainApplicationsVisible, false);
                }
            }
        }

        private bool _isMaintainRolesVisible;

        public bool IsMaintainRolesVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isMaintainRolesVisible;
            }
            set
            {
                if (_isMaintainRolesVisible != value)
                {
                    _isMaintainRolesVisible = value;
                    OnPropertyChanged(() => IsMaintainRolesVisible, false);
                }
            }
        }

        private bool _isMaintainUsersVisible;

        public bool IsMaintainUsersVisible
        {
            get
            {
                if (Globals.Instance.IsUserSessionValid == false)
                    return false;
                return _isMaintainUsersVisible;
            }
            set
            {
                if (_isMaintainUsersVisible != value)
                {
                    _isMaintainUsersVisible = value;
                    OnPropertyChanged(() => IsMaintainUsersVisible, false);
                }
            }
        }

        public Globals Globals
        {
            get { return Globals.Instance; }
        }


        public byte[] CurrentUserImage
        {
            get
            {
                if (Globals.IsUserSessionValid)
                    return Globals.UserSessionToken.UserData.UserImage;
                return ByteArrayToFromImage.ImageToByteArray(Properties.Resources.PersonSilhouetteRound);
            }
        }


        public string CurrentUserDisplayName
        {
            get
            {
                if (Globals.IsUserSessionValid)
                    return Globals.UserSessionToken.UserData.DisplayName;
                return Properties.Resources.CurrentUserDisplayName;
            }
        }

        private bool CanExecuteManageLicenseCommand(object obj)
        {
            return true;
            //return Globals.ThisApplication.SystemRoleId != null && (Globals.IsUserSessionValid &&
            //                                                        Globals.UserSessionToken.IsInRole(
            //                                                            Globals.CurrentUserEntity.EntityId,
            //                                                            Globals.ThisApplication.ApplicationId,
            //                                                            Globals.ThisApplication.SystemRoleId.Value));
        }

        private void ExecuteManageLicenseCommand(object obj)
        {
        }

        private bool CanExecuteSeedDatabaseCommand(object obj)
        {
            return true;
            //return Globals.ThisApplication.SystemRoleId != null && (Globals.IsUserSessionValid &&
            //                                                        Globals.UserSessionToken.IsInRole(
            //                                                            Globals.CurrentUserEntity.EntityId,
            //                                                            Globals.ThisApplication.ApplicationId,
            //                                                            Globals.ThisApplication.SystemRoleId.Value));
        }

        private async void ExecuteSeedDatabaseCommand(object obj)
        {
            var seedDatabaseManager = new SeedDatabaseManager(Globals.Instance.ServerConnections[0]);

            Globals.IsBusy = true;
            Globals.BusyContent = Properties.Resources.BusyContent_SeedingDatabase;

            try
            {
                Globals.ClearCustomErrors();

                var parameters = new SaveParameters<SeedDatabaseRequest>() { SavePhoto = true, };

                #region Brands

                var brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameGalaxyControlSystems,
                    BrandName = SharedResources.Resources.Brand_BrandNameGalaxyControlSystems,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                };

                var imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/GalaxyLogo.png",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameAssaAbloy,
                    BrandName = SharedResources.Resources.Brand_BrandNameAssaAbloy,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_ASSAABLOY,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/ASSAABLOY/mainAALogo.jpg",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameAllegion,
                    BrandName = SharedResources.Resources.Brand_BrandNameAllegion,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Allegion,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Allegion/Allegion_Logo.jpg",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameFarpointe,
                    BrandName = SharedResources.Resources.Brand_BrandNameFarpointe,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Farpointe,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Farpointe_Logo.jpg",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameHID,
                    BrandName = SharedResources.Resources.Brand_BrandNameHID,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_HID,
                };

                imageSource =
                    new BitmapImage(
                        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/hidw200.png",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameSafran,
                    BrandName = SharedResources.Resources.Brand_BrandNameSafranMorpho,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_SafranMorpho,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/SafranMorpho/morpho200.jpg",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameSalto,
                    BrandName = SharedResources.Resources.Brand_BrandNameSalto,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Salto,
                };

                imageSource =
                    new BitmapImage(
                        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Salto/SALTO.png",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);


                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameEssex,
                    BrandName = SharedResources.Resources.Brand_BrandNameEssex,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Essex,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Essex/essex-logo.jpg",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);

                brand = new Brand()
                {
                    Category = SharedResources.Resources.Brand_CategoryAccessControl,
                    CompanyName = SharedResources.Resources.Brand_CompanyNameXico,
                    BrandName = SharedResources.Resources.Brand_BrandNameXico,
                    BrandUid = GalaxySMS.Common.Constants.BrandIds.Brand_Xico,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Xico/logo.png",
                            UriKind.Absolute));
                brand.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.Brands.Add(brand);
                #endregion

                #region CredentialReaderDataFormats

                var credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_GalaxyInfrared,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.Unknown,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.None
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataStandard,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData_Inverted,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataInverted,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockDataInverted
                };

                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_ClockData8DigitFixed,
                    PanelDataFormatCode =
                        (int)
                        GalaxySMS.Common.Enums.CredentialReaderDataFormat.ClockDataFixed8Digits,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData8DigitFixed
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_RS232G5,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.Rs232G5,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.RS232G5
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_Wiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.WiegandFormat,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_WiegandKey,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.WiegandKey,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.WiegandKey
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_XceedIdPiv,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.XceedIdPiv,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.XceedIdPiv
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_XceedIdPivWiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.XceedIdPivWiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.XceedIdPivWiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_Cardax,
                    PanelDataFormatCode = (int)Common.Enums.CredentialReaderDataFormat.Cardax,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Cardax
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                credentialReaderFormat = new CredentialReaderDataFormat()
                {
                    DataFormatName = SharedResources.Resources.CredentialReaderDataFormat_CardaxWiegand,
                    PanelDataFormatCode =
                        (int)GalaxySMS.Common.Enums.CredentialReaderDataFormat.CardaxWiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.CardaxWiegand
                };
                parameters.Data.CredentialReaderDataFormats.Add(credentialReaderFormat);

                #endregion

                #region CredentialReaderType

                var credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.AssaAbloyIPEnabledLock,
                    BrandUid = Common.Constants.BrandIds.Brand_ASSAABLOY,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    Model = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    Description = SharedResources.Resources.CredentialReaderTypeName_ASSAAbloyIPEnabledLock,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/ASSAABLOY/Products/WIFI/SAR_Profile SeriesS2.png",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardWiegand,
                    BrandUid = Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Standard_Wiegand,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Standard_Wiegand,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Standard_Wiegand,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/standard_wiegand.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardDataClock,
                    BrandUid = Common.Constants.BrandIds.Brand_GalaxyControlSystems,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Standard_DataClock,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Standard_DataClock,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Standard_DataClock,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockData
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/standard_data_clock.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeRanger,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Pyramid,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Pyramid,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Pyramid,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Pyramid/grp_pyramid.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeDelta,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Delta,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Delta,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Delta,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Delta/grp_delta.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.FarpointeRanger,
                    BrandUid = Common.Constants.BrandIds.Brand_Farpointe,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_Farpointe_Ranger,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_Farpointe_Ranger,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_Farpointe_Ranger,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Farpointe/Ranger/grp_ranger.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.HIDProx125K,
                    BrandUid = Common.Constants.BrandIds.Brand_HID,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_HID_125KProx,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_HID_125KProx,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_HID_125KProx,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/125K/readers-prox-banner_0.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.HIDiClassSE,
                    BrandUid = Common.Constants.BrandIds.Brand_HID,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_HID_iClassSE,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_HID_iClassSE,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_HID_iClassSE,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.Wiegand
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/HID/iClass/SE/readers-iclass-se-platform-banner_0.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);

                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.EssexKeypad,
                    BrandUid = Common.Constants.BrandIds.Brand_Essex,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_EssexKeypad,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_EssexKeypad,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_EssexKeypad,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.None
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Essex/12-PadBothSm.png",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);


                credentialReaderType = new CredentialReaderType()
                {
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.InvertedDataClock,
                    BrandUid = Common.Constants.BrandIds.Brand_Xico,
                    ReaderTypeName = SharedResources.Resources.CredentialReaderTypeTypeName_XicoMagStripe,
                    Model = SharedResources.Resources.CredentialReaderTypeModel_XicoMagStripe,
                    Description = SharedResources.Resources.CredentialReaderTypeDescription_XicoMagStripe,
                    CredentialReaderDataFormatUid = Common.Constants.CredentialReaderDataFormatIds.ClockDataInverted
                };
                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Xico/36001.jpg",
                            UriKind.Absolute));
                credentialReaderType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();

                parameters.Data.CredentialReaderTypes.Add(credentialReaderType);
                #endregion

                #region AccessPortalTypes

                var accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_AssaIpEnabledLock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_AssaIpEnabledLock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.AssaAbloyIPEnabledLock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_StandardWiegand,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_StandardWiegand,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardWiegand
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_StandardDataClock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_StandardDataClock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.StandardDataClock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);


                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_InvertedDataClock,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_InvertedDataClock,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.InvertedDataClock
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);


                accessPortalType = new AccessPortalType()
                {
                    AccessPortalTypeUid =
                        Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_EssexKeypad,
                    AccessPortalTypeDescription =
                        SharedResources.Resources.AccessPortalType_StandardEntryPoint_EssexKeypad,
                    CredentialReaderTypeUid = Common.Constants.CredentialReaderTypeIds.EssexKeypad
                };
                parameters.Data.AccessPortalTypes.Add(accessPortalType);

                #endregion

                #region InputDeviceSupervisionTypes

                var inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid = GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.None,
                    IsActive = true,
                    IsDefault = true,
                    HasSeriesResistor = false,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervision.TroubleShort,
                    AlternateVoltagesEnabled = true,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.NoSupervisionAlternate.TroubleShort,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_None_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_None_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.None.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenNoSupervision.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_SeriesInLine_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_SeriesInLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine1000.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine1000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2000.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine2000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine2200.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine2200.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesInLine4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = false,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700Alternate.TroubleShort,
                    Display =
                        string.Format(SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_SeriesInLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.InLine4700.ResistorValue),
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesInLine4700.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display = SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Display,
                    Description = SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine1000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine1000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine2000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine2200.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine2200.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.ParallelEndOfLine4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = false,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700Alternate.TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources.InputDeviceSupervisionType_ParallelEndOfLine_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLine4700.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.ParallelEndOfLine4700.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold = 0,
                    TroubleOpenThreshold = 0,
                    TroubleShortThreshold = 0,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold = 0,
                    AlternateTroubleOpenThreshold = 0,
                    AlternateTroubleShortThreshold = 0,
                    Display =
                        SharedResources.Resources.InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLine_Display,
                    Description =
                        SharedResources.Resources
                            .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLine_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds
                        .DualSerialChannelMode_RS485InputModule);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel1000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine1000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel1000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);


                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel2000,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2000.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel2000.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel2200,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine2200.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel2200.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                inputDeviceSupervisionType = new InputDeviceSupervisionType()
                {
                    InputDeviceSupervisionTypeUid =
                        GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.SeriesAndParallel4700,
                    IsActive = true,
                    IsDefault = false,
                    HasSeriesResistor = true,
                    HasParallelResistor = true,
                    IsNormalOpen = false,
                    NormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.Normal,
                    TroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.TroubleOpen,
                    TroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.TroubleShort,
                    AlternateVoltagesEnabled = false,
                    AlternateNormalChangeThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate.Normal,
                    AlternateTroubleOpenThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate.TroubleOpen,
                    AlternateTroubleShortThreshold =
                        GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700Alternate
                            .TroubleShort,
                    Display =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Display,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.ResistorValue),
                    Description =
                        string.Format(
                            SharedResources.Resources
                                .InputDeviceSupervisionType_InLineSeriesAndParallelEndOfLineValue_Description,
                            GalaxySMS.Common.Constants.GalaxyInputVoltageThresholds.EndOfLineInLine4700.ResistorValue),
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.InputDeviceSupervisionType.SeriesAndParallel4700.ToString()
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                inputDeviceSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                inputDeviceSupervisionType.InterfaceBoardSectionModeIds.Add(
                    GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs);
                parameters.Data.InputDeviceSupervisionTypes.Add(inputDeviceSupervisionType);

                #endregion

                #region AccessPortalContactSupervisionTypes


                var accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.None,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_None_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_None_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.None.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.None,
                    IsActive = true,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenNoSupervision.png",
                            UriKind.Absolute));
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);


                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesAndParallel,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesAndParallel_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_SeriesAndParallel_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesAndParallel.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesAndParallel,
                    IsActive = true,
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeriesAndParallel.png",
                            UriKind.Absolute));
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);


                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.SeriesInLine,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesInLine_Display,
                    Description = SharedResources.Resources.AccessPortalContactSupervisionType_SeriesInLine_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesInLine.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.SeriesInLine,
                    IsActive = true,
                    IsDefault = false
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenSeries.png",
                            UriKind.Absolute));
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);

                accessPortalContactSupervisionType = new AccessPortalContactSupervisionType()
                {
                    AccessPortalContactSupervisionTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalContactSupervisionTypeIds.ParallelEndOfLine,
                    Display = SharedResources.Resources.AccessPortalContactSupervisionType_ParallelEndOfLine_Display,
                    Description =
                        SharedResources.Resources.AccessPortalContactSupervisionType_ParallelEndOfLine_Description,
                    UniqueResourceName =
                        GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.ParallelEndOfLine.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalContactSupervisionType.ParallelEndOfLine,
                    IsActive = true
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/InputSupervisionType/NormalOpenParallel.png",
                            UriKind.Absolute));
                accessPortalContactSupervisionType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                parameters.Data.AccessPortalContactSupervisionTypes.Add(accessPortalContactSupervisionType);

                #endregion

                #region AccessPortalElevatorControlType

                var accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.None,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_None_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_None_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.None.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.None,
                    IsActive = true,
                    IsDefault = true
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/none.png",
                            UriKind.Absolute));

                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);


                // Galaxy Control Systems Relay
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.GalaxyElevatorControlRelays,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_GalaxyElevatorControlRelays_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_GalaxyElevatorControlRelays_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.GalaxyElevatorControlRelays.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.GalaxyElevatorControlRelays,
                    IsActive = true,
                    IsDefault = false
                };

                imageSource =
                    new BitmapImage(
                        new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/GalaxyControlSystems/GalaxyLogoArrows.jpg",
                            UriKind.Absolute));

                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_708);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);


                // Otis Compass
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.OtisCompass,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_OtisCompass_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_OtisCompass_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.OtisCompass.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.OtisCompass,
                    IsActive = true,
                    IsDefault = false
                };

                imageSource =
                    new BitmapImage(
                        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Otis/Otis.jpg",
                            UriKind.Absolute));

                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);

                // Kone Compass
                accessPortalElevatorControlType = new AccessPortalElevatorControlType()
                {
                    AccessPortalElevatorControlTypeUid =
                        GalaxySMS.Common.Constants.AccessPortalElevatorControlTypeIds.KoneEli,
                    Display = SharedResources.Resources.AccessPortalElevatorControlType_KoneEli_Display,
                    Description = SharedResources.Resources.AccessPortalElevatorControlType_KoneEli_Description,
                    UniqueResourceName = GalaxySMS.Common.Enums.AccessPortalElevatorControlType.KoneEli.ToString(),
                    Code = (short)GalaxySMS.Common.Enums.AccessPortalElevatorControlType.KoneEli,
                    IsActive = true,
                    IsDefault = false
                };

                imageSource =
                    new BitmapImage(
                        new Uri("pack://application:,,,/GalaxySMS.Resources;component/Images/Partners/Kone/KONE_180.png",
                            UriKind.Absolute));

                accessPortalElevatorControlType.gcsBinaryResource.BinaryResource = imageSource.ToByteArray();
                accessPortalElevatorControlType.GalaxyPanelModelUids.Add(
                    GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635);
                parameters.Data.AccessPortalElevatorControlTypes.Add(accessPortalElevatorControlType);
                #endregion

                #region GalaxyOutputMode

                // Follows
                var galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Follows,
                    Display = SharedResources.Resources.GalaxyOutputMode_Follows_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Follows_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Follows,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Follows.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/follows.png",
                            UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Latching
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Latching,
                    Display = SharedResources.Resources.GalaxyOutputMode_Latching_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Latching_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Latching,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Latching.ToString()
                };

                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/padlock2_unlock-user.png",
                            UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Scheduled
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Scheduled,
                    Display = SharedResources.Resources.GalaxyOutputMode_Scheduled_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Scheduled_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Scheduled,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Scheduled.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/scheduled.png",
                            UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // TimeoutRetriggerable
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.TimeoutRetriggerable,
                    Display = SharedResources.Resources.GalaxyOutputMode_TimeoutRetriggerable_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_TimeoutRetriggerable_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.TimeoutRetriggerable,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.TimeoutRetriggerable.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/timeout-retriggerable.png",
                            UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Timeout
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Timeout,
                    Display = SharedResources.Resources.GalaxyOutputMode_Timeout_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Timeout_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Timeout,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Timeout.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/timeout.png",
                    UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Limit
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Limit,
                    Display = SharedResources.Resources.GalaxyOutputMode_Limit_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Limit_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Limit,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Limit.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/limit.png",
                    UriKind.Absolute));

                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);

                // Counter
                galaxyOutputMode = new GalaxyOutputMode()
                {
                    GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Counter,
                    Display = SharedResources.Resources.GalaxyOutputMode_Counter_Display,
                    Description = SharedResources.Resources.GalaxyOutputMode_Counter_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputMode.Counter,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputMode.Counter.ToString()
                };
                galaxyOutputMode.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                    "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/counter_up_down.png",
                    UriKind.Absolute));


                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Disable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Enable);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.On);
                galaxyOutputMode.OutputCommandUids.Add(
                    GalaxySMS.Common.Constants.OutputCommandIds.Off);

                parameters.Data.GalaxyOutputModes.Add(galaxyOutputMode);


                #endregion

                #region GalaxyOutputInputSourceRelationship

                // OR
                var galaxyOutputInputSourceRelationship = new GalaxyOutputInputSourceRelationship
                {
                    GalaxyOutputInputSourceRelationshipUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceRelationshipIds.OR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceRelationship_OR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceRelationship_OR_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.OR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.OR.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/or.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceRelationships.Add(galaxyOutputInputSourceRelationship);

                galaxyOutputInputSourceRelationship = new GalaxyOutputInputSourceRelationship
                {
                    GalaxyOutputInputSourceRelationshipUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceRelationshipIds.AND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceRelationship_AND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceRelationship_AND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.AND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceRelationship.AND.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/and.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceRelationships.Add(galaxyOutputInputSourceRelationship);

                #endregion

                #region GalaxyOutputInputSourceMode

                // OR
                var galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.OR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_OR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_OR_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.OR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.OR.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/or.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // AND
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.AND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_AND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_AND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.AND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.AND.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/and.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // NAND
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.NAND,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_NAND_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_NAND_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NAND,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NAND.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/nand.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);

                // NOR
                galaxyOutputInputSourceMode = new GalaxyOutputInputSourceMode
                {
                    GalaxyOutputInputSourceModeUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.NOR,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceMode_NOR_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceMode_NOR_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NOR,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceMode.NOR.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Logic/nor.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceModes.Add(galaxyOutputInputSourceMode);
                #endregion

                #region GalaxyOutputInputSourceTriggerCondition

                // Nothing
                var galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Nothing,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Nothing_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Nothing_Description,
                    IsDefault = true,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Nothing,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Nothing.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/none.png",
                            UriKind.Absolute))
                    }
                };

                //File.WriteAllBytes("e:\\zTemp\\none.png", galaxyOutputInputSourceTriggerCondition.gcsBinaryResource.BinaryResource);

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Active
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.OnOrAlarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Active_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Active_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.OnOrAlarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.OnOrAlarm.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-orange.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);


                // Alarm
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Alarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Alarm_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Alarm_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Alarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Alarm.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-red.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // On
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.On,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_On_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_On_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.On,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.On.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Armed
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Armed,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Armed_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Armed_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Armed,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Armed.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-green-dark.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Disarmed
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Disarmed,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Disarmed_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Disarmed_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Disarmed,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Disarmed.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm_bell-gray.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);


                // Trouble
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.Trouble,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Trouble_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_Trouble_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Trouble,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.Trouble.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm-tools-orange.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);

                // Trouble or Alarm
                galaxyOutputInputSourceTriggerCondition = new GalaxyOutputInputSourceTriggerCondition
                {
                    GalaxyOutputInputSourceTriggerConditionUid =
                        GalaxySMS.Common.Constants.GalaxyOutputInputSourceTriggerConditionIds.TroubleOrAlarm,
                    Display = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_AlarmOrTrouble_Display,
                    Description = SharedResources.Resources.GalaxyOutputInputSourceTriggerCondition_AlarmOrTrouble_Description,
                    IsDefault = false,
                    Code = (short)GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.TroubleOrAlarm,
                    UniqueResourceName = GalaxySMS.Common.Enums.GalaxyOutputInputSourceTriggerCondition.TroubleOrAlarm.ToString(),
                    gcsBinaryResource =
                    {
                        BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.UriToByteArray(new Uri(
                            "pack://application:,,,/GalaxySMS.Resources;component/Images/Outputs/32x32/alarm-tools-red.png",
                            UriKind.Absolute))
                    }
                };

                parameters.Data.GalaxyOutputInputSourceTriggerConditions.Add(galaxyOutputInputSourceTriggerCondition);
                #endregion

                bool result = await seedDatabaseManager.SeedDatabaseAsync(parameters);
                if (seedDatabaseManager.HasErrors)
                {
                    foreach (var error in seedDatabaseManager.Errors)
                    {
                        Globals.AddCustomError(error);
                    }
                }
            }
            catch (Exception e)
            {
                this.Log().DebugFormat(e.ToString());
            }
            Globals.IsBusy = false;
        }


        private bool CanExecuteRefreshSitesCommand(object obj)
        {
            return Globals.IsUserSessionValid;
        }

        private void ExecuteRefreshSitesCommand(object obj)
        {
            Globals.RefreshEntitySites();
        }

        #endregion
    }
}