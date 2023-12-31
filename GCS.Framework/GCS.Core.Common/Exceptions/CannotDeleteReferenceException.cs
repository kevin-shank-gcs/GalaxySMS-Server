﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Exceptions\CannotDeleteReferenceException.cs
//
// summary:	Implements the cannot delete reference exception class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Exceptions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Exception for signalling cannot delete reference errors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CannotDeleteReferenceException : ApplicationException
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CannotDeleteReferenceException(string message)
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

        public CannotDeleteReferenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
