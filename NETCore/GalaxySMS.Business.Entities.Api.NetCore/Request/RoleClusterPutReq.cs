using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{

    public partial class RoleClusterPutReq //: PutRequestBase
    {
        public RoleClusterPutReq()
        {
            AccessPortals = new HashSet<RoleAccessPortalPutReq>();
            InputDevices = new HashSet<RoleInputDevicePutReq>();
            InputOutputGroups = new HashSet<RoleInputOutputGroupPutReq>();
            OutputDevices = new HashSet<RoleOutputDevicePutReq>();
            IncludeAllOutputDevices = true;
            IncludeAllAccessPortals = true;
            IncludeAllInputDevices = true;
            IncludeAllInputOutputGroups = true;

        }
        //[Required]
        //public System.Guid RoleClusterUid { get; set; }

        //        public System.Guid RoleId { get; set; }

        [Required]
        //     public System.Guid ClusterUid { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
        //public string ClusterName { get; set; }
        //        public ICollection<RoleClusterPermission> RoleClusterPermissions { get; set; }

        public System.Boolean IncludeAllAccessPortals { get; set; }

        public System.Boolean IncludeAllInputOutputGroups { get; set; }

        public System.Boolean IncludeAllInputDevices { get; set; }
        public System.Boolean IncludeAllOutputDevices { get; set; }

        //public ICollection<RoleClusterPermission> RoleClusterPermissions { get; set; }

        public ICollection<RoleAccessPortalPutReq> AccessPortals { get; set; }

        public ICollection<RoleInputOutputGroupPutReq> InputOutputGroups { get; set; }

        public ICollection<RoleInputDevicePutReq> InputDevices { get; set; }

        public ICollection<RoleOutputDevicePutReq> OutputDevices { get; set; }

    }
}
