using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
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
	public class SeedDatabaseRequest : EntityBase
    {
        public SeedDatabaseRequest()
        {
            Init();
        }

        private void Init()
        {
            this.Brands = new HashSet<Brand>();
            this.CredentialReaderDataFormats = new HashSet<CredentialReaderDataFormat>();
            this.CredentialReaderTypes = new HashSet<CredentialReaderType>();
            this.AccessPortalTypes = new HashSet<AccessPortalType>();
            this.Features = new HashSet<Feature>();

            this.ClusterTypes = new HashSet<ClusterType>();
            this.ClusterCommands = new HashSet<ClusterCommand>();
            this.GalaxyPanelModels = new HashSet<GalaxyPanelModel>();
            this.GalaxyPanelCommands = new HashSet<GalaxyPanelCommand>();
            this.GalaxyCpuModels = new HashSet<GalaxyCpuModel>();
            this.InterfaceBoardTypes = new HashSet<InterfaceBoardType>();
            this.InterfaceBoardSectionModes = new HashSet<InterfaceBoardSectionMode>();
            this.GalaxyHardwareModuleTypes = new HashSet<GalaxyHardwareModuleType>();
            this.InputDeviceSupervisionTypes = new HashSet<InputDeviceSupervisionType>();
            this.AccessPortalContactSupervisionTypes = new HashSet<AccessPortalContactSupervisionType>();
            this.AccessPortalElevatorControlTypes = new HashSet<AccessPortalElevatorControlType>();
            this.GalaxyOutputModes = new HashSet<GalaxyOutputMode>();
            this.GalaxyOutputInputSourceRelationships = new HashSet<GalaxyOutputInputSourceRelationship>();
            this.GalaxyOutputInputSourceModes = new HashSet<GalaxyOutputInputSourceMode>();
            this.GalaxyOutputInputSourceTriggerConditions = new HashSet<GalaxyOutputInputSourceTriggerCondition>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Brand> Brands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialReaderDataFormat> CredentialReaderDataFormats { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialReaderType> CredentialReaderTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalType> AccessPortalTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Feature> Features { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterType> ClusterTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterCommand> ClusterCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyPanelModel> GalaxyPanelModels { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyPanelCommand> GalaxyPanelCommands { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyCpuModel> GalaxyCpuModels { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InterfaceBoardType> InterfaceBoardTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceSupervisionType> InputDeviceSupervisionTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalElevatorControlType> AccessPortalElevatorControlTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalContactSupervisionType> AccessPortalContactSupervisionTypes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputMode> GalaxyOutputModes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceRelationship> GalaxyOutputInputSourceRelationships {get;set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceMode> GalaxyOutputInputSourceModes {get;set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyOutputInputSourceTriggerCondition> GalaxyOutputInputSourceTriggerConditions {get;set; }

    }
}
