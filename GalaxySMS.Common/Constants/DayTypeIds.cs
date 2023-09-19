////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\DayTypeIds.cs
//
// summary:	Implements the day type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A day type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DayTypeIds
    {
        //public static readonly Guid TimeSchedule_Never = new Guid("00000000-0000-0000-0000-000000000001");
        //public static readonly Guid TimeSchedule_Always = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A day type number. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DayTypeNumber
    {
        //public static readonly ushort TimeSchedule_Never = 0;
        //public static readonly ushort TimeSchedule_Always = 255;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A day type limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DayTypeLimits
    {
        //public const int Never = 0;
        /// <summary>   The lowest definable number. </summary>
        public const int LowestDefinableNumber = 1;
        /// <summary>   The highest definable number. </summary>
        public const int HighestDefinableNumber = 100;
        //public const int Always = 255;
    }
}
