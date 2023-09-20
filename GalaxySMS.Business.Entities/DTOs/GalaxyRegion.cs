using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
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

//		[DataMember]
        public String UniqueId { get { return RegionId; } }

		[DataMember]
        public String RegionId { get; set; }
        
        [DataMember]
        public String RegionName { get; set; }

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
