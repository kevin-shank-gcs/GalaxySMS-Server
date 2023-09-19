using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.ViewModels
{
    public class EditPermissionViewModel : ViewModelBase
    {
        public EditPermissionViewModel(IServiceFactory serviceFactory, gcsApplication application, gcsPermission permission)
        {
            _ServiceFactory = serviceFactory;
            _CurrentApplication = application;
            _Permission = new gcsPermission(permission);
            _Permission.CleanAll();

            CanChangePermissionCategory = true;
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);

            _PermissionManager = new PermissionManager(Globals.Instance.ServerConnections[0]);
            _PermissionManager.SavePermissionCompletedEvent += PermissionManager_OnSavePermissionCompletedEvent;
            _PermissionManager.ErrorsOccurredEvent += PermissionManager_OnErrorsOccurredEvent;

        }

        private void PermissionManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void PermissionManager_OnSavePermissionCompletedEvent(object sender, SavePermissionCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Permission != null)
                {
                    if (PermissionUpdated != null)
                        PermissionUpdated(this, new PermissionEventArgs(e.Permission, e.IsNew));
                }
            });
        }

        private bool _canChangePermissionCategory;
        IServiceFactory _ServiceFactory;
        gcsPermission _Permission;
        readonly PermissionManager _PermissionManager;

        private gcsApplication _CurrentApplication;
        private gcsPermissionCategory _currentPermissionCategory;
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public event EventHandler CancelEditPermission;
        public event EventHandler<PermissionEventArgs> PermissionUpdated;

        public gcsPermission Permission
        {
            get { return _Permission; }
        }

        public gcsPermissionCategory CurrentPermissionCategory
        {
            get { return _currentPermissionCategory; }
            set
            {
                if (_currentPermissionCategory != value)
                {
                    _currentPermissionCategory = value;
                    OnPropertyChanged(() => CurrentPermissionCategory);
                }
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

        public bool CanChangePermissionCategory
        {
            get
            {
                return _canChangePermissionCategory;
            }
            set
            {
                if (_canChangePermissionCategory != value)
                {
                    _canChangePermissionCategory = value;
                    OnPropertyChanged(() => CanChangePermissionCategory);
                }
            }
        }

        public ObservableCollection<gcsPermissionCategory> PermissionCategories
        { get { return CurrentApplication.PermissionCategories.ToObservableCollection(); } }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Permission);
        }

        void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                bool isNew = (_Permission.PermissionId == Guid.Empty);
                var saveParams = new SaveParameters<gcsPermission>(_Permission);
                if (UseAsyncServiceCalls == false)
                {
                    var savedPermission = _PermissionManager.SavePermission(saveParams);
                    if (savedPermission != null)
                    {
                        if (PermissionUpdated != null)
                            PermissionUpdated(this, new PermissionEventArgs(savedPermission, isNew));
                    }
                }
                else
                {
                    _PermissionManager.SavePermissionAsync(saveParams);
                }

            }
        }

        bool OnSaveCommandCanExecute(object arg)
        {
            return _Permission.IsDirty;
        }

        void OnCancelCommandExecute(object arg)
        {
            if (CancelEditPermission != null)
                CancelEditPermission(this, EventArgs.Empty);
        }
    }
}
