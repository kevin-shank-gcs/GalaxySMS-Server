using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("EditAreaView")]
    //[DependentView(typeof(ViewBTab), RegionNames.RibbonTabRegion)]
    //[DependentView(typeof(ViewC), RegionNames.LeftSidebarRegion)]
    //[RegionMemberLifetime(KeepAlive = false)]
    public partial class EditAreaView : UserControlViewBase, ISupportDataContext
    {
        public EditAreaView()
        {
            InitializeComponent();
        }
    }
}
