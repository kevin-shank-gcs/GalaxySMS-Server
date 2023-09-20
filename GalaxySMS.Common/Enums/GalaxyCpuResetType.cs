////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyCpuResetType.cs
//
// summary:	Implements the galaxy CPU reset type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy CPU reset types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyCpuResetType
    {
        /// <summary>   An enum constant representing the simulate reset button option. </summary>
        SimulateResetButton,
        /// <summary>   An enum constant representing the force cold reset option. </summary>
        ForceColdReset
    }
}
