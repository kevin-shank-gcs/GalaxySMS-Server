using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimeScheduleDayTypeTimePeriodRepository : IDataRepository<TimeScheduleDayTypeTimePeriod>
    {
        IEnumerable<TimeScheduleDayTypeTimePeriod> GetAllForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeTimePeriod> GetAllForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeTimePeriod> GetAllForTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeTimePeriod> GetAllForTimeScheduleAndDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters, Guid timeScheduleUid, Guid dayTypeUid);
    }
}

