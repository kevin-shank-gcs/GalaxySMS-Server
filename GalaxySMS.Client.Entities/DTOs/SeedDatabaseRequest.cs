////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SeedDatabaseRequest.cs
//
// summary:	Implements the seed database request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A seed database request. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SeedDatabaseRequest : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the brands. </summary>
        ///
        /// <value> The brands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<Brand> _brands { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential reader data formats. </summary>
        ///
        /// <value> The credential reader data formats. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<CredentialReaderDataFormat> _credentialReaderDataFormats { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the credential readers. </summary>
        ///
        /// <value> A list of types of the credential readers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<CredentialReaderType> _credentialReaderTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portals. </summary>
        ///
        /// <value> A list of types of the access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<AccessPortalType> _accessPortalTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the features. </summary>
        ///
        /// <value> The features. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<Feature> _features { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the clusters. </summary>
        ///
        /// <value> A list of types of the clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<ClusterType> _clusterTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster commands. </summary>
        ///
        /// <value> The cluster commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<ClusterCommand> _clusterCommands { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel models. </summary>
        ///
        /// <value> The galaxy panel models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<GalaxyPanelModel> _galaxyPanelModels { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel commands. </summary>
        ///
        /// <value> The galaxy panel commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<GalaxyPanelCommand> _galaxyPanelCommands { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU models. </summary>
        ///
        /// <value> The galaxy CPU models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<GalaxyCpuModel> _galaxyCpuModels { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the interface boards. </summary>
        ///
        /// <value> A list of types of the interface boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<InterfaceBoardType> _interfaceBoardTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section modes. </summary>
        ///
        /// <value> The interface board section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<InterfaceBoardSectionMode> _interfaceBoardSectionModes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the galaxy hardware modules. </summary>
        ///
        /// <value> A list of types of the galaxy hardware modules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<GalaxyHardwareModuleType> _galaxyHardwareModuleTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the input device supervisions. </summary>
        ///
        /// <value> A list of types of the input device supervisions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<InputDeviceSupervisionType> _inputDeviceSupervisionTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portal elevator controls. </summary>
        ///
        /// <value> A list of types of the access portal elevator controls. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<AccessPortalElevatorControlType> _accessPortalElevatorControlTypes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portal contact supervisions. </summary>
        ///
        /// <value> A list of types of the access portal contact supervisions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<AccessPortalContactSupervisionType> _accessPortalContactSupervisionTypes { get; set; }


        private IList<GalaxyOutputMode> _galaxyOutputModes { get; set; }

        private IList<GalaxyOutputInputSourceRelationship> _galaxyOutputInputSourceRelationships { get; set; }


        private IList<GalaxyOutputInputSourceMode> _galaxyOutputInputSourceModes { get; set; }

        private IList<GalaxyOutputInputSourceTriggerCondition> _galaxyOutputInputSourceTriggerConditions { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SeedDatabaseRequest()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the brands. </summary>
        ///
        /// <value> The brands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Brand> Brands
        {
            get { return _brands; }
            set
            {
                if (_brands != value)
                {
                    _brands = value;
                    OnPropertyChanged(() => Brands, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential reader data formats. </summary>
        ///
        /// <value> The credential reader data formats. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CredentialReaderDataFormat> CredentialReaderDataFormats
        {
            get { return _credentialReaderDataFormats; }
            set
            {
                if (_credentialReaderDataFormats != value)
                {
                    _credentialReaderDataFormats = value;
                    OnPropertyChanged(() => CredentialReaderDataFormats, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the credential readers. </summary>
        ///
        /// <value> A list of types of the credential readers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CredentialReaderType> CredentialReaderTypes
        {
            get { return _credentialReaderTypes; }
            set
            {
                if (_credentialReaderTypes != value)
                {
                    _credentialReaderTypes = value;
                    OnPropertyChanged(() => CredentialReaderTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portals. </summary>
        ///
        /// <value> A list of types of the access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalType> AccessPortalTypes
        {
            get { return _accessPortalTypes; }
            set
            {
                if (_accessPortalTypes != value)
                {
                    _accessPortalTypes = value;
                    OnPropertyChanged(() => AccessPortalTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the features. </summary>
        ///
        /// <value> The features. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Feature> Features
        {
            get { return _features; }
            set
            {
                if (_features != value)
                {
                    _features = value;
                    OnPropertyChanged(() => Features, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the clusters. </summary>
        ///
        /// <value> A list of types of the clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<ClusterType> ClusterTypes
        {
            get { return _clusterTypes; }
            set
            {
                if (_clusterTypes != value)
                {
                    _clusterTypes = value;
                    OnPropertyChanged(() => ClusterTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster commands. </summary>
        ///
        /// <value> The cluster commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<ClusterCommand> ClusterCommands
        {
            get { return _clusterCommands; }
            set
            {
                if (_clusterCommands != value)
                {
                    _clusterCommands = value;
                    OnPropertyChanged(() => ClusterCommands, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel models. </summary>
        ///
        /// <value> The galaxy panel models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyPanelModel> GalaxyPanelModels
        {
            get { return _galaxyPanelModels; }
            set
            {
                if (_galaxyPanelModels != value)
                {
                    _galaxyPanelModels = value;
                    OnPropertyChanged(() => GalaxyPanelModels, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel commands. </summary>
        ///
        /// <value> The galaxy panel commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyPanelCommand> GalaxyPanelCommands
        {
            get { return _galaxyPanelCommands; }
            set
            {
                if (_galaxyPanelCommands != value)
                {
                    _galaxyPanelCommands = value;
                    OnPropertyChanged(() => GalaxyPanelCommands, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU models. </summary>
        ///
        /// <value> The galaxy CPU models. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyCpuModel> GalaxyCpuModels
        {
            get { return _galaxyCpuModels; }
            set
            {
                if (_galaxyCpuModels != value)
                {
                    _galaxyCpuModels = value;
                    OnPropertyChanged(() => GalaxyCpuModels, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the interface boards. </summary>
        ///
        /// <value> A list of types of the interface boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InterfaceBoardType> InterfaceBoardTypes
        {
            get { return _interfaceBoardTypes; }
            set
            {
                if (_interfaceBoardTypes != value)
                {
                    _interfaceBoardTypes = value;
                    OnPropertyChanged(() => InterfaceBoardTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section modes. </summary>
        ///
        /// <value> The interface board section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InterfaceBoardSectionMode> InterfaceBoardSectionModes
        {
            get { return _interfaceBoardSectionModes; }
            set
            {
                if (_interfaceBoardSectionModes != value)
                {
                    _interfaceBoardSectionModes = value;
                    OnPropertyChanged(() => InterfaceBoardSectionModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the galaxy hardware modules. </summary>
        ///
        /// <value> A list of types of the galaxy hardware modules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<GalaxyHardwareModuleType> GalaxyHardwareModuleTypes
        {
            get { return _galaxyHardwareModuleTypes; }
            set
            {
                if (_galaxyHardwareModuleTypes != value)
                {
                    _galaxyHardwareModuleTypes = value;
                    OnPropertyChanged(() => GalaxyHardwareModuleTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the input device supervisions. </summary>
        ///
        /// <value> A list of types of the input device supervisions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<InputDeviceSupervisionType> InputDeviceSupervisionTypes
        {
            get { return _inputDeviceSupervisionTypes; }
            set
            {
                if (_inputDeviceSupervisionTypes != value)
                {
                    _inputDeviceSupervisionTypes = value;
                    OnPropertyChanged(() => InputDeviceSupervisionTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portal elevator controls. </summary>
        ///
        /// <value> A list of types of the access portal elevator controls. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalElevatorControlType> AccessPortalElevatorControlTypes
        {
            get { return _accessPortalElevatorControlTypes; }
            set
            {
                if (_accessPortalElevatorControlTypes != value)
                {
                    _accessPortalElevatorControlTypes = value;
                    OnPropertyChanged(() => AccessPortalElevatorControlTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portal contact supervisions. </summary>
        ///
        /// <value> A list of types of the access portal contact supervisions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalContactSupervisionType> AccessPortalContactSupervisionTypes
        {
            get { return _accessPortalContactSupervisionTypes; }
            set
            {
                if (_accessPortalContactSupervisionTypes != value)
                {
                    _accessPortalContactSupervisionTypes = value;
                    OnPropertyChanged(() => AccessPortalContactSupervisionTypes, false);
                }
            }
        }


        private IList<GalaxyOutputMode> galaxyOutputModes;
        [DataMember]

        public IList<GalaxyOutputMode> GalaxyOutputModes
        {
            get { return galaxyOutputModes; }
            set
            {
                if (galaxyOutputModes != value)
                {
                    galaxyOutputModes = value;
                    OnPropertyChanged(() => GalaxyOutputModes, false);
                }
            }
        }

        [DataMember]
        public IList<GalaxyOutputInputSourceRelationship> GalaxyOutputInputSourceRelationships
        {
            get { return _galaxyOutputInputSourceRelationships; }
            set
            {
                if (_galaxyOutputInputSourceRelationships != value)
                {
                    _galaxyOutputInputSourceRelationships = value;
                    OnPropertyChanged(() => GalaxyOutputInputSourceRelationships, false);
                }
            }
        }

        [DataMember]
        public IList<GalaxyOutputInputSourceMode> GalaxyOutputInputSourceModes
        {
            get { return _galaxyOutputInputSourceModes; }
            set
            {
                if (_galaxyOutputInputSourceModes != value)
                {
                    _galaxyOutputInputSourceModes = value;
                    OnPropertyChanged(() => GalaxyOutputInputSourceModes, false);
                }
            }
        }

        
        [DataMember]

        public IList<GalaxyOutputInputSourceTriggerCondition> GalaxyOutputInputSourceTriggerConditions
        {
            get { return _galaxyOutputInputSourceTriggerConditions; }
            set
            {
                if (_galaxyOutputInputSourceTriggerConditions != value)
                {
                    _galaxyOutputInputSourceTriggerConditions = value;
                    OnPropertyChanged(() => GalaxyOutputInputSourceTriggerConditions, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this SeedDatabaseRequest. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            Brands = new List<Brand>();
            CredentialReaderDataFormats = new List<CredentialReaderDataFormat>();
            CredentialReaderTypes = new List<CredentialReaderType>();
            AccessPortalTypes = new List<AccessPortalType>();
            Features = new List<Feature>();
            ClusterTypes = new List<ClusterType>();
            ClusterCommands = new List<ClusterCommand>();
            GalaxyPanelModels = new List<GalaxyPanelModel>();
            GalaxyPanelCommands = new List<GalaxyPanelCommand>();
            GalaxyCpuModels = new List<GalaxyCpuModel>();
            InterfaceBoardTypes = new List<InterfaceBoardType>();
            InterfaceBoardSectionModes = new List<InterfaceBoardSectionMode>();
            GalaxyHardwareModuleTypes = new List<GalaxyHardwareModuleType>();
            InputDeviceSupervisionTypes = new List<InputDeviceSupervisionType>();
            AccessPortalElevatorControlTypes = new List<AccessPortalElevatorControlType>();
            AccessPortalContactSupervisionTypes = new List<AccessPortalContactSupervisionType>();
            GalaxyOutputModes = new List<GalaxyOutputMode>();
            GalaxyOutputInputSourceRelationships = new List<GalaxyOutputInputSourceRelationship>();
            GalaxyOutputInputSourceModes = new List<GalaxyOutputInputSourceMode>();
            GalaxyOutputInputSourceTriggerConditions = new List<GalaxyOutputInputSourceTriggerCondition>();
        }
    }
}