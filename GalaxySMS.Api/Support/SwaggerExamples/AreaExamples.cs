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
    public class SaveAreaExamples : IExamplesProvider<SaveParams<AreaReq>>
    {
        SaveParams<AreaReq> IExamplesProvider<SaveParams<AreaReq>>.GetExamples()
        {
            return new SaveParams<AreaReq>()
            {
                Data = new AreaReq()
                {
                    AreaUid = Guid.Empty,
                    ClusterUid = Globals.Instance.ClusterUid,
                    Display = $"Sample Area X",
                    Description = "Sample Description",
                    AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.NoArea,
                    EntityIds = new List<Guid>(),
                    MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                }
            };
        }
    }

    public class SaveApiEntitiesAreaExamples : IExamplesProvider<SaveParams<AreaPutReq>>
    {
        SaveParams<AreaPutReq> IExamplesProvider<SaveParams<AreaPutReq>>.GetExamples()
        {
            return new SaveParams<AreaPutReq>()
            {
                Data = new AreaPutReq()
                {
                    AreaUid = Guid.Empty,
                    ClusterUid = Guid.Empty,
                    Display = $"Sample Area X",
                    Description = "Sample Description",
                    AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.NoArea,
                    EntityIds = new List<Guid>(),
                    MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    ConcurrencyValue = 0,
                }

            };
        }
    }
}