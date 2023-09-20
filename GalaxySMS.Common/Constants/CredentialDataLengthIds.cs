////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CredentialDataLengthIds.cs
//
// summary:	Implements the credential data length identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential data length identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialDataLengthIds
    {
        /// <summary>   The standard 48 bits. </summary>
        public static readonly Guid Standard48Bits = new Guid("00000000-0000-0000-0000-000000000030");
        /// <summary>   The extended 256 bits. </summary>
        public static readonly Guid Extended256Bits = new Guid("00000000-0000-0000-0000-000000000100");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential data byte array length. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class CredentialDataByteArrayLength
    {
        /// <summary>   The standard 48 bit. </summary>
        public const int Standard48Bit = 48/8;
        /// <summary>   The extended 256 bits. </summary>
        public const int Extended256Bits = 256/8;

    }
}
