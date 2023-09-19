using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleSiteReq
    {
        public RoleSiteReq()
        {
            Clusters = new HashSet<RoleClusterReq>();
            IncludeAllClusters = true;
        }

        [Required]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        //public System.Guid SiteUid { get; set; }
        //public string SiteName { get; set; }

        public System.Boolean IncludeAllClusters { get; set; }


        //public ICollection<RoleSitePermission> RoleSitePermissions { get; set; }

        public ICollection<RoleClusterReq> Clusters { get; set; }
    }
}
