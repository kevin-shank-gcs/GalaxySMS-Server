using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    public partial class gcsApplicationPermissionsMinimal
    {
        public gcsApplicationPermissionsMinimal()
        {
            PermissionCategories = new HashSet<gcsPermissionCategoryMinimal>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ApplicationId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsPermissionCategoryMinimal> PermissionCategories { get; set; }
    }
}
