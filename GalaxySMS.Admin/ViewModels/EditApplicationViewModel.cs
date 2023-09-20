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
    public class EditApplicationViewModel : ViewModelBase
    {
        public EditApplicationViewModel(IServiceFactory serviceFactory, gcsApplication application)
        {
            _ServiceFactory = serviceFactory;

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);

            _ApplicationManager = new ApplicationManager(Globals.Instance.ServerConnections[0]);
            _ApplicationManager.SaveApplicationCompletedEvent += ApplicationManager_OnSaveApplicationCompletedEvent;
            _ApplicationManager.ErrorsOccurredEvent += ApplicationManager_OnErrorsOccurredEvent;

            _Application = new gcsApplication(application);
            _Application.CleanAll();
            if (application.ApplicationId != Guid.Empty)
            {
                MaintainRolesViewModel = new MaintainRolesViewModel(_ServiceFactory, Application);
                MaintainRolesViewModel.RoleSaved += MaintainRolesViewModel_RoleSaved;
                MaintainRolesViewModel.RoleDeleted += MaintainRolesViewModel_RoleDeleted;

                MaintainPermissionCategoriesViewModel = new MaintainPermissionCategoriesViewModel(_ServiceFactory, Application);
                MaintainPermissionCategoriesViewModel.PermissionCategorySaved += MaintainPermissionCategoriesViewModel_PermissionCategorySaved;
                MaintainPermissionCategoriesViewModel.PermissionCategoryDeleted += MaintainPermissionCategoriesViewModel_PermissionCategoryDeleted;
            }
            _Roles = Globals.Instance.GetRolesForApplication(Application.ApplicationId);

        }

        private void MaintainPermissionCategoriesViewModel_PermissionCategoryDeleted(object sender, PermissionCategoryEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.PermissionCategory.ApplicationId == _Application.ApplicationId)
                {
                    foreach (var permissionCategory in Application.PermissionCategories)
                    {
                        if (permissionCategory.PermissionCategoryId == e.PermissionCategory.PermissionCategoryId)
                        {
                            Application.PermissionCategories.Remove(permissionCategory);
                            break;
                        }
                    }
                }
            });
        }

        private void MaintainPermissionCategoriesViewModel_PermissionCategorySaved(object sender, PermissionCategoryEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.IsNew == true)
                {
                    Application.PermissionCategories.Add(e.PermissionCategory);
                }
                else
                {

                    if (e.PermissionCategory.ApplicationId == _Application.ApplicationId)
                    {
                        foreach (var permissionCategory in Application.PermissionCategories)
                        {
                            if (permissionCategory.PermissionCategoryId == e.PermissionCategory.PermissionCategoryId)
                            {
                                Application.PermissionCategories.Remove(permissionCategory);
                                Application.PermissionCategories.Add(e.PermissionCategory);
                                break;
                            }
                        }
                    }
                }
            });
        }

        private void ApplicationManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void ApplicationManager_OnSaveApplicationCompletedEvent(object sender, SaveApplicationCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Application != null)
                {
                    if (ApplicationUpdated != null)
                        ApplicationUpdated(this, new ApplicationEventArgs(e.Application, e.IsNew));
                }
            });
        }

        void MaintainRolesViewModel_RoleDeleted(object sender, RoleEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Role.EntityId == _Application.ApplicationId)
                {
                    foreach (var role in Roles)
                    {
                        if (role.RoleId == e.Role.RoleId)
                        {
                            Roles.Remove(role);
                            break;
                        }
                    }
                }
            });
        }

        void MaintainRolesViewModel_RoleSaved(object sender, RoleEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.IsNew == true)
                {
                    Roles.Add(e.Role);
                }
                else
                {
                    
                    if (e.Role.EntityId == _Application.ApplicationId)
                    {
                        foreach (var role in Roles)
                        {
                            if (role.RoleId == e.Role.RoleId)
                            {
                                //bool thisIsSystemRoleId = false;
                                //if (Application.SystemRoleId == role.RoleId)
                                //    thisIsSystemRoleId = true;
                                Roles.Remove(role);
                                Roles.Add(e.Role);
                                //if (thisIsSystemRoleId == true)
                                //    Application.SystemRoleId = e.Role.RoleId;
                                //OnPropertyChanged(() => Application.SystemRoleId);
                                break;
                            }
                        }
                        //OnPropertyChanged(() => Roles);
                    }
                }
            });
        }

        IServiceFactory _ServiceFactory;
        gcsApplication _Application;
        ApplicationManager _ApplicationManager;
        private ObservableCollection<gcsRole> _Roles;
         
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public event EventHandler CancelEditApplication;
        public event EventHandler<ApplicationEventArgs> ApplicationUpdated;

        [Import]
        public MaintainRolesViewModel MaintainRolesViewModel { get; private set; }

        [Import]
        public MaintainPermissionCategoriesViewModel MaintainPermissionCategoriesViewModel { get; private set; }

        public gcsApplication Application
        {
            get { return _Application; }
        }

        public ObservableCollection<gcsLanguage> Languages
        { get { return Globals.Instance.Languages; } }

        public ObservableCollection<gcsRole> Roles
        {
            get
            {
                return _Roles;
            }
        }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Application);
        }

        void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                bool isNew = (_Application.ApplicationId == Guid.Empty);
                var saveParams = new SaveParameters<gcsApplication>(_Application);
                if (UseAsyncServiceCalls == false)
                {

                    var savedApplication = _ApplicationManager.SaveApplication(saveParams);
                    if (savedApplication != null)
                    {
                        if (ApplicationUpdated != null)
                            ApplicationUpdated(this, new ApplicationEventArgs(savedApplication, isNew));
                    }
                }
                else
                {
                    _ApplicationManager.SaveApplicationAsyncWithEvents(saveParams);
                }
            }
        }

        bool OnSaveCommandCanExecute(object arg)
        {
            if (_Application == null)
                return false;

            return _Application.IsDirty;
        }

        void OnCancelCommandExecute(object arg)
        {
            if (CancelEditApplication != null)
                CancelEditApplication(this, EventArgs.Empty);
        }
    }
}
