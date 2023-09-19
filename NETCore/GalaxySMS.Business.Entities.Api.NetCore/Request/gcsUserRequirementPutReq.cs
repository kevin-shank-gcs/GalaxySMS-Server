using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserRequirementPutReq : PutRequestBase
    {
        
        [Required]
        public System.Guid UserRequirementsId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        public bool PasswordCannotContainName { get; set; }

        public short PasswordMinimumLength { get; set; }

        public short PasswordMaximumLength { get; set; }

        public short PasswordMinimumChangeCharacters { get; set; }

        public short MinimumPasswordAge { get; set; }

        public short MaximumPasswordAge { get; set; }

        public short MaintainPasswordHistoryCount { get; set; }

        public short DefaultExpirationDays { get; set; }

        public short LockoutUserIfInactiveForDays { get; set; }

        public bool AllowPasswordChangeAttempt { get; set; }

        public short RequireLowerCaseLetterCount { get; set; }

        public short RequireUpperCaseLetterCount { get; set; }

        public short RequireNumericDigitCount { get; set; }

        public short RequireSpecialCharacterCount { get; set; }

        public bool UseCustomRegEx { get; set; }

        public string PasswordCustomRegEx { get; set; }

        public string RegularExpressionDescription { get; set; }

        public bool RequireTwoFactorAuthentication { get; set; }
    }
}
