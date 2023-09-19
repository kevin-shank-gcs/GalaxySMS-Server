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
    public class InputDeviceGalaxyCommonEditingDataBasic : EntityBaseSimple
    {
        public InputDeviceGalaxyCommonEditingDataBasic()
        {
            GalaxyInputModes = new HashSet<GalaxyInputModeBasic>();
            AlertEventTypes = new HashSet<InputDeviceAlertEventTypeBasic>();
            GalaxyDelayTypes = new HashSet<GalaxyInputDelayTypeBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInputModeBasic> GalaxyInputModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceAlertEventTypeBasic> AlertEventTypes {get;set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInputDelayTypeBasic> GalaxyDelayTypes {get;set; }

    }
}
