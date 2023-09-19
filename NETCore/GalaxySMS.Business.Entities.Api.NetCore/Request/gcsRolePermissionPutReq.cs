using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RolePermissionPutReq//: PutRequestBase
    {
        //[Required]
        //public System.Guid RolePermissionId { get; set; }

        //[Required]
        //public System.Guid RoleId { get; set; }

        [Required]
        public System.Guid Id { get; set; }

        public string Name { get; set; }
//        public System.Guid PermissionId { get; set; }

    }
}
