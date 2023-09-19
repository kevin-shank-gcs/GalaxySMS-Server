////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\TimeScheduleTypeIds.cs
//
// summary:	Implements the time schedule type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static readonly Guid TimeScheduleType_GalaxyLegacy15MinuteInterval = new Guid("91a4e660-de07-4b07-96e5-0a10f5b28f5a");
        /// <summary>   The time schedule type galaxy minute interval. </summary>
        public static readonly Guid TimeScheduleType_GalaxyMinuteInterval = new Guid("3f442b47-9df3-475f-b787-89abc3063273");
        /// <summary>   The time schedule type assa abloy dsr. </summary>
        public static readonly Guid TimeScheduleType_AssaAbloyDsr = new Guid("a67a4264-7acd-4937-bdb8-ce1ac1c1312d");
    }
}
