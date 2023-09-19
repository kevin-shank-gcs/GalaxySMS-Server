////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalCommandIds.cs
//
// summary:	Implements the access portal command identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal command identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalCommandIds
    {
        /// <summary>   The pulse. </summary>
        public static readonly Guid Pulse = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The unlock. </summary>
        public static readonly Guid Unlock = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The lock. </summary>
        public static readonly Guid Lock = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The enable. </summary>
        public static readonly Guid Enable = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The disable. </summary>
        public static readonly Guid Disable = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The auxiliary relay on. </summary>
        public static readonly Guid AuxRelayOn = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The auxiliary relay off. </summary>
        public static readonly Guid AuxRelayOff = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   State of the set LED temporary. </summary>
        public static readonly Guid SetLedTemporaryState = new Guid("00000000-0000-0000-0000-000000000008");
        /// <summary>   The request status. </summary>
        public static readonly Guid RequestStatus = new Guid("00000000-0000-0000-0000-000000000009");
    }
}
