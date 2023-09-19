using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{    
    public partial class GenderBasicResp
    {
        public System.Guid GenderUid { get; set; }
        public System.Guid EntityId { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public string GenderCode { get; set; }
    }
}
