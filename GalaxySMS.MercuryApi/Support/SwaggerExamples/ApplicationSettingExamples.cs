using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Business.Entities.Api.NetCore;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.MercuryApi.Support
{
    public class SaveApplicationSettingPostExamples : IExamplesProvider<SaveParams<gcsApplicationSettingPostReq>>
    {
        SaveParams<gcsApplicationSettingPostReq> IExamplesProvider<SaveParams<gcsApplicationSettingPostReq>>.GetExamples()
        {
            var data = new gcsApplicationSettingPostReq()
            {
                ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id,
                Category = "Category 1",
                SettingKey = "Key 1",
                SettingValue = "Some Setting Value XYZ",
                SettingDescription = "Setting desc",
                IsActive = true
            };


            return new SaveParams<gcsApplicationSettingPostReq>()
            {
                Data = data
            };
        }
    }


    public class SaveApplicationSettingPutExamples : IExamplesProvider<SaveParams<gcsApplicationSettingPutReq>>
    {
        SaveParams<gcsApplicationSettingPutReq> IExamplesProvider<SaveParams<gcsApplicationSettingPutReq>>.GetExamples()
        {
            var data = new gcsApplicationSettingPutReq()
            {
                ApplicationSettingId = Guid.Empty,
                ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id,
                Category = "Category 1",
                SettingKey = "Key 1",
                SettingValue = "Some Setting Value XYZ",
                SettingDescription = "Setting desc",
                IsActive = true
            };


            return new SaveParams<gcsApplicationSettingPutReq>()
            {
                Data = data
            };
        }
    }

}