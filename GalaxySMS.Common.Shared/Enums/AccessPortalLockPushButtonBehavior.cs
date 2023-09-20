////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalLockPushButtonBehavior.cs
//
// summary:	Implements the access portal lock push button behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal lock push button behaviors. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalLockPushButtonBehavior
    { 
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the privacy option. </summary>
        Privacy = 40,
        /// <summary>   An enum constant representing the office option. </summary>
        Office = 50
    }
}
