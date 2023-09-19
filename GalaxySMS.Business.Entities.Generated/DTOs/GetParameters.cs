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
            SessionId = o.SessionId;
            RequestDateTime = o.RequestDateTime;
        }
        public void Init()
        {
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
        }

        
        public Guid SessionId { get; set; }

        
        public Guid CurrentEntityId { get; set; }

        public Guid UniqueId { get; set; }
        public string GetString { get; set; }
        public bool GetForList { get; set; }


        public DateTimeOffset RequestDateTime { get; set; }
    }

    
    public class GetParameters<T> : IGetParameters<T>
    {
        public GetParameters()
        {
            Init();
        }

        public void Init()
        {
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
        }

        public GetParameters(Guid sessionId)
        {
            Init();
            SessionId = sessionId;
        }

        public GetParameters(GetParameters<T> o)
        {
            Init();
            SessionId = o.SessionId;
            RequestDateTime = o.RequestDateTime;
            Data = o.Data;
        }

        
        public Guid SessionId { get; set; }

        
        public Guid CurrentEntityId { get; set; }

        
        public Guid UniqueId { get; set; }
        public Guid GetString { get; set; }
        public bool GetForList { get; set; }


        public DateTimeOffset RequestDateTime { get; set; }

        
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
            IncludePhoto = false;
            PhotoPixelWidth = 0;
        }

        public GetParametersWithPhoto(GetParametersWithPhoto o)
        {
            IncludePhoto = o.IncludePhoto;
            PhotoPixelWidth = o.PhotoPixelWidth;
        }

        
        public bool IncludePhoto { get; set; }

        
        public int PhotoPixelWidth { get; set; }
    }

    
    public class GetParametersWithPhoto<T> : GetParameters<T>, IGetParametersWithPhoto<T>
    {
        public GetParametersWithPhoto()
        {
            Init();
        }

        public void Init()
        {
            base.Init();
            IncludePhoto = false;
            PhotoPixelWidth = 0;
        }

        public GetParametersWithPhoto(GetParametersWithPhoto<T> o) : base(o)
        {
            IncludePhoto = o.IncludePhoto;
            PhotoPixelWidth = o.PhotoPixelWidth;
        }

        
        public bool IncludePhoto { get; set; }

        
        public int PhotoPixelWidth { get; set; }
    }
}
