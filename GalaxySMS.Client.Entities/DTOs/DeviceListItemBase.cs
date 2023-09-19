////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DeviceListItemBase.cs
//
// summary:	Implements the device list item base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A device list item base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DeviceListItemBase :DtoObjectBase
    {
        /// <summary>   Identifier for the entity. </summary>
        private Guid _EntityId;
        /// <summary>   The unique UID. </summary>
        private Guid _UniqueUid;
        /// <summary>   The name. </summary>
        private string _Name;
        /// <summary>   The account code. </summary>
        private int _clusterGroupId;
        /// <summary>   The cluster number. </summary>
        private int _ClusterNumber;
        /// <summary>   The panel number. </summary>
        private int _PanelNumber;
        /// <summary>   The board number. </summary>
        private int _BoardNumber;
        /// <summary>   The section number. </summary>
        private int _SectionNumber;
        /// <summary>   The module number. </summary>
        private int _ModuleNumber;
        /// <summary>   The node number. </summary>
        private int _NodeNumber;
        /// <summary>   The when created Date/Time. </summary>
        private DateTimeOffset _WhenCreated;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique UID. </summary>
        ///
        /// <value> The unique UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid UniqueUid
        {
            get { return _UniqueUid; }
            set
            {
                if (_UniqueUid != value)
                {
                    _UniqueUid = value;
                    OnPropertyChanged(() => UniqueUid, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(() => Name, true);
                }
            }
        }

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
                    OnPropertyChanged(() => ClusterGroupId, true);
                }
            }
        }

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
                    OnPropertyChanged(() => ClusterNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel number. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PanelNumber
        {
            get { return _PanelNumber; }
            set
            {
                if (_PanelNumber != value)
                {
                    _PanelNumber = value;
                    OnPropertyChanged(() => PanelNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board number. </summary>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int BoardNumber
        {
            get { return _BoardNumber; }
            set
            {
                if (_BoardNumber != value)
                {
                    _BoardNumber = value;
                    OnPropertyChanged(() => BoardNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section number. </summary>
        ///
        /// <value> The section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int SectionNumber
        {
            get { return _SectionNumber; }
            set
            {
                if (_SectionNumber != value)
                {
                    _SectionNumber = value;
                    OnPropertyChanged(() => SectionNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the module number. </summary>
        ///
        /// <value> The module number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ModuleNumber
        {
            get { return _ModuleNumber; }
            set
            {
                if (_ModuleNumber != value)
                {
                    _ModuleNumber = value;
                    OnPropertyChanged(() => ModuleNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the node number. </summary>
        ///
        /// <value> The node number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int NodeNumber
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique hardware. </summary>
        ///
        /// <value> The identifier of the unique hardware. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.DefaultAccountClusterPanelBoardSectionNode, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the when created. </summary>
        ///
        /// <value> The when created. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset WhenCreated
        {
            get { return _WhenCreated; }
            set
            {
                if (_WhenCreated != value)
                {
                    _WhenCreated = value;
                    OnPropertyChanged(() => WhenCreated, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the age. </summary>
        ///
        /// <value> The age. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSpan Age
        {
            get { return DateTimeOffset.Now - WhenCreated; }
        }
    }
}
