////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Exceptions\AuthorizationValidationException.cs
//
// summary:	Implements the authorization validation exception class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Exceptions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Exception for signalling authorization validation errors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AuthorizationValidationException : ApplicationException
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AuthorizationValidationException(string message)
            : this(message, null)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">          The message. </param>
        /// <param name="innerException">   The inner exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AuthorizationValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
