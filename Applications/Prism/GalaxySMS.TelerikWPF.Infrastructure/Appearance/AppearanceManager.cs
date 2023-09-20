using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GalaxySMS.TelerikWPF.Infrastructure.Analytics;
using GalaxySMS.TelerikWPF.Infrastructure.Appearance;
using Telerik.Windows.Controls;

namespace GalaxySMS.TelerikWPF.Infrastructure.Appearance
{
    public static class AppearanceManager
    {
        private static readonly string telerikThemePrefix = "/Telerik.Windows.Themes.";
        private static readonly string telerikThemeAssemblyFolder = ";component/Themes/";
        private static readonly string office2013Theme = "Office2013";
        private static readonly string visualStudio2013Theme = "VisualStudio2013";
        private static readonly string greenTheme = "Green";

        private static ColorVariations currentColorVariation = ColorVariations.Light;

        public static void ChangeAppearance(Themes theme, ColorVariations colorVariation)
        {
            string analyticsFeatureName = string.Concat(EqatecConstants.Theme, ".", theme.ToString());
            EqatecMonitor.Instance.TrackFeature(analyticsFeatureName);

            if (currentColorVariation != colorVariation)
            {
                //change Background
                switch (colorVariation)
                {
                    case ColorVariations.Light:
                        ThemePalette.Palette.Background = ThemePalette.LightBackgroundColor;
                        ThemePalette.Palette.Foreground = ThemePalette.LightForegroundColor;
                        ThemePalette.Palette.AlternativeBackground = ThemePalette.LightAlternativeBackgroundColor;
                        break;
                    case ColorVariations.Dark:
                        ThemePalette.Palette.Background = ThemePalette.DarkBackgroundColor;
                        ThemePalette.Palette.Foreground = ThemePalette.DarkForegroundColor;
                        ThemePalette.Palette.AlternativeBackground = ThemePalette.DarkAlternativeBackgroundColor;
                        break;
                    case ColorVariations.ExpressionDark:
                        ThemePalette.Palette.Background = ThemePalette.ExpressionDarkBackgroundColor;
                        ThemePalette.Palette.Foreground = ThemePalette.DarkForegroundColor;
                        ThemePalette.Palette.AlternativeBackground = ThemePalette.DarkAlternativeBackgroundColor;
                        break;
                    default:
                        break;
                }

                currentColorVariation = colorVariation;
            }

            string themeAssembly = GetThemeAssemblyName(theme.ToString());
            SetTheme(themeAssembly);
            SetThemeSpecific(theme);
            OnThemeChanged(theme, colorVariation);
        }

        private static void SetThemeSpecific(Themes theme)
        {
            switch (theme)
            {
                case Themes.Windows8:
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = Windows8Palette.Palette.AccentColor;
                    break;
                case Themes.Office2013:
                    Office2013Palette.LoadPreset(Office2013Palette.ColorVariation.White);
                    ThemePalette.Palette.FontFamily = new FontFamily("Calibri");
                    ThemePalette.Palette.AccentBrush = Office2013Palette.Palette.AccentColor;
                    break;
                case Themes.Office2013_LightGray:
                    Office2013Palette.LoadPreset(Office2013Palette.ColorVariation.LightGray);
                    ThemePalette.Palette.FontFamily = new FontFamily("Calibri");
                    ThemePalette.Palette.AccentBrush = Office2013Palette.Palette.AccentColor;
                    break;
                case Themes.Office2013_DarkGray:
                    Office2013Palette.LoadPreset(Office2013Palette.ColorVariation.DarkGray);
                    ThemePalette.Palette.FontFamily = new FontFamily("Calibri");
                    ThemePalette.Palette.AccentBrush = Office2013Palette.Palette.AccentColor;
                    break;
                case Themes.VisualStudio2013:
                    VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Light);
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = VisualStudio2013Palette.Palette.AccentDarkColor;
                    break;
                case Themes.VisualStudio2013_Blue:
                    VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Blue);
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = VisualStudio2013Palette.Palette.AccentDarkColor;
                    break;
                case Themes.VisualStudio2013_Dark:
                    VisualStudio2013Palette.LoadPreset(VisualStudio2013Palette.ColorVariation.Dark);
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = VisualStudio2013Palette.Palette.AccentDarkColor;
                    break;
                case Themes.Green_Light:
                    GreenPalette.LoadPreset(GreenPalette.ColorVariation.Light);
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = GreenPalette.Palette.AccentLowColor;
                    break;
                case Themes.Green_Dark:
                    GreenPalette.LoadPreset(GreenPalette.ColorVariation.Dark);
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = GreenPalette.Palette.AccentLowColor;
                    break;
                case Themes.Expression_Dark:
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = ThemePalette.AccentBrushColor;
                    break;
                default:
                    ThemePalette.Palette.FontFamily = new FontFamily("Segoe UI");
                    ThemePalette.Palette.AccentBrush = ThemePalette.AccentBrushColor;
                    break;
            }
        }

        private static string GetThemeAssemblyName(string theme)
        {
            if (theme.Contains(office2013Theme))
            {
                return office2013Theme;
            }
            else if (theme.Contains(visualStudio2013Theme))
            {
                return visualStudio2013Theme;
            }
            if (theme.Contains(greenTheme))
            {
                return greenTheme;
            }
            else
            {
                return theme;
            }
        }

        private static void SetTheme(string theme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "System.Windows.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.Data.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.Input.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.Navigation.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.ScheduleView.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.GridView.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.DataVisualization.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri(string.Concat(telerikThemePrefix, theme, telerikThemeAssemblyFolder, "Telerik.Windows.Controls.Chart.xaml"), UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/Brushes.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/CommonStyles.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/RadButtonStyle.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/RadListBoxStyle.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/RadGridViewStyle.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/CRM.Theme;component/Styles/RadDataFormStyle.xaml", UriKind.RelativeOrAbsolute)
            });
        }

        public static event EventHandler<AppearanceChangedEventArgs> ThemeChanged;
        private static void OnThemeChanged(Themes theme, ColorVariations colorVariation)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged(null, new AppearanceChangedEventArgs(theme, colorVariation));
            }
        }
    }
}
