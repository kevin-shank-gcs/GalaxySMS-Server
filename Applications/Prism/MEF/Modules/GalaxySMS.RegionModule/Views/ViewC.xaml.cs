using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Region.Views
{
    /// <summary>
    /// Interaction logic for ViewC.xaml
    /// </summary>
    [Export("ViewC")]
    public partial class ViewC : UserControlViewBase
    {
        public ViewC()
        {
            InitializeComponent();
        }
    }
}
