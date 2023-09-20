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
    public class AccessPortalViewModel : ViewModelBase
    {
        #region Private fields
        private RelayCommand _refreshAccessPortalsCommand;
        private ObservableCollection<AccessPortal> _accessPortals = new ObservableCollection<AccessPortal>();
        private RelayCommand<AccessPortal> _pulseCommand;
        private RelayCommand<AccessPortal> _unlockCommand;
        private RelayCommand<AccessPortal> _lockCommand;
        private RelayCommand<AccessPortal> _enableCommand;
        private RelayCommand<AccessPortal> _disableCommand;
        private RelayCommand<AccessPortal> _requestStatusCommand;

        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public ObservableCollection<AccessPortal> AccessPortals
        {
            get { return _accessPortals; }
            set
            {
                if (_accessPortals != value)
                {
                    _accessPortals = value;
                    OnPropertyChanged(() => AccessPortals, false);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand RefreshAccessPortalsCommand
        {
            get
            {
                return _refreshAccessPortalsCommand
                    ?? (_refreshAccessPortalsCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server retrieves the requested data...";

                            // Use the Globals.GetManager<T> helper method to get a usable UserSessionManager object
                            var mgr = Globals.GetManager<AccessPortalManager>();
                            // Call the GetAccessPortalsForSiteAsync method and save the result.
                            var accessPortals = await mgr.GetAccessPortalsForSiteAsync(new GetParametersWithPhoto()
                            {
                                UniqueId = Globals.CurrentSite.SiteUid,
                                IncludePhoto = false,
                            });

                            if (mgr.HasErrors == false)
                            {
                                if (accessPortals != null)
                                    AccessPortals = accessPortals.Items.ToObservableCollection();
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


        public RelayCommand<AccessPortal> PulseCommand
        {
            get { return _pulseCommand; }
            set
            {
                if (_pulseCommand != value)
                {
                    _pulseCommand = value;
                    OnPropertyChanged(() => PulseCommand, false);
                }
            }
        }


        public RelayCommand<AccessPortal> UnlockCommand
        {
            get { return _unlockCommand; }
            set
            {
                if (_unlockCommand != value)
                {
                    _unlockCommand = value;
                    OnPropertyChanged(() => UnlockCommand, false);
                }
            }
        }


        public RelayCommand<AccessPortal> LockCommand
        {
            get { return _lockCommand; }
            set
            {
                if (_lockCommand != value)
                {
                    _lockCommand = value;
                    OnPropertyChanged(() => LockCommand, false);
                }
            }
        }



        public RelayCommand<AccessPortal> EnableCommand
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



        public RelayCommand<AccessPortal> DisableCommand
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



        public RelayCommand<AccessPortal> RequestStatusCommand
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
        public AccessPortalViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            Globals.Messenger.Register<NotificationMessage<AccessPortalStatusReply>>(this, OnAccessPortalStatusReply);

            PulseCommand = new RelayCommand<AccessPortal>(OnPulseCommand, CanPulseCommand);
            UnlockCommand = new RelayCommand<AccessPortal>(OnUnlockCommand, CanUnlockCommand);
            LockCommand = new RelayCommand<AccessPortal>(OnLockCommand, CanLockCommand);
            EnableCommand = new RelayCommand<AccessPortal>(OnEnableCommand, CanEnableCommand);
            DisableCommand = new RelayCommand<AccessPortal>(OnDisableCommand, CanDisableCommand);
            RequestStatusCommand = new RelayCommand<AccessPortal>(OnRequestStatusCommand, CanRequestStatusCommand);
        }


        private async void OnPulseCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.Pulse);
        }

        bool CanPulseCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.UnlockMomentarily);
        }

        private async void OnLockCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.Lock);
        }

        bool CanLockCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Lock);
        }


        private async void OnUnlockCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.Unlock);
        }

        bool CanUnlockCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Unlock);
        }


        private async void OnEnableCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.Enable);
        }

        bool CanEnableCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Enable);
        }


        private async void OnDisableCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.Disable);
        }

        bool CanDisableCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Disable);
        }


        private async void OnRequestStatusCommand(AccessPortal ap)
        {
            await ExecuteAccessPortalCommand(ap, AccessPortalCommandActionCode.RequestStatus);
        }

        bool CanRequestStatusCommand(AccessPortal arg)
        {
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.RequestStatus);
        }

        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

        private void OnAccessPortalStatusReply(NotificationMessage<AccessPortalStatusReply> obj)
        {
            var ap = AccessPortals.FirstOrDefault(o => o.AccessPortalUid == obj.Content.AccessPortalUid);
            if (ap != null)
                ap.LastStatusReply = obj.Content;

            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.AccessPortalStatus})");
        }
        private async Task ExecuteAccessPortalCommand(AccessPortal ap, AccessPortalCommandActionCode cmdCode)
        {
            Globals.BusyContent = $"Please wait. Sending {cmdCode} to {ap.Name}";
            Globals.IsBusy = true;
            var mgr = Globals.GetManager<AccessPortalManager>();

            var parameters = new CommandParameters<AccessPortalCommandAction>()
            {
                Data = new AccessPortalCommandAction()
                {
                    CommandAction = cmdCode,
                    AccessPortalUid = ap.AccessPortalUid
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };


            CommandResponse<AccessPortalCommandAction> result = null;
            result = await mgr.ExecuteCommandAsync(parameters);

            if (result != null && mgr.HasErrors == false)
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