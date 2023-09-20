using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.Schedule.Views
{
    /// <summary>
    /// Interaction logic for EditScheduleView.xaml
    /// </summary>
    public partial class EditScheduleView : UserControlViewBase, ISupportDataContext
    {
        public EditScheduleView()
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
