////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalLockPushButtonBehaviorIds.cs
//
// summary:	Implements the access portal lock push button behavior identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal lock push button behavior identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalLockPushButtonBehaviorIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The privacy. </summary>
        public static readonly Guid Privacy = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The office. </summary>
        public static readonly Guid Office = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
