using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.GalaxyHardware.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("EditInputOutputGroupView")]
    //[DependentView(typeof(ViewBTab), RegionNames.RibbonTabRegion)]
    //[DependentView(typeof(ViewC), RegionNames.LeftSidebarRegion)]
    //[RegionMemberLifetime(KeepAlive = false)]
    public partial class EditInputOutputGroupView : UserControlViewBase, ISupportDataContext
    {
        public EditInputOutputGroupView()
        {
            InitializeComponent();
        }
    }
}
