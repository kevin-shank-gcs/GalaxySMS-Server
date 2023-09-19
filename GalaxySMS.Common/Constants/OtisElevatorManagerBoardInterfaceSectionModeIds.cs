////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\OtisElevatorManagerBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the otis elevator manager board interface section mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The otis elevator manager board interface section mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class OtisElevatorManagerBoardInterfaceSectionModeIds
    {
        /// <summary>   The otis elevator manager section mode oei. </summary>
        public static readonly Guid OtisElevatorManagerSectionMode_OEI = new Guid("07981308-6B6F-4E8D-A3C7-554398C9E1EA");

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
                r.Add(OtisElevatorManagerSectionMode_OEI);
                return r;
            }
        }
    }

}
