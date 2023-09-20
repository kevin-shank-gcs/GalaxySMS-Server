using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace GCS.Framework.UI.Telerik.WPF
{
    public static class TelerikHelpers
    {
        public class AlertParameters
        {
            public object Header { get; set; }
            public object Content { get; set; }
        }

        public static void PromptForExit(EventHandler<WindowClosedEventArgs> eventHandler, object content, object header, object okButtonContent, object cancelButtonContent)
        {
            DialogParameters dlgParams = new DialogParameters();

            dlgParams.Content = content;

            dlgParams.Header = header;
            dlgParams.DialogStartupLocation = WindowStartupLocation.CenterOwner;
            dlgParams.OkButtonContent = okButtonContent;
            dlgParams.CancelButtonContent = cancelButtonContent;
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
