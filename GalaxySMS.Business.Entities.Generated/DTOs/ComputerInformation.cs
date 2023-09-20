using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{

    public class ComputerInformation : EntityBase
    {

        public ComputerInformation()
        {
            IPAddresses = new HashSet<string>();
            MachineName = string.Empty;
            DomainName = string.Empty;
        }

        public string MachineName { get; set; }
        public string DomainName { get; set; }

        public ICollection<string> IPAddresses { get; set; }
    }
}
