using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;

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

    public class GalaxyPanelCommunicationManagerEventSubscriber : EntityBase, IIdentifiableEntity
    {
        private string _clientName;

        public GalaxyPanelCommunicationManagerEventSubscriber() : base()
        {
            EntityGuid = Guid.Empty;
        }

        public GalaxyPanelCommunicationManagerEventSubscriber(GalaxyPanelCommunicationManagerEventSubscriber o)
            : base()
        {
            if (o != null)
            {
                EntityGuid = o.EntityGuid;
                ClientName = o.ClientName;
                EntityId = o.EntityId;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClientName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int EntityId { get; set; }

    }
}
