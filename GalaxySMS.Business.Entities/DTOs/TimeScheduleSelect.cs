using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class TimeScheduleSelect : TimeSchedule
    {
        public TimeScheduleSelect() :base()
        {
            Initialize();
        }

        public TimeScheduleSelect(TimeSchedule e) :base(e)
        {
            Initialize();
        }


        public TimeScheduleSelect(TimeScheduleSelect e) : base(e)
        {
            Initialize();
            Selected = e.Selected;
            ClusterScheduleMap = e.ClusterScheduleMap;
        }

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterScheduleMap = new GalaxyClusterTimeScheduleMap();
        }

        public bool Selected { get; set; }
        public GalaxyClusterTimeScheduleMap ClusterScheduleMap { get; set; }
    }
}
