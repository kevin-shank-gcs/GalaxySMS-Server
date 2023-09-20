using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainPermissionsViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainPermissionsViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsPermission>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsPermission>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _PermissionManager = new PermissionManager(Globals.Instance.ServerConnections[0]);
            _PermissionManager.GetAllPermissionsCompletedEvent += PermissionManager_OnGetAllPermissionsCompletedEvent;
            _PermissionManager.DeletePermissionCompletedEvent += PermissionManager_OnDeletePermissionCompletedEvent;
            _PermissionManager.ErrorsOccurredEvent += PermissionManager_OnErrorsOccurredEvent;
        }

        public MaintainPermissionsViewModel(IServiceFactory serviceFactory, gcsApplication application, gcsPermissionCategory permissionCategory)
        {
            _ServiceFactory = serviceFactory;
            _CurrentApplication = application;
            _PermissionCategory = permissionCategory;

            EditCommand = new DelegateCommand<gcsPermission>(OnEditCommand);
            DeleteCommand = new DelegateCommand<gcsPermission>(OnDeleteCommand);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand);

            _PermissionManager = new PermissionManager(Globals.Instance.ServerConnections[0]);
            _PermissionManager.GetAllPermissionsCompletedEvent += PermissionManager_OnGetAllPermissionsCompletedEvent;
            _PermissionManager.DeletePermissionCompletedEvent += PermissionManager_OnDeletePermissionCompletedEvent;
            _PermissionManager.ErrorsOccurredEvent += PermissionManager_OnErrorsOccurredEvent;
        }

        private void PermissionManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void PermissionManager_OnDeletePermissionCompletedEvent(object sender, DeletePermissionCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Permissions.Remove(e.Permission);
                Globals.Instance.RefreshPermissions();
                var handler = PermissionDeleted;
                if( handler != null )
                    handler(this, new PermissionEventArgs(e.Permission, false));
            });
        }

        private void PermissionManager_OnGetAllPermissionsCompletedEvent(object sender, GetAllPermissionsCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Permissions = new ObservableCollection<gcsPermission>();
                foreach (var permission in e.Permissions)
                {
                    _Permissions.Add(permission);
                }
                OnPropertyChanged(() => Permissions, false);
            });
        }

        IServiceFactory _ServiceFactory;
        PermissionManager _PermissionManager;
        gcsPermissionCategory _PermissionCategory;

        private gcsApplication _CurrentApplication;
        EditPermissionViewModel _CurrentPermissionViewModel;

        public DelegateCommand<gcsPermission> EditCommand { get; private set; }
        public DelegateCommand<gcsPermission> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }


        public event EventHandler<PermissionEventArgs> PermissionSaved;
        public event EventHandler<PermissionEventArgs> PermissionDeleted;

        public override string ViewTitle
        {
            get
            {
                if (PermissionCategory != null)
                    return Properties.Resources.EditApplicationView_PermissionsTitle;
                else
                    return Properties.Resources.MaintainPermissions_Title;
            }
        }

        public gcsApplication CurrentApplication
        {
            get { return _CurrentApplication; }
            set
            {
                if (_CurrentApplication != value)
                {
                    _CurrentApplication = value;
                    OnPropertyChanged(() => CurrentApplication);
                }
            }
        }


        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        public EditPermissionViewModel CurrentPermissionViewModel
        {
            get { return _CurrentPermissionViewModel; }
            set
            {
                if (_CurrentPermissionViewModel != value)
                {
                    _CurrentPermissionViewModel = value;
                    OnPropertyChanged(() => CurrentPermissionViewModel, false);
                }
            }
        }

        ObservableCollection<gcsPermission> _Permissions;

        public ObservableCollection<gcsPermission> Permissions
        {
            get { return _Permissions; }
            set
            {
                if (_Permissions != value)
                {
                    _Permissions = value;
                    OnPropertyChanged(() => Permissions, false);
                }
            }
        }
  
        public gcsPermissionCategory PermissionCategory
        {
            get { return _PermissionCategory; }
            set
            {
                if (_PermissionCategory != value)
                {
                    _PermissionCategory = value;
                    OnPropertyChanged(() => PermissionCategory, false);
                }
            }
        }

        protected override void OnViewLoaded()
        {
            _Permissions = new ObservableCollection<gcsPermission>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsPermission> permissions;
                if (PermissionCategory == null)
                    permissions = _PermissionManager.GetAllPermissions();
                else
                    permissions = _PermissionManager.GetAllPermissionsForPermissionCategory(PermissionCategory);

                foreach (var permission in permissions)
                    _Permissions.Add(permission);
            }
            else
            {
                if (PermissionCategory == null)
                    _PermissionManager.GetAllPermissionsAsync();
                else
                    _PermissionManager.GetAllPermissionsForPermissionCategoryAsync(PermissionCategory);
            }
        }

        private bool OnEditCommandCanExecute(gcsPermission obj)
        {
            return CurrentPermissionViewModel == null;
        }
        
        void OnEditCommand(gcsPermission permission)
        {
            if (permission != null)
            {
                CurrentPermissionViewModel = new EditPermissionViewModel(_ServiceFactory, CurrentApplication, permission);
                if (PermissionCategory != null)
                    CurrentPermissionViewModel.CanChangePermissionCategory = false;
                CurrentPermissionViewModel.PermissionUpdated += CurrentPermissionViewModel_PermissionUpdated;
                CurrentPermissionViewModel.CancelEditPermission += CurrentPermissionViewModel_CancelEvent;
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentPermissionViewModel == null;
        }

        void OnAddNewCommand(object arg)
        {
            var permission = new gcsPermission();
            if (PermissionCategory != null)
            {
                permission.PermissionCategoryId = PermissionCategory.PermissionCategoryId;
            }
            CurrentPermissionViewModel = new EditPermissionViewModel(_ServiceFactory, CurrentApplication, permission);
            CurrentPermissionViewModel.PermissionUpdated += CurrentPermissionViewModel_PermissionUpdated;
            CurrentPermissionViewModel.CancelEditPermission += CurrentPermissionViewModel_CancelEvent;
        }

        void CurrentPermissionViewModel_PermissionUpdated(object sender, PermissionEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    var permission = _Permissions.FirstOrDefault(item => item.PermissionId == e.Permission.PermissionId);
                    if (permission != null)
                    {
                        permission.PermissionCategoryId = e.Permission.PermissionCategoryId;
                        permission.PermissionName = e.Permission.PermissionName;
                        permission.PermissionDescription = e.Permission.PermissionDescription;
                        permission.IsActive = e.Permission.IsActive;
                        permission.ConcurrencyValue = e.Permission.ConcurrencyValue;
                    }
                }
                else
                    _Permissions.Add(e.Permission);

                Globals.Instance.RefreshPermissions();
                CurrentPermissionViewModel = null;
                var handler = PermissionSaved;
                if( handler != null)
                    handler(this, new PermissionEventArgs(e.Permission, e.IsNew));
            });
        }

        void CurrentPermissionViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentPermissionViewModel = null;
        }

        private bool OnDeleteCommandCanExecute(gcsPermission obj)
        {
            return CurrentPermissionViewModel == null;
        }

        void OnDeleteCommand(gcsPermission permission)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(permission.PermissionName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _PermissionManager.DeletePermission(permission);
                    _Permissions.Remove(permission);
                    Globals.Instance.RefreshPermissions();
                }
                else
                {
                    _PermissionManager.DeletePermissionAsync(permission);
                }
            }
        }
    }
}
