using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Extensions;
namespace GalaxySMS.Api.Support
{
    public class SaveAccessPortalExamples : IExamplesProvider<SaveParams<AccessPortalReq>>
    {
        SaveParams<AccessPortalReq> IExamplesProvider<SaveParams<AccessPortalReq>>.GetExamples()
        {
            var data = new AccessPortalReq()
            {
            };


            return new SaveParams<AccessPortalReq>()
            {
                Data = data,
            };
        }
    }
}

public class SaveApiEntitiesAccessPortalExamples : IExamplesProvider<SaveParams<AccessPortalPutReq>>
{
    SaveParams<AccessPortalPutReq> IExamplesProvider<SaveParams<AccessPortalPutReq>>.GetExamples()
    {
        var data = new SaveParams<AccessPortalPutReq>()
        {
            Data = new AccessPortalPutReq()
            {
                PortalName = "Sample Access Portal Name",
                ConcurrencyValue = 1,
                Properties = new AccessPortalPropertiesPutReq()
                {
                    ConcurrencyValue = 1,
                },
                Areas = new List<AccessPortalAreaPutReq>(),
                Schedules = new List<AccessPortalTimeSchedulePutReq>(),
                AlertEvents = new List<AccessPortalAlertEventPutReq>(),
                AuxiliaryOutputs = new List<AccessPortalAuxiliaryOutputPutReq>(),
                Notes = new List<NotePutReq>(),
                AccessGroups = new List<AccessGroupAccessPortalApPutReq>(),
            }

        };

        data.Data.Areas.Add(new AccessPortalAreaPutReq()
        {
            AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.ToArea,
            ConcurrencyValue = 1,
        });

        data.Data.Areas.Add(new AccessPortalAreaPutReq()
        {
            AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.FromArea,
            ConcurrencyValue = 1,
        });

        data.Data.Areas.Add(new AccessPortalAreaPutReq()
        {
            AccessPortalAreaTypeUid = GalaxySMS.Common.Constants.AccessPortalAreaTypeIds.WhosInArea,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AutomaticUnlock,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.PinRequired,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.AuxiliaryOutput,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.CrisisUnlock,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableForcedOpen,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.Schedules.Add(new AccessPortalTimeSchedulePutReq()
        {
            AccessPortalScheduleTypeUid = GalaxySMS.Common.Constants.AccessPortalScheduleTypeIds.DisableOpenTooLong,
            TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.AlertEvents.Add(new AccessPortalAlertEventPutReq()
        {
            AccessPortalAlertEventTypeUid = GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.ForcedOpen,
            AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
            ConcurrencyValue = 1,
        });

        data.Data.AuxiliaryOutputs.Add(new AccessPortalAuxiliaryOutputPutReq()
        {
            AccessPortalAuxiliaryOutputModeUid = GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows,
            ConcurrencyValue = 1
        });

        data.Data.AccessGroups.Add(new AccessGroupAccessPortalApPutReq()
        {

        });

        data.SavePhoto = false;
        //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveAccessPortalAreasOption), GalaxySMS.Common.Enums.SaveAccessPortalAreasOption.DeleteMissingItems.ToString()));
        //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveAccessPortalSchedulesOption), GalaxySMS.Common.Enums.SaveAccessPortalSchedulesOption.DeleteMissingItems.ToString()));
        //data.IgnoreProperties.Add(nameof(data.Data.Notes));
        return data;
    }
}


public class GetHistoryApiEntitiesAccessPortalExamples : IExamplesProvider<AccessPortalActivityHistoryEventSearchParametersReq>
{
    AccessPortalActivityHistoryEventSearchParametersReq IExamplesProvider<AccessPortalActivityHistoryEventSearchParametersReq>.GetExamples()
    {
        var data = new AccessPortalActivityHistoryEventSearchParametersReq()
        {
            StartDateTime = DateTimeOffset.Now.Today() - new TimeSpan(7, 0, 0, 0),
            EndDateTime = DateTimeOffset.Now,
        };


        return data;
    }
}
