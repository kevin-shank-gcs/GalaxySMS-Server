using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class PermissionCategoryReq
    {

        [Required]
        public System.Guid PermissionCategoryId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        [Required]
        [StringLength(65)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(255)]
        public string PermissionCategoryDescription { get; set; }

        public bool IsSystemCategory { get; set; }

        public bool IsEntityCategory { get; set; }

        public ICollection<PermissionReq> Permissions { get; set; }
    }
}
