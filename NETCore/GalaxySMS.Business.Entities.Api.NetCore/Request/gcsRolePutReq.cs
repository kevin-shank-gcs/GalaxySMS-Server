using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RolePutReq : PutRequestBase
    {
        public RolePutReq()
        {
            RolePermissions = new HashSet<RolePermissionPutReq>();
            //AccessPortals = new HashSet<RoleAccessPortalPutReq>();
            //InputDevices = new HashSet<RoleInputDevicePutReq>();
            //OutputDevices = new HashSet<RoleOutputDevicePutReq>();
            //Clusters = new HashSet<RoleClusterPutReq>();
            //InputOutputGroups = new HashSet<RoleInputOutputGroupPutReq>();

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

        //public ICollection<EntityApplicationRolePutReq> gcsEntityApplicationRoles { get; set; }

        //[Required]
        public ICollection<RolePermissionPutReq> RolePermissions { get; set; }
        public RoleFiltersPutReq DeviceFilters { get; set; }
        ////[Required]
        //public ICollection<RoleAccessPortalPutReq> AccessPortals { get; set; }
        ////[Required]
        //public ICollection<RoleInputOutputGroupPutReq> InputOutputGroups { get; set; }

        ////[Required]
        //public ICollection<RoleClusterPutReq> Clusters { get; set; }

        ////[Required]
        //public ICollection<RoleInputDevicePutReq> InputDevices { get; set; }

        ////[Required]
        //public ICollection<RoleOutputDevicePutReq> OutputDevices { get; set; }

    }
}
