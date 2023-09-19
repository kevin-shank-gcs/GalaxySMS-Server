////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalCommandActionCode.cs
//
// summary:	Implements the access portal command action code class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{

    /// <summary>   Values that represent access portal command action codes. </summary>
    public enum AccessPortalCommandActionCode
    {
        None,/// <summary>
        /// None
        /// </summary>
        Pulse, /// <summary>
        /// Pulse (Momentary Unlock)
        /// </summary>
        Unlock, /// <summary>
        /// Unlock
        /// </summary>
        Lock, /// <summary>
        /// Lock
        /// </summary>
        Enable, /// <summary>
        /// Enable
        /// </summary>
        Disable, /// <summary>
        /// Disable
        /// </summary>
        AuxRelayOn, /// <summary>
        /// Auxiliary Output On
        /// </summary>
        AuxRelayOff, /// <summary>
        /// Auxiliary Output Off
        /// </summary>
        SetLedTemporaryState, /// <summary>
        /// Set LED Temporary State
        /// </summary>
        RequestStatus
    }

}
