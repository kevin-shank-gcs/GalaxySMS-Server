using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GCS.Core.Common.Extensions;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveDayTypeExamples : IExamplesProvider<SaveParams<DayTypeReq>>
    {

        SaveParams<DayTypeReq> IExamplesProvider<SaveParams<DayTypeReq>>.GetExamples()
        {
            var data = new DayTypeReq
            {
                DayTypeUid = Guid.Empty,
                EntityId = Guid.Empty,
                Name = "Sample DayType",
                Notes = "Time Period Description",
                DayTypeCode = Common.Enums.DayTypeCode.DayType0,
                //HighlightColor = 0,
                HighlightColorRGBA = 0.ToRGBA(),
                Dates = new List<DayTypeDateReq>()
                //EntityIds = new List<Guid>(),
                //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
            };
            data.Dates.Add(new DayTypeDateReq()
            {
                Date = DateTime.Today,
                Title = "Sample Day"
            });
            data.Dates.Add(new DayTypeDateReq()
            {
                Date = DateTime.Today.AddDays(7),
                Title = "Sample Day"
            });

            return new SaveParams<DayTypeReq>()
            {
                Data = data,
            };
        }
    }

    public class SaveApiEntitiesDayTypeExamples : IExamplesProvider<SaveParams<DayTypePutReq>>
    {
        SaveParams<DayTypePutReq> IExamplesProvider<SaveParams<DayTypePutReq>>.GetExamples()
        {
            var data = new SaveParams<DayTypePutReq>()
            {
                Data = new DayTypePutReq()
                {
                    DayTypeUid = Guid.Empty,
                    EntityId = Guid.Empty,
                    Name = "Sample DayType",
                    Notes = "",
                    DayTypeCode = Common.Enums.DayTypeCode.DayType0,
                    //HighlightColor = 0,
                    //EntityIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<ApiEntities.EntityIdEntityMapPermissionLevel>(),
                    HighlightColorRGBA = 0.ToRGBA(),
                    Dates = new List<DayTypeDateReq>(),
                    ConcurrencyValue = 0,
                }
            };
            data.Data.Dates.Add(new DayTypeDateReq()
            {
                Date = DateTime.Today,
                Title = "Sample Day"
            });
            data.Data.Dates.Add(new DayTypeDateReq()
            {
                Date = DateTime.Today.AddDays(7),
                Title = "Sample Day"
            });
            return data;
        }
    }

}