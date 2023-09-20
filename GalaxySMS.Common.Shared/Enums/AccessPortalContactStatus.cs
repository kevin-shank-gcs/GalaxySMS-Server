////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalContactStatus.cs
//
// summary:	Implements the access portal contact status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal contact status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalContactStatus
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the open option. </summary>
        Open,
        /// <summary>   An enum constant representing the closed option. </summary>
        Closed,
        /// <summary>   An enum constant representing the trouble open option. </summary>
        TroubleOpen,
        /// <summary>   An enum constant representing the trouble short option. </summary>
        TroubleShort,
    }
}
