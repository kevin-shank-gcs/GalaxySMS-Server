using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class PersonPhotoUploadReq
    {
        //    [Required]
        public System.Guid PersonUid { get; set; }

        // Optional. This will default to false if omitted, but if the photo is the first photo for a person, it will be set to true for the first photo inserted
        public bool? IsDefault { get; set; }

        // Can be used to identify a specific photo by text value. May be useful when multiple photos are involved.
        [StringLength(65)]
        public string Tag { get; set; }

        [Required]
        //[ModelBinder(Name = "PhotoUploadForm[photoFile]")]
        //public IFormFile PhotoUploadForm { get; set; }
        //       [ModelBinder(Name = "PhotoFile")]
        public IFormFile PhotoFile { get; set; }

    }
}
