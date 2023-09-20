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
    public class SaveGalaxyTimePeriodExamples : IExamplesProvider<SaveParams<GalaxyTimePeriodReq>>
    {
        SaveParams<GalaxyTimePeriodReq> IExamplesProvider<SaveParams<GalaxyTimePeriodReq>>.GetExamples()
        {
            var data = new GalaxyTimePeriodReq()
            {
                GalaxyTimePeriodUid = Guid.Empty,
                EntityId = Guid.Empty,
                Display = "Sample GalaxyTimePeriod",
                Description = "Time Period Description",
                PanelTimePeriodNumber = 0,
                TimePeriods = new List<TimePeriodReq>(),
                //EntityIds = new List<Guid>(),
                //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
            };
            data.TimePeriods.Add(new TimePeriodReq()
            {
                Name = $"8AM - 5PM",
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
            });
            return new SaveParams<GalaxyTimePeriodReq>()
            {
                Data = data,
            };
        }
    }

    public class SaveApiEntitiesGalaxyTimePeriodExamples : IExamplesProvider<SaveParams<GalaxyTimePeriodPutReq>>
    {
        SaveParams<GalaxyTimePeriodPutReq> IExamplesProvider<SaveParams<GalaxyTimePeriodPutReq>>.GetExamples()
        {
            var data = new GalaxyTimePeriodPutReq()
            {
                GalaxyTimePeriodUid = Guid.Empty,
                EntityId = Guid.Empty,
                Display = "Sample GalaxyTimePeriod",
                Description = "Time Period Description",
                PanelTimePeriodNumber = 0,
                TimePeriods = new List<TimePeriodPutReq>(),
                //EntityIds = new List<Guid>(),
                //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                ConcurrencyValue = 0,
            };

            data.TimePeriods.Add(new TimePeriodPutReq()
                {
                    StartTime = new TimeSpan(7,30,0),
                    EndTime = new TimeSpan(12,0,0),
                    Name = $"7:30 am - Noon",
                    ConcurrencyValue = 0,
                });

            data.TimePeriods.Add(new TimePeriodPutReq()
            {
                StartTime = new TimeSpan(12,45,0),
                EndTime = new TimeSpan(17,0,0),
                Name = $"12:45 pm - 5pm",
                ConcurrencyValue = 0,
            });
            return new SaveParams<GalaxyTimePeriodPutReq>()
            {
                Data = data

            };
        }
    }

}