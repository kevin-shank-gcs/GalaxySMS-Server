using GalaSoft.MvvmLight.CommandWpf;
using GalaxySMS.Client.SDK.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using GCS.Core.Common.Logger;
using System.Linq;
using GCS.Core.Common.UI.Core;
using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.Entities;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        #region Private fields
        private string _userName = "administrator";//string.Empty;
        private string _password = "P@$$word";//string.Empty;
        private RelayCommand _signInCommand;
        private RelayCommand _signOutCommand;
        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }


        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName, false);
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password, false);
                }
            }
        }
        #endregion



        //public RelayCommand SignInCommand
        //{
        //    get
        //    {
        //        return _signInCommand
        //            ?? (_signInCommand = new RelayCommand(
        //            async () =>
        //            {
        //                try
        //                {
        //                    Globals.IsBusy = true;
        //                    Globals.BusyContent = "Please wait while the server is thinking...";
        //                    // Use the Globals.GetManager<T> helper method to get a usable UserSessionManager object
        //                    var mgr = Globals.GetManager<UserSessionManager>();

        //                    // Call the SignInRequestAsync method and save the result.
        //                    var userSignInRequest = new Client.Entities.UserSignInRequest()
        //                    {
        //                        SignInBy = Client.Entities.UserSignInRequestBase.SignInUsing.AutoDetect,
        //                        UserName = UserName,
        //                        Password = Password,
        //                        // The ApplicationId is important. The user must be allowed to use the application that is identified by this value
        //                        ApplicationId = ApplicationIds.GalaxySMS_DefaultApp_Id, 
        //                        IncludeEntityPhotos = true,
        //                        EntityPhotosPixelWidth = 200,
        //                        IncludeUserPhotos = true,
        //                        UserPhotosPixelWidth = 200,
        //                    };

        //                    userSignInRequest.PermissionsForApplicationIds.Add(mgr.ClientUserSessionData.ApplicationId);

        //                    Globals.SignInResult = await mgr.SignInRequestAsync(userSignInRequest);

        //                    // The result can be evaluated by examining the RequestResult enum value
        //                    if (Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.Success || Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.SuccessWithInfo)
        //                    {
        //                        // Select the default entity
        //                        Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == Globals.UserSessionToken.UserData.PrimaryEntityId);
        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    this.Log().ErrorFormat("SignInCommand finished", e);
        //                }
        //                Globals.IsBusy = false;

        //            }));
        //    }
        //}

        public RelayCommand SignInCommand
        {
            get
            {
                return _signInCommand
                    ?? (_signInCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server is thinking...";
                            // Use the Globals.GetManager<T> helper method to get a usable UserSessionManager object
                            var mgr = Globals.GetManager<UserSessionManager>();

                            // Call the SignInRequestAsync method and save the result.
                            var userSignInRequest = new Client.Entities.UserSignInRequest()
                            {
                                SignInBy = Client.Entities.UserSignInRequestBase.SignInUsing.AutoDetect,
                                UserName = UserName,
                                Password = Password,
                                // The ApplicationId is important. The user must be allowed to use the application that is identified by this value
                                ApplicationId = ApplicationIds.GalaxySMS_DefaultApp_Id,
                                IncludeEntityPhotos = true,
                                EntityPhotosPixelWidth = 200,
                                IncludeUserPhotos = true,
                                UserPhotosPixelWidth = 200,
                            };

                            userSignInRequest.PermissionsForApplicationIds.Add(mgr.ClientUserSessionData.ApplicationId);

                            var result = await mgr.SignInRequestAsync(userSignInRequest);
                            await ProcessUserSignInResult(result);

                            // The result can be evaluated by examining the RequestResult enum value
                            if (Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.Success || Globals.SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.SuccessWithInfo)
                            {
                                // Select the default entity
                                Globals.CurrentUserEntity = Globals.CurrentUserEntities.FirstOrDefault(o => o.EntityId == Globals.UserSessionToken.UserData.PrimaryEntityId);
                            }
                            else
                            {

                            }
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat("SignInCommand finished", e);
                        }
                        Globals.IsBusy = false;

                    }));
            }
        }

        private async Task ProcessUserSignInResult(UserSignInResult result)
        {
            if (result == null)
            {
                ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_InvalidTwoFactorToken);
                return;
            }
            switch (result.RequestResult)
            {
                case UserSignInRequestResult.Unknown:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_Unknown);
                    break;

                case UserSignInRequestResult.Success:
                    ResultMessageForecolor = null;
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_Success,
                        result.RequestData.UserName);
                    Globals.SignInResult = result;
                    UserName = Globals.UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    //IsServiceAddressFieldEnabled = false;
                    //IsAuthenticationTypeFieldEnabled = false;
                    await ObtainUserEntityData();
                    //CloseAction(true);
                    break;

                case UserSignInRequestResult.SuccessWithInfo:
                    ResultMessageForecolor = null;
                    var infoMessage = string.Empty;
                    foreach (var info in result.SuccessInformation)
                    {
                        switch (info)
                        {
                            case SuccessInfo.None:
                                break;
                            case SuccessInfo.UserAccountSoonToExpire:
                                infoMessage +=
                                    string.Format(
                                        Properties.Resources.SignInOutView_UserSignInResult_SuccessInfo_SoonToExpire,
                                        result.RequestData.UserName,
                                        result.AccountSoonToExpireDays);
                                break;
                            case SuccessInfo.PasswordMustBeChanged:
                                infoMessage +=
                                    string.Format(
                                        Properties.Resources.SignInOutView_UserSignInResult_SuccessInfo_PasswordMustBeChanged,
                                        result.PasswordChangeDays);
                                break;
                        }
                    }

                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_SuccessWithInfo,
                        result.RequestData.UserName);
                    ResultMessage += "\n";
                    ResultMessage += infoMessage;
                    Globals.SignInResult = result;
                    UserName = Globals.UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    //IsServiceAddressFieldEnabled = false;
                    //IsAuthenticationTypeFieldEnabled = false;
                    await ObtainUserEntityData();
                    break;

                case UserSignInRequestResult.InvalidUserName:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_UserIdNotValid,
                        result.RequestData.UserName);
                    break;
                case UserSignInRequestResult.InvalidPassword:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_PasswordIncorrect);
                    break;
                case UserSignInRequestResult.UserAccountIsNotActive:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_NotActive,
                        result.RequestData.UserName);
                    break;
                case UserSignInRequestResult.UserAccountIsLockedOut:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_LockedOut,
                        result.RequestData.UserName);
                    break;
                case UserSignInRequestResult.ApplicationNotPermitted:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_ApplicationNotPermitted,
                        result.RequestData.UserName);
                    break;
                case UserSignInRequestResult.EmailAndPhoneNumberNotConfirmed:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_EmailOrPhoneNumberNotConfirmed,
                        result.RequestData.UserName);
                    break;

                case UserSignInRequestResult.MustProvideTwoFactorToken:
                    ResultMessageForecolor = null;
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_MustProvideTwoFactorToken);
                    Globals.SignInResult = result;
                    UserName = Globals.UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    //IsServiceAddressFieldEnabled = false;
                    //IsAuthenticationTypeFieldEnabled = false;
                    //IsPasswordFieldEnabled = false;
                    //IsUserNameFieldEnabled = false;
                    //IsTwoFactorTokenControlEnabled = true;
                    break;

                case UserSignInRequestResult.InvalidTwoFactorToken:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_InvalidTwoFactorToken);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            //OnPropertyChanged(() => IsUserNameFieldEnabled, false);
            //OnPropertyChanged(() => IsPasswordFieldEnabled, false);
        }

        public string ResultMessage { get; set; }

        public SolidColorBrush ResultMessageForecolor { get; set; }

        private async Task ObtainUserEntityData()
        {
            Globals.ServerConnection.ClientUserSessionData.SessionGuid = Globals.UserSessionToken.SessionId;
            var entityManager = Globals.GetManager<EntityManager>();
            var userSessionManager = Globals.GetManager<UserSessionManager>();

            var parameters = new GetParametersWithPhoto()
            {
                UniqueId = Globals.UserSessionToken.UserData.UserId,
                IncludePhoto = true,
                PhotoPixelWidth = 200,
            };

            parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, true));

            var tempUes = Globals.UserSessionToken.UserData.UserEntities.ToList();
            var entitiesForUser = await entityManager.GetEntityListForUserAsync(parameters);

            if (!entityManager.HasErrors && entitiesForUser?.Items != null)
            {
                // Get for users Primary Entity and the Facility Manager app
                var userEntities = await userSessionManager.GetUserEntityAsync(Globals.UserSessionToken.UserData.PrimaryEntityId);
                if (!userSessionManager.HasErrors && userEntities != null)
                {
                    var e = entitiesForUser.Items.FirstOrDefault(o => o.EntityId == userEntities.EntityId);
                    if (e != null)
                        userEntities.Thumbnail = e.Photo;
                    tempUes.Add(userEntities);
                }

                foreach (var e in entitiesForUser.Items)
                {
                    var userEntities1 = await userSessionManager.GetUserEntityAsync(e.EntityId);
                    if (!userSessionManager.HasErrors && userEntities1 != null)
                    {
                        userEntities1.Thumbnail = e.Photo;
                        await FillChildUserEntitiesRecursive(e, userSessionManager, userEntities1);
                        var currentEntity = tempUes.FirstOrDefault(o => o.EntityId == e.EntityId);
                        if (currentEntity == null)
                            tempUes.Add(userEntities1);
                        else
                        {
                            //var apps = currentEntity.Applications.ToList();
                            //apps.AddRange(userEntities1.Applications.ToList());
                            //currentEntity.UserApplications = apps;
                        }
                    }
                }
            }

            Globals.UserSessionToken.UserData.UserEntities = tempUes.ToObservableCollection();
            Globals.NotifyPropertyChange(Globals.CurrentUserEntities);
        }

        private static async Task FillChildUserEntitiesRecursive(gcsEntityBasic e, UserSessionManager userSessionManager,
            UserEntity userEntities1)
        {
            foreach (var ce in e.ChildEntities)
            {
                var childUserEntity = await userSessionManager.GetUserEntityAsync(ce.EntityId);
                if (childUserEntity != null)
                {
                    childUserEntity.Thumbnail = ce.Photo;
                    var tempChildUe = userEntities1.ChildUserEntities.ToList();
                    tempChildUe.Add(childUserEntity);
                    userEntities1.ChildUserEntities = tempChildUe.ToCollection();
                    if (ce.ChildEntities.Any())
                        await FillChildUserEntitiesRecursive(ce, userSessionManager, childUserEntity);
                }
            }
        }

        public RelayCommand SignOutCommand
        {
            get
            {
                return _signOutCommand
                       ?? (_signOutCommand = new RelayCommand(
                   async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            var mgr = Globals.GetManager<UserSessionManager>();
                            var t = await mgr.SignOutAsync(Globals.UserSessionToken.SessionId);
                            Globals.UserSignedOut(t);
                        }
                        catch (Exception e)
                        {
                            Trace.WriteLine(e.ToString());
                        }
                        Globals.IsBusy = false;
                    }));

            }
        }


        public MainViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
        }

        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

    }
}