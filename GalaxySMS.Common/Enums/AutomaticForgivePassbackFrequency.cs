////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AutomaticForgivePassbackFrequency.cs
//
// summary:	Implements the automatic forgive passback frequency class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent automatic forgive passback frequencies. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AutomaticForgivePassbackFrequency
    { 
        /// <summary>   An enum constant representing the never option. </summary>
        Never,
        /// <summary>   An enum constant representing the once per day option. </summary>
        OncePerDay,
        /// <summary>   An enum constant representing the twice per day option. </summary>
        TwicePerDay,
        /// <summary>   An enum constant representing the four times per day option. </summary>
        FourTimesPerDay,
        /// <summary>   An enum constant representing the every two hours option. </summary>
        EveryTwoHours,
        /// <summary>   An enum constant representing the every hour option. </summary>
        EveryHour,
        /// <summary>   An enum constant representing the every thirty minutes option. </summary>
        EveryThirtyMinutes
    }
}
