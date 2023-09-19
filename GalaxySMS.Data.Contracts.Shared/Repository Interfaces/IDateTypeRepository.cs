using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IDateTypeRepository : IPagedDataRepository<DateType>, IHasGetEntityId
    {
        DateType GetDateTypeForEntityAndDate(Guid entityId, DateTimeOffset date);
        IArrayResponse<DateType> GetAllDateTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DateType> GetAllDateTypesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IArrayResponse<DateType> GetAllDateTypesForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<DateType_PanelLoadData> GetPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxySMS.Common.Enums.TimeScheduleType scheduleType);
        IEnumerable<DateType_PanelLoadData> GetPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<DateType_GetClustersThatUseDateType> GetClustersThatUseDateType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        DateTypeDefaultBehavior_PanelLoadData GetDefaultBehaviorPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        DateDayTypeInfo GetDateDayTypeInfo(Guid entityId, DateTimeOffset date);
    }
}

