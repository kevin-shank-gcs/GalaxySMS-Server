////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CpuResetType.cs
//
// summary:	Implements the CPU reset type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent CPU reset types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum CpuResetType
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown,
        /// <summary>   An enum constant representing the cold reset option. </summary>
		ColdReset = 0,
        /// <summary>   An enum constant representing the warm reset option. </summary>
		WarmReset = 1
	}
}
