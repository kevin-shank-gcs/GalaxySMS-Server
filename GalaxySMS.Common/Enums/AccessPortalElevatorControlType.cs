////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalElevatorControlType.cs
//
// summary:	Implements the access portal elevator control type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal elevator control types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AccessPortalElevatorControlType
	{
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the galaxy elevator control relays option. </summary>
        GalaxyElevatorControlRelays,
        /// <summary>   An enum constant representing the otis compass option. </summary>
        OtisCompass,
        /// <summary>   An enum constant representing the kone eli option. </summary>
        KoneEli
    }
}
