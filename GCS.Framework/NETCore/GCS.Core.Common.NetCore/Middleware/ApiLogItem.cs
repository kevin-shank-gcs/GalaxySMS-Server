using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.NetCore.Middleware
{
    public class ApiLogItem
    {
        //public long Id { get; set; }

        public DateTimeOffset RequestTime { get; set; }

        public long ResponseMillis { get; set; }

        public int StatusCode { get; set; }

        public string Method { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

    }

}
