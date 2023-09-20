using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityRolePutReq:PutRequestBase
    {
                
        //[Required]
        //public System.Guid EntityRoleId { get; set; }

        [Required]
        public System.Guid RoleId { get; set; }

        //[Required]
        //public System.Guid EntityApplicationId { get; set; }

        //public ICollection<UserEntityApplicationRole> gcsUserEntityApplicationRoles { get; set; }

    }
}
