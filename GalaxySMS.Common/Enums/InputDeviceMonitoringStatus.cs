////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\InputDeviceMonitoringStatus.cs
//
// summary:	Implements the input device monitoring status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent input device monitoring status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum InputDeviceMonitoringStatus
	{
        /// <summary>   An enum constant representing the normal option. </summary>
        Normal,
        /// <summary>   An enum constant representing the isolated option. </summary>
        Isolated,
        /// <summary>   An enum constant representing the shunted option. </summary>
        Shunted,
        /// <summary>   An enum constant representing the entry delay option. </summary>
        EntryDelay,
        /// <summary>   An enum constant representing the dwell delay option. </summary>
        DwellDelay,
    }
}
