using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("EditAccessGroupView")]
    //[DependentView(typeof(ViewBTab), RegionNames.RibbonTabRegion)]
    //[DependentView(typeof(ViewC), RegionNames.LeftSidebarRegion)]
    //[RegionMemberLifetime(KeepAlive = false)]
    public partial class EditAccessGroupView : UserControlViewBase, ISupportDataContext
    {
        public EditAccessGroupView()
        {
            InitializeComponent();
        }
    }
}
