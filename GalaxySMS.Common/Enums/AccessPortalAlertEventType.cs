////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalAlertEventType.cs
//
// summary:	Implements the access portal alert event type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal alert event types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalAlertEventType
    { 
/// <summary>   . </summary>
        ForcedOpen = 1,
        /// <summary>   An enum constant representing the open too long option. </summary>
        OpenTooLong,
        /// <summary>   An enum constant representing the invalid access attempt option. </summary>
        InvalidAccessAttempt,
        /// <summary>   An enum constant representing the passback violation option. </summary>
        PassbackViolation,
        /// <summary>   An enum constant representing the duress option. </summary>
        Duress,
        /// <summary>   An enum constant representing the reader heartbeat option. </summary>
        ReaderHeartbeat,
        /// <summary>   An enum constant representing the access granted option. </summary>
        AccessGranted,
        /// <summary>
        /// An enum constant representing the access granted disarm input output group 1 option.
        /// </summary>
        AccessGrantedDisarmInputOutputGroup1,
        /// <summary>
        /// An enum constant representing the access granted disarm input output group 2 option.
        /// </summary>
        AccessGrantedDisarmInputOutputGroup2,
        /// <summary>
        /// An enum constant representing the access granted disarm input output group 3 option.
        /// </summary>
        AccessGrantedDisarmInputOutputGroup3,
        /// <summary>
        /// An enum constant representing the access granted disarm input output group 4 option.
        /// </summary>
        AccessGrantedDisarmInputOutputGroup4,
        /// <summary>   An enum constant representing the door group option. </summary>
        DoorGroup,
        /// <summary>   An enum constant representing the unlocked by option. </summary>
        UnlockedBy,
        /// <summary>   An enum constant representing the locked by option. </summary>
        LockedBy,
    }
}
