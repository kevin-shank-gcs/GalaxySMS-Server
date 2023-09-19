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
    public class DayTypeSelect : DayType
    {
        public DayTypeSelect() :base()
        {
            Initialize();
        }

        public DayTypeSelect(DayType e) :base(e)
        {
            Initialize();
        }


        public DayTypeSelect(DayTypeSelect e) : base(e)
        {
            Initialize();
            Selected = e.Selected;
            ClusterDayTypeMap = e.ClusterDayTypeMap;
        }

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterDayTypeMap = new GalaxyClusterDayTypeMap();
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
        public GalaxyClusterDayTypeMap ClusterDayTypeMap { get; set; }
    }
}
