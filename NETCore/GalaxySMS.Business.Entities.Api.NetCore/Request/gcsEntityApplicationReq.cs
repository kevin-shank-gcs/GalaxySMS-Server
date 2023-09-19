
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityApplicationReq
    {
        //[Required]
        //public System.Guid EntityApplicationId { get; set; }

        //[Required]
        //public System.Guid EntityId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

//        public ICollection<EntityApplicationRoleReq> gcsEntityApplicationRoles { get; set; }
        public ICollection<Guid> RoleIds { get; set; }

    }
}
