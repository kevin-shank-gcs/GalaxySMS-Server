using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.AssaAbloy.RibbonTabs;
using GalaxySMS.AssaAbloy.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.AssaAbloy.Views
{
    /// <summary>
    /// Interaction logic for AssaAbloyView.xaml
    /// </summary>
    [Export("AssaAbloyView")]
    //[DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class AssaAbloyView : UserControlViewBase, ISupportDataContext
    {
        public AssaAbloyView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as AssaAbloyViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as AssaAbloyViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(CommonResources.Resources.MaintainRegions_AreYouSureDeleteRegion, e.Message),
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
