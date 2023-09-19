using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsEntityApplicationRoleRepository : IDataRepository<gcsEntityApplicationRole>
    {
        IEnumerable<gcsEntityApplicationRole> GetAllEntityApplicationRolesForEntityApplication(Guid entityApplicationId);
        IEnumerable<gcsEntityApplicationRole> GetAllEntityApplicationRolesForRole(Guid roleId);
        gcsEntityApplicationRole GetForEntityApplicationAndRole(Guid entityApplicationId, Guid roleId);
        Guid GetIdForEntityApplicationAndRoleIds(Guid entityId, Guid applicationId, Guid roleId);

    }
}

