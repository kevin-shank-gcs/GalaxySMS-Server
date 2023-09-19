using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleFiltersPutReq : PutRequestBase
    {
        public RoleFiltersPutReq()
        {
            //Clusters = new HashSet<RoleClusterPutReq>();
            Regions = new HashSet<RoleRegionPutReq>();
            IncludeAllClusters = true;
            IncludeAllRegions = true;
            IncludeAllSites = true;
        }

        public bool IncludeAllRegions { get; set; }

        public bool IncludeAllSites { get; set; }

        //[Required]
        public bool IncludeAllClusters { get; set; }

        public bool IncludeAllAccessPortals { get; set; }

        public bool IncludeAllInputOutputGroups { get; set; }
        public bool IncludeAllInputDevices { get; set; }

        public bool IncludeAllOutputDevices { get; set; }

        //[Required]
        //public ICollection<RoleClusterPutReq> Clusters { get; set; }
        public ICollection<RoleRegionPutReq> Regions { get; set; }

    }
}
