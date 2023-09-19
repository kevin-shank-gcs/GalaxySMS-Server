////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\TimeScheduleTypeIds.cs
//
// summary:	Implements the time schedule type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TimeScheduleTypeIds
    {
        /// <summary>   The time schedule type galaxy legacy 15 minute interval. </summary>
        public static readonly Guid TimeScheduleType_GalaxyLegacy15MinuteInterval = new Guid("00000000-0000-0000-0000-00000000000f");
        /// <summary>   The time schedule type galaxy minute interval. </summary>
        public static readonly Guid TimeScheduleType_GalaxyMinuteInterval = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The time schedule type assa abloy dsr. </summary>
        public static readonly Guid TimeScheduleType_AssaAbloyDsr = new Guid("00000000-0000-0000-0001-000000000000");
    }
}
