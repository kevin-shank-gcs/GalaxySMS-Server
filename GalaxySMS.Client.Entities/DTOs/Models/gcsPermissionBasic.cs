using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsPermissionBasic
    {

        [DataMember]
        public System.Guid PermissionId { get; set; }

        [DataMember]
        public System.Guid PermissionCategoryId { get; set; }

        [DataMember]
        public System.Guid PermissionTypeId { get; set; }

        [DataMember]
        public string PermissionName { get; set; }

        [DataMember]
        public string PermissionDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Code { get; set; }
    }
}
