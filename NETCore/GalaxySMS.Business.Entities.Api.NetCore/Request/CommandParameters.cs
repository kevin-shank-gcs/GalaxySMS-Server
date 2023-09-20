using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Api.Models.RequestModels
{
	public class CommandParams
    {
        public CommandParams()
        {
            Parameters = new List<KeyValuePair<string,string>>();
        }

        public CommandParams(CommandParams p)
        {
            //OperationUid = p.OperationUid;
            if (p.Parameters != null)
                Parameters = p.Parameters.ToList();
        }

        //public Guid OperationUid { get; set; }

        public ICollection<KeyValuePair<string, string>> Parameters { get; set; }
        public bool NotifySignalRSession { get; set; }
        
        //[RequiredGuidNotEmpty()]
        public Guid OperationUid { get; set; }
    }

    public class CommandParams<T> : CommandParams where T : class, new()
    {
        public CommandParams() : base()
        {
            Data = new T();
        }

        public CommandParams(CommandParams<T> p) : base(p)
        {
            Data = p.Data;
        }

        [Required]
        public T Data { get; set; }
    }
    public class CommandParamsSimple
    {
        public CommandParamsSimple()
        {
            //Parameters = new List<KeyValuePair<string, string>>();
        }

        public CommandParamsSimple(CommandParams p)
        {
            NotifySignalRSession = p.NotifySignalRSession;
            OperationUid = p.OperationUid;
        }

        public bool NotifySignalRSession { get; set; }

        public Guid OperationUid { get; set; }
    }

    public class CommandParamsSimple<T> : CommandParamsSimple where T : class, new()
    {
        public CommandParamsSimple() : base()
        {
            Data = new T();
        }

        public CommandParamsSimple(CommandParamsSimple<T> p) : base()
        {
            Data = p.Data;
        }

        [Required]
        public T Data { get; set; }
    }
}
