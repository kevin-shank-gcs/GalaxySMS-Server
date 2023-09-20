using System.ComponentModel.Composition;
using System.Windows;
using GalaxySMS.Region.ViewModels;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Region.Properties;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.Region.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("RegionView")]
    //[DependentView(typeof (RegionViewTab), RegionNames.RibbonTabRegion)]
    public partial class RegionView : UserControlViewBase, ISupportDataContext
    {
        private const string StateExtendedPropertyName = "STATE_NAME";
        private MapShape countyShape;
        private MapShape stateShape;

        public RegionView()
        {
            InitializeComponent();
        }

        protected override void OnUnwireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as RegionViewModel;
            if (vm != null)
            {
                vm.ConfirmDelete -= OnConfirmDelete;
                vm.ErrorOccured -= OnErrorOccured;
            }
        }

        protected override void OnWireViewModelEvents(ViewModelBase viewModel)
        {
            var vm = viewModel as RegionViewModel;
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

        //private void BringIntoView(MapShape shape)
        //{
        //    LocationRect bestView = this.StateLayer.GetBestView(new object[] { shape });
        //    RadMap1.SetView(bestView);
        //}

        //private void CountyLayerReaderReadCompleted(object sender, ReadShapesCompletedEventArgs eventArgs)
        //{
        //    if (eventArgs.Error != null)
        //        return;

        //    foreach (MapShape shape in this.CountyLayer.Items)
        //        shape.MouseLeftButtonUp += this.CountyShapeMouseLeftButtonUp;

        //    //if (this.ZoomInCheckBox.IsChecked == true)
        //        this.BringIntoView(this.stateShape);
        //}

        //private void CountyShapeMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    MapShape shape = sender as MapShape;

        //    this.ResetCountyShapeColor();

        //    this.countyShape = shape;
        //    shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0xB5, 0x85));
        //}

        //private string GetExtendedProperty(MapShape shape, string propertyName)
        //{
        //    return shape.ExtendedData.GetValue(propertyName).ToString();
        //}

        //private void ResetCountyShapeColor()
        //{
        //    if (this.countyShape != null)
        //        this.countyShape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xDB, 0xA3));
        //}

        //private void ResetStateShapeColor()
        //{
        //    if (this.stateShape != null)
        //        this.stateShape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xF0, 0xD9));
        //}

        //private void StateLayerReaderReadCompleted(object sender, ReadShapesCompletedEventArgs eventArgs)
        //{
        //    foreach (MapShape shape in this.StateLayer.Items)
        //        shape.MouseLeftButtonUp += this.StateShapeMouseLeftButtonUp;
        //}

        //private void StateShapeMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    MapShape shape = sender as MapShape;
        //    this.stateShape = shape;
        //    //(this.DataContext as RegionViewModel).County = GetExtendedProperty(shape, StateExtendedPropertyName);

        //    //if ((bool)this.LoadCountyDataCheckBox.IsChecked)
        //    //{
        //    //    this.stateShape = shape;
        //    //    (this.Resources["DataContext"] as ExampleViewModel).County = GetExtendedProperty(shape, StateExtendedPropertyName);
        //    //}
        //    //else
        //    //{
        //    //    this.ResetStateShapeColor();

        //    //    this.stateShape = shape;
        //    //    shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xE4, 0xBA));
        //    //}
        //}
    }
}