using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveRoleExamples : IExamplesProvider<SaveParams<RoleReq>>
    {
        SaveParams<RoleReq> IExamplesProvider<SaveParams<RoleReq>>.GetExamples()
        {
            var data = new SaveParams<RoleReq>()
            {
                Data = new RoleReq()
                {
                    EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                    RoleName = "Execute Access Portal Commands",
                    RoleDescription = "Role 1 description",
                    IsActive = true,
                    RolePermissions = new List<RolePermissionReq>()
                    {
                        new RolePermissionReq()
                            {Id=Guid.Empty}
                    },
                    DeviceFilters = new RoleFiltersReq()
                    {
                        IncludeAllClusters = true,
                        Regions = new List<RoleRegionReq>()
                        {
                            new RoleRegionReq()
                            {
                                Sites = new List<RoleSiteReq>()
                                {
                                    new RoleSiteReq()
                                    {
                                        Clusters = new List<RoleClusterReq>()
                                        {
                                            new RoleClusterReq()
                                            {
                                                //ClusterUid = Guid.Empty,
                                                Id = Guid.Empty,
                                                IncludeAllAccessPortals = true,
                                                IncludeAllInputDevices = true,
                                                IncludeAllOutputDevices = true,
                                                IncludeAllInputOutputGroups = true,
                                                AccessPortals = new List<RoleAccessPortalReq>()
                                                {
                                                    new RoleAccessPortalReq()
                                                    {
                                                        Id = GalaxySMS.Common.Constants.ClusterLedBehaviorIds
                                                            .SteadyHigh,
                                                    }
                                                },
                                                InputDevices = new List<RoleInputDeviceReq>()
                                                {
                                                    new RoleInputDeviceReq()
                                                    {
                                                    }
                                                },
                                                OutputDevices = new List<RoleOutputDeviceReq>()
                                                {
                                                    new RoleOutputDeviceReq()
                                                    {
                                                    }
                                                },
                                                InputOutputGroups = new List<RoleInputOutputGroupReq>()
                                                {
                                                    new RoleInputOutputGroupReq()
                                                    {
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //gcsRolePermissions = new List<RolePermissionReq>(),
                    //gcsEntityApplicationRoles = new List<EntityApplicationRoleReq>()
                }
            };
            //data.Data.PermissionIds.Add(Guid.Empty);

            return data;
        }
    }

    public class SaveApiEntitiesRoleExamples : IExamplesProvider<SaveParams<RolePutReq>>
    {
        SaveParams<RolePutReq> IExamplesProvider<SaveParams<RolePutReq>>.GetExamples()
        {

            var data = new SaveParams<RolePutReq>()
            {
                Data = new RolePutReq()
                {
                    EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                    RoleName = "Role 1",
                    RoleDescription = "Role 1 description",
                    IsActive = true,
                    RolePermissions = new List<RolePermissionPutReq>(),
                    DeviceFilters = new RoleFiltersPutReq(),
                    ConcurrencyValue = 0,
                }

            };

            data.Data.RolePermissions.Add(new RolePermissionPutReq()
            {
                //ConcurrencyValue = 0
            });

            return data;
        }
    }

}