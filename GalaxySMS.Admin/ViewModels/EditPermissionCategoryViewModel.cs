using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
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
    public class EditPermissionCategoryViewModel : ViewModelBase
    {
        public EditPermissionCategoryViewModel(IServiceFactory serviceFactory, gcsApplication application, gcsPermissionCategory permissionCategory)
        {
            _ServiceFactory = serviceFactory;
            _PermissionCategory = new gcsPermissionCategory(permissionCategory);
            _PermissionCategory.CleanAll();
            CurrentApplication = application;
            CanChangeApplication = true;
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);

            _PermissionCategoryManager = new PermissionCategoryManager(Globals.Instance.ServerConnections[0]);
            _PermissionCategoryManager.SavePermissionCategoryCompletedEvent += PermissionCategoryManager_OnSavePermissionCategoryCompletedEvent;
            _PermissionCategoryManager.ErrorsOccurredEvent += PermissionCategoryManager_OnErrorsOccurredEvent;
            if (_PermissionCategory.PermissionCategoryId != Guid.Empty)
            {
                MaintainPermissionsViewModel = new MaintainPermissionsViewModel(_ServiceFactory, CurrentApplication,  _PermissionCategory);
                MaintainPermissionsViewModel.PermissionSaved += MaintainPermissionsViewModel_PermissionSaved;
                MaintainPermissionsViewModel.PermissionDeleted += MaintainPermissionsViewModel_PermissionDeleted;
            }
        }

        private void MaintainPermissionsViewModel_PermissionDeleted(object sender, PermissionEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Permission.PermissionCategoryId == PermissionCategory.PermissionCategoryId)
                {
                    foreach (var permission in PermissionCategory.Permissions)
                    {
                        if (permission.PermissionId == e.Permission.PermissionId)
                        {
                            PermissionCategory.Permissions.Remove(permission);
                            break;
                        }
                    }
                }
            });
        }

        private void MaintainPermissionsViewModel_PermissionSaved(object sender, PermissionEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.IsNew == true)
                {
                    PermissionCategory.Permissions.Add(e.Permission);
                }
                else
                {

                    if (e.Permission.PermissionCategoryId == PermissionCategory.PermissionCategoryId)
                    {
                        foreach (var permission in PermissionCategory.Permissions)
                        {
                            if (permission.PermissionId == e.Permission.PermissionId)
                            {
                                PermissionCategory.Permissions.Remove(permission);
                                PermissionCategory.Permissions.Add(e.Permission);
                                break;
                            }
                        }
                    }
                }
            });
        }

        private void PermissionCategoryManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void PermissionCategoryManager_OnSavePermissionCategoryCompletedEvent(object sender, SavePermissionCategoryCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.PermissionCategory != null)
                {
                    if (PermissionCategoryUpdated != null)
                        PermissionCategoryUpdated(this, new PermissionCategoryEventArgs(e.PermissionCategory, e.IsNew));
                }
            });
        }

        private bool _CanChangeApplication;
        IServiceFactory _ServiceFactory;
        gcsPermissionCategory _PermissionCategory;
        PermissionCategoryManager _PermissionCategoryManager;

        private gcsApplication _CurrentApplication;
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public event EventHandler CancelEditPermissionCategory;
        public event EventHandler<PermissionCategoryEventArgs> PermissionCategoryUpdated;

        [Import]
        public MaintainPermissionsViewModel MaintainPermissionsViewModel { get; private set; }

        public gcsPermissionCategory PermissionCategory
        {
            get { return _PermissionCategory; }
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

        public bool CanChangeApplication
        {
            get
            {
                return _CanChangeApplication;
            }
            set
            {
                if (_CanChangeApplication != value)
                {
                    _CanChangeApplication = value;
                    OnPropertyChanged(() => CanChangeApplication);
                }
            }
        }
        public ObservableCollection<gcsApplication> Applications
        { get { return Globals.Instance.Applications; } }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(PermissionCategory);
        }

        void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                bool isNew = (_PermissionCategory.PermissionCategoryId == Guid.Empty);
                var saveParams = new SaveParameters<gcsPermissionCategory>(_PermissionCategory);
                if (UseAsyncServiceCalls == false)
                {
                    var savedPermissionCategory = _PermissionCategoryManager.SavePermissionCategory(saveParams);
                    if (savedPermissionCategory != null)
                    {
                        if (PermissionCategoryUpdated != null)
                            PermissionCategoryUpdated(this, new PermissionCategoryEventArgs(savedPermissionCategory, isNew));
                    }
                }
                else
                {
                    _PermissionCategoryManager.SavePermissionCategoryAsync(saveParams);
                }

            }
        }

        bool OnSaveCommandCanExecute(object arg)
        {
            return _PermissionCategory.IsDirty;
        }

        void OnCancelCommandExecute(object arg)
        {
            if (CancelEditPermissionCategory != null)
                CancelEditPermissionCategory(this, EventArgs.Empty);
        }
    }
}
