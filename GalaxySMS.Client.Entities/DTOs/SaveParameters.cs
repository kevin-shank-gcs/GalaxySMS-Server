////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SaveParameters.cs
//
// summary:	Implements the save parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A save parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SaveParameters : ISaveParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters()
        {
            Options = new List<KeyValuePair<string, string>>();
            IgnoreProperties = new List<string>();
            ExcludeMemberCollectionSettings = new List<string>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The IGetParametersBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(ISaveParameters p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            SavePhoto = false;
            ThrowExceptionIfDuplicate = true;
            Options = p.Options;
            IgnoreProperties = p.IgnoreProperties;
            BackgroundJobId = p.BackgroundJobId;
            ExcludeMemberCollectionSettings = p.ExcludeMemberCollectionSettings.ToCollection();
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            IncludeMemberCollections = p.IncludeMemberCollections;
            IncludePhoto = p.IncludePhoto;
            PhotoPixelWidth = p.PhotoPixelWidth;
            OmitPhotoBinaryData = p.OmitPhotoBinaryData;
            IncludeScaledPhotos = p.IncludeScaledPhotos;
            SaveType = p.SaveType;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The IGetParametersBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(IGetParametersBase p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            SavePhoto = false;
            ThrowExceptionIfDuplicate = true;
            Options = new List<KeyValuePair<string, string>>();
            IgnoreProperties = new List<string>();
            BackgroundJobId = Guid.Empty;
            ExcludeMemberCollectionSettings = p.ExcludeMemberCollectionSettings.ToCollection();
            IncludeMemberCollections = p.IncludeMemberCollections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the operation UID. </summary>
        ///
        /// <value> The operation UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid OperationUid { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the identifier of the session. </summary>
        /////
        ///// <value> The identifier of the session. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public Guid SessionId { get; set; }

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
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the photo should be saveed. </summary>
        ///
        /// <value> True if save photo, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool SavePhoto { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the throw exception if duplicate. </summary>
        ///
        /// <value> True if throw exception if duplicate, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool ThrowExceptionIfDuplicate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The options. </value>
        ///=================================================================================================
        [DataMember]

        public ICollection<KeyValuePair<string, string>> Options { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the properties to ignore. </summary>
        ///
        /// <value> The ignore properties. </value>
        ///=================================================================================================
        [DataMember]
        public ICollection<string> IgnoreProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determine if a specific property name is in the IgnoreProperties collection.
        /// </summary>
        ///
        /// <param name="name"> The name of the property to ignore. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ///=================================================================================================

        public bool Ignore(string name)
        {
            if (IgnoreProperties == null || IgnoreProperties.Count == 0)
                return false;
            return IgnoreProperties.Contains(name);
        }

        public KeyValuePair<string, string> OptionKvp(string key)
        {
            return Options.FirstOrDefault(o => o.Key == key);
        }

        public string OptionValue(string key)
        {
            return OptionKvp(key).Value;
        }


        public T OptionValue<T>(string key)
        {
            try
            {
                var v = OptionKvp(key).Value;
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(v);
                }
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }

        public void AddOption<T>(string key, T value)
        {
            var existingKpv = OptionKvp(key);
            if (existingKpv.Key == key)
                Options.Remove(existingKpv);
            Options.Add(new KeyValuePair<string, string>(key, value.ToString()));
        }

        public Guid BackgroundJobId { get; set; }

        public bool DoNotValidateAuthorization { get; set; }

        [DataMember]
        public ICollection<string> ExcludeMemberCollectionSettings { get; set; }

        public bool IsExcluded(string name)
        {
            if (ExcludeMemberCollectionSettings == null || ExcludeMemberCollectionSettings.Count == 0)
                return false;
            return ExcludeMemberCollectionSettings.Contains(name);
        }

        [DataMember] public bool IncludeMemberCollections { get; set; }
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

        [DataMember]
        public SaveOperationType SaveType { get; set; } = SaveOperationType.AddOrUpdate;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A save parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SaveParameters<T> : SaveParameters, ISaveParameters<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters() : base()
        {
            Init();
        }

        private void Init()
        {
            Data = new T();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ISaveParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(IGetParametersBase p) : base(p)
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The ISaveParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(ISaveParameters p) : base(p)
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        /// <param name="p">    The ISaveParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(T data, IGetParametersBase p) : base(p)
        {
            Init();
            Data = data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        /// <param name="p">    The ISaveParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveParameters(T data, ISaveParameters p) : base(p)
        {
            Init();
            Data = data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="data"> The data. </param>
        /// <param name="p">    The ISaveParameters to process. </param>
        ///=================================================================================================

        public SaveParameters(SaveParameters<T> data, ISaveParameters p) : base(p)
        {
            Init();
            Data = data.Data;
        }


        public SaveParameters(T data) : base()
        {
            Init();
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


    [DataContract]
    public class SaveJobParameters<T> where T : class, new()
    {
        public Guid JobId { get; set; }
        public SaveParameters<T> SaveParameters { get; set; }
        public IApplicationUserSessionDataHeader UserSessionData { get; set; }
    }
}
