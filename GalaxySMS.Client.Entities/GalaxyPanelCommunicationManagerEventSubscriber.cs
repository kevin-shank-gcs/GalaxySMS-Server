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
    [DataContract]
    public class GalaxyPanelCommunicationManagerEventSubscriber : ObjectBase, IIdentifiableEntity
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

        [DataMember]
        public string ClientName
        {
            get { return _clientName; }
			set
			{
                if (_clientName != value)
				{
                    _clientName = value;
					OnPropertyChanged(() => ClientName);
				}
			}        
        }

        [DataMember]
        public Guid EntityGuid { get; set; }

        [DataMember]
        public int EntityId { get; set; }
    }
}
