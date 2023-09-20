using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.ActiveDirectory;
using GCS.Framework.ActiveDirectory.UserControls;
using GCS.Framework.Imaging;
using GCS.Framework.Security;
using static GalaxySMS.Client.Entities.SendDataResponse;
using gcsApplication = GalaxySMS.Client.Entities.gcsApplication;
using gcsEntity = GalaxySMS.Client.Entities.gcsEntity;
using gcsLanguage = GalaxySMS.Client.Entities.gcsLanguage;
using gcsRole = GalaxySMS.Client.Entities.gcsRole;
using gcsUser = GalaxySMS.Client.Entities.gcsUser;
using gcsUserEntity = GalaxySMS.Client.Entities.gcsUserEntity;
using gcsUserRequirement = GalaxySMS.Client.Entities.gcsUserRequirement;
using GetParametersWithPhoto = GalaxySMS.Client.Entities.GetParametersWithPhoto;

namespace GalaxySMS.Admin.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        public EditUserViewModel(IServiceFactory serviceFactory, gcsUser user)
        {
            _ServiceFactory = serviceFactory;
            _User = new gcsUser(user);
            //           _User.CleanAll();

            Entities = new ObservableCollection<gcsEntity>();
            foreach (var e in Globals.Instance.Entities.Where(o => o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id))
            {
                Entities.Add(new gcsEntity(e));
            }

            CanChangeApplication = true;
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectActiveDirectoryUserCommand = new DelegateCommand<object>(OnSelectActiveDirectoryUserCommandExecute);
            SelectUserImageCommand = new DelegateCommand<object>(OnSelectUserImageCommandExecute);
            SelectSecurityImageCommand = new DelegateCommand<object>(OnSelectSecurityImageCommandExecute);
            EntitySelectionChangedCommand = new DelegateCommand<object>(OnEntitySelectionChangedCommand);

            //DeleteEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnDeleteEntityApplicationCommand);
            //AddEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnAddEntityApplicationCommand);

            DeleteEntityCommand = new DelegateCommand<gcsEntity>(OnDeleteEntityCommand);
            AddEntityCommand = new DelegateCommand<gcsEntity>(OnAddEntityCommand);

            DeleteEntityRoleCommand = new DelegateCommand<gcsRole>(OnDeleteEntityRoleCommand);
            AddEntityRoleCommand = new DelegateCommand<gcsRole>(OnAddEntityRoleCommand);

            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.SaveUserCompletedEvent += UserManager_OnSaveUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
            _UserManager.ValidatePasswordCompletedEvent += _UserManager_ValidatePasswordCompletedEvent;

            BackgroundSubduedEffect = Globals.Instance.BackgroundSubduedEffect;
            BackgroundSubduedOpacity = Globals.Instance.BackgroundSubduedOpacity;
            GetUserEditingData();
            //_User.CleanAll();

        }

        private void _UserManager_ValidatePasswordCompletedEvent(object sender, ValidatePasswordCompletedEventArgs e)
        {
            ProcessPasswordValidationResults(e.ValidationResults);
        }

        private void UserManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            Globals.Instance.IsBusy = false;
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void UserManager_OnSaveUserCompletedEvent(object sender, SaveUserCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.User != null)
                {
                    if (UserUpdated != null)
                        UserUpdated(this, new UserEventArgs(e.User, e.IsNew));
                }
                Globals.Instance.IsBusy = false;
            });
        }

        private void ProcessPasswordValidationResults(PasswordValidationInfo results)
        {
            if (_User.UserRequirements != null)
            {
                foreach (var validationResult in results.Results)
                {
                    switch (validationResult.Result)
                    {
                        case PasswordValidationResult.Unknown:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(Properties.Resources.PasswordValidationResult_UnknownError)));
                            break;

                        case PasswordValidationResult.InvalidIsEmpty:
                            if (_User.UserId == Guid.Empty) // if editing and the password is empty, then the password is not being changed. This is ok. However, if adding, a blank password is not allowed
                            {
                                AddCustomErrorToValidationResults(
                                    new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                        string.Format(Properties.Resources.PasswordValidationResult_PasswordIsRequired)));
                            }
                            break;

                        case PasswordValidationResult.Valid:
                            break;

                        case PasswordValidationResult.InvalidLengthToShort:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(Properties.Resources.PasswordValidationResult_InvalidLengthToShort,
                                        _User.UserRequirements.PasswordMinimumLength)));
                            break;

                        case PasswordValidationResult.InvalidLengthToLong:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(Properties.Resources.PasswordValidationResult_InvalidLengthToLong,
                                        _User.UserRequirements.PasswordMaximumLength)));
                            break;

                        case PasswordValidationResult.InsufficientUpperCaseCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources
                                            .PasswordValidationResult_InvalidNotEnoughUpperCaseCharacters,
                                        _User.UserRequirements.RequireUpperCaseLetterCount)));
                            break;

                        case PasswordValidationResult.InsufficientLowerCaseCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources
                                            .PasswordValidationResult_InvalidNotEnoughLowerCaseCharacters,
                                        _User.UserRequirements.RequireLowerCaseLetterCount)));
                            break;

                        case PasswordValidationResult.InsufficientNumericDigits:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources.PasswordValidationResult_InvalidNotEnoughNumericDigits,
                                        _User.UserRequirements.RequireNumericDigitCount)));
                            break;

                        case PasswordValidationResult.InsufficientSpecialCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources.PasswordValidationResult_InvalidNotEnoughSpecialCharacters,
                                        _User.UserRequirements.RequireSpecialCharacterCount)));
                            break;

                        case PasswordValidationResult.InvalidDoesNotMatchRegularExpression:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources
                                            .PasswordValidationResult_InvalidDoesNotMatchRegularExpression,
                                        _User.UserRequirements.PasswordCustomRegEx)));
                            break;

                        case PasswordValidationResult.InvalidMatchesPreviousPassword:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources
                                            .PasswordValidationResult_InvalidMatchesPreviouslyUsedPassword,
                                        _User.UserRequirements.MaintainPasswordHistoryCount)));
                            break;

                        case PasswordValidationResult.InsufficientNumberOfCharactersChanged:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources
                                            .PasswordValidationResult_InvalidNotEnoughCharactersHaveBeenChanged,
                                        _User.UserRequirements.PasswordMinimumChangeCharacters)));
                            break;

                        case PasswordValidationResult.InvalidContainsIllegalContent:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Properties.Resources.PasswordValidationResult_InvalidContainsIllegalContent,
                                        _User.UserRequirements.PasswordCannotContainName)));
                            break;

                        case PasswordValidationResult.InvalidParameter:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(Properties.Resources.PasswordValidationResult_InvalidParameter)));
                            break;

                        default:
                            AddCustomErrorToValidationResults(
                                new CustomError(Properties.Resources.EditUserView_PasswordTitle,
                                    string.Format(Properties.Resources.PasswordValidationResult_UnknownError)));
                            break;
                    }
                }
            }
        }

        private bool _CanChangeApplication;
        private IServiceFactory _ServiceFactory;
        private gcsUser _User;
        private UserManager _UserManager;
        private gcsEntity _currentEntity;
        private gcsApplication _currentApplication;
        private string _passwordRequirements;

        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> EntitySelectionChangedCommand { get; private set; }

        public DelegateCommand<object> SelectActiveDirectoryUserCommand { get; private set; }

        public DelegateCommand<object> SelectUserImageCommand { get; private set; }

        public DelegateCommand<object> SelectSecurityImageCommand { get; private set; }
        public DelegateCommand<gcsEntity> AddEntityCommand { get; private set; }
        public DelegateCommand<gcsEntity> DeleteEntityCommand { get; private set; }

        //public DelegateCommand<gcsApplication> AddEntityApplicationCommand { get; private set; }
        //public DelegateCommand<gcsApplication> DeleteEntityApplicationCommand { get; private set; }

        public DelegateCommand<gcsRole> AddEntityRoleCommand { get; private set; }
        public DelegateCommand<gcsRole> DeleteEntityRoleCommand { get; private set; }


        public event EventHandler CancelEditUser;

        public event EventHandler<UserEventArgs> UserUpdated;

        public gcsUser User
        {
            get { return _User; }
        }

        public gcsEntity CurrentEntity
        {
            get { return _currentEntity; }
            set
            {
                if (_currentEntity != value)
                {
                    _currentEntity = value;
                    OnPropertyChanged(() => CurrentEntity);
                }
            }
        }

        public gcsApplication CurrentApplication
        {
            get { return _currentApplication; }
            set
            {
                if (_currentApplication != value)
                {
                    _currentApplication = value;
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

        async Task GetUserEditingData()
        {
            Globals.Instance.IsBusy = true;
            UserEditingData = await _UserManager.GetUserEditingDataAsync(new GetParametersWithPhoto());

            Entities = new ObservableCollection<gcsEntity>();
            foreach (var e in Globals.Instance.Entities.Where(o => o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id))
            {
                Entities.Add(new gcsEntity(e));
                var ent = new gcsEntity(e);
                var ue = _User.UserEntities.FirstOrDefault(o => o.EntityId == ent.EntityId);
                ent.IsAuthorized = ue != null;
                if (ue != null)
                {
                    ent.UserIsAdministrator = ue.IsAdministrator;
                    ent.InheritParentRoles = ue.InheritParentRoles;
                    foreach (var r in ent.AllRoles)
                    {
                        var userRole = ue.UserEntityRoles.FirstOrDefault(o => o.RoleId == r.RoleId);
                        r.IsAuthorized = userRole != null;
                    }
                }
                _User.AllEntities.Add(ent);
            }

            _User.CleanAll();

            OnEntitySelectionChangedCommand(null);

            Globals.Instance.IsBusy = false;
        }


        private gcsUserEditingData _userEditingData;

        public gcsUserEditingData UserEditingData
        {
            get { return _userEditingData; }
            set
            {
                if (_userEditingData != value)
                {
                    _userEditingData = value;
                    OnPropertyChanged(() => UserEditingData, false);
                }
            }
        }



        private void OnEntitySelectionChangedCommand(object entity)
        {
            if (_User != null)
            {
                _User.UserRequirements =
                    Globals.Instance.GetUserRequirementsForEntity(_User.PrimaryEntityId);
                if (_User.UserRequirements != null)
                {
                    PasswordRequirements = FormatPasswordRequirements(_User.UserRequirements);
                }
                else
                {
                    PasswordRequirements = string.Empty;
                }

                gcsEntity e = entity as gcsEntity;
                if (e != null)
                    OnAddEntityCommand(e);
            }
        }

        private void OnAddEntityCommand(gcsEntity obj)
        {
            if (obj == null)
                return;
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            var existingItem =
                (from u in User.AllEntities.Where(u => u.EntityId == obj.EntityId) select u).FirstOrDefault();
            if (existingItem != null)
            {
                User.AllEntities.Remove(existingItem);
            }
            User.AllEntities.Add(obj);

            var existingUe = User.UserEntities.FirstOrDefault(o => o.EntityId == obj.EntityId);
            if (existingUe == null)
            {
                User.UserEntities.Add(new gcsUserEntity()
                {
                    EntityId = obj.EntityId
                });
            }

            User.MakeDirty();
        }

        private void OnDeleteEntityCommand(gcsEntity obj)
        {
            if (obj == null)
                return;
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            var existingItem =
                (from u in User.AllEntities.Where(u => u.EntityId == obj.EntityId) select u).FirstOrDefault();
            if (existingItem != null)
            {
                User.AllEntities.Remove(existingItem);
            }
            User.AllEntities.Add(obj);

            var existingUe = User.UserEntities.FirstOrDefault(o => o.EntityId == obj.EntityId);
            if (existingUe != null)
            {
                User.UserEntities.Remove(existingUe);
            }
            User.MakeDirty();
        }

        //private void OnAddEntityApplicationCommand(gcsApplication obj)
        //{
        //    if (obj == null || CurrentEntity == null)
        //        return;
        //    obj.IsAuthorized = true;

        //    // Must Remove then add to get the grid to refresh
        //    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
        //    //CurrentEntity.AllApplications.Remove(obj);
        //    //CurrentEntity.AllApplications.Add(obj);

        //    _User.MakeDirty();
        //}

        //private void OnDeleteEntityApplicationCommand(gcsApplication obj)
        //{
        //    if (obj == null || CurrentEntity == null)
        //        return;
        //    obj.IsAuthorized = false;

        //    // Must Remove then add to get the grid to refresh
        //    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
        //    //CurrentEntity.AllApplications.Remove(obj);
        //    //CurrentEntity.AllApplications.Add(obj);


        //    //var existingEntityApplication = CurrentEntity.FirstOrDefault(o => o.ApplicationId == obj.ApplicationId);
        //    //if (existingEntityApplication != null)
        //    //{

        //    //}

        //    _User.MakeDirty();

        //}

        private void OnAddEntityRoleCommand(gcsRole obj)
        {
            if (obj == null || CurrentEntity == null)
                return;
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            CurrentEntity.AllRoles.Remove(obj);
            CurrentEntity.AllRoles.Add(obj);

            var ueType = _User.UserEntities.GetType();

            var currentUe = _User.UserEntities.FirstOrDefault(o => o.EntityId == obj.EntityId);
            if (currentUe != null)
            {
                currentUe.UserEntityRoles = currentUe.UserEntityRoles.ToCollection();
                var uerType = currentUe.UserEntityRoles.GetType();
                var r = currentUe.UserEntityRoles.FirstOrDefault(o => o.RoleId == obj.RoleId);
                if( r == null)
                    currentUe.UserEntityRoles.Add(new gcsUserEntityRole(){RoleId = obj.RoleId});
            }

            _User.MakeDirty();
        }

        private void OnDeleteEntityRoleCommand(gcsRole obj)
        {
            if (obj == null || CurrentEntity == null)
                return;
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            CurrentEntity.AllRoles.Remove(obj);
            CurrentEntity.AllRoles.Add(obj);

            var currentUe = _User.UserEntities.FirstOrDefault(o => o.EntityId == obj.EntityId);
            if (currentUe != null)
            {
                currentUe.UserEntityRoles = currentUe.UserEntityRoles.ToCollection();

                var r = currentUe.UserEntityRoles.FirstOrDefault(o => o.RoleId == obj.RoleId);
                if (r != null)
                    currentUe.UserEntityRoles.Remove(r);
            }

            _User.MakeDirty();
        }

        //public ObservableCollection<gcsApplication> Applications
        //{ get { return Globals.Instance.Applications; } }

        public ObservableCollection<gcsLanguage> Languages
        { get { return Globals.Instance.Languages; } }

        //public ObservableCollection<gcsEntityEx> Entities
        //{ get { return Globals.Instance.Entities.Where(o=>o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id).ToObservableCollection(); } }
        public ObservableCollection<gcsEntity> Entities { get; internal set; }

        public String PasswordRequirements
        {
            get { return _passwordRequirements; }
            set
            {
                _passwordRequirements = value;
                OnPropertyChanged(() => PasswordRequirements);
            }
        }

        private string FormatPasswordRequirements(gcsUserRequirement userReqs)
        {
            if (userReqs == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            if (userReqs.PasswordCannotContainName == true)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_CannotContainIllegalContent));

            if (userReqs.UseCustomRegEx)
            {
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustMatchRegularExpression,
                    userReqs.PasswordCustomRegEx, userReqs.RegularExpressionDescription));
                return sb.ToString();
            }

            if (userReqs.PasswordMinimumLength > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MinimumLength,
                    userReqs.PasswordMinimumLength));

            if (userReqs.PasswordMaximumLength > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MaximumLength,
                    userReqs.PasswordMaximumLength));


            if (userReqs.RequireUpperCaseLetterCount > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustContainUpperCaseCharacterCount,
                    userReqs.RequireUpperCaseLetterCount));


            if (userReqs.RequireLowerCaseLetterCount > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustContainLowerCaseCharacterCount,
                    userReqs.RequireLowerCaseLetterCount));


            if (userReqs.RequireNumericDigitCount > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustContainNumericDigitsCount,
                    userReqs.RequireNumericDigitCount));


            if (userReqs.RequireSpecialCharacterCount > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustContainSpecialCharacterCount,
                    userReqs.PasswordMaximumLength));


            if (userReqs.MaintainPasswordHistoryCount > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_CannotReuseRecentPasswords,
                    userReqs.MaintainPasswordHistoryCount));


            if (userReqs.PasswordMinimumChangeCharacters > 0)
                sb.AppendLine(string.Format(Properties.Resources.PasswordRule_MustChangeCharacterCount,
                    userReqs.PasswordMinimumChangeCharacters));

            return sb.ToString();
        }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(User);
        }

        private void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                Globals.Instance.IsBusy = true;
                Globals.Instance.BusyContent = GalaxySMS.Admin.Properties.Resources.EditUserView_PleaseWaitWhileISave;
                // Extra validation gets added here
                bool isNew = (_User.UserId == Guid.Empty);

                //// Deal with entities, applications and roles here
                //var authorizedEntities = _User.AllEntities.Where(o => o.IsAuthorized == true).ToList();
                //var addTheseEntities = authorizedEntities.Where(p => _User.gcsUserEntities.All(p2 => p2.EntityId != p.EntityId)).ToList();
                //var deleteTheseEntities = _User.gcsUserEntities.Where(p => authorizedEntities.All(p2 => p2.EntityId != p.EntityId)).ToList();

                foreach (var e in _User.AllEntities.Where(o => o.IsAuthorized))
                {
                    var ue = _User.UserEntities.FirstOrDefault(o => o.EntityId == e.EntityId);
                    if (ue != null)
                    {
                        ue.IsAdministrator = e.UserIsAdministrator;
                        ue.InheritParentRoles = e.InheritParentRoles;
                    }
                }

                var saveParams = new SaveParameters<gcsUser>(_User){DoNotValidateAuthorization = true};
                if (UseAsyncServiceCalls == false)
                {
                    var savedUser = _UserManager.SaveUser(saveParams);
                    if (savedUser != null)
                    {
                        UserUpdated?.Invoke(this, new UserEventArgs(savedUser, isNew));
                    }
                    Globals.Instance.IsBusy = false;
                }
                else
                {
                    _UserManager.SaveUserRaiseEvent(saveParams);
                }
            }
        }

        protected override void ValidateModel()
        {
            base.ValidateModel();
            if (IsValid == false)
            {   // if validation failed, it could be due to the password. If it is, 
                var passwordValidationResults = _UserManager.ValidatePassword(_User);
                ProcessPasswordValidationResults(passwordValidationResults);
            }
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            return _User.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            if (CancelEditUser != null)
                CancelEditUser(this, EventArgs.Empty);
        }

        private void OnSelectActiveDirectoryUserCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ActiveDirectoryUserSelectionControl adUserControl = new ActiveDirectoryUserSelectionControl();
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(adUserControl, null, Properties.Resources.Dialog_SelectActiveDirectoryUserTitle);
                ClearBackgroundSubdued();
                if (adUserControl.DialogResult == true && adUserControl.SelectedADUser != null)
                {
                    _User.DisplayName = adUserControl.SelectedADUser.DisplayName;
                    _User.FirstName = adUserControl.SelectedADUser.FirstName;
                    _User.LastName = adUserControl.SelectedADUser.LastName;
                    _User.Email = adUserControl.SelectedADUser.EmailAddress;
                    _User.UserName = adUserControl.SelectedADUser.UserLogonName;
                    _User.UserInitials = adUserControl.SelectedADUser.Initials;
                    if (adUserControl.SelectedADUser.AccountDisabled != MyTriState.Yes)
                        _User.IsActive = true;
                    _User.ActiveDirectoryObjectGuid = adUserControl.SelectedADUser.ObjectGUID;
                    _User.ImportedFromActiveDirectory = true;
                    OnPropertyChanged(() => User);
                }

                //Telerik.Windows.Controls.RadWindow window = new Telerik.Windows.Controls.RadWindow();
                //ActiveDirectoryUserSelectionControl adUserControl = new ActiveDirectoryUserSelectionControl();
                //window.Content = adUserControl;
                //window.MinHeight = window.ActualHeight;
                //window.MinWidth = window.ActualWidth;
                //window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                //window.Owner = App.Current.MainWindow;
                //window.CanClose = true;
                //window.ShowDialog();
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectActiveDirectoryUserCommandExecute: {0}", ex.Message);
            }
        }

        private void OnSelectUserImageCommandExecute(object obj)
        {
            try
            {
                //Telerik.Windows.Controls.RadWindow window = new Telerik.Windows.Controls.RadWindow();
                //ImageCaptureControl captureControl = new ImageCaptureControl();
                //captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_User.UserImage);
                //captureControl.AutomaticallyScaleDownImage = true;
                //captureControl.ScaleToMaximumHeight = 600;
                //window.Width = 400;
                //window.Height = 400;
                //window.Content = captureControl;
                //window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                //window.Owner = App.Current.MainWindow;
                //window.CanClose = true;
                //SetBackgroundSubdued();
                //window.ShowDialog();
                //ClearBackgroundSubdued();
                //if (captureControl.ImageCroppedAndScaled != null)
                //{
                //    _User.UserImage = ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                //}
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_User.UserImage);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, Properties.Resources.Dialog_SelectCapturePhotoTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    _User.UserImage = ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectUserImageCommandExecute: {0}", ex.Message);
            }
        }

        private void OnSelectSecurityImageCommandExecute(object obj)
        {
            IDialogService dlgService = new DialogService();
            ImageCaptureControl captureControl = new ImageCaptureControl();
            captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_User.SecurityImage);
            captureControl.AutomaticallyScaleDownImage = true;
            captureControl.ScaleToMaximumHeight = 600;
            SetBackgroundSubdued();
            dlgService.ShowRadDialog(captureControl, null, Properties.Resources.Dialog_SelectCapturePhotoTitle);
            ClearBackgroundSubdued();
            if (captureControl.ImageCroppedAndScaled != null)
            {
                _User.SecurityImage = ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
            }
        }
    }
}