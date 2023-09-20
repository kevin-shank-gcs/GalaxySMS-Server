using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{    
    public partial class CommandScriptBasicResp
    {
        public System.Guid CommandScriptUid { get; set; }
        public System.Guid EntityId { get; set; }
        public string CommandScriptName { get; set; }
        public string Notes { get; set; }
    }
}
