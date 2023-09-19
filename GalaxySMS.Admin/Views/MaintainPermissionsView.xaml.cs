using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for MaintainPermissionsView.xaml
    /// </summary>
    public partial class MaintainPermissionsView : UserControlViewBase
    {
        public MaintainPermissionsView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as MaintainPermissionsViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as MaintainPermissionsViewModel;
            if (vm != null)
            {
                OnUnwireViewModelEvents(vm);
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(Properties.Resources.MaintainPermissions_AreYouSureDeletePermission, e.Message), 
                Properties.Resources.Common_ConfirmDelete,
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        void OnErrorOccured(object sender, ErrorMessageEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage, Properties.Resources.Common_Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
