////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ConnectionDebugModeForSubscriber.cs
//
// summary:	Implements the connection debug mode for subscriber class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A connection debugging mode for subscriber. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ConnectionDebuggingModeForSubscriber : GalaxyPanelCommunicationManagerEventSubscriber
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionDebuggingModeForSubscriber() : base()
        {
            ConnectionGuid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The ConnectionDebuggingModeForSubscriber to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionDebuggingModeForSubscriber(GalaxyPanelCommunicationManagerEventSubscriber o) : base(o)
        {
            if (o != null)
            {
                ConnectionGuid = Guid.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The ConnectionDebuggingModeForSubscriber to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionDebuggingModeForSubscriber(ConnectionDebuggingModeForSubscriber o)
            : base(o)
        {
            if (o != null)
            {
                ConnectionGuid = o.ConnectionGuid;
                EnableDebugging = o.EnableDebugging;
            }
        }

        /// <summary>   Unique identifier for the connection. </summary>
        private Guid _connectionGuid;
        /// <summary>   True to enable, false to disable the debugging. </summary>
        private bool _enableDebugging;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the connection. </summary>
        ///
        /// <value> Unique identifier of the connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ConnectionGuid
        {
            get { return _connectionGuid; }
            set
            {
                if (_connectionGuid != value)
                {
                    _connectionGuid = value;
                    OnPropertyChanged(() => ConnectionGuid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the debugging is enabled. </summary>
        ///
        /// <value> True if enable debugging, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool EnableDebugging
        {
            get { return _enableDebugging; }
            set
            {
                if (_enableDebugging != value)
                {
                    _enableDebugging = value;
                    OnPropertyChanged(() => EnableDebugging);
                }
            }
        }
    }
}
