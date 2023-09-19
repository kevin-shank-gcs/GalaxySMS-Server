using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

    public class SendDataResponse
    {
        public enum Result { Ok, NotOk}

        public SendDataResponse()
        {
            ResponseDateTime = DateTimeOffset.Now;
        }

        public SendDataResponse(DateTimeOffset dt)
        {
            ResponseDateTime = dt;
        }

        public SendDataResponse(SendDataResponse p) :base()
        {
            if( p!= null)
            {
                ResponseDateTime = p.ResponseDateTime;
                ResultCode = p.ResultCode;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ResponseDateTime { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Result ResultCode { get; set; }
    }

    [DataContract]
    public class SendDataResponse<T> : SendDataResponse where T : class, new()
    {
        public SendDataResponse() : base()
        {
            Data = new T();
        }

        public SendDataResponse(T data, SendDataResponse p) : base(p)
        {
            Data = data;
        }

        public SendDataResponse(T data) : base()
        {
            Data = data;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }

    }

}
