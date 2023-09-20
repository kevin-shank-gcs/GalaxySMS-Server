using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class SitePutReq : PutRequestBase
    {

        [Required]
        public System.Guid SiteUid { get; set; }

        [Required]
        public System.Guid RegionUid { get; set; }

        [Required]
        [StringLength(100)]
        public string SiteName { get; set; }

        [Required]
        [StringLength(30)]
        public string SiteId { get; set; }

        public Nullable<double> Longitude { get; set; }

        public Nullable<double> Latitude { get; set; }

        public System.Guid EntityId { get; set; }

        public BinaryResourceReq gcsBinaryResource { get; set; }

        public AddressPutReq Address { get; set; }

        public ICollection<Guid> EntityIds { get; set; }
 
        public ICollection<Guid> RoleIds { get; set; }


        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

    }
}
