////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AccessGroupNumber.cs
//
// summary:	Implements the access group number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access group numbers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AccessGroupNumber
    {
        /// <summary>   An enum constant representing the no access option. </summary>
        NoAccess = 0,
        /// <summary>   An enum constant representing the unlimited access option. </summary>
        UnlimitedAccess = 255,
        /// <summary>   An enum constant representing the personal group option. </summary>
        PersonalGroup = 2001
    }
}
