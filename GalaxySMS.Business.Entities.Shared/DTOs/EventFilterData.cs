using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class EventFilterData
    {

        public EventFilterData()
        {
            EventTypes = new HashSet<EventType>();
        }
#if NetCoreApi
#else
        [DataMember] 
#endif
        public ICollection<EventType> EventTypes { get; set; }
#if NetCoreApi
#else
        [DataMember] 
#endif
        public string DeviceType { get; set; }

#if NetCoreApi
#else
        [DataMember] 
#endif
        public string DeviceName { get; set; }

#if NetCoreApi
#else
        [DataMember] 
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember] 
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember] 
#endif
        public string ClusterName { get; set; }

    }

    public class EventType
    {
#if NetCoreApi
#else
        [DataMember] 
#endif
        public Guid Id { get; set; }

#if NetCoreApi
#else
        [DataMember] 
#endif
        public string Name { get; set; }

    }
}
