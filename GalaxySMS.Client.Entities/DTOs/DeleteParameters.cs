////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DeleteParameters.cs
//
// summary:	Implements the delete parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A delete parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DeleteParameters : IDeleteParameters
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteParameters()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DeleteParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteParameters(DeleteParameters o)
        {
            Init();
            OperationUid = o.OperationUid;
            BackgroundJobId = o.BackgroundJobId;
            SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            RequestDateTime = o.RequestDateTime;
            StringValue = o.StringValue;
            DoNotValidateAuthorization = o.DoNotValidateAuthorization;
            if (o.Options != null)
                Options = o.Options.ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this DeleteParameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            OperationUid = Guid.Empty;
            BackgroundJobId = Guid.Empty;
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            StringValue = string.Empty;
            Options = new List<KeyValuePair<string, string>>();
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
        /// <summary>   Gets or sets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string value. </summary>
        ///
        /// <value> The string value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string StringValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the do not validate authorization. </summary>
        ///
        /// <value> True if do not validate authorization, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool DoNotValidateAuthorization { get; set; }

        [DataMember]
        public ICollection<KeyValuePair<string, string>> Options { get; set; }
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
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A delete parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DeleteParameters<T> : IDeleteParameters<T> where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteParameters()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this DeleteParameters&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            OperationUid = Guid.Empty;
            BackgroundJobId = Guid.Empty;
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            Data = new T();
            StringValue = string.Empty;
            DoNotValidateAuthorization = false;
            Options = new List<KeyValuePair<string, string>>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DeleteParameters&lt;T&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteParameters(DeleteParameters<T> o)
        {
            Init();
            OperationUid = o.OperationUid;
            BackgroundJobId = o.BackgroundJobId;
            SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            RequestDateTime = o.RequestDateTime;
            Data = o.Data;
            StringValue = o.StringValue;
            DoNotValidateAuthorization = o.DoNotValidateAuthorization;
            if (o.Options != null)
                Options = o.Options.ToList();
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
        /// <summary>   Gets or sets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request date time. </summary>
        ///
        /// <value> The request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset RequestDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public T Data { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string value. </summary>
        ///
        /// <value> The string value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string StringValue { get; set; }

        [DataMember]
        public bool DoNotValidateAuthorization { get; set; }

        [DataMember]
        public ICollection<KeyValuePair<string, string>> Options { get; set; }
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
    }
}
