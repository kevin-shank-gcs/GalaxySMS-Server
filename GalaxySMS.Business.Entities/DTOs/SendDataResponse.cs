using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{


    [DataContract]
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

        [DataMember]
        public DateTimeOffset ResponseDateTime { get; set; }

        [DataMember]
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

        [DataMember]
        public T Data { get; set; }

    }

}
