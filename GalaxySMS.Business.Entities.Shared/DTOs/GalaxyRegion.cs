using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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

    public class GalaxyRegion : EntityBase
	{
		public GalaxyRegion():base()
		{
		    RegionId = string.Empty;
		    RegionName = string.Empty;
		}

		public GalaxyRegion(String regionId, String regionName) :base()
		{
			RegionId = regionId;
		    RegionName = regionName;
		}

        public GalaxyRegion(GalaxyRegion o) :base(o)
		{
            RegionId = o.RegionId;
            RegionName = o.RegionName;
        }


        public String UniqueId { get { return RegionId; } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String RegionId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String RegionName { get; set; }

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
