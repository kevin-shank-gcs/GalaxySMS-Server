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
    public class UserInterfacePageControlData : EntityBase
    {
        public UserInterfacePageControlData()
        {
            ControlProperties = new HashSet<UserDefinedProperty>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserDefinedProperty> ControlProperties { get; set; }
    }
}
