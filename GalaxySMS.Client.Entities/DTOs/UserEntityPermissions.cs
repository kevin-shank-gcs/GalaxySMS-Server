using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class UserEntityPermissions
    {
        [DataMember] public Guid CurrentEntityId { get; set; }

        [DataMember] public List<string> RolePermissions { get; set; }
    }
}
