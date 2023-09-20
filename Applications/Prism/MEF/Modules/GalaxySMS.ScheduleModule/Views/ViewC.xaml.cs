using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Schedule.Views
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
