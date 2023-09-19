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
using GalaxySMS.FacilityManager.ViewModels;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls;

namespace GalaxySMS.FacilityManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : RadRibbonWindow
    {
        [ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
            var dc = DataContext as MainWindowViewModel;
            if( dc != null)
            this.InputBindings.Add(new KeyBinding(dc.OpenHelpPageCommand, new KeyGesture(Key.F1)));
        }


    }
}
