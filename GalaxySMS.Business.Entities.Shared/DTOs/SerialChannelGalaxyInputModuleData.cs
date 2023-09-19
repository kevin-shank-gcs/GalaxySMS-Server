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

    public class SerialChannelGalaxyInputModuleData : EntityBase
    {
        public SerialChannelGalaxyInputModuleData()
        {
            ModulePresent = false;
            ModuleNumber = 0;
        }

        public SerialChannelGalaxyInputModuleData(SerialChannelGalaxyInputModuleData p) : base(p)
        {
            ModulePresent = false;
            ModuleNumber = 0;
            if (p != null)
            {
                ModulePresent = p.ModulePresent;
                ModuleNumber = p.ModuleNumber;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort ModuleNumber { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ModulePresent { get; set; }
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<SerialChannelGalaxyInputModuleData> Modules { get; set; }
    }
}
