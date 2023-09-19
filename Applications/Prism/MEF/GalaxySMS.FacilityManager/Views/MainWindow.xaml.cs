using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
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
using GalaxySMS.Common.Shared.Constants;
using GalaxySMS.FacilityManager.Helpers;
using GalaxySMS.FacilityManager.ViewModels;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GalaxySMS.TelerikWPF.Infrastructure;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using Telerik.Windows.Controls;
using Prism6Regions = Prism.Regions;

namespace GalaxySMS.FacilityManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : RadRibbonWindow
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly RegionManager _regionManager;
        private bool _cancelClose = true;

        [ImportingConstructor]
        public MainWindow(IEventAggregator eventAggregator, Prism6Regions.IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager as Prism6Regions.RegionManager;
            InitializeComponent();
            var dc = DataContext as MainWindowViewModel;
            if (dc != null)
                this.InputBindings.Add(new KeyBinding(dc.OpenHelpPageCommand, new KeyGesture(Key.F1)));

            eventAggregator.GetEvent<SaveLayoutEvent>().Subscribe(this.SaveLayout, ThreadOption.PublisherThread);
            eventAggregator.GetEvent<LoadLayoutEvent>().Subscribe(this.LoadLayout, ThreadOption.PublisherThread);
            Application.Current.Exit += (s, e) => this.SaveLayout(null);
            radDocking.CustomElementLoading += RadDocking_CustomElementLoading;
        }

        private void RadDocking_CustomElementLoading(object sender, LayoutSerializationCustomLoadingEventArgs e)
        {
            try
            {
                //if (e.CustomElementTypeName != PrismModuleViewNames.SignInOutView)
                {
                    var myVm = this.DataContext as MainWindowViewModel;
                    if (myVm != null)
                    {
                        var newPane = myVm.GetNewDocumentPaneView(e.AffectedElementSerializationTag);
                        myVm.Navigate(newPane);

                        e.SetAffectedElement(newPane);
                    }
                }
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
            }
        }

        private void RadDocking_Close(object sender, Telerik.Windows.Controls.Docking.StateChangeEventArgs e)
        {
            _eventAggregator.GetEvent<PubSubEvent<Telerik.Windows.Controls.Docking.StateChangeEventArgs>>().Publish(e);
            //ObservableCollection<RadPane> closedPanes = new ObservableCollection<RadPane>();

            //if (this.RadContextMenu.ItemsSource != null)
            //{
            //    closedPanes = this.RadContextMenu.ItemsSource as ObservableCollection<RadPane>;
            //}

            //foreach (RadPane Pane in e.Panes)
            //{
            //    Pane.Header = string.Format("Show {0}", Pane.Header);
            //    closedPanes.Add(Pane);
            //}

            //this.RadContextMenu.ItemsSource = closedPanes;
        }

        private void RadDocking_PreviewClose(object sender, Telerik.Windows.Controls.Docking.StateChangeEventArgs e)
        {
            var dr = MessageBox.Show("Sure?", "", MessageBoxButton.YesNo);

            if (dr != MessageBoxResult.Yes)
            {
                e.Handled = true;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _cancelClose = true;
            TelerikHelpers.PromptForExit(OnConfirmClosed);
            e.Cancel = _cancelClose;
        }

        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                _cancelClose = false;
            }
        }

        public const string DockingLayoutFileName = "layout.xml";

        private void SaveLayout(object param)
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (var isoStream = storage.OpenFile(DockingLayoutFileName, FileMode.Create))
                {
                    radDocking.SaveLayout(isoStream);

                    isoStream.Seek(0, SeekOrigin.Begin);
                    StreamReader reader2 = new StreamReader(isoStream);
                    var str = reader2.ReadToEnd();
                }
            }
        }

        private void LoadLayout(object param)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists(DockingLayoutFileName))
                {
                    using (var isoStream = storage.OpenFile(DockingLayoutFileName, FileMode.Open))
                    {
                        isoStream.Seek(0, SeekOrigin.Begin);
                        StreamReader reader2 = new StreamReader(isoStream);
                        var str = reader2.ReadToEnd();
                        isoStream.Seek(0, SeekOrigin.Begin);
                        radDocking.LoadLayout(isoStream);
                    }
                }
            }
        }

    }
}