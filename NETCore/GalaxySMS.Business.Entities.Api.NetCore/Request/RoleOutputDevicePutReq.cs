using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleOutputDevicePutReq //: PutRequestBase
    {
        //[Required]
        //public System.Guid RoleOutputDeviceUid { get; set; }

//        public System.Guid RoleId { get; set; }

        [Required]
        //public System.Guid OutputDeviceUid { get; set; }
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        //public string OutputName { get; set; }
        //public ICollection<RoleOutputDevicePermission> RoleOutputDevicePermissions { get; set; }

    }
}
