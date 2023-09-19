using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCS.AssaAbloyDSR.DSRAccessControlService;
using GCS.AssaAbloyDSR;

namespace GCS.AssaAbloyTestApp
{
    public partial class DayPeriodViewControl : UserControl
    {
        public DayPeriodViewControl()
        {
            InitializeComponent();
        }


        private DayPeriod _DayPeriod;
        public DayPeriod DayPeriod
        {
            get
            {
                return _DayPeriod;
            }
            set
            {
                _DayPeriod = value;
                for (int x = 0; x < WeekDayCheckBoxList.Items.Count; x++)
                {
                    WeekDayCheckBoxList.SetItemChecked(x, false);
                }
                
                if( DayPeriod != null)
                {
                    for (int x = 0; x < WeekDayCheckBoxList.Items.Count; x++)
                    {
                        if (DayPeriod.weekDays.Contains((WeekDay) WeekDayCheckBoxList.Items[x]))
                            WeekDayCheckBoxList.SetItemChecked(x, true);
                    }
                    ucTimePeriodListViewControl.TimePeriods = this.DayPeriod.timePeriods;
                }
            }
        }

        private void clbDayPeriodControl_Load(object sender, EventArgs e)
        {
            WeekDayCheckBoxList.Items.Add(WeekDay.SUNDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.MONDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.TUESDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.WEDNESDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.THURSDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.FRIDAY);
            WeekDayCheckBoxList.Items.Add(WeekDay.SATURDAY);
        }
    }
}
