using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelDataProcessors.Interfaces
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for panel output data processor. </summary>
    ///
    /// <remarks>   Kevin, 1/28/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CpuIdentifer
    {
        public CpuIdentifer()
        {
            ClusterGroupId = 0;
        }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int PanelNumber { get; set; }
        public short CpuNumber { get; set; }
    }

    public interface IPanelHelper
    {
        uint GetLastLogIndex(CpuIdentifer id);
    }
}
