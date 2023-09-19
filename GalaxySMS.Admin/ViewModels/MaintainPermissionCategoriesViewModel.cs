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
    public class MaintainPermissionCategoriesViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainPermissionCategoriesViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsPermissionCategory>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsPermissionCategory>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _permissionCategoryManager = new PermissionCategoryManager(Globals.Instance.ServerConnections[0]);
            _permissionCategoryManager.GetAllPermissionCategoriesCompletedEvent += PermissionCategoryManager_OnGetAllPermissionCategoriesCompletedEvent;
            _permissionCategoryManager.DeletePermissionCategoryCompletedEvent += PermissionCategoryManager_OnDeletePermissionCategoryCompletedEvent;
            _permissionCategoryManager.ErrorsOccurredEvent += PermissionCategoryManager_OnErrorsOccurredEvent;
        }

        public MaintainPermissionCategoriesViewModel(IServiceFactory serviceFactory, gcsApplication application)
        {
            _ServiceFactory = serviceFactory;
            _Application = application;

            EditCommand = new DelegateCommand<gcsPermissionCategory>(OnEditCommand);
            DeleteCommand = new DelegateCommand<gcsPermissionCategory>(OnDeleteCommand);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand);

            _permissionCategoryManager = new PermissionCategoryManager(Globals.Instance.ServerConnections[0]);
            _permissionCategoryManager.GetAllPermissionCategoriesCompletedEvent += PermissionCategoryManager_OnGetAllPermissionCategoriesCompletedEvent;
            _permissionCategoryManager.DeletePermissionCategoryCompletedEvent += PermissionCategoryManager_OnDeletePermissionCategoryCompletedEvent;
            _permissionCategoryManager.ErrorsOccurredEvent += PermissionCategoryManager_OnErrorsOccurredEvent;
        }

        private void PermissionCategoryManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void PermissionCategoryManager_OnDeletePermissionCategoryCompletedEvent(object sender, DeletePermissionCategoryCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _PermissionCategories.Remove(e.PermissionCategory);
                //Globals.Instance.RefreshPermissionCategories();
                var handler = PermissionCategoryDeleted;
                if( handler != null )
                    handler(this, new PermissionCategoryEventArgs(e.PermissionCategory, false));
            });
        }

        private void PermissionCategoryManager_OnGetAllPermissionCategoriesCompletedEvent(object sender, GetAllPermissionCategoriesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _PermissionCategories = new ObservableCollection<gcsPermissionCategory>();
                foreach (var permission in e.PermissionCategories)
                {
                    _PermissionCategories.Add(permission);
                }
                OnPropertyChanged(() => PermissionCategories, false);
            });
        }

        IServiceFactory _ServiceFactory;
        PermissionCategoryManager _permissionCategoryManager;
        gcsApplication _Application;
        gcsPermissionCategory _PermissionCategory;

        EditPermissionCategoryViewModel _CurrentPermissionCategoryViewModel;

        public DelegateCommand<gcsPermissionCategory> EditCommand { get; private set; }
        public DelegateCommand<gcsPermissionCategory> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }


        public event EventHandler<PermissionCategoryEventArgs> PermissionCategorySaved;
        public event EventHandler<PermissionCategoryEventArgs> PermissionCategoryDeleted;

        public override string ViewTitle
        {
            get
            {
                if (Application != null)
                    return Properties.Resources.EditApplicationView_PermissionCategoriesTitle;
                else
                    return Properties.Resources.MaintainPermissionCategories_Title;
            }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        public EditPermissionCategoryViewModel CurrentPermissionCategoryViewModel
        {
            get { return _CurrentPermissionCategoryViewModel; }
            set
            {
                if (_CurrentPermissionCategoryViewModel != value)
                {
                    _CurrentPermissionCategoryViewModel = value;
                    OnPropertyChanged(() => CurrentPermissionCategoryViewModel, false);
                }
            }
        }

        ObservableCollection<gcsPermissionCategory> _PermissionCategories;

        public ObservableCollection<gcsPermissionCategory> PermissionCategories
        {
            get { return _PermissionCategories; }
            set
            {
                if (_PermissionCategories != value)
                {
                    _PermissionCategories = value;
                    OnPropertyChanged(() => PermissionCategories, false);
                }
            }
        }

        public gcsApplication Application
        {
            get { return _Application; }
            set
            {
                if (_Application != value)
                {
                    _Application = value;
                    OnPropertyChanged(() => Application, false);
                }
            }
        }

        protected override void OnViewLoaded()
        {
            _PermissionCategories = new ObservableCollection<gcsPermissionCategory>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsPermissionCategory> permissions;
                if (Application == null)
                    permissions = _permissionCategoryManager.GetAllPermissionCategories();
                else
                    permissions = _permissionCategoryManager.GetAllPermissionCategoriesForApplication(Application);

                foreach (var permission in permissions)
                    _PermissionCategories.Add(permission);
            }
            else
            {
                if (Application == null)
                    _permissionCategoryManager.GetAllPermissionCategoriesAsync();
                else
                    _permissionCategoryManager.GetAllPermissionCategoriesForApplicationAsync(Application);
            }
        }

        private bool OnEditCommandCanExecute(gcsPermissionCategory obj)
        {
            return CurrentPermissionCategoryViewModel == null;
        }
        
        void OnEditCommand(gcsPermissionCategory permissionCategory)
        {
            if (permissionCategory != null)
            {
                CurrentPermissionCategoryViewModel = new EditPermissionCategoryViewModel(_ServiceFactory, Application, permissionCategory);
                if (Application != null)
                    CurrentPermissionCategoryViewModel.CanChangeApplication = false;
                CurrentPermissionCategoryViewModel.PermissionCategoryUpdated += CurrentPermissionCategoryViewModel_PermissionCategoryUpdated;
                CurrentPermissionCategoryViewModel.CancelEditPermissionCategory += CurrentPermissionCategoryViewModel_CancelEvent;
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentPermissionCategoryViewModel == null;
        }

        void OnAddNewCommand(object arg)
        {
            var permissionCategory = new gcsPermissionCategory();
            if (Application != null)
            {
                permissionCategory.ApplicationId = Application.ApplicationId;
            }
            CurrentPermissionCategoryViewModel = new EditPermissionCategoryViewModel(_ServiceFactory, Application, permissionCategory);
            CurrentPermissionCategoryViewModel.PermissionCategoryUpdated += CurrentPermissionCategoryViewModel_PermissionCategoryUpdated;
            CurrentPermissionCategoryViewModel.CancelEditPermissionCategory += CurrentPermissionCategoryViewModel_CancelEvent;
        }

        void CurrentPermissionCategoryViewModel_PermissionCategoryUpdated(object sender, PermissionCategoryEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    var permissionCategory = _PermissionCategories.FirstOrDefault(item => item.PermissionCategoryId == e.PermissionCategory.PermissionCategoryId);
                    if (permissionCategory != null)
                    {
                        permissionCategory.CategoryName = e.PermissionCategory.CategoryName;
                        permissionCategory.PermissionCategoryDescription = e.PermissionCategory.PermissionCategoryDescription;
                        permissionCategory.ApplicationId = e.PermissionCategory.ApplicationId;
                        permissionCategory.IsEntityCategory = e.PermissionCategory.IsEntityCategory;
                        permissionCategory.IsSystemCategory = e.PermissionCategory.IsSystemCategory;
 //                       permissionCategory.gcsPermissions = e.PermissionCategory.gcsPermissions.ToCollection();
                        permissionCategory.Permissions = e.PermissionCategory.Permissions;
                        permissionCategory.ConcurrencyValue = e.PermissionCategory.ConcurrencyValue;
                    }
                }
                else
                    _PermissionCategories.Add(e.PermissionCategory);

                Globals.Instance.RefreshPermissionCategories();
                CurrentPermissionCategoryViewModel = null;
                var handler = PermissionCategorySaved;
                if( handler != null)
                    handler(this, new PermissionCategoryEventArgs(e.PermissionCategory, e.IsNew));
            });
        }

        void CurrentPermissionCategoryViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentPermissionCategoryViewModel = null;
        }

        private bool OnDeleteCommandCanExecute(gcsPermissionCategory obj)
        {
            return CurrentPermissionCategoryViewModel == null;
        }

        void OnDeleteCommand(gcsPermissionCategory permissionCategory)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(permissionCategory.CategoryName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _permissionCategoryManager.DeletePermissionCategory(permissionCategory);
                    _PermissionCategories.Remove(permissionCategory);
                    Globals.Instance.RefreshPermissionCategories();
                }
                else
                {
                    _permissionCategoryManager.DeletePermissionCategoryAsync(permissionCategory);
                }

            }
        }
    }
}
