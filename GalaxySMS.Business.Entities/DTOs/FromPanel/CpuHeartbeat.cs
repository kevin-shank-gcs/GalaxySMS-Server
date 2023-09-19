using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class CpuHeartbeat : PanelMessageBase
    {
        public CpuHeartbeat()
        {
        }

        public CpuHeartbeat(PanelMessageBase b)
            : base(b)
        {
        }

        public CpuHeartbeat(CpuHeartbeat o)
            : base(o)
        {
            if (o != null)
            {
            }
        }
    }
}
