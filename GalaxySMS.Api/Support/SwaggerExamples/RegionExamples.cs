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
    public class SaveRegionExamples : IExamplesProvider<SaveParams<RegionReq>>
    {
        SaveParams<RegionReq> IExamplesProvider<SaveParams<RegionReq>>.GetExamples() => new SaveParams<RegionReq>()
        {
            Data = new RegionReq()
            {
                RegionUid = Guid.Empty,
                RegionName = "Sample Region",
                RegionId = "Unique Region ID",
                EntityIds = new List<Guid>(),
                //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
            }
        };
    }

    public class SaveApiEntitiesRegionExamples : IExamplesProvider<SaveParams<RegionPutReq>>
    {
        SaveParams<RegionPutReq> IExamplesProvider<SaveParams<RegionPutReq>>.GetExamples()
        {
            return new SaveParams<RegionPutReq>()
            {
                Data = new RegionPutReq()
                {
                    RegionUid = Guid.Empty,
                    RegionName = "Sample Region",
                    RegionId = "Unique Region ID",
                    EntityIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    ConcurrencyValue = 0,
                    gcsBinaryResource = new BinaryResourceReq()
                    {

                    },
                }

            };
        }
    }

}