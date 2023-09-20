////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalAuxiliaryOutputModeIds.cs
//
// summary:	Implements the access portal auxiliary output mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal auxiliary output mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalAuxiliaryOutputModeIds
    {
        /// <summary>   The follows. </summary>
        public static readonly Guid Follows = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The timeout. </summary>
        public static readonly Guid Timeout = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The scheduled. </summary>
        public static readonly Guid Scheduled = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The latching. </summary>
        public static readonly Guid Latching = new Guid("00000000-0000-0000-0000-000000000004");
    }
}
