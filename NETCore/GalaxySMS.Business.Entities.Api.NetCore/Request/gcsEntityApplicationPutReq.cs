
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityApplicationPutReq:PutRequestBase
    {
        [Required]
        public System.Guid EntityApplicationId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        public ICollection<EntityApplicationRolePutReq> gcsEntityApplicationRoles { get; set; }

    }
}
