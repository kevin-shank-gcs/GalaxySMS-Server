using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class gcsLargeObjectStoragePostReq
    {
        public System.Guid Uid { get; set; }
        public Nullable<System.Guid> EntityId { get; set; }

        [Required]
        [StringLength(255)]
        public string UniqueTag { get; set; }

        [Required]
        [StringLength(255)]
        public string DataType { get; set; }

        [StringLength(4000)]
        public string TextData { get; set; }

        public byte[] FileStreamData { get; set; }

        public byte[] BlobData { get; set; }
        //public string InsertName { get; set; }
        //public System.DateTimeOffset InsertDate { get; set; }
        //public string UpdateName { get; set; }
        //public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        //public Nullable<short> ConcurrencyValue { get; set; }

        //public gcsEntity gcsEntity { get; set; }

    }
}
