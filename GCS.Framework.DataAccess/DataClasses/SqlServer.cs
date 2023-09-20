using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace GCS.Framework.DataAccess.DataClasses
{
    public class SqlServer : ObjectBase
    {
        private string _serverInstanceName;
        private string _serverName;
        private string _instance;
        private string _sqlVersion;
        private string _sqlEdition;
        private bool _isLocal;
        private bool _isClustered;
        private bool _isSqlExpress;
        private bool _isRunning;
        private bool _isValidConnection;
        private string _connectionString;
        private string _catalogName = string.Empty;

        public SqlServer()
        {
            SqlConnectionParameters = new SqlConnectionParameters();
            Catalogs = new ObservableCollection<string>();
            ConnectionString = string.Empty;
        }

        public SqlServer(ServerConnection serverConnection)
        {
            SqlConnectionParameters = new SqlConnectionParameters();
            SqlConnectionParameters.ConnectionString = serverConnection.ConnectionString;
            ServerInstanceName = serverConnection.ServerInstance;
            Instance = ServerInstanceName;

            Catalogs = new ObservableCollection<string>();
            ConnectionString = serverConnection.ConnectionString;
            var svr = new Server(serverConnection);
            Initialize(svr);
            CatalogName = serverConnection.DatabaseName;
        }

        public SqlServer(Server svr)
        {
            SqlConnectionParameters = new SqlConnectionParameters();
            Catalogs = new ObservableCollection<string>();
            ConnectionString = string.Empty;
            Server = svr;
            Initialize(svr);
        }

        void Initialize(Server svr)
        {
            Server = svr;
            if (Server != null)
            {
                ConnectionString = Server.ConnectionContext.ConnectionString;
                if (string.IsNullOrEmpty(ServerInstanceName))
                    ServerInstanceName = Server.InstanceName;
                ServerName = Server.NetName;
                Instance = Server.InstanceName;
                SQLVersion = Server.VersionString;
                SQLEdition = Server.Edition;
                if (Server.NetName == Environment.MachineName)
                    IsLocal = true;
                else
                    IsLocal = false;
                IsClustered = Server.IsClustered;
                IsSqlExpress = Server.Edition.Contains("Express");
                IsRunning = true;

                var orderedCatalogs = new ObservableCollection<string>();

                //add to list
                foreach (Database db in Server.Databases)
                {
                    orderedCatalogs.Add(db.Name);//ToString());
                }

                orderedCatalogs = new ObservableCollection<string>(orderedCatalogs.OrderBy(i => i));
                foreach (var catalog in orderedCatalogs)
                    Catalogs.Add(catalog);

                if (Catalogs.Count > 0)
                {
                    if (string.IsNullOrEmpty(CatalogName))
                    {
                        var catName = Catalogs[0];
                        CatalogName = catName;
                    }
                }
                else
                {
                    CatalogName = string.Empty;
                }
                IsValidConnection = true;
            }
        }

        public string ServerInstanceName
        {
            get { return _serverInstanceName; }
            set
            {
                if (_serverInstanceName != value)
                {
                    _serverInstanceName = value;
                    OnPropertyChanged(() => ServerInstanceName, false);
                }
            }
        }

        public string ServerName
        {
            get { return _serverName; }
            set
            {
                if (_serverName != value)
                {
                    _serverName = value;
                    OnPropertyChanged(() => ServerName, false);
                }
            }
        }

        public string Instance
        {
            get { return _instance; }
            set
            {
                if (_instance != value)
                {
                    _instance = value;
                    OnPropertyChanged(() => Instance, false);
                }
            }
        }

        public string SQLVersion
        {
            get { return _sqlVersion; }
            set
            {
                if (_sqlVersion != value)
                {
                    _sqlVersion = value;
                    OnPropertyChanged(() => SQLVersion, false);
                }
            }
        }

        public string SQLEdition
        {
            get { return _sqlEdition; }
            set
            {
                if (_sqlEdition != value)
                {
                    _sqlEdition = value;
                    OnPropertyChanged(() => SQLEdition, false);
                }
            }
        }

        public bool IsLocal
        {
            get { return _isLocal; }
            set
            {
                if (_isLocal != value)
                {
                    _isLocal = value;
                    OnPropertyChanged(() => IsLocal, false);
                }
            }
        }

        public bool IsClustered
        {
            get { return _isClustered; }
            set
            {
                if (_isClustered != value)
                {
                    _isClustered = value;
                    OnPropertyChanged(() => IsClustered, false);
                }
            }
        }

        public bool IsSqlExpress
        {
            get { return _isSqlExpress; }
            set
            {
                if (_isSqlExpress != value)
                {
                    _isSqlExpress = value;
                    OnPropertyChanged(() => IsSqlExpress, false);
                }
            }
        }

        /// <summary>
        /// Get/Set IsRunning
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged(() => IsRunning, false);
                }
            }
        }

        private Server _server;

        public Server Server
        {
            get { return _server; }
            set
            {
                if (_server != value)
                {
                    _server = value;
                    OnPropertyChanged(() => Server, false);
                }
            }
        }
        
        /// <summary>
        /// Get/Set catalogName
        /// </summary>
        public string CatalogName
        {
            get { return _catalogName; }
            set
            {
                if (_catalogName != value)
                {
                    _catalogName = value;
                    SqlConnectionParameters.InitialCatalog = CatalogName;
                    OnPropertyChanged(() => CatalogName, false);
                    SelectedCatalog = Server.Databases[CatalogName];
                }
                BuildConnectionString(null);
            }
        }

        private Database _selectedCatalog;

        public Database SelectedCatalog
        {
            get { return _selectedCatalog; }
            set
            {
                if (_selectedCatalog != value)
                {
                    _selectedCatalog = value;
                    OnPropertyChanged(() => SelectedCatalog, false);
                }
                if (CatalogName != SelectedCatalog.Name)
                    CatalogName = SelectedCatalog.Name;
            }
        }
        
        private Table _selectedTable;

        public Table SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                if (_selectedTable != value)
                {
                    _selectedTable = value;
                    OnPropertyChanged(() => SelectedTable, false);
                }
            }
        }

        private StoredProcedure _selectedStoredProcedure;

        public StoredProcedure SelectedStoredProcedure
        {
            get { return _selectedStoredProcedure; }
            set
            {
                if (_selectedStoredProcedure != value)
                {
                    _selectedStoredProcedure = value;
                    OnPropertyChanged(() => SelectedStoredProcedure, false);
                }
            }
        }

        private View _selectedView;

        public View SelectedView
        {
            get { return _selectedView; }
            set
            {
                if (_selectedView != value)
                {
                    _selectedView = value;
                    OnPropertyChanged(() => SelectedView, false);
                }
            }
        }
        
        public bool IsValidConnection
        {
            get { return _isValidConnection; }
            internal set
            {
                if (_isValidConnection != value)
                {
                    _isValidConnection = value;
                    OnPropertyChanged(() => IsValidConnection, false);
                }
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            internal set
            {
                if (_connectionString != value)
                {
                    _connectionString = value;
                    OnPropertyChanged(() => ConnectionString, false);
                }
            }
        }
        
        public SqlConnectionParameters SqlConnectionParameters { get; internal set; }
        
        public string BuildConnectionString(SqlConnectionParameters parameters)
        {
            if (parameters == null)
                parameters = new SqlConnectionParameters(SqlConnectionParameters);

            if (parameters.ConnectionString == string.Empty)
                parameters.ConnectionString = DefaultConnectionString;
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(parameters.ConnectionString);

            builder.DataSource = ServerInstanceName;
            switch (parameters.AuthenticationType.Type)
            {
                case SqlServerAuthenticationType.IntegratedWindowsAuthentication:
                    builder["Trusted_Connection"] = true;
                    break;
                case SqlServerAuthenticationType.SqlServerAuthentication:
                    builder["Trusted_Connection"] = false;
                    builder.UserID = parameters.UserName;
                    builder.Password = parameters.Password;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            builder.AsynchronousProcessing = parameters.AsynchronousProcessing;
            builder.ConnectTimeout = parameters.ConnectTimeout;
            if (string.IsNullOrEmpty(CatalogName))
                builder.InitialCatalog = parameters.InitialCatalog;
            else
                builder.InitialCatalog = CatalogName;
            builder.ApplicationName = parameters.ApplicationName;
            builder.ApplicationIntent = parameters.ApplicationIntent;
            builder.AttachDBFilename = parameters.AttachDbFilename;
            builder.Encrypt = parameters.Encrypt;
            ConnectionString = builder.ConnectionString;
            return ConnectionString;
        }

        private string DefaultConnectionString
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.  
            get { return string.Format("Server={0};Integrated Security=SSPI;Initial Catalog=master", ServerInstanceName); }
        }

        public ObservableCollection<string> Catalogs { get; internal set; } 
        public bool TestConnection()
        {
            try
            {
                IsRunning = false;
                IsValidConnection = false;
                if (Catalogs == null)
                    Catalogs = new ObservableCollection<string>();
                else
                    Catalogs.Clear();

                //create connection
                SqlConnection sqlConn = new SqlConnection(ConnectionString);

                //open connection
                sqlConn.Open();

                //get databases
                DataTable tblDatabases = sqlConn.GetSchema("Databases");

                //close connection
                sqlConn.Close();

                var orderedCatalogs = new ObservableCollection<string>();

                //add to list
                foreach (DataRow row in tblDatabases.Rows)
                {
                    String strDatabaseName = row["database_name"].ToString();

                    orderedCatalogs.Add(strDatabaseName);
                }

                orderedCatalogs = new ObservableCollection<string>(orderedCatalogs.OrderBy(i => i)); 
                foreach( var catalog in orderedCatalogs)
                    Catalogs.Add(catalog);

                if (Catalogs.Count > 0)
                {
                    var catName = Catalogs[0];
                    CatalogName = catName;
                }
                else
                {
                    CatalogName = string.Empty;
                }
                IsValidConnection = true;
                IsRunning = true;
            }
            catch (Exception ex)
            {
                this.Log().ErrorFormat("TestConnection exception: {0}", ex.Message);
                return false;
            }
            return true;
        }

        public Database SelectedDatabase
        {
            get;
            set;
        }
    }
}
