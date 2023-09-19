using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class ApplicationRoleFilterData
    {
        public ApplicationRoleFilterData()
        {
            EntityFilters = new HashSet<gcsEntityFilterData>();
        }

        [DataMember]
        public ICollection<gcsEntityFilterData> EntityFilters { get; set; }

    }

}



