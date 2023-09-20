////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\ReaderInterfaceSectionMode.cs
//
// summary:	Implements the reader interface section mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent reader interface section modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum ReaderInterfaceSectionMode
    {
        /// <summary>   An enum constant representing the unused option. </summary>
        Unused,
        /// <summary>   An enum constant representing the access portal option. </summary>
        AccessPortal,
        /// <summary>   An enum constant representing the credential reader only option. </summary>
        CredentialReaderOnly
    }
}
