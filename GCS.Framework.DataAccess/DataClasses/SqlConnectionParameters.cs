using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace GCS.Framework.DataAccess.DataClasses
{
    public enum SqlServerAuthenticationType { IntegratedWindowsAuthentication, SqlServerAuthentication}

    public class SqlAuthenticationType
    {
        public SqlAuthenticationType(SqlServerAuthenticationType type)
        {
            Type = type;
        }

        public SqlServerAuthenticationType Type { get; set; }

        public string Description
        {
            get
            {
                switch (Type)
                {
                    case SqlServerAuthenticationType.IntegratedWindowsAuthentication:
                        return Properties.Resources.SqlServerPicker_AuthenticationMode_Integrated;

                    case SqlServerAuthenticationType.SqlServerAuthentication:
                        return Properties.Resources.SqlServerPicker_AuthenticationMode_SqlServer;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }


    public class SqlConnectionParameters : ObjectBase
    {
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _initialCatalog = string.Empty;
        private string _applicationName = string.Empty;
        private string _connectionString = string.Empty;
        private string _attachDbFilename = string.Empty;
        private ApplicationIntent _applicationIntent;
        private int _connectTimeout = 15;
        private bool _asynchronousProcessing = false;
        private bool _encrypt = false;

        private string _sqlServerUserNameSaved = string.Empty;
        private string _sqlServerPasswordSaved = string.Empty;

        private SqlAuthenticationType _authenticationType;
         private ObservableCollection<SqlAuthenticationType> _sqlAuthenticationTypes;

        public SqlConnectionParameters()
        {
            Init();
        }
        
        public SqlConnectionParameters(string connectionString)
        {
            Init();
            ConnectionString = connectionString;
        }

        public SqlConnectionParameters( SqlConnectionParameters parameters)
        {
            Init();

            AuthenticationType = SqlAuthenticationTypes.FirstOrDefault(a => a.Type == parameters.AuthenticationType.Type);

            UserName = parameters.UserName;
            Password = parameters.Password;
            InitialCatalog = parameters.InitialCatalog;
            ApplicationName = parameters.ApplicationName;
            ConnectionString = parameters.ConnectionString;
            ConnectTimeout = parameters.ConnectTimeout;
            ApplicationIntent = parameters.ApplicationIntent;
            AttachDbFilename = parameters.AttachDbFilename;
            AsynchronousProcessing = parameters.AsynchronousProcessing;
            Encrypt = parameters.Encrypt;
        }

        public void Init(Server svr, ServerConnection connectionInfo)
        {
            if (svr != null && connectionInfo != null)
            {
                if (connectionInfo.LoginSecure)
                {
                    AuthenticationType =
                        SqlAuthenticationTypes.FirstOrDefault(
                            t => t.Type == SqlServerAuthenticationType.IntegratedWindowsAuthentication);
                    UserName = string.Empty;
                    Password = string.Empty;
                }
                else
                {
                    AuthenticationType =
                        SqlAuthenticationTypes.FirstOrDefault(
                            t => t.Type == SqlServerAuthenticationType.SqlServerAuthentication);
                    UserName = connectionInfo.Login;
                    Password = connectionInfo.Password;
                }
                ConnectTimeout = connectionInfo.ConnectTimeout;
                Encrypt = connectionInfo.EncryptConnection;
                if( string.IsNullOrEmpty(ApplicationName))
                    ApplicationName = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes().Title;
            }
        }

        private void Init()
        {
            UserName = string.Empty;
            Password = string.Empty;
            InitialCatalog = string.Empty;
            ApplicationName = string.Empty;
            ConnectTimeout = 15;
            ApplicationIntent = ApplicationIntent.ReadWrite;
            AttachDbFilename = string.Empty;
            AsynchronousProcessing = true;
            Encrypt = false;
            
            SqlAuthenticationTypes = new ObservableCollection<SqlAuthenticationType>();
            SqlAuthenticationTypes.Add(new SqlAuthenticationType(SqlServerAuthenticationType.IntegratedWindowsAuthentication));
            SqlAuthenticationTypes.Add(new SqlAuthenticationType(SqlServerAuthenticationType.SqlServerAuthentication));
            AuthenticationType = SqlAuthenticationTypes.FirstOrDefault();

        }

        public ObservableCollection<SqlAuthenticationType> SqlAuthenticationTypes
        {
            get { return _sqlAuthenticationTypes; }
            set
            {
                if (_sqlAuthenticationTypes != value)
                {
                    _sqlAuthenticationTypes = value;
                    OnPropertyChanged(() => SqlAuthenticationTypes, false);
                }
            }
        }

        /// <summary>
        /// Get/Set ConnectTimeout
        /// </summary>
        public int ConnectTimeout
        {
            get { return _connectTimeout; }
            set
            {
                if (_connectTimeout != value)
                {
                    _connectTimeout = value;
                    OnPropertyChanged(() => ConnectTimeout, false);
                }
            }
        }


        /// <summary>
        /// Get/Set ApplicationIntent
        /// </summary>
        public ApplicationIntent ApplicationIntent
        {
            get { return _applicationIntent; }
            set
            {
                if (_applicationIntent != value)
                {
                    _applicationIntent = value;
                    OnPropertyChanged(() => ApplicationIntent, false);
                }
            }
        }


        /// <summary>
        /// Get/Set UserName
        /// </summary>
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

        /// <summary>
        /// Get/Set Password
        /// </summary>
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

        /// <summary>
        /// Get/Set InitialCatalog
        /// </summary>
        public string InitialCatalog
        {
            get { return _initialCatalog; }
            set
            {
                if (_initialCatalog != value)
                {
                    if (value == null)
                        value = string.Empty;
                    _initialCatalog = value;
                    OnPropertyChanged(() => InitialCatalog, false);
                }
            }
        }

        /// <summary>
        /// Get/Set ApplicationName
        /// </summary>
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

        /// <summary>
        /// Get/Set ConnectionString
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (_connectionString != value)
                {
                    _connectionString = value;
                    OnPropertyChanged(() => ConnectionString, false);
                }
            }
        }

        /// <summary>
        /// Get/Set AttachDbFilename
        /// </summary>
        public string AttachDbFilename
        {
            get { return _attachDbFilename; }
            set
            {
                if (_attachDbFilename != value)
                {
                    _attachDbFilename = value;
                    OnPropertyChanged(() => AttachDbFilename, false);
                }
            }
        }

        public SqlAuthenticationType AuthenticationType
        {
            get { return _authenticationType; }
            set
            {
                if (_authenticationType != value)
                {
                    if( _authenticationType != null )
                    {
                        if (_authenticationType.Type == SqlServerAuthenticationType.SqlServerAuthentication)
                        {
                            _sqlServerUserNameSaved = UserName;
                            _sqlServerPasswordSaved = Password;
                        }
                    }
                    _authenticationType = value;
 
                    OnPropertyChanged(() => AuthenticationType, false);
                    OnPropertyChanged(() => IsSqlServerAuth);
                    if (AuthenticationType.Type == SqlServerAuthenticationType.IntegratedWindowsAuthentication)
                    {
                        var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
                        if (windowsIdentity != null)
                            UserName = windowsIdentity.Name;
                    }
                    else
                    {
                        //UserName = string.Empty;
                        UserName = _sqlServerUserNameSaved;
                        Password = _sqlServerPasswordSaved;
                    }
                    Password = string.Empty;
                }
            }
        }
        /// <summary>
        /// Get/Set IsSqlServerAuth
        /// </summary>
        public bool IsSqlServerAuth
        {
            get
            {
                return AuthenticationType.Type == SqlServerAuthenticationType.SqlServerAuthentication;
            }
            //set
            //{
            //    if (_IsSqlServerAuth != value)
            //    {
            //        _IsSqlServerAuth = value;
            //        OnPropertyChanged(() => IsSqlServerAuth, false);
            //    }
            //}
        }

        /// <summary>
        /// Get/Set AsynchronousProcessing
        /// </summary>
        public bool AsynchronousProcessing
        {
            get { return _asynchronousProcessing; }
            set
            {
                if (_asynchronousProcessing != value)
                {
                    _asynchronousProcessing = value;
                    OnPropertyChanged(() => AsynchronousProcessing, false);
                }
            }
        }

        /// <summary>
        /// Get/Set Encrypt
        /// </summary>
        public bool Encrypt
        {
            get { return _encrypt; }
            set
            {
                if (_encrypt != value)
                {
                    _encrypt = value;
                    OnPropertyChanged(() => Encrypt, false);
                }
            }
        }

    }
}
