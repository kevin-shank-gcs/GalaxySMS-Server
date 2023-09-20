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
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls;

namespace GalaxySMS.Client.UI
{
    /// <summary>
    /// Interaction logic for TimeScheduleMapUserControl.xaml
    /// </summary>
    public partial class TimeScheduleMapUserControl : UserControlViewBase
    {
        public TimeScheduleMapUserControl()
        {
            InitializeComponent();
        }

        //private void UserEntityTileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var vm = DataContext as ISupportsUserEntitySelection;
        //    if (vm != null)
        //    {
        //        vm.SelectedUserEntities = ((RadTileList)sender).SelectedItems;
        //    }
        //}
    }
}
