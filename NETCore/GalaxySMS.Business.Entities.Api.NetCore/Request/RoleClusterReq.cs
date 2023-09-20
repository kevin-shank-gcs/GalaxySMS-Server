using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleClusterReq
    {
        public RoleClusterReq()
        {
            AccessPortals = new HashSet<RoleAccessPortalReq>();
            InputDevices = new HashSet<RoleInputDeviceReq>();
            InputOutputGroups = new HashSet<RoleInputOutputGroupReq>();
            OutputDevices = new HashSet<RoleOutputDeviceReq>();
            IncludeAllOutputDevices = true;
            IncludeAllAccessPortals = true;
            IncludeAllInputDevices = true;
            IncludeAllInputOutputGroups = true;
        }

        [Required]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        //public System.Guid ClusterUid { get; set; }
        //public string ClusterName { get; set; }

        public System.Boolean IncludeAllAccessPortals { get; set; }

        public System.Boolean IncludeAllInputOutputGroups { get; set; }

        public System.Boolean IncludeAllInputDevices { get; set; }
        public System.Boolean IncludeAllOutputDevices { get; set; }

        //public ICollection<RoleClusterPermission> RoleClusterPermissions { get; set; }

        public ICollection<RoleAccessPortalReq> AccessPortals { get; set; }

        public ICollection<RoleInputOutputGroupReq> InputOutputGroups { get; set; }

        public ICollection<RoleInputDeviceReq> InputDevices { get; set; }

        public ICollection<RoleOutputDeviceReq> OutputDevices { get; set; }


    }
}
