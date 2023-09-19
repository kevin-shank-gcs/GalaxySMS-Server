////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\ActivityLoggingEnabledState.cs
//
// summary:	Implements the activity logging enabled state class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent activity logging enabled states. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum ActivityLoggingEnabledState
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown,
        /// <summary>   An enum constant representing the activity logging not enabled option. </summary>
		ActivityLoggingNotEnabled,
        /// <summary>   An enum constant representing the activity logging enabled option. </summary>
		ActivityLoggingEnabled		
	}
}
