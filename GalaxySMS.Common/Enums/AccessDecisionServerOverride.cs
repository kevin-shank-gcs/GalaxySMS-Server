////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessDecisionServerOverride.cs
//
// summary:	Implements the access decision server override class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access decision server consultation rules. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AccessDecisionServerConsultationRule
	{
        /// <summary>   An enum constant representing the never consult server option. </summary>
		NeverConsultServer,
        /// <summary>
        /// An enum constant representing the only when valid access would be granted by panel option.
        /// </summary>
		OnlyWhenValidAccessWouldBeGrantedByPanel,
        /// <summary>
        /// An enum constant representing the only when access would be denied by panel option.
        /// </summary>
		OnlyWhenAccessWouldBeDeniedByPanel,
        /// <summary>   An enum constant representing the always consult server option. </summary>
		AlwaysConsultServer
	}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Values that represent access decision server fails to respond timeout behaviors.
    /// </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AccessDecisionServerFailsToRespondTimeoutBehavior
	{
        /// <summary>   An enum constant representing the follow panel decision option. </summary>
		FollowPanelDecision,
        /// <summary>   An enum constant representing the always deny access option. </summary>
		AlwaysDenyAccess,
        /// <summary>   An enum constant representing the always grant access option. </summary>
		AlwaysGrantAccess
	}
}
