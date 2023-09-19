using System;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserEntityApplicationRoleRepository : IDataRepository<gcsUserEntityApplicationRole>
    {
        IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityId(Guid userEntityId);
        IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityIdAndApplicationId(Guid userEntityId, Guid applicationId);
        IEnumerable<gcsUserEntityApplicationRole> GetByEntityApplicationRoleId(Guid entityApplicationRoleId);
        IEnumerable<gcsUserEntityApplicationRole> GetByUserId(Guid userId);
        IEnumerable<gcsUserEntityApplicationRole> GetByUserIdAndEntityId(Guid userId, Guid entityId);
        IEnumerable<gcsUserEntityApplicationRole> GetByUserIdAndEntityIdAndApplicationId(Guid userId, Guid entityId, Guid applicationId);
        IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityIdAndRoleId(Guid userEntityId, Guid roleId);
    }
}
