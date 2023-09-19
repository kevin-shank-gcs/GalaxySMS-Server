using GalaxySMS.AccessPortal.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using System.ComponentModel.Composition;
using System.Windows;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.AccessPortal.Views
{
    /// <summary>
    /// Interaction logic for AccessPortalView.xaml
    /// </summary>
    [Export("AccessPortalView")]
    //[DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class AccessPortalView : UserControlViewBase, ISupportDataContext
    {
        public AccessPortalView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as AccessPortalViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as AccessPortalViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(CommonResources.Resources.MaintainAccessPortals_AreYouSureDeleteAccessPortal, e.Message),
                GalaxySMS.Resources.Resources.Common_ConfirmDelete,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        void OnErrorOccured(object sender, ErrorMessageEventArgs e)
        {
            RadWindow.Alert(new DialogParameters
            {
                Content = e.ErrorMessage,
                Owner = Application.Current.MainWindow
            });
            //            MessageBox.Show(e.ErrorMessage, GalaxySMS.Client.Resources.Resources.Common_Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
