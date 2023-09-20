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
    public class TimeScheduleSelectBasic : TimeScheduleBasic
    {
        public TimeScheduleSelectBasic() :base()
        {
            Initialize();
        }
        public TimeScheduleSelectBasic(TimeScheduleBasic e) : base(e)
        {
            Initialize();
        }

        public TimeScheduleSelectBasic(TimeScheduleSelectBasic e) : base(e)
        {
            Initialize();
            Selected = e.Selected;
            ClusterScheduleMap = e.ClusterScheduleMap;
        }

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterScheduleMap = new GalaxyClusterTimeScheduleMapBasic();
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Selected { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyClusterTimeScheduleMapBasic ClusterScheduleMap { get; set; }
    }
}
