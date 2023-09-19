////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonLcdMessageDisplayModes.cs
//
// summary:	Implements the person LCD message display modes class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person LCD message display modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonLcdMessageDisplayModes
    {
        /// <summary>   An enum constant representing the do not display option. </summary>
        DoNotDisplay = 0,
        /// <summary>   An enum constant representing the display every time option. </summary>
        DisplayEveryTime = 1,
        /// <summary>   An enum constant representing the display for date time range option. </summary>
        DisplayForDateTimeRange = 3,
    }
}
