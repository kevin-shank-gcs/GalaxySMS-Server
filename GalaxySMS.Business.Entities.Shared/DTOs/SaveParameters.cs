////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SaveParameters.cs
//
// summary:	Implements the save parameters class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;


#if NetCoreApi
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Business.Entities.Api.NetCore
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class SaveParameters : ISaveParameters
    {
        public SaveParameters()
        {
            Options = new List<KeyValuePair<string, string>>();
            IgnoreProperties = new List<string>();
            ExcludeMemberCollectionSettings = new List<string>();
        }

        public SaveParameters(ISaveParameters p)
        {
            OperationUid = p.OperationUid;
            //SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            SavePhoto = p.SavePhoto;
            ThrowExceptionIfDuplicate = p.ThrowExceptionIfDuplicate;
            Options = p.Options;
            IgnoreProperties = p.IgnoreProperties;
            BackgroundJobId = p.BackgroundJobId;
            ExcludeMemberCollectionSettings = p.ExcludeMemberCollectionSettings.ToCollection();
            DoNotValidateAuthorization = p.DoNotValidateAuthorization;
            IncludeMemberCollections = p.IncludeMemberCollections;
            IncludePhoto = p.IncludePhoto;
            IncludeScaledPhotos = p.IncludeScaledPhotos;
            OmitPhotoBinaryData = p.OmitPhotoBinaryData;
            PhotoPixelWidth = p.PhotoPixelWidth;
            SaveType = p.SaveType;
        }

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

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
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SavePhoto { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ThrowExceptionIfDuplicate { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        ///
        /// <value> The options. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif      

        public ICollection<KeyValuePair<string, string>> Options { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the ignore properties. </summary>
        ///
        /// <value> The ignore properties. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif       
        public ICollection<string> IgnoreProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checks to see if specific value is in the Ignore collection. </summary>
        ///
        /// <param name="name"> The name. </param>
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
            return Options.FirstOrDefault(o=>o.Key == key);
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
                if(converter != null)
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

        public bool DoNotValidateAuthorization {get;set;}

        public void AddOption<T>(string key, T value)
        {
            var existingKpv = OptionKvp(key);
            if (existingKpv.Key == key)
                Options.Remove(existingKpv);
            Options.Add(new KeyValuePair<string, string>(key, value.ToString()));
        }

#if NetCoreApi
#else
        [DataMember]
#endif 
        public Guid BackgroundJobId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        //public ICollection<KeyValuePair<string, bool>> ExcludeMemberCollectionSettings { get; set; }
        public ICollection<string> ExcludeMemberCollectionSettings { get; set; }

        public bool IsExcluded(string name)
        {
            if (ExcludeMemberCollectionSettings == null || ExcludeMemberCollectionSettings.Count == 0)
                return false;
            return ExcludeMemberCollectionSettings.Contains(name);
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IncludeMemberCollections { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool IncludePhoto { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public int PhotoPixelWidth { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       

        public bool OmitPhotoBinaryData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool IncludeScaledPhotos { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif  
        public SaveOperationType SaveType { get; set; } = SaveOperationType.AddOrUpdate;
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class SaveParameters<T> : SaveParameters, ISaveParameters<T> where T : class, new()
    {
        public SaveParameters() : base()
        {
            Init();
        }

        private void Init()
        {
            Data = new T();
        }

        public SaveParameters(IGetParametersBase p) : base(p)
        {
            Init();
        }

        public SaveParameters(ISaveParameters p) : base(p)
        {
            Init();
        }
        public SaveParameters(ISaveParameters<T> p) : base(p)
        {
            Init();
            Data = p.Data;
        }

        public SaveParameters(T data, IGetParametersBase p) : base(p)
        {
            Init();
            this.Data = data;
        }

        public SaveParameters(T data, ISaveParameters p) : base(p)
        {
            Init();
            this.Data = data;
        }

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
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif

        public T Data { get; set; }
    }
}
