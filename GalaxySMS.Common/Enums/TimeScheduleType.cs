////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\TimeScheduleType.cs
//
// summary:	Implements the time schedule type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent time schedule types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum TimeScheduleType
    {
        /// <summary>   An enum constant representing the galaxy fifteen minute interval option. </summary>
        GalaxyFifteenMinuteInterval,
        /// <summary>   An enum constant representing the galaxy one minute interval option. </summary>
        GalaxyOneMinuteInterval,
        /// <summary>   An enum constant representing the assa abloy dsr option. </summary>
        AssaAbloyDsr
    }
}
