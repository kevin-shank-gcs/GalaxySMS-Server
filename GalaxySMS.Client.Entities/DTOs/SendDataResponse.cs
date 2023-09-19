﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SendDataResponse.cs
//
// summary:	Implements the send data response class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A send data response. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SendDataResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent results. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum Result { Ok, NotOk }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse()
        {
            ResponseDateTime = DateTimeOffset.Now;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse(DateTimeOffset dt)
        {
            ResponseDateTime = dt;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The SendDataResponse to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse(SendDataResponse p) : base()
        {
            if (p != null)
            {
                ResponseDateTime = p.ResponseDateTime;
                ResultCode = p.ResultCode;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the response date time. </summary>
        ///
        /// <value> The response date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset ResponseDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the result code. </summary>
        ///
        /// <value> The result code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Result ResultCode { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A send data response. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SendDataResponse<T> : SendDataResponse where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse() : base()
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        /// <param name="p">    The SendDataResponse to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataResponse(T data, SendDataResponse p) : base(p)
        {
            Data = data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public T Data { get; set; }

    }

}
