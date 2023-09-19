using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserEntityRepository : IDataRepository<gcsUserEntity>
    {
        IEnumerable<gcsUserEntity> GetByUserId(Guid userId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsUserEntity> GetByEntityId(Guid entityId, IGetParametersWithPhoto getParameters);
        gcsUserEntity GetByUserIdAndEntityId(Guid userId, Guid entityId, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsUserEntityMinimal> GetMinimalByUserId(Guid userId, IGetParametersWithPhoto getParameters);
    }
}
