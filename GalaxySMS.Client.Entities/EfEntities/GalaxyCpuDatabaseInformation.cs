////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\GalaxyCpuDatabaseInformation.cs
//
// summary:	Implements the galaxy CPU database information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about a Galaxy CPU. </summary>
    ///
    /// <remarks>   Kevin, 9/4/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class GalaxyCpuDatabaseInformation : DtoObjectBase
    {
        #region Private Variables
        /// <summary>   The cluster UID. </summary>
        private Guid _ClusterUid = Guid.Empty;
        /// <summary>   The galaxy panel UID. </summary>
        private Guid _GalaxyPanelUid = Guid.Empty;
        /// <summary>   The CPU UID. </summary>
        private Guid _CpuUid = Guid.Empty;
        /// <summary>   The account code. </summary>
        private int _clusterGroupId = 0;
        /// <summary>   The cluster number. </summary>
        private int _ClusterNumber = 0;
        /// <summary>   The panel number. </summary>
        private int _PanelNumber = 0;
        /// <summary>   The CPU number. </summary>
        private short _CpuNumber = 0;
        /// <summary>   The serial number. </summary>
        private string _SerialNumber = string.Empty;
        /// <summary>   The IP address. </summary>
        private string _IpAddress = string.Empty;
        /// <summary>   True to enable, false to disable the default event logging. </summary>
        private bool _DefaultEventLoggingOn = false;
        /// <summary>   True to prevent data loading. </summary>
        private bool _PreventDataLoading = false;
        /// <summary>   True to prevent flash loading. </summary>
        private bool _PreventFlashLoading = false;
        /// <summary>   Zero-based index of the last log. </summary>
        private int _LastLogIndex = 0;
        /// <summary>   Name of the cluster. </summary>
        private string _ClusterName = string.Empty;
        /// <summary>   Name of the panel. </summary>
        private string _PanelName = string.Empty;
        /// <summary>   The cluster type code. </summary>
        private string _ClusterTypeCode = string.Empty;
        /// <summary>   True if cluster type is active. </summary>
        private bool _ClusterTypeIsActive = false;
        /// <summary>   Length of the credential data. </summary>
        private short _CredentialDataLength = 0;
        /// <summary>   The panel location. </summary>
        private string _PanelLocation = string.Empty;
        /// <summary>   The panel model type code. </summary>
        private string _PanelModelTypeCode = string.Empty;
        /// <summary>   True if panel model is active. </summary>
        private bool _PanelModelIsActive = false;
        /// <summary>   True if CPU is active. </summary>
        private bool _CpuIsActive = false;
        /// <summary>   The site UID. </summary>
        private Guid _siteUid;
        /// <summary>   Name of the site. </summary>
        private string _SiteName;
        /// <summary>   Identifier for the entity. </summary>
        private Guid _EntityId;
        /// <summary>   Name of the entity. </summary>
        private string _EntityName;

        private string _EntityType;
        /// <summary>
        /// Time Zone the cluster is located in
        /// </summary>
        private string _TimeZoneId;

        /// <summary>   Information describing the alert event acknowledge. </summary>
        private List<GalaxyPanel_GetAlertEventAcknowledgeData> _AlertEventAcknowledgeData;

        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Uid value. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid ClusterUid
        {
            get { return _ClusterUid; }
            set
            {
                if (_ClusterUid != value)
                {
                    _ClusterUid = value;
                    OnPropertyChanged(() => ClusterUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Galaxy Panel Uid value. </summary>
        ///
        /// <value> The galaxy panel UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid GalaxyPanelUid
        {
            get { return _GalaxyPanelUid; }
            set
            {
                if (_GalaxyPanelUid != value)
                {
                    _GalaxyPanelUid = value;
                    OnPropertyChanged(() => GalaxyPanelUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cpu Uid value. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid CpuUid
        {
            get { return _CpuUid; }
            set
            {
                if (_CpuUid != value)
                {
                    _CpuUid = value;
                    OnPropertyChanged(() => CpuUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Account Code value. </summary>
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
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Number value. </summary>
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
                    OnPropertyChanged(() => ClusterNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Number value. </summary>
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
                    OnPropertyChanged(() => PanelNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cpu Number value. </summary>
        ///
        /// <value> The CPU number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short CpuNumber
        {
            get { return _CpuNumber; }
            set
            {
                if (_CpuNumber != value)
                {
                    _CpuNumber = value;
                    OnPropertyChanged(() => CpuNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Serial Number value. </summary>
        ///
        /// <value> The serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                if (_SerialNumber != value)
                {
                    _SerialNumber = value;
                    OnPropertyChanged(() => SerialNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Ip Address value. </summary>
        ///
        /// <value> The IP address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string IpAddress
        {
            get { return _IpAddress; }
            set
            {
                if (_IpAddress != value)
                {
                    _IpAddress = value;
                    OnPropertyChanged(() => IpAddress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Default Event Logging On value. </summary>
        ///
        /// <value> True if default event logging on, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool DefaultEventLoggingOn
        {
            get { return _DefaultEventLoggingOn; }
            set
            {
                if (_DefaultEventLoggingOn != value)
                {
                    _DefaultEventLoggingOn = value;
                    OnPropertyChanged(() => DefaultEventLoggingOn);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Prevent Data Loading value. </summary>
        ///
        /// <value> True if prevent data loading, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool PreventDataLoading
        {
            get { return _PreventDataLoading; }
            set
            {
                if (_PreventDataLoading != value)
                {
                    _PreventDataLoading = value;
                    OnPropertyChanged(() => PreventDataLoading);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Prevent Flash Loading value. </summary>
        ///
        /// <value> True if prevent flash loading, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool PreventFlashLoading
        {
            get { return _PreventFlashLoading; }
            set
            {
                if (_PreventFlashLoading != value)
                {
                    _PreventFlashLoading = value;
                    OnPropertyChanged(() => PreventFlashLoading);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Last Log Index value. </summary>
        ///
        /// <value> The last log index. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int LastLogIndex
        {
            get { return _LastLogIndex; }
            set
            {
                if (_LastLogIndex != value)
                {
                    _LastLogIndex = value;
                    OnPropertyChanged(() => LastLogIndex);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Name value. </summary>
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
                    OnPropertyChanged(() => ClusterName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Name value. </summary>
        ///
        /// <value> The name of the panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PanelName
        {
            get { return _PanelName; }
            set
            {
                if (_PanelName != value)
                {
                    _PanelName = value;
                    OnPropertyChanged(() => PanelName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Type Code value. </summary>
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
                    OnPropertyChanged(() => ClusterTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Type Is Active value. </summary>
        ///
        /// <value> True if cluster type is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool ClusterTypeIsActive
        {
            get { return _ClusterTypeIsActive; }
            set
            {
                if (_ClusterTypeIsActive != value)
                {
                    _ClusterTypeIsActive = value;
                    OnPropertyChanged(() => ClusterTypeIsActive);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Credential Data Length value. </summary>
        ///
        /// <value> The length of the credential data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short CredentialDataLength
        {
            get { return _CredentialDataLength; }
            set
            {
                if (_CredentialDataLength != value)
                {
                    _CredentialDataLength = value;
                    OnPropertyChanged(() => CredentialDataLength);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Location value. </summary>
        ///
        /// <value> The panel location. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PanelLocation
        {
            get { return _PanelLocation; }
            set
            {
                if (_PanelLocation != value)
                {
                    _PanelLocation = value;
                    OnPropertyChanged(() => PanelLocation);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Model Type Code value. </summary>
        ///
        /// <value> The panel model type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PanelModelTypeCode
        {
            get { return _PanelModelTypeCode; }
            set
            {
                if (_PanelModelTypeCode != value)
                {
                    _PanelModelTypeCode = value;
                    OnPropertyChanged(() => PanelModelTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Panel Model Is Active value. </summary>
        ///
        /// <value> True if panel model is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool PanelModelIsActive
        {
            get { return _PanelModelIsActive; }
            set
            {
                if (_PanelModelIsActive != value)
                {
                    _PanelModelIsActive = value;
                    OnPropertyChanged(() => PanelModelIsActive);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cpu Is Active value. </summary>
        ///
        /// <value> True if CPU is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool CpuIsActive
        {
            get { return _CpuIsActive; }
            set
            {
                if (_CpuIsActive != value)
                {
                    _CpuIsActive = value;
                    OnPropertyChanged(() => CpuIsActive);
                }
            }
        }

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        ///
        /// <value> The site UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        ///
        /// <value> The site UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid SiteUid
        {
            get { return _siteUid; }
            set
            {
                if (_siteUid != value)
                {
                    _siteUid = value;
                    OnPropertyChanged(() => SiteUid, true);
                }
            }
        }

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
                    OnPropertyChanged(() => SiteName, true);
                }
            }
        }

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
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public string EntityName
        {
            get { return _EntityName; }
            set
            {
                if (_EntityName != value)
                {
                    _EntityName = value;
                    OnPropertyChanged(() => EntityName, true);
                }
            }
        }

        [DataMember]

        public string EntityType
        {
            get { return _EntityType; }
            set
            {
                if (_EntityType != value)
                {
                    _EntityType = value;
                    OnPropertyChanged(() => EntityType, true);
                }
            }
        }

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the time zone. </summary>
        ///
        /// <value> The identifier of the time zone. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string TimeZoneId
        {
            get { return _TimeZoneId; }
            set
            {
                if (_TimeZoneId != value)
                {
                    _TimeZoneId = value;
                    OnPropertyChanged(() => TimeZoneId, true);
                }
            }
        }

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the alert event acknowledge. </summary>
        ///
        /// <value> Information describing the alert event acknowledge. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<GalaxyPanel_GetAlertEventAcknowledgeData> AlertEventAcknowledgeData
        {
            get { return _AlertEventAcknowledgeData; }
            set
            {
                if (_AlertEventAcknowledgeData != value)
                {
                    _AlertEventAcknowledgeData = value;
                    OnPropertyChanged(() => AlertEventAcknowledgeData, true);
                }
            }
        }

        private bool _isConnected;

        [DataMember]
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged(() => IsConnected, false);
                }
            }
        }

        #endregion
    }
}
