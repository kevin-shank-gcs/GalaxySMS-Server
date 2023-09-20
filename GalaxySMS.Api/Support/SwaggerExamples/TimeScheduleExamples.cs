using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveTimeScheduleExamples : IExamplesProvider<SaveParams<TimeScheduleReq>>
    {

        SaveParams<TimeScheduleReq> IExamplesProvider<SaveParams<TimeScheduleReq>>.GetExamples()
        {
            var data = new TimeScheduleReq()
            {
                TimeScheduleUid = Guid.Empty,
                EntityId = Guid.Empty,
                Display = "Sample M-F 7-5 Schedule",
                Description = "Fifteen minute only sample",
                //TimeScheduleDayTypesTimePeriods = new List<TimeScheduleDayTypeTimePeriodReq>(),
                //TimeScheduleDayTypesGalaxyTimePeriods = new List<TimeScheduleDayTypeGalaxyTimePeriodReq>(),
                DayTypesTimePeriods = new List<DayTypeTimePeriodsReq>(),
                //EntityIds = new List<Guid>(),
                //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
            };

            var tp7am5pm= new TimePeriodReq()
            {
                StartTime = new TimeSpan(0, 7, 0, 0),
                EndTime = new TimeSpan(0, 17, 0, 0),
                Name = $"7am - 5pm"
            };

            for (var dt = DayTypeCode.Monday; dt <= DayTypeCode.Friday; dt++)
            {
                var dttp = new DayTypeTimePeriodsReq()
                {
                    DayTypeCode = dt,
                };
                dttp.FifteenMinuteTimePeriods.Add(tp7am5pm);
                data.DayTypesTimePeriods.Add(dttp);
            }

            return new SaveParams<TimeScheduleReq>()
            {
                Data = data,
            };
        }
    }


    public class SaveApiEntitiesTimeScheduleExamples : IExamplesProvider<SaveParams<TimeSchedulePutReq>>
    {
        SaveParams<TimeSchedulePutReq> IExamplesProvider<SaveParams<TimeSchedulePutReq>>.GetExamples()
        {
            return new SaveParams<TimeSchedulePutReq>()
            {
                Data = new TimeSchedulePutReq()
                {
                    TimeScheduleUid = Guid.Empty,
                    EntityId = Guid.Empty,
                    Display = "Sample Time Schedule",
                    Description = "Time Schedule Description",
                    //TimeScheduleDayTypesTimePeriods = new List<TimeScheduleDayTypeTimePeriodReq>(),
                    //TimeScheduleDayTypesGalaxyTimePeriods = new List<TimeScheduleDayTypeGalaxyTimePeriodReq>(),
                    DayTypesTimePeriods = new List<DayTypeTimePeriodsPutReq>(),
                    //EntityIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    ConcurrencyValue = 0,
                }

            };
        }
    }
}