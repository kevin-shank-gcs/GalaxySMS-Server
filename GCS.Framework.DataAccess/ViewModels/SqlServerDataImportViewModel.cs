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
    public class SqlServerDataImportViewModel : ViewModelBase
    {
        #region Private fields

        private SqlServer _selectedSqlServer;
        private bool _isOkButtonVisible = true;
        private bool _isCancelButtonVisible = true;
        private bool _isErrorMessageVisible;
        private string _errorMessage;
        private bool _isAllEnabled;
        private bool _isCatalogAreaVisible = true;
        private bool _isTablesTabVisible = true;
        private bool _isViewsTabVisible = true;
        private bool _isStoredProceduresTabVisible = true;
        private bool _isSqlCommandTabVisible = true;
        private bool _isSampleDataTabVisible = true;
        private bool _showBusyIndicator = false;
        private string _busyIndicatorContent = string.Empty;
        private DataTable _sampleData;

        #endregion Private fields

        #region Constructors

        [ImportingConstructor]
        public SqlServerDataImportViewModel()
        {
            OkCommand = new DelegateCommand<object>(ExecuteOkCommand, CanExecuteOkCommand);
            CancelCommand = new DelegateCommand<object>(ExecuteCancelCommand, CanExecuteCancelCommand);

            GetTableDataCommand = new DelegateCommand<object>(ExecuteGetTableDataCommand, CanExecuteGetTableDataCommand);
            GetViewDataCommand = new DelegateCommand<object>(ExecuteGetViewDataCommand, CanExecuteGetViewDataCommand);
            GetStoredProcedureDataCommand = new DelegateCommand<object>(ExecuteGetStoredProcedureDataCommand, CanExecuteGetStoredProcedureDataCommand);
            ExecuteSqlCommandCommand = new DelegateCommand<object>(ExecuteSqlCommand, CanExecuteSqlCommand);

            AcceptButtonText = Properties.Resources.SqlServerPicker_OKButtonText;
            IsAllEnabled = true;
        }


        #endregion Constructors

        #region Commands
        public DelegateCommand<object> OkCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<object> GetTableDataCommand { get; private set; }
        public DelegateCommand<object> GetViewDataCommand { get; private set; }
        public DelegateCommand<object> GetStoredProcedureDataCommand { get; private set; }
        public DelegateCommand<object> ExecuteSqlCommandCommand { get; private set; }

        #endregion Commands

        #region Command handlers

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

        public void ExecuteOkCommand(object obj)
        {
            RaiseOKClicked(obj);
        }


        private void ExecuteGetStoredProcedureDataCommand(object obj)
        {
        }

        private bool CanExecuteGetStoredProcedureDataCommand(object obj)
        {
            if (SelectedSqlServer != null &&
                SelectedSqlServer.SelectedStoredProcedure != null)
                return true;
            return false;
        }

        private void ExecuteGetViewDataCommand(object obj)
        {
        }

        private bool CanExecuteGetViewDataCommand(object obj)
        {
            if (SelectedSqlServer != null &&
                SelectedSqlServer.SelectedView != null)
                return true;
            return false;
        }

        private void ExecuteGetTableDataCommand(object obj)
        {
            try
            {
                BuildSqlCommandFromTableSelection();
                var results = SelectedSqlServer.SelectedCatalog.ExecuteWithResults(SqlCommand);
                SampleData = results.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteGetTableDataCommand(object obj)
        {
            if (SelectedSqlServer != null &&
                SelectedSqlServer.SelectedTable != null)
                return true;
            return false;
        }


        private void ExecuteSqlCommand(object obj)
        {
            try
            {
                var results = SelectedSqlServer.SelectedCatalog.ExecuteWithResults(SqlCommand);
                SampleData = results.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteSqlCommand(object obj)
        {
            return !string.IsNullOrEmpty(SqlCommand);
        }

        #endregion Command handlers

        #region Public properties

        public bool IsValidConnection
        {
            get
            {
                if (SelectedSqlServer != null && !string.IsNullOrEmpty(SelectedSqlServer.ConnectionString))
                    return true;
                return false;
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

        public bool AreAnyDataTabsVisible
        {
            get
            {
                if (IsTablesTabVisible || IsViewsTabVisible || IsStoredProceduresTabVisible)
                    return true;
                return false;
            }
        }
     
        public bool IsTablesTabVisible
        {
            get { return _isTablesTabVisible; }
            set
            {
                if (_isTablesTabVisible != value)
                {
                    _isTablesTabVisible = value;
                    OnPropertyChanged(() => IsTablesTabVisible, false);
                    OnPropertyChanged(() => AreAnyDataTabsVisible, false);
                }
            }
        }

        public bool IsViewsTabVisible
        {
            get { return _isViewsTabVisible; }
            set
            {
                if (_isViewsTabVisible != value)
                {
                    _isViewsTabVisible = value;
                    OnPropertyChanged(() => IsViewsTabVisible, false);
                    OnPropertyChanged(() => AreAnyDataTabsVisible, false);
                }
            }
        }

        public bool IsStoredProceduresTabVisible
        {
            get { return _isStoredProceduresTabVisible; }
            set
            {
                if (_isStoredProceduresTabVisible != value)
                {
                    _isStoredProceduresTabVisible = value;
                    OnPropertyChanged(() => IsStoredProceduresTabVisible, false);
                    OnPropertyChanged(() => AreAnyDataTabsVisible, false);
                }
            }
        }

        public bool IsSqlCommandTabVisible
        {
            get { return _isSqlCommandTabVisible; }
            set
            {
                if (_isSqlCommandTabVisible != value)
                {
                    _isSqlCommandTabVisible = value;
                    OnPropertyChanged(() => IsSqlCommandTabVisible, false);
                }
            }
        }

        public bool IsSampleDataTabVisible
        {
            get { return _isSampleDataTabVisible; }
            set
            {
                if (_isSampleDataTabVisible != value)
                {
                    _isSqlCommandTabVisible = value;
                    OnPropertyChanged(() => _isSampleDataTabVisible, false);
                }
            }
        }
               
        public DataTable SampleData
        {
            get { return _sampleData; }
            set
            {
                if (_sampleData != value)
                {
                    _sampleData = value;
                    OnPropertyChanged(() => SampleData, false);
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

        #endregion

        #region Private/Internal methods

        internal void BuildSqlCommandFromTableSelection()
        {
            var sqlColumns = string.Empty;
            foreach (var col in SelectedColumns)
            {
                if (!string.IsNullOrEmpty(sqlColumns))
                    sqlColumns += ",";
                sqlColumns += string.Format("[{0}]", col.Name);
            }
            if (string.IsNullOrEmpty(sqlColumns))
                sqlColumns = "*";

            SqlCommand = string.Format("SELECT {0} FROM {1}", sqlColumns, SelectedSqlServer.SelectedTable);
        }
        #endregion
    }
}
