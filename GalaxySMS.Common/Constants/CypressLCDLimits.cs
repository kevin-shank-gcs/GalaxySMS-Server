////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CypressLCDLimits.cs
//
// summary:	Implements the cypress LCD limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The cypress LCD limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CypressLCDLimits
    {
        /// <summary>   The lowest definable display number. </summary>
        public const short LowestDefinableDisplayNumber = 1;
        /// <summary>   The highest definable display number. </summary>
        public const short HighestDefinableDisplayNumber = 16;
        /// <summary>   The maximum displays per channel. </summary>
        public const short MaximumDisplaysPerChannel = 16;
    }
}
