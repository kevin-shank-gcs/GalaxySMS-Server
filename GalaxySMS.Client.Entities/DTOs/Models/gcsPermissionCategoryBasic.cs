using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsPermissionCategoryBasic
    {

        [DataMember]
        public System.Guid PermissionCategoryId { get; set; }

        [DataMember]
        public System.Guid ApplicationId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public string PermissionCategoryDescription { get; set; }

        [DataMember]
        public bool IsSystemCategory { get; set; }

        [DataMember]
        public bool IsEntityCategory { get; set; }

        [DataMember]
        public ICollection<gcsPermissionBasic> Permissions { get; set; }
    }
}
