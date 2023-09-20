////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalStatus.cs
//
// summary:	Implements the access portal status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalStatus
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the idle option. </summary>
        Idle,
        /// <summary>   An enum constant representing the open option. </summary>
        Open,
        /// <summary>   An enum constant representing the open too long option. </summary>
        OpenTooLong,
        /// <summary>   An enum constant representing the reading card forward option. </summary>
        ReadingCardForward,
        /// <summary>   An enum constant representing the reading card reverse option. </summary>
        ReadingCardReverse,
        /// <summary>   An enum constant representing the red step option. </summary>
        RedStep,
        /// <summary>   An enum constant representing the unlock option. </summary>
        Unlock,
        /// <summary>   An enum constant representing the shunted option. </summary>
        Shunted,
        /// <summary>   An enum constant representing the scheduled option. </summary>
        Scheduled,
        /// <summary>   An enum constant representing the pin blink option. </summary>
        PinBlink,
        /// <summary>   An enum constant representing the pin option. </summary>
        Pin,
        /// <summary>   An enum constant representing the privacy mode option. </summary>
        PrivacyMode,
        /// <summary>   An enum constant representing the office mode option. </summary>
        OfficeMode,
        /// <summary>   An enum constant representing the dead option. </summary>
        Dead,
        /// <summary>   An enum constant representing the interlocked option. </summary>
        Interlocked,
        /// <summary>   An enum constant representing the alarm disarmed option. </summary>
        AlarmDisarmed,
        /// <summary>   An enum constant representing the alarm armed option. </summary>
        AlarmArmed,
        /// <summary>   An enum constant representing the delayed unlock option. </summary>
        DelayedUnlock
    }
}
