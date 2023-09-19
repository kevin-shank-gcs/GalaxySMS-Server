////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TestData.cs
//
// summary:	Implements the test data class
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

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A test data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class TestData : ObjectBase, IIdentifiableEntity
    {
        /// <summary>   Information describing the galaxy CPU. </summary>
        private GalaxyCpuInformation _galaxyCpuInformation;
        /// <summary>   The description. </summary>
        private string _description;
        /// <summary>   The remote IP endpoint. </summary>
        private string _remoteIpEndpoint;
        /// <summary>   The local IP endpoint. </summary>
        private string _localIpEndpoint;
        /// <summary>   True if this TestData is connected. </summary>
        private bool _isConnected;
        /// <summary>   True if this TestData is authenticated. </summary>
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

        //[DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueId
        {
            get
            {
                if (GalaxyCpuInformation == null)
                    return string.Empty;
                else
                    return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId);
            }
        }

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
                }
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
        /// <summary>   Gets or sets a value indicating whether this TestData is connected. </summary>
        ///
        /// <value> True if this TestData is connected, false if not. </value>
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
        /// Gets or sets a value indicating whether this TestData is authenticated.
        /// </summary>
        ///
        /// <value> True if this TestData is authenticated, false if not. </value>
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TestData()
        {
            GalaxyCpuInformation = new GalaxyCpuInformation();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    The TestData to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TestData(TestData c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformation(c.GalaxyCpuInformation);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int EntityId
        {
            get
            {
                return 0;
            }
            set
            {

            }
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
                {
                    if (Guid.TryParse(GalaxyCpuInformation.InstanceGuid, out g))
                        return g;
                }
                return g;
            }
            set { }
        }
    }
}
