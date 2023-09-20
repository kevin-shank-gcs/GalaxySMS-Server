using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class CpuResetReply : PanelMessageBase
    {
        public CpuResetReply()
        {
        }

        public CpuResetReply(PanelMessageBase b)
            : base(b)
        {
        }

        public CpuResetReply(CpuResetReply o)
            : base(o)
        {
            if (o != null)
            {
            }
        }
    }
}
