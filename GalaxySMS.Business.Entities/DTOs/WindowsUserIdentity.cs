using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Principal;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{

    public class WindowsUserIdentity : EntityBase
    {
        public WindowsUserIdentity()
        {
            Name = string.Empty;
            DomainName = string.Empty;
        }
        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }
        public string DomainName { get; set; }
    }
}
