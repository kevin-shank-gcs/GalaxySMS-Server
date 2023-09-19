using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class SerialChannelGalaxyInputModuleData : ObjectBase
    {
        public SerialChannelGalaxyInputModuleData()
        {
            ModulePresent = false;
            ModuleNumber = 0;
        }

        public SerialChannelGalaxyInputModuleData(SerialChannelGalaxyInputModuleData p) 
        {
            ModulePresent = false;
            ModuleNumber = 0;
            if (p != null)
            {
                ModulePresent = p.ModulePresent;
                ModuleNumber = p.ModuleNumber;
            }
        }

        private ushort _moduleNumber;
        
        [DataMember]
        public ushort ModuleNumber
        {
            get { return _moduleNumber; }
            set
            {
                if (_moduleNumber != value)
                {
                    _moduleNumber = value;
                    OnPropertyChanged(() => ModuleNumber, true);
                }
            }
        }

        private bool _ModulePresent;

        [DataMember]
        public bool ModulePresent
        {
            get { return _ModulePresent; }
            set
            {
                if (_ModulePresent != value)
                {
                    _ModulePresent = value;
                    OnPropertyChanged(() => ModulePresent, true);
                }
            }
        }

    }

    [DataContract]
    public class SerialChannelGalaxyInputModuleDataCollection : PanelMessageBase
    {
        public SerialChannelGalaxyInputModuleDataCollection()
        {
            Modules = new List<SerialChannelGalaxyInputModuleData>();
        }

        public SerialChannelGalaxyInputModuleDataCollection(PanelMessageBase b) : base(b)
        {
            Modules = new List<SerialChannelGalaxyInputModuleData>();
        }
        public SerialChannelGalaxyInputModuleDataCollection(SerialChannelGalaxyInputModuleDataCollection o) : base(o)
        {
            Modules = new List<SerialChannelGalaxyInputModuleData>();
            if (o != null)
                Modules = o.Modules.ToList();
        }

        private List<SerialChannelGalaxyInputModuleData> _modules;

        [DataMember]
        public List<SerialChannelGalaxyInputModuleData> Modules
        {
            get { return _modules; }
            set
            {
                if (_modules != value)
                {
                    _modules = value;
                    OnPropertyChanged(() => Modules, true);
                }
            }
        }
    }
}
