using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class ClusterAddressResp
	{
		public ClusterAddressResp()
		{
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = 0;
		}

		public ClusterAddressResp(Int32 clusterId)
		{
			ClusterNumber = clusterId;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = 0;
        }

        public ClusterAddressResp(Int32 clusterId, int clusterGroupId)
        {
            ClusterNumber = clusterId;
            //Region = new GalaxyRegion();
            //Site = new GalaxySite();
            ClusterGroupId = clusterGroupId;
        }

        public ClusterAddressResp(ClusterAddressResp o)
		{
            ClusterNumber = o.ClusterNumber;
            //Region = o.Region;
            //Site = o.Site;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }

        public String UniqueId { get { return string.Format("{0}:{1:D5}", ClusterGroupId, ClusterNumber); } }
        public Guid ClusterUid { get; set; }
        public Int32 ClusterNumber { get; set; }
        public int ClusterGroupId { get; set; }
        //public GalaxyRegion Region { get; set; }
        //public GalaxySite Site { get; set; }
        public override string ToString()
		{
			return UniqueId;
		}
	}
}
