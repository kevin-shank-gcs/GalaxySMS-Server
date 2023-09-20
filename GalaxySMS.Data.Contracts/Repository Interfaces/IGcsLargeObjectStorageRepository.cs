using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsLargeObjectStorageRepository : IDataRepository<gcsLargeObjectStorage>
    {
        gcsLargeObjectStorage GetForEntityAndUniqueTag(Guid entityId, string uniqueTag, IApplicationUserSessionDataHeader sessionData);
    }
}
