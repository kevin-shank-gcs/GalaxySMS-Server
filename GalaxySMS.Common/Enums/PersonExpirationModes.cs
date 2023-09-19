////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonExpirationModes.cs
//
// summary:	Implements the person expiration modes class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person expiration modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonExpirationModes
    {
        /// <summary>   An enum constant representing the never expires option. </summary>
        NeverExpires = 0,
        /// <summary>   An enum constant representing the expire by date option. </summary>
        ExpireByDate = 1,
        /// <summary>   An enum constant representing the expire by usage count option. </summary>
        ExpireByUsageCount = 2,
        /// <summary>   An enum constant representing the expire by date and time option. </summary>
        ExpireByDateAndTime = 3,
    }
}
