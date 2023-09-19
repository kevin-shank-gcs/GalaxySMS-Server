using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
    public class DeleteParameters : IDeleteParametersBase
    {
        public DeleteParameters()
        {
            Init();
        }

        public DeleteParameters(DeleteParameters o)
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

        public DateTimeOffset RequestDateTime { get; set; }
    }

    public class DeleteParameters<T> : IDeleteParameters<T>
    {
        public DeleteParameters()
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

        public DeleteParameters(DeleteParameters<T> o)
        {
            Init();
            SessionId = o.SessionId;
            RequestDateTime = o.RequestDateTime;
            Data = o.Data;
        }

        public Guid SessionId { get; set; }

        public Guid CurrentEntityId { get; set; }

        public Guid UniqueId { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }

        public T Data { get; set; }
    }
}
