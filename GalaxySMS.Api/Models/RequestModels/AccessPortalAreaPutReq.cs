using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessPortalAreaPutReq : PutRequestBase
    {
        //public System.Guid AccessPortalAreaUid { get; set; }


        //public System.Guid AccessPortalUid { get; set; }


        public System.Guid AreaUid { get; set; }


        public System.Guid AccessPortalAreaTypeUid { get; set; }

    }
}
