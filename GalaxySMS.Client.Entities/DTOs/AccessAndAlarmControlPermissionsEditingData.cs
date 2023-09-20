////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessAndAlarmControlPermissionsEditingData.cs
//
// summary:	Implements the access and alarm control permissions editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InputOutputGroupSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroupSelectionItem()
        {

        }

        /// <summary>   The input output group UID. </summary>
        private Guid _inputOutputGroupUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group UID. </summary>
        ///
        /// <value> The input output group UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid InputOutputGroupUid
        {
            get { return _inputOutputGroupUid; }
            set
            {
                if (_inputOutputGroupUid != value)
                {
                    _inputOutputGroupUid = value;
                    OnPropertyChanged(() => InputOutputGroupUid, false);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Name of the input output group. </summary>
        private string _InputOutputGroupName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the input output group. </summary>
        ///
        /// <value> The name of the input output group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InputOutputGroupName
        {
            get { return _InputOutputGroupName; }
            set
            {
                if (_InputOutputGroupName != value)
                {
                    _InputOutputGroupName = value;
                    OnPropertyChanged(() => InputOutputGroupName, false);
                }
            }
        }


        /// <summary>   The description. </summary>
        private string _description;
        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description, false);
                }
            }
        }

        /// <summary>   The input output group number. </summary>
        private int _InputOutputGroupNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int InputOutputGroupNumber
        {
            get { return _InputOutputGroupNumber; }
            set
            {
                if (_InputOutputGroupNumber != value)
                {
                    _InputOutputGroupNumber = value;
                    OnPropertyChanged(() => InputOutputGroupNumber, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessGroupSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessGroupSelectionItem()
        {

        }

        /// <summary>   The access group UID. </summary>
        private Guid _accessGroupUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access group UID. </summary>
        ///
        /// <value> The access group UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid AccessGroupUid
        {
            get { return _accessGroupUid; }
            set
            {
                if (_accessGroupUid != value)
                {
                    _accessGroupUid = value;
                    OnPropertyChanged(() => AccessGroupUid, false);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Name of the access group. </summary>
        private string _AccessGroupName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the access group. </summary>
        ///
        /// <value> The name of the access group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string AccessGroupName
        {
            get { return _AccessGroupName; }
            set
            {
                if (_AccessGroupName != value)
                {
                    _AccessGroupName = value;
                    OnPropertyChanged(() => AccessGroupName, false);
                }
            }
        }

        /// <summary>   The description. </summary>
        private string _description;
        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description, false);
                }
            }
        }


        /// <summary>   The access group number. </summary>
        private int _AccessGroupNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access group number. </summary>
        ///
        /// <value> The access group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int AccessGroupNumber
        {
            get { return _AccessGroupNumber; }
            set
            {
                if (_AccessGroupNumber != value)
                {
                    _AccessGroupNumber = value;
                    OnPropertyChanged(() => AccessGroupNumber, false);
                    OnPropertyChanged(() => IsExtendedAccessGroup, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this AccessGroupSelectionItem is extended access
        /// group.
        /// </summary>
        ///
        /// <value> True if this AccessGroupSelectionItem is extended access group, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        public bool IsExtendedAccessGroup
        {
            get { return _AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess; }
            //set
            //{
            //    OnPropertyChanged(() => IsExtendedAccessGroup, false);
            //}
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPortalSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalSelectionItem()
        {

        }

        /// <summary>   The access portal UID. </summary>
        private Guid _AccessPortalUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid AccessPortalUid
        {
            get { return _AccessPortalUid; }
            set
            {
                if (_AccessPortalUid != value)
                {
                    _AccessPortalUid = value;
                    OnPropertyChanged(() => AccessPortalUid, false);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Name of the access portal. </summary>
        private string _AccessPortalName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the access portal. </summary>
        ///
        /// <value> The name of the access portal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string AccessPortalName
        {
            get { return _AccessPortalName; }
            set
            {
                if (_AccessPortalName != value)
                {
                    _AccessPortalName = value;
                    OnPropertyChanged(() => AccessPortalName, false);
                }
            }
        }

        /// <summary>   The location. </summary>
        private string _location;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(() => Location, false);
                }
            }
        }

        /// <summary>   The binary resource. </summary>
        private byte[] _binaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] BinaryResource
        {
            get { return _binaryResource; }
            set
            {
                if (_binaryResource != value)
                {
                    _binaryResource = value;
                    OnPropertyChanged(() => BinaryResource, false);
                }
            }
        }


        /// <summary>   The cluster type code. </summary>
        private string _ClusterTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster type code. </summary>
        ///
        /// <value> The cluster type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClusterTypeCode
        {
            get { return _ClusterTypeCode; }
            set
            {
                if (_ClusterTypeCode != value)
                {
                    _ClusterTypeCode = value;
                    OnPropertyChanged(() => ClusterTypeCode, false);
                }
            }
        }

        /// <summary>   The galaxy panel type code. </summary>
        private string _GalaxyPanelTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel type code. </summary>
        ///
        /// <value> The galaxy panel type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string GalaxyPanelTypeCode
        {
            get { return _GalaxyPanelTypeCode; }
            set
            {
                if (_GalaxyPanelTypeCode != value)
                {
                    _GalaxyPanelTypeCode = value;
                    OnPropertyChanged(() => GalaxyPanelTypeCode, false);
                }
            }
        }

        /// <summary>   The interface board model. </summary>
        private string _InterfaceBoardModel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board model. </summary>
        ///
        /// <value> The interface board model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InterfaceBoardModel
        {
            get { return _InterfaceBoardModel; }
            set
            {
                if (_InterfaceBoardModel != value)
                {
                    _InterfaceBoardModel = value;
                    OnPropertyChanged(() => InterfaceBoardModel, false);
                }
            }
        }

        /// <summary>   The interface board section mode code. </summary>
        private short _InterfaceBoardSectionModeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section mode code. </summary>
        ///
        /// <value> The interface board section mode code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardSectionModeCode
        {
            get { return _InterfaceBoardSectionModeCode; }
            set
            {
                if (_InterfaceBoardSectionModeCode != value)
                {
                    _InterfaceBoardSectionModeCode = value;
                    OnPropertyChanged(() => InterfaceBoardSectionModeCode, false);
                }
            }
        }

        /// <summary>   The interface board type code. </summary>
        private short _InterfaceBoardTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board type code. </summary>
        ///
        /// <value> The interface board type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardTypeCode
        {
            get { return _InterfaceBoardTypeCode; }
            set
            {
                if (_InterfaceBoardTypeCode != value)
                {
                    _InterfaceBoardTypeCode = value;
                    OnPropertyChanged(() => InterfaceBoardTypeCode, false);
                }
            }
        }

        /// <summary>   The module type code. </summary>
        private short _ModuleTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the module type code. </summary>
        ///
        /// <value> The module type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short ModuleTypeCode
        {
            get { return _ModuleTypeCode; }
            set
            {
                if (_ModuleTypeCode != value)
                {
                    _ModuleTypeCode = value;
                    OnPropertyChanged(() => ModuleTypeCode, false);
                }
            }
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The input device selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InputDeviceSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceSelectionItem()
        {

        }

        /// <summary>   The input device UID. </summary>
        private Guid _InputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input device UID. </summary>
        ///
        /// <value> The input device UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid InputDeviceUid
        {
            get { return _InputDeviceUid; }
            set
            {
                if (_InputDeviceUid != value)
                {
                    _InputDeviceUid = value;
                    OnPropertyChanged(() => InputDeviceUid, false);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Name of the access portal. </summary>
        private string _InputName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the input. </summary>
        ///
        /// <value> The name of the input. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InputName
        {
            get { return _InputName; }
            set
            {
                if (_InputName != value)
                {
                    _InputName = value;
                    OnPropertyChanged(() => InputName, false);
                }
            }
        }

        /// <summary>   The location. </summary>
        private string _location;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(() => Location, false);
                }
            }
        }

        /// <summary>   The binary resource. </summary>
        private byte[] _binaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] BinaryResource
        {
            get { return _binaryResource; }
            set
            {
                if (_binaryResource != value)
                {
                    _binaryResource = value;
                    OnPropertyChanged(() => BinaryResource, false);
                }
            }
        }


        /// <summary>   The cluster type code. </summary>
        private string _ClusterTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster type code. </summary>
        ///
        /// <value> The cluster type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClusterTypeCode
        {
            get { return _ClusterTypeCode; }
            set
            {
                if (_ClusterTypeCode != value)
                {
                    _ClusterTypeCode = value;
                    OnPropertyChanged(() => ClusterTypeCode, false);
                }
            }
        }

        /// <summary>   The galaxy panel type code. </summary>
        private string _GalaxyPanelTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel type code. </summary>
        ///
        /// <value> The galaxy panel type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string GalaxyPanelTypeCode
        {
            get { return _GalaxyPanelTypeCode; }
            set
            {
                if (_GalaxyPanelTypeCode != value)
                {
                    _GalaxyPanelTypeCode = value;
                    OnPropertyChanged(() => GalaxyPanelTypeCode, false);
                }
            }
        }

        /// <summary>   The interface board model. </summary>
        private string _InterfaceBoardModel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board model. </summary>
        ///
        /// <value> The interface board model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InterfaceBoardModel
        {
            get { return _InterfaceBoardModel; }
            set
            {
                if (_InterfaceBoardModel != value)
                {
                    _InterfaceBoardModel = value;
                    OnPropertyChanged(() => InterfaceBoardModel, false);
                }
            }
        }

        /// <summary>   The interface board section mode code. </summary>
        private short _InterfaceBoardSectionModeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section mode code. </summary>
        ///
        /// <value> The interface board section mode code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardSectionModeCode
        {
            get { return _InterfaceBoardSectionModeCode; }
            set
            {
                if (_InterfaceBoardSectionModeCode != value)
                {
                    _InterfaceBoardSectionModeCode = value;
                    OnPropertyChanged(() => InterfaceBoardSectionModeCode, false);
                }
            }
        }

        /// <summary>   The interface board type code. </summary>
        private short _InterfaceBoardTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board type code. </summary>
        ///
        /// <value> The interface board type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardTypeCode
        {
            get { return _InterfaceBoardTypeCode; }
            set
            {
                if (_InterfaceBoardTypeCode != value)
                {
                    _InterfaceBoardTypeCode = value;
                    OnPropertyChanged(() => InterfaceBoardTypeCode, false);
                }
            }
        }

        /// <summary>   The module type code. </summary>
        private short _ModuleTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the module type code. </summary>
        ///
        /// <value> The module type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short ModuleTypeCode
        {
            get { return _ModuleTypeCode; }
            set
            {
                if (_ModuleTypeCode != value)
                {
                    _ModuleTypeCode = value;
                    OnPropertyChanged(() => ModuleTypeCode, false);
                }
            }
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected, false);
                }
            }
        }


    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The output device selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class OutputDeviceSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public OutputDeviceSelectionItem()
        {

        }

        /// <summary>   The output device UID. </summary>
        private Guid _OutputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid OutputDeviceUid
        {
            get { return _OutputDeviceUid; }
            set
            {
                if (_OutputDeviceUid != value)
                {
                    _OutputDeviceUid = value;
                    OnPropertyChanged(() => OutputDeviceUid, false);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Name of the access portal. </summary>
        private string _OutputName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the output. </summary>
        ///
        /// <value> The name of the output. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string OutputName
        {
            get { return _OutputName; }
            set
            {
                if (_OutputName != value)
                {
                    _OutputName = value;
                    OnPropertyChanged(() => OutputName, false);
                }
            }
        }

        /// <summary>   The location. </summary>
        private string _location;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(() => Location, false);
                }
            }
        }

        /// <summary>   The binary resource. </summary>
        private byte[] _binaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] BinaryResource
        {
            get { return _binaryResource; }
            set
            {
                if (_binaryResource != value)
                {
                    _binaryResource = value;
                    OnPropertyChanged(() => BinaryResource, false);
                }
            }
        }


        /// <summary>   The cluster type code. </summary>
        private string _ClusterTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster type code. </summary>
        ///
        /// <value> The cluster type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClusterTypeCode
        {
            get { return _ClusterTypeCode; }
            set
            {
                if (_ClusterTypeCode != value)
                {
                    _ClusterTypeCode = value;
                    OnPropertyChanged(() => ClusterTypeCode, false);
                }
            }
        }

        /// <summary>   The galaxy panel type code. </summary>
        private string _GalaxyPanelTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel type code. </summary>
        ///
        /// <value> The galaxy panel type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string GalaxyPanelTypeCode
        {
            get { return _GalaxyPanelTypeCode; }
            set
            {
                if (_GalaxyPanelTypeCode != value)
                {
                    _GalaxyPanelTypeCode = value;
                    OnPropertyChanged(() => GalaxyPanelTypeCode, false);
                }
            }
        }

        /// <summary>   The interface board model. </summary>
        private string _InterfaceBoardModel;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board model. </summary>
        ///
        /// <value> The interface board model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InterfaceBoardModel
        {
            get { return _InterfaceBoardModel; }
            set
            {
                if (_InterfaceBoardModel != value)
                {
                    _InterfaceBoardModel = value;
                    OnPropertyChanged(() => InterfaceBoardModel, false);
                }
            }
        }

        /// <summary>   The interface board section mode code. </summary>
        private short _InterfaceBoardSectionModeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section mode code. </summary>
        ///
        /// <value> The interface board section mode code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardSectionModeCode
        {
            get { return _InterfaceBoardSectionModeCode; }
            set
            {
                if (_InterfaceBoardSectionModeCode != value)
                {
                    _InterfaceBoardSectionModeCode = value;
                    OnPropertyChanged(() => InterfaceBoardSectionModeCode, false);
                }
            }
        }

        /// <summary>   The interface board type code. </summary>
        private short _InterfaceBoardTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board type code. </summary>
        ///
        /// <value> The interface board type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short InterfaceBoardTypeCode
        {
            get { return _InterfaceBoardTypeCode; }
            set
            {
                if (_InterfaceBoardTypeCode != value)
                {
                    _InterfaceBoardTypeCode = value;
                    OnPropertyChanged(() => InterfaceBoardTypeCode, false);
                }
            }
        }

        /// <summary>   The module type code. </summary>
        private short _ModuleTypeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the module type code. </summary>
        ///
        /// <value> The module type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short ModuleTypeCode
        {
            get { return _ModuleTypeCode; }
            set
            {
                if (_ModuleTypeCode != value)
                {
                    _ModuleTypeCode = value;
                    OnPropertyChanged(() => ModuleTypeCode, false);
                }
            }
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected, false);
                }
            }
        }


    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class TimeScheduleSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleSelectionItem()
        {

        }

        /// <summary>   The time schedule UID. </summary>
        private Guid _timeScheduleUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedule UID. </summary>
        ///
        /// <value> The time schedule UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid TimeScheduleUid
        {
            get { return _timeScheduleUid; }
            set
            {
                if (_timeScheduleUid != value)
                {
                    _timeScheduleUid = value;
                    OnPropertyChanged(() => TimeScheduleUid, false);
                }
            }
        }

        /// <summary>   Name of the time schedule. </summary>
        private string _timeScheduleName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the time schedule. </summary>
        ///
        /// <value> The name of the time schedule. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string TimeScheduleName
        {
            get { return _timeScheduleName; }
            set
            {
                if (_timeScheduleName != value)
                {
                    _timeScheduleName = value;
                    OnPropertyChanged(() => TimeScheduleName, false);
                }
            }
        }

        /// <summary>   The description. </summary>
        private string _description;

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }


        private int _PanelScheduleNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel schedule number. </summary>
        ///
        /// <value> The panel schedule number. </value>
        ///=================================================================================================
        [DataMember]

        public int PanelScheduleNumber
        {
            get { return _PanelScheduleNumber; }
            set
            {
                if (_PanelScheduleNumber != value)
                {
                    _PanelScheduleNumber = value;
                    OnPropertyChanged(() => PanelScheduleNumber, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ClusterSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterSelectionItem()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItem>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItem>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItem>();
            AccessPortals = new ObservableCollection<AccessPortalSelectionItem>();
            InputDevices = new ObservableCollection<InputDeviceSelectionItem>();
            OutputDevices = new ObservableCollection<OutputDeviceSelectionItem>();
        }

        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }

        /// <summary>   The site UID. </summary>
        private Guid _siteUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        ///
        /// <value> The site UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid SiteUid
        {
            get { return _siteUid; }
            set
            {
                if (_siteUid != value)
                {
                    _siteUid = value;
                    OnPropertyChanged(() => SiteUid, false);
                }
            }
        }


        /// <summary>   Name of the cluster. </summary>
        private string _ClusterName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the cluster. </summary>
        ///
        /// <value> The name of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClusterName
        {
            get { return _ClusterName; }
            set
            {
                if (_ClusterName != value)
                {
                    _ClusterName = value;
                    OnPropertyChanged(() => ClusterName, false);
                }
            }
        }

        /// <summary>   The cluster number. </summary>
        private int _ClusterNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster number. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterNumber
        {
            get { return _ClusterNumber; }
            set
            {
                if (_ClusterNumber != value)
                {
                    _ClusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber, false);
                }
            }
        }

        /// <summary>   The account code. </summary>
        private int _clusterGroupId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the account code. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId, false);
                }
            }
        }

        /// <summary>   The binary resource. </summary>
        private byte[] _photo;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] Photo
        {
            get { return _photo; }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    OnPropertyChanged(() => Photo, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Groups the access belongs to. </summary>
        private ICollection<AccessGroupSelectionItem> _accessGroups;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the groups the access belongs to. </summary>
        ///
        /// <value> The access groups. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<AccessGroupSelectionItem> AccessGroups
        {
            get { return _accessGroups; }
            set
            {
                if (_accessGroups != value)
                {
                    _accessGroups = value;
                    OnPropertyChanged(() => AccessGroups, false);
                }
            }
        }

        /// <summary>   Groups the input output belongs to. </summary>
        private ICollection<InputOutputGroupSelectionItem> _inputOutputGroups;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the groups the input output belongs to. </summary>
        ///
        /// <value> The input output groups. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<InputOutputGroupSelectionItem> InputOutputGroups
        {
            get { return _inputOutputGroups; }
            set
            {
                if (_inputOutputGroups != value)
                {
                    _inputOutputGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
                }
            }
        }

        /// <summary>   The time schedules. </summary>
        private ICollection<TimeScheduleSelectionItem> _timeSchedules;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedules. </summary>
        ///
        /// <value> The time schedules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<TimeScheduleSelectionItem> TimeSchedules
        {
            get { return _timeSchedules; }
            set
            {
                if (_timeSchedules != value)
                {
                    _timeSchedules = value;
                    OnPropertyChanged(() => TimeSchedules, false);
                }
            }
        }

        /// <summary>   The access portals. </summary>
        private ObservableCollection<AccessPortalSelectionItem> _AccessPortals;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portals. </summary>
        ///
        /// <value> The access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<AccessPortalSelectionItem> AccessPortals
        {
            get { return _AccessPortals; }
            set
            {
                if (_AccessPortals != value)
                {
                    _AccessPortals = value;
                    OnPropertyChanged(() => AccessPortals, false);
                }
            }
        }


        /// <summary>   The input devices. </summary>
        private ObservableCollection<InputDeviceSelectionItem> _InputDevices;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input devices. </summary>
        ///
        /// <value> The input devices. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<InputDeviceSelectionItem> InputDevices
        {
            get { return _InputDevices; }
            set
            {
                if (_InputDevices != value)
                {
                    _InputDevices = value;
                    OnPropertyChanged(() => InputDevices, false);
                }
            }
        }


        /// <summary>   The output devices. </summary>
        private ObservableCollection<OutputDeviceSelectionItem> _OutputDevices;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the output devices. </summary>
        ///
        /// <value> The output devices. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<OutputDeviceSelectionItem> OutputDevices
        {
            get { return _OutputDevices; }
            set
            {
                if (_OutputDevices != value)
                {
                    _OutputDevices = value;
                    OnPropertyChanged(() => OutputDevices, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group non extended selection items. </summary>
        ///
        /// <value> The access group non extended selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItem> AccessGroupNonExtendedSelectionItems
        {
            get { return AccessGroups.Where(i => i.IsExtendedAccessGroup == false && i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group with extended selection items. </summary>
        ///
        /// <value> The access group with extended selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItem> AccessGroupWithExtendedSelectionItems
        {
            get { return AccessGroups.Where(i => i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group with personal access group selection items. </summary>
        ///
        /// <value> The access group with personal access group selection items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItem> AccessGroupWithPersonalAccessGroupSelectionItems
        {
            get { return AccessGroups.ToObservableCollection(); }
        }


        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected, false);
                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A site selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class SiteSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SiteSelectionItem()
        {
            Clusters = new HashSet<ClusterSelectionItem>();
        }
        /// <summary>   The site UID. </summary>
        private Guid _siteUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        ///
        /// <value> The site UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid SiteUid
        {
            get { return _siteUid; }
            set
            {
                if (_siteUid != value)
                {
                    _siteUid = value;
                    OnPropertyChanged(() => SiteUid, false);
                }
            }
        }

        /// <summary>   The region UID. </summary>
        private Guid _regionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the region UID. </summary>
        ///
        /// <value> The region UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid RegionUid
        {
            get { return _regionUid; }
            set
            {
                if (_regionUid != value)
                {
                    _regionUid = value;
                    OnPropertyChanged(() => RegionUid, false);
                }
            }
        }

        /// <summary>   Name of the site. </summary>
        private string _SiteName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the site. </summary>
        ///
        /// <value> The name of the site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string SiteName
        {
            get { return _SiteName; }
            set
            {
                if (_SiteName != value)
                {
                    _SiteName = value;
                    OnPropertyChanged(() => SiteName, false);
                }
            }
        }

        /// <summary>   The binary resource. </summary>
        private byte[] _binaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] BinaryResource
        {
            get { return _binaryResource; }
            set
            {
                if (_binaryResource != value)
                {
                    _binaryResource = value;
                    OnPropertyChanged(() => BinaryResource, false);
                }
            }
        }
        /// <summary>   Identifier for the site. </summary>
        private string _SiteId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the site. </summary>
        ///
        /// <value> The identifier of the site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string SiteId
        {
            get { return _SiteId; }
            set
            {
                if (_SiteId != value)
                {
                    _SiteId = value;
                    OnPropertyChanged(() => SiteId, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   The clusters. </summary>
        private ICollection<ClusterSelectionItem> _clusters;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the clusters. </summary>
        ///
        /// <value> The clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<ClusterSelectionItem> Clusters
        {
            get { return _clusters; }
            set
            {
                if (_clusters != value)
                {
                    _clusters = value;
                    OnPropertyChanged(() => Clusters, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A region selection item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class RegionSelectionItem : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RegionSelectionItem()
        {
            Sites = new HashSet<SiteSelectionItem>();
        }
        /// <summary>   The region UID. </summary>
        private Guid _regionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the region UID. </summary>
        ///
        /// <value> The region UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid RegionUid
        {
            get { return _regionUid; }
            set
            {
                if (_regionUid != value)
                {
                    _regionUid = value;
                    OnPropertyChanged(() => RegionUid, false);
                }
            }
        }

        /// <summary>   Name of the region. </summary>
        private string _RegionName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the region. </summary>
        ///
        /// <value> The name of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RegionName
        {
            get { return _RegionName; }
            set
            {
                if (_RegionName != value)
                {
                    _RegionName = value;
                    OnPropertyChanged(() => RegionName, false);
                }
            }
        }


        /// <summary>   The binary resource. </summary>
        private byte[] _binaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource. </summary>
        ///
        /// <value> The binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] BinaryResource
        {
            get { return _binaryResource; }
            set
            {
                if (_binaryResource != value)
                {
                    _binaryResource = value;
                    OnPropertyChanged(() => BinaryResource, false);
                }
            }
        }

        /// <summary>   Identifier for the region. </summary>
        private string _RegionId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the region. </summary>
        ///
        /// <value> The identifier of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RegionId
        {
            get { return _RegionId; }
            set
            {
                if (_RegionId != value)
                {
                    _RegionId = value;
                    OnPropertyChanged(() => RegionId, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   The sites. </summary>
        private ICollection<SiteSelectionItem> _sites;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sites. </summary>
        ///
        /// <value> The sites. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<SiteSelectionItem> Sites
        {
            get { return _sites; }
            set
            {
                if (_sites != value)
                {
                    _sites = value;
                    OnPropertyChanged(() => Sites, false);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access and alarm control permissions editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessAndAlarmControlPermissionsEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessAndAlarmControlPermissionsEditingData()
        {
            Regions = new HashSet<RegionSelectionItemBasic>();
            //Regions = new HashSet<RegionSelectionItem>();
            //var x = new RegionSelectionItem();
        }

        /// <summary>   The regions. </summary>
       // private ICollection<RegionSelectionItem> _regions;
        private ICollection<RegionSelectionItemBasic> _regions;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the regions. </summary>
        ///
        /// <value> The regions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<RegionSelectionItemBasic> Regions
        //public ICollection<RegionSelectionItem> Regions
        {
            get { return _regions; }
            set
            {
                if (_regions != value)
                {
                    _regions = value;
                    OnPropertyChanged(() => Regions, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster selection item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterUid">   The cluster UID. </param>
        ///
        /// <returns>   The cluster selection item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterSelectionItemBasic GetClusterSelectionItem(Guid clusterUid)
        {
            foreach (var r in Regions)
            {
                foreach (var s in r.Sites)
                {
                    var c = s.Clusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
                    if (c != null)
                        return c;
                }
            }
            return null;
        }


        public ClusterSelectionItemBasic GetClusterSelectionItem(int clusterGroupId, int clusterNumber)
        {
            foreach (var r in Regions)
            {
                foreach (var s in r.Sites)
                {
                    var c = s.Clusters.FirstOrDefault(o => o.ClusterNumber == clusterNumber && o.ClusterGroupId == clusterGroupId);
                    if (c != null)
                        return c;
                }
            }
            return null;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets site selection item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="siteUid">  The site UID. </param>
        ///
        /// <returns>   The site selection item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //        public SiteSelectionItemBasic GetSiteSelectionItem(Guid siteUid)
        public SiteSelectionItemBasic GetSiteSelectionItem(Guid siteUid)
        {
            foreach (var r in Regions)
            {
                var s = r.Sites.FirstOrDefault(o => o.SiteUid == siteUid);
                if (s != null)
                    return s;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets region selection item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="regionUid">    The region UID. </param>
        ///
        /// <returns>   The region selection item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RegionSelectionItemBasic GetRegionSelectionItem(Guid regionUid)
        {
            return Regions.FirstOrDefault(o => o.RegionUid == regionUid);
        }
    }
}

