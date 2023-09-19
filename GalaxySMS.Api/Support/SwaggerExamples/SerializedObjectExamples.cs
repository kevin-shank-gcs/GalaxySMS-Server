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
    public class SaveSerializedObjectPostExamples : IExamplesProvider<SaveParams<gcsSerializedObjectPostReq>>
    {
        SaveParams<gcsSerializedObjectPostReq> IExamplesProvider<SaveParams<gcsSerializedObjectPostReq>>.GetExamples()
        {
            var data = new gcsSerializedObjectPostReq()
            {
                SerializedObjectId = Guid.Empty,
                ApplicationId = Guid.Empty,
                Key = "Key 1",
                SerializedObject = "Some text data. Could be XML, JSON, HTML or free-from text"
            };


            return new SaveParams<gcsSerializedObjectPostReq>()
            {
                Data = data
            };
        }
    }


    public class SaveSerializedObjectPutExamples : IExamplesProvider<SaveParams<gcsSerializedObjectPutReq>>
    {
        SaveParams<gcsSerializedObjectPutReq> IExamplesProvider<SaveParams<gcsSerializedObjectPutReq>>.GetExamples()
        {
            var data = new gcsSerializedObjectPutReq()
            {
                SerializedObjectId = Guid.Empty,
                ApplicationId = Guid.Empty,
                Key = "Key 1",
                SerializedObject = "Some text data. Could be XML, JSON, HTML or free-from text"
            };


            return new SaveParams<gcsSerializedObjectPutReq>()
            {
                Data = data
            };
        }
    }

}