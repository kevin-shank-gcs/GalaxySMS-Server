using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
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
            SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            RequestDateTime = o.RequestDateTime;
        }
        public void Init()
        {
            OperationUid = Guid.Empty;
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
        }

        public Guid OperationUid { get; set; }
        public Guid SessionId { get; set; }

        public Guid CurrentEntityId { get; set; }
        public Guid CurrentSiteUid { get; set; }

        public Guid UniqueId { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }
    }

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
                this.SessionId = p.SessionId;
                this.CurrentEntityId = p.CurrentEntityId;
                this.CurrentSiteUid = p.CurrentSiteUid;
                this.RequestDateTime = p.RequestDateTime;
            }
        }

        public DeleteParameters(ISaveParameters<T> p)
        {
            Init();
            if (p != null)
            {
                this.OperationUid = p.OperationUid;
                this.SessionId = p.SessionId;
                this.CurrentEntityId = p.CurrentEntityId;
                this.CurrentSiteUid = p.CurrentSiteUid;
                this.RequestDateTime = p.RequestDateTime;
                this.Data = p.Data;
            }
        }
        public void Init()
        {
            OperationUid = Guid.Empty;
            SessionId = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteUid = Guid.Empty;
            UniqueId = Guid.Empty;
            RequestDateTime = DateTimeOffset.Now;
            Data = new T();
        }

        public DeleteParameters(DeleteParameters<T> o)
        {
            Init();
            OperationUid = o.OperationUid;
            SessionId = o.SessionId;
            CurrentEntityId = o.CurrentEntityId;
            CurrentSiteUid = o.CurrentSiteUid;
            UniqueId = o.UniqueId;
            RequestDateTime = o.RequestDateTime;
            Data = o.Data;
        }

        public Guid OperationUid { get; set; }
        public Guid SessionId { get; set; }

        public Guid CurrentEntityId { get; set; }
        public Guid CurrentSiteUid { get; set; }
        public Guid UniqueId { get; set; }

        public DateTimeOffset RequestDateTime { get; set; }

        public T Data { get; set; }
    }
}
