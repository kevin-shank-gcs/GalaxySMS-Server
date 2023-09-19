using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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
    public class AccessProfileEditingData : EntityBase
    {
        public AccessProfileEditingData()
        {
            AccessProfiles = new HashSet<AccessProfile>();
            Sites = new HashSet<Site>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingData();
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
        public ICollection<Site> Sites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfile> AccessProfiles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessAndAlarmControlPermissionsEditingData AccessAndAlarmControlPermissionsEditingData { get; set; }

    }

}
