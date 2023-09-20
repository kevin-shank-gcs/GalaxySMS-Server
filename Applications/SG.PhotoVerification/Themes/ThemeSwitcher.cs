using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace SG.PhotoVerification.Themes
{
    public static class ThemeSwitcher
    {
        //http://demos.telerik.com/silverlight/Themesgenerator/
        //http://www.telerik.com/help/silverlight/common-styling-appearance-visualstudio2013-theme.html
        //http://www.creativecolorschemes.com/resources/free-color-schemes/
        //http://www.w3schools.com/tags/ref_colorpicker.asp

        public static void SwitchTheme(ThemeNameValuePair themeInfo)
        {

            if (themeInfo == null || themeInfo.AssemblyName == string.Empty)
            {
                themeInfo = new ThemeNameValuePair(ThemeAssemblyNames.Transparent, Properties.Resources.ThemeDisplayName_Transparent, string.Empty);
                //return;
            }
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
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Docking.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Gridview.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(string.Format("/Telerik.Windows.Themes.{0};component/Themes/Telerik.Windows.Controls.Data.xaml", themeInfo.AssemblyName), UriKind.RelativeOrAbsolute)
                });

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

                        case "":
                            break;

                        default:
                            VisualStudio2013Palette.ColorVariation colorVariation = GCS.Framework.Utilities.GenericEnums.GetOne<VisualStudio2013Palette.ColorVariation>(themeInfo.VariationName);
                            if (colorVariation != null)
                                VisualStudio2013Palette.LoadPreset(colorVariation);
                            break;
                    }

                }
                else if (themeInfo.AssemblyName == "Office2013")
                {
                    Office2013Palette.ColorVariation colorVariation = GCS.Framework.Utilities.GenericEnums.GetOne<Office2013Palette.ColorVariation>(themeInfo.VariationName);
                    if (colorVariation != null)
                        Office2013Palette.LoadPreset(colorVariation);
                }
                if (themeInfo.AssemblyName == "Windows8")
                {
                    switch (themeInfo.VariationName)
                    {
                        case "DarkBlue":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3366CC");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#7F6E6E6E");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFA7A7A7");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFE3E3E3");
                            break;

                        case "GrayScale":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF828282");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF333333");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF999999");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDBDBDB");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFF2F2F2");
                            break;

                        case "CoolBlue":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF25A0DA");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFD6D4D4");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF767676");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            break;

                        case "BeachBlue":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF007790");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF65B6BF");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            break;

                        case "BeachSand":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF6E5E52");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFDE873A");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF434343");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF2F2F2F");
                            break;

                        case "GrayOrange":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF999999");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFF9900");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
                            break;

                        case "DullBlue":
                            Windows8Palette.Palette.AccentColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF4D8AA7");
                            Windows8Palette.Palette.MainColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFFFFFFF");
                            Windows8Palette.Palette.BasicColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF97CAE2");
                            Windows8Palette.Palette.StrongColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF3A3636");
                            Windows8Palette.Palette.MarkerColor = (Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FF000000");
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
                GCS.Core.Common.Logger.LogManager.GetLogger<Exception>().ErrorFormat("SwitchTheme error: {0}", ex.Message);
            }

        }
    }

}
