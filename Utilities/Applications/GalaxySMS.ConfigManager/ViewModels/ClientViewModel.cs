using GalaxySMS.ConfigManager.Properties;
using GalaxySMS.ConfigManager.Support.Entities;
using GalaxySMS.ConfigManager.Support.Telerik;
using GalaxySMS.ConfigManager.Views;
using GCS.Core.Common.Shared.Extensions;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.Utils;
using GCS.Framework.InstallHelpers;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using static GCS.Framework.InstallHelpers.Helpers;
using Application = System.Windows.Application;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.ConfigManager.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ClientViewModel : ViewModelBase
    {
        #region Private fields
        private Requirements requirements;

        #endregion

        #region Constructor
        [ImportingConstructor]
        public ClientViewModel()
        {
            InstallClientCommand = new DelegateCommand<object>(ExecuteInstallClientCommand, CanExecuteInstallClientCommand);
            InstallPreRequisiteCommand = new DelegateCommand<Requirement>(ExecuteInstallPreRequisiteCommand, CanExecuteInstallPreRequisiteCommand);

            BuildRequirements();
            ScanForRequirementsStatus();

            base.BackgroundSubduedOpacity = .5;
        }

        #endregion

        #region Commands
        public DelegateCommand<Requirement> InstallPreRequisiteCommand { get; private set; }
        public DelegateCommand<object> InstallClientCommand { get; private set; }

        #endregion

        #region Public Properties
        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        public override string ViewTitle
        {
            get
            {
                return Resources.ClientView_Title;
            }
        }


        public Requirements RequiredItems
        {
            get { return requirements; }
            set
            {
                if (requirements != value)
                {
                    requirements = value;
                    OnPropertyChanged(() => RequiredItems, true);
                }
            }
        }


        #endregion

        #region Private Methods

        private bool CanExecuteInstallPreRequisiteCommand(Requirement obj)
        {
            //if( obj != null && obj.Type == RequirementType.MSMQ)
            //    return true;

            if (obj == null || obj.Status == InstallStatus.Installed)
                return false;

            switch (obj.Type)
            {
                case RequirementType.NetFramework_4_8:
                    break;

            }

            return true;
        }

        private async void ExecuteInstallPreRequisiteCommand(Requirement obj)
        {
            if (obj == null)
                return;
            uint valueDetected = 0;
            Globals.IsBusy = true;
            switch (obj.Type)
            {
                case RequirementType.NetFramework_4_8:
                    //InstallDotNetFramework();
                    await InstallDotNetFrameworkAsync();
                    valueDetected = IsDotNetInstalled(valueDetected, obj);
                    break;
            }
            RequiredItems.AllCompleted = false;
            Globals.IsBusy = false;
        }

        private void ShowAlertDialog(MessageBoxView.IconType iconType, string message, string title, bool subdueBackground, EventHandler<WindowClosedEventArgs> eventHandler)
        {
            if (subdueBackground)
                SetBackgroundSubdued();
            TelerikHelpers.ShowAlertDialog(eventHandler, iconType, message, title);
            if (subdueBackground)
                ClearBackgroundSubdued();
        }

        private bool CanExecuteInstallClientCommand(object obj)
        {
            return RequiredItems.AllCompleted;
        }

        private async void ExecuteInstallClientCommand(object obj)
        {
            await InstallClient();

        }

        private async Task InstallClient()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.ClientView_Busy_Content_InstallingClient}. {Resources.PleaseWait}";
            try
            {
                var setupPath = string.Format("{0}\\Installers\\GalaxySMS-Client-Setup.exe", SystemUtilities.MyFolderLocation);
                if (!File.Exists(setupPath))
                {

                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = setupPath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        setupPath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(setupPath))
                {
                    String sMessageTitle = Resources.ClientView_ClientSoftware_Installation_Finished;

                    proc = Process.Start(setupPath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.ClientView_The_ClientSoftware_installation_completed_successfully, sMessageTitle, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.ClientView_ClientSoftware_Install_did_not_succeed, proc.ExitCode), Resources.ClientView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private async Task InstallDotNetFrameworkAsync()
        {
            Globals.Instance.IsBusy = true;
            Globals.BusyContent = $"{Resources.DatabaseView_Busy_Content_InstallingDotNetFramework}. {Resources.PleaseWait}";
            try
            {
                var exePath = $"{SystemUtilities.MyFolderLocation}\\NETFramework\\4.8\\ndp48-x86-x64-allos-enu.exe";
                if (!File.Exists(exePath))
                {

                    var openFolderDialog = new RadOpenFileDialog()
                    {
                        Filter = "Setup Applications|*.exe",
                        Owner = Application.Current.MainWindow,
                        FileName = exePath

                    };
                    openFolderDialog.ShowDialog();
                    if (openFolderDialog.DialogResult == true)
                    {
                        exePath = openFolderDialog.FileName;
                    }
                }

                Process proc = null;
                if (File.Exists(exePath))
                {
                    String sMessageTitle = Resources.DatabaseView_DOTNETFramework_Installation_Finished;

                    proc = Process.Start(exePath, string.Empty);

                    if (proc != null)
                    {
                        await proc.WaitForExitAsync();
                        if (proc.ExitCode == 0)
                        {   // SUCCESSFUL
                            ShowAlertDialog(MessageBoxView.IconType.Success, Resources.DatabaseView_The_DOTNETFramework_installation_completed_successfully, Resources.DatabaseView_Installation_Finished, true, OnShowAlertClosed);
                        }
                        else
                        {
                            ShowAlertDialog(MessageBoxView.IconType.Warning, string.Format(Resources.DatabaseView_DOTNETFramework_Install_did_not_succeed, proc.ExitCode), Resources.DatabaseView_Installation_Error, true, OnShowAlertClosed);
                        }
                    }
                }
                //else
                //    System.Diagnostics.Process.Start("https://aka.ms/ssmsfullsetup");

            }
            catch (FileNotFoundException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (ArgumentException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (Win32Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (ObjectDisposedException ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            catch (Exception ex)
            {
                ShowAlertDialog(MessageBoxView.IconType.Stop, ex.Message, Resources.ClientView_Error, true, OnShowAlertClosed);
            }
            Globals.Instance.IsBusy = false;
        }

        private void OnShowAlertClosed(object sender, WindowClosedEventArgs e)
        {
            ClearBackgroundSubdued();
        }

        private async void ScanForRequirementsStatus()
        {
            //Globals.IsBusy = true;
            uint valueDetected = 0;
            foreach (var r in RequiredItems.Items)
            {
                switch (r.Type)
                {
                    case RequirementType.NetFramework_4_8:
                        valueDetected = IsDotNetInstalled(valueDetected, r);
                        break;

                }
            }
            RequiredItems.AllCompleted = false;
            //Globals.IsBusy = false;
        }

        private uint IsDotNetInstalled(uint valueDetected, Requirement r)
        {
            if (Helpers.IsDotNetInstalled("v4", r.AcceptableValues, ref valueDetected) == true)
                r.Status = InstallStatus.Installed;
            else
                r.Status = InstallStatus.NotInstalled;
            r.ValueDetected = valueDetected;
            return valueDetected;
        }

        private void BuildRequirements()
        {
            int orderNumber = 0;
            RequiredItems = new Requirements();
            var req = new Requirement()
            {
                Type = RequirementType.NetFramework_4_8,
                OrderNumber = orderNumber++,
                Title = Resources.Requirement_NETFramework4_8_Title,
                Description = Resources.Requirement_NETFramework4_8_Desc,
            };
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48Win10May2019Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48WindowsMay2019Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48WindowsMay2020Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v48Windows11Server2022Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v481Windows112022Update);
            req.AcceptableValues.Add(NetFramework4xReleaseNumbers.v481Windows2022Update);
            RequiredItems.Items.Add(req);

        }

        #endregion

        #region Protected methods
        protected override void OnViewLoaded()
        {
            ClearCustomErrors();
        }

        #endregion
    }
}
