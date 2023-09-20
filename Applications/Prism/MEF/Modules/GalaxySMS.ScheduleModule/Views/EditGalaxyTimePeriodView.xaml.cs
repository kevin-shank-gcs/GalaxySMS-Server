using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.Schedule.Views
{
    /// <summary>
    /// Interaction logic for EditGalaxyTimePeriodView.xaml
    /// </summary>
    public partial class EditGalaxyTimePeriodView : UserControlViewBase, ISupportDataContext
    {
        public EditGalaxyTimePeriodView()
        {
            InitializeComponent();
        }

        //private void radTabOneMinuteSchedules_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        //{
        //    if (e.Delta > 0)
        //    {
        //        if (ZoomFactor < 2)
        //            ZoomFactor += .02;
        //    }
        //    else
        //    {
        //        if (ZoomFactor > .05)
        //            ZoomFactor -= .02;
        //    }
        //}

        //private void radTabFifteenMinuteSchedules_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        //{

        //}
    }
}
