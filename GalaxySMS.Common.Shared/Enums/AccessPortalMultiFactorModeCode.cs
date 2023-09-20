////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalMultiFactorModeCode.cs
//
// summary:	Implements the access portal multi factor mode code class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal multi factor mode codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalMultiFactorModeCode
    { 
        /// <summary>   An enum constant representing the single factor option. </summary>
        SingleFactor = 1,
        /// <summary>   An enum constant representing the two factor option. </summary>
        TwoFactor = 2,
        /// <summary>   An enum constant representing the three factor option. </summary>
        ThreeFactor = 3
    }
}
