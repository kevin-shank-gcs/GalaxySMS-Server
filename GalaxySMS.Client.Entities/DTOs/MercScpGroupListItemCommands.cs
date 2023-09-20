using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class MercScpGroupListItemCommands : MercScpGroupListItem
    {
        public MercScpGroupListItemCommands()
        {
            //Commands = new List<ClusterCommandBasic>();
            //FlashingCommands = new List<ClusterCommandBasic>();
            DisabledCommandIds = new List<Guid>();
        }

        //[DataMember]
        //public List<ClusterCommandBasic> Commands { get; set; }

        //[DataMember]
        //public List<ClusterCommandBasic> FlashingCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> DisabledCommandIds { get; set; }
    }

}
