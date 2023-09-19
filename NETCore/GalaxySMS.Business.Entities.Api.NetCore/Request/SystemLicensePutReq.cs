using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class SystemLicensePutReq
    {
        //[Required]
        public System.Guid SystemId { get; set; }

        [Required]
        public string License { get; set; }

        [Required]
        public string PublicKey { get; set; }
    }
}
