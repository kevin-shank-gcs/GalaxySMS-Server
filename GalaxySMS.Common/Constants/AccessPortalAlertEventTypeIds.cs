////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalAlertEventTypeIds.cs
//
// summary:	Implements the access portal alert event type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal alert event type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalAlertEventTypeIds
    {
        /// <summary>   The forced open. </summary>
        public static readonly Guid ForcedOpen = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The open too long. </summary>
        public static readonly Guid OpenTooLong = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The invalid access attempt. </summary>
        public static readonly Guid InvalidAccessAttempt = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The passback violation. </summary>
        public static readonly Guid PassbackViolation = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The duress. </summary>
        public static readonly Guid Duress = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The reader heartbeat. </summary>
        public static readonly Guid ReaderHeartbeat = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The access granted. </summary>
        public static readonly Guid AccessGranted = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   The first access granted disarm input output group. </summary>
        public static readonly Guid AccessGrantedDisarmInputOutputGroup1 = new Guid("00000000-0000-0000-0000-000000000008");
        /// <summary>   The second access granted disarm input output group. </summary>
        public static readonly Guid AccessGrantedDisarmInputOutputGroup2 = new Guid("00000000-0000-0000-0000-000000000009");
        /// <summary>   The third access granted disarm input output group. </summary>
        public static readonly Guid AccessGrantedDisarmInputOutputGroup3 = new Guid("00000000-0000-0000-0000-00000000000a");
        /// <summary>   The fourth access granted disarm input output group. </summary>
        public static readonly Guid AccessGrantedDisarmInputOutputGroup4 = new Guid("00000000-0000-0000-0000-00000000000b");
        /// <summary>   Group the door belongs to. </summary>
        public static readonly Guid DoorGroup = new Guid("00000000-0000-0000-0000-00000000000c");
        /// <summary>   Amount to unlocked by. </summary>
        public static readonly Guid UnlockedBy = new Guid("00000000-0000-0000-0000-00000000000d");
        /// <summary>   Amount to locked by. </summary>
        public static readonly Guid LockedBy = new Guid("00000000-0000-0000-0000-00000000000e");
    }
}
