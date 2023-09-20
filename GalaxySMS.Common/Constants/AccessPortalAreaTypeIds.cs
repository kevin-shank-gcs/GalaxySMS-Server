////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalAreaTypeIds.cs
//
// summary:	Implements the access portal area type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal area type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalAreaTypeIds
    {
        /// <summary>   from area. </summary>
        public static readonly Guid FromArea = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   to area. </summary>
        public static readonly Guid ToArea = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The whos in area. </summary>
        public static readonly Guid WhosInArea = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
