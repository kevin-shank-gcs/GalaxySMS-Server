using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{

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
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                GetForList = o.GetForList;
                GetString = o.GetString;
                IncludeMemberCollections = o.IncludeMemberCollections;
                IncludeHardwareAddress = o.IncludeHardwareAddress;
                IncludeCommands = o.IncludeCommands;
                RequestDateTime = o.RequestDateTime;
                ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
                SessionId = o.SessionId;
                UniqueId = o.UniqueId;
                PersonUid = o.PersonUid;
                ClusterUid = o.ClusterUid;
                GetGuid = o.GetGuid;
                ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToList();
                Options = o.Options.ToList();
                ClusterGroupId = o.ClusterGroupId;
                ClusterNumber = o.ClusterNumber;
                PanelNumber = o.PanelNumber;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
            }
        }

        public GetParameters(IGetParametersBase o)
        {
            Init();
            if (o != null)
            {
                OperationUid = o.OperationUid;
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                GetForList = o.GetForList;
                GetString = o.GetString;
                IncludeMemberCollections = o.IncludeMemberCollections;
                IncludeHardwareAddress = o.IncludeHardwareAddress;
                IncludeCommands = o.IncludeCommands;
                RequestDateTime = o.RequestDateTime;
                ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
                SessionId = o.SessionId;
                UniqueId = o.UniqueId;
                PersonUid = o.PersonUid;
                ClusterUid = o.ClusterUid;
                GetGuid = o.GetGuid;
                ExcludeMemberCollectionSettings = o.ExcludeMemberCollectionSettings.ToList();
                Options = o.Options.ToList();
                ClusterGroupId = o.ClusterGroupId;
                ClusterNumber = o.ClusterNumber;
                PanelNumber = o.PanelNumber;
                PageNumber = o.PageNumber;
                PageSize = o.PageSize;
            }
        }

        public GetParameters(SaveParameters o)
        {
            Init();
            if (o != null)
            {
                OperationUid = o.OperationUid;
                CurrentEntityId = o.CurrentEntityId;
                CurrentSiteUid = o.CurrentSiteUid;
                RequestDateTime = o.RequestDateTime;
                SessionId = o.SessionId;
            }
        }

        public void Init()
        {
            OperationUid = Guid.Empty;
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            PersonUid = Guid.Empty;
            ClusterUid = Guid.Empty;
            GetGuid = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            ClusterGroupId = 0;
            ThrowExceptionIfNotFound = true;
            ExcludeMemberCollectionSettings = new List<KeyValuePair<string, bool>>();
            Options = new List<KeyValuePair<string, bool>>();
            IncludeMemberCollections = false;
            PageNumber = 0;
            PageSize = 0;
        }

        public Guid OperationUid { get; set; }
        public Guid SessionId { get; set; }

        public Guid CurrentEntityId { get; set; }

        public Guid CurrentSiteUid { get; set; }

        public Guid UniqueId { get; set; }
        public Guid PersonUid { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid GetGuid { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }

        public String GetString { get; set; }

        public bool GetForList { get; set; }

        public bool IncludeMemberCollections { get; set; }
        public bool IncludeHardwareAddress { get; set; }
        public bool IncludeCommands { get; set; }
        public bool ThrowExceptionIfNotFound { get; set; }

        public uint GetUInt32 { get; set; }

        public ushort GetUInt16 { get; set; }

        public int GetInt32 { get; set; }

        public short GetInt16 { get; set; }

        public ICollection<KeyValuePair<string, bool>> ExcludeMemberCollectionSettings { get; set; }

        public ICollection<KeyValuePair<string, bool>> Options { get; set; }
        public String ClusterGroupId { get; set; }
        public Int32 ClusterNumber { get; set; }
        public Int32 PanelNumber { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }


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

        public GetParameters(Guid sessionId)
        {
            Init();
            SessionId = sessionId;
        }

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
            SessionId = o.SessionId;
            ThrowExceptionIfNotFound = o.ThrowExceptionIfNotFound;
            UniqueId = o.UniqueId;
            Data = o.Data;
        }

        public T Data { get; set; }
    }


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
        }

        public GetParametersWithPhoto(GetParametersWithPhoto o) : base(o)
        {
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;
            }
        }
        public GetParametersWithPhoto(IGetParametersBase o) : base(o)
        {
            IncludePhoto = false;
            PhotoPixelWidth = 0;
        }

        public GetParametersWithPhoto(IGetParametersWithPhoto o) : base(o)
        {
            IncludePhoto = false;
            PhotoPixelWidth = 0;
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;
            }
        }

        public GetParametersWithPhoto(SaveParameters o) : base(o)
        {
        }

        public bool IncludePhoto { get; set; }


        public int PhotoPixelWidth { get; set; }
    }


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
        }

        public GetParametersWithPhoto(GetParametersWithPhoto<T> o) : base(o)
        {
            if (o != null)
            {
                IncludePhoto = o.IncludePhoto;
                PhotoPixelWidth = o.PhotoPixelWidth;

            }
        }


        public bool IncludePhoto { get; set; }


        public int PhotoPixelWidth { get; set; }
    }

    public class GetHardwareAddressParameters : ICallParametersBase
    {
        public Guid OperationUid { get; set; }
        public Guid SessionId { get; set; }
        public Guid CurrentEntityId { get; set; }
        public Guid CurrentSiteUid { get; set; }
        public DateTimeOffset RequestDateTime { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid GalaxyPanelUid { get; set; }
        public Guid CpuUid { get; set; }
        public String ClusterGroupId { get; set; }
        public Int32 ClusterNumber { get; set; }
        public Int32 PanelNumber { get; set; }
        public Int16 CpuNumber { get; set; }

    }
}
