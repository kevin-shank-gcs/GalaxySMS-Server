using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class gcsApplicationSettingPostReq
    {

        //public System.Guid ApplicationSettingId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingKey { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingValue { get; set; }

        //[Required]
        [StringLength(255)]
        public string SettingDescription { get; set; }

        public bool IsActive { get; set; }


    }
    
    public partial class gcsApplicationSettingPutReq:PutRequestBase
    {

        [Required]
        public System.Guid ApplicationSettingId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingKey { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingValue { get; set; }

        //[Required]
        [StringLength(255)]
        public string SettingDescription { get; set; }

        public bool IsActive { get; set; }

    }
}
