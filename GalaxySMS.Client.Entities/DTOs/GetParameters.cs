////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GetParameters.cs
//
// summary:	Implements the get parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The GetParameters class that provides properties commonly used to request data.
    /// </summary>
    ///
    /// <remarks>   Kevin, 8/8/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GetParameters : IGetParametersBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParameters()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ///
        /// <param name="o">    The IGetParametersBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParameters(IGetParametersBase o)
        {
            Init();
            OperationUid = o.OperationUid;
            BackgroundJobId = o.BackgroundJobId;
            //SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            PersonUid = o.PersonUid;
            GetGuid = o.GetGuid;
            GetString = o.GetString;
            GetUInt16 = o.GetUInt16;
            GetUInt32 = o.GetUInt32;
            GetInt16 = o.GetInt16;
            GetInt32 = o.GetInt32;
            GetDate = o.GetDate;
            GetDate2 = o.GetDate2;
            MercScpGroupUid = o.MercScpGroupUid;
            ClusterUid = o.ClusterUid;
            ClusterGroupId = o.ClusterGroupId;
            ClusterNumber = o.ClusterNumber;
            PanelNumber = o.PanelNumber;

            RequestDateTime = o.RequestDateTime;
            ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
            this.ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToList();
            this.Options = o.Options.ToList();
            PageNumber = o.PageNumber;
            PageSize = o.PageSize;
            DescendingOrder = o.DescendingOrder;
            SortProperty = o.SortProperty;
            IncludeHardwareAddress = o.IncludeHardwareAddress;
            IncludeCommands = o.IncludeCommands;
            IncludeMemberCollections = o.IncludeMemberCollections;
            AllowedEntityIds = o.AllowedEntityIds.ToList();
            AllowedApplicationIds = o.AllowedApplicationIds.ToList();
            RefreshCache = o.RefreshCache;
            DoNotValidateAuthorization = o.DoNotValidateAuthorization;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GetParameters. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            OperationUid = Guid.Empty;
            BackgroundJobId = Guid.Empty;
            //SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            GetGuid = Guid.Empty;
            PersonUid = Guid.Empty;
            ClusterUid = Guid.Empty;
            MercScpGroupUid = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            GetDate = DateTimeOffset.MinValue;
            GetDate2 = DateTimeOffset.MinValue;
            ThrowExceptionIfNotFound = true;
            ClusterGroupId = 0;
            //ExcludeMemberCollectionSettings = new List<KeyValuePair<string, bool>>();
            ExcludeMemberCollectionSettings = new List<string>();
            Options = new List<KeyValuePair<string, bool>>();
            IncludeMemberCollections = false;
            PageNumber = 0;
            PageSize = 0;
            DescendingOrder = false;
            SortProperty = string.Empty;
            AllowedEntityIds = new List<Guid>();
            AllowedApplicationIds = new List<Guid>();
            RefreshCache = true;//false;
            DoNotValidateAuthorization = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the operation UID. </summary>
        ///
        /// <remarks>
        /// The OperationUid value is a unique value that can be used to uniquely identify the specific
        /// object.
        /// </remarks>
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the SessionId Guid value. </summary>
        /////
        ///// <remarks>
        ///// This value is used to identify the user session that this call is being made from. It must be
        ///// provided to most calls. If set, this value will override the SessionGuid header value. If not
        ///// set, the SessionGuid header value will be used. If neither are supplied, the operation will
        ///// typically fail.
        ///// </remarks>
        /////
        ///// <value> The identifier of the session. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public Guid SessionId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current entity unique identifier. </summary>
        ///
        /// <value> The identifier of the current entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current site unique identifier. </summary>
        ///
        /// <value> The identifier of the current site u. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentSiteUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid PersonUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the get. </summary>
        ///
        /// <value> Unique identifier of the get. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid GetGuid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get string. </summary>
        ///
        /// <value> The get string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String GetString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get date. </summary>
        ///
        /// <value> The get date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset GetDate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the get date 2. </summary>
        ///
        /// <value> The get date 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset GetDate2 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether or not to get for list. </summary>
        ///
        /// <value> True if get for list, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool GetForList { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the member collections should be included.
        /// </summary>
        ///
        /// <value> True if include member collections, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool GetBool { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the member collections should be included.
        /// </summary>
        ///
        /// <value> True if include member collections, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludeMemberCollections { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the hardware address should be included.
        /// </summary>
        ///
        /// <value> True if include hardware address, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember] public bool IncludeHardwareAddress { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the commands should be included. </summary>
        ///
        /// <value> True if include commands, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember] public bool IncludeCommands { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the throw exception if not found. </summary>
        ///
        /// <value> True if throw exception if not found, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool ThrowExceptionIfNotFound { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get u int 32. </summary>
        ///
        /// <value> The get u int 32. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public uint GetUInt32 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get u int 16. </summary>
        ///
        /// <value> The get u int 16. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ushort GetUInt16 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get int 32. </summary>
        ///
        /// <value> The get int 32. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int GetInt32 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the get int 16. </summary>
        ///
        /// <value> The get int 16. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short GetInt16 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the results should be returned in descending order. </summary>
        ///
        /// <value> True if descending order, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool DescendingOrder { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sort property. </summary>
        ///
        /// <value> The sort property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SortProperty { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the exclude member collection settings. </summary>
        ///
        /// <value> The exclude member collection settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        //public ICollection<KeyValuePair<string, bool>> ExcludeMemberCollectionSettings { get; set; }
        public ICollection<string> ExcludeMemberCollectionSettings { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if a specific property is excluded. </summary>
        ///
        /// <param name="name"> The name. </param>
        ///
        /// <returns>   True if excluded, false if not. </returns>
        ///=================================================================================================

        public bool IsExcluded(string name)
        {
            if (ExcludeMemberCollectionSettings == null || ExcludeMemberCollectionSettings.Count == 0)
                return false;
            return ExcludeMemberCollectionSettings.Contains(name);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The options. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<KeyValuePair<string, bool>> Options { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 ClusterGroupId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster number. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 ClusterNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel number. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 PanelNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember] 
        public Guid MercScpGroupUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the page number. </summary>
        ///
        /// <value> The page number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PageNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the size of the page. </summary>
        ///
        /// <value> The size of the page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PageSize { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the allowed entities. </summary>
        ///
        /// <value> A list of identifiers of the allowed entities. </value>
        ///=================================================================================================
        [DataMember]
        public ICollection<Guid> AllowedEntityIds { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the allowed applications. </summary>
        ///
        /// <value> A list of identifiers of the allowed applications. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<Guid> AllowedApplicationIds { get; set; }

        /// <summary>
        /// True = force the item to be retrieved from the database and the cache updated
        /// </summary>
        [DataMember]
        public bool RefreshCache { get; set; }

        [DataMember]
        public bool DoNotValidateAuthorization { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets a value indicating whether from cache should be read. </summary>
        /////
        ///// <value> True if read from cache, false if not. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //[DataMember]
        //public bool ReadFromCache { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an option. </summary>
        ///
        /// <param name="key">  The key. </param>
        ///
        /// <returns>   The option. </returns>
        ///=================================================================================================

        public bool? GetOption(string key)
        {
            var opt = Options.FirstOrDefault(o => o.Key == key);
            if (opt.Key != key)
                return null;
            return opt.Value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds an option to 'value'. </summary>
        ///
        /// <param name="key">      The key. </param>
        /// <param name="value">    True to value. </param>
        ///=================================================================================================

        public void AddOption(string key, bool value)
        {
            var kvp = new KeyValuePair<string, bool>(key, value);
            if (!Options.Contains(kvp))
                Options.Add(kvp);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A get parameters. </summary>
    ///
    /// <remarks>   Kevin, 8/8/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GetParameters<T> : GetParameters, IGetParameters<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParameters() : base()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GetParameters&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public GetParameters(Guid sessionId)
        //{
        //    Init();
        //    SessionId = sessionId;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ///
        /// <param name="o">    The GetParameters&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParameters(GetParameters<T> o) : base(o)
        {
            Data = o.Data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public T Data { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A get parameters with photo. </summary>
    ///
    /// <remarks>   Kevin, 8/8/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GetParametersWithPhoto : GetParameters, IGetParametersWithPhoto
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        /// <param name="personSummarySearchParameters"></param>
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public GetParametersWithPhoto() : base()
        {
            Init();
        }
        //public GetParametersWithPhoto(GetParameters o) : base(o)
        //{
        //    Init();
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GetParametersWithPhoto. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            IncludePhoto = true;
            PhotoPixelWidth = 0;
            OmitPhotoBinaryData = false;
            IncludeScaledPhotos = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ///
        /// <param name="o">    The IGetParametersWithPhoto to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParametersWithPhoto(IGetParametersWithPhoto o) : base(o)
        {
            Init();

            IncludePhoto = o.IncludePhoto;
            PhotoPixelWidth = o.PhotoPixelWidth;
            OmitPhotoBinaryData = o.OmitPhotoBinaryData;
            IncludeScaledPhotos = o.IncludeScaledPhotos;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the photo should be included. </summary>
        ///
        /// <value> True if include photo, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludePhoto { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the photo pixel. </summary>
        ///
        /// <value> The width of the photo pixel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PhotoPixelWidth { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the include photo links. </summary>
        ///
        /// <value> The include photo links. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool OmitPhotoBinaryData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the scaled photos should be included.
        /// </summary>
        ///
        /// <value> True if include scaled photos, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public bool IncludeScaledPhotos { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A get parameters with photo. </summary>
    ///
    /// <remarks>   Kevin, 8/8/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GetParametersWithPhoto<T> : GetParameters<T>, IGetParametersWithPhoto<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParametersWithPhoto()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GetParametersWithPhoto&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            IncludePhoto = false;
            PhotoPixelWidth = 0;
            OmitPhotoBinaryData = false;
            IncludeScaledPhotos = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 8/8/2018. </remarks>
        ///
        /// <param name="o">    The GetParametersWithPhoto&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetParametersWithPhoto(GetParametersWithPhoto<T> o) : base(o)
        {
            IncludePhoto = o.IncludePhoto;
            PhotoPixelWidth = o.PhotoPixelWidth;
            OmitPhotoBinaryData = o.OmitPhotoBinaryData;
            IncludeScaledPhotos = o.IncludeScaledPhotos;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the photo should be included. </summary>
        ///
        /// <value> True if include photo, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludePhoto { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the photo pixel. </summary>
        ///
        /// <value> The width of the photo pixel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PhotoPixelWidth { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the include photo links. </summary>
        ///
        /// <value> The include photo links. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool OmitPhotoBinaryData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the scaled photos should be included.
        /// </summary>
        ///
        /// <value> True if include scaled photos, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludeScaledPhotos { get; set; }
    }
}
