using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserEntityRolePostReq
    {
        //[Required]
        //public System.Guid UserEntityApplicationRoleId { get; set; }

        //[Required]
        //public System.Guid UserEntityId { get; set; }
        [Required]
        public System.Guid RoleId { get; set; }
    }

    public partial class UserEntityRolePutReq:PutRequestBase
    {
        //[Required]
        //public System.Guid UserEntityRoleId { get; set; }

        //[Required]
        //public System.Guid UserEntityId { get; set; }

        [Required]
        public System.Guid RoleId { get; set; }

        public string RoleName { get; set; }
    }

}
