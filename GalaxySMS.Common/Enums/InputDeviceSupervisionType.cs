////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\InputDeviceSupervisionType.cs
//
// summary:	Implements the input device supervision type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent input device supervision types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum InputDeviceSupervisionType
	{
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the series in line 1000 option. </summary>
        SeriesInLine1000,
        /// <summary>   An enum constant representing the series in line 2000 option. </summary>
        SeriesInLine2000,
        /// <summary>   An enum constant representing the series in line 2200 option. </summary>
        SeriesInLine2200,
        /// <summary>   An enum constant representing the series in line 4700 option. </summary>
        SeriesInLine4700,
        /// <summary>   An enum constant representing the parallel end of line 1000 option. </summary>
        ParallelEndOfLine1000,
        /// <summary>   An enum constant representing the parallel end of line 2000 option. </summary>
        ParallelEndOfLine2000,
        /// <summary>   An enum constant representing the parallel end of line 2200 option. </summary>
        ParallelEndOfLine2200,
        /// <summary>   An enum constant representing the parallel end of line 4700 option. </summary>
        ParallelEndOfLine4700,
        /// <summary>   An enum constant representing the series and parallel 1000 option. </summary>
        SeriesAndParallel1000,
        /// <summary>   An enum constant representing the series and parallel 2000 option. </summary>
        SeriesAndParallel2000,
        /// <summary>   An enum constant representing the series and parallel 2200 option. </summary>
        SeriesAndParallel2200,
        /// <summary>   An enum constant representing the series and parallel 4700 option. </summary>
        SeriesAndParallel4700,
        /// <summary>   An enum constant representing the series in line option. </summary>
        SeriesInLine,
        /// <summary>   An enum constant representing the parallel end of line option. </summary>
        ParallelEndOfLine,
        /// <summary>   An enum constant representing the series and parallel option. </summary>
        SeriesAndParallel
    }
}
