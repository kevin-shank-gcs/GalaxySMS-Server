using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserEntityApplicationRoleReq
    {
        [Required]
        public System.Guid UserEntityApplicationRoleId { get; set; }

        [Required]
        public System.Guid UserEntityId { get; set; }

        [Required]
        public System.Guid EntityApplicationRoleId { get; set; }

    }
}
