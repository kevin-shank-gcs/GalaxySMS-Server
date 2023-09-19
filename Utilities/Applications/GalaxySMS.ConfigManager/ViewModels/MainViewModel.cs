using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GalaxySMS.ConfigManager.Properties;
using GalaxySMS.ConfigManager.Support.Telerik;
using GalaxySMS.ConfigManager.Themes;
using GCS.Core.Common.UI.Core;
using GalaxySMS.ConfigManager.Views;
using System.Windows;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using System.Net;

namespace GalaxySMS.ConfigManager.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewModel : ViewModelBase
    {
        #region Private fields
        private ObservableCollection<ThemeNameValuePair> _themes = new ObservableCollection<ThemeNameValuePair>();
        private ThemeNameValuePair _selectedTheme;
        private string _userName;
        private string _password;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            CreateCommands();
            BuildThemesCollection();
            InitializeGlobals();
        }
        #endregion

        #region Private methods
        private void CreateCommands()
        {
            ExitCommand = new DelegateCommand<object>(ExecuteExitCommand, CanExecuteExitCommand);
            HelpAboutCommand = new DelegateCommand<object>(ExecuteHelpAboutCommand, CanExecuteHelpAboutCommand);
            CommandA = new DelegateCommand<object>(ExecuteCommandA, CanExecuteCommandA);
        }

        private bool CanExecuteCommandA(object obj)
        {
            return true;
            return false;
        }

        private async void ExecuteCommandA(object obj)
        {
            try
            {
                Globals.IsBusy = true;
                ClearCustomErrors();
            }
            catch (Exception ex)
            {
                AddCustomError(new GCS.Core.Common.CustomError(ex));
            }
            Globals.IsBusy = false;

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

        private void BuildThemesCollection()
        {
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.ExpressionDark, Properties.Resources.ThemeDisplayName_Expression_Dark, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Properties.Resources.ThemeDisplayName_Office2013_DarkGray, Telerik.Windows.Controls.Office2013Palette.ColorVariation.DarkGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Properties.Resources.ThemeDisplayName_Office2013_LightGray, Telerik.Windows.Controls.Office2013Palette.ColorVariation.LightGray.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Properties.Resources.ThemeDisplayName_Office2013_White, Telerik.Windows.Controls.Office2013Palette.ColorVariation.White.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2013, Properties.Resources.ThemeDisplayName_Office2013_GalaxyRed, ThemeVariationNames.GalaxyRed));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlack, Properties.Resources.ThemeDisplayName_Office_Black, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeBlue, Properties.Resources.ThemeDisplayName_Office_Blue, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.OfficeSilver, Properties.Resources.ThemeDisplayName_Office_Silver, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Summer, Properties.Resources.ThemeDisplayName_Summer, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Transparent, Properties.Resources.ThemeDisplayName_Transparent, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Vista, Properties.Resources.ThemeDisplayName_Vista, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_Dark, Telerik.Windows.Controls.VisualStudio2013Palette.ColorVariation.Dark.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_Blue, Telerik.Windows.Controls.VisualStudio2013Palette.ColorVariation.Blue.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_Light, Telerik.Windows.Controls.VisualStudio2013Palette.ColorVariation.Light.ToString()));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_Green, ThemeVariationNames.Green));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_DarkOlive, ThemeVariationNames.DarkOlive));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_EarthtoneBrown, ThemeVariationNames.EarthtoneBrowns));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_DarkGold, ThemeVariationNames.DarkGold));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2013, Properties.Resources.ThemeDisplayName_VisualStudio2013_GalaxyRed, ThemeVariationNames.GalaxyRed));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7, Properties.Resources.ThemeDisplayName_Windows7, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_CoolBlue, ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_DarkBlue, ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_DullBlue, ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_GalaxyRed, ThemeVariationNames.GalaxyRed));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch, Properties.Resources.ThemeDisplayName_Windows8Touch, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch, Properties.Resources.ThemeDisplayName_Windows8Touch_GalaxyRed, ThemeVariationNames.GalaxyRed));

            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Crystal, Properties.Resources.ThemeDisplayName_Crystal, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Fluent, Properties.Resources.ThemeDisplayName_Fluent, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Green, Properties.Resources.ThemeDisplayName_Green, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Material, Properties.Resources.ThemeDisplayName_Material, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016, Properties.Resources.ThemeDisplayName_Office2016, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Office2016Touch, Properties.Resources.ThemeDisplayName_Office2016Touch, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.VisualStudio2019, Properties.Resources.ThemeDisplayName_VisualStudio2019, string.Empty));


            Themes = new ReadOnlyObservableCollection<ThemeNameValuePair>(_themes);

            string defaultTheme = Settings.Default.Theme;
            string defaultVariation = Settings.Default.ThemeVariation;
            foreach (ThemeNameValuePair theme in _themes)
            {
                if (theme.AssemblyName == defaultTheme && theme.VariationName == defaultVariation)
                {
                    SelectedTheme = theme;
                    break;
                }
            }
        }

        private void InitializeGlobals()
        {
            Globals.Instance.Init();
        }
        #endregion

        #region Public properties
        [Import]
        public ServerViewModel ServerViewModel { get; private set; }
        [Import]
        public ClientViewModel ClientViewModel { get; private set; }

        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        public override string ViewTitle
        {
            get
            {
                return Resources.MainView_ApplicationTitle;
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

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName, false);
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password, false);
                }
            }
        }
        public DelegateCommand<object> ExitCommand { get; private set; }
        public DelegateCommand<object> HelpAboutCommand { get; private set; }
        public DelegateCommand<object> CommandA { get; private set; }
        #endregion
    }
}
