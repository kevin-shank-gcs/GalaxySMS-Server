////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessPortalAreaType.cs
//
// summary:	Implements the access portal area type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access portal area types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessPortalAreaType
    { 
        /// <summary>   An enum constant representing from area option. </summary>
        FromArea = 1,
        /// <summary>   An enum constant representing to area option. </summary>
        ToArea,
        /// <summary>   An enum constant representing the whos in area option. </summary>
        WhosInArea
    }
}
