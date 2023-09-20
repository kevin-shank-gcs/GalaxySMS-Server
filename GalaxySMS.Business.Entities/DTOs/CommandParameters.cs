using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
    public class CommandParameters : ICommandParameters
    {
        public CommandParameters()
        {

        }

        public CommandParameters(ICommandParameters p)
        {
            OperationUid = p.OperationUid;
            SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
        }

        public CommandParameters(ICallParametersBase p)
        {
            OperationUid = p.OperationUid;
            SessionId = p.SessionId;
            CurrentEntityId = p.CurrentEntityId;
            CurrentSiteUid = p.CurrentSiteUid;
            RequestDateTime = p.RequestDateTime;
        }

        public Guid OperationUid { get; set; }
        public Guid SessionId { get; set; }
        public Guid CurrentEntityId { get; set; }
        public Guid CurrentSiteUid { get; set; }
        public DateTimeOffset RequestDateTime { get; set; }
        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }
    }

    public class CommandParameters<T> : CommandParameters, ICommandParameters<T> where T : class, new()
    {
        public CommandParameters() : base()
        {
            Data = new T();
        }

        public CommandParameters(ICallParametersBase p) : base(p)
        {
            Data = new T();
        }

        public CommandParameters(ICommandParameters p) : base(p)
        {
            Data = new T();
        }

        public CommandParameters(ICommandParameters p, T data) : base(p)
        {
            Data = data;
        }
        public CommandParameters(ICommandParameters<T> p) : base(p)
        {
            Data = p.Data;
        }
        public T Data { get; set; }
    }
}
