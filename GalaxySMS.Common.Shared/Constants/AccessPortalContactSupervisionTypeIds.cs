////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalContactSupervisionTypeIds.cs
//
// summary:	Implements the access portal contact supervision type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal contact supervision type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalContactSupervisionTypeIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The series in line. </summary>
        public static readonly Guid SeriesInLine = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The parallel end of line. </summary>
        public static readonly Guid ParallelEndOfLine = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The series and parallel. </summary>
        public static readonly Guid SeriesAndParallel = new Guid("00000000-0000-0000-0000-000000000004");

    }
}
