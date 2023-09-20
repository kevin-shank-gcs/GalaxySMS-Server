using System.Windows;
using System.Windows.Controls;
using GalaxySMS.SiteManager.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.SiteManager.Views
{
    /// <summary>
    /// Interaction logic for MaintainUsersView.xaml
    /// </summary>
    public partial class MaintainUsersView : UserControlViewBase
    {
        public MaintainUsersView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainUsersViewModel vm = viewModel as MaintainUsersViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainUsersViewModel vm = viewModel as MaintainUsersViewModel;
            if (vm != null)
            {
                OnUnwireViewModelEvents(vm);
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(Properties.Resources.MaintainUsers_AreYouSureDeleteUser, e.Message),
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
