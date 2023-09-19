////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PinRequiredMode.cs
//
// summary:	Implements the pin required mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent pin required modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PinRequiredMode
    { 
        /// <summary>   An enum constant representing the required for access decision option. </summary>
        RequiredForAccessDecision = 1,
        /// <summary>   An enum constant representing the informational only option. </summary>
        InformationalOnly,
        /// <summary>   An enum constant representing the specifies reclose time option. </summary>
        SpecifiesRecloseTime
    }
}
