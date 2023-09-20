////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalNoServerReplyBehavior.cs
//
// summary:	Implements the access portal no server reply behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal no server reply behaviors. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalNoServerReplyBehavior
    { 
        /// <summary>   An enum constant representing the follow panel decision option. </summary>
        FollowPanelDecision = 0,
        /// <summary>   An enum constant representing the always grant access option. </summary>
        AlwaysGrantAccess = 4,
        /// <summary>   An enum constant representing the always deny access option. </summary>
        AlwaysDenyAccess = 8
    }
}
