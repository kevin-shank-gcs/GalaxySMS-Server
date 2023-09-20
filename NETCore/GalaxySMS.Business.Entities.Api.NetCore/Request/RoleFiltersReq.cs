using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleFiltersReq
    {
        public RoleFiltersReq()
        {
            //Clusters = new HashSet<RoleClusterReq>();
            Regions = new HashSet<RoleRegionReq>();
            IncludeAllRegions = true;
            IncludeAllClusters = true;
            IncludeAllSites = true;
            IncludeAllAccessPortals = true;
            IncludeAllInputDevices = true;
            IncludeAllOutputDevices = true;
            IncludeAllInputOutputGroups = true;
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
        //public ICollection<RoleClusterReq> Clusters { get; set; }
        public ICollection<RoleRegionReq> Regions { get; set; }

    }
}
