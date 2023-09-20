using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleRegionReq
    {
        public RoleRegionReq()
        {
            Sites = new HashSet<RoleSiteReq>();
            IncludeAllSites = true;
        }

        [Required]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        //public System.Guid RegionUid { get; set; }
        //public string RegionName { get; set; }

        public System.Boolean IncludeAllSites { get; set; }


        //public ICollection<RoleRegionPermission> RoleRegionPermissions { get; set; }

        public ICollection<RoleSiteReq> Sites { get; set; }
    }
}
