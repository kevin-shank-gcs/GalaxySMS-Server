using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class ProcessAlertEventData
    {
        public ProcessAlertEventData()
        {

        }

        public ProcessAlertEventData(IEnumerable<InputOutputGroup> ioGroups, IEnumerable<TimeScheduleSelect> schedules, int ioGroupNumber, AccessPortalAlertEvent alertEvent, int scheduleNumber, int ioGroupOffsetNumber, string instructionText, string audioFilename, int priority, bool responseRequired)
        {
            InputOutputGroups = ioGroups;
            TimeSchedules = schedules;
            InputOutputGroupNumber = ioGroupNumber;
            InputOutputGroupOffsetNumber = ioGroupOffsetNumber;
            AlertEvent = AlertEvent;
            AckScheduleNumber = scheduleNumber;
            InstructionText = instructionText;
            AudioFilename = audioFilename;
            Priority = priority;
            ResponseRequired = responseRequired;
        }
        public IEnumerable<InputOutputGroup> InputOutputGroups { get; set; }
        public IEnumerable<TimeScheduleSelect> TimeSchedules { get; set; }
        public AccessPortalAlertEvent AlertEvent { get; set; }
        public int InputOutputGroupNumber { get; set; }
        public int InputOutputGroupOffsetNumber { get; set; }
        public int AckScheduleNumber { get; set; }
        public int Priority { get; set; }
        public bool ResponseRequired { get; set; }
        public string InstructionText { get; set; }
        public string AudioFilename { get; set; }

    }
}
