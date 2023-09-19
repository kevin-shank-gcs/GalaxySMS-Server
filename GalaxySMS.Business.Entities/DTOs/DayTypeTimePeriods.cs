using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class DayTypeTimePeriods : DayType
    {
        public DayTypeTimePeriods() :base()
        {
            Initialize();
        }

        public DayTypeTimePeriods(DayType e) :base(e)
        {
            Initialize();
        }


        public DayTypeTimePeriods(DayTypeTimePeriods e) : base(e)
        {
            Initialize();
            //TimePeriods = e.TimePeriods;
            FifteenMinuteTimePeriods = e.FifteenMinuteTimePeriods;
            GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            //OneMinuteTimePeriods = e.OneMinuteTimePeriods;
        }

        protected void Initialize()
        {
            base.Initialize();
            //this.TimePeriods = new HashSet<TimePeriod>();
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriod>();
            //this.OneMinuteTimePeriods = new HashSet<TimePeriod>();
        }

        public ICollection<TimePeriod> FifteenMinuteTimePeriods { get; set; }

        public Guid GalaxyTimePeriodUid { get; set; }
    }
}
