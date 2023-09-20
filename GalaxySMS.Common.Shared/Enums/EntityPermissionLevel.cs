////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\EntityPermissionLevel.cs
//
// summary:	Implements the entity permission level class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bit-field of flags for specifying entity permission levels. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Flags]
    public enum EntityPermissionLevel
    {
        /// <summary>   A binary constant representing the none flag. </summary>
        None,
        /// <summary>   A binary constant representing the view flag. </summary>
        View = 1,
        /// <summary>   A binary constant representing the add edit flag. </summary>
        AddEdit = 2,
        /// <summary>   A binary constant representing the delete flag. </summary>
        Delete = 4,
        /// <summary>   A binary constant representing the view edit flag. </summary>
        ViewEdit = View | AddEdit,
        /// <summary>   A binary constant representing the view edit delete flag. </summary>
        ViewEditDelete = View | AddEdit | Delete,
    }
}
