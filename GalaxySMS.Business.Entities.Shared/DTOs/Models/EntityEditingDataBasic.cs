using GCS.Core.Common.Core;
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
    public class EntityEditingDataBasic : EntityBaseSimple
    {
        public EntityEditingDataBasic()
        {
            TimeZones = new HashSet<TimeZoneListItem>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeZoneListItem> TimeZones { get; set; }

    }
}
