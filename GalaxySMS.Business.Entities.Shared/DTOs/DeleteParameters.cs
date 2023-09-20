////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DeleteParameters.cs
//
// summary:	Implements the delete parameters class
///=================================================================================================

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    /// <summary>   A delete parameters. </summary>
    public class DeleteParameters : IDeleteParameters
    {
        public DeleteParameters()
        {
            Init();
        }

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
                Options = o.Options.ToCollection();
        }
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
            DoNotValidateAuthorization = false;
            Options= new Dictionary<string, string>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid BackgroundJobId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SessionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentSiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UniqueId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string StringValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DoNotValidateAuthorization { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
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
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ///=================================================================================================
#if NetCoreApi
#else
    [DataContract]
#endif
    public class DeleteParameters<T> : IDeleteParameters<T> where T : class, new()
    {
        public DeleteParameters()
        {
            Init();
        }

        public DeleteParameters(ISaveParameters p)
        {
            Init();
            if (p != null)
            {
                this.OperationUid = p.OperationUid;
                this.BackgroundJobId = p.BackgroundJobId;
                //this.SessionId = p.SessionId;
                this.CurrentEntityId = p.CurrentEntityId;
                this.CurrentSiteUid = p.CurrentSiteUid;
                this.RequestDateTime = p.RequestDateTime;
                this.DoNotValidateAuthorization = p.DoNotValidateAuthorization;
                if (p.Options != null)
                    Options = p.Options.ToCollection();
            }
        }

        public DeleteParameters(ISaveParameters<T> p)
        {
            Init();
            if (p != null)
            {
                this.OperationUid = p.OperationUid;
                //this.SessionId = p.SessionId;
                this.CurrentEntityId = p.CurrentEntityId;
                this.CurrentSiteUid = p.CurrentSiteUid;
                this.RequestDateTime = p.RequestDateTime;
                this.Data = p.Data;
                if (p.Options != null)
                    Options = p.Options.ToCollection();
            }
        }
        public void Init()
        {
            OperationUid = Guid.Empty;
            BackgroundJobId = Guid.Empty;
            
            //SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            Data = new T();
            StringValue = string.Empty;
            DoNotValidateAuthorization = false;
            Options = new List<KeyValuePair<string, string>>();

        }

        public DeleteParameters(DeleteParameters<T> o)
        {
            Init();
            OperationUid = o.OperationUid;
            BackgroundJobId = o.BackgroundJobId;
            //SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            RequestDateTime = o.RequestDateTime;
            Data = o.Data;
            StringValue = o.StringValue;
            DoNotValidateAuthorization = o.DoNotValidateAuthorization;
            if (o.Options != null)
                Options = o.Options.ToCollection();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid BackgroundJobId { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid SessionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentSiteUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UniqueId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string StringValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DoNotValidateAuthorization { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
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
