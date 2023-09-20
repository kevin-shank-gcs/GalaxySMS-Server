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
    public class SaveDateTypeExamples : IExamplesProvider<SaveParams<DateTypeReq>>
    {

        SaveParams<DateTypeReq> IExamplesProvider<SaveParams<DateTypeReq>>.GetExamples()
        {
            var data = new DateTypeReq()
            {
                DateTypeUid = Guid.Empty,
                EntityId = Guid.Empty,
                Date = DateTime.Today,
                Title = "Sample Title"
            };

            return new SaveParams<DateTypeReq>()
            {
                Data = data,
            };
        }
    }

    public class SaveApiEntitiesDateTypeExamples : IExamplesProvider<SaveParams<ApiEntities.DateType>>
    {
        SaveParams<ApiEntities.DateType> IExamplesProvider<SaveParams<ApiEntities.DateType>>.GetExamples()
        {
            return new SaveParams<ApiEntities.DateType>()
            {
                Data = new ApiEntities.DateType()
                {
                    DateTypeUid = Guid.Empty,
                    EntityId = Guid.Empty,
                    Date = DateTime.Today,
                    Title = "Sample Title",
                    ConcurrencyValue = 0,
                }

            };
        }
    }

}