using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class GalaxyPanelEditingData : EntityBase
    {
        public GalaxyPanelEditingData()
        {
            PanelModels = new HashSet<GalaxyPanelModel>();
            CpuModels = new HashSet<GalaxyCpuModel>();
            InterfaceBoardTypes = new HashSet<InterfaceBoardType>();
            InterfaceBoardSectionModes = new HashSet<InterfaceBoardSectionMode>();
            GalaxyHardwareModuleTypes = new HashSet<GalaxyHardwareModuleType>();
            TimeSchedules = new HashSet<TimeSchedule>();
            InputOutputGroups = new HashSet<InputOutputGroup>();
            AlertEventTypes = new HashSet<GalaxyPanelAlertEventType>();
        }

        public ICollection<GalaxyPanelModel> PanelModels { get; set; }
        public ICollection<GalaxyCpuModel> CpuModels { get; set; }
        public ICollection<InterfaceBoardType> InterfaceBoardTypes { get; set; }
        public ICollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; set; }
        public ICollection<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes { get; set; }
        public ICollection<TimeSchedule> TimeSchedules { get; set; }
        public ICollection<InputOutputGroup> InputOutputGroups { get; set; }
        public ICollection<GalaxyPanelAlertEventType> AlertEventTypes { get; set; }

    }
}
