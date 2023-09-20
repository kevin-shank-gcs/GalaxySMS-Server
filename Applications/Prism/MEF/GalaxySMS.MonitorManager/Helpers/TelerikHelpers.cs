using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaxySMS.MonitorManager.Properties;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Utilities;
using Telerik.Windows.Controls;
using LocalResources = GalaxySMS.MonitorManager.Properties;

namespace GalaxySMS.MonitorManager.Helpers
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

            dlgParams.Content = string.Format(LocalResources.Resources.Exit_ConfirmationPrompt,
                SystemUtilities.GetEntryAssemblyAttributes().Title);

            dlgParams.Header = LocalResources.Resources.Exit_ConfirmationPromptHeader;
            dlgParams.DialogStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            dlgParams.OkButtonContent = LocalResources.Resources.Exit_ConfirmationYesButton;
            dlgParams.CancelButtonContent = LocalResources.Resources.Exit_ConfirmationNoButton;
            dlgParams.Closed += eventHandler;
            RadWindow.Confirm(dlgParams);
        }


        public static void Confirm(DialogParameters dlgParams)
        {
            RadWindow.Confirm(dlgParams);
        }

        public static void ShowAlert(DialogParameters dialogParameters)
        {
            RadWindow.Alert(dialogParameters);
        }
        //public static void ShowHelpAboutDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        //{
        //    IDialogService dlgService = new DialogService();
        //    AboutView aboutView = new AboutView();

        //    dlgService.ShowRadDialog(aboutView, null, string.Format(Resources.AboutView_Title, Globals.Instance.MyAssemblyAtrributes.Title));
        //}

        //public static void ShowLicenseDetailsDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        //{
        //    IDialogService dlgService = new DialogService();
        //    LicenseView licenseView = new LicenseView();

        //    dlgService.ShowRadDialog(licenseView, null, Resources.LicenseView_LicenseDetailsHeader);
        //}
        //public static void ShowUpdateLicenseDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        //{
        //    IDialogService dlgService = new DialogService();
        //    LicenseView licenseView = new LicenseView(true);

        //    dlgService.ShowRadDialog(licenseView, null, Resources.LicenseView_LicenseDetailsHeader);
        //}
    }

}
