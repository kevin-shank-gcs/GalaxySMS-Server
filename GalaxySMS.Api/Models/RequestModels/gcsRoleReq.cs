using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleReq
    {

        [Required]
        public System.Guid RoleId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        [Required]
        [StringLength(65)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(255)]
        public string RoleDescription { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

        public bool IsAdministratorRole { get; set; }

        public ICollection<EntityApplicationRoleReq> gcsEntityApplicationRoles { get; set; }

        public ICollection<RolePermissionReq> RolePermissions { get; set; }

    }
}
