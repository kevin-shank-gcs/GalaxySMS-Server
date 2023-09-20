using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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

    public class SerialChannelGalaxyDoorModuleData : EntityBase
    {
        public SerialChannelGalaxyDoorModuleData()
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
        }

        public SerialChannelGalaxyDoorModuleData(SerialChannelGalaxyDoorModuleData p) : base(p)
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
            NodeNumber = 0;
            if (p != null)
            {
                NodeNumber = p.NodeNumber;
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public short NodeNumber { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public short RemoteModuleSectionNumber { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string SerialNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion Version { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion BootVersion { get; set; }
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<SerialChannelGalaxyDoorModuleData> Modules { get; set; }
    }
}
