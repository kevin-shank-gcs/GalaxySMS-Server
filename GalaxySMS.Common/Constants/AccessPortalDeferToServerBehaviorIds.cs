////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalDeferToServerBehaviorIds.cs
//
// summary:	Implements the access portal defer to server behavior identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal defer to server behavior identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalDeferToServerBehaviorIds
    {
        /// <summary>   The never. </summary>
        public static readonly Guid Never = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The always. </summary>
        public static readonly Guid Always = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The when panel would deny access. </summary>
        public static readonly Guid WhenPanelWouldDenyAccess = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The when panel would grant access. </summary>
        public static readonly Guid WhenPanelWouldGrantAccess = new Guid("00000000-0000-0000-0000-000000000004");
    }
}
