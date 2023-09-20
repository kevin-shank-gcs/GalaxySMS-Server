////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\InputDeviceContactStatus.cs
//
// summary:	Implements the input device contact status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent input device contact status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum InputDeviceContactStatus
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the trouble open option. </summary>
        TroubleOpen,
        /// <summary>   An enum constant representing the trouble short option. </summary>
        TroubleShort,
        /// <summary>   An enum constant representing the off option. </summary>
        Off,
        /// <summary>   An enum constant representing the on option. </summary>
        On,

        /// <summary>   An enum constant representing the armed secure option. </summary>
        ArmedSecure,

        /// <summary>   An enum constant representing the armed alarm option. </summary>
        ArmedAlarm
    }
}
