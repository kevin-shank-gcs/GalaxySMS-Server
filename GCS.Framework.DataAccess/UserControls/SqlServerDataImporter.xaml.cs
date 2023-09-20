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
using GCS.Framework.DataAccess.ViewModels;
using Telerik.Windows.Controls;

namespace GCS.Framework.DataAccess.UserControls
{
    /// <summary>
    /// Interaction logic for SampleView1.xaml
    /// </summary>
    public partial class SqlServerDataImporter : UserControlViewBase
    {
        private SqlServerDataImportViewModel _viewModel;

        public SqlServerDataImporter()
        {
            InitializeComponent();
            //_viewModel = (SqlServerDataImportViewModel)this.Resources["viewModel"];
            //_viewModel.OkButtonClicked += _viewModel_OkButtonClicked;
            //_viewModel.CancelButtonClicked += _viewModel_CancelButtonClicked;
        }

        void _viewModel_CancelButtonClicked(object sender, EventArgs e)
        {
            RaiseCancelClicked(sender, e);
            CloseParentWindow(false);
        }

        void _viewModel_ConnectionValid(object sender, SqlServerSelectedEventArgs e)
        {
            RaiseConectionValid(sender, e);
        }

        void _viewModel_OkButtonClicked(object sender, SqlServerSelectedEventArgs e)
        {
            RaiseOKClicked(sender, e);
            CloseParentWindow(true);
        }

        private void CloseParentWindow(bool? dialogResult)
        {
            var parentWindow = Window.GetWindow(this);
            this.DialogResult = dialogResult;
            parentWindow.Close();
        }

        #region Public Properties
        public Nullable<bool> DialogResult { get; internal set; }

        public SqlServerDataImportViewModel ViewModel
        {
            get { return _viewModel; }
        }
        #endregion

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
        protected void RaiseOKClicked(object sender, SqlServerSelectedEventArgs e)
        {
            DialogResult = true;
            OKClickedEventHandler handler = this.OkButtonClicked;
            if (handler != null)
            {
                //// Create event args
                //SqlServerSelectedEventArgs args =
                //  new SqlServerSelectedEventArgs(_viewModel.SelectedSqlServer);

                //// Raise the OKClickedEventHandler event.
                handler(this, e);
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
        protected void RaiseCancelClicked(object sender, EventArgs e)
        {
            DialogResult = false;
            CancelClickedEventHandler handler = this.CancelButtonClicked;
            if (handler != null)
            {
                //// Create event args
                //EventArgs args =
                //  new EventArgs();

                //// Raise the CancelClickedEventHandler event.
                handler(this, e);
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
        protected void RaiseConectionValid(object sender, SqlServerSelectedEventArgs e)
        {
            ConnectionValidEventHandler handler = this.ConnectionValid;
            if (handler != null)
            {
                //// Create event args
                //SqlServerSelectedEventArgs args =
                //  new SqlServerSelectedEventArgs(_viewModel.SelectedSqlServer);

                // Raise the ConnectionValidEventHandler event.
                handler(sender, e);
            }
        }
        #endregion

        private void TableColumnSelection_Changed(object sender, SelectionChangeEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.BuildSqlCommandFromTableSelection();
        }

        #endregion

        private void UserControlViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as DataImportWizardViewModel;
            if (vm != null)
                _viewModel = vm.SqlServerDataImportVM;

        }
    }
}
