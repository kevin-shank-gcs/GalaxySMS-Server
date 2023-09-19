////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	WebApiClientBase.cs
//
// summary:	Implements the web API client base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GCS.Core.Common.WebApi
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A web API client base. </summary>
    ///
    /// <remarks>   Kevin, 4/23/2015. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class WebApiClientBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WebApiClientBase()
        {
            DefaultWebServiceCallProperties = new WebServiceCallProperties();
            DefaultWebServiceCallProperties.ContentType = ContentType.Json;
            DefaultWebServiceCallProperties.ServerUrl = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ///
        /// <param name="serverUrl">    URL of the server. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WebApiClientBase(string serverUrl)
        {
            DefaultWebServiceCallProperties = new WebServiceCallProperties();
            DefaultWebServiceCallProperties.ContentType = ContentType.Json;
            DefaultWebServiceCallProperties.ServerUrl = serverUrl;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ///
        /// <param name="serverUrl">    URL of the server. </param>
        /// <param name="contentType">  Type of the content. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WebApiClientBase(string serverUrl, ContentType contentType)
        {
            DefaultWebServiceCallProperties = new WebServiceCallProperties();
            DefaultWebServiceCallProperties.ContentType = contentType;
            DefaultWebServiceCallProperties.ServerUrl = serverUrl;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the default web service call properties. </summary>
        ///
        /// <value> The default web service call properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WebServiceCallProperties DefaultWebServiceCallProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the upload data task asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <typeparam name="TU">   Type of the tu. </typeparam>
        /// <param name="uploadData">       Information describing the upload. </param>
        /// <param name="callProperties">   The call properties. </param>
        ///
        /// <returns>   A Task&lt;TU&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected internal async Task<TU> DoUploadDataTaskAsync<T, TU>(T uploadData,
            WebServiceCallProperties callProperties)
        {
            if (callProperties == null)
                callProperties = DefaultWebServiceCallProperties;

            WebClient proxy = new WebClient();
            MemoryStream mem = new MemoryStream();

            switch (callProperties.ContentType)
            {
                case ContentType.Json:
                    var jSer = new DataContractJsonSerializer(uploadData.GetType());
                    jSer.WriteObject(mem, uploadData);
                    proxy.Headers["Content-type"] = ContentTypeStrings.ContentType_ApplicationJson;
                    break;

                case ContentType.Xml:
                    var ser = new DataContractSerializer(uploadData.GetType());
                    ser.WriteObject(mem, uploadData);
                    proxy.Headers["Content-type"] = ContentTypeStrings.ContentType_ApplicationXml;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if( !callProperties.ServerUrl.EndsWith("/") && !callProperties.UrlSuffix.StartsWith("/") )
                callProperties.ServerUrl += "/";

            string url = string.Format("{0}{1}", callProperties.ServerUrl, callProperties.UrlSuffix);

            byte[] data = await proxy.UploadDataTaskAsync(new Uri(url), "POST", mem.ToArray());
            Stream replyStream = new MemoryStream(data);

            TU returnData; // = Activator.CreateInstance<TU>();
            switch (callProperties.ContentType)
            {
                case ContentType.Json:
                    var jSer = new DataContractJsonSerializer(typeof(TU));
                    returnData = (TU)jSer.ReadObject(replyStream);
                    break;

                case ContentType.Xml:
                    var ser = new DataContractSerializer(typeof(TU));
                    returnData = (TU)ser.ReadObject(replyStream);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return returnData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the download data task asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="callProperties">   The call properties. </param>
        ///
        /// <returns>   A Task&lt;T&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected internal async Task<T> DoDownloadDataTaskAsync<T>(WebServiceCallProperties callProperties)
        {
            if (callProperties == null)
                callProperties = DefaultWebServiceCallProperties;

            var proxy = new WebClient();
            switch (callProperties.ContentType)
            {
                case ContentType.Json:
                    proxy.Headers["Content-type"] = ContentTypeStrings.ContentType_ApplicationJson;
                    break;

                case ContentType.Xml:
                    proxy.Headers["Content-type"] = ContentTypeStrings.ContentType_ApplicationXml;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            proxy.Encoding = Encoding.Unicode;

            if( !callProperties.ServerUrl.EndsWith("/") && !callProperties.UrlSuffix.StartsWith("/") )
                callProperties.ServerUrl += "/";

            string url = string.Format("{0}{1}", callProperties.ServerUrl, callProperties.UrlSuffix);

            byte[] data = await proxy.DownloadDataTaskAsync(new Uri(url));

            Stream replyStream = new MemoryStream(data);

            T returnData; // = Activator.CreateInstance<T>();
            switch (callProperties.ContentType)
            {
                case ContentType.Json:
                    var jSer = new DataContractJsonSerializer(typeof(T));
                    returnData = (T)jSer.ReadObject(replyStream);
                    break;

                case ContentType.Xml:
                    var ser = new DataContractSerializer(typeof(T));
                    returnData = (T)ser.ReadObject(replyStream);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return returnData;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/23/2015. </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="callProperties">   The call properties. </param>
        ///
        /// <returns>   The asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected internal async Task<T> GetAsync<T>(WebServiceCallProperties callProperties) where T : new()
        {
            if (callProperties == null)
                callProperties = DefaultWebServiceCallProperties;

            var client = new HttpClient();
            client.BaseAddress = new Uri(callProperties.ServerUrl);
            switch (callProperties.ContentType)
            {
                case ContentType.Json:
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(ContentTypeStrings.ContentType_ApplicationJson));
                    break;

                case ContentType.Xml:
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(ContentTypeStrings.ContentType_ApplicationXml));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            //var task = client.GetAsync(callProperties.UrlSuffix).
            //    ContinueWith((taskwithresponse) =>
            //    {
            //        var response = taskwithresponse.Result;
            //        response.EnsureSuccessStatusCode();
            //        var readtask = response.Content.ReadAsAsync<T>();
            //        readtask.Wait();
            //        ret = readtask.Result;
            //    });
            //task.Wait();
            HttpResponseMessage response = client.GetAsync(callProperties.UrlSuffix).Result;

            if (response.IsSuccessStatusCode)
            {
                T ret = await response.Content.ReadAsAsync<T>();
                return ret;
            }
            return new T();
        }
        //#elif NET35  
        //#elif NET20
        //#endif  

    }
}