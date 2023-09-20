using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserEntityPostReq
    {
        //[Required]
        //public System.Guid UserEntityId { get; set; }

        //[Required]
        //public System.Guid UserId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        public bool IsAdministrator { get; set; }
        public bool InheritParentRoles { get; set; }

        public ICollection<UserEntityRolePostReq> UserEntityRoles { get; set; }

    }
    //public partial class UserEntityPostReq
    //{
    //    //[Required]
    //    //public System.Guid UserEntityId { get; set; }

    //    //[Required]
    //    //public System.Guid UserId { get; set; }

    //    [Required]
    //    public System.Guid EntityId { get; set; }

    //    public ICollection<Guid> gcsUserEntityApplicationRoles { get; set; }

    //}

    public partial class UserEntityPutReq : PutRequestBase
    {
        //[Required]
        //public System.Guid UserEntityId { get; set; }

        //[Required]
        //public System.Guid UserId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }
        public string EntityName { get; set; }
        public bool IsAdministrator { get; set; }
        public bool InheritParentRoles { get; set; }
        public ICollection<UserEntityRolePutReq> UserEntityRoles { get; set; }

    }
}
