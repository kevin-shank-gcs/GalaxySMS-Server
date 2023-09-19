using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserEntityApplicationRolePostReq
    {
        //[Required]
        //public System.Guid UserEntityApplicationRoleId { get; set; }

        //[Required]
        //public System.Guid UserEntityId { get; set; }
        [Required]
        public System.Guid EntityApplicationRoleId { get; set; }
    }

    public partial class UserEntityApplicationRolePutReq:PutRequestBase
    {
        [Required]
        public System.Guid UserEntityApplicationRoleId { get; set; }

        //[Required]
        //public System.Guid UserEntityId { get; set; }

        [Required]
        public System.Guid EntityApplicationRoleId { get; set; }

    }

}
