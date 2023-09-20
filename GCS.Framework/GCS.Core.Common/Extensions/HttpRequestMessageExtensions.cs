////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\HttpRequestMessageExtensions.cs
//
// summary:	Implements the HTTP request message extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A HTTP request message extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class HttpRequestMessageExtensions
    {
        /// <summary>   Context for the HTTP. </summary>
        private const string HttpContext = "MS_HttpContext";
        /// <summary>   Message describing the remote endpoint. </summary>
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpRequestMessage extension method that gets client IP address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request to act on. </param>
        ///
        /// <returns>   The client IP address. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            return null;
        }
    }

}
