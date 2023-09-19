using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCS.Core.Common.UI.Core;
using PDSA.SqlServer;
using PDSA.SqlServer.Picker;

namespace GCS.Framework.DataAccess.UserControls
{
    /// <summary>
    /// Interaction logic for SqlServerPicker.xaml
    /// </summary>
    public partial class SqlServerPicker_PDSA : UserControlViewBase
    {
        #region Constructor
        /// <summary>
        /// Constructor for ucPDSASqlServerPicker Class
        /// </summary>
        public SqlServerPicker_PDSA()
        {
            InitializeComponent();

            _ViewModel = (PDSASqlServerPickerViewModel)this.Resources["viewModel"];
        }
        #endregion

        #region Private Variables
        private PDSASqlServerPickerViewModel _ViewModel = null;
        private bool _PreLoadLocalServers = false;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get the Connection String
        /// </summary>
        public string ConnectString
        {
            get { return _ViewModel.DetailData.ConnectString; }
        }

        /// <summary>
        /// Get/Set whether or not the Connect String Area is Visible
        /// </summary>
        public bool IsConnectStringVisible
        {
            get { return _ViewModel.IsConnectStringVisible; }
            set { _ViewModel.IsConnectStringVisible = value; }
        }

        /// <summary>
        /// Get/Set whether or not the Catalog Area is Visible
        /// </summary>
        public bool IsCatalogAreaVisible
        {
            get { return _ViewModel.IsCatalogAreaVisible; }
            set { _ViewModel.IsCatalogAreaVisible = value; }
        }

        /// <summary>
        /// Get/Set whether or not the OK Button is Visible
        /// </summary>
        public bool IsOKButtonVisible
        {
            get { return _ViewModel.IsOKButtonVisible; }
            set { _ViewModel.IsOKButtonVisible = value; }
        }

        /// <summary>
        /// Get/Set whether or not the Cancel Button is Visible
        /// </summary>
        public bool IsCancelButtonVisible
        {
            get { return _ViewModel.IsCancelButtonVisible; }
            set { _ViewModel.IsCancelButtonVisible = value; }
        }

        /// <summary>
        /// Get/Set whether or not to pre-load all local servers when displaying for the first time
        /// </summary>
        public bool PreLoadLocalServers
        {
            get { return _PreLoadLocalServers; }
            set { _PreLoadLocalServers = value; }
        }
        #endregion

        #region Event Procedures
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (PreLoadLocalServers)
                _ViewModel.LoadLocalServers();
        }

        #region OKClickedEventHandler Event
        /// <summary>
        /// Delegate for informing calling form that the "OK" button was clicked
        /// </summary>
        /// <param name="sender">Object from which event is raised</param>
        /// <param name="e">a PDSASqlServerSelectedEventArgs object</param>
        public delegate void OKClickedEventHandler(object sender, PDSASqlServerSelectedEventArgs e);

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// </summary>
        public event OKClickedEventHandler OkButtonClicked;

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// The event is only invoked if data binding is used
        /// </summary>
        protected void RaiseOKClicked()
        {
            OKClickedEventHandler handler = this.OkButtonClicked;
            if (handler != null)
            {
                // Create event args
                PDSASqlServerSelectedEventArgs args =
                  new PDSASqlServerSelectedEventArgs();

                args.ConnectString = _ViewModel.DetailData.ConnectString;
                args.SqlServerObject = _ViewModel.DetailData;

                // Raise the OKClickedEventHandler event.
                handler(this, args);
            }
        }
        #endregion

        #region CancelClickedEventHandler Event
        /// <summary>
        /// Delegate for informing calling form that the "Cancel" button was clicked
        /// </summary>
        /// <param name="sender">Object from which event is raised</param>
        /// <param name="e">An EventArgs object</param>
        public delegate void CancelClickedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// The Cancel Click Event to raise to any UI object
        /// </summary>
        public event CancelClickedEventHandler CancelButtonClicked;

        /// <summary>
        /// The Cancel Clicked Event to raise to any UI object
        /// The event is only invoked if data binding is used
        /// </summary>
        protected void RaiseCancelClicked()
        {
            CancelClickedEventHandler handler = this.CancelButtonClicked;
            if (handler != null)
            {
                // Create event args
                EventArgs args =
                  new EventArgs();

                // Raise the CancelClickedEventHandler event.
                handler(this, args);
            }
        }
        #endregion

        #region ConnectionValidClickedEventHandler Event
        /// <summary>
        /// Delegate for informing calling form that the connection was tested and is OK.
        /// </summary>
        /// <param name="sender">Object from which event is raised</param>
        /// <param name="e">a PDSASqlServerSelectedEventArgs object</param>
        public delegate void ConnectionValidEventHandler(object sender, PDSASqlServerSelectedEventArgs e);

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// </summary>
        public event ConnectionValidEventHandler ConnectionValid;

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// The event is only invoked if data binding is used
        /// </summary>
        protected void RaiseConectionValid()
        {
            ConnectionValidEventHandler handler = this.ConnectionValid;
            if (handler != null)
            {
                // Create event args
                PDSASqlServerSelectedEventArgs args =
                  new PDSASqlServerSelectedEventArgs();

                args.ConnectString = _ViewModel.DetailData.ConnectString;
                args.SqlServerObject = _ViewModel.DetailData;

                // Raise the ConnectionValidEventHandler event.
                handler(this, args);
            }
        }
        #endregion

        private void btnLoadNetwork_Click(object sender, RoutedEventArgs e)
        {
            Cursor cur = this.Cursor;

            this.Cursor = Cursors.Wait;
            _ViewModel.LoadAllServers();
            this.Cursor = cur;
        }

        private void btnTestConnection_Click(object sender, RoutedEventArgs e)
        {
            Cursor cur = this.Cursor;

            this.Cursor = Cursors.Wait;
            if (_ViewModel.TestConnection())
                RaiseConectionValid();

            this.Cursor = cur;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            RaiseOKClicked();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            RaiseCancelClicked();
        }

        private void btnLoadLocal_Click(object sender, RoutedEventArgs e)
        {
            Cursor cur = this.Cursor;

            this.Cursor = Cursors.Wait;
            _ViewModel.LoadLocalServers();

            this.Cursor = cur;
        }

        private void btnCopyConnectString_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_ViewModel.DetailData.ConnectString);
        }

        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _ViewModel.DetailData.Password = pwdPassword.Password;
        }

        private void cboServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Have to set this here and not in XAML
            _ViewModel.DetailData = (PDSASqlServer)cboServers.SelectedItem;

            _ViewModel.ErrorMessage = string.Empty;
        }
        #endregion

        #region SetConnectString Method
        /// <summary>
        /// Pass in a connection string to have the defaults set on this user control
        /// </summary>
        /// <param name="connectString">The connection string</param>
        public void SetConnectionString(string connectString)
        {
            _ViewModel.DetailData = PDSASqlServer.CreateSqlServerObjectFromConnectString(connectString);
        }
        #endregion
    }
}
