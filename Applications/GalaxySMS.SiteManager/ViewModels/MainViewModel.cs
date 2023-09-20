using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using GalaxySMS.SiteManager.Properties;
using GalaxySMS.SiteManager.Support;
using GalaxySMS.SiteManager.Themes;
using GalaxySMS.SiteManager.Views;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.UI.ViewModels;
using GalaxySMS.Client.UI.Views;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using GCS.Framework.Security;
using GCS.Framework.Utilities;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.SiteManager.ViewModels
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
        private ObservableCollection<ThemeNameValuePair> _themes = new ObservableCollection<ThemeNameValuePair>();
        private ThemeNameValuePair _selectedTheme;

        InitializeSystemDatabaseManager _initSystemManager;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            BuildThemesCollection();
            Globals.Instance.ValidateThisApplicationWithServer(true);
            //           InitializeGlobals();
            CreateCommandObjects();

            _initSystemManager = new InitializeSystemDatabaseManager(Globals.Instance.ServerConnections[0]);
        }
        #endregion

        #region Private Methods
        private void CreateCommandObjects()
        {
            CurrentUserControlButtonCommand = new DelegateCommand<object>(ExecuteCurrentUserControlButtonCommand, CanExecuteCurrentUserControlButtonCommand);
            SignInCommand = new DelegateCommand<object>(ExecuteSignInCommand, CanExecuteSignInCommand);
            SignOutCommand = new DelegateCommand<object>(ExecuteSignOutCommand, CanExecuteSignOutCommand);
            ExitCommand = new DelegateCommand<object>(ExecuteExitCommand, CanExecuteExitCommand);
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
            dlg.ShowDialog(MaintainUsersViewModel, new MaintainUsersView(), null, MaintainUsersViewModel.ViewTitle);
        }

        private void BuildThemesCollection()
        {
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.ExpressionDark, Resources.ThemeDisplayName_Expression_Dark, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Resources.ThemeDisplayName_Office2013_DarkGray, Office2013Palette.ColorVariation.DarkGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Resources.ThemeDisplayName_Office2013_LightGray, Office2013Palette.ColorVariation.LightGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Resources.ThemeDisplayName_Office2013_White, Office2013Palette.ColorVariation.White.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlack, Resources.ThemeDisplayName_Office_Black, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlue, Resources.ThemeDisplayName_Office_Blue, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeSilver, Resources.ThemeDisplayName_Office_Silver, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Summer, Resources.ThemeDisplayName_Summer, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Transparent, Resources.ThemeDisplayName_Transparent, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Vista, Resources.ThemeDisplayName_Vista, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_Dark, VisualStudio2013Palette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_Blue, VisualStudio2013Palette.ColorVariation.Blue.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_Light, VisualStudio2013Palette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_Green, ThemeVariationNames.Green));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_DarkOlive, ThemeVariationNames.DarkOlive));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_EarthtoneBrown, ThemeVariationNames.EarthtoneBrowns));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Resources.ThemeDisplayName_VisualStudio2013_DarkGold, ThemeVariationNames.DarkGold));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7, Resources.ThemeDisplayName_Windows7, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_CoolBlue, ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_DarkBlue, ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Resources.ThemeDisplayName_Windows8_DullBlue, ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch, Resources.ThemeDisplayName_Windows8Touch, string.Empty));
            Themes = new ReadOnlyObservableCollection<ThemeNameValuePair>(_themes);

            string defaultTheme = Settings.Default.Theme;
            foreach (ThemeNameValuePair theme in _themes)
            {
                if (theme.AssemblyName == defaultTheme)
                {
                    SelectedTheme = theme;
                    break;
                }
            }
        }

        private void InitializeGlobals()
        {
            Globals.Instance.Init();
            Globals.Instance.RefreshAll();
        }

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
            var signInOutView = new SignInOutView();
            signInOutView.UserSessionToken = Globals.Instance.UserSessionToken;
            signInOutView.ApplicationGuid = assemblyAttributes.Guid;
            signInOutView.ApplicationName = assemblyAttributes.Title;
            signInOutView.CopyrightNotice = assemblyAttributes.Company;
            signInOutView.HeaderText = Resources.SignInOutView_HeaderText;
            signInOutView.FooterText = Resources.SignInOutView_FooterText;
            signInOutView.Servers = Settings.Default.Servers.ToObservableCollection();
            signInOutView.ServerAddress = Settings.Default.ServerAddress;
            AuthenticationType authenticationType = GenericEnums.GetOne<AuthenticationType>(Settings.Default.AuthenticationType);
            signInOutView.AuthenticationType = new AuthenticationTypeData(authenticationType);
            //signInOutView.HeaderBackground = new SolidColorBrush(System.Windows.Media.Colors.DarkRed);
            //signInOutView.FooterBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x6E, 0x6E, 0xbE));

            SetBackgroundSubdued();
            dlgService.ShowRadDialog(signInOutView, null, assemblyAttributes.Title);//.Resources.Dialog_UserSignInOutDialogTitle);
            ClearBackgroundSubdued();
            if (signInOutView.DialogResult == true)
            {
                Globals.Instance.UserSessionToken = signInOutView.UserSessionToken;
                OnPropertyChanged(() => CurrentUserImage, false);
                OnPropertyChanged(() => CurrentUserDisplayName, false);
                IsTabControlVisible = true;
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

        #endregion

        #region Public Properties
        public override string ViewTitle
        {
            get
            {
                return string.Format(Resources.MainView_ApplicationTitleFormat, Resources.MainView_ApplicationTitle, Globals.MyAssemblyAtrributes.Version);
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
                    (App.Current as App).SwitchTheme(_selectedTheme);
                    Settings.Default.Theme = _selectedTheme.AssemblyName;
                    Settings.Default.ThemeVariation = _selectedTheme.VariationName;
                    Settings.Default.Save();
                }
            }
        }

        [Import]
        public SignInOutViewModel SignInOutViewModel { get; private set; }

        [Import]
        public MaintainUsersViewModel MaintainUsersViewModel { get; private set; }


        private bool _isTabControlVisible = false;

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

        private bool _isMaintainUsersVisible = false;

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
            get
            {
                return Globals.Instance;
            }
        }


        public byte[] CurrentUserImage
        {
            get
            {
                if (Globals.IsUserSessionValid)
                    return Globals.UserSessionToken.UserData.UserImage;
                return ByteArrayToFromImage.ImageToByteArray(Resources.PersonSilhouetteRound);
            }
        }


        public string CurrentUserDisplayName
        {
            get
            {
                if (Globals.IsUserSessionValid)
                    return Globals.UserSessionToken.UserData.DisplayName;
                return Resources.CurrentUserDisplayName;
            }
        }

        #endregion
    }
}