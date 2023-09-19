////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalDeferToServerBehavior.cs
//
// summary:	Implements the access portal defer to server behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal defer to server behaviors. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalDeferToServerBehavior
    { 
        /// <summary>   An enum constant representing the never option. </summary>
        Never,
        /// <summary>   An enum constant representing the when panel would deny access option. </summary>
        WhenPanelWouldDenyAccess = 64,
        /// <summary>   An enum constant representing the when panel would grant access option. </summary>
        WhenPanelWouldGrantAccess = 128,
        /// <summary>   An enum constant representing the always option. </summary>
        Always = 192,
    }
}
