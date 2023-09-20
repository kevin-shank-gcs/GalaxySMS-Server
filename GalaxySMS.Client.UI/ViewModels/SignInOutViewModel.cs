using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.UI.Properties;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Converters;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.Utils;
using GCS.Framework.Security;
//using System.Drawing;

namespace GalaxySMS.Client.UI.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SignInOutViewModel : ViewModelBase
    {
        #region Constructor

        [ImportingConstructor]
        public SignInOutViewModel()
        {
            HeaderBackground = new SolidColorBrush(Colors.Black);
            FooterBackground = new SolidColorBrush(Color.FromRgb(0x2E, 0x2E, 0x2E));

            var lgb = new LinearGradientBrush(Color.FromRgb(0x90, 0x8B, 0x8B),
                Color.FromRgb(0x67, 0x65, 0x64),
                new Point(0, 0), new Point(1, 1));
            lgb.GradientStops[0].Offset = 0.933;
            lgb.GradientStops[1].Offset = 0.337;
            MiddleBackground = lgb;

            BusyContent = Properties.Resources.SignInOutView_PleaseWait_ValidatingCredentialsWithServer;

            var gradientStops = new GradientStopCollection(2)
            {
                //new GradientStop(Color.FromRgb(0xAC, 0xA8, 0xA8), 0),
//                 new GradientStop(Color.FromRgb(0xF9, 0xF9, 0xF9), 1)
                new GradientStop(Color.FromRgb(0x40, 0x40, 0x40), 0),
               new GradientStop(Color.FromRgb(0xc0, 0xc0, 0xc0), 1)
            };

            var rgb = new RadialGradientBrush(gradientStops);
            MiddleBackground = rgb;
            TextForeColor = new SolidColorBrush(ColorUtilities.ContrastColor(gradientStops[1].Color));

            BuildServersCollection();
            BuildAuthenticationTypesCollection();

            if (UserSessionToken != null && UserSessionToken.UserData != null)
            {
                UserName = UserSessionToken.UserData.DisplayName;
                AuthenticationType = (from at in AuthenticationTypes
                                      where at.AuthenticationType == UserSessionToken.AuthenticationType
                                      select at).FirstOrDefault();
                IsServiceAddressFieldEnabled = false;
                IsAuthenticationTypeFieldEnabled = false;
            }
            else
            {
                //UserName = string.Empty;

                _applicationUserName = GalaxySMS.Resources.Resources.DefaultUserLoginName;//"administrator";// string.Empty;
                _applicationUserPassword = GalaxySMS.Resources.Resources.DefaultUserPassword;//"P@$$word";//string.Empty;
                UserName = _applicationUserName;

                IsServiceAddressFieldEnabled = true;
                IsAuthenticationTypeFieldEnabled = true;
            }

            SignInCommand = new DelegateCommand<object>(ExecuteSignInCommandAsync, CanExecuteSignInCommand);
            SignOutCommand = new DelegateCommand<object>(ExecuteSignOutCommand, CanExecuteSignOutCommand);
            CancelCommand = new DelegateCommand<object>(ExecuteCancelCommand);
            SendTwoFactorTokenCommand = new DelegateCommand<object>(ExecuteSendTwoFactorTokenCommandAsync, CanExecuteSendTwoFactorTokenCommand);
        }



        #endregion Constructor

        #region Private fields

        private UserSessionManager _UserSessionManager;
        private EntityManager _entityManager;

        private readonly string[] _localMachineAliases = new string[4] { ".\\", "localhost", "127.0.0.1", "" };

        private string _applicationUserName = string.Empty;
        private string _windowUserName = string.Empty;
        private readonly string _currentWindowsUserName = PrincipalIdentity.CurrentWindowsUserName;
        private string _applicationUserPassword = GalaxySMS.Resources.Resources.DefaultUserPassword;// string.Empty;
        private string _windowsUserPassword = string.Empty;
        private bool? _dialogResult;
        private string _headerText;
        private ObservableCollection<string> _servers;
        private string _serverAddress;
        private bool _isBusy;
        private string _busyContent;
        private string _resultMessage;
        private Brush _resultMessageForecolor;
        private GalaxySiteServerConnection _galaxySiteServerConnection;

        private GalaxySiteServerConnectionSettings _galaxySiteServerConnectionSettings =
            new GalaxySiteServerConnectionSettings();

        private ObservableCollection<AuthenticationTypeData> _authenticationTypes;
        private AuthenticationTypeData _authenticationType;

        #endregion Private fields

        #region Public properties

        public GalaxySiteServerConnectionSettings SiteServerConnectionSettings
        {
            get { return _galaxySiteServerConnectionSettings; }
            internal set
            {
                if (_galaxySiteServerConnectionSettings != value)
                {
                    _galaxySiteServerConnectionSettings = value;
                    OnPropertyChanged(() => SiteServerConnectionSettings, false);
                }
            }
        }

        public bool? DialogResult
        {
            get { return _dialogResult; }
            internal set
            {
                _dialogResult = value;
                OnPropertyChanged(() => DialogResult, false);
            }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                if (_headerText != value)
                {
                    _headerText = value;
                    OnPropertyChanged(() => HeaderText, false);
                }
            }
        }

        public ObservableCollection<string> Servers
        {
            get { return _servers; }
            set
            {
                if (_servers != value)
                {
                    _servers = value;
                    OnPropertyChanged(() => Servers, false);
                }
            }
        }

        public string ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                if (_serverAddress != value)
                {
                    _serverAddress = value;
                    OnPropertyChanged(() => ServerAddress, true);
                }
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(() => IsBusy, false);
                }
            }
        }

        public string BusyContent
        {
            get { return _busyContent; }
            set
            {
                if (_busyContent != value)
                {
                    _busyContent = value;
                    OnPropertyChanged(() => BusyContent, false);
                }
            }
        }

        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                if (_resultMessage != value)
                {
                    _resultMessage = value;
                    OnPropertyChanged(() => ResultMessage, false);
                    OnPropertyChanged(() => IsResultMessageVisible, false);
                }
            }
        }

        public bool IsResultMessageVisible
        {
            get
            {
                if (string.IsNullOrEmpty(ResultMessage))
                    return false;
                return ResultMessage.Length > 0;
            }
        }

        public Brush ResultMessageForecolor
        {
            get { return _resultMessageForecolor; }
            set
            {
                if (_resultMessageForecolor != value)
                {
                    _resultMessageForecolor = value;
                    OnPropertyChanged(() => ResultMessageForecolor, false);
                }
            }
        }

        //private string _serverText;

        //public string ServerText
        //{
        //    get { return _serverText; }
        //    set
        //    {
        //        if (_serverText != value)
        //        {
        //            _serverText = value;
        //            OnPropertyChanged(() => ServerText, true);
        //        }
        //    }
        //}

        public ObservableCollection<AuthenticationTypeData> AuthenticationTypes
        {
            get { return _authenticationTypes; }
            set
            {
                if (_authenticationTypes != value)
                {
                    _authenticationTypes = value;
                    OnPropertyChanged(() => AuthenticationTypes, false);
                }
            }
        }

        public AuthenticationTypeData AuthenticationType
        {
            get { return _authenticationType; }
            set
            {
                if (_authenticationType != value)
                {
                    _authenticationType = value;
                    UpdateUserNamePasswordValues();
                    OnPropertyChanged(() => AuthenticationType, true);
                    OnPropertyChanged(() => IsUserNameFieldEnabled, false);
                    OnPropertyChanged(() => IsPasswordFieldEnabled, false);
                }
            }
        }

        private void UpdateUserNamePasswordValues()
        {
            if (AuthenticationType != null)
            {
                switch (AuthenticationType.AuthenticationType)
                {
                    case GCS.Framework.Security.AuthenticationType.Application:
                        UserName = _applicationUserName;
                        Password = _applicationUserPassword;
                        break;

                    case GCS.Framework.Security.AuthenticationType.WindowsCurrentUser:
                        UserName = _currentWindowsUserName;
                        Password = string.Empty;
                        break;

                    case GCS.Framework.Security.AuthenticationType.WindowsUser:
                        UserName = _windowUserName;
                        Password = _windowsUserPassword;
                        break;
                }
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                // preserve the previous values
                if (AuthenticationType != null)
                {
                    switch (AuthenticationType.AuthenticationType)
                    {
                        case GCS.Framework.Security.AuthenticationType.Application:
                            //                            value = GalaxySMS.Resources.Resources.DefaultUserLoginName;
                            _applicationUserName = value;
                            break;

                        case GCS.Framework.Security.AuthenticationType.WindowsCurrentUser:
                            break;

                        case GCS.Framework.Security.AuthenticationType.WindowsUser:
                            _windowUserName = value;
                            break;
                    }
                }

                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName, true);
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                // preserve the previous values
                if (AuthenticationType != null)
                {
                    switch (AuthenticationType.AuthenticationType)
                    {
                        case GCS.Framework.Security.AuthenticationType.Application:
                            _applicationUserPassword = value;
                            break;

                        case GCS.Framework.Security.AuthenticationType.WindowsCurrentUser:
                            break;

                        case GCS.Framework.Security.AuthenticationType.WindowsUser:
                            _windowsUserPassword = value;
                            break;
                    }
                }
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password, true);
                }
            }
        }

        private string _twoFactorToken;

        public string TwoFactorToken
        {
            get { return _twoFactorToken; }
            set
            {
                if (_twoFactorToken != value)
                {
                    _twoFactorToken = value;
                    OnPropertyChanged(() => TwoFactorToken, true);
                }
            }
        }

        private string _footerText;

        public string FooterText
        {
            get { return _footerText; }
            set
            {
                if (_footerText != value)
                {
                    _footerText = value;
                    OnPropertyChanged(() => FooterText, false);
                }
            }
        }

        private string _copyrightNotice;

        public string CopyrightNotice
        {
            get { return _copyrightNotice; }
            set
            {
                if (_copyrightNotice != value)
                {
                    _copyrightNotice = value;
                    OnPropertyChanged(() => CopyrightNotice, false);
                }
            }
        }

        private Brush _headerBackground;

        public Brush HeaderBackground
        {
            get { return _headerBackground; }
            set
            {
                if (_headerBackground != value)
                {
                    _headerBackground = value;
                    OnPropertyChanged(() => HeaderBackground, false);
                }
            }
        }

        private Brush _middleBackground;

        public Brush MiddleBackground
        {
            get { return _middleBackground; }
            set
            {
                if (_middleBackground != value)
                {
                    _middleBackground = value;
                    OnPropertyChanged(() => MiddleBackground, false);
                }
            }
        }

        private Brush _footerBackground;

        public Brush FooterBackground
        {
            get { return _footerBackground; }
            set
            {
                if (_footerBackground != value)
                {
                    _footerBackground = value;
                    OnPropertyChanged(() => FooterBackground, false);
                }
            }
        }


        private Brush _textForeColor;

        public Brush TextForeColor
        {
            get { return _textForeColor; }
            set
            {
                if (_textForeColor != value)
                {
                    _textForeColor = value;
                    OnPropertyChanged(() => TextForeColor, false);
                }
            }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _userSessionToken; }
            set
            {
                _userSessionToken = value;
                OnPropertyChanged(() => UserSessionToken, false);
                if (UserSessionToken != null && UserSessionToken.UserData != null)
                {
                    UserName = UserSessionToken.UserData.UserName;
                }
                else
                    UserName = GalaxySMS.Resources.Resources.DefaultUserLoginName;// string.Empty;
            }
        }

        private string _applicationName;

        public string ApplicationName
        {
            get { return _applicationName; }
            set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                    OnPropertyChanged(() => ApplicationName, false);
                }
            }
        }

        private Guid _applicationGuid;
        private UserSessionToken _userSessionToken;

        public Guid ApplicationGuid
        {
            get { return _applicationGuid; }
            set
            {
                if (_applicationGuid != value)
                {
                    _applicationGuid = value;
                    OnPropertyChanged(() => ApplicationGuid, false);
                }
            }
        }

        private bool _isAuthenticationTypeFieldEnabled;

        public bool IsAuthenticationTypeFieldEnabled
        {
            get { return _isAuthenticationTypeFieldEnabled; }
            set
            {
                if (_isAuthenticationTypeFieldEnabled != value)
                {
                    _isAuthenticationTypeFieldEnabled = value;
                    OnPropertyChanged(() => IsAuthenticationTypeFieldEnabled, false);
                }
            }
        }

        private bool _isServiceAddressFieldEnabled;

        public bool IsServiceAddressFieldEnabled
        {
            get { return _isServiceAddressFieldEnabled; }
            set
            {
                if (_isServiceAddressFieldEnabled != value)
                {
                    _isServiceAddressFieldEnabled = value;
                    OnPropertyChanged(() => IsServiceAddressFieldEnabled, false);
                }
            }
        }

        public bool IsUserNameFieldEnabled
        {
            get
            {
                if (AuthenticationType == null)
                    return false;
                if (UserSessionToken != null && UserSessionToken.UserData != null &&
                    UserSessionToken.SessionId != Guid.Empty)
                    return false;
                switch (AuthenticationType.AuthenticationType)
                {
                    case GCS.Framework.Security.AuthenticationType.Application:
                        return true;

                    case GCS.Framework.Security.AuthenticationType.WindowsCurrentUser:
                        return false;

                    case GCS.Framework.Security.AuthenticationType.WindowsUser:
                        return true;
                }
                return false;
            }
            set { OnPropertyChanged(() => IsUserNameFieldEnabled, false); }
        }

        public bool IsPasswordFieldEnabled
        {
            get
            {
                if (AuthenticationType == null)
                    return false;

                if (IsTwoFactorTokenControlEnabled)
                    return false;

                switch (AuthenticationType.AuthenticationType)
                {
                    case GCS.Framework.Security.AuthenticationType.Application:
                        return true;

                    case GCS.Framework.Security.AuthenticationType.WindowsCurrentUser:
                        return false;

                    case GCS.Framework.Security.AuthenticationType.WindowsUser:
                        return true;
                }
                return false;
            }
            set { OnPropertyChanged(() => IsPasswordFieldEnabled, false); }
        }

        private bool _IsTwoFactorTokenControlEnabled;
        private GalaxySiteServerConnection _siteServerConnection;

        public bool IsTwoFactorTokenControlEnabled
        {
            get { return _IsTwoFactorTokenControlEnabled; }
            set
            {
                if (_IsTwoFactorTokenControlEnabled != value)
                {
                    _IsTwoFactorTokenControlEnabled = value;
                    OnPropertyChanged(() => IsTwoFactorTokenControlEnabled, false);
                }
            }
        }

        #endregion Public properties

        #region Commands

        public DelegateCommand<object> SignInCommand { get; private set; }

        public DelegateCommand<object> SignOutCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SendTwoFactorTokenCommand { get; private set; }
        #endregion Commands

        #region Private methods

        private void BuildServersCollection()
        {
            Servers = new ObservableCollection<string>();
            Servers.Add("localhost");
        }

        private void BuildAuthenticationTypesCollection()
        {
            AuthenticationTypes = new ObservableCollection<AuthenticationTypeData>();
            AuthenticationTypes.Add(new AuthenticationTypeData
            {
                AuthenticationType = GCS.Framework.Security.AuthenticationType.Application,
                Description = Properties.Resources.SignInOutView_AuthenticationTypeApplication
            });
            AuthenticationTypes.Add(new AuthenticationTypeData
            {
                AuthenticationType = GCS.Framework.Security.AuthenticationType.WindowsCurrentUser,
                Description = Properties.Resources.SignInOutView_AuthenticationTypeWindowsCurrentUser
            });
            AuthenticationTypes.Add(new AuthenticationTypeData
            {
                AuthenticationType = GCS.Framework.Security.AuthenticationType.WindowsUser,
                Description = Properties.Resources.SignInOutView_AuthenticationTypeWindowsUser
            });
        }

        private void ExecuteCancelCommand(object obj)
        {
            DialogResult = false;
        }

        private bool CanExecuteSignOutCommand(object obj)
        {
            if (UserSessionToken == null || UserSessionToken.SessionId == Guid.Empty || IsTwoFactorTokenControlEnabled)
                return false;
            return true;
        }

        private void ExecuteSignOutCommand(object obj)
        {
            if (_UserSessionManager == null)
            {
                _galaxySiteServerConnectionSettings = new GalaxySiteServerConnectionSettings();

                var serverAddress = ServerAddress;
                //if (string.IsNullOrEmpty(ServerText) == false)
                //    serverAddress = ServerText;

                foreach (var localAlias in _localMachineAliases)
                {
                    if (localAlias == ServerAddress)
                        serverAddress = "localhost";
                }
                _galaxySiteServerConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
                _galaxySiteServerConnectionSettings.ServerAddress = serverAddress;
                _galaxySiteServerConnectionSettings.UserName = UserName;
                _galaxySiteServerConnectionSettings.Password = Password;

                var siteServerConnection = new GalaxySiteServerConnection(_galaxySiteServerConnectionSettings);
                _UserSessionManager = new UserSessionManager(siteServerConnection);

                _UserSessionManager.ErrorsOccurredEvent += UserSessionManagerOnErrorsOccurredEvent;
                _UserSessionManager.RequestUserSignInCompletedEvent +=
                    UserSessionManagerOnRequestUserSignInCompletedEvent;
                _UserSessionManager.UserSignOutCompletedEvent += _UserSessionManager_UserSignOutCompletedEvent;
                _UserSessionManager.UserRefreshCompletedEvent += _UserSessionManager_UserRefreshCompletedEvent;
            }

            _UserSessionManager.SignOutUserSessionTokenVoidAsync(UserSessionToken);
        }

        private bool CanExecuteSignInCommand(object obj)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return false;
            return true;
        }

        //private void ExecuteSignInCommand(object obj)
        //{
        //    _galaxySiteServerConnectionSettings = new GalaxySiteServerConnectionSettings();

        //    var serverAddress = ServerAddress;
        //    //if (string.IsNullOrEmpty(ServerText) == false)
        //    //    serverAddress = ServerText;

        //    foreach (var localAlias in _localMachineAliases)
        //    {
        //        if (localAlias == ServerAddress)
        //            serverAddress = "localhost";
        //    }
        //    _galaxySiteServerConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
        //    _galaxySiteServerConnectionSettings.ServerAddress = serverAddress;
        //    _galaxySiteServerConnectionSettings.UserName = UserName;
        //    _galaxySiteServerConnectionSettings.Password = Password;

        //    var siteServerConnection = new GalaxySiteServerConnection(_galaxySiteServerConnectionSettings);
        //    _UserSessionManager = new UserSessionManager(siteServerConnection);

        //    _UserSessionManager.ErrorsOccurredEvent += UserSessionManagerOnErrorsOccurredEvent;
        //    _UserSessionManager.RequestUserSignInCompletedEvent += UserSessionManagerOnRequestUserSignInCompletedEvent;
        //    _UserSessionManager.UserSignOutCompletedEvent += _UserSessionManager_UserSignOutCompletedEvent;
        //    _UserSessionManager.UserRefreshCompletedEvent += _UserSessionManager_UserRefreshCompletedEvent;
        //    var userSignInRequest = new UserSignInRequest();

        //    userSignInRequest.AuthenticationType = AuthenticationType.AuthenticationType;
        //    userSignInRequest.UserName = UserName;

        //    userSignInRequest.Password = Password;
        //    userSignInRequest.MinimumExecutionTime = 1500;
        //    IsBusy = true;
        //    _UserSessionManager.SignInRequestAsync(userSignInRequest);
        //}
        private async void ExecuteSignInCommandAsync(object obj)
        {
            _galaxySiteServerConnectionSettings = new GalaxySiteServerConnectionSettings();

            var serverAddress = ServerAddress;
            //if (string.IsNullOrEmpty(ServerText) == false)
            //    serverAddress = ServerText;

            foreach (var localAlias in _localMachineAliases)
            {
                if (localAlias == ServerAddress)
                    serverAddress = "localhost";
            }
            _galaxySiteServerConnectionSettings.BindingType = GalaxySiteServerConnectionSettings.WcfBindingType.Tcp;
            _galaxySiteServerConnectionSettings.ServerAddress = serverAddress;
            _galaxySiteServerConnectionSettings.UserName = UserName;
            _galaxySiteServerConnectionSettings.Password = Password;

            _siteServerConnection = new GalaxySiteServerConnection(_galaxySiteServerConnectionSettings);
            _UserSessionManager = new UserSessionManager(_siteServerConnection);

            _UserSessionManager.ErrorsOccurredEvent += UserSessionManagerOnErrorsOccurredEvent;
            _UserSessionManager.RequestUserSignInCompletedEvent += UserSessionManagerOnRequestUserSignInCompletedEvent;
            _UserSessionManager.UserSignOutCompletedEvent += _UserSessionManager_UserSignOutCompletedEvent;
            _UserSessionManager.UserRefreshCompletedEvent += _UserSessionManager_UserRefreshCompletedEvent;

            var userSignInRequest = new UserSignInRequest();

            userSignInRequest.PermissionsForApplicationIds.Add(ApplicationIds.GalaxySMS_DefaultApp_Id);

            userSignInRequest.ApplicationId = this.ApplicationGuid;
            userSignInRequest.ApplicationName = this.ApplicationName;
            userSignInRequest.AuthenticationType = AuthenticationType.AuthenticationType;
            userSignInRequest.UserName = UserName;
            userSignInRequest.Password = Password;
            //userSignInRequest.MinimumExecutionTime = 1500;
            userSignInRequest.IncludeEntityPhotos = true;
            userSignInRequest.EntityPhotosPixelWidth = 200;
            userSignInRequest.IncludeUserPhotos = true;
            userSignInRequest.UserPhotosPixelWidth = 200;
            IsBusy = true;

            var result = await _UserSessionManager.SignInRequestAsync(userSignInRequest);

            await ProcessUserSignInResult(result);
            IsBusy = false;
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
                    UserSessionToken = result.SessionToken;
                    UserName = UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    IsServiceAddressFieldEnabled = false;
                    IsAuthenticationTypeFieldEnabled = false;
                    await ObtainUserEntityData();
                    CloseAction(true);
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
                    UserSessionToken = result.SessionToken;
                    UserName = UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    IsServiceAddressFieldEnabled = false;
                    IsAuthenticationTypeFieldEnabled = false;
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
                    UserSessionToken = result.SessionToken;
                    _UserSessionManager.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
                    UserName = UserSessionToken.UserData.UserName;
                    Password = string.Empty;
                    IsServiceAddressFieldEnabled = false;
                    IsAuthenticationTypeFieldEnabled = false;
                    IsPasswordFieldEnabled = false;
                    IsUserNameFieldEnabled = false;
                    IsTwoFactorTokenControlEnabled = true;
                    break;

                case UserSignInRequestResult.InvalidTwoFactorToken:
                    ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                    ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_InvalidTwoFactorToken);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            OnPropertyChanged(() => IsUserNameFieldEnabled, false);
            OnPropertyChanged(() => IsPasswordFieldEnabled, false);
        }

        private async Task ObtainUserEntityData()
        {
            _siteServerConnection.ClientUserSessionData.SessionGuid = UserSessionToken.SessionId;
            var entityManager = new EntityManager(_siteServerConnection);
            var userSessionManager = new UserSessionManager(_siteServerConnection);

            var parameters = new GetParametersWithPhoto()
            {
                UniqueId = _userSessionToken.UserData.UserId,
                IncludePhoto = true,
                PhotoPixelWidth = 200,
            };

            parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, true));

            var tempUes = _userSessionToken.UserData.UserEntities.ToList();
            var entitiesForUser = await entityManager.GetEntityListForUserAsync(parameters);

            if (!entityManager.HasErrors && entitiesForUser?.Items != null)
            {
                // Get for users Primary Entity and the Facility Manager app
                var userEntities = await userSessionManager.GetUserEntityAsync(_userSessionToken.UserData.PrimaryEntityId);
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

            _userSessionToken.UserData.UserEntities = tempUes.ToObservableCollection();
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

        private void _UserSessionManager_UserSignOutCompletedEvent(object sender, UserSignOutCompletedEventArgs e)
        {
            UserSessionToken = e.UserSessionToken;
            ResultMessageForecolor = null;
            ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignOutResult);
            UserName = string.Empty;
            Password = string.Empty;
            IsServiceAddressFieldEnabled = true;
            IsAuthenticationTypeFieldEnabled = true;
            IsTwoFactorTokenControlEnabled = false;

            OnPropertyChanged(() => IsUserNameFieldEnabled, false);
            OnPropertyChanged(() => IsPasswordFieldEnabled, false);
        }

        private void _UserSessionManager_UserRefreshCompletedEvent(object sender, UserRefreshCompletedEventArgs e)
        {
        }

        private void UserSessionManagerOnRequestUserSignInCompletedEvent(object sender,
            RequestUserSignInCompletedEventArgs requestUserSignInCompletedEventArgs)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                IsBusy = false;
                switch (requestUserSignInCompletedEventArgs.UserSignInResult.RequestResult)
                {
                    case UserSignInRequestResult.Unknown:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_Unknown);
                        break;
                    case UserSignInRequestResult.Success:
                        ResultMessageForecolor = null;
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_Success,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        UserSessionToken = requestUserSignInCompletedEventArgs.UserSignInResult.SessionToken;
                        UserName = UserSessionToken.UserData.UserName;
                        Password = string.Empty;
                        IsServiceAddressFieldEnabled = false;
                        IsAuthenticationTypeFieldEnabled = false;
                        CloseAction(true);
                        break;

                    case UserSignInRequestResult.SuccessWithInfo:
                        ResultMessageForecolor = null;
                        var infoMessage = string.Empty;
                        foreach (var info in requestUserSignInCompletedEventArgs.UserSignInResult.SuccessInformation)
                        {
                            switch (info)
                            {
                                case SuccessInfo.None:
                                    break;
                                case SuccessInfo.UserAccountSoonToExpire:
                                    infoMessage +=
                                        string.Format(
                                            Properties.Resources.SignInOutView_UserSignInResult_SuccessInfo_SoonToExpire,
                                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName,
                                            requestUserSignInCompletedEventArgs.UserSignInResult.AccountSoonToExpireDays);
                                    break;
                                case SuccessInfo.PasswordMustBeChanged:
                                    infoMessage +=
                                        string.Format(
                                            Properties.Resources.SignInOutView_UserSignInResult_SuccessInfo_PasswordMustBeChanged,
                                            requestUserSignInCompletedEventArgs.UserSignInResult.PasswordChangeDays);
                                    break;
                            }
                        }

                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_SuccessWithInfo,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        ResultMessage += "\n";
                        ResultMessage += infoMessage;
                        UserSessionToken = requestUserSignInCompletedEventArgs.UserSignInResult.SessionToken;
                        UserName = UserSessionToken.UserData.UserName;
                        Password = string.Empty;
                        IsServiceAddressFieldEnabled = false;
                        IsAuthenticationTypeFieldEnabled = false;
                        break;
                    case UserSignInRequestResult.InvalidUserName:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_UserIdNotValid,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        break;
                    case UserSignInRequestResult.InvalidPassword:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_PasswordIncorrect);
                        break;
                    case UserSignInRequestResult.UserAccountIsNotActive:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_NotActive,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        break;
                    case UserSignInRequestResult.UserAccountIsLockedOut:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_LockedOut,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        break;
                    case UserSignInRequestResult.ApplicationNotPermitted:
                        ResultMessageForecolor = new SolidColorBrush(Colors.Red);
                        ResultMessage = string.Format(Properties.Resources.SignInOutView_UserSignInResult_ApplicationNotPermitted,
                            requestUserSignInCompletedEventArgs.UserSignInResult.RequestData.UserName);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OnPropertyChanged(() => IsUserNameFieldEnabled, false);
                OnPropertyChanged(() => IsPasswordFieldEnabled, false);
            });
        }

        private void UserSessionManagerOnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            IsBusy = false;
            foreach (var error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private bool CanExecuteSendTwoFactorTokenCommand(object obj)
        {
            if (_UserSessionManager == null)
                return false;

            if (_userSessionToken == null || _userSessionToken.SessionId == Guid.Empty || string.IsNullOrEmpty(TwoFactorToken) || TwoFactorToken.Length != 6)
                return false;

            return true;
        }

        private async void ExecuteSendTwoFactorTokenCommandAsync(object obj)
        {
            IsBusy = true;
            var result = await _UserSessionManager.VerifyTwoFactorAuthenticationTokenAsync(new TwoFactorAuthenticationData()
            {
                SessionId = _userSessionToken.SessionId,
                TwoFactorToken = this.TwoFactorToken
            });

            IsBusy = false;

            ProcessUserSignInResult(result);

        }

        #endregion Private methods
    }
}