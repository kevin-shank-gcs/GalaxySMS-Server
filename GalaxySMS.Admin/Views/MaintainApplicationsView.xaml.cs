using System.Windows;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for MaintainApplicationsView.xaml
    /// </summary>
    public partial class MaintainApplicationsView : UserControlViewBase
    {
        public MaintainApplicationsView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainApplicationsViewModel vm = viewModel as MaintainApplicationsViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainApplicationsViewModel vm = viewModel as MaintainApplicationsViewModel;
            if (vm != null)
            {
                OnUnwireViewModelEvents(vm);
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format( Properties.Resources.MaintainApplications_AreYouSureDeleteApplication, e.Message), 
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
    }
}
