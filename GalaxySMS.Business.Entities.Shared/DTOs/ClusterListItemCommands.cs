using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class ClusterListItemCommands : ClusterListItem
    {
        public ClusterListItemCommands()
        {
            //Commands = new List<ClusterCommandBasic>();
            //FlashingCommands = new List<ClusterCommandBasic>();
            DisabledCommandIds = new List<Guid>();
        }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public List<ClusterCommandBasic> Commands { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public List<ClusterCommandBasic> FlashingCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> DisabledCommandIds { get; set; }

    }

}
