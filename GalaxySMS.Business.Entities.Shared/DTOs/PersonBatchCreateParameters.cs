using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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

    public class PersonBatchCreateParameters
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Quantity { get; set; }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public int Quantity { get; set; }
    }
}
