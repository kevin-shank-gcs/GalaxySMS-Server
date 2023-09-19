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
    public class OutputDeviceGalaxyCommonEditingDataBasic : EntityBaseSimple
    {
        public OutputDeviceGalaxyCommonEditingDataBasic()
        {
            GalaxyOutputModes = new HashSet<GalaxyOutputModeBasic>();
            InputSourceRelationshipTypes = new HashSet<GalaxyOutputInputSourceRelationshipBasic>();
            InputSourceModes = new HashSet<GalaxyOutputInputSourceModeBasic>();
            InputSourceTriggerConditions = new HashSet<GalaxyOutputInputSourceTriggerConditionBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputModeBasic> GalaxyOutputModes { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceRelationshipBasic> InputSourceRelationshipTypes { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceModeBasic> InputSourceModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceTriggerConditionBasic> InputSourceTriggerConditions { get; set; }
    }
}
