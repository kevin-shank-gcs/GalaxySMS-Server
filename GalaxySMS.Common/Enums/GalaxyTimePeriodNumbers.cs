////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyTimePeriodNumbers.cs
//
// summary:	Implements the galaxy time period numbers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy time period numbers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyTimePeriodNumbers : short
    {
        /// <summary>   An enum constant representing the time period never option. </summary>
        TimePeriodNever = 0,
        /// <summary>   An enum constant representing the time period always option. </summary>
        TimePeriodAlways = 255
    }
}
