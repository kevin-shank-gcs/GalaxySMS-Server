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

    public interface IPanelOutputDataProcessor
    {
        void ProcessData(System.Collections.Concurrent.BlockingCollection<object> queue);
        void StopProcessor();
    }
}
