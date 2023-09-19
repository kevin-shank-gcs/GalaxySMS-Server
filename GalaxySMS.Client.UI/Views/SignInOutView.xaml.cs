using System.Linq;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.UI.ViewModels;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Security;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace GalaxySMS.Client.UI.Views
{
    /// <summary>
    /// Interaction logic for SignInOutView.xaml
    /// </summary>
    public partial class SignInOutView : UserControlViewBase
    {
        private SignInOutViewModel _viewModel = new SignInOutViewModel();
        public SignInOutView()
        {
            InitializeComponent();
            DataContext = _viewModel;

            Loaded += UserControl_Loaded;
            DialogResult = null;
            if (_viewModel.CloseAction == null)
                _viewModel.CloseAction = new Action<bool>(DoClose);
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public Nullable<bool> DialogResult
        {
            get { return _viewModel.DialogResult; }
            internal set
            {
                _viewModel.DialogResult = value;
            }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _viewModel.UserSessionToken; }
            set
            {
                _viewModel.UserSessionToken = value;
            }
        }

        public Guid ApplicationGuid
        {
            get { return _viewModel.ApplicationGuid; }
            set { _viewModel.ApplicationGuid = value; }
        }

        public string ApplicationName
        {
            get { return _viewModel.ApplicationName; }
            set
            {
                _viewModel.ApplicationName = value;
            }
        }

        public string HeaderText
        {
            get { return _viewModel.HeaderText; }
            set
            {
                _viewModel.HeaderText = value;
            }
        }

        public ObservableCollection<string> Servers
        {
            get { return _viewModel.Servers; }
            set
            {
                _viewModel.Servers = value;
            }
        }

        public string ServerAddress
        {
            get { return _viewModel.ServerAddress; }
            set
            {
                _viewModel.ServerAddress = value;
            }
        }

        public AuthenticationTypeData AuthenticationType
        {
            get { return _viewModel.AuthenticationType; }
            set
            {
                _viewModel.AuthenticationType = (from at in AuthenticationTypes
                                                 where at.AuthenticationType == value.AuthenticationType
                                                     select at).FirstOrDefault();
            }
        }
        public ObservableCollection<AuthenticationTypeData> AuthenticationTypes
        {
            get { return _viewModel.AuthenticationTypes; }
            set
            {
                _viewModel.AuthenticationTypes = value;
            }
        }

        public string FooterText
        {
            get { return _viewModel.FooterText; }
            set
            {
                _viewModel.FooterText = value;
            }
        }

        public string CopyrightNotice
        {
            get { return _viewModel.CopyrightNotice; }
            set
            {
                _viewModel.CopyrightNotice = value;
            }
        }

        public Brush HeaderBackground
        {
            get { return _viewModel.HeaderBackground; }
            set { _viewModel.HeaderBackground = value; }
        }
        public Brush MiddleBackground
        {
            get { return _viewModel.MiddleBackground; }
            set { _viewModel.MiddleBackground = value; }
        }

        public Brush FooterBackground
        {
            get { return _viewModel.FooterBackground; }
            set { _viewModel.FooterBackground = value; }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DoClose(bool bResult)
        {
            if(bResult == true)
                btnOk_Click(null, null);
            else
            {
                BtnCancel_OnClick(null, null);
            }
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}