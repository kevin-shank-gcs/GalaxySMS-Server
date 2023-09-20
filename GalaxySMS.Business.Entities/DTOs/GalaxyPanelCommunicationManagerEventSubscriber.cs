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

namespace GalaxySMS.Business.Entities
{

    [DataContract]
    public class GalaxyPanelCommunicationManagerEventSubscriber : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public string ClientName { get; set; }
    }
}
