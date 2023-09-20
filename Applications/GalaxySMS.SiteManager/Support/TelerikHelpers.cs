using System;
using System.Windows;
using GalaxySMS.SiteManager.Properties;
using GalaxySMS.SiteManager.Views;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;

namespace GalaxySMS.SiteManager.Support
{
    public static class TelerikHelpers
    {
        public class AlertParameters
        {
            public object Header { get; set; }
            public object Content { get; set; }
        }
        public static void PromptForExit(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            DialogParameters dlgParams = new DialogParameters();

            dlgParams.Content = string.Format(Resources.MainView_Exit_ConfirmationPrompt,
                Globals.Instance.MyAssemblyAtrributes.Title);

            dlgParams.Header = Resources.MainView_Exit_ConfirmationPromptHeader;
            dlgParams.DialogStartupLocation = WindowStartupLocation.CenterOwner;
            dlgParams.OkButtonContent = Resources.MainView_Exit_ConfirmationYesButton;
            dlgParams.CancelButtonContent = Resources.MainView_Exit_ConfirmationNoButton;
            dlgParams.Closed += eventHandler;
            RadWindow.Confirm(dlgParams);
        }
        public static void ShowAlert(DialogParameters dialogParameters)
        {
            RadWindow.Alert(dialogParameters);
        }
        public static void ShowHelpAboutDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            IDialogService dlgService = new DialogService();
            AboutView aboutView = new AboutView();

            dlgService.ShowRadDialog(aboutView, null, string.Format(Resources.AboutView_Title, Globals.Instance.MyAssemblyAtrributes.Title));
        }

        public static void ShowLicenseDetailsDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            IDialogService dlgService = new DialogService();
            LicenseView licenseView = new LicenseView();

            dlgService.ShowRadDialog(licenseView, null, Resources.LicenseView_LicenseDetailsHeader);
        }
    }
}
