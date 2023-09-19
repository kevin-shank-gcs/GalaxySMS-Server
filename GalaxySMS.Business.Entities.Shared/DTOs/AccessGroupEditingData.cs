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
    public class AccessGroupEditingData: EntityBase
    {
        public AccessGroupEditingData()
        {
            TimeSchedules = new HashSet<TimeSchedule>();
            AccessPortals = new HashSet<AccessPortal>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeSchedule> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortal> AccessPortals { get; set; }
    }
}
