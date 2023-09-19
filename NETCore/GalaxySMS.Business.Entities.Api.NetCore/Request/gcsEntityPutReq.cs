using GalaxySMS.Business.Entities.Api.NetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using Swashbuckle.AspNetCore.Annotations;


namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class EntityPutReq : PutRequestBase, IEntityValidation
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

        public bool AutoMapTimeSchedules { get; set; }

        //[Required]
        [Range(0, 65535)]
        [SwaggerSchema(ReadOnly = true)]
        public int ClusterGroupId { get; set; }
       
        //[Required]
        [StringLength(65)]
        public string TimeZoneId { get; set; }

        public Nullable<System.Guid> ParentEntityId { get; set; }
        //public ICollection<EntityApplicationPutReq> gcsEntityApplications { get; set; }
        public BinaryResourceReq gcsBinaryResource { get; set; }
        //public string License { get; set; }
        //public string PublicKey { get; set; }
        public UserRequirementPutReq UserRequirements { get; set; }
        public ICollection<RegionListItem> Regions { get; set; }
        //public ICollection<gcsRole> AllRoles { get; set; }

        public gcsEntityCounts Counts { get; set; }


    }
}


