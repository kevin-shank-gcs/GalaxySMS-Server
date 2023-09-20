using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]

    public class AccessProfileListItem
    {
        [DataMember]
        public Guid AccessProfileUid { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public AccessProfileCounts Counts { get; set; }
    }

    [DataContract]

    public class AccessProfileCounts 
    {
        [DataMember]
        public int Cardholders { get; set; }
    }



}
