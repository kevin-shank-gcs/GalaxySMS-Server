using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

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
    public partial class InputDevice_GetHardwareInformation : EntityBase
    {
        #region Public Properties
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputName {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short GalaxyInputModeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid RegionUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short BoardNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short SectionNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short NodeNumber {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterTypeUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterTypeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelModelUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public string GalaxyPanelTypeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InterfaceBoardTypeUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardTypeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public string InterfaceBoardModel {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InterfaceBoardSectionModeUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleTypeUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleTypeCode {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyInterfaceBoardSectionNodeUid {get;set;}
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsNodeActive {get;set;}

        #endregion

    }
}
