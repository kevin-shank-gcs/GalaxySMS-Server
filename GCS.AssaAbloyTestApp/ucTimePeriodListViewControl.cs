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
    public partial class ucTimePeriodListViewControl : UserControl
    {
        private List<TimePeriod> _tpList = new List<TimePeriod>();

        public ucTimePeriodListViewControl()
        {
            InitializeComponent();
            TimePeriods = _tpList.ToArray();
        }


        private TimePeriod[] _TimePeriods;
        public TimePeriod[] TimePeriods
        {
            get
            {
                return _TimePeriods;
            }
            set
            {
                _TimePeriods = value;
                lbTimePeriods.Items.Clear();
                _tpList.Clear();
                if ( TimePeriods != null)
                {
                    _tpList = TimePeriods.ToList();
                    foreach (var tp in TimePeriods)
                    {
                        var data = new StartEndTimePeriod(tp.start, tp.end);
                        lbTimePeriods.Items.Add(data);
                    }

                }
            }
        }

        public void Add(TimePeriod tp)
        {
            _tpList.Add(tp);
            TimePeriods = _tpList.ToArray();
        }

        public void Remove(TimePeriod tp)
        {
            _tpList.Remove(tp);
            TimePeriods = _tpList.ToArray();
        }

        public void Clear()
        {
            _tpList = new List<TimePeriod>();
            TimePeriods = _tpList.ToArray();
        }
    }
}
