using System.ComponentModel.Composition;
using System.Windows;
using GalaxySMS.Site.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;
using Prism.Regions;

namespace GalaxySMS.Site.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("SiteView")]
    //[DependentView(typeof(SiteViewTab), RegionNames.RibbonTabRegion)]
    public partial class SiteView : UserControlViewBase, ISupportDataContext
    {
        [ImportingConstructor]
        public SiteView(IRegionManager regionManager)
        {
            InitializeComponent();
            
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as SiteViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccurred -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as SiteViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccurred += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(CommonResources.Resources.MaintainSites_AreYouSureDeleteSite, e.Message),
               CommonResources.Resources.Common_ConfirmDelete,
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
