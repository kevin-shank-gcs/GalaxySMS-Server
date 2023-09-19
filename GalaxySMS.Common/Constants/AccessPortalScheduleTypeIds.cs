////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalScheduleTypeIds.cs
//
// summary:	Implements the access portal schedule type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal schedule type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalScheduleTypeIds
    {
        /// <summary>   The automatic unlock. </summary>
        public static readonly Guid AutomaticUnlock = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The pin required. </summary>
        public static readonly Guid PinRequired = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The disable forced open. </summary>
        public static readonly Guid DisableForcedOpen = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The disable open too long. </summary>
        public static readonly Guid DisableOpenTooLong = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The crisis unlock. </summary>
        public static readonly Guid CrisisUnlock = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The auxiliary output. </summary>
        public static readonly Guid AuxiliaryOutput = new Guid("00000000-0000-0000-0000-000000000006");
    }
}
