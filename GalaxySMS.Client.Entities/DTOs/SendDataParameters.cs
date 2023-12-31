﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SendDataParameters.cs
//
// summary:	Implements the send data parameters class
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
    /// <summary>   Interface for send data parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ISendDataParameters
    {
        //Guid SessionId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        DateTimeOffset RequestDateTime {get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the send to address. </summary>
        ///
        /// <value> The send to address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        BoardSectionNodeHardwareAddress SendToAddress { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for send data parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ISendDataParameters<T> : ISendDataParameters where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Data { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the populate data from database. </summary>
        ///
        /// <value> True if populate data from database, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool PopulateDataFromDatabase { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A send data parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SendDataParameters: ISendDataParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ISendDataParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters(ISendDataParameters p)
        {
            Initialize();
            if( p!= null)
            {
                this.RequestDateTime = p.RequestDateTime;
                //this.SessionId = p.SessionId;
                if( p.SendToAddress != null)
                    this.SendToAddress = new BoardSectionNodeHardwareAddress(p.SendToAddress);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this SendDataParameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Initialize()
        {
            //SessionId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            SendToAddress = new BoardSectionNodeHardwareAddress();
        }

        #region Implementation of ISendDataParameters

        //[DataMember]
        //public Guid SessionId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the send to address. </summary>
        ///
        /// <value> The send to address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public BoardSectionNodeHardwareAddress SendToAddress { get; set; }

        #endregion
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A send data parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SendDataParameters<T> : SendDataParameters, ISendDataParameters<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters() : base()
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ISendDataParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters(ISendDataParameters p) : base(p)
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        /// <param name="p">    The ISendDataParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters(T data, ISendDataParameters p) : base(p)
        {
            Data = data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SendDataParameters(T data) : base()
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the populate data from database. </summary>
        ///
        /// <value> True if populate data from database, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool PopulateDataFromDatabase { get; set; }
    }

}
