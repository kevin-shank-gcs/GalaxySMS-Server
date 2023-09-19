using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class OutputDeviceHardwareSpecificEditingData : DtoObjectBase
    {
        //private ICollection<OutputDeviceSupervisionType> _contactSupervisionTypes;
        private ICollection<TimeSchedule> _timeSchedules;
        private ICollection<InputOutputGroup> _inputOutputGroups;

        public OutputDeviceHardwareSpecificEditingData()
        {
            //ContactSupervisionTypes = new HashSet<OutputDeviceSupervisionType>();
            TimeSchedules = new HashSet<TimeSchedule>();
            InputOutputGroups = new HashSet<InputOutputGroup>();
        }

        //[DataMember]
        //public ICollection<OutputDeviceSupervisionType> ContactSupervisionTypes
        //{
        //    get { return _contactSupervisionTypes; }
        //    set
        //    {
        //        if (_contactSupervisionTypes != value)
        //        {
        //            _contactSupervisionTypes = value;
        //            OnPropertyChanged(() => ContactSupervisionTypes, false);
        //        }
        //    }
        //}

        [DataMember]
        public ICollection<TimeSchedule> TimeSchedules
        {
            get { return _timeSchedules; }
            set
            {
                if (_timeSchedules != value)
                {
                    _timeSchedules = value;
                    OnPropertyChanged(() => TimeSchedules, false);
                }
            }
        }

        [DataMember]
        public ICollection<InputOutputGroup> InputOutputGroups
        {
            get { return _inputOutputGroups; }
            set
            {
                if (_inputOutputGroups != value)
                {
                    _inputOutputGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
                }
            }
        }
    }
}
