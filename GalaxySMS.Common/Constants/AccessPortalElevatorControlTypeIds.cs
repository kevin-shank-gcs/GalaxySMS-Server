////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalElevatorControlTypeIds.cs
//
// summary:	Implements the access portal elevator control type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal elevator control type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalElevatorControlTypeIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The galaxy elevator control relays. </summary>
        public static readonly Guid GalaxyElevatorControlRelays = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The otis compass. </summary>
        public static readonly Guid OtisCompass = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The kone eli. </summary>
        public static readonly Guid KoneEli = new Guid("00000000-0000-0000-0000-000000000004");
    }
}
