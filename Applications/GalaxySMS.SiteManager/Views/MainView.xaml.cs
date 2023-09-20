using System.Windows;
using GCS.Core.Common.UI.Core;
using SPECSID.Windows.Forms;

namespace GalaxySMS.SiteManager.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControlViewBase
    {
        public MainView()
        {
            InitializeComponent();
        }
        CaptureControl cap = null;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
