using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class MercScpGroupMercScpMinimal : DbObjectBase
    {
        public MercScpGroupMercScpMinimal()
        {
            MercScps = new HashSet<MercScpMinimal>();
        }

        [DataMember]
        public System.Guid MercScpGroupUid { get; set; }

        [DataMember]
        public ICollection<MercScpMinimal> MercScps { get; set; }

    }
}
