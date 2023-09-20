using GalaxySMS.Admin.Properties;
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainUsersViewModel : ViewModelBase
    {
        private KeyValuePair<int, string> _gridPageSize;
        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;

        [ImportingConstructor]
        public MaintainUsersViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            //EditCommand = new DelegateCommand<gcsUser>(OnEditCommand, OnEditCommandCanExecute);
            //DeleteCommand = new DelegateCommand<gcsUser>(OnDeleteCommand, OnDeleteCommandCanExecute);
            EditCommand = new DelegateCommand<gcsUserBasic>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsUserBasic>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.GetAllUsersCompletedEvent += UserManager_OnGetAllUsersCompletedEvent;
            _UserManager.DeleteUserCompletedEvent += UserManager_OnDeleteUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }
        }



        public MaintainUsersViewModel(IServiceFactory serviceFactory, gcsApplication application)
        {
            _ServiceFactory = serviceFactory;
            _Application = application;

            //EditCommand = new DelegateCommand<gcsUser>(OnEditCommand);
            //DeleteCommand = new DelegateCommand<gcsUser>(OnDeleteCommand);
            EditCommand = new DelegateCommand<gcsUserBasic>(OnEditCommand);
            DeleteCommand = new DelegateCommand<gcsUserBasic>(OnDeleteCommand);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand);

            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.GetAllUsersCompletedEvent += UserManager_OnGetAllUsersCompletedEvent;
            _UserManager.DeleteUserCompletedEvent += UserManager_OnDeleteUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }
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

        //private void UserManager_OnDeleteUserCompletedEvent(object sender, DeleteUserCompletedEventArgs e)
        //{
        //    App.Current.Dispatcher.Invoke((Action)delegate
        //    {
        //        _Users.Remove(e.User);
        //        //              Globals.Instance.RefreshRoles();
        //    });
        //}
        private void UserManager_OnDeleteUserCompletedEvent(object sender, DeleteUserCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                var userToDelete = _Users.FirstOrDefault(o => o.UserId == e.User.UserId);
                if (userToDelete != null)
                    _Users.Remove(userToDelete);
                //              Globals.Instance.RefreshRoles();
            });
        }

        //private void UserManager_OnGetAllUsersCompletedEvent(object sender, GetAllUsersCompletedEventArgs e)
        //{
        //    App.Current.Dispatcher.Invoke((Action)delegate
        //    {
        //        _Users = new ObservableCollection<gcsUser>();
        //        foreach (gcsUser user in e.Users)
        //        {
        //            _Users.Add(user);
        //        }
        //        OnPropertyChanged(() => Users, false);
        //    });
        //}

        private void UserManager_OnGetAllUsersCompletedEvent(object sender, GetAllUsersCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Users = new ObservableCollection<gcsUserBasic>();
                foreach (gcsUser user in e.Users)
                {
                    _Users.Add(user.ToGcsUserBasic());
                }
                OnPropertyChanged(() => Users, false);
                OnPropertyChanged(() => TotalRecordCount, false);
            });
        }

        IServiceFactory _ServiceFactory;
        UserManager _UserManager;
        gcsApplication _Application;

        EditUserViewModel _CurrentUserViewModel;

        //public DelegateCommand<gcsUser> EditCommand { get; private set; }
        //public DelegateCommand<gcsUser> DeleteCommand { get; private set; }
        public DelegateCommand<gcsUserBasic> EditCommand { get; private set; }
        public DelegateCommand<gcsUserBasic> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }

        public override string ViewTitle
        {
            get
            {
                if (Application != null)
                    return Properties.Resources.EditApplicationView_UsersTitle;
                else
                    return Properties.Resources.MaintainUsers_Title;
            }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

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

        //ObservableCollection<gcsUser> _Users;

        //public ObservableCollection<gcsUser> Users
        //{
        //    get { return _Users; }
        //    set
        //    {
        //        if (_Users != value)
        //        {
        //            _Users = value;
        //            OnPropertyChanged(() => Users, false);
        //        }
        //    }
        //}
        ObservableCollection<gcsUserBasic> _Users;

        public ObservableCollection<gcsUserBasic> Users
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


        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        public ObservableCollection<KeyValuePair<int, string>> GridPageSizes
        {
            get { return _gridPageSizes; }
            set
            {
                if (_gridPageSizes != value)
                {
                    _gridPageSizes = value;
                    OnPropertyChanged(() => GridPageSizes, false);
                }
            }
        }

        public int TotalRecordCount
        {
            get
            {
                if (Users == null)
                    return 0;
                return Users.Count;
            }
            set { OnPropertyChanged(() => TotalRecordCount, false); }
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

        //protected override void OnViewLoaded()
        //{
        //    _Users = new ObservableCollection<gcsUser>();
        //    ClearCustomErrors();
        //    if (UseAsyncServiceCalls == false)
        //    {
        //        ReadOnlyCollection<gcsUser> users;
        //        if (Application == null)
        //            users = _UserManager.GetAllUsers();
        //        else
        //            users = _UserManager.GetAllUsersForApplication(Application);

        //        foreach (gcsUser user in users)
        //            _Users.Add(user);
        //    }
        //    else
        //    {
        //        if (Application == null)
        //            _UserManager.GetAllUsersRaiseEvent();
        //        else
        //            _UserManager.GetAllUsersForApplicationAsync(Application);
        //    }
        //}
        protected override void OnViewLoaded()
        {
            _Users = new ObservableCollection<gcsUserBasic>();
            ClearCustomErrors();
            var parameters = new GetParametersWithPhoto()
            {
                IncludePhoto = true,
                PhotoPixelWidth = Settings.Default.ThumbnailWidth,
            };

            if (UseAsyncServiceCalls == false)
            {
                if (Application == null)
                {
                    _Users = _UserManager.GetAllUsersList(parameters, false).Items.ToObservableCollection();
                }
                else
                {
                    var usersForApp = _UserManager.GetAllUsersForApplication(Application);
                    foreach (var u in usersForApp.Items)
                        _Users.Add(u.ToGcsUserBasic());
                }

            }
            else
            {
                if (Application == null)
                {

                    Task.Run(async () =>
                    {
                        var users = await _UserManager.GetAllUsersListAsync(parameters);
                        _Users = users.Items.ToObservableCollection();
                    }).Wait();
                }
                else
                {
                    Task.Run(async () =>
                    {
                        var users = await _UserManager.GetAllUsersForApplicationAsync(Application);

                        _Users = new ObservableCollection<gcsUserBasic>();
                        foreach (var u in users.Items)
                            _Users.Add(new gcsUserBasic(u));
                    }).Wait();
                }
            }

        }


        //        private bool OnEditCommandCanExecute(gcsUser obj)
        //        {
        //            return CurrentUserViewModel == null;
        //        }
        //        void OnEditCommand(gcsUser user)
        //        {
        //            if (user != null)
        //            {
        //                CurrentUserViewModel = new EditUserViewModel(_ServiceFactory, user);
        //                if (Application != null)
        //                    CurrentUserViewModel.CanChangeApplication = false;
        //                CurrentUserViewModel.UserUpdated += CurrentUserViewModel_UserUpdated;
        //                CurrentUserViewModel.CancelEditUser += CurrentUserViewModel_CancelEvent;
        ////                BackgroundEffect = new BlurEffect();
        //            }
        //        }
        private bool OnEditCommandCanExecute(gcsUserBasic obj)
        {
            return CurrentUserViewModel == null;
        }
        async void OnEditCommand(gcsUserBasic user)
        {
            if (user != null)
            {
                Globals.Instance.IsBusy = true;
                //var fullUser = await _UserManager.GetByUserIdAsync(user.UserId);
                var fullUser = await _UserManager.GetByUserIdAsync(new GetParametersWithPhoto() { UniqueId = user.UserId, IncludeMemberCollections = true, IncludePhoto = true });
                CurrentUserViewModel = new EditUserViewModel(_ServiceFactory, fullUser);
                if (Application != null)
                    CurrentUserViewModel.CanChangeApplication = false;
                CurrentUserViewModel.UserUpdated += CurrentUserViewModel_UserUpdated;
                CurrentUserViewModel.CancelEditUser += CurrentUserViewModel_CancelEvent;
                //                BackgroundEffect = new BlurEffect();
                Globals.Instance.IsBusy = false;
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

        //void CurrentUserViewModel_UserUpdated(object sender, UserEventArgs e)
        //{
        //    App.Current.Dispatcher.Invoke((Action)delegate
        //    {
        //        if (!e.IsNew)
        //        {
        //            gcsUser user = _Users.Where(item => item.UserId == e.User.UserId).FirstOrDefault();
        //            if (user != null)
        //            {
        //                user.DisplayName = e.User.DisplayName;
        //                user.Email = e.User.Email;
        //                user.FirstName = e.User.FirstName;
        //                user.ImportedFromActiveDirectory = e.User.ImportedFromActiveDirectory;
        //                user.IsActive = e.User.IsActive;
        //                user.IsLockedOut = e.User.IsLockedOut;
        //                user.LanguageId = e.User.LanguageId;
        //                user.PrimaryEntityId = e.User.PrimaryEntityId;
        //                user.LastLoginDate = e.User.LastLoginDate;
        //                user.LastName = e.User.LastName;
        //                user.LastPasswordResetDate = e.User.LastPasswordResetDate;
        //                user.UserName = e.User.UserName;
        //                user.ResetPasswordFlag = e.User.ResetPasswordFlag;
        //                user.SecurityImage = e.User.SecurityImage;
        //                user.UserActivationDate = e.User.UserActivationDate;
        //                user.UserExpirationDate = e.User.UserExpirationDate;
        //                user.UserImage = e.User.UserImage;
        //                user.UserInitials = e.User.UserInitials;
        //                user.UserPassword = e.User.UserPassword;
        //                user.UserTheme = e.User.UserTheme;
        //                user.ActiveDirectoryObjectGuid = e.User.ActiveDirectoryObjectGuid;
        //                user.InsertName = e.User.InsertName;
        //                user.InsertDate = e.User.InsertDate;
        //                user.UpdateName = e.User.UpdateName;
        //                user.UpdateDate = e.User.UpdateDate;
        //                user.ConcurrencyValue = e.User.ConcurrencyValue;

        //                user.gcsUserSettings = new HashSet<gcsUserSetting>();
        //                foreach (gcsUserSetting s in e.User.gcsUserSettings)
        //                {
        //                    user.gcsUserSettings.Add(s);
        //                }

        //                user.gcsUserOldPasswords = new HashSet<gcsUserOldPassword>();
        //                foreach (gcsUserOldPassword p in e.User.gcsUserOldPasswords)
        //                {
        //                    user.gcsUserOldPasswords.Add(p);
        //                }

        //                user.gcsUserEntities = new HashSet<gcsUserEntity>();
        //                foreach (gcsUserEntity ue in e.User.gcsUserEntities)
        //                {
        //                    user.gcsUserEntities.Add(ue);
        //                }                 

        //            }
        //        }
        //        else
        //            _Users.Add(e.User);

        //        CurrentUserViewModel = null;
        //        BackgroundEffect = null;
        //    });
        //}
        void CurrentUserViewModel_UserUpdated(object sender, UserEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    var user = _Users.Where(item => item.UserId == e.User.UserId).FirstOrDefault();
                    if (user != null)
                    {
                        user.Initialize(e.User);
                    }
                }
                else
                    _Users.Add(e.User.ToGcsUserBasic());

                CurrentUserViewModel = null;
                BackgroundEffect = null;
            });
        }

        void CurrentUserViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentUserViewModel = null;
            BackgroundEffect = null;
        }

        //       private bool OnDeleteCommandCanExecute(gcsUser obj)
        //       {
        //           return CurrentUserViewModel == null;
        //       }

        //       void OnDeleteCommand(gcsUser user)
        //       {
        //           ClearCustomErrors();

        //           var args = new CancelMessageEventArgs(user.DisplayName);
        //           ConfirmDelete?.Invoke(this, args);
        //           if (!args.Cancel)
        //           {

        //               if (UseAsyncServiceCalls == false)
        //               {
        //                   _UserManager.DeleteUser(user);
        //                   _Users.Remove(user);
        ////                   Globals.Instance.RefreshUsers();
        //               }
        //               else
        //               {
        //                   _UserManager.DeleteUserAsync(user);
        //               }

        //           }
        //       }
        private bool OnDeleteCommandCanExecute(gcsUserBasic obj)
        {
            return CurrentUserViewModel == null;
        }

        async void OnDeleteCommand(gcsUserBasic user)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(user.DisplayName);
            ConfirmDelete?.Invoke(this, args);
            if (!args.Cancel)
            {
                Globals.Instance.IsBusy = true;
                if (UseAsyncServiceCalls == false)
                {
                    _UserManager.DeleteUser(user);
                    //                   Globals.Instance.RefreshUsers();
                }
                else
                {
                    await _UserManager.DeleteUserAsync(user);
                }
                _Users.Remove(user);
                Globals.Instance.IsBusy = false;

            }
        }

    }
}
