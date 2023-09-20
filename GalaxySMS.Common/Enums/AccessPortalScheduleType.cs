////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalScheduleType.cs
//
// summary:	Implements the access portal schedule type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal schedule types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalScheduleType
    { 
        /// <summary>   An enum constant representing the automatic unlock option. </summary>
        AutomaticUnlock = 1,
        /// <summary>   An enum constant representing the pin required option. </summary>
        PinRequired,
        /// <summary>   An enum constant representing the disable forced open option. </summary>
        DisableForcedOpen,
        /// <summary>   An enum constant representing the disable open too long option. </summary>
        DisableOpenTooLong,
        /// <summary>   An enum constant representing the crisis unlock option. </summary>
        CrisisUnlock,
        /// <summary>   An enum constant representing the auxiliary output option. </summary>
        AuxiliaryOutput,
    }
}
