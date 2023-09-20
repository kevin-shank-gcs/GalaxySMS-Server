using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaTimeScheduleDayPeriodRepository : IDataRepository<AssaTimeScheduleDayPeriod>
    {
        IEnumerable<AssaTimeScheduleDayPeriod> GetAllForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AssaTimeScheduleDayPeriod> GetAllForAssaDayPeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

