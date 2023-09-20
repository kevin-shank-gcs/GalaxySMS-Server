using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleAccessPortalPutReq //: PutRequestBase
    {

        //[Required]
        //public System.Guid RoleAccessPortalUid { get; set; }

        //        public System.Guid RoleId { get; set; }

        [Required]
        //public System.Guid AccessPortalUid { get; set; }
        public Guid Id { get; set; }

        //public string PortalName { get; set; }
        public string Name { get; set; }
//        public ICollection<RoleAccessPortalPermission> RoleAccessPortalPermissions { get; set; }

    }
}
