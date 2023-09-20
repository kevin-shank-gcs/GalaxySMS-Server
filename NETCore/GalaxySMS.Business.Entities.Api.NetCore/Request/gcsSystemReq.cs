using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class SystemReq
    {

        [Required]
        public System.Guid SystemId { get; set; }

        public string License { get; set; }

        public string PublicKey { get; set; }

        [Required]
        [StringLength(65)]
        public string SystemName { get; set; }

        public string CompanyName { get; set; }

        public string CompanyEmail { get; set; }

        public string SupportCompany { get; set; }

        public string SupportContact { get; set; }

        public string SupportPhone { get; set; }

        public string SupportEmail { get; set; }

        public string SupportUrl { get; set; }

        public byte[] SupportImage { get; set; }

        public byte[] SystemImage { get; set; }

        //public License TheLicense { get; set; }

        public Version SystemVersion { get; set; }
    }
}
