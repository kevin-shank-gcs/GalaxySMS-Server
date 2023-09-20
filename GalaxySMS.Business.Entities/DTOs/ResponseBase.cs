using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
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

        public Guid SessionId { get; set; }

        public DateTimeOffset ResponseDateTime { get; set; }

        public T Data { get; set; }
    }

}
