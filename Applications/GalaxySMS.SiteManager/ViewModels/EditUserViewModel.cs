using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaxySMS.SiteManager.Properties;
using GalaxySMS.SiteManager.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.ActiveDirectory;
using GCS.Framework.ActiveDirectory.UserControls;
using GCS.Framework.Imaging;
using GCS.Framework.Security;

namespace GalaxySMS.SiteManager.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        public EditUserViewModel(IServiceFactory serviceFactory, gcsUser user)
        {
            _ServiceFactory = serviceFactory;
            _User = new gcsUser(user);
            //           _User.CleanAll();

            CanChangeApplication = true;
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectActiveDirectoryUserCommand = new DelegateCommand<object>(OnSelectActiveDirectoryUserCommandExecute);
            SelectUserImageCommand = new DelegateCommand<object>(OnSelectUserImageCommandExecute);
            SelectSecurityImageCommand = new DelegateCommand<object>(OnSelectSecurityImageCommandExecute);
            EntitySelectionChangedCommand = new DelegateCommand<object>(OnEntitySelectionChangedCommand);

            DeleteEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnDeleteEntityApplicationCommand);
            AddEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnAddEntityApplicationCommand);

            DeleteEntityCommand = new DelegateCommand<gcsEntity>(OnDeleteEntityCommand);
            AddEntityCommand = new DelegateCommand<gcsEntity>(OnAddEntityCommand);

            DeleteEntityApplicationRoleCommand = new DelegateCommand<gcsRole>(OnDeleteEntityApplicationRoleCommand);
            AddEntityApplicationRoleCommand = new DelegateCommand<gcsRole>(OnAddEntityApplicationRoleCommand);


            _UserManager = new UserManager(Globals.Instance.ServerConnections[0]);
            _UserManager.SaveUserCompletedEvent += UserManager_OnSaveUserCompletedEvent;
            _UserManager.ErrorsOccurredEvent += UserManager_OnErrorsOccurredEvent;
            _UserManager.ValidatePasswordCompletedEvent += _UserManager_ValidatePasswordCompletedEvent;

            BackgroundSubduedEffect = Globals.Instance.BackgroundSubduedEffect;
            BackgroundSubduedOpacity = Globals.Instance.BackgroundSubduedOpacity;

            OnEntitySelectionChangedCommand(null);
            _User.CleanAll();
        }

        private void _UserManager_ValidatePasswordCompletedEvent(object sender, ValidatePasswordCompletedEventArgs e)
        {
            ProcessPasswordValidationResults(e.ValidationResults);
        }

        private void UserManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
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
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(Resources.PasswordValidationResult_UnknownError)));
                            break;

                        case PasswordValidationResult.InvalidIsEmpty:
                            if (_User.UserId == Guid.Empty) // if editing and the password is empty, then the password is not being changed. This is ok. However, if adding, a blank password is not allowed
                            {
                                AddCustomErrorToValidationResults(
                                    new CustomError(Resources.EditUserView_PasswordTitle,
                                        string.Format(Resources.PasswordValidationResult_PasswordIsRequired)));
                            }
                            break;

                        case PasswordValidationResult.Valid:
                            break;

                        case PasswordValidationResult.InvalidLengthToShort:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(Resources.PasswordValidationResult_InvalidLengthToShort,
                                        _User.UserRequirements.PasswordMinimumLength)));
                            break;

                        case PasswordValidationResult.InvalidLengthToLong:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(Resources.PasswordValidationResult_InvalidLengthToLong,
                                        _User.UserRequirements.PasswordMaximumLength)));
                            break;

                        case PasswordValidationResult.InsufficientUpperCaseCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources
                                            .PasswordValidationResult_InvalidNotEnoughUpperCaseCharacters,
                                        _User.UserRequirements.RequireUpperCaseLetterCount)));
                            break;

                        case PasswordValidationResult.InsufficientLowerCaseCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources
                                            .PasswordValidationResult_InvalidNotEnoughLowerCaseCharacters,
                                        _User.UserRequirements.RequireLowerCaseLetterCount)));
                            break;

                        case PasswordValidationResult.InsufficientNumericDigits:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources.PasswordValidationResult_InvalidNotEnoughNumericDigits,
                                        _User.UserRequirements.RequireNumericDigitCount)));
                            break;

                        case PasswordValidationResult.InsufficientSpecialCharacters:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources.PasswordValidationResult_InvalidNotEnoughSpecialCharacters,
                                        _User.UserRequirements.RequireSpecialCharacterCount)));
                            break;

                        case PasswordValidationResult.InvalidDoesNotMatchRegularExpression:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources
                                            .PasswordValidationResult_InvalidDoesNotMatchRegularExpression,
                                        _User.UserRequirements.PasswordCustomRegEx)));
                            break;

                        case PasswordValidationResult.InvalidMatchesPreviousPassword:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources
                                            .PasswordValidationResult_InvalidMatchesPreviouslyUsedPassword,
                                        _User.UserRequirements.MaintainPasswordHistoryCount)));
                            break;

                        case PasswordValidationResult.InsufficientNumberOfCharactersChanged:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources
                                            .PasswordValidationResult_InvalidNotEnoughCharactersHaveBeenChanged,
                                        _User.UserRequirements.PasswordMinimumChangeCharacters)));
                            break;

                        case PasswordValidationResult.InvalidContainsIllegalContent:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(
                                        Resources.PasswordValidationResult_InvalidContainsIllegalContent,
                                        _User.UserRequirements.PasswordCannotContainName)));
                            break;

                        case PasswordValidationResult.InvalidParameter:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(Resources.PasswordValidationResult_InvalidParameter)));
                            break;

                        default:
                            AddCustomErrorToValidationResults(
                                new CustomError(Resources.EditUserView_PasswordTitle,
                                    string.Format(Resources.PasswordValidationResult_UnknownError)));
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

        public DelegateCommand<gcsApplication> AddEntityApplicationCommand { get; private set; }
        public DelegateCommand<gcsApplication> DeleteEntityApplicationCommand { get; private set; }

        public DelegateCommand<gcsRole> AddEntityApplicationRoleCommand { get; private set; }
        public DelegateCommand<gcsRole> DeleteEntityApplicationRoleCommand { get; private set; }


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
            User.AllEntities.Remove(obj);
            User.AllEntities.Add(obj);
            User.MakeDirty();
        }

        private void OnDeleteEntityCommand(gcsEntity obj)
        {
            if (obj == null)
                return;
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            User.AllEntities.Remove(obj);
            User.AllEntities.Add(obj);
            User.MakeDirty();
        }

        private void OnAddEntityApplicationCommand(gcsApplication obj)
        {
            if (obj == null || CurrentEntity == null)
                return;
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentEntity.AllApplications.Remove(obj);
            //CurrentEntity.AllApplications.Add(obj);
            _User.MakeDirty();
        }

        private void OnDeleteEntityApplicationCommand(gcsApplication obj)
        {
            if (obj == null || CurrentEntity == null)
                return;
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentEntity.AllApplications.Remove(obj);
            //CurrentEntity.AllApplications.Add(obj);
            _User.MakeDirty();

        }

        private void OnAddEntityApplicationRoleCommand(gcsRole obj)
        {
            if (obj == null || CurrentApplication == null)
                return;
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentApplication.AllRoles.Remove(obj);
            //CurrentApplication.AllRoles.Add(obj);
            _User.MakeDirty();
        }

        private void OnDeleteEntityApplicationRoleCommand(gcsRole obj)
        {
            if (obj == null || CurrentApplication == null)
                return;
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentApplication.AllRoles.Remove(obj);
            //CurrentApplication.AllRoles.Add(obj);
            _User.MakeDirty();

        }

        public ObservableCollection<gcsApplication> Applications
        { get { return Globals.Instance.Applications; } }

        public ObservableCollection<gcsLanguage> Languages
        { get { return Globals.Instance.Languages; } }

        public ObservableCollection<gcsEntityEx> Entities
        { get { return Globals.Instance.Entities; } }

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
                sb.AppendLine(string.Format(Resources.PasswordRule_CannotContainIllegalContent));

            if (userReqs.UseCustomRegEx)
            {
                sb.AppendLine(string.Format(Resources.PasswordRule_MustMatchRegularExpression,
                    userReqs.PasswordCustomRegEx, userReqs.RegularExpressionDescription));
                return sb.ToString();
            }

            if (userReqs.PasswordMinimumLength > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MinimumLength,
                    userReqs.PasswordMinimumLength));

            if (userReqs.PasswordMaximumLength > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MaximumLength,
                    userReqs.PasswordMaximumLength));


            if (userReqs.RequireUpperCaseLetterCount > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MustContainUpperCaseCharacterCount,
                    userReqs.RequireUpperCaseLetterCount));


            if (userReqs.RequireLowerCaseLetterCount > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MustContainLowerCaseCharacterCount,
                    userReqs.RequireLowerCaseLetterCount));


            if (userReqs.RequireNumericDigitCount > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MustContainNumericDigitsCount,
                    userReqs.RequireNumericDigitCount));


            if (userReqs.RequireSpecialCharacterCount > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MustContainSpecialCharacterCount,
                    userReqs.PasswordMaximumLength));


            if (userReqs.MaintainPasswordHistoryCount > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_CannotReuseRecentPasswords,
                    userReqs.MaintainPasswordHistoryCount));


            if (userReqs.PasswordMinimumChangeCharacters > 0)
                sb.AppendLine(string.Format(Resources.PasswordRule_MustChangeCharacterCount,
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
                // Extra validation gets added here
                bool isNew = (_User.UserId == Guid.Empty);
                var saveParams = new SaveParameters<gcsUser>(_User);
                if (UseAsyncServiceCalls == false)
                {
                    var savedUser = _UserManager.SaveUser(saveParams );
                    if (savedUser != null)
                    {
                        if (UserUpdated != null)
                            UserUpdated(this, new UserEventArgs(savedUser, isNew));
                    }
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
                dlgService.ShowRadDialog(adUserControl, null, Resources.Dialog_SelectActiveDirectoryUserTitle);
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
                dlgService.ShowRadDialog(captureControl, null, Resources.Dialog_SelectCapturePhotoTitle);
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
            dlgService.ShowRadDialog(captureControl, null, Resources.Dialog_SelectCapturePhotoTitle);
            ClearBackgroundSubdued();
            if (captureControl.ImageCroppedAndScaled != null)
            {
                _User.SecurityImage = ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
            }
        }
    }
}