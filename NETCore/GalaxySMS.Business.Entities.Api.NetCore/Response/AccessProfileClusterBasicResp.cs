using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
        public partial class AccessProfileClusterBasicResp
    {
//        public System.Guid AccessProfileClusterUid { get; set; }

//        public System.Guid AccessProfileUid { get; set; }

        public System.Guid ClusterUid { get; set; }

        public string ClusterName { get; set; }

        public ICollection<AccessProfileAccessGroupBasicResp> AccessProfileAccessGroups{ get; set; }public ICollection<AccessProfileInputOutputGroupBasicResp> AccessProfileInputOutputGroups{ get; set; }
    }
}
