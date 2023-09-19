////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalNoServerReplyBehaviorIds.cs
//
// summary:	Implements the access portal no server reply behavior identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal no server reply behavior identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalNoServerReplyBehaviorIds
    {
        /// <summary>   The follow panel decision. </summary>
        public static readonly Guid FollowPanelDecision = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The always deny access. </summary>
        public static readonly Guid AlwaysDenyAccess = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The always grant access. </summary>
        public static readonly Guid AlwaysGrantAccess = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
