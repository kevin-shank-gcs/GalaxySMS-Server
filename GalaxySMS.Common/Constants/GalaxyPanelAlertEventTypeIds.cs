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
    /// <summary>   A galaxy panel alert event type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 3/7/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPanelAlertEventTypeIds
    {

        /// <summary>   The low battery. </summary>
        public static readonly Guid LowBattery = new Guid("00000000-0000-0000-0000-000000000001");

        /// <summary>   The AC failure. </summary>
        public static readonly Guid ACFailure = new Guid("00000000-0000-0000-0000-000000000002");

        /// <summary>   The tamper. </summary>
        public static readonly Guid Tamper = new Guid("00000000-0000-0000-0000-000000000003");

        /// <summary>   The emergency unlock. </summary>
        public static readonly Guid EmergencyUnlock = new Guid("00000000-0000-0000-0000-000000000004");
    }
}
