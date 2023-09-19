using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class ClusterListItemCommands : ClusterListItem
    {
        public ClusterListItemCommands()
        {
            Commands = new List<ClusterCommandBasic>();
            FlashingCommands = new List<ClusterCommandBasic>();
        }

        [DataMember]
        public List<ClusterCommandBasic> Commands { get; set; }

        [DataMember]
        public List<ClusterCommandBasic> FlashingCommands { get; set; }
    }

}
