using System.Windows;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for GalaxyConnectionDebugView.xaml
    /// </summary>
    public partial class GalaxyConnectionDebugView : UserControlViewBase
    {
        public GalaxyConnectionDebugView()
        {
            InitializeComponent();
        }

        protected override void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModelBase)
            {
                ((ViewModelBase) DataContext).ViewUnloaded(this);
            }
        }
    }
}
