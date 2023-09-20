using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.Region.RibbonTabs
{
    /// <summary>
    ///     Interaction logic for ViewATab.xaml
    /// </summary>
    public partial class RegionViewTab : RadRibbonTab, ISupportDataContext
    {
        public RegionViewTab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RadRibbonTab));
        }
    }
}