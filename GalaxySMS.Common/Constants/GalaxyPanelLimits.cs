////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyPanelLimits.cs
//
// summary:	Implements the galaxy panel limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy panel limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPanelLimits
    {
        /// <summary>   The lowest definable panel number. </summary>
        public const int LowestDefinablePanelNumber = 1;
        /// <summary>   The highest definable panel number. </summary>
        public const int HighestDefinablePanelNumber = 65534;
        /// <summary>   The maximum panels per cluster. </summary>
        public const int MaximumPanelsPerCluster = 65533;
    }
}
