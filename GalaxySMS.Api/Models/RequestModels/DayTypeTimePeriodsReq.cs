using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class DayTypeTimePeriodsReq : DayTypeTimePeriodReqBase//DayTypeReq
    {
        public DayTypeTimePeriodsReq() :base()
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodReq>();
        }

        public DayTypeTimePeriodsReq(DayTypeReq e) 
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodReq>();
        }


        public DayTypeTimePeriodsReq(DayTypeTimePeriodsReq e)
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodReq>();
            FifteenMinuteTimePeriods = e.FifteenMinuteTimePeriods;
            GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
        }

        public ICollection<TimePeriodReq> FifteenMinuteTimePeriods { get; set; }

        public Guid GalaxyTimePeriodUid { get; set; }
    }
}
