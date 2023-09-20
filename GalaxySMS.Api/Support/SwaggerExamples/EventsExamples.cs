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
    public class EventSearchParametersExamples : IExamplesProvider<ApiEntities.EventSearchParameters>
    {
        ApiEntities.EventSearchParameters IExamplesProvider<ApiEntities.EventSearchParameters>.GetExamples()
        {
            var retData = new ApiEntities.EventSearchParameters
            {
                StartDateTime = DateTimeOffset.Now - TimeSpan.FromDays(3),
                EndDateTime = DateTimeOffset.Now,
                IncludeAcknowledgements = true,
                IncludeLoggingOnOffEvents = true
            };
            retData.EventTypeUids.Add(GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessDenied);
            retData.EventTypeUids.Add(GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGranted);
            retData.EventTypeUids.Add(GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorForcedOpen);

            retData.StartPriority = 0;
            retData.EndPriority = 10000;
            retData.Priorities.Add(1000);
            retData.Priorities.Add(2000);
            retData.Priorities.Add(3000);
            return retData;
        }
    }
}