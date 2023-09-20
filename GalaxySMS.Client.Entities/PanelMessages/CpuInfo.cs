////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\CpuInfo.cs
//
// summary:	Implements the CPU information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the CPU connection. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class CpuConnectionInfo : ObjectBase, IIdentifiableEntity
    {
        /// <summary>   Information describing the galaxy CPU. </summary>
        private GalaxyCpuInformation _galaxyCpuInformation;
        /// <summary>   The description. </summary>
        private string _description;
        /// <summary>   The remote IP endpoint. </summary>
        private string _remoteIpEndpoint;
        /// <summary>   The local IP endpoint. </summary>
        private string _localIpEndpoint;
        /// <summary>   True if this CpuConnectionInfo is connected. </summary>
        private bool _isConnected;
        /// <summary>   True if this CpuConnectionInfo is authenticated. </summary>
        private bool _isAuthenticated;
        /// <summary>   The created date time. </summary>
        private DateTimeOffset _createdDateTime;
        /// <summary>   Handle of the socket. </summary>
        private string _socketHandle;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the galaxy CPU. </summary>
        ///
        /// <value> Information describing the galaxy CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyCpuInformation GalaxyCpuInformation
        {
            get { return _galaxyCpuInformation; }
            set
            {
                if (_galaxyCpuInformation != value)
                {
                    _galaxyCpuInformation = value;
                    OnPropertyChanged(() => GalaxyCpuInformation);
                }
            }
        }

        //	    [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueId { get { return string.Format("{0}:{1:D3}:{2:D3}:{3:D}", GalaxyCpuInformation.ClusterGroupId, GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the remote IP endpoint. </summary>
        ///
        /// <value> The remote IP endpoint. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String RemoteIpEndpoint
        {
            get { return _remoteIpEndpoint; }
            set
            {
                if (_remoteIpEndpoint != value)
                {
                    _remoteIpEndpoint = value;
                    OnPropertyChanged(() => RemoteIpEndpoint);
                    OnPropertyChanged(() => CpuUrl);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the CPU. </summary>
        ///
        /// <value> The CPU URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CpuUrl
        {
            get
            {
                if (RemoteIpEndpoint != null)
                    return string.Format("http://{0}", RemoteIpEndpoint.Split(':').FirstOrDefault());
                return string.Empty;
            }
            set
            {
                OnPropertyChanged(() => CpuUrl);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the local IP endpoint. </summary>
        ///
        /// <value> The local IP endpoint. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String LocalIpEndpoint
        {
            get { return _localIpEndpoint; }
            set
            {
                if (_localIpEndpoint != value)
                {
                    _localIpEndpoint = value;
                    OnPropertyChanged(() => LocalIpEndpoint);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this CpuConnectionInfo is connected.
        /// </summary>
        ///
        /// <value> True if this CpuConnectionInfo is connected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Boolean IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    OnPropertyChanged(() => IsConnected);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this CpuConnectionInfo is authenticated.
        /// </summary>
        ///
        /// <value> True if this CpuConnectionInfo is authenticated, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Boolean IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    OnPropertyChanged(() => IsAuthenticated);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the created date time. </summary>
        ///
        /// <value> The created date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset CreatedDateTime
        {
            get { return _createdDateTime; }
            set
            {
                _createdDateTime = value; if (_createdDateTime != value)
                {
                    _createdDateTime = value;
                    OnPropertyChanged(() => CreatedDateTime);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the handle of the socket. </summary>
        ///
        /// <value> The socket handle. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String SocketHandle
        {
            get { return _socketHandle; }
            set
            {
                if (_socketHandle != value)
                {
                    _socketHandle = value;
                    OnPropertyChanged(() => SocketHandle);
                }
            }
        }

        /// <summary>   Information describing the CPU database. </summary>
        private GalaxyCpuDatabaseInformation _CpuDatabaseInformation;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the CPU database. </summary>
        ///
        /// <value> Information describing the CPU database. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyCpuDatabaseInformation CpuDatabaseInformation
        {
            get { return _CpuDatabaseInformation; }
            set
            {
                if (_CpuDatabaseInformation != value)
                {
                    _CpuDatabaseInformation = value;
                    OnPropertyChanged(() => CpuDatabaseInformation, false);
                    OnPropertyChanged(() => ExistsInDatabase, false);
                    OnPropertyChanged(() => CredentialSizeSettingsMatch, false);
                }
            }
        }

        public bool CredentialSizeSettingsMatch
        {
            get
            {
                if (CpuDatabaseInformation == null)
                    return true;

                if (GalaxyCpuInformation?.InqueryReply == null)
                    return true;

                switch (GalaxyCpuInformation.InqueryReply.CardCodeFormat)
                {
                    case CredentialDataSize.Standard48Bits:
                        return CpuDatabaseInformation.CredentialDataLength == GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Standard48Bit;
                    case CredentialDataSize.Extended256Bits:
                        return CpuDatabaseInformation.CredentialDataLength == GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits;
                }
                return false;
            }

            set
            {
                OnPropertyChanged(() => CredentialSizeSettingsMatch, false);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the exists in database. </summary>
        ///
        /// <value> True if exists in database, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExistsInDatabase
        {
            get
            {
                if (CpuDatabaseInformation == null)
                    return false;
                return CpuDatabaseInformation.CpuUid != Guid.Empty;
            }
            set
            {
                OnPropertyChanged(() => ExistsInDatabase, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuConnectionInfo()
        {
            GalaxyCpuInformation = new GalaxyCpuInformation();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    The CpuConnectionInfo to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuConnectionInfo(CpuConnectionInfo c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformation(c.GalaxyCpuInformation);
            CpuDatabaseInformation = new GalaxyCpuDatabaseInformation(c.CpuDatabaseInformation);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the entity. </summary>
        ///
        /// <value> Unique identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid EntityGuid
        {
            get
            {
                Guid g = Guid.Empty;
                if (GalaxyCpuInformation != null)
                    Guid.TryParse(GalaxyCpuInformation.InstanceGuid, out g);
                return g;
            }
            set { }
        }
    }


    public class CpuConnection : ObjectBase
    {
        private CpuConnectionInfo _cpuConnectionInfo;
        private ObservableCollection<PanelLoadDataReply> _panelLoadDataReplies;
        private LoadDataToPanelSettings _loadDataSettings;

        public CpuConnection()
        {
            PanelLoadDataReplies = new ObservableCollection<PanelLoadDataReply>();
            LoadDataSettings = new LoadDataToPanelSettings();
        }

        public CpuConnectionInfo ConnectionInfo
        {
            get { return _cpuConnectionInfo; }
            set
            {
                if (_cpuConnectionInfo != value)
                {
                    _cpuConnectionInfo = value;
                    OnPropertyChanged(() => ConnectionInfo, true);
                }
            }
        }

        public ObservableCollection<PanelLoadDataReply> PanelLoadDataReplies
        {
            get { return _panelLoadDataReplies; }
            set
            {
                if (_panelLoadDataReplies != value)
                {
                    _panelLoadDataReplies = value;
                    OnPropertyChanged(() => PanelLoadDataReplies, false);
                }
            }
        }

        public LoadDataToPanelSettings LoadDataSettings
        {
            get { return _loadDataSettings; }
            set
            {
                if (_loadDataSettings != value)
                {
                    _loadDataSettings = value;
                    OnPropertyChanged(() => LoadDataSettings, false);
                }
            }
        }

    }
}
