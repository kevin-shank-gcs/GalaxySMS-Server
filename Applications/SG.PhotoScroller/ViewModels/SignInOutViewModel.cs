using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SG.PhotoScroller.Properties;
using SG.PhotoScroller.Support.Telerik;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Utilities;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace SG.PhotoScroller.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SignInOutViewModel : ViewModelBase
    {
        #region Constructor

        public SignInOutViewModel()
        {
            HeaderBackground = new LinearGradientBrush(Colors.SteelBlue, Colors.DarkGray, .5);
            MiddleBackground = new LinearGradientBrush(Colors.SkyBlue, Colors.WhiteSmoke, .5);
            GradientStartColor = Colors.Transparent;
            GradientMiddleColor = Colors.Transparent;
            GradientStopColor = Colors.Transparent;
            SignInCommand = new DelegateCommand<object>(ExecuteSignInCommand, CanExecuteSignInCommand);
            SignOutCommand = new DelegateCommand<object>(ExecuteSignOutCommand, CanExecuteSignOutCommand);
        }

        #endregion

        #region Public properties


        private Nullable<bool> _dialogResult;

        public Nullable<bool> DialogResult
        {
            get { return _dialogResult; }
            internal set
            {
                _dialogResult = value;
                OnPropertyChanged(() => DialogResult, false);
            }
        }

        public Color GradientStartColor { get; set; }
        public Color GradientMiddleColor { get; set; }
        public Color GradientStopColor { get; set; }

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


        private string _headerText;

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


        public Globals Globals
        {
            get { return Globals.Instance; }
        }
        public override string ViewTitle
        {
            get
            {
                return Resources.SignInOutView_Title;
            }
        }

        private string _userName;

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

        private string _password;

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
        
        public DelegateCommand<object> SignInCommand { get; private set; }
        public DelegateCommand<object> SignOutCommand { get; private set; }

        #endregion Public properties

        #region Private methods

        private bool CanExecuteSignInCommand(object obj)
        {
            return !Globals.IsSignedIn;
        }

        private void ExecuteSignInCommand(object obj)
        {
            if (Globals.Instance.SignIn(UserName, Password) == true)
            {
                Password = string.Empty;
                DialogResult = true;
            }
        }

        private bool CanExecuteSignOutCommand(object obj)
        {
            return Globals.IsSignedIn;
        }

        private void ExecuteSignOutCommand(object obj)
        {
            Globals.Instance.SignOut();
        }
        #endregion

    }
}
