////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ApiLogHandler.cs
//
// summary:	Implements the API log handler class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Routing;
using GCS.Core.Common.Logger;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace GCS.Core.Common.WebApi.MessageHandlers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An API log handler. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApiLogHandler : DelegatingHandler
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">              The HTTP request message to send to the server. </param>
        /// <param name="cancellationToken">    A cancellation token to cancel operation. </param>
        ///
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the
        /// asynchronous operation.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiLogEntry = CreateApiLogEntryWithRequestData(request);
            if (request.Content != null)
            {
                await request.Content.ReadAsStringAsync()
                    .ContinueWith(task =>
                    {
                        apiLogEntry.RequestContentBody = task.Result;
                    }, cancellationToken);
            }

            return await base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;

                    // Update the API log entry with response info
                    apiLogEntry.ResponseStatusCode = (int)response.StatusCode;
                    apiLogEntry.ResponseTimestamp = DateTimeOffset.Now;

                    if (response.Content != null)
                    {
                        apiLogEntry.ResponseContentBody = response.Content.ReadAsStringAsync().Result;
                        apiLogEntry.ResponseContentType = response.Content.Headers.ContentType.MediaType;
                        apiLogEntry.ResponseHeaders = SerializeHeaders(response.Content.Headers);
                    }

                    //var s = apiLogEntry.ToJsonString();
                    var s = apiLogEntry.ToXmlString();
                    this.Log().Debug(s);    // USED TO BE INFO.
                    //System.Diagnostics.Trace.WriteLine(xml);
                    // TODO: Save the API log entry to the database

                    return response;
                }, cancellationToken);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates API log entry with request data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  The request. </param>
        ///
        /// <returns>   The new API log entry with request data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private ApiLogEntry CreateApiLogEntryWithRequestData(HttpRequestMessage request)
        {
            string HttpContext = "MS_HttpContext";
            string RemoteEndpointMessage = RemoteEndpointMessageProperty.Name;
            string OwinContext = "MS_OwinContext";

            var ale = new ApiLogEntry();
            ale.Application = GCS.Framework.Utilities.SystemUtilities.MyProcessName;
            ale.RequestMethod = request.Method.Method;
            ale.RequestHeaders = SerializeHeaders(request.Headers);
            ale.Machine = Environment.MachineName;
            ale.RequestTimestamp = DateTimeOffset.Now;
            ale.RequestUri = request.RequestUri.ToString();

            var routeData = request.GetRouteData();
            if (routeData != null)
            {
                ale.RequestRouteTemplate = routeData.Route.RouteTemplate;
                ale.RequestRouteData = SerializeRouteData(routeData);
            }
            // Self-hosting using Owin
            if (request.Properties.ContainsKey(OwinContext))
            {
                OwinContext owinContext = (OwinContext)request.Properties[OwinContext];
                if (owinContext != null)
                {
                    ale.RequestIpAddress = owinContext.Request.RemoteIpAddress;
                    ale.RequestContentType = owinContext.Request.ContentType;
                    if (owinContext.Request.User != null)
                        ale.User = owinContext.Request.User.Identity.Name;
                    return ale;
                }
            }
            // Web-hosting
            else if (request.Properties.ContainsKey(HttpContext))
            {
                var context = ((HttpContextBase)request.Properties[HttpContext]);

                return new ApiLogEntry
                {
                    Application = "[insert-calling-app-here]",
                    User = context.User.Identity.Name,
                    Machine = Environment.MachineName,
                    RequestContentType = context.Request.ContentType,
                    RequestRouteTemplate = routeData.Route.RouteTemplate,
                    RequestRouteData = SerializeRouteData(routeData),
                    RequestIpAddress = context.Request.UserHostAddress,
                    RequestMethod = request.Method.Method,
                    RequestHeaders = SerializeHeaders(request.Headers),
                    RequestTimestamp = DateTimeOffset.Now,
                    RequestUri = request.RequestUri.ToString()
                };
            }
            // Self-hosting
            else if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                var remote = request.Properties[RemoteEndpointMessage] as RemoteEndpointMessageProperty;

                if (remote != null)
                {
                    var ip = remote.Address;
                    return new ApiLogEntry
                    {
                        //Application = "[insert-calling-app-here]",
                        //User = context.User.Identity.Name,
                        //Machine = Environment.MachineName,
                        //RequestContentType = context.Request.ContentType,
                        //RequestRouteTemplate = routeData.Route.RouteTemplate,
                        //RequestRouteData = SerializeRouteData(routeData),
                        //RequestIpAddress = remote.Address,
                        //RequestMethod = request.Method.Method,
                        //RequestHeaders = SerializeHeaders(request.Headers),
                        //RequestTimestamp = DateTimeOffset.Now,
                        //RequestUri = request.RequestUri.ToString()
                    };
                }
            }
            return new ApiLogEntry
            {
                Application = "[insert-calling-app-here]",
            };

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serialize route data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="routeData">    Information describing the route. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string SerializeRouteData(IHttpRouteData routeData)
        {
            return JsonConvert.SerializeObject(routeData, Formatting.Indented);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serialize headers. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="headers">  The headers. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string SerializeHeaders(HttpHeaders headers)
        {
            var dict = new Dictionary<string, string>();

            foreach (var item in headers.ToList())
            {
                if (item.Value != null)
                {
                    var header = String.Empty;
                    foreach (var value in item.Value)
                    {
                        header += value + " ";
                    }

                    // Trim the trailing space and add item to the dictionary
                    header = header.TrimEnd(" ".ToCharArray());
                    dict.Add(item.Key, header);
                }
            }

            return JsonConvert.SerializeObject(dict, Formatting.Indented);
        }
    }

}
