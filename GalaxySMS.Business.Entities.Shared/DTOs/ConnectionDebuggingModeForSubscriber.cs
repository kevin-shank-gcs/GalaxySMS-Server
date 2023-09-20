using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ConnectionGuid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool EnableDebugging { get; set; }
    }
}
