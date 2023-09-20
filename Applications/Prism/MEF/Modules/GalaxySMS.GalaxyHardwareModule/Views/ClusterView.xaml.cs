using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("ClusterView")]
//    [DependentView(typeof(ViewATab), RegionNames.RibbonTabRegion)]
    public partial class ClusterView : UserControlViewBase, ISupportDataContext
    {
        public ClusterView()
        {
            InitializeComponent();
        }
    }
}
