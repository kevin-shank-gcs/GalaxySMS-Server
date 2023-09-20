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
    public partial class ucDayExceptionViewControl : UserControl
    {
        private DayException dayException;

        public ucDayExceptionViewControl()
        {
            InitializeComponent();
        }

        public DayException DayException
        {
            get
            {
                return this.dayException;
            }

            set
            {
                this.dayException = value;
                if( this.DayException != null)
                {
                    dtpDate.Value = this.DayException.localDate.ToDateTime();
                    ucTimePeriodListViewControl.TimePeriods = this.DayException.timePeriods;
                }
            }
        }
    }
}
