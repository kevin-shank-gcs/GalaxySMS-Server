////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInterfaceBoardLimits.cs
//
// summary:	Implements the galaxy interface board limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy interface board limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardLimits
    {
        /// <summary>   The lowest definable board number. </summary>
        public const short LowestDefinableBoardNumber = 1;
        /// <summary>   The highest definable board number. </summary>
        public const short HighestDefinableBoardNumber = 16;
        /// <summary>   The maximum interface boards per panel. </summary>
        public const short MaximumInterfaceBoardsPerPanel = 16;
    }
}
