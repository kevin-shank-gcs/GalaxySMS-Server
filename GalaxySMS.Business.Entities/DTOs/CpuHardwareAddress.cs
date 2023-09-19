using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{

	[DataContract]
	public class CpuHardwareAddress : ClusterAddress
	{
		public enum CpuNumber { None = 0, One = 1, Two = 2, Both = 3 }
		public enum SystemPanelAddress { None = 0, AllPanels = 255 }

		public CpuHardwareAddress() :base()
		{
		}

		public CpuHardwareAddress(CpuHardwareAddress o) : base(o)
		{
			if (o != null)
			{
				PanelNumber = o.PanelNumber;
				CpuId = o.CpuId;
				CpuModel = o.CpuModel;
                ClusterGroupId = o.ClusterGroupId;
                CpuUid = o.CpuUid;
                PanelUid =o.PanelUid;
            }
        }

		public CpuHardwareAddress(Int32 clusterNumber, Int32 panelNumber, Int16 cpuId, string accountCode) : base(clusterNumber)
		{
			ClusterNumber = clusterNumber;
			PanelNumber = panelNumber;
			CpuId = cpuId;
            ClusterGroupId = accountCode;
		}

//		[DataMember]
		public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }

		[DataMember]
		public Int32 PanelNumber { get; set; }

		[DataMember]
		public Int16 CpuId { get; set; }

		[DataMember]
		public CpuModel CpuModel { get; set; }

	    [DataMember]
	    public Guid CpuUid { get; set; }

        [DataMember]
	    public Guid PanelUid { get; set; }

        //		[DataMember]
        public CpuHardwareAddress CpuAddress { get { return this; } }

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
