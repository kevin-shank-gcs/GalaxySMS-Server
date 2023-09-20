using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Framework.DataAccess.DataClasses;
using GCS.Framework.DataAccess.Properties;
using GCS.Framework.Utilities;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GCS.Framework.DataAccess.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SqlServerPickerViewModel : ViewModelBase
    {
        #region Private fields

        private SqlServer _selectedSqlServer;
        private string _serverInstanceNameText = string.Empty;
        private bool _isOkButtonVisible = true;
        private bool _isCancelButtonVisible = true;
        private bool _isErrorMessageVisible;
        private string _errorMessage;
        private bool _isAllEnabled;
        private bool _isCatalogAreaVisible = true;
        private bool _isSqlVersionVisible = true;
        private bool _isSqlEditionVisible = true;
        private bool _isSqlExpressVisible = true;
        private bool _isApplicationNameVisible = true;
        private bool _isCopyConnectStringButtonVisible = true;
        private bool _isConnectStringVisible = true;
        private bool _showBusyIndicator = false;
        private string _busyIndicatorContent = string.Empty;

        #endregion Private fields

        private async Task<SqlServer> GetSqlServerDetailData(string serverInstance, SqlConnectionParameters parameters)
        {
            SqlServer server = null;
            await Task.Run(() =>
                {
                    try
                    {
                        var conn = new ServerConnection(serverInstance);
                        switch (parameters.AuthenticationType.Type)
                        {
                            case SqlServerAuthenticationType.IntegratedWindowsAuthentication:
                                conn.LoginSecure = true;
                                break;

                            case SqlServerAuthenticationType.SqlServerAuthentication:
                                conn.LoginSecure = false;
                                conn.Login = parameters.UserName;
                                conn.Password = parameters.Password;
                                break;

                            default:
                                throw new ArgumentOutOfRangeException("authenticationType");
                        }

                        conn.EncryptConnection = parameters.Encrypt;
                        conn.MultipleActiveResultSets = true;
                        var svr = new Server(conn);
                        server = new SqlServer(svr);
                        //The actual connection is made when a property is retrieved.

                        server.Instance = server.Server.InstanceName;
                        server.ServerInstanceName = server.Server.Name;
                        server.ServerName = server.Server.NetName;
                        server.SQLEdition = server.Server.Edition;
                        server.SQLVersion = server.Server.VersionString;
                        server.IsSqlExpress = server.Server.Edition.Contains("Express");
                        server.IsClustered = server.Server.IsClustered;
                        if (svr.NetName == Environment.MachineName)
                            server.IsLocal = true;
                        else
                        {
                            server.IsLocal = false;
                        }

                        foreach (var database in svr.Databases)
                        {
                            var databaseName = database.ToString();
                            databaseName = databaseName.Replace("[", string.Empty);
                            databaseName = databaseName.Replace("]", string.Empty);

                            server.Catalogs.Add(databaseName);
                        }
                        DetailDataForAuth.Init(svr, conn);
                        server.SqlConnectionParameters = DetailDataForAuth;

                        server.BuildConnectionString(null);
                        server.ConnectionString = conn.ConnectionString;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
            return server;
        }

        private ObservableCollection<SqlServer> GetSqlServerInstances(bool bLocalOnly)
        {
            ObservableCollection<SqlServer> collection = new ObservableCollection<SqlServer>();
            if (bLocalOnly)
            {
                var localInstances = GetLocalSqlServerInstanceNames();  // this is much faster than using the SmoApplication.EnumAvailableSqlServers(true); method
                foreach (var instanceName in localInstances)
                {
                    var server = new SqlServer();
                    server.ServerName = Environment.MachineName;
                    server.Instance = instanceName;
                    server.ServerInstanceName = string.Format("{0}\\{1}", server.ServerName, instanceName);
                    server.IsLocal = true;
                    collection.Add(server);
                }
            }
            else
            {
                DataTable dataTable = SmoApplication.EnumAvailableSqlServers(false);

                foreach (DataRow row in dataTable.Rows)
                {
                    string s = string.Empty;
                    var server = new SqlServer();
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        switch (col.ColumnName)
                        {
                            case "Name":
                                server.ServerInstanceName = row[col].ToString();
                                break;

                            case "Server":
                                server.ServerName = row[col].ToString();
                                break;

                            case "Instance":
                                server.Instance = row[col].ToString();
                                break;

                            case "Version":
                                server.SQLVersion = row[col].ToString();
                                break;

                            case "IsClustered":
                                server.IsClustered = Convert.ToBoolean(row[col]);
                                break;

                            case "IsLocal":
                                server.IsLocal = Convert.ToBoolean(row[col]);
                                break;
                        }
                    }
                    collection.Add(server);
                }
            }

            return collection;
        }

        private async Task RequestSqlInstancesAsync(bool bLocalOnly)
        {
            BusyIndicatorContent = Properties.Resources.BusyIndicatorContent_BusyRequestingSqlInstancesContent;

            ShowBusyIndicator = true;
            IsAllEnabled = false;
            SqlServersCollection.Clear();
            var results = await Task.Run(() => GetSqlServerInstances(bLocalOnly));
            foreach (var sqlServer in results)
                SqlServersCollection.Add(sqlServer);
            IsAllEnabled = true;
            ShowBusyIndicator = false;
        }

        /// <summary>
        ///  get local sql server instance names from registry, search both WOW64 and WOW3264 hives
        /// </summary>
        /// <returns>a list of local sql server instance names</returns>
        private static IEnumerable<string> GetLocalSqlServerInstanceNames()
        {
            var registryValueDataReader = new RegistryValueDataReader();

            string[] instances64Bit = registryValueDataReader.ReadRegistryValueData(GCS.Framework.Utilities.RegistryHive.Wow64,
                                                                                    Registry.LocalMachine,
                                                                                    @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                    "InstalledInstances");

            string[] instances32Bit = registryValueDataReader.ReadRegistryValueData(GCS.Framework.Utilities.RegistryHive.Wow6432,
                                                                                    Registry.LocalMachine,
                                                                                    @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                    "InstalledInstances");

            //FormatLocalSqlInstanceNames(ref instances64Bit);
            //FormatLocalSqlInstanceNames(ref instances32Bit);

            IList<string> localInstanceNames = new List<string>(instances64Bit);

            localInstanceNames = localInstanceNames.Union(instances32Bit).ToList();

            return localInstanceNames;
        }

        #region Constructors

        [ImportingConstructor]
        public SqlServerPickerViewModel()
        {
            SqlServersCollection = new ObservableCollection<SqlServer>();
            GetLocalInstancesCommand = new DelegateCommand<object>(ExecuteGetLocalInstancesCommand, CanExecuteGetLocalInstancesCommand);
            GetAllInstancesCommand = new DelegateCommand<object>(ExecuteGetAllInstancesCommand, CanExecuteGetAllInstancesCommand);
            TestConnectionCommand = new DelegateCommand<object>(ExecuteTestConnectionCommand, CanExecuteTestConnectionCommand);
            CopyConnectStringCommand = new DelegateCommand<object>(ExecuteCopyConnectStringCommand, CanExecuteCopyConnectStringCommand);
            OkCommand = new DelegateCommand<object>(ExecuteOkCommand, CanExecuteOkCommand);
            CancelCommand = new DelegateCommand<object>(ExecuteCancelCommand, CanExecuteCancelCommand);
            NavigateCommand = new DelegateCommand<object>(new Action<object>(d => { this.Navigate(d); }));

            DetailDataForAuth = new SqlConnectionParameters();

            AcceptButtonText = Properties.Resources.SqlServerPicker_OKButtonText;
            IsAllEnabled = true;
        }

        private bool CanExecuteCancelCommand(object obj)
        {
            return true;
        }

        private void ExecuteCancelCommand(object obj)
        {
            RaiseCancelClicked(obj);
        }

        private bool CanExecuteOkCommand(object obj)
        {
            if (SelectedSqlServer != null && SelectedSqlServer.IsValidConnection)
                return true;
            return false;
        }


        public bool IsValidConnection
        {
            get
            {
                if (SelectedSqlServer != null && !string.IsNullOrEmpty(SelectedSqlServer.ConnectionString))
                    return true;
                return false;                
            }
        }
        
        public void ExecuteOkCommand(object obj)
        {
            RaiseOKClicked(obj);
        }

        private void Navigate(object d)
        {
			System.Diagnostics.Process.Start(this.HelpUrl);
        }

        #endregion Constructors

        #region Commands

        public DelegateCommand<object> GetLocalInstancesCommand { get; private set; }

        public DelegateCommand<object> GetAllInstancesCommand { get; private set; }

        public DelegateCommand<object> TestConnectionCommand { get; private set; }

        public DelegateCommand<object> CopyConnectStringCommand { get; private set; }

        public DelegateCommand<object> OkCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> NavigateCommand { get; set; }

        #endregion Commands

        #region Command handlers

        private async void ExecuteGetLocalInstancesCommand(object obj)
        {
            await RequestSqlInstancesAsync(true);
        }

        private bool CanExecuteGetLocalInstancesCommand(object obj)
        {
            return true;//IsAllEnabled;
        }

        private bool CanExecuteGetAllInstancesCommand(object obj)
        {
            return true; //IsAllEnabled;
        }

        private async void ExecuteGetAllInstancesCommand(object obj)
        {
            await RequestSqlInstancesAsync(false);
        }

        private bool CanExecuteTestConnectionCommand(object obj)
        {
            return SelectedSqlServer != null || !String.IsNullOrEmpty(this.ServerInstanceNameText);
        }

        private async void ExecuteTestConnectionCommand(object obj)
        {
            try
            {
                string catalogName = string.Empty;
                var sqlServerInstanceName = ServerInstanceNameText;
                if (SelectedSqlServer != null)
                {
                    SelectedSqlServer.IsRunning = false;
                    sqlServerInstanceName = SelectedSqlServer.ServerInstanceName;
                    catalogName = SelectedSqlServer.CatalogName;
                }
                BusyIndicatorContent = string.Format(Resources.BusyIndicatorContent_TestingConnectionBusyMessage, sqlServerInstanceName);
                ShowBusyIndicator = true;

                IsAllEnabled = false;
                IsErrorMessageVisible = false;
                ErrorMessage = string.Empty;

                var sqlServer = await GetSqlServerDetailData(sqlServerInstanceName, DetailDataForAuth);

                SelectedSqlServer = sqlServer;
                if( SelectedSqlServer.TestConnection() )
                {
                    if (string.IsNullOrEmpty(catalogName) == false)
                    {
                        if (SelectedSqlServer.Catalogs.Contains(catalogName))
                        {
                            SelectedSqlServer.CatalogName = catalogName;
                        }
                    }
                    RaiseConectionValid();
                }
            }
            catch (Exception ex)
            {
                if (SelectedSqlServer != null)
                {
                    SelectedSqlServer.ConnectionString = string.Empty;
                    SelectedSqlServer.Catalogs.Clear();
                }
                ErrorMessage = ex.Message;
                IsErrorMessageVisible = true;
                this.Log().ErrorFormat(ex.Message);
            }
            IsAllEnabled = true;
            ShowBusyIndicator = false;
        }

        private void ExecuteCopyConnectStringCommand(object obj)
        {
            Clipboard.SetText(SelectedSqlServer.ConnectionString);
        }

        private bool CanExecuteCopyConnectStringCommand(object obj)
        {
            if (SelectedSqlServer != null && SelectedSqlServer.ConnectionString != string.Empty)
                return true;
            return false;
        }

        #endregion Command handlers

        #region Public properties

        public SqlServerPickerViewModel SqlServerPickerVM
        { get { return this; } }

        public ObservableCollection<SqlServer> SqlServersCollection { get; set; }

        /// <summary>
        /// Get/Set ShowBusyIndicator
        /// </summary>
        public bool ShowBusyIndicator
        {
            get { return _showBusyIndicator; }
            set
            {
                if (_showBusyIndicator != value)
                {
                    _showBusyIndicator = value;
                    OnPropertyChanged(() => ShowBusyIndicator, false);
                }
            }
        }

        /// <summary>
        /// Get/Set BusyIndicatorContent
        /// </summary>
        public string BusyIndicatorContent
        {
            get { return _busyIndicatorContent; }
            set
            {
                if (_busyIndicatorContent != value)
                {
                    _busyIndicatorContent = value;
                    OnPropertyChanged(() => BusyIndicatorContent, false);
                }
            }
        }

        public SqlServer SelectedSqlServer
        {
            get { return _selectedSqlServer; }
            set
            {
                if (_selectedSqlServer != value)
                {
                    _selectedSqlServer = value;
                    OnPropertyChanged(() => SelectedSqlServer, false);
                    OnPropertyChanged(() => IsValidConnection, false);
                }
            }
        }

        ObservableCollection<Column> _selectedColumns;
        public ObservableCollection<Column> SelectedColumns
        {
            get
            {
                if (_selectedColumns == null)
                {
                    _selectedColumns = new ObservableCollection<Column>();
                }
                return _selectedColumns;
            }
        }
        /// <summary>
        /// Get/Set ServerInstanceNameText
        /// </summary>
        public string ServerInstanceNameText
        {
            get { return _serverInstanceNameText; }
            set
            {
                if (_serverInstanceNameText != value)
                {
                    _serverInstanceNameText = value;
                    if (_selectedSqlServer != null && _selectedSqlServer.ServerInstanceName != _serverInstanceNameText)
                        SelectedSqlServer = null;
                    OnPropertyChanged(() => ServerInstanceNameText, false);
                }
            }
        }

        public bool IsOKButtonVisible
        {
            get { return _isOkButtonVisible; }
            set
            {
                if (_isOkButtonVisible != value)
                {
                    _isOkButtonVisible = value;
                    OnPropertyChanged(() => IsOKButtonVisible, false);
                }
            }
        }

        public bool IsCancelButtonVisible
        {
            get { return _isCancelButtonVisible; }
            set
            {
                if (_isCancelButtonVisible != value)
                {
                    _isCancelButtonVisible = value;
                    OnPropertyChanged(() => IsCancelButtonVisible, false);
                }
            }
        }

        public bool IsConnectStringVisible
        {
            get { return _isConnectStringVisible; }
            set
            {
                if (_isConnectStringVisible != value)
                {
                    _isConnectStringVisible = value;
                    OnPropertyChanged(() => IsConnectStringVisible, false);
                }
            }
        }

        private string _helpUrl;

        public string HelpUrl
        {
            get { return _helpUrl; }
            set
            {
                if (_helpUrl != value)
                {
                    _helpUrl = value;
                    OnPropertyChanged(() => HelpUrl, false);
                }
            }
        }
        
        public bool IsErrorMessageVisible
        {
            get { return _isErrorMessageVisible; }
            set
            {
                if (_isErrorMessageVisible != value)
                {
                    _isErrorMessageVisible = value;
                    OnPropertyChanged(() => IsErrorMessageVisible, false);
                }
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(() => ErrorMessage, false);
                }
            }
        }

        public bool IsApplicationNameVisible
        {
            get { return _isApplicationNameVisible; }
            set
            {
                if (_isApplicationNameVisible != value)
                {
                    _isApplicationNameVisible = value;
                    OnPropertyChanged(() => IsApplicationNameVisible, false);
                }
            }
        }

        public bool IsAllEnabled
        {
            get { return _isAllEnabled; }
            set
            {
                if (_isAllEnabled != value)
                {
                    _isAllEnabled = value;
                    OnPropertyChanged(() => IsAllEnabled, false);
                }
            }
        }

        private string _messageToDisplay;

        public string MessageToDisplay
        {
            get { return _messageToDisplay; }
            set
            {
                if (_messageToDisplay != value)
                {
                    _messageToDisplay = value;
                    OnPropertyChanged(() => MessageToDisplay, false);
                }
            }
        }

        private bool _isMessageVisible;

        public bool IsMessageVisible
        {
            get { return _isMessageVisible; }
            set
            {
                if (_isMessageVisible != value)
                {
                    _isMessageVisible = value;
                    OnPropertyChanged(() => IsMessageVisible, false);
                }
            }
        }

        private SqlConnectionParameters _detailDataForAuth;

        public SqlConnectionParameters DetailDataForAuth
        {
            get { return _detailDataForAuth; }
            set
            {
                if (_detailDataForAuth != value)
                {
                    _detailDataForAuth = value;
                    OnPropertyChanged(() => DetailDataForAuth, false);
                }
            }
        }

        /// <summary>
        /// Get/Set IsCatalogAreaVisible
        /// </summary>
        public bool IsCatalogAreaVisible
        {
            get { return _isCatalogAreaVisible; }
            set
            {
                if (_isCatalogAreaVisible != value)
                {
                    _isCatalogAreaVisible = value;
                    OnPropertyChanged(() => IsCatalogAreaVisible, false);
                }
            }
        }
     
        public bool IsSqlVersionVisible
        {
            get { return _isSqlVersionVisible; }
            set
            {
                if (_isSqlVersionVisible != value)
                {
                    _isSqlVersionVisible = value;
                    OnPropertyChanged(() => IsSqlVersionVisible, false);
                }
            }
        }

        public bool IsSqlEditionVisible
        {
            get { return _isSqlEditionVisible; }
            set
            {
                if (_isSqlEditionVisible != value)
                {
                    _isSqlEditionVisible = value;
                    OnPropertyChanged(() => IsSqlEditionVisible, false);
                }
            }
        }

        public bool IsSqlExpressVisible
        {
            get { return _isSqlExpressVisible; }
            set
            {
                if (_isSqlExpressVisible != value)
                {
                    _isSqlExpressVisible = value;
                    OnPropertyChanged(() => IsSqlExpressVisible, false);
                }
            }
        }

    
        public bool IsCopyConnectStringButtonVisible
        {
            get { return _isCopyConnectStringButtonVisible; }
            set
            {
                if (_isCopyConnectStringButtonVisible != value)
                {
                    _isCopyConnectStringButtonVisible = value;
                    OnPropertyChanged(() => IsCopyConnectStringButtonVisible, false);
                }
            }
        }


        private string _acceptButtonText;

        public string AcceptButtonText
        {
            get { return _acceptButtonText; }
            set
            {
                if (_acceptButtonText != value)
                {
                    _acceptButtonText = value;
                    OnPropertyChanged(() => AcceptButtonText, false);
                }
            }
        }

        private string _sqlCommand;

        public string SqlCommand
        {
            get { return _sqlCommand; }
            set
            {
                if (_sqlCommand != value)
                {
                    _sqlCommand = value;
                    OnPropertyChanged(() => SqlCommand, false);
                }
            }
        }
        
        #endregion Public properties

        #region Event Handlers
        #region OKClickedEventHandler Event
        /// <summary>
        /// Delegate for informing calling form that the "OK" button was clicked
        /// </summary>
        /// <param name="sender">Object from which event is raised</param>
        /// <param name="e">a PDSASqlServerSelectedEventArgs object</param>
        public delegate void OKClickedEventHandler(object sender, SqlServerSelectedEventArgs e);

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// </summary>
        public event OKClickedEventHandler OkButtonClicked;

        /// <summary>
        /// The OK Click Event to raise to any UI object
        /// The event is only invoked if data binding is used
        /// </summary>
        protected void RaiseOKClicked(object obj)
        {
            OKClickedEventHandler handler = this.OkButtonClicked;
            if (handler != null)
            {
                // Create event args
                SqlServerSelectedEventArgs args =
                  new SqlServerSelectedEventArgs(SelectedSqlServer);

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
        protected void RaiseCancelClicked(object obj)
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
        public delegate void ConnectionValidEventHandler(object sender, SqlServerSelectedEventArgs e);

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
                SqlServerSelectedEventArgs args =
                  new SqlServerSelectedEventArgs(SelectedSqlServer);

                // Raise the ConnectionValidEventHandler event.
                handler(this, args);
            }
        }
        #endregion

        #endregion
    }
}
