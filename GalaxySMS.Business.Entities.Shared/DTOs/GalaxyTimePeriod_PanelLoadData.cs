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
	public class GalaxyTimePeriod_PanelLoadData
    {
        public GalaxyTimePeriod_PanelLoadData()
        {
            PanelLoadData = new List<GalaxyTimePeriod_GetPanelLoadData>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyTimePeriodUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public IEnumerable<GalaxyTimePeriod_GetPanelLoadData> PanelLoadData { get; set; }

    }
}
