////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CardTourManagerBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the card tour manager board interface section mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A card tour manager board interface section mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CardTourManagerBoardInterfaceSectionModeIds
    {
        /// <summary>   The ctm section mode ctm. </summary>
        public static readonly Guid CTMSectionMode_CTM = new Guid("4BCD7E0D-153D-4FAE-968F-EE2E969FA2C6");

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
                r.Add(CTMSectionMode_CTM);
                return r;
            }
        }
    }
}
