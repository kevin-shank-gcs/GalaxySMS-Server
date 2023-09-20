using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserPostReq
    {
        //[Required]
        //public System.Guid UserId { get; set; }

        public Nullable<System.Guid> LanguageId { get; set; }

        [Required]
        public System.Guid PrimaryEntityId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public string UserInitials { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(1024)]
        public string UserPassword { get; set; }

        public bool ResetPasswordFlag { get; set; }

        public string UserTheme { get; set; }

        public bool IsLockedOut { get; set; }

        public bool IsActive { get; set; }

        public Nullable<System.DateTime> UserActivationDate { get; set; }

        public Nullable<System.DateTime> UserExpirationDate { get; set; }

        public bool ImportedFromActiveDirectory { get; set; }

        public Nullable<System.Guid> ActiveDirectoryObjectGuid { get; set; }

        public byte[] SecurityImage { get; set; }

        public byte[] UserImage { get; set; }

        [Required]
        //        [EmailAddress]
//        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        
        
        [StringLength(256)]
        public string Email { get; set; }

        //[Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public bool EmailConfirmed { get; set; }

        //public bool LockoutEnabled { get; set; }

        //[Required]
        //[EmailAddress]
        //[StringLength(256)]
        //public string NormalizedEmail { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string NormalizedUserName { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        //public string PasswordHash { get; set; }

        public ICollection<UserSettingPostReq> UserSettings { get; set; }

        public ICollection<UserEntityPostReq> UserEntities { get; set; }

        public DefaultUserEntityBehavior DefaultUserEntityOptions { get; set; } = new DefaultUserEntityBehavior();
    }

    public class DefaultUserEntityBehavior
    {
       public bool AddDescendantEntities { get; set; } 
       public bool InheritParentEntityRoles { get; set; }
       public bool IsEntityAdmin { get; set; }
       public bool DoNotAddDefaultRolesToUser { get; set; }
    }
}
