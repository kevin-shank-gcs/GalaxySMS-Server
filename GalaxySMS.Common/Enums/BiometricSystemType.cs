////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\BiometricSystemType.cs
//
// summary:	Implements the biometric system type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent biometric system types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum BiometricSystemType
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the morpho manager bio bridge option. </summary>
        MorphoManagerBioBridge,
        /// <summary>   An enum constant representing the invixium ixm web option. </summary>
        InvixiumIxmWeb,
    }
}
