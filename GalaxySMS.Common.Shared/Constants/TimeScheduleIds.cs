////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\TimeScheduleIds.cs
//
// summary:	Implements the time schedule identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TimeScheduleIds
    {
        /// <summary>   The time schedule never. </summary>
        public static readonly Guid TimeSchedule_Never = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The time schedule always. </summary>
        public static readonly Guid TimeSchedule_Always = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
        //public static readonly Guid TimeSchedule_Default = new Guid("00000000-0000-0000-0000-000000000002");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule number. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TimeScheduleNumber
    {
        /// <summary>   The time schedule never. </summary>
        public static readonly ushort TimeSchedule_Never = 0;
        /// <summary>   The time schedule always. </summary>
        public static readonly ushort TimeSchedule_Always = 255;
        //public static readonly ushort TimeSchedule_Default = (ushort)short.MaxValue;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TimeScheduleLimits
    {
        /// <summary>   The never. </summary>
        public const int Never = 0;
        /// <summary>   The lowest definable number. </summary>
        public const int LowestDefinableNumber = 1;
        /// <summary>   The highest definable number. </summary>
        public const int HighestDefinableNumber = 254;
        /// <summary>   The always. </summary>
        public const int Always = 255;
    }
}
