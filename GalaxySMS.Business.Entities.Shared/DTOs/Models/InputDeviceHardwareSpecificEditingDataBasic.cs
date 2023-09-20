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
    public class InputDeviceHardwareSpecificEditingDataBasic : EntityBaseSimple
    {
        public InputDeviceHardwareSpecificEditingDataBasic()
        {
            ContactSupervisionTypes = new HashSet<InputDeviceSupervisionTypeBasic>();
            TimeSchedules = new HashSet<TimeScheduleBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupBasic>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceSupervisionTypeBasic> ContactSupervisionTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleBasic> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupBasic> InputOutputGroups { get; set; }

    }
}
