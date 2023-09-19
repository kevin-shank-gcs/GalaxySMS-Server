using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class gcsSettingPostReq
    {
        //[Required]
        //public System.Guid SettingId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        [StringLength(65)]
        public string SettingGroup { get; set; }

        [Required]
        [StringLength(65)]
        public string SettingSubGroup { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingKey { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }
    }


    public partial class gcsSettingPutReq : PutRequestBase
    {
        [Required]
        public System.Guid SettingId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        [StringLength(65)]
        public string SettingGroup { get; set; }

        [Required]
        [StringLength(65)]
        public string SettingSubGroup { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingKey { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }

    }
}
