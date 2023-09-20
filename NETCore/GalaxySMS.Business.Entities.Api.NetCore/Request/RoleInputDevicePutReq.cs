using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleInputDevicePutReq //: PutRequestBase
    {
        //[Required]
        //public System.Guid RoleInputDeviceUid { get; set; }

//        public System.Guid RoleId { get; set; }

        [Required]
//      public System.Guid InputDeviceUid { get; set; }
        public System.Guid Id { get; set; }
        //        public ICollection<RoleInputDevicePermission> RoleInputDevicePermissions { get; set; }

        //public string InputName { get; set; }
        public string Name { get; set; }
    }
}
