using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{

    public partial class RoleRegionPutReq //: PutRequestBase
    {
        public RoleRegionPutReq()
        {
            Sites = new HashSet<RoleSitePutReq>();
            IncludeAllSites = true;

        }

        [Required]
        //public System.Guid RegionUid { get; set; }

        public Guid Id { get; set; }
//        public string RegionName { get; set; }
        public string Name { get; set; }
        public System.Boolean IncludeAllSites { get; set; }

        //public ICollection<RoleRegionPermission> RoleRegionPermissions { get; set; }

        public ICollection<RoleSitePutReq> Sites { get; set; }

    }
}
