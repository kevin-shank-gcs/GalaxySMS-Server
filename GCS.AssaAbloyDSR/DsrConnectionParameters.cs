using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.AssaAbloyDSR
{
    public class DsrConnectionParameters
    {
        public DsrConnectionParameters()
        {
            IpAddress = string.Empty;
            Port = 8080;
            UseHttps = false;
        }

        public string IpAddress { get; set; }
        public uint Port { get; set; }
        public bool UseHttps { get; set; }
    }
}
