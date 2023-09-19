using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsEntityRepository : IPagedDataRepository<gcsEntity>
    {
        IEnumerable<gcsEntity> GetEntitiesForUser(Guid userId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsEntity> GetChildEntitiesForParent(Guid parentId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        IEnumerable<gcsEntity> GetEntityHierarchy(Guid toplevelEntityId, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters);
        gcsEntityCounts GetNewestCountsForEntity(Guid entityId);
        gcsEntityCounts UpdateCountsForEntity(Guid entityId);

        IEnumerable<gcsEntity> GetByName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsEntity> GetByDescription(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<gcsEntity> GetByNameOrDescription(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        IArrayResponse<gcsEntity> GetEntitiesForUserPaged(Guid userId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<gcsEntity> GetByNamePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<gcsEntity> GetByDescriptionPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IArrayResponse<gcsEntity> GetByNameOrDescriptionPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        int DeleteEntity(Guid entityId, IApplicationUserSessionDataHeader sessionData, IDeleteParameters deleteParams);
        string GetEntityName(Guid entityId);
    }
}
