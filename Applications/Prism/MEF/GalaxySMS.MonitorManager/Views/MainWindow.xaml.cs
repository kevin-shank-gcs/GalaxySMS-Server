using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
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
using GalaxySMS.MonitorManager.Helpers;
using GalaxySMS.MonitorManager.ViewModels;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Telerik.Windows.Controls;

namespace GalaxySMS.MonitorManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : RadRibbonWindow
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _cancelClose = true;

        [ImportingConstructor]
        public MainWindow(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
            var dc = DataContext as MainWindowViewModel;
            if (dc != null)
                this.InputBindings.Add(new KeyBinding(dc.OpenHelpPageCommand, new KeyGesture(Key.F1)));
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
    }
}