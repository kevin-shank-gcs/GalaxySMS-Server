using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{        
    public partial class AccessProfileBasicResp
    {
        public System.Guid AccessProfileUid { get; set; }
        public System.Guid EntityId { get; set; }
        public string AccessProfileName { get; set; }
        public string Comments { get; set; }

        public ICollection<AccessProfileClusterBasicResp> AccessProfileClusters { get; set; }

        public AccessProfileCounts Counts { get; set; }

    }
}
