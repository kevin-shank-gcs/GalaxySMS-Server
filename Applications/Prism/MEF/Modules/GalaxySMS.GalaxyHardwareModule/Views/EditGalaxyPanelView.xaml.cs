using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("EditGalaxyPanelView")]
    //[DependentView(typeof(ViewBTab), RegionNames.RibbonTabRegion)]
    //[DependentView(typeof(ViewC), RegionNames.LeftSidebarRegion)]
    //[RegionMemberLifetime(KeepAlive = false)]
    public partial class EditGalaxyPanelView : UserControlViewBase, ISupportDataContext
    {
        public EditGalaxyPanelView()
        {
            InitializeComponent();
        }
    }
}
