using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class AccessProfileAccessGroupBasicResp
    {
//        public System.Guid AccessProfileAccessGroupUid { get; set; }

        public System.Guid AccessGroupUid { get; set; }

//        public System.Guid AccessProfileClusterUid { get; set; }

        public short OrderNumber { get; set; }

        public int AccessGroupNumber { get; set; }
        //   	public PersonClusterPermission PersonClusterPermission { get; set; }

        public string AccessGroupName { get; set; }

    }
}
