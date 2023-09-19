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
    public class InputDeviceGalaxyCommonEditingData : DtoObjectBase
    {
        private ICollection<GalaxyInputMode> _inputModes;
        private ICollection<InputDeviceAlertEventType> _alertEventTypes;
        private ICollection<GalaxyInputDelayType> _delayTypes;

        public InputDeviceGalaxyCommonEditingData()
        {
            GalaxyInputModes = new HashSet<GalaxyInputMode>();
            AlertEventTypes = new HashSet<InputDeviceAlertEventType>();
            GalaxyDelayTypes = new HashSet<GalaxyInputDelayType>();
        }

        [DataMember]
        public ICollection<GalaxyInputMode> GalaxyInputModes
        {
            get => _inputModes;
            set
            {
                if (_inputModes != value)
                {
                    _inputModes = value;
                    OnPropertyChanged(() => GalaxyInputModes, false);
                }
            }
        }

        
        [DataMember]
        public ICollection<InputDeviceAlertEventType> AlertEventTypes
        {
            get { return _alertEventTypes; }
            set 
            {   
                if (_alertEventTypes != value)
                {
                    _alertEventTypes = value;
                    OnPropertyChanged(() => AlertEventTypes, false);
                }
            }
        }

        
        [DataMember]
        public ICollection<GalaxyInputDelayType> GalaxyDelayTypes
        {
            get { return _delayTypes; }
            set 
            {   
                if (_delayTypes != value)
                {
                    _delayTypes = value;
                    OnPropertyChanged(() => GalaxyDelayTypes, false);
                }
            }
        }

    }
}
