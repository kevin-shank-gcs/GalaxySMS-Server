////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CrisisModeState.cs
//
// summary:	Implements the crisis mode state class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent crisis mode states. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum CrisisModeState
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown,
        /// <summary>   An enum constant representing the inactive option. </summary>
		Inactive,
        /// <summary>   An enum constant representing the active option. </summary>
		Active
	}
}
