using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class PermissionReq
    {
        [Required]
        public System.Guid PermissionId { get; set; }

        [Required]
        public System.Guid PermissionCategoryId { get; set; }

        [Required]
        public System.Guid PermissionTypeId { get; set; }

        [Required]
        [StringLength(65)]
        public string PermissionName { get; set; }

        [Required]
        [StringLength(255)]
        public string PermissionDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
