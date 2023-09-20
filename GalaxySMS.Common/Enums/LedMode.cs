////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\LedMode.cs
//
// summary:	Implements the LED mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent LED modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum LedMode
	{
        /// <summary>   An enum constant representing all off option. </summary>
		AllOff = 0,
        /// <summary>   An enum constant representing the green only solid option. </summary>
		GreenOnlySolid = 1,
        /// <summary>   An enum constant representing the red only solid option. </summary>
		RedOnlySolid = 2,
        /// <summary>   An enum constant representing the both solid option. </summary>
		BothSolid = 3,
        /// <summary>   An enum constant representing the green blink 6 times per second option. </summary>
		GreenBlink6TimesPerSecond = 4,
        /// <summary>   An enum constant representing the green blink 12 times per second option. </summary>
		GreenBlink12TimesPerSecond = 5,
        /// <summary>   An enum constant representing the both blink 12 times per second option. </summary>
		BothBlink12TimesPerSecond = 6,
        /// <summary>   An enum constant representing the red blink 2 times per second option. </summary>
		RedBlink2TimesPerSecond = 7
	}

}
