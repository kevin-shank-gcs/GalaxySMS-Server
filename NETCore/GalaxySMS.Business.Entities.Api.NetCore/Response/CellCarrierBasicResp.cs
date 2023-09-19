using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{    
    public partial class CellCarrierBasicResp
    {
        public System.Guid CellCarrierUid { get; set; }
        public string CarrierName { get; set; }
        public string MMSSuffix { get; set; }
        public string SMSSuffix { get; set; }
    }
}
