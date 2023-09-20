////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CredentialParityType.cs
//
// summary:	Implements the credential parity type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent credential parity types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum CredentialParityTypes : short
    {
        /// <summary>   An enum constant representing the even option. </summary>
        Even = 1,
        /// <summary>   An enum constant representing the odd option. </summary>
        Odd = 2
    }
}
