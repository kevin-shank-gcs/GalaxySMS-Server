using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
    public class SaveParameters<T>: ISaveParameters<T>
    {
        public Guid SessionId { get; set; }
        public Guid CurrentEntityId { get; set; }
        public DateTimeOffset RequestDateTime { get; set; }
        public T Data { get; set; }
        public bool SavePhoto { get; set; }
    }
}
