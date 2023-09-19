using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Business.Entities.Api.NetCore;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Api.Support
{
    public class SaveLargeObjectStoragePostExamples : IExamplesProvider<SaveParams<gcsLargeObjectStoragePostReq>>
    {
        SaveParams<gcsLargeObjectStoragePostReq> IExamplesProvider<SaveParams<gcsLargeObjectStoragePostReq>>.GetExamples()
        {
            var encodeThis = "Some text data. Could be XML, JSON, HTML or free-from text";

            var data = new gcsLargeObjectStoragePostReq()
            {
                Uid = Guid.Empty,
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                UniqueTag = "UniqueTag 1",
                DataType = "TextData",
                TextData = "Some Text Data about the large object",
                FileStreamData = encodeThis.Base64StringEncode().ConvertBase64StringToByteArray(),
                BlobData = encodeThis.Base64StringEncode().ConvertBase64StringToByteArray()
            };


            return new SaveParams<gcsLargeObjectStoragePostReq>()
            {
                Data = data
            };
        }
    }


    public class SaveLargeObjectStoragePutExamples : IExamplesProvider<SaveParams<gcsLargeObjectStoragePutReq>>
    {
        SaveParams<gcsLargeObjectStoragePutReq> IExamplesProvider<SaveParams<gcsLargeObjectStoragePutReq>>.GetExamples()
        {
            var encodeThis = "Some text data. Could be XML, JSON, HTML or free-from text";

            var data = new gcsLargeObjectStoragePutReq()
            {
                Uid = Guid.Empty,
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                UniqueTag = "UniqueTag 1",
                DataType = "TextData",
                TextData = "Some Text Data about the large object",
                FileStreamData = encodeThis.Base64StringEncode().ConvertBase64StringToByteArray(),
                BlobData = encodeThis.Base64StringEncode().ConvertBase64StringToByteArray()
            };

            return new SaveParams<gcsLargeObjectStoragePutReq>()
            {
                Data = data
            };
        }
    }

}