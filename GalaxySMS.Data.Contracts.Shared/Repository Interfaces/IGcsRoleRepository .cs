using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsRoleRepository : IPagedDataRepository<gcsRole>, IHasGetEntityId
    {
        IEnumerable<gcsRole> GetAllRolesForEntity(Guid entityId, IGetParametersWithPhoto getParameters);
        //IEnumerable<gcsRole> GetAllRolesForApplication(Guid applicationId, IGetParametersWithPhoto getParameters);
        //IEnumerable<gcsRole> GetAllRolesForApplicationAndEntity(Guid applicationId, Guid entityId, IGetParametersWithPhoto getParameters);
        //IEnumerable<gcsRole> GetAllRolesForUserAndEntityAndApplication(Guid userId, Guid entityId, Guid applicationId, IGetParametersWithPhoto getParameters);
        //IEnumerable<gcsRole> GetAllRolesForUserEntityAndApplication(Guid userEntityId, Guid applicationId, IGetParametersWithPhoto getParameters);
        IEnumerable<Guid> GetAllPrimaryKeyUids(Guid entityId);
        IEnumerable<Guid> GetAllDefaultUids(Guid entityId);

        //IArrayResponse<gcsRole> GetAllRolesForApplicationPaged(Guid applicationId,
        //    IGetParametersWithPhoto getParameters);

        IArrayResponse<gcsRole> GetAllRolesForEntityPaged(Guid entityId,
            IGetParametersWithPhoto getParameters, Guid userId);

        string GetRoleName(Guid roleId);

    }
}

