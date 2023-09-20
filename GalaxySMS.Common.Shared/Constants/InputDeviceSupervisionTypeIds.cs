////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\InputDeviceSupervisionTypeIds.cs
//
// summary:	Implements the input device supervision type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input device supervision type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputDeviceSupervisionTypeIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The series in line 1000. </summary>
        public static readonly Guid SeriesInLine1000 = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The series in line 2000. </summary>
        public static readonly Guid SeriesInLine2000 = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The series in line 2200. </summary>
        public static readonly Guid SeriesInLine2200 = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The series in line 4700. </summary>
        public static readonly Guid SeriesInLine4700 = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The parallel end of line 1000. </summary>
        public static readonly Guid ParallelEndOfLine1000 = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The parallel end of line 2000. </summary>
        public static readonly Guid ParallelEndOfLine2000 = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   The parallel end of line 2200. </summary>
        public static readonly Guid ParallelEndOfLine2200 = new Guid("00000000-0000-0000-0000-000000000008");
        /// <summary>   The parallel end of line 4700. </summary>
        public static readonly Guid ParallelEndOfLine4700 = new Guid("00000000-0000-0000-0000-000000000009");
        /// <summary>   The series and parallel 1000. </summary>
        public static readonly Guid SeriesAndParallel1000 = new Guid("00000000-0000-0000-0000-00000000000A");
        /// <summary>   The series and parallel 2000. </summary>
        public static readonly Guid SeriesAndParallel2000 = new Guid("00000000-0000-0000-0000-00000000000B");
        /// <summary>   The series and parallel 2200. </summary>
        public static readonly Guid SeriesAndParallel2200 = new Guid("00000000-0000-0000-0000-00000000000C");
        /// <summary>   The series and parallel 4700. </summary>
        public static readonly Guid SeriesAndParallel4700 = new Guid("00000000-0000-0000-0000-00000000000D");
        /// <summary>   The series in line. </summary>
        public static readonly Guid SeriesInLine = new Guid("00000000-0000-0000-0000-00000000000E");
        /// <summary>   The parallel end of line. </summary>
        public static readonly Guid ParallelEndOfLine = new Guid("00000000-0000-0000-0000-00000000000F");
        /// <summary>   The series and parallel. </summary>
        public static readonly Guid SeriesAndParallel = new Guid("00000000-0000-0000-0000-000000000010");

    }
}
