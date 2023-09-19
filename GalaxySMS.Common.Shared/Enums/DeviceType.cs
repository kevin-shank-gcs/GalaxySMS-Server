////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\DeviceType.cs
//
// summary:	Implements the device type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent device types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum DeviceType
	{
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the access portal option. </summary>
		AccessPortal,
        /// <summary>   An enum constant representing the input output group option. </summary>
		InputOutputGroup,
        /// <summary>   An enum constant representing the input device option. </summary>
	    InputDevice,
        /// <summary>   An enum constant representing the output device option. </summary>
		OutputDevice,
        /// <summary>   An enum constant representing the cluster option. </summary>
        Cluster,
        /// <summary>   An enum constant representing the galaxy panel option. </summary>
        GalaxyPanel
	}
}
