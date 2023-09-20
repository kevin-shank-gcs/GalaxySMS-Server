////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	HttpRequestMessageExtensions.cs
//
// summary:	Implements the HTTP request message extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace GCS.Core.Common.WebApi
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HTTP request message extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class HttpRequestMessageExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpRequestMessage extension method that gets header value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request to act on. </param>
        /// <param name="name">     The name. </param>
        ///
        /// <returns>   The header value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetHeaderValue(this HttpRequestMessage request, string name)
        {
            IEnumerable<string> values;
            var found = request.Headers.TryGetValues(name, out values);
            if (found)
            {
                return values.FirstOrDefault();
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the header values in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request to act on. </param>
        /// <param name="name">     The name. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the header values in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<string> GetHeaderValues(this HttpRequestMessage request, string name)
        {
            IEnumerable<string> values;
            var found = request.Headers.TryGetValues(name, out values);
            if (found)
            {
                return values;
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpRequestMessage extension method that adds a header value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request to act on. </param>
        /// <param name="name">     The name. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddHeaderValue(this HttpRequestMessage request, string name, string value)
        {
            request.Headers.Add(name, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpRequestMessage extension method that adds a header values. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request to act on. </param>
        /// <param name="name">     The name. </param>
        /// <param name="values">   The values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddHeaderValues(this HttpRequestMessage request, string name, IEnumerable<string> values)
        {
            request.Headers.Add(name, values);
        }
        
    }
}