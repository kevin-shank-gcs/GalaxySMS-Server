////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\TimePeriodType.cs
//
// summary:	Implements the time period type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent time period types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum TimePeriodType
    {
        /// <summary>   An enum constant representing the galaxy fifteen minute interval option. </summary>
        GalaxyFifteenMinuteInterval,
        /// <summary>   An enum constant representing the galaxy one minute interval option. </summary>
        GalaxyOneMinuteInterval,
        /// <summary>   An enum constant representing the assa abloy dsr option. </summary>
        AssaAbloyDsr
    }
}
