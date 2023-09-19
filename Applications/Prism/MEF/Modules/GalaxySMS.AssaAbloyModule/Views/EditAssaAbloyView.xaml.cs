using System;
using System.Collections.Generic;
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
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.AssaAbloy.Views
{
    /// <summary>
    /// Interaction logic for EditRegionViewxaml.xaml
    /// </summary>
    public partial class EditAssaAbloyView : UserControlViewBase, ISupportDataContext
    {
        public EditAssaAbloyView()
        {
            InitializeComponent();
            //radGridViewAssaAccessPoints.AddHandler(RadComboBox.SelectionChangedEvent, new System.Windows.Controls.SelectionChangedEventHandler(OnAccessPointSelectionChanged));
        }

        //private void OnAccessPointSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var combo = e.OriginalSource as RadComboBox;
        //}
    }
}
