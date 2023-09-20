////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalLockStatus.cs
//
// summary:	Implements the access portal lock status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal lock status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalLockStatus
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the locked option. </summary>
        Locked,
        /// <summary>   An enum constant representing the unlocked option. </summary>
        Unlocked,
    }
}
