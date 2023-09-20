////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PinRequiredModeIds.cs
//
// summary:	Implements the pin required mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A pin required mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PinRequiredModeIds
    {
        /// <summary>   The required for access decision. </summary>
        public static readonly Guid RequiredForAccessDecision = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The informational only. </summary>
        public static readonly Guid InformationalOnly = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The specifies reclose time. </summary>
        public static readonly Guid SpecifiesRecloseTime = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
