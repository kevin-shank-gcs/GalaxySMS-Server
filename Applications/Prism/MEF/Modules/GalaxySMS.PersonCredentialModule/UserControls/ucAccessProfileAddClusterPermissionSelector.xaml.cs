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
using GalaxySMS.Client.Entities;

namespace GalaxySMS.PersonCredential.UserControls
{
    /// <summary>
    /// Interaction logic for ucAccessProfileAddClusterPermissionSelector.xaml
    /// </summary>
    public partial class ucAccessProfileAddClusterPermissionSelector : UserControl
    {
        public ucAccessProfileAddClusterPermissionSelector()
        {
            InitializeComponent();
        }

        //private void TreeView_PreviewSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var isSelectedItemNotRegion = !e.AddedItems.OfType<Region>().Any();
        //    if (isSelectedItemNotRegion)
        //    {
        //        e.Handled = true;

        //        var selectedContainer = this.xTreeView.SelectedContainer;
        //        if (selectedContainer != null) selectedContainer.Focus();
        //    }
        //}
    }

}
