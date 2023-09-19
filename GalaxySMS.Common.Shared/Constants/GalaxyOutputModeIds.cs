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

    public class GalaxyOutputModeIds
    {
        public static readonly Guid Follows = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid Latching = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid Scheduled = new Guid("00000000-0000-0000-0000-000000000003");
        public static readonly Guid TimeoutRetriggerable = new Guid("00000000-0000-0000-0000-000000000004");
        public static readonly Guid Timeout = new Guid("00000000-0000-0000-0000-000000000005");
        public static readonly Guid Limit = new Guid("00000000-0000-0000-0000-000000000006");
        public static readonly Guid Counter = new Guid("00000000-0000-0000-0000-000000000007");
    }
}
