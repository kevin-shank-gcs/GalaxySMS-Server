using System;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;
using GalaxySMS.Prism.Infrastructure.Events;
using GalaxySMS.Schedule.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Prism.Events;
using Telerik.Windows.Controls;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Schedule.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    [Export("DayTypeView")]
    //[DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class DayTypeView : UserControlViewBase, ISupportDataContext
    {
        //[Import]
        //private IEventAggregator _eventAggregator;

        public DayTypeView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as DayTypeViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as DayTypeViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete += OnConfirmDelete;
                vm.ErrorOccured += OnErrorOccured;
            }
        }

        void OnConfirmDelete(object sender, CancelMessageEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(string.Format(CommonResources.Resources.MaintainDayTypes_AreYouSureDeleteDayType, e.Message),
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

        //private void ScheduleViewBase_OnShowDialog(object sender, ShowDialogEventArgs e)
        //{
        //    var selectedAppointment = ((Telerik.Windows.Controls.RadScheduleView)(sender)).SelectedAppointment as DateTypeAppointment;
        //    ((DayTypeViewModel)DataContext).SelectedAppointment = selectedAppointment;
        //    var additionalData = DataContext;
        //    e.DialogViewModel.AdditionalData = additionalData;
        //}

        //private void cbDayTypes_OnDropDownOpened(object sender, EventArgs e)
        //{
        //    this.radCalendar.SelectionMode = SelectionMode.Multiple;
        //}

        //private void cbDayTypes_OnDropDownClosed(object sender, EventArgs e)
        //{
        //    this.radCalendar.SelectionMode = SelectionMode.Single;
        //}

        //private void cbDayTypes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedDates = radCalendar.SelectedDates;
        //    var selectedDayType = e.AddedItems;
        //    if (e.AddedItems.Count > 0)
        //    {
        //        var payload = new DateDayTypeChanged()
        //        {
        //            Dates = radCalendar.SelectedDates.ToList(),
        //            DayType = e.AddedItems[0] as DayType
        //        };

        //        _eventAggregator.GetEvent<PubSubEvent<DateDayTypeChanged>>().Publish(payload);
        //    }
        //}
    }
}
