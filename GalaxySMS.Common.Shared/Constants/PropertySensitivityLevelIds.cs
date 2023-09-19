////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PropertySensitivityLevelIds.cs
//
// summary:	Implements the property sensitivity level identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A property sensitivity level identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PropertySensitivityLevelIds
    {
        /// <summary>   The public. </summary>
        public static readonly Guid Public = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The confidential. </summary>
        public static readonly Guid Confidential = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
