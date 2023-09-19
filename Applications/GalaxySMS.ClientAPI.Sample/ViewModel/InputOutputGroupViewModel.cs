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
    public class InputOutputGroupViewModel : ViewModelBase
    {
        #region Private fields
        private RelayCommand _refreshInputOutputGroupsCommand;
        private ObservableCollection<InputOutputGroup> _inputOutputGroups = new ObservableCollection<InputOutputGroup>();
        private RelayCommand<InputOutputGroup> _armCommand;
        private RelayCommand<InputOutputGroup> _disarmCommand;
        private RelayCommand<InputOutputGroup> _unshuntCommand;
        private RelayCommand<InputOutputGroup> _shuntCommand;
        private RelayCommand<InputOutputGroup> _unlockAccessPortalGroupCommand;
        private RelayCommand<InputOutputGroup> _lockAccessPortalGroupCommand;
        private RelayCommand<InputOutputGroup> _enableAccessPortalGroupCommand;
        private RelayCommand<InputOutputGroup> _disableAccessPortalGroupCommand;
        //private RelayCommand<InputOutputGroup> _requestStatusCommand;

        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public ObservableCollection<InputOutputGroup> InputOutputGroups
        {
            get { return _inputOutputGroups; }
            set
            {
                if (_inputOutputGroups != value)
                {
                    _inputOutputGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand RefreshInputOutputGroupsCommand
        {
            get
            {
                return _refreshInputOutputGroupsCommand
                    ?? (_refreshInputOutputGroupsCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server retrieves the requested data...";

                            // Use the Globals.GetManager<T> helper method to get a usable UserSessionManager object
                            var mgr = Globals.GetManager<GalaxyInputOutputGroupManager>();

                            var parameters = new GetParametersWithPhoto
                            {
                                UniqueId = Globals.CurrentUserEntity.EntityId,
                                IncludePhoto = false };

                            parameters.AddOption(GetInputDeviceOption.IsNodeActiveValue.ToString(), true);
                            // Call the GetInputOutputGroupsForSiteAsync method and save the result.
                            var inputDevices = await mgr.GetAllInputOutputGroupsForEntityAsync(parameters);

                            if (mgr.HasErrors == false)
                            {
                                if (inputDevices != null)
                                    InputOutputGroups = inputDevices.Items.ToObservableCollection();
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


        public RelayCommand<InputOutputGroup> UnshuntCommand
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


        public RelayCommand<InputOutputGroup> ShuntCommand
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


        public RelayCommand<InputOutputGroup> ArmCommand
        {
            get { return _armCommand; }
            set
            {
                if (_armCommand != value)
                {
                    _armCommand = value;
                    OnPropertyChanged(() => ArmCommand, false);
                }
            }
        }


        public RelayCommand<InputOutputGroup> DisarmCommand
        {
            get { return _disarmCommand; }
            set
            {
                if (_disarmCommand != value)
                {
                    _disarmCommand = value;
                    OnPropertyChanged(() => DisarmCommand, false);
                }
            }
        }


        public RelayCommand<InputOutputGroup> LockAccessPortalGroupCommand
        {
            get { return _lockAccessPortalGroupCommand; }
            set
            {
                if (_lockAccessPortalGroupCommand != value)
                {
                    _lockAccessPortalGroupCommand = value;
                    OnPropertyChanged(() => LockAccessPortalGroupCommand, false);
                }
            }
        }


        public RelayCommand<InputOutputGroup> UnlockAccessPortalGroupCommand
        {
            get { return _unlockAccessPortalGroupCommand; }
            set
            {
                if (_unlockAccessPortalGroupCommand != value)
                {
                    _unlockAccessPortalGroupCommand = value;
                    OnPropertyChanged(() => UnlockAccessPortalGroupCommand, false);
                }
            }
        }


        public RelayCommand<InputOutputGroup> EnableAccessPortalGroupCommand
        {
            get { return _enableAccessPortalGroupCommand; }
            set
            {
                if (_enableAccessPortalGroupCommand != value)
                {
                    _enableAccessPortalGroupCommand = value;
                    OnPropertyChanged(() => EnableAccessPortalGroupCommand, false);
                }
            }
        }


        public RelayCommand<InputOutputGroup> DisableAccessPortalGroupCommand
        {
            get { return _disableAccessPortalGroupCommand; }
            set
            {
                if (_disableAccessPortalGroupCommand != value)
                {
                    _disableAccessPortalGroupCommand = value;
                    OnPropertyChanged(() => DisableAccessPortalGroupCommand, false);
                }
            }
        }



        //public RelayCommand<InputOutputGroup> RequestStatusCommand
        //{
        //    get { return _requestStatusCommand; }
        //    set
        //    {
        //        if (_requestStatusCommand != value)
        //        {
        //            _requestStatusCommand = value;
        //            OnPropertyChanged(() => RequestStatusCommand, false);
        //        }
        //    }
        //}

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public InputOutputGroupViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            //Globals.Messenger.Register<NotificationMessage<InputOutputGroupStatusReply>>(this, OnInputOutputGroupStatusReply);

            UnshuntCommand = new RelayCommand<InputOutputGroup>(OnUnshuntCommand, CanUnshuntCommand);
            ShuntCommand = new RelayCommand<InputOutputGroup>(OnShuntCommand, CanShuntCommand);
            ArmCommand = new RelayCommand<InputOutputGroup>(OnArmCommand, CanArmCommand);
            DisarmCommand = new RelayCommand<InputOutputGroup>(OnDisarmCommand, CanDisarmCommand);

            UnlockAccessPortalGroupCommand = new RelayCommand<InputOutputGroup>(OnUnlockAccessPortalGroupCommand, CanUnlockAccessPortalGroupCommand);
            LockAccessPortalGroupCommand = new RelayCommand<InputOutputGroup>(OnLockAccessPortalGroupCommand, CanLockAccessPortalGroupCommand);
            EnableAccessPortalGroupCommand = new RelayCommand<InputOutputGroup>(OnEnableAccessPortalGroupCommand, CanEnableAccessPortalGroupCommand);
            DisableAccessPortalGroupCommand = new RelayCommand<InputOutputGroup>(OnDisableAccessPortalGroupCommand, CanDisableAccessPortalGroupCommand);
            //RequestStatusCommand = new RelayCommand<InputOutputGroup>(OnRequestStatusCommand, CanRequestStatusCommand);
        }

        private async void OnShuntCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.Shunt);
        }

        bool CanShuntCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Shunt);
        }


        private async void OnUnshuntCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.Unshunt);
        }

        bool CanUnshuntCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Unshunt);
        }


        private async void OnArmCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.Arm);
        }

        bool CanArmCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Arm);
        }


        private async void OnDisarmCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.Disarm);
        }

        bool CanDisarmCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSInputOutputGroupCommandPermission.Disarm);
        }

        private async void OnUnlockAccessPortalGroupCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.UnlockAccessPortals);
        }

        bool CanUnlockAccessPortalGroupCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Unlock);
        }

        private async void OnLockAccessPortalGroupCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.LockAccessPortals);
        }

        bool CanLockAccessPortalGroupCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Lock);
        }

        private async void OnEnableAccessPortalGroupCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.EnableAccessPortals);
        }

        bool CanEnableAccessPortalGroupCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Enable);
        }

        private async void OnDisableAccessPortalGroupCommand(InputOutputGroup ap)
        {
            await ExecuteInputOutputGroupCommand(ap, InputOutputGroupCommandActionCode.DisableAccessPortals);
        }

        bool CanDisableAccessPortalGroupCommand(InputOutputGroup arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalGroupCommandPermission.Disable);
        }






        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

        private async Task ExecuteInputOutputGroupCommand(InputOutputGroup ap, InputOutputGroupCommandActionCode cmdCode)
        {
            Globals.BusyContent = $"Please wait. Sending {cmdCode} to {ap.Display}";
            Globals.IsBusy = true;
            var mgr = Globals.GetManager<GalaxyInputOutputGroupManager>();

            var parameters = new CommandParameters<InputOutputGroupCommandAction>()
            {
                Data = new InputOutputGroupCommandAction()
                {
                    CommandAction = cmdCode,
                    InputOutputGroupUid = ap.InputOutputGroupUid
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };


            bool bResult = false;
            bResult = await mgr.ExecuteCommandAsync(parameters);

            if (bResult == true && mgr.HasErrors == false)
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