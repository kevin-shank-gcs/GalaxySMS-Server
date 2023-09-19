////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CredentialReaderStatus.cs
//
// summary:	Implements the credential reader status class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent credential reader status. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum CredentialReaderStatus
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
        Unknown,
        /// <summary>   An enum constant representing the ready to read option. </summary>
        ReadyToRead,
        /// <summary>   An enum constant representing the reading option. </summary>
        Reading,
        /// <summary>   An enum constant representing the reading disabled option. </summary>
        ReadingDisabled
    }
}
