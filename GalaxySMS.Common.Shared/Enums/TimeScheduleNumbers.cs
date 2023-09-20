////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\TimeScheduleNumbers.cs
//
// summary:	Implements the time schedule numbers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent time schedule numbers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum TimeScheduleNumbers : short
    {
        /// <summary>   An enum constant representing the time schedule never option. </summary>
        TimeScheduleNever = 0,
        /// <summary>   An enum constant representing the time schedule always option. </summary>
        TimeScheduleAlways = 255,
        /// <summary>   An enum constant representing the time schedule default option. </summary>
        TimeScheduleDefault = short.MaxValue
    }
}
