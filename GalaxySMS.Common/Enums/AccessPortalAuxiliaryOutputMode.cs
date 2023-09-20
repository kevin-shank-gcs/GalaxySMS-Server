////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalAuxiliaryOutputMode.cs
//
// summary:	Implements the access portal auxiliary output mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal auxiliary output modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalAuxiliaryOutputMode
    { 
        /// <summary>   An enum constant representing the follows option. </summary>
        Follows,
        /// <summary>   An enum constant representing the timeout option. </summary>
        Timeout,
        /// <summary>   An enum constant representing the scheduled option. </summary>
        Scheduled,
        /// <summary>   An enum constant representing the latching option. </summary>
        Latching
    }
}
