using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.Site.Views
{
    /// <summary>
    /// Interaction logic for EditSiteView.xaml
    /// </summary>
    //[Export("EditSiteView")]
    //[DependentView(typeof(GalaxySMS.GalaxyHardware.Views.GalaxyHardwareView), RegionNames.GalaxyHardwareRegion)]
    public partial class EditSiteView : UserControlViewBase, ISupportDataContext
    {
        public EditSiteView()
        {
            InitializeComponent();
        }
    }
}
