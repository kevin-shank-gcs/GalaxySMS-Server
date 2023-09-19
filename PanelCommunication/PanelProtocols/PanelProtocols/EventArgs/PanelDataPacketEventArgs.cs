using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.PanelProtocols.Series6xx
{
	public class PanelDataPacketEventArgs : EventArgs
	{
		public IDataPacket6xx Packet { get; internal set; }
        public int ClusterGroupId { get; set; }
		public PanelDataPacketEventArgs(ref IDataPacket6xx packet, int clusterGroupId)
		{
			Packet = packet;
            ClusterGroupId = clusterGroupId;
		}
	}
}
