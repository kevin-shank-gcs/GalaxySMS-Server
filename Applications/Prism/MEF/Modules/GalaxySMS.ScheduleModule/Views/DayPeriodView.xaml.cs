using System.ComponentModel.Composition;
using System.Windows;
using GalaxySMS.Schedule.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Schedule.Views
{
    /// <summary>
    /// Interaction logic for DayPeriodView.xaml
    /// </summary>
    [Export("DayPeriodView")]
    //[DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class DayPeriodView : UserControlViewBase, ISupportDataContext
    {
        public DayPeriodView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as DayPeriodViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as DayPeriodViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(CommonResources.Resources.MaintainDayPeriods_AreYouSureDeleteDayPeriod, e.Message),
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
