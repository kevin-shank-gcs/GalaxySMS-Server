using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RolePermissionReq
    {
        //[Required]
        //public System.Guid RolePermissionId { get; set; }

        //[Required]
        //public System.Guid RoleId { get; set; }

        [Required]
        public System.Guid Id { get; set; }
//        public System.Guid PermissionId { get; set; }

    }
}
