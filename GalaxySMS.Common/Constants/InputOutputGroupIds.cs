////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\InputOutputGroupIds.cs
//
// summary:	Implements the input output group identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputOutputGroupIds
    {
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputOutputGroupLimits
    {
        /// <summary>   The none. </summary>
        public const int None = 0;
        /// <summary>   The lowest definable number. </summary>
        public const int LowestDefinableNumber = 1;
        /// <summary>   The highest number. </summary>
        public const int HighestNumber = 255;
        /// <summary>   Number of maximums. </summary>
        public const int MaximumCount = 256;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group offset limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputOutputGroupOffsetLimits
    {
        /// <summary>   The none. </summary>
        public const short None = 0;
        /// <summary>   The minimum. </summary>
        public const short Minimum = 1;
        /// <summary>   The maximum. </summary>
        public const short Maximum = 32;
        /// <summary>   The default tag. </summary>
        public const string DefaultTag = "*";
    }

}
