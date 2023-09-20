using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class UserSettingReq
    {
        [Required]
        public System.Guid UserSettingId { get; set; }

        [Required]
        public System.Guid UserId { get; set; }

        public Nullable<System.Guid> ApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        
        [Required]
        [StringLength(255)]
        public string SettingKey { get; set; }
        
        [Required]
        [StringLength(255)]
        public string SettingValue { get; set; }
        
        [Required]
        [StringLength(255)]
        public string SettingDescription { get; set; }
    }
}
