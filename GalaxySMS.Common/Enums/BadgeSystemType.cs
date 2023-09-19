////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\BadgeSystemType.cs
//
// summary:	Implements the badge system type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent badge system types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum BadgeSystemType
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the Identifier producer option. </summary>
        IdProducer,
        /// <summary>   An enum constant representing the card exchange option. </summary>
        CardExchange,
    }
}
