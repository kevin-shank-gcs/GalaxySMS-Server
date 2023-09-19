////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\CommandParameters.cs
//
// summary:	Implements the command parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A command parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class CommandParameters : ICommandParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICallParametersBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            BackgroundJobId = p.BackgroundJobId;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICallParametersBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            BackgroundJobId = p.BackgroundJobId;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the operation UID. </summary>
        ///
        /// <value> The operation UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid OperationUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the background job. </summary>
        ///
        /// <value> The identifier of the background job. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember] 
        public Guid BackgroundJobId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the session. </summary>
        ///
        /// <value> The identifier of the session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid SessionId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current entity identifier. </summary>
        ///
        /// <value> The identifier of the current entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current site u identifier. </summary>
        ///
        /// <value> The identifier of the current site u. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentSiteUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ApplicationId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The parameters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }

        [DataMember] 
        public bool DoNotValidateAuthorization { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A command parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class CommandParameters<T> : CommandParameters, ICommandParameters<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters() : base()
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICommandParameters&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICommandParameters&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICommandParameters&lt;T&gt; to process. </param>
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ICommandParameters&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CommandParameters(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public T Data { get; set; }
    }


    [DataContract]
    public class CommandResponse : ICommandResponse
    {
        public CommandResponse()
        {

        }

        public CommandResponse(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            //DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
        }

        public CommandResponse(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            //CurrentEntityId = p.CurrentEntityId;
            //CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            //DoNotValidateAuthorization = p.DoNotValidateAuthorization;
        }


        [DataMember]

        public Guid OperationUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid SessionId { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid CurrentEntityId { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid CurrentSiteUid { get; set; }

        [DataMember]

        public DateTimeOffset RequestDateTime { get; set; }

        [DataMember]
        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public bool DoNotValidateAuthorization { get; set; }
        [DataMember] 
        public bool IsPanelOnline { get; set; }

        [DataMember]
        public int ApproximateDuration { get; set; }
    }



    [DataContract]
    public class CommandResponse<T> : CommandResponse, ICommandResponse<T> where T : class, new()
    {
        public CommandResponse() : base()
        {
            Data = new T();
        }

        public CommandResponse(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public CommandResponse(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public CommandResponse(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public CommandResponse(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }


        [DataMember]
        public T Data { get; set; }
    }

    [DataContract]
    public class LoadDataCommandResponse<T> : CommandResponse, ICommandResponse<T> where T : class, new()
    {
        public LoadDataCommandResponse() : base()
        {
            Data = new T();
        }

        public LoadDataCommandResponse(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public LoadDataCommandResponse(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public LoadDataCommandResponse(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public LoadDataCommandResponse(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }

        [DataMember]
        public T Data { get; set; }


        [DataMember]
        public LoadDataToPanelNotificationCounts NotificationCounts { get; set; }
    }
}
