using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.SiteManager.Properties;
using GalaxySMS.SiteManager.Support;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySMS.SiteManager.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainUsersViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainUsersViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsUser>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsUser>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.GetAllUsersCompletedEvent += UserManager_OnGetAllUsersCompletedEvent;
            _UserManager.DeleteUserCompletedEvent += UserManager_OnDeleteUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
        }



        public MaintainUsersViewModel(IServiceFactory serviceFactory, gcsApplication application)
        {
            _ServiceFactory = serviceFactory;
            _Application = application;

            EditCommand = new DelegateCommand<gcsUser>(OnEditCommand);
            DeleteCommand = new DelegateCommand<gcsUser>(OnDeleteCommand);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand);

            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.GetAllUsersCompletedEvent += UserManager_OnGetAllUsersCompletedEvent;
            _UserManager.DeleteUserCompletedEvent += UserManager_OnDeleteUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
        }
        private void UserManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void UserManager_OnDeleteUserCompletedEvent(object sender, DeleteUserCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Users.Remove(e.User);
                //              Globals.Instance.RefreshRoles();
            });
        }

        private void UserManager_OnGetAllUsersCompletedEvent(object sender, GetAllUsersCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Users = new ObservableCollection<gcsUser>();
                foreach (gcsUser user in e.Users)
                {
                    _Users.Add(user);
                }
                OnPropertyChanged(() => Users, false);
            });
        }

        IServiceFactory _ServiceFactory;
        UserManager _UserManager;
        gcsApplication _Application;

        EditUserViewModel _CurrentUserViewModel;

        public DelegateCommand<gcsUser> EditCommand { get; private set; }
        public DelegateCommand<gcsUser> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }

        public override string ViewTitle
        {
            get
            {
                if (Application != null)
                    return Resources.EditApplicationView_UsersTitle;
                else
                    return Resources.MaintainUsers_Title;
            }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        public EditUserViewModel CurrentUserViewModel
        {
            get { return _CurrentUserViewModel; }
            set
            {
                if (_CurrentUserViewModel != value)
                {
                    _CurrentUserViewModel = value;
                    OnPropertyChanged(() => CurrentUserViewModel, false);
                }
            }
        }

        ObservableCollection<gcsUser> _Users;

        public ObservableCollection<gcsUser> Users
        {
            get { return _Users; }
            set
            {
                if (_Users != value)
                {
                    _Users = value;
                    OnPropertyChanged(() => Users, false);
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
            _Users = new ObservableCollection<gcsUser>();
            ArrayResponse<gcsUser> users;
            ClearCustomErrors();
            if (UseAsyncServiceCalls == false)
            {
                if (Application == null)
                    users = _UserManager.GetAllUsers();
                else
                    users = _UserManager.GetAllUsersForApplication(Application);
                _Users = users.Items.ToObservableCollection();
            }
            else
            {
                if (Application == null)
                {
                    Task.Run(async () =>
                    {
                        users = await _UserManager.GetAllUsersAsync();
                    }).Wait();
                }
                else
                {
                    Task.Run(async () =>
                    {
                        users = await _UserManager.GetAllUsersForApplicationAsync(Application);
                    }).Wait();
                }
            }
        }

        private bool OnEditCommandCanExecute(gcsUser obj)
        {
            return CurrentUserViewModel == null;
        }
        void OnEditCommand(gcsUser user)
        {
            if (user != null)
            {
                CurrentUserViewModel = new EditUserViewModel(_ServiceFactory, user);
                if (Application != null)
                    CurrentUserViewModel.CanChangeApplication = false;
                CurrentUserViewModel.UserUpdated += CurrentUserViewModel_UserUpdated;
                CurrentUserViewModel.CancelEditUser += CurrentUserViewModel_CancelEvent;
                //                BackgroundEffect = new BlurEffect();
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentUserViewModel == null;
        }

        void OnAddNewCommand(object arg)
        {
            gcsUser user = new gcsUser();
            //if (Application != null)
            //{
            //    user.ApplicationId = Application.ApplicationId;
            //}
            CurrentUserViewModel = new EditUserViewModel(_ServiceFactory, user);
            CurrentUserViewModel.UserUpdated += CurrentUserViewModel_UserUpdated;
            CurrentUserViewModel.CancelEditUser += CurrentUserViewModel_CancelEvent;
            //           BackgroundEffect = new BlurEffect();
        }

        void CurrentUserViewModel_UserUpdated(object sender, UserEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    gcsUser user = _Users.Where(item => item.UserId == e.User.UserId).FirstOrDefault();
                    if (user != null)
                    {
                        user.DisplayName = e.User.DisplayName;
                        user.Email = e.User.Email;
                        user.FirstName = e.User.FirstName;
                        user.ImportedFromActiveDirectory = e.User.ImportedFromActiveDirectory;
                        user.IsActive = e.User.IsActive;
                        user.IsLockedOut = e.User.IsLockedOut;
                        user.LanguageId = e.User.LanguageId;
                        user.PrimaryEntityId = e.User.PrimaryEntityId;
                        user.LastLoginDate = e.User.LastLoginDate;
                        user.LastName = e.User.LastName;
                        user.LastPasswordResetDate = e.User.LastPasswordResetDate;
                        user.UserName = e.User.UserName;
                        user.ResetPasswordFlag = e.User.ResetPasswordFlag;
                        user.SecurityImage = e.User.SecurityImage;
                        user.UserActivationDate = e.User.UserActivationDate;
                        user.UserExpirationDate = e.User.UserExpirationDate;
                        user.UserImage = e.User.UserImage;
                        user.UserInitials = e.User.UserInitials;
                        user.UserPassword = e.User.UserPassword;
                        user.UserTheme = e.User.UserTheme;
                        user.ActiveDirectoryObjectGuid = e.User.ActiveDirectoryObjectGuid;
                        user.InsertName = e.User.InsertName;
                        user.InsertDate = e.User.InsertDate;
                        user.UpdateName = e.User.UpdateName;
                        user.UpdateDate = e.User.UpdateDate;
                        user.ConcurrencyValue = e.User.ConcurrencyValue;

                        user.UserSettings = new HashSet<gcsUserSetting>();
                        foreach (gcsUserSetting s in e.User.UserSettings)
                        {
                            user.UserSettings.Add(s);
                        }

                        user.UserOldPasswords = new HashSet<gcsUserOldPassword>();
                        foreach (gcsUserOldPassword p in e.User.UserOldPasswords)
                        {
                            user.UserOldPasswords.Add(p);
                        }

                        user.UserEntities = new HashSet<gcsUserEntity>();
                        foreach (gcsUserEntity ue in e.User.UserEntities)
                        {
                            user.UserEntities.Add(ue);
                        }

                    }
                }
                else
                    _Users.Add(e.User);

                CurrentUserViewModel = null;
                BackgroundEffect = null;
            });
        }

        void CurrentUserViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentUserViewModel = null;
            BackgroundEffect = null;
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
        private bool OnDeleteCommandCanExecute(gcsUser obj)
        {
            return CurrentUserViewModel == null;
        }

        void OnDeleteCommand(gcsUser user)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(user.DisplayName);
            ConfirmDelete?.Invoke(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _UserManager.DeleteUser(user);
                    _Users.Remove(user);
                    //                   Globals.Instance.RefreshUsers();
                }
                else
                {
                    _UserManager.DeleteUserRaiseEvent(user);
                }

            }
        }
    }
}
