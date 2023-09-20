using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for GalaxyFlashImageView.xaml
    /// </summary>
    [Export("GalaxyFlashImageView")]
//    [DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class GalaxyFlashImageView : UserControlViewBase, ISupportDataContext
    {
        public GalaxyFlashImageView()
        {
            InitializeComponent();
        }
    }
}
