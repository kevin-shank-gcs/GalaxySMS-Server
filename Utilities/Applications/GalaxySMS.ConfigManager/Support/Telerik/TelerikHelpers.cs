using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.ConfigManager.ViewModels;
using GalaxySMS.ConfigManager.Views;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;

namespace GalaxySMS.ConfigManager.Support.Telerik
{
    public static class TelerikHelpers
    {
        public static void PromptForExit(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            DialogParameters dlgParams = new DialogParameters();

            dlgParams.Content = string.Format(Properties.Resources.MainView_Exit_ConfirmationPrompt,
                Globals.Instance.MyAssemblyAtrributes.Title);

            dlgParams.Header = Properties.Resources.MainView_Exit_ConfirmationPromptHeader;
            dlgParams.DialogStartupLocation = WindowStartupLocation.CenterOwner;
            dlgParams.OkButtonContent = Properties.Resources.MainView_Exit_ConfirmationYesButton;
            dlgParams.CancelButtonContent = Properties.Resources.MainView_Exit_ConfirmationNoButton;
            dlgParams.Closed += eventHandler;
            RadWindow.Confirm(dlgParams);
        }

        public static void ShowHelpAboutDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            IDialogService dlgService = new DialogService();
            AboutView aboutView = new AboutView();

            dlgService.ShowRadDialog(aboutView, null, string.Format(Properties.Resources.AboutView_Title, Globals.Instance.MyAssemblyAtrributes.Title));
        }

        public static void ShowLicenseDetailsDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            IDialogService dlgService = new DialogService();
            LicenseView licenseView = new LicenseView();

            dlgService.ShowRadDialog(licenseView, null, Properties.Resources.LicenseView_LicenseDetailsHeader);
        }

        
        public static void ShowAlertDialog(EventHandler<WindowClosedEventArgs> eventHandler, MessageBoxView.IconType icon, string message, string title)
        {
            IDialogService dlgService = new DialogService();
            MessageBoxView msgView = new MessageBoxView {Icon = icon, Message = message};

            dlgService.ShowRadDialog(msgView, null, title);
        }


        public static void Alert(string content, string header)
        {
            DialogParameters dlgParams = new DialogParameters();
            dlgParams.Owner = Globals.Instance.MainWindow;
            dlgParams.Content = content;
            dlgParams.Content = new TextBlock() { Text = content, TextWrapping = TextWrapping.Wrap, Width = 400 };
            dlgParams.Header = header;
            dlgParams.DialogStartupLocation = WindowStartupLocation.CenterOwner;

            RadWindow.Alert(dlgParams);
        }
    }
}
