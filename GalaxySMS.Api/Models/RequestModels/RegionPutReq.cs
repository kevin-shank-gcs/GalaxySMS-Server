using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RegionPutReq : PutRequestBase
    {
        [Required]
        public System.Guid RegionUid { get; set; }

        [Required]
        [StringLength(100)]
        public string RegionName { get; set; }

        [Required]
        [StringLength(30)]
        public string RegionId { get; set; }

        public System.Guid EntityId { get; set; }

        public BinaryResourceReq gcsBinaryResource { get; set; }

        public ICollection<Guid> EntityIds { get; set; }

        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }
    }
}
