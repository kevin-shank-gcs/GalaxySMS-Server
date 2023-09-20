using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class AccessPortalGalaxyPanelSpecificEditingData : EntityBase
    {
        public AccessPortalGalaxyPanelSpecificEditingData()
        {
            ContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionType>();
            LiquidCrystalDisplays  = new HashSet<LiquidCrystalDisplay>();
            ElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            ElevatorRelaysInterfaceBoardSections = new HashSet<GalaxyInterfaceBoardSection>();
            Areas = new HashSet<Area>();
            TimeSchedules = new HashSet<TimeSchedule>();
            InputOutputGroups = new HashSet<InputOutputGroup>();
            //AccessGroups = new HashSet<AccessGroup>();
            //OtisElevatorDecs = new HashSet<OtisElevatorDec>();
        }

        public ICollection<AccessPortalContactSupervisionType> ContactSupervisionTypes { get; set; }
        public ICollection<LiquidCrystalDisplay> LiquidCrystalDisplays { get; set; }
        public ICollection<AccessPortalElevatorControlType> ElevatorControlTypes {get;set; }
        public ICollection<GalaxyInterfaceBoardSection> ElevatorRelaysInterfaceBoardSections {get;set; }
        //public ICollection<OtisElevatorDec> OtisElevatorDecs {get;set; }    
        public ICollection<Area> Areas { get; set; }
        public ICollection<TimeSchedule> TimeSchedules { get; set; }
        public ICollection<InputOutputGroup> InputOutputGroups { get; set; }
        //public ICollection<AccessGroup> AccessGroups { get; set; }
    }
}
