using System.Diagnostics;
using System.Windows.Navigation;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for LicenseView.xaml
    /// </summary>
    public partial class LicenseView : UserControlViewBase
    {
        public LicenseView(bool bAllowImport = false)
        {
            InitializeComponent();
            var dc = DataContext as LicenseViewModel;
            if( dc != null)
                dc.CanUpdateLicense = bAllowImport;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (e.Uri != null && string.IsNullOrEmpty(e.Uri.OriginalString) == false)
            {
                string uri = e.Uri.AbsoluteUri;
                Process.Start(new ProcessStartInfo(uri));

                e.Handled = true;
            }
        }
    }
}
