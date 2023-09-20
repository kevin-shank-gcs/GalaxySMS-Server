////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\KoneElevatorManagerBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the kone elevator manager board interface section mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A kone elevator manager board interface section mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class KoneElevatorManagerBoardInterfaceSectionModeIds
    {
        /// <summary>   The kone elevator manager section mode kei. </summary>
        public static readonly Guid KoneElevatorManagerSectionMode_KEI = new Guid("2D934E44-74B1-4B45-8DF3-F7D5AFB094C4");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the values. </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(KoneElevatorManagerSectionMode_KEI);
                return r;
            }
        }
    }

}
