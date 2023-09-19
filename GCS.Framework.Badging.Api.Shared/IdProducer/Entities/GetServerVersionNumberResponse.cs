using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class GetServerVersionNumberResponse : MethodResponse
    {
        public String Data { get; set; }

        public Version Version
        {
            get
            {
                var v = new Version();
                if (string.IsNullOrEmpty(Data))
                    return v;
                if( Version.TryParse(Data, out v))
                    return v;
                return v;
            }

        }
    }
}
