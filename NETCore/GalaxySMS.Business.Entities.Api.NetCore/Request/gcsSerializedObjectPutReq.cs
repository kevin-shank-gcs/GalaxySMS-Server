using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class gcsSerializedObjectPutReq : PutRequestBase
    {
        [Required]
        public System.Guid SerializedObjectId { get; set; }

        [Required]
        public System.Guid ApplicationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Key { get; set; }

        [Required]
        //[StringLength(4000)]
        public string SerializedObject { get; set; }


    }
}
