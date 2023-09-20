using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class StateProvinceBasicResp
    {
        public System.Guid StateProvinceUid { get; set; }
//        public System.Guid CountryUid { get; set; }

        public string StateProvinceCode { get; set; }

        public string StateProvinceName { get; set; }

    }
}
