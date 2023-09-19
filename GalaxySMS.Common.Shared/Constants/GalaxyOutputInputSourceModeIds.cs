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

    public class GalaxyOutputInputSourceModeIds
    {
        public static readonly Guid OR = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid AND = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid NOR = new Guid("00000000-0000-0000-0000-000000000003");
        public static readonly Guid NAND = new Guid("00000000-0000-0000-0000-000000000004");
    }
}
