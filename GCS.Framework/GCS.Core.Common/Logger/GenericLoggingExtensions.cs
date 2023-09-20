////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\GenericLoggingExtensions.cs
//
// summary:	Implements the generic logging extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GCS.Core.Common.Contracts;
using log4net;

namespace GCS.Core.Common.Logger
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A generic logging extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class GenericLoggingExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that logs the given thing. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="thing">    The thing to act on. </param>
        ///
        /// <returns>   An ILogger. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ILogger Log<T>(this T thing)
        {
            var log = LogManager.GetLogger<T>();
            return log;
        }
    }
}
