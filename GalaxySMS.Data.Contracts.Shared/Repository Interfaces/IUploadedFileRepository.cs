using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IUploadedFileRepository : IDataRepository<UploadedFile>
    {
        IEnumerable<UploadedFile> GetAllForTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<UploadedFile> GetForUniqueFilename(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<UploadedFile> GetForOriginalFilename(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        int DeleteStaleImages(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}

