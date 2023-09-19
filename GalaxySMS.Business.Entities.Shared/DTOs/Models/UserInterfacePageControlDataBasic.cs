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
    public class UserInterfacePageControlDataBasic : EntityBaseSimple
    {
        public UserInterfacePageControlDataBasic()
        {
            ControlProperties = new HashSet<UserDefinedPropertyBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserDefinedPropertyBasic> ControlProperties { get; set; }
    }
}
