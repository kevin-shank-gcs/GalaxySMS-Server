using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class GalaxyRegionResp
	{
		public GalaxyRegionResp():base()
		{
		    RegionId = string.Empty;
		    RegionName = string.Empty;
		}

		public GalaxyRegionResp(String regionId, String regionName) 
		{
			RegionId = regionId;
		    RegionName = regionName;
		}

        public GalaxyRegionResp(GalaxyRegionResp o)
		{
            RegionId = o.RegionId;
            RegionName = o.RegionName;
        }


        public String UniqueId { get { return RegionId; } }
        public String RegionId { get; set; }
        public String RegionName { get; set; }

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
