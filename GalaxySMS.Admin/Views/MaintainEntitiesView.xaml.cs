using System;
using System.Windows;
using GalaxySMS.Admin.Support;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using PDSA.MessageBroker;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for MaintainEntitiesView.xaml
    /// </summary>
    public partial class MaintainEntitiesView : UserControlViewBase
    {
        public MaintainEntitiesView()
        {
            InitializeComponent();

        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainEntitiesViewModel vm = viewModel as MaintainEntitiesViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccurred -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            MaintainEntitiesViewModel vm = viewModel as MaintainEntitiesViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccurred += OnErrorOccured;
            }
        }

        private void OnEntitySelected(object sender, EntityEventArgs e)
        {

        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(Properties.Resources.MaintainEntities_AreYouSureDeleteEntity, e.Message), 
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
