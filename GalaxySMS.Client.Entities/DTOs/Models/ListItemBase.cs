using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]

    public class ListItemBase
    {
        [DataMember]
        public Guid Uid { get; set; }
       
        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string KeyValue { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public bool IsNodeActive { get; set; }


    }
}
