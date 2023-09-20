////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalContactSupervisionType.cs
//
// summary:	Implements the access portal contact supervision type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal contact supervision types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AccessPortalContactSupervisionType
	{
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the series in line option. </summary>
        SeriesInLine,
        /// <summary>   An enum constant representing the parallel end of line option. </summary>
        ParallelEndOfLine,
        /// <summary>   An enum constant representing the series and parallel option. </summary>
        SeriesAndParallel
    }
}
