using GalaxySMS.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;


namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityReq: IEntityValidation
    {

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        [StringLength(65)]
        public string EntityName { get; set; }

//        [Required]
        [StringLength(255)]
        public string EntityDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string EntityKey { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(65)]
        public string EntityType { get; set; }

        [Required]
        [Range(0, 65535)]
        [SwaggerSchema(ReadOnly = true)]
        public int ClusterGroupId { get; set; }

        //[Required]
        [StringLength(65)]
        public string TimeZoneId { get; set; }
        //public bool AutoMapTimeSchedules { get; set; }
        //public Nullable<System.Guid> BinaryResourceUid { get; set; }

        public Nullable<System.Guid> ParentEntityId { get; set; }

        //public ICollection<EntityApplicationReq> gcsEntityApplications { get; set; }

        public byte[] Image { get; set; }
        //public BinaryRes gcsBinaryResource { get; set; }
        //public string License { get; set; }

        //public string PublicKey { get; set; }

        public UserRequirementReq UserRequirements { get; set; }

        public AddEntityOptions Options { get; set; } = new();

    }

    public class AddEntityOptions
    {
        public bool AddToExistingUsers { get; set; } = true;
        public bool InheritParentEntityRoles { get; set; } = true;
        public bool IsEntityAdmin { get; set; } = false;
        public bool AutoMapSchedules { get; set; } = true;
    }

}
