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
    public class OutputDeviceGalaxyCommonEditingData : EntityBase
    {
        public OutputDeviceGalaxyCommonEditingData()
        {
            GalaxyOutputModes = new HashSet<GalaxyOutputMode>();
            InputSourceRelationshipTypes = new HashSet<GalaxyOutputInputSourceRelationship>();
            InputSourceModes = new HashSet<GalaxyOutputInputSourceMode>();
            InputSourceTriggerConditions = new HashSet<GalaxyOutputInputSourceTriggerCondition>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputMode> GalaxyOutputModes { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceRelationship> InputSourceRelationshipTypes { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceMode> InputSourceModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceTriggerCondition> InputSourceTriggerConditions { get; set; }
    }
}
