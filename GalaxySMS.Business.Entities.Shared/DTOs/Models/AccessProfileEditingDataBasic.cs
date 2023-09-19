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
	public class AccessProfileEditingDataBasic : EntityBaseSimple
    {
        public AccessProfileEditingDataBasic()
        {
            AccessProfiles = new HashSet<AccessProfileBasic>();
            Sites = new HashSet<SiteBasic>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingDataBasic();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<SiteBasic> Sites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfileBasic> AccessProfiles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessAndAlarmControlPermissionsEditingDataBasic AccessAndAlarmControlPermissionsEditingData { get;set;}

    }

}
