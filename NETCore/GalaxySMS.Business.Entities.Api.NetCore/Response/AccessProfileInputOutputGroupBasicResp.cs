using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class AccessProfileInputOutputGroupBasicResp
    {
//        public System.Guid AccessProfileInputOutputGroupUid { get; set; }
//        public System.Guid AccessProfileClusterUid { get; set; }
        public System.Guid InputOutputGroupUid { get; set; }
        public short OrderNumber { get; set; }
        public int InputOutputGroupNumber { get; set; }

        public string InputOutputGroupName { get; set; }

    }
}
