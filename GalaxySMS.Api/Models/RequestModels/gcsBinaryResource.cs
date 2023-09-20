using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class BinaryResourceReq
    {
        [Required]
        public System.Guid BinaryResourceUid { get; set; }

        ////[Required]
        //public string DataType { get; set; }

        ////[Required]
        //public string Category { get; set; }

        ////[Required]
        //public string Tag { get; set; }

        [Required]
        public byte[] BinaryResource { get; set; }

        public bool HasBeenModified { get; set; }

        [Required]
        public Nullable<short> ConcurrencyValue { get; set; }


    }
}
