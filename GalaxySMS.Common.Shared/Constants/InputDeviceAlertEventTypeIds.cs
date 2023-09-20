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

    public class InputDeviceAlertEventTypeIds
    {
        /// <summary>   Alarm. </summary>
        public static readonly Guid StateChange = new Guid("00000000-0000-0000-0000-000000000001");
    }
}
