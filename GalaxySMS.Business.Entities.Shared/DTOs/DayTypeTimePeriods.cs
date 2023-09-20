using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimePeriod> FifteenMinuteTimePeriods { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyTimePeriodUid { get; set; }
    }
}
