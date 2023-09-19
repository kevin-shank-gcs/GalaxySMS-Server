////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyTimePeriodIds.cs
//
// summary:	Implements the galaxy time period identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy time period identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyTimePeriodIds
    {
        /// <summary>   The time period never. </summary>
        public static readonly Guid TimePeriod_Never = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The time period always. </summary>
        public static readonly Guid TimePeriod_Always = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy time period number. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyTimePeriodNumber
    {
        /// <summary>   The time period never. </summary>
        public static readonly ushort TimePeriod_Never = 0;
        /// <summary>   The time period always. </summary>
        public static readonly ushort TimePeriod_Always = 255;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy time period limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyTimePeriodLimits
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
