using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleInputOutputGroupReq
    {
        [Required]
        //public System.Guid InputOutputGroupUid { get; set; }
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        //public string InputOutputGroupName { get; set; }

        //public ICollection<RoleInputOutputGroupPermission> RoleInputOutputGroupPermissions { get; set; }

    }
}
