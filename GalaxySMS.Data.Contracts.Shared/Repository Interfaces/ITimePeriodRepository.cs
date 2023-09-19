using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimePeriodRepository : IDataRepository<TimePeriod>, IHasGetEntityId
    {
        IEnumerable<TimePeriod> GetAllTimePeriodsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        TimePeriod FindMatchingTimePeriodByTimes(IApplicationUserSessionDataHeader sessionData, IGetParameters<TimePeriod> parameters);
        TimePeriod FindMatchingTimePeriodName(IApplicationUserSessionDataHeader sessionData, IGetParameters<TimePeriod> parameters);
        IEnumerable<TimePeriod> GetAllTimePeriodsForAssaDayPeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        //IEnumerable<TimePeriod> GetAllTimePeriodsForTimeScheduleAndDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters, Guid timeScheduleUid, Guid dayTypeUid);
        IEnumerable<TimePeriod> GetAllTimePeriodsForGalaxyTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

