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
    public class SaveSiteExamples : IExamplesProvider<SaveParams<SiteReq>>
    {
        SaveParams<SiteReq> IExamplesProvider<SaveParams<SiteReq>>.GetExamples()
        {
            return new SaveParams<SiteReq>()
            {
                Data = new SiteReq()
                {
                    SiteUid = Guid.Empty,
                    SiteName = "Sample Site",
                    SiteId = "Unique Site ID",
                    EntityIds = new List<Guid>(),
                    RegionUid = Guid.Empty,
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    Address = new AddressReq(),
                }
            };
        }
    }

    public class SaveApiEntitiesSiteExamples : IExamplesProvider<SaveParams<SitePutReq>>
    {
        SaveParams<SitePutReq> IExamplesProvider<SaveParams<SitePutReq>>.GetExamples()
        {
            return new SaveParams<SitePutReq>()
            {
                Data = new SitePutReq()
                {
                    SiteUid = Guid.Empty,
                    SiteName = "Sample Site",
                    SiteId = "Unique Site ID",
                    EntityIds = new List<Guid>(),
                    RegionUid = Guid.Empty,
                    //MappedEntitiesPermissionLevels = new List<ApiEntities.EntityIdEntityMapPermissionLevel>(),
                    Address = new AddressPutReq(),
                    ConcurrencyValue = 0,
                }

            };
        }
    }

}