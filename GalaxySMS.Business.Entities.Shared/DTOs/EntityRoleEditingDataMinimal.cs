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
    public class EntityRoleEditingDataMinimal
    {
        public EntityRoleEditingDataMinimal()
        {
            ApplicationPermissions = new HashSet<gcsApplicationPermissionsMinimal>();
            FilterData = new gcsEntityFilterDataMinimal();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsApplicationPermissionsMinimal> ApplicationPermissions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsEntityFilterDataMinimal FilterData { get; set; }

    }
}
