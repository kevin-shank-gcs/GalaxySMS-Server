using System.Windows;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for GalaxyPanelCommunicationView.xaml
    /// </summary>
    public partial class GalaxyPanelCommunicationView : UserControlViewBase
    {
        public GalaxyPanelCommunicationView()
        {
            InitializeComponent();
        }

        protected override void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModelBase)
            {
                ((ViewModelBase)DataContext).ViewUnloaded(this);
            }
        }
    }
}
