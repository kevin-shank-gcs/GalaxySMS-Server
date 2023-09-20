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
    public class SerialChannelGalaxyDoorModuleData : ObjectBase
    {
        private short _RemoteModuleSectionNumber;


        public SerialChannelGalaxyDoorModuleData()
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
        }

        public SerialChannelGalaxyDoorModuleData(SerialChannelGalaxyDoorModuleData p)
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
            if (p != null)
            {
                RemoteModuleSectionNumber = p.RemoteModuleSectionNumber;
                SerialNumber = p.SerialNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                BootVersion.Major = p.BootVersion.Major;
                BootVersion.Minor = p.BootVersion.Minor;
                BootVersion.LetterCode = p.BootVersion.LetterCode;
            }
        }

        [DataMember]
        public short RemoteModuleSectionNumber
        {
            get { return _RemoteModuleSectionNumber; }
            set
            {
                if (_RemoteModuleSectionNumber != value)
                {
                    _RemoteModuleSectionNumber = value;
                    OnPropertyChanged(() => RemoteModuleSectionNumber, true);
                }
            }
        }


        private short _NodeNumber;

        [DataMember]
        public short NodeNumber
        {
            get { return _NodeNumber; }
            set
            {
                if (_NodeNumber != value)
                {
                    _NodeNumber = value;
                    OnPropertyChanged(() => NodeNumber, true);
                }
            }
        }

        private string _SerialNumber;

        [DataMember]
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                if (_SerialNumber != value)
                {
                    _SerialNumber = value;
                    OnPropertyChanged(() => SerialNumber, true);
                }
            }
        }

        private FirmwareVersion _Version;

        [DataMember]
        public FirmwareVersion Version
        {
            get { return _Version; }
            set
            {
                if (_Version != value)
                {
                    _Version = value;
                    OnPropertyChanged(() => Version, true);
                }
            }
        }


        private FirmwareVersion _bootVersion;
        [DataMember]
        public FirmwareVersion BootVersion
        {
            get { return _bootVersion; }
            set
            {
                if (_bootVersion != value)
                {
                    _bootVersion = value;
                    OnPropertyChanged(() => BootVersion, true);
                }
            }
        }
    }

    [DataContract]
    public class SerialChannelGalaxyDoorModuleDataCollection : PanelMessageBase
    {
        public SerialChannelGalaxyDoorModuleDataCollection()
        {
            Modules = new List<SerialChannelGalaxyDoorModuleData>();
        }

        public SerialChannelGalaxyDoorModuleDataCollection(PanelMessageBase b) : base(b)
        {
            Modules = new List<SerialChannelGalaxyDoorModuleData>();
        }
        public SerialChannelGalaxyDoorModuleDataCollection(SerialChannelGalaxyDoorModuleDataCollection o) : base(o)
        {
            Modules = new List<SerialChannelGalaxyDoorModuleData>();
            if (o != null)
                Modules = o.Modules.ToList();
        }

        private List<SerialChannelGalaxyDoorModuleData> _modules;

        [DataMember]
        public List<SerialChannelGalaxyDoorModuleData> Modules
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
