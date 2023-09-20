////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AreaIds.cs
//
// summary:	Implements the area identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An area identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AreaIds
    {
        /// <summary>   The area no area. </summary>
        public static readonly Guid Area_NoArea = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The area in. </summary>
        public static readonly Guid Area_In = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The area out. </summary>
        public static readonly Guid Area_Out = new Guid("00000000-0000-0000-0000-000000000003");

        /// <summary>   The area no change. </summary>
        public static readonly Guid Area_NoChange = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An area limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AreaLimits
    {
        /// <summary>   The none. </summary>
        public const int None = 0;
        /// <summary>   The lowest definable number. </summary>
        public const int LowestDefinableNumber = 1;
        /// <summary>   The no change. </summary>
        public const int NoChange = 255;
        /// <summary>   The highest number. </summary>
        public const int HighestNumber = 255;
        /// <summary>   Number of maximums. </summary>
        public const int MaximumCount = 256;
    }


}
