using System;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserEntityRoleRepository : IDataRepository<gcsUserEntityRole>
    {
        IEnumerable<gcsUserEntityRole> GetByUserEntityId(Guid userEntityId);
        //IEnumerable<gcsUserEntityRole> GetByUserEntityIdAndApplicationId(Guid userEntityId, Guid applicationId);
        //IEnumerable<gcsUserEntityRole> GetByEntityApplicationRoleId(Guid entityApplicationRoleId);
        IEnumerable<gcsUserEntityRole> GetByUserId(Guid userId);
        //IEnumerable<gcsUserEntityRole> GetByUserIdAndEntityId(Guid userId, Guid entityId);
        //IEnumerable<gcsUserEntityRole> GetByUserIdAndEntityIdAndApplicationId(Guid userId, Guid entityId, Guid applicationId);
        //IEnumerable<gcsUserEntityRole> GetByUserEntityIdAndRoleId(Guid userEntityId, Guid roleId);
    }
}
