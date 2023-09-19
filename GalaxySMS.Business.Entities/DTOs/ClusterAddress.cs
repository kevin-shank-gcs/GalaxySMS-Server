using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class ClusterAddress: EntityBase
	{
		public ClusterAddress()
		{
            Region = new GalaxyRegion();
            Site = new GalaxySite();
            ClusterGroupId = 0;
		}

		public ClusterAddress(Int32 clusterId)
		{
			ClusterNumber = clusterId;
            Region = new GalaxyRegion();
            Site = new GalaxySite();
            ClusterGroupId = 0;
        }

        public ClusterAddress(Int32 clusterId, string accountCode)
        {
            ClusterNumber = clusterId;
            Region = new GalaxyRegion();
            Site = new GalaxySite();
            ClusterGroupId = accountCode;
        }

        public ClusterAddress(ClusterAddress o)
		{
            ClusterNumber = o.ClusterNumber;
            Region = o.Region;
            Site = o.Site;
            ClusterGroupId = o.ClusterGroupId;
            ClusterUid = o.ClusterUid;
        }

//		[DataMember]
		public String UniqueId { get { return string.Format("{0}:{1:D5}", ClusterGroupId, ClusterNumber); } }

	    [DataMember]
	    public Guid ClusterUid { get; set; }

        [DataMember]
        public Int32 ClusterNumber { get; set; }

        [DataMember]
        public int ClusterGroupId { get; set; }

        [DataMember]
        public GalaxyRegion Region { get; set; }

        [DataMember]
        public GalaxySite Site { get; set; }
        public override string ToString()
		{
			return UniqueId;
		}
	}
}
