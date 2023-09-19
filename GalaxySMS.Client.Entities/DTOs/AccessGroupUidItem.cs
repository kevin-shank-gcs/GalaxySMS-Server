using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class AccessGroupUidItem
    {
        [DataMember]
        public System.Guid AccessGroupUid { get; set; }

        [DataMember]
        public string AccessGroupName { get; set; }
    }
}
