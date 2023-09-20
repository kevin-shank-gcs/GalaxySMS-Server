using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class InputDeviceViewModel : ViewModelBase
    {
        #region Private fields
        private RelayCommand _refreshInputDevicesCommand;
        private ObservableCollection<InputDevice> _inputDevices = new ObservableCollection<InputDevice>();
        private RelayCommand<InputDevice> _unshuntCommand;
        private RelayCommand<InputDevice> _shuntCommand;
        private RelayCommand<InputDevice> _enableCommand;
        private RelayCommand<InputDevice> _disableCommand;
        private RelayCommand<InputDevice> _requestStatusCommand;

        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public ObservableCollection<InputDevice> InputDevices
        {
            get { return _inputDevices; }
            set
            {
                if (_inputDevices != value)
                {
                    _inputDevices = value;
                    OnPropertyChanged(() => InputDevices, false);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand RefreshInputDevicesCommand
        {
            get
            {
                return _refreshInputDevicesCommand
                    ?? (_refreshInputDevicesCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server retrieves the requested data...";

                            // Use the Globals.GetManager<T> helper method to get a usable UserSessionManager object
                            var mgr = Globals.GetManager<InputDeviceManager>();
                            // Call the GetInputDevicesForSiteAsync method and save the result.
                            var accessPortals = await mgr.GetInputDevicesForSiteAsync(new GetParametersWithPhoto()
                            {
                                UniqueId = Globals.CurrentSite.SiteUid,
                                IncludePhoto = false,
                            });

                            if (mgr.HasErrors == false)
                            {
                                if (accessPortals != null)
                                    InputDevices = accessPortals.Items.ToObservableCollection();
                            }
                            else
                                base.AddCustomErrors(mgr.Errors, true);

                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name} exception", e);
                        }
                        Globals.IsBusy = false;

                    }));
            }
        }


        public RelayCommand<InputDevice> UnshuntCommand
        {
            get { return _unshuntCommand; }
            set
            {
                if (_unshuntCommand != value)
                {
                    _unshuntCommand = value;
                    OnPropertyChanged(() => UnshuntCommand, false);
                }
            }
        }


        public RelayCommand<InputDevice> ShuntCommand
        {
            get { return _shuntCommand; }
            set
            {
                if (_shuntCommand != value)
                {
                    _shuntCommand = value;
                    OnPropertyChanged(() => ShuntCommand, false);
                }
            }
        }



        public RelayCommand<InputDevice> EnableCommand
        {
            get { return _enableCommand; }
            set
            {
                if (_enableCommand != value)
                {
                    _enableCommand = value;
                    OnPropertyChanged(() => EnableCommand, false);
                }
            }
        }



        public RelayCommand<InputDevice> DisableCommand
        {
            get { return _disableCommand; }
            set
            {
                if (_disableCommand != value)
                {
                    _disableCommand = value;
                    OnPropertyChanged(() => DisableCommand, false);
                }
            }
        }



        public RelayCommand<InputDevice> RequestStatusCommand
        {
            get { return _requestStatusCommand; }
            set
            {
                if (_requestStatusCommand != value)
                {
                    _requestStatusCommand = value;
                    OnPropertyChanged(() => RequestStatusCommand, false);
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public InputDeviceViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            Globals.Messenger.Register<NotificationMessage<InputDeviceStatusReply>>(this, OnInputDeviceStatusReply);

            UnshuntCommand = new RelayCommand<InputDevice>(OnUnshuntCommand, CanUnshuntCommand);
            ShuntCommand = new RelayCommand<InputDevice>(OnShuntCommand, CanShuntCommand);
            EnableCommand = new RelayCommand<InputDevice>(OnEnableCommand, CanEnableCommand);
            DisableCommand = new RelayCommand<InputDevice>(OnDisableCommand, CanDisableCommand);
            RequestStatusCommand = new RelayCommand<InputDevice>(OnRequestStatusCommand, CanRequestStatusCommand);
        }

        private async void OnShuntCommand(InputDevice ap)
        {
            await ExecuteInputDeviceCommand(ap, InputDeviceCommandActionCode.Shunt);
        }

        bool CanShuntCommand(InputDevice arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputCommandPermission.Shunt);
        }


        private async void OnUnshuntCommand(InputDevice ap)
        {
            await ExecuteInputDeviceCommand(ap, InputDeviceCommandActionCode.Unshunt);
        }

        bool CanUnshuntCommand(InputDevice arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputCommandPermission.Unshunt);
        }


        private async void OnEnableCommand(InputDevice ap)
        {
            await ExecuteInputDeviceCommand(ap, InputDeviceCommandActionCode.Enable);
        }

        bool CanEnableCommand(InputDevice arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputCommandPermission.Enable);
        }


        private async void OnDisableCommand(InputDevice ap)
        {
            await ExecuteInputDeviceCommand(ap, InputDeviceCommandActionCode.Disable);
        }

        bool CanDisableCommand(InputDevice arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputCommandPermission.Disable);
        }


        private async void OnRequestStatusCommand(InputDevice ap)
        {
            await ExecuteInputDeviceCommand(ap, InputDeviceCommandActionCode.RequestStatus);
        }

        bool CanRequestStatusCommand(InputDevice arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputCommandPermission.RequestStatus);
        }

        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

        private void OnInputDeviceStatusReply(NotificationMessage<InputDeviceStatusReply> obj)
        {
            var id = InputDevices.FirstOrDefault(o => o.InputDeviceUid == obj.Content.InputDeviceUid);
            if (id != null)
                id.LastStatusReply = obj.Content;

            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.ArmedStatus}, {obj?.Content.ContactStatus}, {obj?.Content.MonitoringStatus})");
        }
        private async Task ExecuteInputDeviceCommand(InputDevice ap, InputDeviceCommandActionCode cmdCode)
        {
            Globals.BusyContent = $"Please wait. Sending {cmdCode} to {ap.Name}";
            Globals.IsBusy = true;
            var mgr = Globals.GetManager<InputDeviceManager>();

            var parameters = new CommandParameters<InputDeviceCommandAction>()
            {
                Data = new InputDeviceCommandAction()
                {
                    CommandAction = cmdCode,
                    InputDeviceUid = ap.InputDeviceUid
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<InputDeviceCommandAction> bResult = null;
            bResult = await mgr.ExecuteCommandAsync(parameters);

            if (bResult != null && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;

        }
    }
}