using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainRolesViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainRolesViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsRole>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsRole>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _RoleManager = new RoleManager(Globals.Instance.ServerConnections[0]);
            _RoleManager.GetAllRolesCompletedEvent += RoleManager_OnGetAllRolesCompletedEvent;
            _RoleManager.DeleteRoleCompletedEvent += RoleManager_OnDeleteRoleCompletedEvent;
            _RoleManager.ErrorsOccurredEvent += RoleManager_OnErrorsOccurredEvent;
        }

        public MaintainRolesViewModel(IServiceFactory serviceFactory, gcsApplication application)
        {
            _ServiceFactory = serviceFactory;
            _Application = application;

            EditCommand = new DelegateCommand<gcsRole>(OnEditCommand);
            DeleteCommand = new DelegateCommand<gcsRole>(OnDeleteCommand);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand);

            _RoleManager = new RoleManager(Globals.Instance.ServerConnections[0]);
            _RoleManager.GetAllRolesCompletedEvent += RoleManager_OnGetAllRolesCompletedEvent;
            _RoleManager.DeleteRoleCompletedEvent += RoleManager_OnDeleteRoleCompletedEvent;
            _RoleManager.ErrorsOccurredEvent += RoleManager_OnErrorsOccurredEvent;
        }
        private void RoleManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void RoleManager_OnDeleteRoleCompletedEvent(object sender, DeleteRoleCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Roles.Remove(e.Role);
                Globals.Instance.RefreshRoles();
                var handler = RoleDeleted;
                if (handler != null)
                    handler(this, new RoleEventArgs(e.Role, false));
            });
        }

        private void RoleManager_OnGetAllRolesCompletedEvent(object sender, GetAllRolesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Roles = new ObservableCollection<gcsRole>();
                foreach (gcsRole role in e.Roles)
                {
                    _Roles.Add(role);
                }
                OnPropertyChanged(() => Roles, false);
            });
        }

        IServiceFactory _ServiceFactory;
        RoleManager _RoleManager;
        gcsApplication _Application;

        EditRoleViewModel _CurrentRoleViewModel;

        public DelegateCommand<gcsRole> EditCommand { get; private set; }
        public DelegateCommand<gcsRole> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }


        public event EventHandler<RoleEventArgs> RoleSaved;
        public event EventHandler<RoleEventArgs> RoleDeleted;

        public override string ViewTitle
        {
            get
            {
                if (Application != null)
                    return Properties.Resources.EditApplicationView_RolesTitle;
                else
                    return Properties.Resources.MaintainRoles_Title;
            }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        public EditRoleViewModel CurrentRoleViewModel
        {
            get { return _CurrentRoleViewModel; }
            set
            {
                if (_CurrentRoleViewModel != value)
                {
                    _CurrentRoleViewModel = value;
                    OnPropertyChanged(() => CurrentRoleViewModel, false);
                }
            }
        }

        ObservableCollection<gcsRole> _Roles;

        public ObservableCollection<gcsRole> Roles
        {
            get { return _Roles; }
            set
            {
                if (_Roles != value)
                {
                    _Roles = value;
                    OnPropertyChanged(() => Roles, false);
                }
            }
        }

        public ObservableCollection<gcsApplication> Applications
        {
            get { return Globals.Instance.Applications; }

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
            _Roles = new ObservableCollection<gcsRole>();
            var parameters = new GetParametersWithPhoto()
            {
                IncludeMemberCollections = true
            };
            if (Application != null)
                parameters.UniqueId = Application.ApplicationId;
            ArrayResponse<gcsRole> roles = null;

            if (UseAsyncServiceCalls == false)
            {
                if (Application == null)
                    roles = _RoleManager.GetAllRoles(parameters);
                else
                    roles = _RoleManager.GetAllRolesForEntity(parameters);
            }
            else
            {
                if (Application == null)
                {
                    Task.Run(async () =>
                   {
                       roles = await _RoleManager.GetAllRolesAsync(parameters);
                   }).Wait();
                }
                else
                {
                    Task.Run(async () =>
                   {
                       roles = await _RoleManager.GetAllRolesForEntityAsync(parameters);
                   }).Wait();
                }
            }
            foreach (var role in roles.Items)
                _Roles.Add(role);
        }

        private bool OnEditCommandCanExecute(gcsRole obj)
        {
            return CurrentRoleViewModel == null;
        }

        async void OnEditCommand(gcsRole role)
        {
            if (role != null)
            {
                role = await _RoleManager.GetRoleAsync(new GetParametersWithPhoto() { UniqueId = role.RoleId, IncludeMemberCollections = true, RefreshCache = true});
                CurrentRoleViewModel = new EditRoleViewModel(_ServiceFactory, role);
                if (Application != null)
                    CurrentRoleViewModel.CanChangeEntity = false;
                CurrentRoleViewModel.RoleUpdated += CurrentRoleViewModel_RoleUpdated;
                CurrentRoleViewModel.CancelEditRole += CurrentRoleViewModel_CancelEvent;
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentRoleViewModel == null;
        }

        void OnAddNewCommand(object arg)
        {
            gcsRole role = new gcsRole();
            if (Application != null)
            {
                role.EntityId = Application.ApplicationId;
            }
            CurrentRoleViewModel = new EditRoleViewModel(_ServiceFactory, role);
            CurrentRoleViewModel.RoleUpdated += CurrentRoleViewModel_RoleUpdated;
            CurrentRoleViewModel.CancelEditRole += CurrentRoleViewModel_CancelEvent;
        }

        void CurrentRoleViewModel_RoleUpdated(object sender, RoleEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    gcsRole role = _Roles.Where(item => item.RoleId == e.Role.RoleId).FirstOrDefault();
                    if (role != null)
                    {
                        role.RoleName = e.Role.RoleName;
                        role.RoleDescription = e.Role.RoleDescription;
                        role.IsActive = e.Role.IsActive;
                        role.IsDefault = e.Role.IsDefault;
                        role.IsAdministratorRole = e.Role.IsAdministratorRole;
                        role.ConcurrencyValue = e.Role.ConcurrencyValue;
                        role.RolePermissions = e.Role.RolePermissions.ToCollection();
                        //role.gcsEntityApplicationRoles = e.Role.gcsEntityApplicationRoles.ToCollection();
                    }
                }
                else
                    _Roles.Add(e.Role);

                Globals.Instance.RefreshRoles();
                CurrentRoleViewModel = null;
                var handler = RoleSaved;
                if (handler != null)
                    handler(this, new RoleEventArgs(e.Role, e.IsNew));
            });
        }

        void CurrentRoleViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentRoleViewModel = null;
        }

        //void OnDeleteCommand(gcsRole role)
        //{
        //    ClearCustomErrors();

        //    CancelEventArgs args = new CancelEventArgs();
        //    if (ConfirmDelete != null)
        //        ConfirmDelete(this, args);
        //    if (!args.Cancel)
        //    {

        //        if (UseAsyncServiceCalls == false)
        //        {
        //            try
        //            {
        //                WithClient<IAdministrationService>(
        //                    _ServiceFactory.CreateClient<IAdministrationService>(),
        //                    proxy =>
        //                    {
        //                        proxy.DeleteRole(role.RoleId);
        //                        App.Current.Dispatcher.Invoke((Action)delegate
        //                        {
        //                            _Roles.Remove(role);
        //                        });
        //                    });
        //            }
        //            catch (FaultException<ExceptionDetail> ex)
        //            {
        //                AddCustomError(new CustomError(ex.Detail));
        //            }
        //            catch (FaultException<ExceptionDetailEx> ex)
        //            {
        //                AddCustomError(new CustomError(ex.Detail));
        //            }
        //            catch (Exception ex)
        //            {
        //                AddCustomError(new CustomError(ex.Message));

        //            }
        //        }
        //        else
        //        {
        //            WithClientAsync<IAdministrationService>(
        //                _ServiceFactory.CreateClient<IAdministrationService>(), async proxy =>
        //                {
        //                    if (proxy != null)
        //                    {
        //                        Func<Task> task = async () =>
        //                        {
        //                            Task tDelete = proxy.DeleteRoleAsync(role.RoleId);
        //                            await tDelete;
        //                            App.Current.Dispatcher.Invoke((Action)delegate
        //                            {
        //                                _Roles.Remove(role);
        //                            });
        //                        };

        //                        try
        //                        {
        //                            task().Wait();
        //                        }
        //                        catch (AggregateException ae)
        //                        {
        //                            ae = ae.Flatten();
        //                            foreach (Exception ex in ae.InnerExceptions)
        //                            {
        //                                AddCustomError(new CustomError(ex.Message));
        //                                this.Log().Debug(ex.Message);
        //                            }
        //                        }
        //                    }
        //                });
        //        }

        //    }
        //}

        private bool OnDeleteCommandCanExecute(gcsRole obj)
        {
            return CurrentRoleViewModel == null;
        }

        void OnDeleteCommand(gcsRole role)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(role.RoleName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _RoleManager.DeleteRole(role);
                    _Roles.Remove(role);
                    Globals.Instance.RefreshRoles();
                }
                else
                {
                    _RoleManager.DeleteRoleAsync(role);
                }

            }
        }
    }
}
