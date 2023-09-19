////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInputDelayTypeIds.cs
//
// summary:	Implements the galaxy input delay type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy input delay type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInputDelayTypeIds
    {
        /// <summary>   The entry. </summary>
        public static readonly Guid Entry = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The dwell. </summary>
        public static readonly Guid Dwell = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
