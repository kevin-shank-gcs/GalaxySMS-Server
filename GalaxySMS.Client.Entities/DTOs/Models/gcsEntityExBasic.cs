using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsEntityExBasic : gcsEntityBasic 
    {
        [DataMember]
        public gcsEntityCounts Counts { get; set; }
    }

}
