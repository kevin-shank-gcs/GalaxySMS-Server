using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserEntityReq
    {
        [Required]
        public System.Guid UserEntityId { get; set; }

        [Required]
        public System.Guid UserId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        public ICollection<UserEntityApplicationRoleReq> gcsUserEntityApplicationRoles { get; set; }

    }
}
