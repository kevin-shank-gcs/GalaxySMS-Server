////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GetParameters.cs
//
// summary:	Implements the get parameters class
///=================================================================================================

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
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
    public class GetParameters : IGetParametersBase
    {
        public GetParameters()
        {
            Init();
        }

        public GetParameters(GetParameters o)
        {
            Init();
            if (o != null)
            {
                OperationUid = o.OperationUid;
                BackgroundJobId = o.BackgroundJobId;
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                GetForList = o.GetForList;
                GetString = o.GetString;
                GetBool = o.GetBool;
                GetGuid = o.GetGuid;
                GetDate = o.GetDate;
                GetDate2 = o.GetDate2;
                GetInt16 = o.GetInt16;
                GetInt32 = o.GetInt32;
                GetUInt16 = o.GetUInt16;
                GetUInt32 = o.GetUInt32;
                IncludeMemberCollections = o.IncludeMemberCollections;
                IncludeHardwareAddress = o.IncludeHardwareAddress;
                IncludeCommands = o.IncludeCommands;
                RequestDateTime = o.RequestDateTime;
                ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
                //SessionId = o.SessionId;
                UniqueId = o.UniqueId;
                PersonUid = o.PersonUid;
                ClusterUid = o.ClusterUid;
                MercScpGroupUid = o.MercScpGroupUid;
                ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToList();
                Options = o.Options.ToList();
                ClusterGroupId = o.ClusterGroupId;
                ClusterNumber = o.ClusterNumber;
                PanelNumber = o.PanelNumber;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
                DescendingOrder = o.DescendingOrder;
                SortProperty = o.SortProperty;
                AllowedEntityIds = o.AllowedEntityIds.ToList();
                AllowedApplicationIds = o.AllowedApplicationIds.ToList();
                DoNotValidateAuthorization = o.DoNotValidateAuthorization;
                RefreshCache = o.RefreshCache;
                //ReadFromCache = o.ReadFromCache;
            }
        }

        public GetParameters(IGetParametersBase o)
        {
            Init();
            if (o != null)
            {
                OperationUid = o.OperationUid;
                BackgroundJobId = o.BackgroundJobId;
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                GetForList = o.GetForList;
                GetString = o.GetString;
                GetBool = o.GetBool;
                GetGuid = o.GetGuid;
                GetDate = o.GetDate;
                GetDate2 = o.GetDate2;
                GetInt16 = o.GetInt16;
                GetInt32 = o.GetInt32;
                GetUInt16 = o.GetUInt16;
                GetUInt32 = o.GetUInt32;
                IncludeMemberCollections = o.IncludeMemberCollections;
                IncludeHardwareAddress = o.IncludeHardwareAddress;
                IncludeCommands = o.IncludeCommands;
                RequestDateTime = o.RequestDateTime;
                ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
                //SessionId = o.SessionId;
                UniqueId = o.UniqueId;
                PersonUid = o.PersonUid;
                ClusterUid = o.ClusterUid;
                MercScpGroupUid = o.MercScpGroupUid;
                ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToList();
                Options = o.Options.ToList();
                ClusterGroupId = o.ClusterGroupId;
                ClusterNumber = o.ClusterNumber;
                PanelNumber = o.PanelNumber;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
                DescendingOrder = o.DescendingOrder;
                SortProperty = o.SortProperty;
                AllowedEntityIds = o.AllowedEntityIds.ToList();
                AllowedApplicationIds = o.AllowedApplicationIds.ToList();
                RefreshCache = o.RefreshCache;
                //ReadFromCache = o.ReadFromCache;
            }
        }

        public GetParameters(ISaveParameters o)
        {
            Init();
            if (o != null)
            {
                OperationUid = o.OperationUid;
                BackgroundJobId = o.BackgroundJobId;
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                RequestDateTime = o.RequestDateTime;
                DoNotValidateAuthorization = o.DoNotValidateAuthorization;
                ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToCollection();
                IncludeMemberCollections = o.IncludeMemberCollections;
                //SessionId = o.SessionId;
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
            PersonUid = Guid.Empty;
            ClusterUid = Guid.Empty;
            MercScpGroupUid = Guid.Empty;
            GetGuid = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            GetDate = DateTimeOffset.MinValue;
            GetDate2 = DateTimeOffset.MinValue;
            ClusterGroupId = 0;
            ThrowExceptionIfNotFound = true;
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
            //ReadFromCache = true;
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
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Guid MercScpGroupUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Guid GetGuid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public DateTimeOffset RequestDateTime { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public String GetString { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset GetDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset GetDate2 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool GetForList { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool GetBool { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool IncludeMemberCollections { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool IncludeHardwareAddress { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool IncludeCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public bool ThrowExceptionIfNotFound { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public uint GetUInt32 { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public ushort GetUInt16 { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public int GetInt32 { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public short GetInt16 { get; set; }


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
        public ICollection<KeyValuePair<string, bool>> Options { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Int32 ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Int32 ClusterNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public Int32 PanelNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public int PageNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public int PageSize { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DescendingOrder { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string SortProperty { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public ICollection<Guid> AllowedEntityIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif       
        public ICollection<Guid> AllowedApplicationIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif   
        public bool RefreshCache { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public bool ReadFromCache { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif   
        public bool DoNotValidateAuthorization { get; set; }
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

        public void AddOption(string key, bool value)
        {
            var kvp = new KeyValuePair<string, bool>(key, value);
            if (!Options.Contains(kvp))
                Options.Add(kvp);
        }
    }




#if NetCoreApi
#else
    [DataContract]
#endif       
    public class GetParameters<T> : GetParameters, IGetParameters<T> where T : class, new()
    {
        public GetParameters() : base()
        {
            Init();
        }

        public void Init()
        {
            base.Init();
            Data = new T();
        }

        //public GetParameters(Guid sessionId)
        //{
        //    Init();
        //    SessionId = sessionId;
        //}

        public GetParameters(SaveParameters o, T data) : base(o)
        {
            Data = data;
        }

        public GetParameters(GetParameters<T> o)
        {
            Init();
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            GetForList = o.GetForList;
            GetString = o.GetString;
            GetGuid = o.GetGuid;
            IncludeMemberCollections = o.IncludeMemberCollections;
            RequestDateTime = o.RequestDateTime;
            //SessionId = o.SessionId;
            ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
            UniqueId = o.UniqueId;
            Data = o.Data;
        }


#if NetCoreApi
#else
        [DataMember]
#endif       
        public T Data { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif       
    public class GetParametersWithPhoto : GetParameters, IGetParametersWithPhoto
    {
        public GetParametersWithPhoto()
        {
            Init();
        }

        public void Init()
        {
            base.Init();
            IncludePhoto = true;
            PhotoPixelWidth = 0;
            OmitPhotoBinaryData = false;
            IncludeScaledPhotos = false;
        }

        public GetParametersWithPhoto(GetParametersWithPhoto o) : base(o)
        {
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;
                OmitPhotoBinaryData = o.OmitPhotoBinaryData;
                IncludeScaledPhotos = o.IncludeScaledPhotos;
            }
        }
        public GetParametersWithPhoto(IGetParametersBase o) : base(o)
        {
            IncludePhoto = false;
            PhotoPixelWidth = 0;
            OmitPhotoBinaryData = false;
            IncludeScaledPhotos = false;
        }

        public GetParametersWithPhoto(IGetParametersWithPhoto o) : base(o)
        {
            IncludePhoto = false;
            PhotoPixelWidth = 0;
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;
                OmitPhotoBinaryData = o.OmitPhotoBinaryData;
                IncludeScaledPhotos = o.IncludeScaledPhotos;
            }
        }

        public GetParametersWithPhoto(ISaveParameters o) : base(o)
        {
            IncludePhoto = o.IncludePhoto;
            PhotoPixelWidth = o.PhotoPixelWidth;
            OmitPhotoBinaryData = o.OmitPhotoBinaryData;
            IncludeScaledPhotos = o.IncludeScaledPhotos;
        }


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
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class GetParametersWithPhoto<T> : GetParameters<T>, IGetParametersWithPhoto<T> where T : class, new()
    {
        public GetParametersWithPhoto()
        {
            Init();
        }

        public void Init()
        {
            base.Init();
            IncludePhoto = true;
            PhotoPixelWidth = 0;
            OmitPhotoBinaryData = false;
            IncludeScaledPhotos = false;
        }


        public GetParametersWithPhoto(GetParametersWithPhoto<T> o) : base(o)
        {
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;
                OmitPhotoBinaryData = o.OmitPhotoBinaryData;
                IncludeScaledPhotos = o.IncludeScaledPhotos;
            }
        }


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
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class GetHardwareAddressParameters : ICallParametersBase
    {

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
        public DateTimeOffset RequestDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ClusterNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 PanelNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int16 CpuNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DoNotValidateAuthorization { get; set; }
    }
}
