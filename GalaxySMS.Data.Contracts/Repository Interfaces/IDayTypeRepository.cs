using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IDayTypeRepository : IPagedDataRepository<DayType>, IHasGetEntityId
    {
        DayType GetByEntityIdAndDayTypeCode(Guid entityId, GalaxySMS.Common.Enums.DayTypeCode code,
            bool includeMemberCollections);
        DayType GetLowestInActiveByEntityId(Guid entityId, bool includeMemberCollections);

        IArrayResponse<DayType> GetAllDayTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DayType> GetAllDayTypesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DayType> GetAllDayTypesForGalaxyCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DayType> GetAllDayTypesForAssaAbloyDsr(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DayType> GetAllDayTypesForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

