using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

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
    public class ComputerInformation //: EntityBase
    {

        public ComputerInformation() //: base()
        {
            IPAddresses = new HashSet<string>();
            MachineName = string.Empty;
            DomainName = string.Empty;
        }

        public ComputerInformation(ComputerInformation o) //: base(o)
        {
            IPAddresses = new HashSet<string>();
            MachineName = string.Empty;
            DomainName = string.Empty;
            if (o != null)
            {
                this.MachineName = o.MachineName;
                this.DomainName = o.DomainName;
                if (o.IPAddresses != null)
                    this.IPAddresses = o.IPAddresses.ToCollection();
            }

        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string MachineName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DomainName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<string> IPAddresses { get; set; }
    }
}
