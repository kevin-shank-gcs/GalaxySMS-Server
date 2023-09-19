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
            PermissionCategories = new HashSet<gcsEntityRoleMinimal>();
            FilterData = new ApplicationRoleFilterData();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ApplicationId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsApplicationRoleMinimal> PermissionCategories { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ApplicationRoleFilterData FilterData { get; set; }

    }
}
