////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyRemoteRelayModuleLimits.cs
//
// summary:	Implements the galaxy remote relay module limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy remote relay module limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyRemoteRelayModuleLimits
    {
        /// <summary>   The lowest definable relay number. </summary>
        public const short LowestDefinableRelayNumber = 1;
        /// <summary>   The highest definable relay number. </summary>
        public const short HighestDefinableRelayNumber = 24;
        /// <summary>   The maximum relays per channel. </summary>
        public const short MaximumRelaysPerChannel = 24;
    }
}
