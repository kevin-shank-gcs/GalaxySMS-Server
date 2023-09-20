////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\BiometricSystemTypeIds.cs
//
// summary:	Implements the biometric system type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A biometric system type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BiometricSystemTypeIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = Guid.Empty;
        /// <summary>   The morpho manager bio bridge. </summary>
        public static readonly Guid MorphoManagerBioBridge = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The invixium ixm web. </summary>
        public static readonly Guid InvixiumIxmWeb = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
