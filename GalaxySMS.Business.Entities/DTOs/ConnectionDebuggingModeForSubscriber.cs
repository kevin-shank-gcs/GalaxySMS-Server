using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class ConnectionDebuggingModeForSubscriber : GalaxyPanelCommunicationManagerEventSubscriber
    {
        [DataMember]
        public Guid ConnectionGuid { get; set; }

        [DataMember]
        public bool EnableDebugging { get; set; }
    }
}
