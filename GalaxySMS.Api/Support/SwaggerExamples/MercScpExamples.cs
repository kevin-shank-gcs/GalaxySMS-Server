using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Extensions;


namespace GalaxySMS.Api.Support
{
    public class SaveMercScpExamples : IExamplesProvider<SaveParams<MercScpReq>>
    {
        SaveParams<MercScpReq> IExamplesProvider<SaveParams<MercScpReq>>.GetExamples()
        {
            var data = new MercScpReq()
            {
                MercScpGroupUid = Guid.Empty,
                ScpName = "Sample Panel Name",
                Location = "Sample Location",
                MercScpType = MercuryPanelType.LP1501,
                TimeZoneId = TimeZoneInfo.Local.Id,
            };

            return new SaveParams<MercScpReq>()
            {
                Data = data,
            };
        }
    }
    public class SaveMercScpPutExamples : IExamplesProvider<SaveParams<MercScpPutReq>>
    {
        SaveParams<MercScpPutReq> IExamplesProvider<SaveParams<MercScpPutReq>>.GetExamples()
        {
            var data = new MercScpPutReq()
            {
                MercScpGroupUid = Guid.Empty,
                ScpName = "Sample Panel Name",
                Location = "Sample Location",
            };

            return new SaveParams<MercScpPutReq>()
            {
                Data = data,
            };
        }
    }

    public class SaveApiEntitiesMercScpExamples : IExamplesProvider<SaveParams<ApiEntities.MercScp>>
    {
        SaveParams<ApiEntities.MercScp> IExamplesProvider<SaveParams<ApiEntities.MercScp>>.GetExamples()
        {
            return new SaveParams<ApiEntities.MercScp>()
            {
                Data = new ApiEntities.MercScp()
                {
                    //MercScpGroupUid = Globals.Instance.,
                }

            };
        }
    }


    public class
        GetHistoryApiEntitiesMercScpExamples : IExamplesProvider<
            MercScpActivityHistoryEventSearchParametersReq>
    {
        MercScpActivityHistoryEventSearchParametersReq
            IExamplesProvider<MercScpActivityHistoryEventSearchParametersReq>.GetExamples()
        {
            var data = new MercScpActivityHistoryEventSearchParametersReq()
            {
                StartDateTime = DateTimeOffset.Now.Today() - new TimeSpan(7, 0, 0, 0),
                EndDateTime = DateTimeOffset.Now,
            };

            return data;
        }
    }
}