////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInputModeIds.cs
//
// summary:	Implements the galaxy input mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy input mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInputModeIds
    {
        /// <summary>   The standard. </summary>
        public static readonly Guid Standard = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The arming. </summary>
        public static readonly Guid Arming = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
