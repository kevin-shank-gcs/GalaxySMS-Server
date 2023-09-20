using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class AccessPortalUidItem
    {
        [DataMember]
        public System.Guid AccessPortalUid { get; set; }

        [DataMember]
        public string PortalName { get; set; }
    }
}
