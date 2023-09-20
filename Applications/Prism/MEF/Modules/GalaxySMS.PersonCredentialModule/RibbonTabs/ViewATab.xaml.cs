using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.PersonCredential.RibbonTabs
{
    /// <summary>
    ///     Interaction logic for ViewATab.xaml
    /// </summary>
    public partial class ViewATab : RadRibbonTab, ISupportDataContext
    {
        public ViewATab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RadRibbonTab));
        }
    }
}