using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for MaintainApplicationsView.xaml
    /// </summary>
    public partial class MaintainRolesView : UserControlViewBase
    {
        public MaintainRolesView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainRolesViewModel vm = viewModel as MaintainRolesViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccurred -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainRolesViewModel vm = viewModel as MaintainRolesViewModel;
            if (vm != null)
            {
                OnUnwireViewModelEvents(vm);
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccurred += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format( Properties.Resources.MaintainRoles_AreYouSureDeleteRole, e.Message),
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
