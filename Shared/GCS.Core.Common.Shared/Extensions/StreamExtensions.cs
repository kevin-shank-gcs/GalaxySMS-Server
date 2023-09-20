////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\StreamExtensions.cs
//
// summary:	Implements the stream extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A stream extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class StreamExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Stream extension method that reads to end. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="stream">   The stream to act on. </param>
        ///
        /// <returns>   to end. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ReadToEnd(this Stream stream)
        {
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Stream extension method that reads from JSON. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="stream">   The stream to act on. </param>
        ///
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T ReadFromJson<T>(this Stream stream)
        {
            var json = stream.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Stream extension method that reads from JSON. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="stream">   The stream to act on. </param>
        /// <param name="settings"></param>
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T ReadFromJson<T>(this Stream stream, JsonSerializerSettings settings)
        {
            var json = stream.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Stream extension method that reads from JSON. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="stream">       The stream to act on. </param>
        /// <param name="messageType">  Type of the message. </param>
        ///
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object ReadFromJson(this Stream stream, string messageType)
        {
            var type = Type.GetType(messageType);
            var json = stream.ReadToEnd();
            return JsonConvert.DeserializeObject(json, type);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Stream extension method that reads from JSON. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="stream">       The stream to act on. </param>
        /// <param name="messageType">  Type of the message. </param>
        /// <param name="settings"></param>
        /// <returns>   The data that was read from the JSON. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object ReadFromJson(this Stream stream, string messageType, JsonSerializerSettings settings)
        {
            var type = Type.GetType(messageType);
            var json = stream.ReadToEnd();
            return JsonConvert.DeserializeObject(json, type, settings);
        }
    }

}
