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
    public class OutputDeviceGalaxyCommonEditingData : DtoObjectBase
    {
        private ICollection<GalaxyOutputMode> _outputModes;
        private ICollection<GalaxyOutputInputSourceRelationship> _inputSourceRelationshipTypes;
        private ICollection<GalaxyOutputInputSourceMode> _inputSourceModes;
        private ICollection<GalaxyOutputInputSourceTriggerCondition> _inputSourceTriggerConditions;

        public OutputDeviceGalaxyCommonEditingData()
        {
            GalaxyOutputModes = new HashSet<GalaxyOutputMode>();
            InputSourceRelationshipTypes = new HashSet<GalaxyOutputInputSourceRelationship>();
            InputSourceModes = new HashSet<GalaxyOutputInputSourceMode>();
            InputSourceTriggerConditions = new HashSet<GalaxyOutputInputSourceTriggerCondition>();
        }

        [DataMember]
        public ICollection<GalaxyOutputMode> GalaxyOutputModes
        {
            get => _outputModes;
            set
            {
                if (_outputModes != value)
                {
                    _outputModes = value;
                    OnPropertyChanged(() => GalaxyOutputModes, false);
                }
            }
        }

       
        [DataMember]
        public ICollection<GalaxyOutputInputSourceRelationship> InputSourceRelationshipTypes
        {
            get { return _inputSourceRelationshipTypes; }
            set 
            {   
                if (_inputSourceRelationshipTypes != value)
                {
                    _inputSourceRelationshipTypes = value;
                    OnPropertyChanged(() => InputSourceRelationshipTypes, false);
                }
            }
        }

       
        [DataMember]
        public ICollection<GalaxyOutputInputSourceMode> InputSourceModes
        {
            get { return _inputSourceModes; }
            set 
            {   
                if (_inputSourceModes != value)
                {
                    _inputSourceModes = value;
                    OnPropertyChanged(() => InputSourceModes, false);
                }
            }
        }

       
        [DataMember]
        public ICollection<GalaxyOutputInputSourceTriggerCondition> InputSourceTriggerConditions
        {
            get { return _inputSourceTriggerConditions; }
            set 
            {   
                if (_inputSourceTriggerConditions != value)
                {
                    _inputSourceTriggerConditions = value;
                    OnPropertyChanged(() => InputSourceTriggerConditions, false);
                }
            }
        }

    }
}
