using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityReq
    {

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        [StringLength(65)]
        public string EntityName { get; set; }

        [Required]
        [StringLength(255)]
        public string EntityDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string EntityKey { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }

        public string License { get; set; }

        public string PublicKey { get; set; }

        //public Nullable<System.Guid> BinaryResourceUid { get; set; }

        public Nullable<System.Guid> ParentEntityId { get; set; }

        public ICollection<EntityApplicationReq> gcsEntityApplications { get; set; }

        public byte[] Image {get;set;}
        //public BinaryRes gcsBinaryResource { get; set; }
        
        public UserRequirementReq UserRequirements { get; set; }

    }
}
