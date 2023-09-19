using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{

    public partial class RoleSitePutReq //: PutRequestBase
    {
        public RoleSitePutReq()
        {
            Clusters = new HashSet<RoleClusterPutReq>();
            IncludeAllClusters = true;

        }
        //[Required]
        //public System.Guid RoleClusterUid { get; set; }

        //        public System.Guid RoleId { get; set; }

        [Required]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        //public System.Guid SiteUid { get; set; }

        //public string SiteName { get; set; }
        //        public ICollection<RoleClusterPermission> RoleClusterPermissions { get; set; }

        public System.Boolean IncludeAllClusters { get; set; }

        //public ICollection<RoleSitePermission> RoleClusterPermissions { get; set; }

        public ICollection<RoleClusterPutReq> Clusters { get; set; }

    }
}
