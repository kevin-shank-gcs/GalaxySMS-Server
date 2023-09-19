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
    public class SaveDepartmentExamples : IExamplesProvider<SaveParams<DepartmentReq>>
    {
        SaveParams<DepartmentReq> IExamplesProvider<SaveParams<DepartmentReq>>.GetExamples()
        {
            return new SaveParams<DepartmentReq>()
            {
                Data = new DepartmentReq()
                {
                    DepartmentUid = Guid.Empty,
                    EntityId = Guid.Empty,
                    DepartmentName = $"Sample Department",
                    Description = "Sample Description",
                }
            };
        }
    }

    public class SaveApiEntitiesDepartmentExamples : IExamplesProvider<SaveParams<DepartmentPutReq>>
    {
        SaveParams<DepartmentPutReq> IExamplesProvider<SaveParams<DepartmentPutReq>>.GetExamples()
        {
            return new SaveParams<DepartmentPutReq>()
            {
                Data = new DepartmentPutReq()
                {
                    DepartmentUid = Guid.Empty,
                    EntityId = Guid.Empty,
                    DepartmentName = $"Sample Department",
                    Description = "Sample Description",
                    ConcurrencyValue = 0,
                }

            };
        }
    }
}