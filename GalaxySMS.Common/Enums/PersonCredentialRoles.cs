////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonCredentialRoles.cs
//
// summary:	Implements the person credential roles class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person credential roles. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonCredentialRoles
    {
        /// <summary>   An enum constant representing the access control option. </summary>
        AccessControl = 0,
        /// <summary>   An enum constant representing the alarm control option. </summary>
        AlarmControl = 1,
    }
}
