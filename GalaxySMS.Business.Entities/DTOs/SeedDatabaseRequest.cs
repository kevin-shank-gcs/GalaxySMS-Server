using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
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
            
        }

        public ICollection<Brand> Brands { get; set; }
        public ICollection<CredentialReaderDataFormat> CredentialReaderDataFormats { get; set; }
        public ICollection<CredentialReaderType> CredentialReaderTypes { get; set; }
        public ICollection<AccessPortalType> AccessPortalTypes { get; set; }
        public ICollection<Feature> Features { get; set; }

        public ICollection<ClusterType> ClusterTypes { get; set; }
        public ICollection<ClusterCommand> ClusterCommands { get; set; }
        public ICollection<GalaxyPanelModel> GalaxyPanelModels { get; set; }
        public ICollection<GalaxyPanelCommand> GalaxyPanelCommands { get; set; }
        public ICollection<GalaxyCpuModel> GalaxyCpuModels { get; set; }
        public ICollection<InterfaceBoardType> InterfaceBoardTypes { get; set; }
        public ICollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; set; }
        public ICollection<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes { get; set; }
        public ICollection<InputDeviceSupervisionType> InputDeviceSupervisionTypes {get;set; }
        public ICollection<AccessPortalElevatorControlType> AccessPortalElevatorControlTypes {get;set; }
        public ICollection<AccessPortalContactSupervisionType> AccessPortalContactSupervisionTypes {get;set; }
    }
}
