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
    public class InputDeviceGalaxyCommonEditingData : EntityBase
    {
        public InputDeviceGalaxyCommonEditingData()
        {
            GalaxyInputModes = new HashSet<GalaxyInputMode>();
            AlertEventTypes = new HashSet<InputDeviceAlertEventType>();
            GalaxyDelayTypes = new HashSet<GalaxyInputDelayType>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInputMode> GalaxyInputModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceAlertEventType> AlertEventTypes {get;set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInputDelayType> GalaxyDelayTypes {get;set; }

    }
}
