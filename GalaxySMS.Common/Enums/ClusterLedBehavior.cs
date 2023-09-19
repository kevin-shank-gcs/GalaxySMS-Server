////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\ClusterLedBehavior.cs
//
// summary:	Implements the cluster LED behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent cluster LED behaviors. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum ClusterLedBehavior
    {
        /// <summary>   An enum constant representing the steady high option. </summary>
        SteadyHigh = 0,
        /// <summary>   An enum constant representing the steady low option. </summary>
        SteadyLow = 1,
        /// <summary>   An enum constant representing the strobe option. </summary>
        Strobe = 4,
        /// <summary>   An enum constant representing the strobe rapid option. </summary>
        StrobeRapid = 5
    }
}
