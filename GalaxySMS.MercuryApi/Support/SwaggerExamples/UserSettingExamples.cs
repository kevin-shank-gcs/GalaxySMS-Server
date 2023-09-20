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
    public class SaveUserSettingPostExamples : IExamplesProvider<SaveParams<UserSettingPostReq>>
    {
        SaveParams<UserSettingPostReq> IExamplesProvider<SaveParams<UserSettingPostReq>>.GetExamples()
        {
            var data = new UserSettingPostReq()
            {
                UserId = GalaxySMS.Common.Constants.UserIds.GalaxySMS_Administrator_Id,
                ApplicationId = null,//GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id,
                Category = "Category 1",
                SettingKey = "Key 1",
                SettingValue = "Some Setting Value XYZ",
                SettingDescription = "Setting desc",
            };


            return new SaveParams<UserSettingPostReq>()
            {
                Data = data
            };
        }
    }


    public class SaveUserSettingPutExamples : IExamplesProvider<SaveParams<UserSettingPutReq>>
    {
        SaveParams<UserSettingPutReq> IExamplesProvider<SaveParams<UserSettingPutReq>>.GetExamples()
        {
            var data = new UserSettingPutReq()
            {
                UserId = GalaxySMS.Common.Constants.UserIds.GalaxySMS_Administrator_Id,
                ApplicationId = null,//GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id,
                Category = "Category 1",
                SettingKey = "Key 1",
                SettingValue = "Some Setting Value XYZ",
                SettingDescription = "Setting desc",
            };


            return new SaveParams<UserSettingPutReq>()
            {
                Data = data
            };
        }
    }

}