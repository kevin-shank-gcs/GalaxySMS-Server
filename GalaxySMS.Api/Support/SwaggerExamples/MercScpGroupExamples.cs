using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using GalaxySMS.Common.Constants;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveMercScpGroupExamples : IExamplesProvider<SaveParams<MercScpGroupReq>>
    {
        SaveParams<MercScpGroupReq> IExamplesProvider<SaveParams<MercScpGroupReq>>.GetExamples()
        {
            return new SaveParams<MercScpGroupReq>()
            {
                Data = new MercScpGroupReq()
                {
                    MercScpGroupUid = Guid.Empty,
                    Name = "Sample MercScpGroup",
                    EntityId = EntityIds.GalaxySMS_DefaultEntity_Id,
                    SiteUid = Guid.Empty,
                    IsActive = true,
                    RoleIds = new List<Guid>(),
                }
            };
        }
    }

    public class SaveApiEntitiesMercScpGroupExamples : IExamplesProvider<SaveParams<MercScpGroupPutReq>>
    {
        SaveParams<MercScpGroupPutReq> IExamplesProvider<SaveParams<MercScpGroupPutReq>>.GetExamples()
        {
            return new SaveParams<MercScpGroupPutReq>()
            {
                Data = new MercScpGroupPutReq()
                {
                    MercScpGroupUid = Guid.Empty,

                    SiteUid = Guid.Empty,

                    //EntityIds = new List<Guid>(),
                    RoleIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<ApiEntities.EntityIdEntityMapPermissionLevel>(),
                }

            };
        }
    }

    public class MercScpGroupCommandExamples : IExamplesProvider<CommandParams<GalaxyCpuCommandActionReq>>
    {
        CommandParams<GalaxyCpuCommandActionReq> IExamplesProvider<CommandParams<GalaxyCpuCommandActionReq>>.GetExamples()
        {
            var p = new CommandParams<GalaxyCpuCommandActionReq>()
            {
                Data = new GalaxyCpuCommandActionReq()
                {
                    CommandAction = Common.Enums.GalaxyCpuCommandActionCode.RequestControllerInformation,
                }
            };
            return p;
        }
    }

}