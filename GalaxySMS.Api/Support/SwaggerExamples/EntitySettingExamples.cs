using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Business.Entities.Api.NetCore;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveEntitySettingPostExamples : IExamplesProvider<SaveParams<gcsSettingPostReq>>
    {
        SaveParams<gcsSettingPostReq> IExamplesProvider<SaveParams<gcsSettingPostReq>>.GetExamples()
        {
            var data = new gcsSettingPostReq()
            {
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                SettingGroup = "Group 1",
                SettingSubGroup = "Sub-Group 1",
                SettingKey = "Key 1",
                Value = "Some Setting Value XYZ"
            };


            return new SaveParams<gcsSettingPostReq>()
            {
                Data = data
            };
        }
    }


    public class SaveEntitySettingPutExamples : IExamplesProvider<SaveParams<gcsSettingPutReq>>
    {
        SaveParams<gcsSettingPutReq> IExamplesProvider<SaveParams<gcsSettingPutReq>>.GetExamples()
        {
            var data = new gcsSettingPutReq()
            {
                SettingId = Guid.Empty,
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                SettingGroup = "Group 1",
                SettingSubGroup = "Sub-Group 1",
                SettingKey = "Key 1",
                Value = "Some Setting Value XYZ"
            };


            return new SaveParams<gcsSettingPutReq>()
            {
                Data = data
            };
        }
    }

}