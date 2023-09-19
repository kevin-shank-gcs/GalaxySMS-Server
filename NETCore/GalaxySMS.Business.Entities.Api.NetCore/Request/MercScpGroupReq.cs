using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class MercScpGroupReq
    {
        public System.Guid MercScpGroupUid { get; set; }
        public System.Guid EntityId { get; set; }
        public System.Guid SiteUid { get; set; }

        [Required]
        [StringLength(65)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        [Range(60000, int.MaxValue)] public int NumberOfTransactions { get; set; } = 60000;

        [Range(1, 8)] public short NumberOfOperatingModes { get; set; } = 1;

        [Range(0, 1)] public short OperatingModeType { get; set; } = 0;

        public bool AllowConnection { get; set; } = true;
        //public ICollection<Guid> EntityIds { get; set; }

        //public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

        public ICollection<Guid> RoleIds { get; set; }

        public ICollection<Guid> DisabledCommandIds { get; set; }
    }
}
