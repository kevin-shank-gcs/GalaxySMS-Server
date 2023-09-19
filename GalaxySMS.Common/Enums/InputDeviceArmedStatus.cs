////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\InputDeviceArmedStatus.cs
//
// summary:	Implements the input device armed status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent input device armed status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum InputDeviceArmedStatus
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the armed option. </summary>
        Armed,
        /// <summary>   An enum constant representing the disarmed option. </summary>
        Disarmed,
    }
}
