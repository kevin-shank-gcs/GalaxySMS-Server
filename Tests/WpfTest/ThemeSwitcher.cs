using GCS.Framework.Utilities;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using WpfTest.Properties;
using ColorConverter = Telerik.Windows.Controls.ColorEditor.ColorConverter;

namespace WpfTest
{
    public static class ThemeSwitcher
    {
        private static readonly string telerikThemePrefix = "/Telerik.Windows.Themes.";
        private static readonly string telerikThemeAssemblyFolder = ";component/Themes/";
        private static readonly string office2013Theme = "Office2013";
        private static readonly string visualStudio2013Theme = "VisualStudio2013";
        private static readonly string greenTheme = "Green";

        //http://demos.telerik.com/silverlight/Themesgenerator/
        //http://www.telerik.com/help/silverlight/common-styling-appearance-visualstudio2013-theme.html
        //http://www.creativecolorschemes.com/resources/free-color-schemes/
        //http://www.w3schools.com/tags/ref_colorpicker.asp

        public static void SwitchTheme(ThemeNameValuePair themeInfo)
        {

            if (themeInfo == null || themeInfo.AssemblyName == string.Empty)
            {
                themeInfo = new ThemeNameValuePair(ThemeAssemblyNames.Transparent, Resources.ThemeDisplayName_Transparent, string.Empty);
                //return;
            }
            //try
            //{
            //    Application.Current.Resources.MergedDictionaries.Clear();

            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/Brushes.xaml"), UriKind.RelativeOrAbsolute)
            //    });

            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/CommonStyles.xaml"), UriKind.RelativeOrAbsolute)
            //    });

            //     Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //     {
            //         Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadButtonStyle.xaml"), UriKind.RelativeOrAbsolute)
            //     });

            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadListBoxStyle.xaml"), UriKind.RelativeOrAbsolute)
            //    });

            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadGridViewStyle.xaml"), UriKind.RelativeOrAbsolute)
            //    });

            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadDataFormStyle.xaml"), UriKind.RelativeOrAbsolute)
            //    //});


            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/System.Windows.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    });
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Cloud.Controls.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Chart.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Data.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.DataVisualization.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Diagrams.Extensions.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Diagrams.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Docking.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Expressions.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.FixedDocumentViewers.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.FixedDocumentViewersUI.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.GanttView.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Gridview.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.ImageEditor.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Input.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    });
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Navigation.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    });
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Pivot.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.PivotFieldList.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.RibbonView.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.RichTextBoxUI.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Spreadsheet.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    });
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Documents.Proofing.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Documents.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
            //    //});

            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/Brushes.xaml", UriKind.RelativeOrAbsolute)
            //    });
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/CommonStyles.xaml", UriKind.RelativeOrAbsolute)
            //    });
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadButtonStyle.xaml", UriKind.RelativeOrAbsolute)
            //    });
            //    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    {
            //        Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadListBoxStyle.xaml", UriKind.RelativeOrAbsolute)
            //    });
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadGridViewStyle.xaml", UriKind.RelativeOrAbsolute)
            //    //});
            //    //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            //    //{
            //    //    Source = new Uri("pack://application:,,,/GalaxySMS.TelerikWPF.Infrastructure;component/Styles/RadDataFormStyle.xaml", UriKind.RelativeOrAbsolute)
            //    //});





            //    if (themeInfo.AssemblyName == ThemeAssemblyNames.VisualStudio2013)
            //    {
            //        switch (themeInfo.VariationName)
            //        {
            //            case ThemeVariationNames.Green:
            //                VisualStudio2013Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF439462");
            //                VisualStudio2013Palette.Palette.AccentMainColor = (Color)ColorConverter.ColorFromString("#FF439462");
            //                VisualStudio2013Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FFE3DCD3");
            //                VisualStudio2013Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FFA5A099");
            //                VisualStudio2013Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF1E1E1E");
            //                VisualStudio2013Palette.Palette.SemiBasicColor = (Color)ColorConverter.ColorFromString("#64E3DCD3");
            //                VisualStudio2013Palette.Palette.AccentDarkColor = (Color)ColorConverter.ColorFromString("#FF30634A");
            //                VisualStudio2013Palette.Palette.PrimaryColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.SelectedColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.MouseOverColor = (Color)ColorConverter.ColorFromString("#FFB6CFB9");
            //                VisualStudio2013Palette.Palette.ComplementaryColor = (Color)ColorConverter.ColorFromString("#FFDBDDE6");
            //                VisualStudio2013Palette.Palette.HeaderColor = (Color)ColorConverter.ColorFromString("#FF439462");
            //                VisualStudio2013Palette.Palette.AlternativeColor = (Color)ColorConverter.ColorFromString("#FFFDFDFD");
            //                break;

            //            case ThemeVariationNames.DarkOlive:
            //                VisualStudio2013Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FFAFCB1D");
            //                VisualStudio2013Palette.Palette.AccentMainColor = (Color)ColorConverter.ColorFromString("#7F9BB31A");
            //                VisualStudio2013Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FF434343");
            //                VisualStudio2013Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#649C9C9C");
            //                VisualStudio2013Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FFCCCCCC");
            //                VisualStudio2013Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FFDBDBDB");
            //                VisualStudio2013Palette.Palette.SemiBasicColor = (Color)ColorConverter.ColorFromString("#649C9C9C");
            //                VisualStudio2013Palette.Palette.AccentDarkColor = (Color)ColorConverter.ColorFromString("#FF9BB31A");
            //                VisualStudio2013Palette.Palette.PrimaryColor = (Color)ColorConverter.ColorFromString("#FF2F2F2F");
            //                VisualStudio2013Palette.Palette.SelectedColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.MouseOverColor = (Color)ColorConverter.ColorFromString("#669BB31A");
            //                VisualStudio2013Palette.Palette.ComplementaryColor = (Color)ColorConverter.ColorFromString("#FFDADADA");
            //                VisualStudio2013Palette.Palette.HeaderColor = (Color)ColorConverter.ColorFromString("#FF9BB31A");
            //                VisualStudio2013Palette.Palette.AlternativeColor = (Color)ColorConverter.ColorFromString("#FF4E4E4E");
            //                break;

            //            case ThemeVariationNames.EarthtoneBrowns:
            //                VisualStudio2013Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF6D5243");
            //                VisualStudio2013Palette.Palette.AccentMainColor = (Color)ColorConverter.ColorFromString("#FF6D5243");
            //                VisualStudio2013Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FFD5C5C0");
            //                VisualStudio2013Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF81747D");
            //                VisualStudio2013Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF1E1E1E");
            //                VisualStudio2013Palette.Palette.SemiBasicColor = (Color)ColorConverter.ColorFromString("#64D5C5C0");
            //                VisualStudio2013Palette.Palette.AccentDarkColor = (Color)ColorConverter.ColorFromString("#FF493829");
            //                VisualStudio2013Palette.Palette.PrimaryColor = (Color)ColorConverter.ColorFromString("#FFE2DCD9");
            //                VisualStudio2013Palette.Palette.SelectedColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.MouseOverColor = (Color)ColorConverter.ColorFromString("#FFEDEDF1");
            //                VisualStudio2013Palette.Palette.ComplementaryColor = (Color)ColorConverter.ColorFromString("#FFDBDDE6");
            //                VisualStudio2013Palette.Palette.HeaderColor = (Color)ColorConverter.ColorFromString("#FF413128");
            //                VisualStudio2013Palette.Palette.AlternativeColor = (Color)ColorConverter.ColorFromString("#FFF5F5F5");
            //                break;

            //            case ThemeVariationNames.DarkGold:
            //                VisualStudio2013Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FFB59E68");
            //                VisualStudio2013Palette.Palette.AccentMainColor = (Color)ColorConverter.ColorFromString("#FFC9B074");
            //                VisualStudio2013Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FF1E1E1E");
            //                VisualStudio2013Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FF3F3F46");
            //                VisualStudio2013Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF999999");
            //                VisualStudio2013Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FFF1F1F1");
            //                VisualStudio2013Palette.Palette.SemiBasicColor = (Color)ColorConverter.ColorFromString("#643F3F46");
            //                VisualStudio2013Palette.Palette.AccentDarkColor = (Color)ColorConverter.ColorFromString("#FF8D7B51");
            //                VisualStudio2013Palette.Palette.PrimaryColor = (Color)ColorConverter.ColorFromString("#FF2D2D30");
            //                VisualStudio2013Palette.Palette.SelectedColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                VisualStudio2013Palette.Palette.MouseOverColor = (Color)ColorConverter.ColorFromString("#FF3E3E40");
            //                VisualStudio2013Palette.Palette.ComplementaryColor = (Color)ColorConverter.ColorFromString("#FF434346");
            //                VisualStudio2013Palette.Palette.HeaderColor = (Color)ColorConverter.ColorFromString("#FFB59E68");
            //                VisualStudio2013Palette.Palette.AlternativeColor = (Color)ColorConverter.ColorFromString("#FF252526");
            //                break;

            //            case "":
            //                break;

            //            default:
            //                VisualStudio2013Palette.ColorVariation colorVariation = GenericEnums.GetOne<VisualStudio2013Palette.ColorVariation>(themeInfo.VariationName);
            //                VisualStudio2013Palette.LoadPreset(colorVariation);
            //                break;
            //        }

            //    }
            //    else if (themeInfo.AssemblyName == "Office2013")
            //    {
            //        Office2013Palette.ColorVariation colorVariation = GenericEnums.GetOne<Office2013Palette.ColorVariation>(themeInfo.VariationName);
            //        Office2013Palette.LoadPreset(colorVariation);
            //    }
            //    else if (themeInfo.AssemblyName == "Green")
            //    {
            //        GreenPalette.ColorVariation colorVariation = GenericEnums.GetOne<GreenPalette.ColorVariation>(themeInfo.VariationName);
            //        GreenPalette.LoadPreset(colorVariation);
            //    }
            //    if (themeInfo.AssemblyName == "Windows8")
            //    {
            //        switch (themeInfo.VariationName)
            //        {
            //            case "DarkBlue":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF3366CC");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FF000000");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#7F6E6E6E");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FFA7A7A7");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FFE3E3E3");
            //                break;

            //            case "GrayScale":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF828282");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FF333333");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FF999999");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FFDBDBDB");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FFF2F2F2");
            //                break;

            //            case "CoolBlue":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF25A0DA");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FFD6D4D4");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF767676");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF000000");
            //                break;

            //            case "BeachBlue":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF007790");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FF65B6BF");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF434343");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF2F2F2F");
            //                break;

            //            case "BeachSand":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF6E5E52");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FFDE873A");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF434343");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF2F2F2F");
            //                break;

            //            case "GrayOrange":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF999999");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FFFF9900");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF000000");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF000000");
            //                break;

            //            case "DullBlue":
            //                Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ColorFromString("#FF4D8AA7");
            //                Windows8Palette.Palette.MainColor = (Color)ColorConverter.ColorFromString("#FFFFFFFF");
            //                Windows8Palette.Palette.BasicColor = (Color)ColorConverter.ColorFromString("#FF97CAE2");
            //                Windows8Palette.Palette.StrongColor = (Color)ColorConverter.ColorFromString("#FF3A3636");
            //                Windows8Palette.Palette.MarkerColor = (Color)ColorConverter.ColorFromString("#FF000000");
            //                break;
            //            case "":
            //                break;

            //            default:
            //                try
            //                {
            //                    VisualStudio2013Palette.ColorVariation colorVariation = GenericEnums.GetOne<VisualStudio2013Palette.ColorVariation>(themeInfo.VariationName);
            //                    if (colorVariation != null)
            //                        VisualStudio2013Palette.LoadPreset(colorVariation);
            //                }
            //                catch (Exception ex)
            //                {

            //                }
            //                break;
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine($"SwitchTheme error: {ex.Message}");
            //}
            try
            {

                Application.Current.Resources.MergedDictionaries.Clear();

                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/System.Windows.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Input.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Navigation.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });

                foreach (var rd in Application.Current.Resources.MergedDictionaries)
                {
                    if (rd.Contains("RadWindowStyle"))
                    {
                        var s = rd["RadWindowStyle"];
                        var radWindowStyle = s as Style;
                        if (radWindowStyle != null)
                        {
                            foreach (var k in Application.Current.Resources.Keys)
                            {
                                //System.Diagnostics.Trace.WriteLine(k);
                                if (k.ToString().EndsWith(".MainWindow"))
                                {
                                    Application.Current.Resources.Remove(k);
                                    break;
                                }
                            }

                            //Application.Current.Resources.Add(typeof(MainWindow), radWindowStyle);
                            break;
                        }
                    }
                }

                //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                //{
                //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Docking.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                //});
                //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                //{
                //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Gridview.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                //});
                //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                //{
                //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Data.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                //});
                //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                //{
                //    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.ImageEditor.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                //});

                if (themeInfo.AssemblyName == ThemeAssemblyNames.VisualStudio2013)
                {
                    switch (themeInfo.VariationName)
                    {
                        case ThemeVariationNames.Green:
                            VisualStudio2013Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF439462");
                            VisualStudio2013Palette.Palette.AccentMainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF439462");
                            VisualStudio2013Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE3DCD3");
                            VisualStudio2013Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFA5A099");
                            VisualStudio2013Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF1E1E1E");
                            VisualStudio2013Palette.Palette.SemiBasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#64E3DCD3");
                            VisualStudio2013Palette.Palette.AccentDarkColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF30634A");
                            VisualStudio2013Palette.Palette.PrimaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.SelectedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.MouseOverColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFB6CFB9");
                            VisualStudio2013Palette.Palette.ComplementaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDDE6");
                            VisualStudio2013Palette.Palette.HeaderColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF439462");
                            VisualStudio2013Palette.Palette.AlternativeColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFDFDFD");
                            break;

                        case ThemeVariationNames.DarkOlive:
                            VisualStudio2013Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFAFCB1D");
                            VisualStudio2013Palette.Palette.AccentMainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#7F9BB31A");
                            VisualStudio2013Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            VisualStudio2013Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#649C9C9C");
                            VisualStudio2013Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFCCCCCC");
                            VisualStudio2013Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDBDB");
                            VisualStudio2013Palette.Palette.SemiBasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#649C9C9C");
                            VisualStudio2013Palette.Palette.AccentDarkColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF9BB31A");
                            VisualStudio2013Palette.Palette.PrimaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            VisualStudio2013Palette.Palette.SelectedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.MouseOverColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#669BB31A");
                            VisualStudio2013Palette.Palette.ComplementaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDADADA");
                            VisualStudio2013Palette.Palette.HeaderColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF9BB31A");
                            VisualStudio2013Palette.Palette.AlternativeColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF4E4E4E");
                            break;

                        case ThemeVariationNames.EarthtoneBrowns:
                            VisualStudio2013Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF6D5243");
                            VisualStudio2013Palette.Palette.AccentMainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF6D5243");
                            VisualStudio2013Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFD5C5C0");
                            VisualStudio2013Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF81747D");
                            VisualStudio2013Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF1E1E1E");
                            VisualStudio2013Palette.Palette.SemiBasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#64D5C5C0");
                            VisualStudio2013Palette.Palette.AccentDarkColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF493829");
                            VisualStudio2013Palette.Palette.PrimaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE2DCD9");
                            VisualStudio2013Palette.Palette.SelectedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.MouseOverColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFEDEDF1");
                            VisualStudio2013Palette.Palette.ComplementaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDDE6");
                            VisualStudio2013Palette.Palette.HeaderColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF413128");
                            VisualStudio2013Palette.Palette.AlternativeColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF5F5F5");
                            break;

                        case ThemeVariationNames.DarkGold:
                            VisualStudio2013Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFB59E68");
                            VisualStudio2013Palette.Palette.AccentMainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFC9B074");
                            VisualStudio2013Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF1E1E1E");
                            VisualStudio2013Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3F3F46");
                            VisualStudio2013Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF999999");
                            VisualStudio2013Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF1F1F1");
                            VisualStudio2013Palette.Palette.SemiBasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#643F3F46");
                            VisualStudio2013Palette.Palette.AccentDarkColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF8D7B51");
                            VisualStudio2013Palette.Palette.PrimaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2D2D30");
                            VisualStudio2013Palette.Palette.SelectedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.MouseOverColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3E3E40");
                            VisualStudio2013Palette.Palette.ComplementaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434346");
                            VisualStudio2013Palette.Palette.HeaderColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFB59E68");
                            VisualStudio2013Palette.Palette.AlternativeColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF252526");
                            break;

                        case ThemeVariationNames.GalaxyRed:
                            VisualStudio2013Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#AABB1E03");
                            VisualStudio2013Palette.Palette.AccentMainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#AABB1E03");
                            VisualStudio2013Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFCCCEDB");
                            VisualStudio2013Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF717171");
                            VisualStudio2013Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF1E1E1E");
                            VisualStudio2013Palette.Palette.SemiBasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#66CCCEDB");
                            VisualStudio2013Palette.Palette.AccentDarkColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBB1E03");
                            VisualStudio2013Palette.Palette.PrimaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFEEEEF2");
                            VisualStudio2013Palette.Palette.SelectedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            VisualStudio2013Palette.Palette.MouseOverColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF5D8C9");
                            VisualStudio2013Palette.Palette.ComplementaryColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDDE6");
                            VisualStudio2013Palette.Palette.HeaderColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBB1E03");
                            VisualStudio2013Palette.Palette.AlternativeColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF5F5F5");
                            break;

                        case "":
                            break;

                        default:
                            VisualStudio2013Palette.ColorVariation colorVariation = GCS.Framework.Utilities.GenericEnums.GetOne<VisualStudio2013Palette.ColorVariation>(themeInfo.VariationName);
                            if (colorVariation != null)
                                VisualStudio2013Palette.LoadPreset(colorVariation);
                            break;
                    }

                }
                else if (themeInfo.AssemblyName == ThemeAssemblyNames.Office2013)
                {
                    switch (themeInfo.VariationName)
                    {
                        case ThemeVariationNames.GalaxyRed:
                            Office2013Palette.Palette.AccentColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBC1E03");
                            Office2013Palette.Palette.AccentMainColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBC1E03");
                            Office2013Palette.Palette.MainColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Office2013Palette.Palette.BasicColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFDFDFD");
                            Office2013Palette.Palette.StrongColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF444444");
                            Office2013Palette.Palette.InvertedColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Office2013Palette.Palette.EffectAccentLowColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#33BC1E03");
                            Office2013Palette.Palette.MediumLightColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE1E1E1");
                            Office2013Palette.Palette.EffectAccentHighColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#33BC1E03");
                            Office2013Palette.Palette.EffectLowColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#33FFFFFF");
                            Office2013Palette.Palette.EffectHighColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#33000000");
                            Office2013Palette.Palette.LowLightMainColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF1F1F1");
                            Office2013Palette.Palette.LowLightColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF1F1F1");
                            Office2013Palette.Palette.LowDarkColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Office2013Palette.Palette.MediumDarkColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDEDEDE");
                            Office2013Palette.Palette.HighLightColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFD4D4D4");
                            Office2013Palette.Palette.HighDarkColor =
                                (Color)
                                    Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFABABAB");
                            break;

                        default:
                            Office2013Palette.ColorVariation colorVariation = GCS.Framework.Utilities.GenericEnums.GetOne<Office2013Palette.ColorVariation>(themeInfo.VariationName);
                            if (colorVariation != null)
                            {
                                Office2013Palette.LoadPreset(colorVariation);
                            }

                            break;
                    }
                }
                else if (themeInfo.AssemblyName == ThemeAssemblyNames.Windows8Touch)
                {
                    switch (themeInfo.VariationName)
                    {
                        case ThemeVariationNames.GalaxyRed:
                            Windows8TouchPalette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBB1E03");
                            Windows8TouchPalette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8TouchPalette.Palette.MediumColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFCCCCCC");
                            Windows8TouchPalette.Palette.HighColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF767676");
                            Windows8TouchPalette.Palette.LowColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE9E9E9");
                            Windows8TouchPalette.Palette.InvertedColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8TouchPalette.Palette.InvertedForegroundColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8TouchPalette.Palette.MainForegroundColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8TouchPalette.Palette.EffectHighColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8TouchPalette.Palette.EffectLowColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE1E1E1");
                            break;
                    }
                }
                if (themeInfo.AssemblyName == ThemeAssemblyNames.Windows8)
                {
                    switch (themeInfo.VariationName)
                    {
                        case ThemeVariationNames.DarkBlue:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3366CC");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#7F6E6E6E");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFA7A7A7");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE3E3E3");
                            break;

                        case ThemeVariationNames.GrayScale:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF828282");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF333333");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF999999");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDBDB");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF2F2F2");
                            break;

                        case ThemeVariationNames.CoolBlue:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF25A0DA");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFD6D4D4");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF767676");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            break;

                        case ThemeVariationNames.BeachBlue:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF007790");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF65B6BF");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            break;

                        case ThemeVariationNames.BeachSand:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF6E5E52");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDE873A");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            break;

                        case ThemeVariationNames.GrayOrange:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF999999");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFF9900");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            break;

                        case ThemeVariationNames.DullBlue:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF4D8AA7");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF97CAE2");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3A3636");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            break;

                        case ThemeVariationNames.GalaxyRed:
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFBC1E03");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFCCCCCC");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            break;
                        case "":
                            break;

                        default:
                            try
                            {
                                VisualStudio2013Palette.ColorVariation colorVariation = GCS.Framework.Utilities.GenericEnums.GetOne<VisualStudio2013Palette.ColorVariation>(themeInfo.VariationName);
                                if (colorVariation != null)
                                    VisualStudio2013Palette.LoadPreset(colorVariation);
                            }
                            catch (Exception ex)
                            {

                            }
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"SwitchTheme error: {ex.Message}" );
            }

        }
    }
}
