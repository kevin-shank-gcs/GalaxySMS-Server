using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class PersonExpirationModeBasicResp
    {
        public System.Guid  PersonExpirationModeUid { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
        public PersonExpirationModes Code { get; set; }

        //        public Nullable<int> DisplayOrder { get; set; }
        //        public Nullable<bool> IsDefault { get; set; }
        //        public Nullable<bool> IsActive { get; set; }
    }
}
