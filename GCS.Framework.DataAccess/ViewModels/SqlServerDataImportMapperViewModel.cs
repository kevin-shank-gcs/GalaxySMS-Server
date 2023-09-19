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
    public class SqlServerDataImportMapperViewModel :ViewModelBase
    {

        #region Private Fields

        private SqlServer _sourceSqlServer;
        private SqlServer _destinationSqlServer;
        private string _destinationSqlServerConnectionString;
        private bool _isDestinationCatalogAreaVisible;
        private bool _isErrorMessageVisible;
        private string _errorMessage;
        private bool _showBusyIndicator = false;
        private string _busyIndicatorContent = string.Empty;
        private bool _isAllEnabled;
     
        #endregion
        
        #region Constructors

        public SqlServerDataImportMapperViewModel()
        {
            IsAllEnabled = true;
            IsDestinationCatalogAreaVisible = true;
        }

        #endregion

        #region Public Properties

        public SqlServer SourceSqlServer
        {
            get { return _sourceSqlServer; }
            set
            {
                if (_sourceSqlServer != value)
                {
                    _sourceSqlServer = value;
                    OnPropertyChanged(() => SourceSqlServer, false);
                }
            }
        }

        public SqlServer DestinationSqlServer
        {
            get { return _destinationSqlServer; }
            set
            {
                if (_destinationSqlServer != value)
                {
                    _destinationSqlServer = value;
                    OnPropertyChanged(() => DestinationSqlServer, false);
                }
            }
        }

        public bool IsDestinationCatalogAreaVisible
        {
            get { return _isDestinationCatalogAreaVisible; }
            set
            {
                if (_isDestinationCatalogAreaVisible != value)
                {
                    _isDestinationCatalogAreaVisible = value;
                    OnPropertyChanged(() => IsDestinationCatalogAreaVisible, false);
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
 
        public string DestinationSqlServerConnectionString
        {
            get { return _destinationSqlServerConnectionString; }
            set
            {
                if (_destinationSqlServerConnectionString != value)
                {
                    _destinationSqlServerConnectionString = value;
                    OnPropertyChanged(() => DestinationSqlServerConnectionString, false);
                    CreateDestinationServer(DestinationSqlServerConnectionString);
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
       
        #endregion


        private void CreateDestinationServer(string connectionString)
        {
            Server s;
            try
            {
                var sqlConn = new System.Data.SqlClient.SqlConnection(connectionString);
                var conn = new ServerConnection(sqlConn);
                DestinationSqlServer = new SqlServer(conn);

                //s = new Server(conn);
                //if (s != null)
                //{
                //    DestinationSqlServer = new SqlServer(s);
                //    bool bGoodConnection = DestinationSqlServer.TestConnection();
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
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
                  new SqlServerSelectedEventArgs(SourceSqlServer);

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

        #endregion
    }
}
