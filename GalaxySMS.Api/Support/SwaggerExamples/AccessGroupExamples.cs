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
    public class SaveAccessGroupExamples : IExamplesProvider<SaveParams<AccessGroupReq>>
    {
        SaveParams<AccessGroupReq> IExamplesProvider<SaveParams<AccessGroupReq>>.GetExamples()
        {
            var retData = new SaveParams<AccessGroupReq>()
            {
                Data = new AccessGroupReq()
                {
                    ClusterUid = Globals.Instance.ClusterUid,
                    AccessGroupNumber = GalaxySMS.Common.Constants.AccessGroupLimits.None,
                    Display = "Unique Access Group Name",
                    Description = "Sample description",
                    ServiceComment = "Sample service comment",
                    Comment = "Sample comment",
                    IsEnabled = true,
                    ActivationDate = null,
                    ExpirationDate = null,
                    EntityIds = new List<Guid>(),
                    MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    AccessPortals = new List<AccessGroupAccessPortalReq>(),
                    DefaultTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                }
            };
            retData.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange), GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange.PreferStandardGroup.ToString()));

            retData.Data.AccessPortals.Add(new AccessGroupAccessPortalReq()
            {

            });

            retData.Data.AccessPortals.Add(new AccessGroupAccessPortalReq()
            {

            });

            return retData;
        }
    }

    public class SaveApiEntitiesAccessGroupExamples : IExamplesProvider<SaveParams<AccessGroupPutReq>>
    {
        SaveParams<AccessGroupPutReq> IExamplesProvider<SaveParams<AccessGroupPutReq>>.GetExamples()
        {
            var data = new AccessGroupPutReq()
            {
                ClusterUid = Guid.Empty,
                AccessGroupNumber = 1,
                Display = "Unique Access Group Name 1",
                Description = "Sample description",
                ServiceComment = "Sample service comment",
                Comment = "Sample comment",
                IsEnabled = true,
                ActivationDate = new DateTime(DateTime.Now.Year,1,1, 0, 0, 0),
                ExpirationDate = new DateTime(DateTime.Now.Year + 1, 12,31, 23, 59, 59),
                EntityIds = new List<Guid>(),
                MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                AccessPortals = new List<AccessGroupAccessPortalPutReq>(),
                DefaultTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                ConcurrencyValue = 0,
            };
            data.AccessPortals.Add(new AccessGroupAccessPortalPutReq()
            {
                ConcurrencyValue = 0
            });
            data.AccessPortals.Add(new AccessGroupAccessPortalPutReq()
            {
                ConcurrencyValue = 0
            });
            return new SaveParams<AccessGroupPutReq>()
            {
                Data = data
            };
        }
    }
}