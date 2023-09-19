using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaDayPeriodTimePeriodRepository : IDataRepository<AssaDayPeriodTimePeriod>
    {
        IEnumerable<AssaDayPeriodTimePeriod> GetAllForTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AssaDayPeriodTimePeriod> GetAllForAssaDayPeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}

