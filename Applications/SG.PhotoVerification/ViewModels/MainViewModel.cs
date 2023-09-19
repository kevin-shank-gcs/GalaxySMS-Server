using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SG.PhotoVerification.Properties;
using SG.PhotoVerification.Support.Telerik;
using SG.PhotoVerification.Themes;
using GCS.Core.Common.UI.Core;
using SG.PhotoVerification.Views;
using System.Windows;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace SG.PhotoVerification.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewModel : ViewModelBase
    {
        #region Private fields
        private ObservableCollection<ThemeNameValuePair> _themes = new ObservableCollection<ThemeNameValuePair>();
        private ThemeNameValuePair _selectedTheme;
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
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows7, Properties.Resources.ThemeDisplayName_Windows7, string.Empty));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_CoolBlue, ThemeVariationNames.CoolBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_GrayScale, ThemeVariationNames.GrayScale));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_DarkBlue, ThemeVariationNames.DarkBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_BeachBlue, ThemeVariationNames.BeachBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_BeachSand, ThemeVariationNames.BeachSand));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_GrayOrange, ThemeVariationNames.GrayOrange));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8, Properties.Resources.ThemeDisplayName_Windows8_DullBlue, ThemeVariationNames.DullBlue));
            _themes.Add(new ThemeNameValuePair(ThemeAssemblyNames.Windows8Touch, Properties.Resources.ThemeDisplayName_Windows8Touch, string.Empty));
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
        }
        #endregion

        #region Public properties
        [Import]
        public SampleViewModel SampleViewModel { get; private set; }

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

        public DelegateCommand<object> ExitCommand { get; private set; }
        public DelegateCommand<object> HelpAboutCommand { get; private set; }
        #endregion
    }
}
