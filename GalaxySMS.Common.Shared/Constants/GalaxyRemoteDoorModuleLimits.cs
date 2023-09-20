////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyRemoteDoorModuleLimits.cs
//
// summary:	Implements the galaxy remote door module limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy remote door module limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyRemoteDoorModuleLimits
    {
        /// <summary>   The lowest definable door number. </summary>
        public const short LowestDefinableDoorNumber = 1;
        /// <summary>   The highest definable door number. </summary>
        public const short HighestDefinableDoorNumber = 16;
        /// <summary>   The maximum doors per channel. </summary>
        public const short MaximumDoorsPerChannel = 16;
    }
}
