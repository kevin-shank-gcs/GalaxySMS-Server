using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class DayTypeTimePeriodsPutReq : DayTypeTimePeriodPutReqBase//DayTypePutReq
    {
        public DayTypeTimePeriodsPutReq() :base()
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodPutReq>();
        }

        public DayTypeTimePeriodsPutReq(DayTypeReq e) 
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodPutReq>();
        }


        public DayTypeTimePeriodsPutReq(DayTypeTimePeriodsPutReq e)
        {
            this.FifteenMinuteTimePeriods = new HashSet<TimePeriodPutReq>();
            FifteenMinuteTimePeriods = e.FifteenMinuteTimePeriods;
            GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
        }

        public ICollection<TimePeriodPutReq> FifteenMinuteTimePeriods { get; set; }

        public Guid GalaxyTimePeriodUid { get; set; }
    }
}
