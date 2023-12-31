﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ApiLogEntry.cs
//
// summary:	Implements the API log entry class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GCS.Core.Common.WebApi
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An API log entry. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApiLogEntry
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the API log entry. </summary>
        ///
        /// <value> The identifier of the API log entry. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public long ApiLogEntryId { get; set; }             // The (database) ID for the API log entry.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Application { get; set; }             // The application that made the request.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user. </summary>
        ///
        /// <value> The user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string User { get; set; }                    // The user that made the request.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the machine. </summary>
        ///
        /// <value> The machine. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Machine { get; set; }                 // The machine that made the request.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request IP address. </summary>
        ///
        /// <value> The request IP address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestIpAddress { get; set; }        // The IP address that made the request.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the request content. </summary>
        ///
        /// <value> The type of the request content. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestContentType { get; set; }      // The request content type.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request content body. </summary>
        ///
        /// <value> The request content body. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestContentBody { get; set; }      // The request content body.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URI of the request. </summary>
        ///
        /// <value> The request URI. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestUri { get; set; }              // The request URI.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request method. </summary>
        ///
        /// <value> The request method. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestMethod { get; set; }           // The request method (GET, POST, etc).

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request route template. </summary>
        ///
        /// <value> The request route template. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestRouteTemplate { get; set; }    // The request route template.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the request route. </summary>
        ///
        /// <value> Information describing the request route. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestRouteData { get; set; }        // The request route data.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request headers. </summary>
        ///
        /// <value> The request headers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RequestHeaders { get; set; }          // The request headers.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the request timestamp. </summary>
        ///
        /// <value> The request timestamp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset? RequestTimestamp { get; set; }     // The request timestamp.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the response content. </summary>
        ///
        /// <value> The type of the response content. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ResponseContentType { get; set; }     // The response content type.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response content body. </summary>
        ///
        /// <value> The response content body. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ResponseContentBody { get; set; }     // The response content body.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response status code. </summary>
        ///
        /// <value> The response status code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int? ResponseStatusCode { get; set; }        // The response status code.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response headers. </summary>
        ///
        /// <value> The response headers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ResponseHeaders { get; set; }         // The response headers.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the response timestamp. </summary>
        ///
        /// <value> The response timestamp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset? ResponseTimestamp { get; set; }    // The response timestamp.

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return RequestContentBody;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this ApiLogEntry to a JSON string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   This ApiLogEntry as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ToJsonString()
        {
            var ser = new DataContractJsonSerializer(typeof(ApiLogEntry));
            MemoryStream m = new MemoryStream();
            ser.WriteObject(m, this);
            m.Position = 0;
            string json = new StreamReader(m).ReadToEnd();
            return json;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this ApiLogEntry to an XML string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   This ApiLogEntry as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ToXmlString()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ApiLogEntry));
            MemoryStream m = new MemoryStream();
            ser.Serialize(m, this);
            m.Position = 0;
            string xml = new StreamReader(m).ReadToEnd();
            return xml;
        }
    }

}
