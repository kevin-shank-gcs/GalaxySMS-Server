////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessPortalMultiFactorModeIds.cs
//
// summary:	Implements the access portal multi factor mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal multi factor mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalMultiFactorModeIds
    {
        /// <summary>   The single factor. </summary>
        public static readonly Guid SingleFactor = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The two factor. </summary>
        public static readonly Guid TwoFactor = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The three factor. </summary>
        public static readonly Guid ThreeFactor = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
