////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyCpuTypeIds.cs
//
// summary:	Implements the galaxy CPU type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercSioTypeIds
    {
        public static readonly Guid Mr50_S3 = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid Mr52_S3 = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid Mr62e = new Guid("00000000-0000-0000-0000-000000000003");
        public static readonly Guid Mr16In_S3 = new Guid("00000000-0000-0000-0000-000000000004");
        public static readonly Guid Mr16Out_S3 = new Guid("00000000-0000-0000-0000-000000000005");
    }
}
