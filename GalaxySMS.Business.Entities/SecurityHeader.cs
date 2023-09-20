using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class SecurityHeader : EntityBase
    {
        [DataMember]
        public Guid GalaxyUserSessionGuid { get; set; }

        [DataMember]
        public string CurrentWindowsUserName { get; set; }

    }
}
