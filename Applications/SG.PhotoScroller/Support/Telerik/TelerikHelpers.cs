using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SG.PhotoScroller.ViewModels;
using SG.PhotoScroller.Views;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;

namespace SG.PhotoScroller.Support.Telerik
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

        public static void ShowSignInOutDialog(EventHandler<WindowClosedEventArgs> eventHandler)
        {
            IDialogService dlgService = new DialogService();
            SignInOutView signInOutView = new SignInOutView();

            dlgService.ShowRadDialog(signInOutView, null, Properties.Resources.SignInOutView_Title);
        }

    }
}
