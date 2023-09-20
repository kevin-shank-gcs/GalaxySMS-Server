using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
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

    public partial class GalaxyInterfaceBoardSectionCommandAction : ObjectBase
    {
        public GalaxyInterfaceBoardSectionCommandAction()
        {
            Init();
        }

        public GalaxyInterfaceBoardSectionCommandAction(GalaxyInterfaceBoardSectionCommandAction o)
        {
            Init();
            GalaxyInterfaceBoardSectionUid = o.GalaxyInterfaceBoardSectionUid;
            CommandAction = o.CommandAction;
            InterfaceBoardSectionHardwareInformation = o.InterfaceBoardSectionHardwareInformation;
            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = GalaxyInterfaceBoardSectionCommandActionCode.None;
            GalaxyInterfaceBoardSectionUid = Guid.Empty;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyInterfaceBoardSectionCommandActionCode CommandAction { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionUid { get; set; }

        // Server side only. We do not need this to have the DataMember attribute
        public GalaxyInterfaceBoardSection_PanelLoadData InterfaceBoardSectionHardwareInformation { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CommandUid {get;set;}

    }
}
