using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
	public class ClusterAddressReq
	{
		public ClusterAddressReq()
		{
            ClusterGroupId = 0;
		}

		public ClusterAddressReq(Int32 clusterId)
		{
			ClusterNumber = clusterId;
            ClusterGroupId = 0;
        }

        public ClusterAddressReq(Int32 clusterId, int clusterGroupId)
        {
            ClusterNumber = clusterId;
            ClusterGroupId = clusterGroupId;
        }

        public ClusterAddressReq(ClusterAddressReq o)
		{
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }

        public Guid ClusterUid { get; set; }

        [Required]
        [Range(1, 65534)]
        public Int32 ClusterNumber { get; set; }
        
        [Required]
        [Range(0, 65535)]
        public int ClusterGroupId { get; set; }

	}
}
