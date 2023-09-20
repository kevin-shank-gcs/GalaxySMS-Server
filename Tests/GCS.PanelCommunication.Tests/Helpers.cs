using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.PanelProtocols.Series6xx;

namespace GCS.PanelCommunication.Tests
{
    public class Helpers
    {
        public static IDataPacket6xx GetNewPacketToSend(uint sequence, int cluster, int panel, ushort cpu)
        {
            IDataPacket6xx p = new DataPacket6xx(SohCode.UInt16ClusterAndPanelIds, sequence);
            p.ClusterId = cluster;
            p.PanelId = panel;
            p.Cpu = (CpuDistribution)cpu;
            return p;
        }
    }
}
