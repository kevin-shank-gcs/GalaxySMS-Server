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
    public class EntityRoleFilterData
    {
        public EntityRoleFilterData()
        {
            EntityFilters = new HashSet<gcsEntityFilterData>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsEntityFilterData> EntityFilters { get; set; }

    }


}



