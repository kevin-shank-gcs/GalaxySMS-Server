using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class ApplicationReq
    {
        [Required]
        public System.Guid ApplicationId { get; set; }

        public Nullable<System.Guid> LanguageId { get; set; }

        public Nullable<System.Guid> SystemRoleId { get; set; }

        [Required]
        [StringLength(65)]
        public string ApplicationName { get; set; }

        [Required]
        [StringLength(255)]
        public string ApplicationDescription { get; set; }

        public ICollection<UserSettingReq> gcsUserSettings { get; set; }

        public ICollection<EntityApplicationReq> gcsEntityApplications { get; set; }

        public ICollection<PermissionCategoryReq> gcsPermissionCategories { get; set; }

    }
}
