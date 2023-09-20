////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\DataEditMode.cs
//
// summary:	Implements the data edit mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.UI.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent data edit modes. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum DataEditMode
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the add new option. </summary>
        AddNew,
        /// <summary>   An enum constant representing the edit option. </summary>
        Edit
    }
}
