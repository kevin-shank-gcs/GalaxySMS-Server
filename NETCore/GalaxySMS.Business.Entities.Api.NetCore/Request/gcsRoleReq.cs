using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RoleReq
    {
        public RoleReq()
        {
            //PermissionIds = new HashSet<Guid>();
            //AccessPortalIds = new HashSet<Guid>();
            //InputDeviceIds = new HashSet<Guid>();
            //OutputDeviceIds = new HashSet<Guid>();
            //ClusterIds = new HashSet<Guid>();
            //InputOutputGroupIds = new HashSet<Guid>();
        }

        [Required]
        public System.Guid RoleId { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        [StringLength(65)]
        public string RoleName { get; set; }

        //[Required]
        [StringLength(255)]
        public string RoleDescription { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

        public bool IsAdministratorRole { get; set; }

        //public ICollection<EntityApplicationRoleReq> gcsEntityApplicationRoles { get; set; }

        //public ICollection<RolePermissionReq> gcsRolePermissions { get; set; }
        //[Required]
        public ICollection<RolePermissionReq> RolePermissions { get; set; }

        public RoleFiltersReq DeviceFilters { get; set; }
        ////[Required]
        //public ICollection<Guid> AccessPortalIds { get; set; }
        ////[Required]
        //public ICollection<Guid> InputDeviceIds { get; set; }
        ////[Required]
        //public ICollection<Guid> OutputDeviceIds { get; set; }
        ////[Required]
        //public ICollection<Guid> ClusterIds { get; set; }
        ////[Required]
        //public ICollection<Guid> InputOutputGroupIds { get; set; }
        public AddRoleOptions Options { get; set; } = new();

    }

    public class AddRoleOptions
    {
        public bool AddToExistingUsers { get; set; } = false;
    }
}
