using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

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
    public class ResponseBase<T> : IResponseBase<T>
    {
        public ResponseBase()
        {
            Init();
        }

        private void Init()
        {
            SessionId = Guid.Empty;
            ResponseDateTime = DateTimeOffset.Now;
        }

        public ResponseBase(Guid sessionId)
        {
            Init();
            SessionId = sessionId;
        }

        public ResponseBase(ResponseBase<T> o)
        {
            SessionId = o.SessionId;
            ResponseDateTime = o.ResponseDateTime;
            Data = o.Data;
        }

        public ResponseBase(T data)
        {
            Init();
            Data = data;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SessionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ResponseDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }
    }

}
