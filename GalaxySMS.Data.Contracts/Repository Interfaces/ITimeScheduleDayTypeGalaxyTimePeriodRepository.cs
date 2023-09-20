using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimeScheduleDayTypeGalaxyTimePeriodRepository : IDataRepository<TimeScheduleDayTypeGalaxyTimePeriod>
    {
        IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForGalaxyTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForTimeScheduleAndDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters, Guid timeScheduleUid, Guid dayTypeUid);
    }
}

