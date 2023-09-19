using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.Site.RibbonTabs
{
    /// <summary>
    ///     Interaction logic for SiteViewModel.xaml
    /// </summary>
    public partial class SiteViewTab : RadRibbonTab, ISupportDataContext
    {
        public SiteViewTab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RadRibbonTab));
        }
    }
}